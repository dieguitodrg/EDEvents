using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:46:17Z", "event":"CollectCargo", "Type":"USSCargoBlackBox", "Type_Localised":"Cajas negras", "Stolen":false, "MissionID":947196382 }
public class JournalCollectCargo : JournalBase
    {
        
        
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public bool Stolen { get; set; }
        public int MissionID { get; set; }
    }


}