using System;

namespace ObjectBrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ServerBSvvvBrawlv35";

            Console.WriteLine("Preparing Server...");
            ServerCore.Init();

            Console.ReadLine();
        }
    }
}
