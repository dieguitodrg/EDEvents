using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BuyMicroResources", "TotalCount":7, "Price":4000, "MarketID":3700020480, "MicroResources":[ { "Name":"healthpack", "Name_Localised":"Medkit", "Category":"Consumable", "Count":4 }, { "Name":"energycell", "Name_Localised":"Energy Cell", "Category":"Consumable", "Count":3 } ] }
        public class JournalBuyMicroResourcesMicroResource
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
    }

    public class JournalBuyMicroResources : JournalBase
    {
        public int TotalCount { get; set; }
        public int Price { get; set; }
        public long MarketID { get; set; }
        public List<JournalBuyMicroResourcesMicroResource> MicroResources { get; set; }
    }

}