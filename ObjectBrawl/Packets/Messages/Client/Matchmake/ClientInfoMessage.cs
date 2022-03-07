using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using ObjectBrawl.Packets.Messages.Server.Battle;
using ObjectBrawl.Packets.Messages.Server.Matchmake;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Client.Matchmake
{
    public class ClientInfoMessage : PiranhaMessage
    {
        public ClientInfoMessage(Device device, Reader reader) : base(device, reader)
        {
            this.Id = 10177;
        }

        public override async Task Process()
        {
            await new UdpConnectionInfoMessage(Device).SendAsync();
        }
    }
}
