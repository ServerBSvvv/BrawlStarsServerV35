using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using ObjectBrawl.Packets.Messages.Server.Team;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Client.Team
{
    public class TeamCreateMessage : PiranhaMessage
    {
        public TeamCreateMessage(Device device, Reader reader) : base (device, reader)
        {

        }

        public override async Task Process()
        {
            await new TeamMessage(Device).SendAsync();
        }
    }
}
