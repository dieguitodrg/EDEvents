using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T22:11:40Z", "event":"SquadronStartup", "SquadronName":"UNION COSMOS", "CurrentRank":2 }
public class JournalSquadronStartup : JournalBase
    {
        
        
        public string SquadronName { get; set; }
        public int CurrentRank { get; set; }
    }


}