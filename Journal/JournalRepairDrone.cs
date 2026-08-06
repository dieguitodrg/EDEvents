using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"RepairDrone", "HullRepaired":12.5, "CockpitRepaired":0.0, "CorrosionRepaired":3.75 }
        public class JournalRepairDrone : JournalBase
    {
        public double HullRepaired { get; set; }
        public double CockpitRepaired { get; set; }
        public double CorrosionRepaired { get; set; }
    }

}