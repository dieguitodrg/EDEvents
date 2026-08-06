using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CommunityGoalReward","CGID":726,"Name":"Alliance Research Initiative - Trade","System":"Kaushpoos","Reward":4000000000}
        public class JournalCommunityGoalReward : JournalBase
    {
        public int CGID { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public long Reward { get; set; }
    }

}