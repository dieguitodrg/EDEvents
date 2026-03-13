using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:14:58Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"empire_fighter", "Ship_Localised":"Gu-97", "ScanStage":3, "PilotName":"$ShipName_Police_Empire;", "PilotName_Localised":"Servicio de seguridad interna", "PilotRank":"Expert", "ShieldHealth":100.000000, "HullHealth":100.000000, "Faction":"6th Interstellar Corps", "LegalStatus":"Clean" }
public class JournalShipTargeted : JournalBase
    {
        public bool TargetLocked { get; set; }
        public string Ship { get; set; }
        public string Ship_Localised { get; set; }
        public int ScanStage { get; set; }
        public string PilotName { get; set; }
        public string PilotName_Localised { get; set; }
        public string PilotRank { get; set; }
        public double ShieldHealth { get; set; }
        public double HullHealth { get; set; }
        public string Faction { get; set; }
        public string LegalStatus { get; set; }
    }


}