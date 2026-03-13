using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:20:43Z", "event":"MissionRedirected", "MissionID":947196301, "Name":"Mission_Salvage", "LocalisedName":"Operación de recuperación de Cajas negras", "NewDestinationStation":"Henderson's Inheritance", "NewDestinationSystem":"Matire", "OldDestinationStation":"", "OldDestinationSystem":"Bakum" }
public class JournalMissionRedirected : JournalBase
    {
        
        
        public int MissionID { get; set; }
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public string NewDestinationStation { get; set; }
        public string NewDestinationSystem { get; set; }
        public string OldDestinationStation { get; set; }
        public string OldDestinationSystem { get; set; }
    }


}