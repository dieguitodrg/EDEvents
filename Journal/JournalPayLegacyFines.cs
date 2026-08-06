using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PayLegacyFines", "Amount":5000, "AllFinesPaid":true, "Fines":[ { "Faction":"Union Cosmos", "LegacyFine":5000 } ] }
        public class JournalPayLegacyFinesFine
    {
        public string Faction { get; set; }
        public int LegacyFine { get; set; }
    }

    public class JournalPayLegacyFines : JournalBase
    {
        public int Amount { get; set; }
        public bool AllFinesPaid { get; set; }
        public List<JournalPayLegacyFinesFine> Fines { get; set; }
    }

}