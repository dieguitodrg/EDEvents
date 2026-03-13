using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-07T22:19:55Z", "event":"PayBounties", "Amount":3187, "AllFines":false, "Faction":"Societas Acrana Imperii", "ShipID":1, "BrokerPercentage":25.000000 }
public class JournalPayBounties : JournalBase
    {
        
        
        public int Amount { get; set; }
        public bool AllFines { get; set; }
        public string Faction { get; set; }
        public int ShipID { get; set; }
        public double BrokerPercentage { get; set; }
    }


}