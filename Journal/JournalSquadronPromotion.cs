using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SquadronPromotion", "SquadronName":"Gryphon Wing", "OldRank":2, "NewRank":3 }
        public class JournalSquadronPromotion : JournalBase
    {
        public string SquadronName { get; set; }
        public int OldRank { get; set; }
        public int NewRank { get; set; }
    }

}