using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"PowerplayDeliver", "Power":"Li Yong-Rui", "Type":"siriusfranchisepackage", "Type_Localised":"Sirius Franchise Package", "Count":25 }
        public class JournalPowerplayDeliver : JournalBase
    {
        public string Power { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
    }

}