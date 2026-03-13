using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:31:18Z", "event":"Bounty", "Rewards":[ { "Faction":"Hakurei Stargaze Musketeers", "Reward":1122556 } ], "PilotName":"$npc_name_decorate:#name=Malark;", "PilotName_Localised":"Malark", "Target":"ferdelance", "Target_Localised":"Fer-de-Lance", "TotalReward":1122556, "VictimFaction":"HIP 18713 Jet Society" }
public class BountyRewardType
    {
        public string Faction { get; set; }
        public int Reward { get; set; }
    }

    public class JournalBounty : JournalBase
    {
        
        
        public List<BountyRewardType> Rewards { get; set; }
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string Target { get; set; }
        public string Target_Localised { get; set; }
        public int TotalReward { get; set; }
        public string VictimFaction { get; set; }
    }


}