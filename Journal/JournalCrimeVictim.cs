using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CrimeVictim","Offender":"Cmdr Shadowstrike","CrimeType":"assault","Bounty":210}
        public class JournalCrimeVictim : JournalBase
    {
        public string Offender { get; set; }
        public string CrimeType { get; set; }
        public int Bounty { get; set; }
    }

}