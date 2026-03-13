using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:37:13Z", "event":"MarketSell", "MarketID":3224440576, "Type":"clothing", "Type_Localised":"Ropa", "Count":1, "SellPrice":929, "TotalSale":929, "AvgPricePaid":0 }
public class JournalMarketSell : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
        public int SellPrice { get; set; }
        public int TotalSale { get; set; }
        public int AvgPricePaid { get; set; }
    }


}