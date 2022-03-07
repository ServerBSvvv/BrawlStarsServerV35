using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets.Messages.Server.Battle
{
    public class StartLoadingMessage : PiranhaMessage
    {
        public StartLoadingMessage(Device device) : base (device)
        {
            this.Id = 20559;
        }

        public override async Task Encode()
        {
            await Stream.WriteInt(6); // Players Count
            await Stream.WriteInt(0);
            await Stream.WriteInt(0);

            await Stream.WriteInt(6); // Players Array
            {
                await Stream.WriteInt(Device.Player.HighID);
                await Stream.WriteInt(Device.Player.LowID);

                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(540);

                await Stream.WriteInt(30);

                await Stream.WriteScId(16, Device.Player.SelectedBrawler);
                await Stream.WriteScId(29, 0);

                await Stream.WriteBool(false); // 2 booleans

                //sub_99F90
                {
                    await Stream.WriteString("XeonDEV");

                    await Stream.WriteVInt(100);
                    await Stream.WriteVInt(28000000);
                    await Stream.WriteVInt(43000000);
                    await Stream.WriteVInt(0);
                }

                await Stream.WriteBool(false);
            }
            for (int i = 0; i < 5; i++)
            {
                await Stream.WriteInt(0);
                await Stream.WriteInt(1000 + i);

                await Stream.WriteVInt(i + 1);
                await Stream.WriteVInt(i > 1 ? 1 : 0);
                await Stream.WriteVInt(0);

                await Stream.WriteInt(30);

                await Stream.WriteScId(16, i);
                await Stream.WriteScId(29, 0);

                await Stream.WriteBool(false); // 2 booleans

                //sub_99F90
                {
                    await Stream.WriteString("Player");

                    await Stream.WriteVInt(100);
                    await Stream.WriteVInt(28000000);
                    await Stream.WriteVInt(43000000);
                    await Stream.WriteVInt(0);
                }

                await Stream.WriteBool(false);
            }

            //==========//

            await Stream.WriteInt(0); // Array

            await Stream.WriteInt(0); // Array

            await Stream.WriteInt(0);

            await Stream.WriteVInt(1);
            await Stream.WriteVInt(1);
            await Stream.WriteVInt(1);

            {
                await Stream.WriteBool(false);
                await Stream.WriteVInt(0);
                await Stream.WriteVInt(0);
                await Stream.WriteScId(15, 7); // Map id

                await Stream.WriteBool(false); // 3 booleans
            }
        }
    }
}
