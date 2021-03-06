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
    /// Joins a chat channel
    /// </summary>
    public class AddToChannelC2S : OrderedMessage
    {
        /// <summary>
        /// Channel id, TODO get enum
        /// </summary>
        [MessageProperty]
        public uint Chan { get; set; }        
        


        public AddToChannelC2S() : base((MessageType)0x0145, MessageDirection.ClientToServer, (Queues)0x00000003)
        { }

        public AddToChannelC2S(BinaryReader reader) : this()
        {
            Unpack(reader);
        }
        
        public override void Unpack(BinaryReader reader)
        {
            base.Unpack(reader);
            Chan = reader.ReadUInt32();

        }

        public override void Pack(BinaryWriter writer)
        {
            writer.Write(Chan);

        }


    }
}
