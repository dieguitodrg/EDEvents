using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"Resurrect", "Option":"rebuy", "Cost":21538912, "Bankrupt":false }
        public class JournalResurrect : JournalBase
    {
        public string Option { get; set; }
        public int Cost { get; set; }
        public bool Bankrupt { get; set; }
    }

}