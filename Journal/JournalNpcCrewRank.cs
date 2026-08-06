using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"NpcCrewRank", "NpcCrewId":3684280479102380, "NpcCrewName":"Maya Ruiz", "RankCombat":5 }
        public class JournalNpcCrewRank : JournalBase
    {
        public long NpcCrewId { get; set; }
        public string NpcCrewName { get; set; }
        public int RankCombat { get; set; }
    }

}