using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplaySalary", "Power":"Aisling Duval", "Amount":5000000 }
        public class JournalPowerplaySalary : JournalBase
    {
        public string Power { get; set; }
        public int Amount { get; set; }
    }

}