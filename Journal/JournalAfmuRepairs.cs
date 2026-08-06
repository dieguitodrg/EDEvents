using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"AfmuRepairs", "Module":"modularcargobaydoor", "Module_Localised":"Cargo Hatch", "FullyRepaired":true, "Health":1 }
        public class JournalAfmuRepairs : JournalBase
    {
        public string Module { get; set; }
        public string Module_Localised { get; set; }
        public bool FullyRepaired { get; set; }
        public int Health { get; set; }
    }

}