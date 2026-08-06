using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"ShipyardNew", "ShipType":"anaconda", "NewShipID":17 }
        public class JournalShipyardNew : JournalBase
    {
        public string ShipType { get; set; }
        public int NewShipID { get; set; }
    }

}