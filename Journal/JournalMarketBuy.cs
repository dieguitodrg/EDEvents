using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:42:35Z", "event":"MarketBuy", "MarketID":3224427008, "Type":"palladium", "Type_Localised":"Paladio", "Count":159, "BuyPrice":47490, "TotalCost":7550910 }
public class JournalMarketBuy : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
        public int BuyPrice { get; set; }
        public int TotalCost { get; set; }
    }


}