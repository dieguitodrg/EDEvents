using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T23:03:38Z", "event":"JoinACrew", "Captain":"KOSKERG", "Telepresence":true }
        public class JournalJoinACrew : JournalBase
    {
        public string Captain { get; set; }
        public bool Telepresence { get; set; }
    }

}