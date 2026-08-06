using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"Repair", "Item":"int_powerplant_size3_class5", "Item_Localised":"Power Plant", "Cost":1100 }
        public class JournalRepair : JournalBase
    {
        public string Item { get; set; }
        public string Item_Localised { get; set; }
        public int Cost { get; set; }
    }

}