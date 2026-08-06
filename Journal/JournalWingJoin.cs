using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-08T00:10:20Z", "event":"WingJoin", "Others":[ "KOSKERG" ] }
        public class JournalWingJoin : JournalBase
    {
        public List<string> Others { get; set; }
    }

}