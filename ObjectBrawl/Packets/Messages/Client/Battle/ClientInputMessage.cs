using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using ObjectBrawl.Packets.Messages.Server.Battle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Client.Battle
{
    public class ClientInputMessage : PiranhaMessage
    {
        public ClientInputMessage(Device device, Reader reader) : base(device, reader)
        {
            this.Id = 10555;
        }

        public override async Task Process()
        {
            if (Device.Battle == null)
            {
                Console.WriteLine("Start");
                Device.Battle = new Logic.Battle(Device);
                await Device.Battle.Start();
            }
        }
    }
}
