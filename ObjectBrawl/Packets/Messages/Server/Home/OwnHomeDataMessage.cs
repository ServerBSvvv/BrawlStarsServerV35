using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Server.Home
{
    public class OwnHomeDataMessage : PiranhaMessage
    {
        public OwnHomeDataMessage(Device device) : base (device)
        {
            this.Id = 24101;
        }

        public override async Task Encode()
        {
            await Device.Player.LogicClientHome(Stream);
            await Device.Player.LogicClientAvatar(Stream);

            await Stream.WriteVInt(5);
        }
    }
}
