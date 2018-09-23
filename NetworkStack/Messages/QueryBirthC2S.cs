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
    /// Query a character's birth day
    /// </summary>
    public class QueryBirthC2S : OrderedMessage
    {
        [MessageProperty]
        public uint TargetID { get; set; }        
        


        public QueryBirthC2S() : base((MessageType)0x01C4, MessageDirection.ClientToServer, (Queues)0x00000003)
        { }

        public QueryBirthC2S(BinaryReader reader) : this()
        {
            Unpack(reader);
        }
        
        public override void Unpack(BinaryReader reader)
        {
            base.Unpack(reader);
            TargetID = reader.ReadUInt32();

        }

        public override void Pack(BinaryWriter writer)
        {
            writer.Write(TargetID);

        }


    }
}
