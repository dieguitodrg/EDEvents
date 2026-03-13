using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:24:13Z", "event":"CommitCrime", "CrimeType":"recklessWeaponsDischarge", "Faction":"Hakurei Stargaze Musketeers", "Fine":200 }
public class JournalCommitCrime : JournalBase
    {
        
        
        public string CrimeType { get; set; }
        public string Faction { get; set; }
        public int Fine { get; set; }
    }


}