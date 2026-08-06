using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"MultiSellExplorationData", "Discovered":[ { "SystemName":"HIP 84742", "NumBodies":23 }, { "SystemName":"Col 359 Sector NY-S b20-1", "NumBodies":9 } ], "BaseValue":3128776147, "Bonus":402133000, "TotalEarnings":3530909147 }
        public class JournalMultiSellExplorationDataDiscovered
    {
        public string SystemName { get; set; }
        public int NumBodies { get; set; }
    }

    public class JournalMultiSellExplorationData : JournalBase
    {
        public List<JournalMultiSellExplorationDataDiscovered> Discovered { get; set; }
        public long BaseValue { get; set; }
        public int Bonus { get; set; }
        public long TotalEarnings { get; set; }
    }

}