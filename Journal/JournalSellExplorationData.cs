using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SellExplorationData", "Systems":[ "HIP 78085", "Praea Euq NW-W b1-3" ], "Discovered":[ "HIP 78085 A", "Praea Euq NW-W b1-3", "Praea Euq NW-W b1-3 3 a" ], "BaseValue":3520100111, "Bonus":1289540000, "TotalEarnings":4809640111 }
        public class JournalSellExplorationData : JournalBase
    {
        public List<string> Systems { get; set; }
        public List<string> Discovered { get; set; }
        public long BaseValue { get; set; }
        public int Bonus { get; set; }
        public long TotalEarnings { get; set; }
    }

}