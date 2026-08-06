using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2026-01-01T12:00:00Z", "event":"SRVDestroyed", "ID":3, "SRVType":"scarab" }
        public class JournalSRVDestroyed : JournalBase
    {
        public int ID { get; set; }
        public string SRVType { get; set; }
    }

}