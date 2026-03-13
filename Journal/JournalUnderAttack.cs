using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:30:29Z", "event":"UnderAttack", "Target":"You" }
public class JournalUnderAttack : JournalBase
    {
        
        
        public string Target { get; set; }
    }


}