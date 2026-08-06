using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CapShipBond", "Reward":1500000, "AwardingFaction":"Aegis Capital Ship Command", "VictimFaction":"Thargoid" }
        public class JournalCapShipBond : JournalBase
    {
        public int Reward { get; set; }
        public string AwardingFaction { get; set; }
        public string VictimFaction { get; set; }
    }

}