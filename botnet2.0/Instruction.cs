using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace botnet2._0
{
    public class Instruction
    {
        public class AttackTypes
        {
            public const int UDP_Flood = 0;
            public const int ICMP_Ping = 1;
            public const int POD = 2;
            public const int None = -1;
        }

        [JsonProperty("DOS_Type")]
        public int DOS_Type { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("Port")]
        public int Port { get; set; }

        [JsonProperty("Packetsize")]
        public int Packetsize { get; set; }

        [JsonProperty("Killswitch")]
        public bool Killswitch { get; set; }
    }
}
