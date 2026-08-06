using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-08-06T12:00:00Z", "event":"PowerplayCollect", "Power":"Aisling Duval", "Type":"$powerplay_category_type", "Type_Localised":"Manifestos de consolidación", "Count":15 }
        public class JournalPowerplayCollect : JournalBase
    {
        public string Power { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
    }

}