using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SendText", "To":"CMDR Vertex", "Message":"Meet me at the nav beacon when you arrive" }
        public class JournalSendText : JournalBase
    {
        public string To { get; set; }
        public string Message { get; set; }
    }

}