using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"CancelDropship", "Refund":32500 }
        public class JournalCancelDropship : JournalBase
    {
        public int Refund { get; set; }
    }

}