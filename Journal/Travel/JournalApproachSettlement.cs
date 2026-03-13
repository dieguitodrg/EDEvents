using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T22:16:01Z", "event":"ApproachSettlement", "Name":"Trophy Camp", "MarketID":128680583, "StationFaction":{ "Name":"Tod 'The Blaster' McQuinn" }, "StationGovernment":"$government_Engineer;", "StationGovernment_Localised":"Taller", "StationAllegiance":"Alliance", "StationServices":[ "dock", "autodock", "commodities", "contacts", "outfitting", "rearm", "refuel", "repair", "tuning", "engineer", "flightcontroller", "stationoperations", "searchrescue", "stationMenu", "shop", "livery" ], "StationEconomy":"$economy_Colony;", "StationEconomy_Localised":"Colonia", "StationEconomies":[ { "Name":"$economy_Colony;", "Name_Localised":"Colonia", "Proportion":1.000000 } ], "SystemAddress":3107576681170, "BodyID":7, "BodyName":"Trus Madi", "Latitude":-20.634678, "Int64itude":-18.517441 }
public class JournalApproachSettlement : JournalBase
    {
        
        
        public string Name { get; set; }
        public int MarketID { get; set; }
        public StationFactionType StationFaction { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<StationEconomyType> StationEconomies { get; set; }
        public Int64 SystemAddress { get; set; }
        public int BodyID { get; set; }
        public string BodyName { get; set; }
        public double Latitude { get; set; }
        public double Int64itude { get; set; }
    }

    public class StationEconomyType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public double Proportion { get; set; }
    }

    public class StationFactionType
    {
        public string Name { get; set; }
    }


}