using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplayVote", "Power":"Zachary Hudson", "Votes":25, "System":"LHS 3447" }
        public class JournalPowerplayVote : JournalBase
    {
        public string Power { get; set; }
        public int Votes { get; set; }
        public string System { get; set; }
    }

}