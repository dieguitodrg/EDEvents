using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T23:37:14Z", "event":"RepairAll", "Cost":1217 }
public class JournalRepairAll : JournalBase
    {
        
        
        public int Cost { get; set; }
    }


}