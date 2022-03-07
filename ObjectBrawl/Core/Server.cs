using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ObjectBrawl.Core
{
    public class Server
    {
        private byte[] buffer = new byte[1024];
        private List<Device> clients = new List<Device>();
        private Socket serverSocket;
        private int Port;

        public Server(int port)
        {
            this.Port = port;
            serverSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            serverSocket.Listen(5);
            Console.WriteLine("Server started!");
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            Device device = new Device(socket);
            clients.Add(device);
            Console.WriteLine("New Connection!");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), device);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            Device device = (Device)AR.AsyncState;
            int received = 0;
            try
            {
                received = device.Socket.EndReceive(AR);
            }
            catch (Exception)
            {
                Console.WriteLine("Client Disconnected!");
                device.Socket.Close();
                clients.Remove(device);
                return;
            }

            if (received <= 0)
            {
                Console.WriteLine("Client Disconnected!");
                device.Socket.Close();
                clients.Remove(device);
                return;
            }

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);

            Console.WriteLine($"Received {received} bytes!");

            device.ProcessPacket(data);

            device.Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), device);
        }

        public void SendAsync(Socket socket, byte[] data)
        {
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            }
            catch (Exception) { }
        }

        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    }
}
