using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:41:06Z", "event":"SupercruiseDestinationDrop", "Type":"Henderson's Inheritance", "Threat":0, "MarketID":3224440576 }
public class JournalSupercruiseDestinationDrop : JournalBase
    {
        
        
        public string Type { get; set; }
        public int Threat { get; set; }
        public Int64 MarketID { get; set; }
    }


}