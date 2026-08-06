using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"RefuelPartial", "Cost":8470, "Amount":5.2 }
        public class JournalRefuelPartial : JournalBase
    {
        public int Cost { get; set; }
        public double Amount { get; set; }
    }

}