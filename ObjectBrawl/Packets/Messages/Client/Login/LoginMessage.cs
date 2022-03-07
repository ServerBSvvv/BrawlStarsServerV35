using ObjectBrawl.Core;
using ObjectBrawl.Database;
using ObjectBrawl.Helpers;
using ObjectBrawl.Packets.Messages.Server.Home;
using ObjectBrawl.Packets.Messages.Server.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Client.Login
{
    public class LoginMessage : PiranhaMessage
    {
        public LoginMessage(Device device, Reader reader) : base(device, reader)
        {
            this.Id = 10101;
        }

        public int HighID;
        public int LowID;
        public string MasterHash;
        public string Token;
        public int Major;
        public int Minor;

        public override void Decode()
        {
            
            HighID = Reader.ReadInt32();
            LowID = Reader.ReadInt32();

            Token = Reader.ReadString();

            Major = Reader.ReadInt32();
            Reader.ReadInt32();
            Minor = Reader.ReadInt32();
        }

        public override async Task Process()
        {
            if (LowID > 0)
            {
                Device.Player = await PlayerDb.GetAsync(LowID);
                Console.WriteLine("Login Decode");
                // send LoginOk and OHD
                await new LoginOkMessage(Device).SendAsync();
                await new OwnHomeDataMessage(Device).SendAsync();
            }
            else
            {
                Device.Player = await PlayerDb.CreateAsync();
                Console.WriteLine("Login Decode");
                // send LoginOk and OHD
                await new LoginOkMessage(Device).SendAsync();
                await new OwnHomeDataMessage(Device).SendAsync();
            }
        }
    }
}
