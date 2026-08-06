using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"DisbandedSquadron","SquadronName":"TestSquadron"}
        public class JournalDisbandedSquadron : JournalBase
    {
        public string SquadronName { get; set; }
    }

}