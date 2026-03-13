using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2025-07-30T21:33:17Z", "event":"PowerplayRank", "Power":"Jerome Archer", "Rank":5 }
public class JournalPowerplayRank : JournalBase
    {
        
        
        public string Power { get; set; }
        public int Rank { get; set; }
    }


}