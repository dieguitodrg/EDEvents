using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class JournalDocked : JournalBase
    {
    public string StationName { get; set; }
    public string StationType { get; set; }
    public string StarSystem { get; set; }
    public Int64 SystemAddress { get; set; }
    public Int64 MarketID { get; set; }

        public bool CockpitBreach { get; set; }
    public JournalDockedStationFaction StationFaction { get; set; }
    public string StationGovernment { get; set; }
    public string StationGovernment_Localised { get; set; }
    public string StationAllegiance { get; set; }
    public List<string> StationServices { get; set; }

        public bool Wanted { get; set; }
        public bool ActiveFine { get; set; }
        public string StationEconomy { get; set; }
    public string StationEconomy_Localised { get; set; }
    public List<JournalDockedStationEconomy> StationEconomies { get; set; }
    public double DistFromStarLS { get; set; }

        public JournalDockedLandingPads LandingPads { get; set; }

        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }

        public string StationState { get; set; }
    }

public class JournalDockedStationEconomy
{
    public string Name { get; set; }
    public string Name_Localised { get; set; }
    public double Proportion { get; set; }
}

public class JournalDockedStationFaction
{
    public string Name { get; set; }
    public string FactionState { get; set; }
}

    public class JournalDockedLandingPads
    {
        public int Small { get; set; }
        public int Medium { get; set; }
        public int Large { get; set; }
    }


}
