using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-11T21:44:49Z", "event":"Interdicted", "Submitted":true, "Interdictor":"Sandro Pansa", "IsPlayer":false, "Faction":"Achreni Blue Cartel" }
public class JournalInterdicted : JournalBase
    {
        
        
        public bool Submitted { get; set; }
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }
    }


}