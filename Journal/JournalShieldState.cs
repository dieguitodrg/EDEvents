using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-07T22:28:26Z", "event":"ShieldState", "ShieldsUp":false }
public class JournalShieldState : JournalBase
    {
        
        
        public bool ShieldsUp { get; set; }
    }


}