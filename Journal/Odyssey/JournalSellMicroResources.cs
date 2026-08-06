using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SellMicroResources", "MicroResources":[ { "Name":"healthmonitor", "Name_Localised":"Health Monitor", "Category":"Component", "Count":3 }, { "Name":"geneticrepairmedi", "Name_Localised":"Genetic Repair Meds", "Category":"Consumable", "Count":2 } ], "Price":250000, "MarketID":3228964864 }
        public class JournalSellMicroResourcesMicroResource
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
    }

    public class JournalSellMicroResources : JournalBase
    {
        public List<JournalSellMicroResourcesMicroResource> MicroResources { get; set; }
        public int Price { get; set; }
        public long MarketID { get; set; }
    }

}