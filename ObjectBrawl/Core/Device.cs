using ObjectBrawl.Helpers;
using ObjectBrawl.Logic;
using ObjectBrawl.Packets;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Core
{
    public class Device
    {
        public Socket Socket { get; private set; }
        public Player Player { get; set; }

        public Battle Battle { get; set; }

        public Device(Socket socket)
        {
            Socket = socket;
        }

        public async Task ProcessPacket(byte[] buffer)
        {
            await Task.Run(async () => 
            {
                if (buffer.Length >= 7)
                {
                    using (var reader = new Reader(buffer))
                    {
                        var id = reader.ReadUInt16();
                        var length = reader.ReadUInt24();
                        if (buffer.Length - 7 < length) return;

                        if (id >= 10000 && id < 20000)
                        {
                            if (!LogicLaserMessageFactory.Messages.ContainsKey(id))
                            {
                                Console.WriteLine($"Unhandled Message: {id}");
                            }
                            else
                            {
                                if (Activator.CreateInstance(LogicLaserMessageFactory.Messages[id], this, reader) is PiranhaMessage message)
                                {
                                    try
                                    {
                                        message.Id = id;
                                        message.Length = (ushort)length;
                                        message.Version = reader.ReadUInt16();

                                        await Task.Run(async () =>
                                        {
                                            message.Decode();
                                            await message.Process();
                                            Console.WriteLine($"Message {id} handled");
                                            message.Dispose();
                                        }
                                        );
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}
