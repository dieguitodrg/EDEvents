using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-12-15T01:00:10Z", "event":"CarrierJump", "Docked":true, "StationName":"T9Q-35M", "StationType":"FleetCarrier", "MarketID":3709160704, "StationFaction":{ "Name":"FleetCarrier" }, "StationGovernment":"$government_Carrier;", "StationGovernment_Localised":"Propiedad privada", "StationServices":[ "dock", "autodock", "commodities", "contacts", "crewlounge", "rearm", "refuel", "repair", "engineer", "flightcontroller", "stationoperations", "stationMenu", "carriermanagement", "carrierfuel", "socialspace" ], "StationEconomy":"$economy_Carrier;", "StationEconomy_Localised":"Empresa privada", "StationEconomies":[ { "Name":"$economy_Carrier;", "Name_Localised":"Empresa privada", "Proportion":1.000000 } ], "Taxi":false, "Multicrew":false, "StarSystem":"Hu Jing Te", "SystemAddress":672565241233, "StarPos":[115.93750,37.96875,-61.15625], "SystemAllegiance":"Federation", "SystemEconomy":"$economy_Agri;", "SystemEconomy_Localised":"Agrícola", "SystemSecondEconomy":"$economy_Extraction;", "SystemSecondEconomy_Localised":"Extracción", "SystemGovernment":"$government_Corporate;", "SystemGovernment_Localised":"Corporativo", "SystemSecurity":"$SYSTEM_SECURITY_high;", "SystemSecurity_Localised":"Seguridad alta", "Population":2016056359, "Body":"Hu Jing Te C 2", "BodyID":13, "BodyType":"Planet", "Factions":[ { "Name":"Social Hu Jing Te Resistance", "FactionState":"None", "Government":"Democracy", "Influence":0.040000, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Hu Jing Te Gold Energy Inc", "FactionState":"None", "Government":"Corporate", "Influence":0.030000, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Hu Jing Te Law Party", "FactionState":"None", "Government":"Dictatorship", "Influence":0.079000, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Hu Jing Te Exchange", "FactionState":"None", "Government":"Corporate", "Influence":0.048000, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Official Hu Jing Te Party", "FactionState":"None", "Government":"Dictatorship", "Influence":0.032000, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Federal Galactic Systems", "FactionState":"CivilUnrest", "Government":"Corporate", "Influence":0.724000, "Allegiance":"Federation", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":100.000000, "RecoveringStates":[ { "State":"Expansion", "Trend":0 } ] }, { "Name":"Ryders of the Void", "FactionState":"Expansion", "Government":"Feudal", "Influence":0.047000, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":100.000000, "ActiveStates":[ { "State":"Expansion" } ] } ], "SystemFaction":{ "Name":"Federal Galactic Systems", "FactionState":"CivilUnrest" } }
        public class JournalCarrierJumpActiveState
    {
        public string State { get; set; }
    }

    public class JournalCarrierJumpFaction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public double Influence { get; set; }
        public string Allegiance { get; set; }
        public string Happiness { get; set; }
        public string Happiness_Localised { get; set; }
        public double MyReputation { get; set; }
        public List<JournalCarrierJumpRecoveringState> RecoveringStates { get; set; }
        public List<JournalCarrierJumpActiveState> ActiveStates { get; set; }
    }

    public class JournalCarrierJumpRecoveringState
    {
        public string State { get; set; }
        public int Trend { get; set; }
    }

    public class JournalCarrierJump : JournalBase
    {
        public bool Docked { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public long MarketID { get; set; }
        public JournalCarrierJumpStationFaction StationFaction { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<JournalCarrierJumpStationEconomy> StationEconomies { get; set; }
        public bool Taxi { get; set; }
        public bool Multicrew { get; set; }
        public string StarSystem { get; set; }
        public long SystemAddress { get; set; }
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
        public List<JournalCarrierJumpFaction> Factions { get; set; }
        public JournalCarrierJumpSystemFaction SystemFaction { get; set; }
    }

    public class JournalCarrierJumpStationEconomy
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public double Proportion { get; set; }
    }

    public class JournalCarrierJumpStationFaction
    {
        public string Name { get; set; }
    }

    public class JournalCarrierJumpSystemFaction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
    }

}