using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T23:28:51Z", "event":"FactionKillBond", "Reward":29967, "AwardingFaction":"Union Cosmos", "VictimFaction":"Movement for Pini Liberals" }
public class JournalFactionKillBond : JournalBase
    {
        
        
        public int Reward { get; set; }
        public string AwardingFaction { get; set; }
        public string VictimFaction { get; set; }
    }


}