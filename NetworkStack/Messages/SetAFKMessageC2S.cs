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
    /// Set AFK message.
    /// </summary>
    public class SetAFKMessageC2S : OrderedMessage
    {
        /// <summary>
        /// The message text
        /// </summary>
        [MessageProperty]
        public string Message { get; set; }        
        


        public SetAFKMessageC2S() : base((MessageType)0x0010, MessageDirection.ClientToServer, (Queues)0x00000003)
        { }

        public SetAFKMessageC2S(BinaryReader reader) : this()
        {
            Unpack(reader);
        }
        
        public override void Unpack(BinaryReader reader)
        {
            base.Unpack(reader);
            Message = reader.ReadString16L();

        }

        public override void Pack(BinaryWriter writer)
        {
            writer.WriteString16L(Message);

        }


    }
}
