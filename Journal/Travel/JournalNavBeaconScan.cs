using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:04:37Z", "event":"NavBeaconScan", "SystemAddress":5581678973650, "NumBodies":5 }
public class JournalNavBeaconScan : JournalBase
    {
        
        
        public Int64 SystemAddress { get; set; }
        public int NumBodies { get; set; }
    }


}