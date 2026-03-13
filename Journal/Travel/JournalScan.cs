using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class AtmosphereComposition { public string Name { get; set; } public double Percent { get; set; } }
    public class Composition { public double Ice { get; set; } public double Rock { get; set; } public double Metal { get; set; } }
    public class Parent { public int Star { get; set; } }
    public class JournalScan : JournalBase { 
        public string ScanType { get; set; }
        public string BodyName { get; set; }
        public int BodyID { get; set; }
        public List<Parent> Parents { get; set; }
        public string StarSystem { get; set; }
        public Int64 SystemAddress { get; set; }
        public double DistanceFromArrivalLS { get; set; }
        public bool TidalLock { get; set; }
        public string TerraformState { get; set; }
        public string PlanetClass { get; set; }
        public string Atmosphere { get; set; }
        public string AtmosphereType { get; set; }
        public List<AtmosphereComposition> AtmosphereComposition { get; set; }
        public string Volcanism { get; set; }
        public double MassEM { get; set; }
        public double Radius { get; set; }
        public double SurfaceGravity { get; set; }
        public double SurfaceTemperature { get; set; }
        public double SurfacePressure { get; set; }
        public bool Landable { get; set; }
        public Composition Composition { get; set; }
        public double SemiMajorAxis { get; set; }
        public double Eccentricity { get; set; }
        public double OrbitalInclination { get; set; }
        public double Periapsis { get; set; }
        public double OrbitalPeriod { get; set; }
        public double AscendingNode { get; set; }
        public double MeanAnomaly { get; set; }
        public double RotationPeriod { get; set; }
        public double AxialTilt { get; set; }
        public bool WasDiscovered { get; set; }
        public bool WasMapped { get; set; }
    }
}
