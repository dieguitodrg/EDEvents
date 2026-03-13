using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:31:10Z", "event":"BuyDrones", "Type":"Drones", "Count":16, "BuyPrice":101, "TotalCost":1616 }
public class JournalBuyDrones : JournalBase
    {
        
        
        public string Type { get; set; }
        public int Count { get; set; }
        public int BuyPrice { get; set; }
        public int TotalCost { get; set; }
    }


}