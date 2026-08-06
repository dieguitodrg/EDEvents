using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"DatalinkScan","Message":"Scan data recovered from listening post"}
        public class JournalDatalinkScan : JournalBase
    {
        public string Message { get; set; }
    }

}