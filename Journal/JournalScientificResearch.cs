using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ScientificResearch", "MarketID":3228964864, "Name":"ferrousalloys", "Name_Localised":"Ferrous Alloys", "Category":"Manufactured", "Count":25 }
        public class JournalScientificResearch : JournalBase
    {
        public long MarketID { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
    }

}