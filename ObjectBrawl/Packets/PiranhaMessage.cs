using ObjectBrawl.Core;
using ObjectBrawl.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Packets
{
    public class PiranhaMessage : IDisposable
    {
        public PiranhaMessage(Device device)
        {
            Device = device;
            Stream = new MemoryStream();
        }

        public PiranhaMessage(Device device, Reader reader)
        {
            Device = device;
            Reader = reader;
        }

        public MemoryStream Stream { get; set; }
        public Reader Reader { get; set; }
        public Device Device { get; set; }
        public ushort Id { get; set; }
        public ushort Length { get; set; }
        public ushort Version { get; set; }

        public void Dispose()
        {
            Stream = null;
            Reader = null;
            Device = null;
        }

        public virtual void Decode()
        {
        }

        public virtual async Task Encode()
        {
        }

        public virtual async Task Process()
        {
        }

        public async Task<byte[]> BuildPacket()
        {
            using (var stream = new MemoryStream())
            {
                Length = (ushort)Stream.Length;

                await stream.WriteUShort(Id);

                stream.WriteByte(0);

                await stream.WriteUShort(Length);
                await stream.WriteUShort(Version);

                await stream.WriteBuffer(Stream.ToArray());

                await stream.WriteBuffer(new byte[]{0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00});

                return stream.ToArray();
            }
        }

        public async Task SendAsync()
        {
            await this.Encode();
            byte[] buffer = await this.BuildPacket();
            await Task.Run(() => { ServerCore.Server.SendAsync(Device.Socket, buffer); });
        }
    }
}
