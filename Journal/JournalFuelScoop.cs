using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T22:56:25Z", "event":"FuelScoop", "Scooped":5.006089, "Total":29.078890 }
public class JournalFuelScoop : JournalBase
    {
        
        
        public double Scooped { get; set; }
        public double Total { get; set; }
    }


}