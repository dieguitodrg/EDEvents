using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-08-06T12:00:00Z", "event":"EjectCargo", "Type":"gold", "Type_Localised":"Oro", "Count":12, "Abandoned":false }
        public class JournalEjectCargo : JournalBase
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
        public bool Abandoned { get; set; }
    }

}