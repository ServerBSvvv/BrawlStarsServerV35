using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Server.Login
{
    public class LoginOkMessage : PiranhaMessage
    {
        public LoginOkMessage(Device device) : base(device)
        {
            this.Id = 20104;
        }

        public override async Task Encode()
        {
            await Stream.WriteInt(0); // HighID
            await Stream.WriteInt(Device.Player.LowID); // LowID

            await Stream.WriteInt(0); // HighID
            await Stream.WriteInt(Device.Player.LowID); // LowID

            await Stream.WriteString(Device.Player.UserToken);
            await Stream.WriteString(null); // Facebook Id
            await Stream.WriteString(null); // Gamecenter Id

            await Stream.WriteInt(31); // Major
            await Stream.WriteInt(96); // Minor
            await Stream.WriteInt(1); // Content

            await Stream.WriteString("dev"); // Environment

            await Stream.WriteInt(0);
            await Stream.WriteInt(0);
            await Stream.WriteInt(0);
        }
    }
}
