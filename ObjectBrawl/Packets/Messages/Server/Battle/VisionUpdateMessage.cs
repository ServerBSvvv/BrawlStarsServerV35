using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Server.Battle
{
    public class VisionUpdateMessage : PiranhaMessage
    {
        public VisionUpdateMessage(Device device) : base(device)
        {
            this.Id = 24109;
        }

        public int Tick { get; set; }

        public override async Task Encode()
        {
            await Stream.WriteVInt(Tick);
            await Stream.WriteVInt(0);
            await Stream.WriteVInt(2);
            await Stream.WriteVInt(Tick);
            await Stream.WriteHex("00000000d442420f100d200a0200000000000000c0110100444400188500600008002a800060035940629018e40000c3582805308cd73edbc204a00e1dd21f06f862fb627b010080e26ed789dbc204a80e1dd21f06f8c2ebc26b010080e26ed7d4dbc20451a13f0cf0c5f6c5f602000028ee76edf32c016768d1427f18e00c7719ee16000028ee769df82c016968d1427f18e08bed8bed0500008abb5d533f4bc01a5ab4d01f06f882fe827e010080e26ed789d96a029b83204001ce92ad26b059e1010040476003cc5613d8ac440200e0386c82722e043607");
        }
    }
}
