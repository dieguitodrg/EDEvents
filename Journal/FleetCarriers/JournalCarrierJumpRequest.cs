using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-15T00:44:00Z", "event":"CarrierJumpRequest", "CarrierID":3709160704, "SystemName":"Hu Jing Te", "Body":"Hu Jing Te C 2", "SystemAddress":672565241233, "BodyID":13, "DepartureTime":"2024-12-15T00:59:10Z" }
        public class JournalCarrierJumpRequest : JournalBase
    {
        public long CarrierID { get; set; }
        public string SystemName { get; set; }
        public string Body { get; set; }
        public long SystemAddress { get; set; }
        public int BodyID { get; set; }
        public DateTime DepartureTime { get; set; }
    }

}