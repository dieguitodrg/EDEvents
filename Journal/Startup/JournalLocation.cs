using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-08T22:11:56Z", "event":"Location", "Docked":false, "Taxi":false, "Multicrew":false, "StarSystem":"Wolf 397", "SystemAddress":3107576681170, "StarPos":[40.00000,79.21875,-10.40625], "SystemAllegiance":"Alliance", "SystemEconomy":"$economy_Colony;", "SystemEconomy_Localised":"Colonia", "SystemSecondEconomy":"$economy_Agri;", "SystemSecondEconomy_Localised":"Agrícola", "SystemGovernment":"$government_Corporate;", "SystemGovernment_Localised":"Corporativo", "SystemSecurity":"$SYSTEM_SECURITY_medium;", "SystemSecurity_Localised":"Seguridad media", "Population":351227, "Body":"Wolf 397", "BodyID":0, "BodyType":"Star", "Factions":[ { "Name":"89 Leonis Republic Party", "FactionState":"War", "Government":"Democracy", "Influence":0.084084, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":59.300301, "ActiveStates":[ { "State":"Boom" }, { "State":"War" } ] }, { "Name":"Wolf 406 Transport & Co", "FactionState":"Investment", "Government":"Corporate", "Influence":0.506507, "Allegiance":"Alliance", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":64.118797, "PendingStates":[ { "State":"Expansion", "Trend":0 } ], "RecoveringStates":[ { "State":"PublicHoliday", "Trend":0 } ], "ActiveStates":[ { "State":"Investment" } ] }, { "Name":"Wolf 397 Independents", "FactionState":"None", "Government":"Democracy", "Influence":0.158158, "Allegiance":"Alliance", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":22.440001, "RecoveringStates":[ { "State":"Outbreak", "Trend":0 }, { "State":"CivilWar", "Trend":0 } ] }, { "Name":"Blue Fortune Organisation", "FactionState":"None", "Government":"Corporate", "Influence":0.078078, "Allegiance":"Alliance", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":-9.240000, "RecoveringStates":[ { "State":"PublicHoliday", "Trend":0 }, { "State":"CivilWar", "Trend":0 } ] }, { "Name":"Cartel of Wolf 397", "FactionState":"Bust", "Government":"Anarchy", "Influence":0.010010, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000, "RecoveringStates":[ { "State":"InfrastructureFailure", "Trend":0 } ], "ActiveStates":[ { "State":"Bust" } ] }, { "Name":"Wolf 397 Dominion", "FactionState":"War", "Government":"Dictatorship", "Influence":0.084084, "Allegiance":"Alliance", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":-6.000000, "RecoveringStates":[ { "State":"PirateAttack", "Trend":0 } ], "ActiveStates":[ { "State":"War" } ] }, { "Name":"Social Wolf 397 Progressive Party", "FactionState":"None", "Government":"Democracy", "Influence":0.079079, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":3.010000 } ], "SystemFaction":{ "Name":"Wolf 406 Transport & Co", "FactionState":"Investment" }, "Conflicts":[ { "WarType":"war", "Status":"active", "Faction1":{ "Name":"89 Leonis Republic Party", "Stake":"Poblete Research Lab", "WonDays":0 }, "Faction2":{ "Name":"Wolf 397 Dominion", "Stake":"Charnas' Progress", "WonDays":3 } }, { "WarType":"civilwar", "Status":"", "Faction1":{ "Name":"Wolf 397 Independents", "Stake":"Gibson Prospect", "WonDays":4 }, "Faction2":{ "Name":"Blue Fortune Organisation", "Stake":"", "WonDays":0 } } ] }


    

    public class FactionConflictType
    {
        public string Name { get; set; }
        public string Stake { get; set; }
        public int WonDays { get; set; }
    }

    public class StateType
    {
        public string State { get; set; }
        public int Trend { get; set; }
    }


    public class JournalLocation : JournalBase
    {
        
        
        public bool Docked { get; set; }
        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }
        public string StarSystem { get; set; }
        public Int64 SystemAddress { get; set; }
        public List<double> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemSecondEconomy { get; set; }
        public string SystemSecondEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public int Population { get; set; }
        public string Body { get; set; }
        public int BodyID { get; set; }
        public string BodyType { get; set; }
        public List<FactionType> Factions { get; set; }
        public SystemFaction SystemFaction { get; set; }
        public List<SystemFactionType> Conflicts { get; set; }
    }

    public class SystemFaction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
    }

}