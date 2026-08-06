using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"MaterialDiscarded", "Category":"Raw", "Name":"sulphur", "Name_Localised":"Sulphur", "Count":5 }
        public class JournalMaterialDiscarded : JournalBase
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

}