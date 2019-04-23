﻿using ACE.Network.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACE.Network.Cryptography
{
    /// <summary>
    /// Forward looking cache for ISAAC calculations.<para />
    /// Manages ISAAC stream cipher and performs key searches.<para />
    /// Manages a range of encryption keys generated by the stream cipher.<para />
    /// </summary>
    public class CryptoSystem
    {
        public const int MaximumEffortLevel = 1024;
        public const int MinimumEffortLevel = 32;
        /// <summary>
        /// dilemma:
        /// Server is at risk proportional to the effort level, yet very bad connections will need decent key search bounds, or effort.
        /// When client takes too long to respond to a retransmit request it's possible that the key is beyond the lower bounds of the search range
        /// when that key is lost the server can no longer decrypt CRCs of client packets, and the session must be destroyed
        /// if session is not destroyed after a key is lost client remains connected but server can no longer reconstitute the C2S stream
        /// This event fires when a key is lost, or in other words, when the effort needed to continue exceeds the maximum level
        /// </summary>
        public event EventHandler OnCryptoSystemCatastrophicFailure;
        /// <summary>
        /// The rate at which key searches have been failing.
        /// </summary>
        public double FailureRate { get; private set; } = 0;
        /// <summary>
        /// Collection of results of key searches since either initialization or EffortLevel was changed
        /// </summary>
        private Queue<bool> Trend = new Queue<bool>();
        /// <summary>
        /// the maximum number of keys / 2 to generate and search through when corrupted packets and forged packets arrive
        /// </summary>
        private int EffortLevel = MinimumEffortLevel;
        /// <summary>
        /// The "middle" offset of the search-range.<para />
        /// </summary>
        private int offset = 0;
        /// <summary>
        /// The underlying stream cipher
        /// </summary>
        private ISAAC Wheel = null;
        /// <summary>
        /// The number of times the stream cipher has advanced.
        /// </summary>
        private int InternalOffset => Wheel.OverallOffset;
        /// <summary>
        /// leftmost and rightmost boundaries of the search-range
        /// </summary>
        private Tuple<int, int> SearchRange => new Tuple<int, int>(Math.Max(0, offset - EffortLevel), offset + EffortLevel);

        /// <summary>
        /// perhaps something like this would be better suited:<para />
        /// https://www.geeksforgeeks.org/interval-tree/
        /// </summary>
        private SortedDictionary<int, uint> Cache = new SortedDictionary<int, uint>();

        public CryptoSystem(byte[] seed)
        {
            if (seed == null)
            {
                throw new ArgumentNullException("seed can not be null");
            }
            if (seed.Length != 4)
            {
                throw new ArgumentOutOfRangeException("seed length is wrong");
            }
            Wheel = new ISAAC(seed);
        }

        /// <summary>
        /// the tuple validity test Tuple.ItemX == 0 won't work for CryptoSystem
        /// the non nullable needs a sibling for tracking its validity
        /// </summary>
        private struct CacheResult
        {
            public bool Invalid;
            public Tuple<int, uint> Key;
        }

        /// <summary>
        /// attempt to get a key identified by an offset<para />
        /// 1. if the key has never been generated yet then generate and store it<para />
        /// 2. return the cached key if it is present in the cache, or an invalid key if not
        /// </summary>
        /// <param name="offset">the offset of the requested key</param>
        /// <returns>the requested key or an invalid key in the case that the key identified by the offset was already generated and removed</returns>
        private CacheResult this[int offset]
        {
            get
            {
                uint? added = null;
                while (InternalOffset < offset + 1)
                {
                    added = Wheel.GetOffset();
                    Cache.Add(InternalOffset - 1, added.Value);
                }
                if (added != null)
                {
                    return new CacheResult() { Key = new Tuple<int, uint>(InternalOffset - 1, added.Value) };
                }
                if (!Cache.ContainsKey(offset))
                {
                    // the key was removed
                    return new CacheResult() { Invalid = true };
                }
                return new CacheResult() { Key = new Tuple<int, uint>(offset, Cache[offset]) };
            }
        }

        /// <summary>
        /// remove all disabled keys, keys having an offset prior to the current search-range<para />
        /// all keys left behind by the moving search-range will never be used for anything<para />
        /// If a shared (between client and server) key exceeds the lower bound of the cache during maximum effort level the session is destroyed (catastrophic failure).
        /// </summary>
        /// <returns>the number of removed keys</returns>
        private int RemoveDisabledKeys()
        {
            Tuple<int, int> range = SearchRange;
            List<int> toBeRelieved = Cache.Keys.Where(k => k < range.Item1).ToList();
            if (toBeRelieved.Count > 0)
            {
                if (AttemptEffortUpgrade())
                {
                    return 0;
                }
                else
                {
                    OnCryptoSystemCatastrophicFailure?.Invoke(this, null);
                }
            }
            foreach (int offset in toBeRelieved)
            {
                Cache.Remove(offset);
            }
            return toBeRelieved.Count;
        }

        /// <summary>
        /// Except for retransmissions no key is ever used for encryption twice by the client, 
        /// Since the callback verified the key and packet validity we won't need to request retransmission
        /// Therefore we can safely discard the verified key
        /// </summary>
        /// <param name="offset">the verified key offset</param>
        /// <returns></returns>
        private bool RemoveVerifiedKey(int offset)
        {
            return Cache.Remove(offset);
        }

        /// <summary>
        /// enumerate through the current range of keys until the callback verifies a key or there are no more keys
        /// if the callback fails then either the key used to encrypt the CRC is not inside the range or the data was corrupted in transit
        /// </summary>
        /// <param name="callback">the verification callback</param>
        /// <returns>whether the key offset was found or not, as reported by the callback testing each</returns>
        public bool Search(Func<Tuple<int, uint>, bool> callback)
        {
            Tuple<int, int> range = SearchRange;
            for (int i = range.Item1; i < range.Item2 + 1; i++)
            {
                CacheResult result = this[i];
                if (result.Invalid)
                {
                    continue;
                }
                if (callback(result.Key))
                {
                    RemoveVerifiedKey(i);
                    offset = i;
                    RemoveDisabledKeys();
                    AdjustEffortLevel(true);
                    return true;
                }
            }
            AdjustEffortLevel(false);
            return false;
        }

        /// <summary>
        /// upgrade the effort level if possible
        /// </summary>
        /// <returns>if the effort level was upgraded or not</returns>
        private bool AttemptEffortUpgrade()
        {
            if (EffortLevel < MaximumEffortLevel)
            {
                EffortLevel *= 2;
                Trend.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// downgrade the effort level if possible
        /// </summary>
        /// <returns>if the effort level was downgraded or not</returns>
        private bool AttemptEffortDowngrade()
        {
            if (EffortLevel > MinimumEffortLevel)
            {
                EffortLevel /= 2;
                Trend.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AdjustEffortLevel(bool keyLocated)
        {
            Trend.Enqueue(keyLocated);
            while (Trend.Count > EffortLevel)
            {
                Trend.Dequeue();
            }
            FailureRate = Trend.DefaultIfEmpty().Average(k => k ? 0 : 1);
            if (Trend.Count >= EffortLevel)
            {
                if (FailureRate == 0)
                {
                    AttemptEffortDowngrade();
                }
            }
        }

        /// <summary>
        /// textual representation of the cache state
        /// </summary>
        public string Artwork
        {
            get
            {
                Tuple<int, int> range = SearchRange;
                List<int> keys = Cache.Keys.Where(k => k > range.Item1 - 1 && k < range.Item2 + 1).ToList();
                StringBuilder sb = new StringBuilder();
                sb.Append($"{EffortLevel} Effort, {(1 - FailureRate).FormatChance()} Quality [ ");
                for (int i = range.Item1 - 1; i < range.Item2 + 1; i++)
                {
                    sb.Append(keys.Contains(i) ? "|" : ".");
                }
                sb.Append(" ]");
                return sb.ToString();
            }
        }

        public override string ToString()
        {
            return Artwork;
        }
    }
}
