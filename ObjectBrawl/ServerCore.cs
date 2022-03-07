using Newtonsoft.Json;
using ObjectBrawl.Core;
using ObjectBrawl.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectBrawl
{
    public static class ServerCore
    {
        public static Server Server;
        public static bool Initialized { get; private set; }

        [JsonIgnore]
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ObjectCreationHandling = ObjectCreationHandling.Auto,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.None
        };

        public static void Init()
        {
            if (Initialized) return;

            Server = new Server(9339); // TODO: Port in configuration file
            Server.Start();
        }
    }
}
