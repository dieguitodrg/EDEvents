using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-01-20T19:50:10Z", "event":"SellDrones", "Type":"Drones", "Count":12, "SellPrice":100, "TotalSale":1200 }
        public class JournalSellDrones : JournalBase
    {
        public string Type { get; set; }
        public int Count { get; set; }
        public int SellPrice { get; set; }
        public int TotalSale { get; set; }
    }

}