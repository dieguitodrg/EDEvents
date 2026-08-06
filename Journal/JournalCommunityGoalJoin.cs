using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CommunityGoalJoin","CGID":726,"Name":"Alliance Research Initiative - Trade","System":"Kaushpoos"}
        public class JournalCommunityGoalJoin : JournalBase
    {
        public int CGID { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
    }

}