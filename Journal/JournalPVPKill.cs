using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PVPKill", "Victim":"Cmdr Aurora Skye", "CombatRank":5 }
        public class JournalPVPKill : JournalBase
    {
        public string Victim { get; set; }
        public int CombatRank { get; set; }
    }

}