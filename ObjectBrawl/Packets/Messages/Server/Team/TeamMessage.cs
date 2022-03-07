using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Server.Team
{
    public class TeamMessage : PiranhaMessage
    {
        public TeamMessage(Device device) : base (device)
        {
            this.Id = 24124;
        }

        public override async Task Encode()
        {
            await Stream.WriteVInt(1);
            await Stream.WriteBool(false);
            await Stream.WriteVInt(1);

            await Stream.WriteInt(0); // Team HighID
            await Stream.WriteInt(1); // Team LowID

            await Stream.WriteVInt(0);

            await Stream.WriteBool(false);

            await Stream.WriteVInt(0);
            await Stream.WriteVInt(0);

            await Stream.WriteScId(15, 7); // Map Id

            await Stream.WriteBool(false); // Map maker

            await Stream.WriteVInt(1); // Players Array
            {
                await Stream.WriteBool(true);

                await Stream.WriteInt(Device.Player.HighID);
                await Stream.WriteInt(Device.Player.LowID);

                await Stream.WriteScId(16, Device.Player.SelectedBrawler);
                await Stream.WriteScId(29, 0);

                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);

                await Stream.WriteBool(false);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);

                //sub_99F90
                {
                    await Stream.WriteString("XeonDEV");

                    await Stream.WriteVInt(100);
                    await Stream.WriteVInt(28000000 + Device.Player.Thumbnail);
                    await Stream.WriteVInt(43000000 + Device.Player.NameColor);
                    await Stream.WriteVInt(-1);
                }

                await Stream.WriteVInt(0); // Dataref
                await Stream.WriteVInt(0); // Dataref

                await Stream.WriteVInt(0);
            }

            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0); // Array

            await Stream.WriteVInt(0);

            await Stream.WriteVInt(0); // Array

            await Stream.WriteBool(false); // Here's 3 booleans
        }
    }
}
