using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:38:26Z", "event":"MissionAccepted", "Faction":"Union Cosmos", "Name":"Mission_Salvage", "LocalisedName":"Operación de recuperación de Cajas negras", "Commodity":"$USSCargoBlackBox_Name;", "Commodity_Localised":"Cajas negras", "Count":4, "DestinationSystem":"Yu Shor", "DestinationStation":"Bus Stop", "Expiry":"2023-12-09T10:43:26Z", "Wing":false, "Influence":"++", "Reputation":"++", "Reward":2391906, "MissionID":947196382 }
public class JournalMissionAccepted : JournalBase
    {
        
        
        public string Faction { get; set; }
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public int Count { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public DateTime Expiry { get; set; }
        public bool Wing { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }
        public int Reward { get; set; }
        public int MissionID { get; set; }
    }


}