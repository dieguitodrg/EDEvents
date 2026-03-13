using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-01-18T22:15:28Z", "event":"FighterRebuilt", "Loadout":"two", "ID":80 }
public class JournalFighterRebuilt : JournalBase
    {
        
        
        public string Loadout { get; set; }
        public int ID { get; set; }
    }


}