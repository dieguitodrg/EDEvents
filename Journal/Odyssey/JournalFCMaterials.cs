using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"FCMaterials", "MarketID":3700020480, "CarrierName":"Rogue Nebula", "CarrierID":3709160704, "Items":[ { "id":128961556, "Name":"californium", "Name_Localised":"Californium", "Price":74000, "Stock":26, "Demand":0 }, { "id":128961524, "Name":"aerogel", "Name_Localised":"Aerogel", "Price":500, "Stock":0, "Demand":1 } ] }
        public class JournalFCMaterialsItem
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int Demand { get; set; }
    }

    public class JournalFCMaterials : JournalBase
    {
        public long MarketID { get; set; }
        public string CarrierName { get; set; }
        public long CarrierID { get; set; }
        public List<JournalFCMaterialsItem> Items { get; set; }
    }

}