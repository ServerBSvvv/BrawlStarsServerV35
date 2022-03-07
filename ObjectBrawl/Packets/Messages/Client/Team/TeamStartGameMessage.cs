using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using ObjectBrawl.Packets.Messages.Server.Battle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Client.Team
{
    public class TeamStartGameMessage : PiranhaMessage
    {
        public TeamStartGameMessage(Device device, Reader reader) : base(device, reader)
        {
            this.Id = 14355;
        }

        public override async Task Process()
        {
            await new StartLoadingMessage(Device).SendAsync();
        }
    }
}
