////////////////////////////////////////////////////////////////////////////////////
// This file is generated code.  Do not modify it's contents.
// If changes are required, update the message.xml in the TemplateBulder
// project and run the TemplateBuilder to recreate the files.
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using System.Collections.Generic;
using ACE.Network.Enums;
using ACE.Network.Types;
using ACE.Network.Extensions;

namespace ACE.Network.Messages
{
    /// <summary>
    /// Set or update an Object String property value
    /// </summary>
    public class PrivateUpdateStringS2C : Message
    {
        /// <summary>
        /// sequence number
        /// </summary>
        [MessageProperty]
        public byte Sequence { get; set; }        
        
        /// <summary>
        /// String property ID
        /// </summary>
        [MessageProperty]
        public StringPropertyID Key { get; set; }        
        
        /// <summary>
        /// String property value
        /// </summary>
        [MessageProperty]
        public string Value { get; set; }        
        


        public PrivateUpdateStringS2C() : base((MessageType)0x02D5, MessageDirection.ServerToClient, (Queues)0x00000009)
        { }

        public PrivateUpdateStringS2C(BinaryReader reader) : this()
        {
            Unpack(reader);
        }
        
        public override void Unpack(BinaryReader reader)
        {
            base.Unpack(reader);
            Sequence = reader.ReadByte();
            Key = (StringPropertyID)reader.ReadUInt32();
            reader.Align();
            Value = reader.ReadString16L();

        }

        public override void Pack(BinaryWriter writer)
        {
            writer.Write(Sequence);
            writer.Write((uint)Key);
            writer.Align();
            writer.WriteString16L(Value);

        }


    }
}
