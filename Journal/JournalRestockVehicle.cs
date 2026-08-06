using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"RestockVehicle", "Type":"SRV", "Loadout":"starter", "Cost":1030, "Count":1 }
        public class JournalRestockVehicle : JournalBase
    {
        public string Type { get; set; }
        public string Loadout { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
    }

}