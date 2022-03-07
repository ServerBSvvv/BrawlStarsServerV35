using ObjectBrawl.Packets.Messages.Client.Battle;
using ObjectBrawl.Packets.Messages.Client.Login;
using ObjectBrawl.Packets.Messages.Client.Matchmake;
using ObjectBrawl.Packets.Messages.Client.Team;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectBrawl.Packets
{
    public class LogicLaserMessageFactory
    {
        public static Dictionary<int, Type> Messages;

        static LogicLaserMessageFactory()
        {
            Messages = new Dictionary<int, Type>
            {
                {10101, typeof(LoginMessage)},
                {10177, typeof(ClientInfoMessage)},
                {10555, typeof(ClientInputMessage)},
                {14350, typeof(TeamCreateMessage)},
                {14355, typeof(TeamStartGameMessage)}
            };
        }
    }
}
