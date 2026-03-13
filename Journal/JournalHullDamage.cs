using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:29:05Z", "event":"HullDamage", "Health":0.795337, "PlayerPilot":false, "Fighter":true }
public class JournalHullDamage : JournalBase
    {
        
        
        public double Health { get; set; }
        public bool PlayerPilot { get; set; }
        public bool Fighter { get; set; }
    }


}