
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:21:36Z", "event":"FSDJump", "Taxi":false, "Multicrew":false, "StarSystem":"Matire", "SystemAddress":672833021345, "StarPos":[141.40625,-151.21875,-18.03125], "SystemAllegiance":"Empire", "SystemEconomy":"$economy_Extraction;", "SystemEconomy_Localised":"Extracción", "SystemSecondEconomy":"$economy_None;", "SystemSecondEconomy_Localised":"Ninguna", "SystemGovernment":"$government_Patronage;", "SystemGovernment_Localised":"Patronazgo", "SystemSecurity":"$SYSTEM_SECURITY_low;", "SystemSecurity_Localised":"Seguridad baja", "Population":3044, "Body":"Matire", "BodyID":0, "BodyType":"Star", "JumpDist":18.603, "FuelUsed":0.958438, "FuelLevel":30.093397, "Factions":[ { "Name":"Marquis du Matire", "FactionState":"None", "Government":"Feudal", "Influence":0.051051, "Allegiance":"Empire", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Lwena Central Corp.", "FactionState":"None", "Government":"Corporate", "Influence":0.062062, "Allegiance":"Empire", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Matire Systems", "FactionState":"None", "Government":"Corporate", "Influence":0.030030, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Matire United", "FactionState":"None", "Government":"Cooperative", "Influence":0.046046, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":0.000000 }, { "Name":"Hakurei Stargaze Musketeers", "FactionState":"Election", "Government":"Patronage", "Influence":0.388388, "Allegiance":"Empire", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":100.000000, "ActiveStates":[ { "State":"Election" } ] }, { "Name":"6th Interstellar Corps", "FactionState":"Expansion", "Government":"Patronage", "Influence":0.034034, "Allegiance":"Empire", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "MyReputation":100.000000, "ActiveStates":[ { "State":"Expansion" } ] }, { "Name":"Union Cosmos", "FactionState":"Election", "Government":"Dictatorship", "Influence":0.388388, "Allegiance":"Independent", "Happiness":"$Faction_HappinessBand2;", "Happiness_Localised":"Satisfecha", "SquadronFaction":true, "MyReputation":100.000000, "ActiveStates":[ { "State":"Election" } ] } ], "SystemFaction":{ "Name":"Hakurei Stargaze Musketeers", "FactionState":"Election" }, "Conflicts":[ { "WarType":"election", "Status":"active", "Faction1":{ "Name":"Hakurei Stargaze Musketeers", "Stake":"Henderson's Inheritance", "WonDays":0 }, "Faction2":{ "Name":"Union Cosmos", "Stake":"", "WonDays":2 } } ] }
public class ActiveStateType
    {
        public string State { get; set; }
    }

    public class ConflictType
    {
        public string WarType { get; set; }
        public string Status { get; set; }
        public FactionResultType Faction1 { get; set; }
        public FactionResultType Faction2 { get; set; }
    }

    public class FactionType
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public double Influence { get; set; }
        public string Allegiance { get; set; }
        public string Happiness { get; set; }
        public string Happiness_Localised { get; set; }
        public double MyReputation { get; set; }
        public List<ActiveStateType> ActiveStates { get; set; }
        public bool? SquadronFaction { get; set; }
    }

    public class FactionResultType
    {
        public string Name { get; set; }
        public string Stake { get; set; }
        public int WonDays { get; set; }
    }

    public class JournalFSDJump : JournalBase
    {
        
        
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
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public double FuelLevel { get; set; }
        public List<FactionType> Factions { get; set; }
        public SystemFactionType SystemFaction { get; set; }
        public List<ConflictType> Conflicts { get; set; }
    }

    public class SystemFactionType
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
    }


}