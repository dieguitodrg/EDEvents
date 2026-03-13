using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:15:51Z", "event":"LaunchFighter", "Loadout":"four", "ID":68, "PlayerControlled":false }
public class JournalLaunchFighter : JournalBase
    {
        
        
        public string Loadout { get; set; }
        public int ID { get; set; }
        public bool PlayerControlled { get; set; }
    }


}