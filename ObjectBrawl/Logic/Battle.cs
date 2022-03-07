using ObjectBrawl.Core;
using ObjectBrawl.Packets.Messages.Server.Battle;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ObjectBrawl.Logic
{
    public class Battle
    {
        public int Turn { get; set; }
        public int SubTick { get; set; }
        public Device Device { get; set; }

        public System.Timers.Timer battleTimer;

        public Battle(Device device)
        {
            this.Device = device;
        }

        public void Tick(Object source, ElapsedEventArgs e)
        {
            SubTick++;
            if (SubTick > 4)
            {
                Turn++;
                SubTick = 0;
            }
            new VisionUpdateMessage(Device)
            {
                Tick = Turn
            }.SendAsync();
        }

        public async Task Start()
        {
            Turn = -1;
            SubTick = 0;

            battleTimer = new System.Timers.Timer(10);
            battleTimer.Elapsed += Tick;
            battleTimer.AutoReset = true;
            battleTimer.Enabled = true;

            /*await Task.Run(() =>
            {
                while (Device.Socket.Connected)
                {
                    Tick();
                    Thread.Sleep(1000 / 20);
                }
            });*/
        }
    }
}
