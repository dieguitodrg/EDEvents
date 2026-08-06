using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CarrierCrewServices", "CarrierID":3700005632, "CrewRole":"Outfitting", "Operation":"Activate", "CrewName":"Eugene Johnson" }
        public class JournalCarrierCrewServices : JournalBase
    {
        public long CarrierID { get; set; }
        public string CrewRole { get; set; }
        public string Operation { get; set; }
        public string CrewName { get; set; }
    }

}