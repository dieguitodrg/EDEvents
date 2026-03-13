using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T22:56:16Z", "event":"ScanBaryCentre", "StarSystem":"Puppis Sector TO-R b4-3", "SystemAddress":7268829570481, "BodyID":1, "SemiMajorAxis":422605466842.651367, "Eccentricity":0.079473, "OrbitalInclination":-21.781175, "Periapsis":285.933575, "OrbitalPeriod":1575042009.353638, "AscendingNode":-126.674864, "MeanAnomaly":245.205395 }
public class JournalScanBaryCentre : JournalBase
    {
        
        
        public string StarSystem { get; set; }
        public Int64 SystemAddress { get; set; }
        public int BodyID { get; set; }
        public double SemiMajorAxis { get; set; }
        public double Eccentricity { get; set; }
        public double OrbitalInclination { get; set; }
        public double Periapsis { get; set; }
        public double OrbitalPeriod { get; set; }
        public double AscendingNode { get; set; }
        public double MeanAnomaly { get; set; }
    }


}