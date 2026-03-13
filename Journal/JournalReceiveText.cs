using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:19:02Z", "event":"ReceiveText", "From":"UUCC R DANEEL OLIVAW T9Q-35M", "Message":"$STATION_docking_granted;", "Message_Localised":"Solicitud de aterrizaje aceptada.", "Channel":"npc" }
public class JournalReceiveText
    {
        public DateTime timestamp { get; set; }
        public string @event { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
        public string Message_Localised { get; set; }
        public string Channel { get; set; }
    }


}