using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"BuyExplorationData", "System":"Styx", "Cost":352 }
        public class JournalBuyExplorationData : JournalBase
    {
        public string System { get; set; }
        public int Cost { get; set; }
    }

}