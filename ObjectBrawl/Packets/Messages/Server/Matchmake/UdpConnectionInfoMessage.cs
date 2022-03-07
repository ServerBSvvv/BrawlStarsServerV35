using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Server.Matchmake
{
    public class UdpConnectionInfoMessage : PiranhaMessage
    {
        public UdpConnectionInfoMessage(Device device) : base (device)
        {
            this.Id = 24112;
        }

        public override async Task Encode()
        {
            await Stream.WriteVInt(9339);

            await Stream.WriteString(null); // Udp server ip / null = Disable UDP

            await Stream.WriteInt(0); // bytes length

            await Stream.WriteInt(0); // bytes length
        }
    }
}
