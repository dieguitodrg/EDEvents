using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:53:14Z", "event":"SearchAndRescue", "MarketID":3224381440, "Name":"occupiedcryopod", "Name_Localised":"Cápsula de escape ocupada", "Count":1, "Reward":27459 }
public class JournalSearchAndRescue : JournalBase
    {
        
        
        public Int64 MarketID { get; set; }
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
        public int Reward { get; set; }
    }


}