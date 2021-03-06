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
    /// Set or update a Character Skill value
    /// </summary>
    public class PrivateUpdateSkillS2C : Message
    {
        /// <summary>
        /// sequence number
        /// </summary>
        [MessageProperty]
        public byte Sequence { get; set; }        
        
        /// <summary>
        /// skill ID
        /// </summary>
        [MessageProperty]
        public SkillID Key { get; set; }        
        
        /// <summary>
        /// skill information
        /// </summary>
        [MessageProperty]
        public Skill Value { get; } = new Skill();
        


        public PrivateUpdateSkillS2C() : base((MessageType)0x02DD, MessageDirection.ServerToClient, (Queues)0x00000009)
        { }

        public PrivateUpdateSkillS2C(BinaryReader reader) : this()
        {
            Unpack(reader);
        }
        
        public override void Unpack(BinaryReader reader)
        {
            base.Unpack(reader);
            Sequence = reader.ReadByte();
            Key = (SkillID)reader.ReadUInt32();
            Value.Unpack(reader);

        }

        public override void Pack(BinaryWriter writer)
        {
            writer.Write(Sequence);
            writer.Write((uint)Key);
            Value.Pack(writer);

        }


    }
}
