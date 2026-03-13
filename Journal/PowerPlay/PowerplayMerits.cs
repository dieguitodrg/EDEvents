using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-07-30T21:33:17Z", "event":"PowerplayMerits", "Power":"Jerome Archer", "MeritsGained":796, "TotalMerits":21739 }
public class JournalPowerplayMerits : JournalBase
    {
        
        
        public string Power { get; set; }
        public int MeritsGained { get; set; }
        public int TotalMerits { get; set; }
    }


}