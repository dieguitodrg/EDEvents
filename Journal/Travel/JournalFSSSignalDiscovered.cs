using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    //{ "timestamp":"2023-12-08T22:58:07Z", "event":"FSSSignalDiscovered", "SystemAddress":3961880824171, "SignalName":"$Warzone_PointRace_High:#index=2;", "SignalName_Localised":"Zona de conflicto de alta intensidad", "SignalType":"Combat" }
    public class JournalFSSSignalDiscovered : JournalBase
    {


        public Int64 SystemAddress { get; set; }
        public string SignalName { get; set; }
        public string SignalName_Localised { get; set; }
        public string SignalType { get; set; }
    }
}
