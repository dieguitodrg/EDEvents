using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"Continued","Part":2}
        public class JournalContinued : JournalBase
    {
        public int Part { get; set; }
    }

}