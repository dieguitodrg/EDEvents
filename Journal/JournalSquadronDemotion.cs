using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SquadronDemotion", "SquadronName":"Gryphon Wing", "OldRank":3, "NewRank":2 }
        public class JournalSquadronDemotion : JournalBase
    {
        public string SquadronName { get; set; }
        public int OldRank { get; set; }
        public int NewRank { get; set; }
    }

}