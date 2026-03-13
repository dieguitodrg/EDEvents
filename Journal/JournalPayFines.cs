using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:30:32Z", "event":"PayFines", "Amount":200, "AllFines":false, "Faction":"Hakurei Stargaze Musketeers", "ShipID":14 }
public class JournalPayFines : JournalBase
    {
        
        
        public int Amount { get; set; }
        public bool AllFines { get; set; }
        public string Faction { get; set; }
        public int ShipID { get; set; }
    }


}