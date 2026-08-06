using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T23:04:13Z", "event":"QuitACrew", "Captain":"" }
        public class JournalQuitACrew : JournalBase
    {
        public string Captain { get; set; }
    }

}