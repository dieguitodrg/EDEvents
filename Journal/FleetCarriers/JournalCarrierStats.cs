using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-15T00:42:57Z", "event":"CarrierStats", "CarrierID":3709160704, "Callsign":"T9Q-35M", "Name":"UUCC R DANEEL OLIVAW", "DockingAccess":"squadronfriends", "AllowNotorious":true, "FuelLevel":737, "JumpRangeCurr":500.000000, "JumpRangeMax":500.000000, "PendingDecommission":false, "SpaceUsage":{ "TotalCapacity":25000, "Crew":930, "Cargo":1336, "CargoSpaceReserved":0, "ShipPacks":0, "ModulePacks":0, "FreeSpace":22734 }, "Finance":{ "CarrierBalance":964199968, "ReserveBalance":45000000, "AvailableBalance":919199968, "ReservePercent":5, "TaxRate_rearm":0, "TaxRate_refuel":0, "TaxRate_repair":0 }, "Crew":[ { "CrewRole":"BlackMarket", "Activated":false }, { "CrewRole":"Captain", "Activated":true, "Enabled":true, "CrewName":"Amado Finley" }, { "CrewRole":"Refuel", "Activated":true, "Enabled":true, "CrewName":"Maeve Curtis" }, { "CrewRole":"Repair", "Activated":true, "Enabled":true, "CrewName":"Faustino Vargas" }, { "CrewRole":"Rearm", "Activated":true, "Enabled":true, "CrewName":"Vanity Moses" }, { "CrewRole":"Commodities", "Activated":true, "Enabled":true, "CrewName":"Alton Chandler" }, { "CrewRole":"VoucherRedemption", "Activated":false }, { "CrewRole":"Exploration", "Activated":false }, { "CrewRole":"Shipyard", "Activated":false }, { "CrewRole":"Outfitting", "Activated":false }, { "CrewRole":"CarrierFuel", "Activated":true, "Enabled":true, "CrewName":"Cara Delgado" }, { "CrewRole":"VistaGenomics", "Activated":false }, { "CrewRole":"PioneerSupplies", "Activated":false }, { "CrewRole":"Bartender", "Activated":false } ], "ShipPacks":[  ], "ModulePacks":[  ] }
        public class JournalCarrierStatsCrew
    {
        public string CrewRole { get; set; }
        public bool Activated { get; set; }
        public bool? Enabled { get; set; }
        public string CrewName { get; set; }
    }

    public class JournalCarrierStatsFinance
    {
        public int CarrierBalance { get; set; }
        public int ReserveBalance { get; set; }
        public int AvailableBalance { get; set; }
        public int ReservePercent { get; set; }
        public int TaxRate_rearm { get; set; }
        public int TaxRate_refuel { get; set; }
        public int TaxRate_repair { get; set; }
    }

    public class JournalCarrierStats : JournalBase
    {
        public long CarrierID { get; set; }
        public string Callsign { get; set; }
        public string Name { get; set; }
        public string DockingAccess { get; set; }
        public bool AllowNotorious { get; set; }
        public int FuelLevel { get; set; }
        public double JumpRangeCurr { get; set; }
        public double JumpRangeMax { get; set; }
        public bool PendingDecommission { get; set; }
        public JournalCarrierStatsSpaceUsage SpaceUsage { get; set; }
        public JournalCarrierStatsFinance Finance { get; set; }
        public List<JournalCarrierStatsCrew> Crew { get; set; }
        public List<object> ShipPacks { get; set; }
        public List<object> ModulePacks { get; set; }
    }

    public class JournalCarrierStatsSpaceUsage
    {
        public int TotalCapacity { get; set; }
        public int Crew { get; set; }
        public int Cargo { get; set; }
        public int CargoSpaceReserved { get; set; }
        public int ShipPacks { get; set; }
        public int ModulePacks { get; set; }
        public int FreeSpace { get; set; }
    }

}