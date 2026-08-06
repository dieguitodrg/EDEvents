using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"UpgradeSuit", "Name":"utilitysuit_class1", "Name_Localised":"Maverick Suit", "SuitID":1702914472756487, "Class":2, "Cost":600000, "Resources":[ { "Name":"suitschematic", "Name_Localised":"Suit Schematic", "Count":1 }, { "Name":"carbonfibreplating", "Name_Localised":"Carbon Fibre Plating", "Count":5 } ] }
        public class JournalUpgradeSuitResource
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }

    public class JournalUpgradeSuit : JournalBase
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public long SuitID { get; set; }
        public int Class { get; set; }
        public int Cost { get; set; }
        public List<JournalUpgradeSuitResource> Resources { get; set; }
    }

}