using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T21:27:22Z", "event":"RefuelAll", "Cost":17, "Amount":0.329636 }
public class JournalRefuelAll : JournalBase
    {
        
        
        public int Cost { get; set; }
        public double Amount { get; set; }
    }


}