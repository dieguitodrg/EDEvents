using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    public class JournalReservoirReplenished : JournalBase
    {

        public double FuelMain { get; set; }
        public double FuelReservoir { get; set; }
    }
}