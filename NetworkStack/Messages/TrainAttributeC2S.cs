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
    /// Spend XP to raise an attribute.
    /// </summary>
    public class TrainAttributeC2S : OrderedMessage
    {
        /// <summary>
        /// The ID of the attribute
        /// </summary>
        [MessageProperty]
        public AttributeID Atype { get; set; }        
        
        /// <summary>
        /// The amount of XP being spent
        /// </summary>
        [MessageProperty]
        public uint XpSpent { get; set; }        
        


        public TrainAttributeC2S() : base((MessageType)0x0045, MessageDirection.ClientToServer, (Queues)0x00000003)
        { }

        public TrainAttributeC2S(BinaryReader reader) : this()
        {
            Unpack(reader);
        }
        
        public override void Unpack(BinaryReader reader)
        {
            base.Unpack(reader);
            Atype = (AttributeID)reader.ReadUInt32();
            XpSpent = reader.ReadUInt32();

        }

        public override void Pack(BinaryWriter writer)
        {
            writer.Write((uint)Atype);
            writer.Write(XpSpent);

        }


    }
}
