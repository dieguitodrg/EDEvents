using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-06T18:41:38Z", "event":"ReceiveText", "From":"$ShipName_SearchAndRescue;", "From_Localised":"Patrulla de búsqueda y rescate", "Message":"$Rescuer_OnRescueStart05;", "Message_Localised":"Quédate ahí, comandante. Esto no será un procedimiento doloroso.", "Channel":"npc" }
        public class JournalReceiveText : JournalBase
    {
        public string From { get; set; }
        public string From_Localised { get; set; }
        public string Message { get; set; }
        public string Message_Localised { get; set; }
        public string Channel { get; set; }
    }

}