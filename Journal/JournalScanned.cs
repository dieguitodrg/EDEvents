using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:09:16Z", "event":"Scanned", "ScanType":"Cargo" }
public class JournalScanned : JournalBase
    {
        
        
        public string ScanType { get; set; }
    }


}