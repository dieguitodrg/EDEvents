using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SetUserShipName", "Ship":"python", "ShipID":12, "UserShipName":"Dauntless", "UserShipId":"PY-8K4" }
        public class JournalSetUserShipName : JournalBase
    {
        public string Ship { get; set; }
        public int ShipID { get; set; }
        public string UserShipName { get; set; }
        public string UserShipId { get; set; }
    }

}