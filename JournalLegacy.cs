using EDCrew;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{
    public class JournalLegacy
    {
        //{ "timestamp":"2023-02-02T22:30:51Z", "event":"ShipTargeted", "TargetLocked":true, "Ship":"cobramkiii", "Ship_Localised":"Cobra Mk III", "ScanStage":3, "PilotName":"$npc_name_decorate:#name=Gareth Knipe;", "PilotName_Localised":"Gareth Knipe", "PilotRank":"Mostly Harmless", "ShieldHealth":0.000000, "HullHealth":100.000000, "Faction":"Candy Crew Guild", "LegalStatus":"Wanted", "Bounty":112347 }
        public DateTime timestamp { get; set; }

        public string @event { get; set; }
        public Int64 SystemAddress { get; set; }
        public String SignalName { get; set; }

        public bool IsStation { get; set; }
        public bool Taxi { get; set; }
        //public bool Multicrew { get; set; }

        public String StarSystem { get; set; }

        public String From { get; set; }
        public String From_Localised { get; set; }

        public String Message { get; set; }
        public String Message_Localised { get; set; }

        public String Channel { get; set; }

        public String JumpType { get; set; }

        public String StarClass { get; set; }

        public Boolean TargetLocked { get; set; }
        public String Ship { get; set; }
        
        public String Ship_Localised { get; set; }
        public int ScanStage { get; set; }
        public String PilotName { get; set; }
        
        public String PilotName_Localised { get; set; }
        
        public String PilotRank { get; set; }
        public Decimal ShieldHealth { get; set; }
        
        public Decimal HullHealth { get; set; }
        
        public String Faction { get; set; }
        public String LegalStatus { get; set; } 
        
        public Decimal Bounty { get; set; }

        public String Commander { get; set; }

        public String ShipName { get; set; }

        public String ShipIdent { get; set; }

        public List<InventoryMaterialType> Raw { get; set; }
        public List<InventoryMaterialType> Manufactured { get; set; }
        public List<InventoryMaterialType> Encoded { get; set; }

        public List<RewardType> Rewards { get; set; }

        public String Target { get; set; }
        public Decimal TotalReward { get; set; }
        public String VictimFaction { get; set; }
        public int ShipId { get; internal set; }

        //{ "timestamp":"2023-03-19T21:15:45Z", "event":"MaterialCollected", "Category":"Manufactured", "Name":"salvagedalloys", "Name_Localised":"Aleaciones recuperadas", "Count":3 }
        //{ "timestamp":"2023-03-19T21:03:24Z", "event":"EngineerCraft", "Slot":"TinyHardpoint3", "Module":"hpt_shieldbooster_size0_class5", "Ingredients":[ { "Name":"conductiveceramics", "Name_Localised":"Cerámicas conductivas", "Count":1 }, { "Name":"refinedfocuscrystals", "Name_Localised":"Cristales de enfoque refinados", "Count":1 }, { "Name":"imperialshielding", "Name_Localised":"Escudos imperiales", "Count":1 } ], "Engineer":"Didi Vatermann", "EngineerID":300000, "BlueprintID":128673794, "BlueprintName":"ShieldBooster_Resistive", "Level":5, "Quality":1.000000, "ExperimentalEffect":"special_shieldbooster_efficient", "ExperimentalEffect_Localised":"Control de flujo", "Modifiers":[ { "Label":"Integrity", "Value":42.239998, "OriginalValue":48.000000, "LessIsGood":0 }, { "Label":"PowerDraw", "Value":1.350000, "OriginalValue":1.200000, "LessIsGood":1 }, { "Label":"KineticResistance", "Value":17.000002, "OriginalValue":0.000000, "LessIsGood":0 }, { "Label":"ThermicResistance", "Value":17.000002, "OriginalValue":0.000000, "LessIsGood":0 }, { "Label":"ExplosiveResistance", "Value":17.000002, "OriginalValue":0.000000, "LessIsGood":0 } ] }
        //{ "timestamp":"2023-03-19T22:01:22Z", "event":"MissionCompleted", "Faction":"Silvait Gold Advanced Exchange", "Name":"Mission_MassacreWing_name", "MissionID":920351686, "TargetType":"$MissionUtil_FactionTag_Pirate;", "TargetType_Localised":"Piratas", "TargetFaction":"Syndicate of Cartoi", "KillCount":63, "DestinationSystem":"Cartoi", "DestinationStation":"Dittmar Orbital", "Reward":13146456, "MaterialsReward":[ { "Name":"ExquisiteFocusCrystals", "Name_Localised":"Cristales de enfoque exquisitos", "Category":"$MICRORESOURCE_CATEGORY_Manufactured;", "Category_Localised":"Manufacturado", "Count":5 } ], "FactionEffects":[ { "Faction":"", "Effects":[ { "Effect":"$MISSIONUTIL_Interaction_Summary_EP_up;", "Effect_Localised":"La economía de $#MinorFaction; ha mejorado en el sistema $#System;.", "Trend":"UpGood" } ], "Influence":[ { "SystemAddress":4207289471706, "Trend":"DownBad", "Influence":"+" } ], "ReputationTrend":"DownBad", "Reputation":"+" }, { "Faction":"Silvait Gold Advanced Exchange", "Effects":[ { "Effect":"$MISSIONUTIL_Interaction_Summary_EP_up;", "Effect_Localised":"La economía de $#MinorFaction; ha mejorado en el sistema $#System;.", "Trend":"UpGood" } ], "Influence":[ { "SystemAddress":9469194610097, "Trend":"UpGood", "Influence":"++" } ], "ReputationTrend":"UpGood", "Reputation":"++" } ] }

        public String Category { get; set; }

        public String Name { get; set; }

        public String Name_Localised { get; set; }

        public int Count { get; set; }

        public String Slot { get; set; }

        public String Module { get; set; }

        public List<InventoryMaterialType> Ingredients { get; set; }

        public String Engineer { get; set; }

        public int EngineerID { get; set; }

        public int BlueprintID { get; set; }
public String BlueprintName { get; set; }

        public int Level { get; set; }
        public Decimal Quality { get; set; }

        public Decimal MarketID { get; set; }
        public String TraderType { get; set; }

        public MaterialTradeType Paid { get; set; }

        public MaterialTradeType Received { get; set; }

        public List<MaterialRewardType> MaterialsReward { get; set; }

        public List<CommodityRewardType> CommodityReward { get; set; }

        public Int64 Reward { get; set; }

        public string TargetFaction { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        
        public List<global::FactionEffectType> FactionEffects { get; set; }

        public String AwardingFaction { get; set; }
        public String AwardingFaction_Localised { get; set; }

        public String VictimFaction_Localised { get; set; }
        public String Target_Localised { get; internal set; }

        public List<Mission> Active { get; set; }

        public List<Mission> Failed { get; set; }

        public List<Mission> Complete { get; set; }

        //event RedeemVoucher
        //type CombatBond
        public String @Type { get; set; }

        public Decimal Amount { get; set; }
        public string Subsystem_Localised { get; set; }

        //public int Combat { get; set; }
        public int Trade { get; set; }

        public int Explore { get; set; }
        public int Soldier { get; set; }
        public int Exobiologist { get; set; }
        public Decimal Empire { get; set; }
        public Decimal Federation { get; set; }

        public Decimal Alliance { get; set; }

        //public int CQC { get; set; }

        //PowerPlay

        public string Power { get; set; }
        public int MeritsGained { get; set; }
        public int TotalMerits { get; set; }

        public int Rank { get; set; }

        /*Statistics*/

        public BankAccount Bank_Account { get; set; }
        //public Combat Combat { get; set; }
        public Crime Crime { get; set; }
        public Smuggling Smuggling { get; set; }
        public Trading Trading { get; set; }
        public Mining Mining { get; set; }
        public Exploration Exploration { get; set; }
        public Passengers Passengers { get; set; }
        public SearchAndRescue Search_And_Rescue { get; set; }
        public TGENCOUNTERS TG_ENCOUNTERS { get; set; }
        public Crafting Crafting { get; set; }
        public Crew Crew { get; set; }
        //public Multicrew Multicrew { get; set; }
        public MaterialTraderStats Material_Trader_Stats { get; set; }
        public FLEETCARRIER FLEETCARRIER { get; set; }
        public Exobiology Exobiology { get; set; }

        //Location

        public double DistFromStarLS { get; set; }
        public bool Docked { get; set; }

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
        public BigInteger Population { get; set; }
        public string Body { get; set; }
        public Int64 BodyID { get; set; }
        public string BodyType { get; set; }
        public List<Faction> Factions { get; set; }
        public SystemFaction SystemFaction { get; set; }
        public List<Conflict> Conflicts { get; set; }

        public List<Signal> Signals { get; set; }
        public int LandingPad { get; set; }
        public string StationName { get; set; }

        public string Type_Localised { get; set; }
        public bool Stolen { get; set; }

        public bool Abandoned { get; set; }

        public string BodyName { get; set; }

        //

        public string ScanType { get; set; }
        public string Genus { get; set; }
        public string Genus_Localised { get; set; }
        public string Species { get; set; }
        public string Species_Localised { get; set; }
        public string Variant { get; set; }
        public string Variant_Localised { get; set; }

        //

        public string StationType { get; set; }
        
        
        
        public StationFaction StationFaction { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public List<string> StationServices { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public List<StationEconomy> StationEconomies { get; set; }

        public LandingPads LandingPads { get; set; }

        public string SquadronName { get; set; }
        public int CurrentRank { get; set; }
        public long MissionID { get; set; }
        public string LocalisedName { get; set; }
        public DateTime Expiry { get; set; }

        /*ColonisationProgress*/

        public double ConstructionProgress { get; set; }
        public bool ConstructionComplete { get; set; }
        public bool ConstructionFailed { get; set; }
        public List<ResourcesRequiredType> ResourcesRequired { get; set; }
    }


    public class MaterialRewardType
    {
            public string Name { get; set; }
            public string Name_Localised { get; set; }

        public String Category { get; set; }

        public String Category_Localised { get; set; }
        public int Count { get; set; }

    }

    public class StationEconomy
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public double Proportion { get; set; }
    }

    public class StationFaction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
    }
    public class CommodityRewardType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }

    }

    public class MaterialTradeType
    {
        public String Material { get; set; }
        public String Material_Localised { get; set; }

        public String Category { get; set; }
        public int Quantity { get; set; }
    }

    public class RewardType
    {
        public String Faction { get; set; }
        public Decimal Reward { get; set; }
    }

    public class InventoryMaterialType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public int Count { get; set; }
    }
    public class Inventario
    {
        public List<InventoryMaterialType> Raw { get; set; }
        public List<InventoryMaterialType> Manufactured { get; set; }
        public List<InventoryMaterialType> Encoded { get; set; }

    }

    public class Mission
    {
        public Int64 MissionID { get; set; }
        public String Name { get; set; }
        public Boolean PassengerMission { get; set; }
        public int Expires { get; set; }

    }

    public class BankAccount
    {
        public Int64 Current_Wealth { get; set; }
        public Int64 Spent_On_Ships { get; set; }
        public Int64 Spent_On_Outfitting { get; set; }
        public Int64 Spent_On_Repairs { get; set; }
        public Int64 Spent_On_Fuel { get; set; }
        public Int64 Spent_On_Ammo_Consumables { get; set; }
        public int Insurance_Claims { get; set; }
        public Int64 Spent_On_Insurance { get; set; }
        public int Owned_Ship_Count { get; set; }
        public Int64 Spent_On_Suits { get; set; }
        public Int64 Spent_On_Weapons { get; set; }
        public Int64 Spent_On_Suit_Consumables { get; set; }
        public int Suits_Owned { get; set; }
        public int Weapons_Owned { get; set; }
        public Int64 Spent_On_Premium_Stock { get; set; }
        public int Premium_Stock_Bought { get; set; }
    }

    public class Combat
    {
        public int Bounties_Claimed { get; set; }
        public Int64 Bounty_Hunting_Profit { get; set; }
        public int Combat_Bonds { get; set; }
        public Int64 Combat_Bond_Profits { get; set; }
        public int Assassinations { get; set; }
        public Int64 Assassination_Profits { get; set; }
        public int Highest_Single_Reward { get; set; }
        public int Skimmers_Killed { get; set; }
        public int OnFoot_Combat_Bonds { get; set; }
        public Int64 OnFoot_Combat_Bonds_Profits { get; set; }
        public int OnFoot_Vehicles_Destroyed { get; set; }
        public int OnFoot_Ships_Destroyed { get; set; }
        public int Dropships_Taken { get; set; }
        public int Dropships_Booked { get; set; }
        public int Dropships_Cancelled { get; set; }
        public int ConflictZone_High { get; set; }
        public int ConflictZone_Medium { get; set; }
        public int ConflictZone_Low { get; set; }
        public int ConflictZone_Total { get; set; }
        public int ConflictZone_High_Wins { get; set; }
        public int ConflictZone_Medium_Wins { get; set; }
        public int ConflictZone_Low_Wins { get; set; }
        public int ConflictZone_Total_Wins { get; set; }
        public int Settlement_Defended { get; set; }
        public int Settlement_Conquered { get; set; }
        public int OnFoot_Skimmers_Killed { get; set; }
        public int OnFoot_Scavs_Killed { get; set; }
    }

    public class Crafting
    {
        public int Count_Of_Used_Engineers { get; set; }
        public int Recipes_Generated { get; set; }
        public int Recipes_Generated_Rank_1 { get; set; }
        public int Recipes_Generated_Rank_2 { get; set; }
        public int Recipes_Generated_Rank_3 { get; set; }
        public int Recipes_Generated_Rank_4 { get; set; }
        public int Recipes_Generated_Rank_5 { get; set; }
        public int Suit_Mods_Applied { get; set; }
        public int Weapon_Mods_Applied { get; set; }
        public int Suits_Upgraded { get; set; }
        public int Weapons_Upgraded { get; set; }
        public int Suits_Upgraded_Full { get; set; }
        public int Weapons_Upgraded_Full { get; set; }
        public int Suit_Mods_Applied_Full { get; set; }
        public int Weapon_Mods_Applied_Full { get; set; }
    }

    public class Crew
    {
        public Int64 NpcCrew_TotalWages { get; set; }
        public int NpcCrew_Hired { get; set; }
        public int NpcCrew_Fired { get; set; }
        public int NpcCrew_Died { get; set; }
    }

    public class Crime
    {
        public int Notoriety { get; set; }
        public int Fines { get; set; }
        public int Total_Fines { get; set; }
        public int Bounties_Received { get; set; }
        public int Total_Bounties { get; set; }
        public int Highest_Bounty { get; set; }
        public int Malware_Uploaded { get; set; }
        public int Settlements_State_Shutdown { get; set; }
        public int Production_Sabotage { get; set; }
        public int Production_Theft { get; set; }
        public int Total_Murders { get; set; }
        public int Citizens_Murdered { get; set; }
        public int Omnipol_Murdered { get; set; }
        public int Guards_Murdered { get; set; }
        public int Data_Stolen { get; set; }
        public int Goods_Stolen { get; set; }
        public int Sample_Stolen { get; set; }
        public int Total_Stolen { get; set; }
        public int Turrets_Destroyed { get; set; }
        public int Turrets_Overloaded { get; set; }
        public int Turrets_Total { get; set; }
        public int Value_Stolen_StateChange { get; set; }
        public int Profiles_Cloned { get; set; }
    }

    public class Exobiology
    {
        public int Organic_Genus_Encountered { get; set; }
        public int Organic_Species_Encountered { get; set; }
        public int Organic_Variant_Encountered { get; set; }
        public int Organic_Data_Profits { get; set; }
        public int Organic_Data { get; set; }
        public int First_Logged_Profits { get; set; }
        public int First_Logged { get; set; }
        public int Organic_Systems { get; set; }
        public int Organic_Planets { get; set; }
        public int Organic_Genus { get; set; }
        public int Organic_Species { get; set; }
    }

    public class Exploration
    {
        public int Systems_Visited { get; set; }
        public int Exploration_Profits { get; set; }
        public int Planets_Scanned_To_Level_2 { get; set; }
        public int Planets_Scanned_To_Level_3 { get; set; }
        public int Efficient_Scans { get; set; }
        public int Highest_Payout { get; set; }
        public int Total_Hyperspace_Distance { get; set; }
        public int Total_Hyperspace_Jumps { get; set; }
        public double Greatest_Distance_From_Start { get; set; }
        public int Time_Played { get; set; }
        public int OnFoot_Distance_Travelled { get; set; }
        public int Shuttle_Journeys { get; set; }
        public int Shuttle_Distance_Travelled { get; set; }
        public int Spent_On_Shuttles { get; set; }
        public int First_Footfalls { get; set; }
        public int Planet_Footfalls { get; set; }
        public int Settlements_Visited { get; set; }
    }

    public class FLEETCARRIER
    {
        public int FLEETCARRIER_EXPORT_TOTAL { get; set; }
        public int FLEETCARRIER_IMPORT_TOTAL { get; set; }
        public int FLEETCARRIER_TRADEPROFIT_TOTAL { get; set; }
        public Int64 FLEETCARRIER_TRADESPEND_TOTAL { get; set; }
        public int FLEETCARRIER_STOLENPROFIT_TOTAL { get; set; }
        public int FLEETCARRIER_STOLENSPEND_TOTAL { get; set; }
        public double FLEETCARRIER_DISTANCE_TRAVELLED { get; set; }
        public int FLEETCARRIER_TOTAL_JUMPS { get; set; }
        public int FLEETCARRIER_SHIPYARD_SOLD { get; set; }
        public int FLEETCARRIER_SHIPYARD_PROFIT { get; set; }
        public int FLEETCARRIER_OUTFITTING_SOLD { get; set; }
        public int FLEETCARRIER_OUTFITTING_PROFIT { get; set; }
        public int FLEETCARRIER_REARM_TOTAL { get; set; }
        public int FLEETCARRIER_REFUEL_TOTAL { get; set; }
        public int FLEETCARRIER_REFUEL_PROFIT { get; set; }
        public int FLEETCARRIER_REPAIRS_TOTAL { get; set; }
        public int FLEETCARRIER_VOUCHERS_REDEEMED { get; set; }
        public int FLEETCARRIER_VOUCHERS_PROFIT { get; set; }
    }

    public class MaterialTraderStats
    {
        public int Trades_Completed { get; set; }
        public int Materials_Traded { get; set; }
        public int Encoded_Materials_Traded { get; set; }
        public int Raw_Materials_Traded { get; set; }
        public int Grade_1_Materials_Traded { get; set; }
        public int Grade_2_Materials_Traded { get; set; }
        public int Grade_3_Materials_Traded { get; set; }
        public int Grade_4_Materials_Traded { get; set; }
        public int Grade_5_Materials_Traded { get; set; }
        public int Assets_Traded_In { get; set; }
        public int Assets_Traded_Out { get; set; }
    }

    public class Mining
    {
        public long Mining_Profits { get; set; }
        public int Quantity_Mined { get; set; }
        public int Materials_Collected { get; set; }
    }

    public class Multicrew
    {
        public int Multicrew_Time_Total { get; set; }
        public int Multicrew_Gunner_Time_Total { get; set; }
        public int Multicrew_Fighter_Time_Total { get; set; }
        public int Multicrew_Credits_Total { get; set; }
        public int Multicrew_Fines_Total { get; set; }
    }

    public class Passengers
    {
        public int Passengers_Missions_Accepted { get; set; }
        public int Passengers_Missions_Disgruntled { get; set; }
        public int Passengers_Missions_Bulk { get; set; }
        public int Passengers_Missions_VIP { get; set; }
        public int Passengers_Missions_Delivered { get; set; }
        public int Passengers_Missions_Ejected { get; set; }
    }

    public class SearchAndRescue
    {
        public int SearchRescue_Traded { get; set; }
        public int SearchRescue_Profit { get; set; }
        public int SearchRescue_Count { get; set; }
        public int Salvage_Legal_POI { get; set; }
        public int Salvage_Legal_Settlements { get; set; }
        public int Salvage_Illegal_POI { get; set; }
        public int Salvage_Illegal_Settlements { get; set; }
        public int Maglocks_Opened { get; set; }
        public int Panels_Opened { get; set; }
        public int Settlements_State_FireOut { get; set; }
        public int Settlements_State_Reboot { get; set; }
    }

    public class Smuggling
    {
        public int Black_Markets_Traded_With { get; set; }
        public int Black_Markets_Profits { get; set; }
        public int Resources_Smuggled { get; set; }
        public double Average_Profit { get; set; }
        public int Highest_Single_Transaction { get; set; }
    }

    public class TGENCOUNTERS
    {
        public int TG_ENCOUNTER_TOTAL { get; set; }
        public string TG_ENCOUNTER_TOTAL_LAST_SYSTEM { get; set; }
        public string TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP { get; set; }
        public string TG_ENCOUNTER_TOTAL_LAST_SHIP { get; set; }
        public int TG_SCOUT_COUNT { get; set; }
    }

    public class Trading
    {
        public int Markets_Traded_With { get; set; }
        public Int64 Market_Profits { get; set; }
        public int Resources_Traded { get; set; }
        public double Average_Profit { get; set; }
        public int Highest_Single_Transaction { get; set; }
        public int Data_Sold { get; set; }
        public int Goods_Sold { get; set; }
        public int Assets_Sold { get; set; }
    }
    //Location


    public class ActiveState
    {
        public string State { get; set; }
    }

    public class Conflict
    {
        public string WarType { get; set; }
        public string Status { get; set; }
        public Faction1 Faction1 { get; set; }
        public Faction2 Faction2 { get; set; }
    }

    public class Faction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public double Influence { get; set; }
        public string Allegiance { get; set; }
        public string Happiness { get; set; }
        public string Happiness_Localised { get; set; }
        public double MyReputation { get; set; }
        public List<ActiveState> ActiveStates { get; set; }
        public List<PendingState> PendingStates { get; set; }
    }

    public class Faction1
    {
        public string Name { get; set; }
        public string Stake { get; set; }
        public int WonDays { get; set; }
    }

    public class Faction2
    {
        public string Name { get; set; }
        public string Stake { get; set; }
        public int WonDays { get; set; }
    }

    public class PendingState
    {
        public string State { get; set; }
        public int Trend { get; set; }
    }

    public class SystemFaction
    {
        public string Name { get; set; }
        public string FactionState { get; set; }
    }

    public class Signal
    {
        public string Type { get; set; }
        public string Type_Localised { get; set; }
        public int Count { get; set; }
    }

}


/*
 
Flags:

Bit	Value	Hex	Meaning
0	1	0000 0001	Docked, (on a landing pad)
1	2	0000 0002	Landed, (on planet surface)
2	4	0000 0004	Landing Gear Down
3	8	0000 0008	Shields Up
4	16	0000 0010	Supercruise
5	32	0000 0020	FlightAssist Off
6	64	0000 0040	Hardpoints Deployed
7	128	0000 0080	In Wing
8	256	0000 0100	LightsOn
9	512	0000 0200	Cargo Scoop Deployed
10	1024	0000 0400	Silent Running,
11	2048	0000 0800	Scooping Fuel
12	4096	0000 1000	Srv Handbrake
13	8192	0000 2000	Srv using Turret view
14	16384	0000 4000	Srv Turret retracted (close to ship)
15	32768	0000 8000	Srv DriveAssist
16	65536	0001 0000	Fsd MassLocked
17	131072	0002 0000	Fsd Charging
18	262144	0004 0000	Fsd Cooldown
19	524288	0008 0000	Low Fuel ( < 25% )
20	1048576	0010 0000	Over Heating ( > 100% )
21	2097152	0020 0000	Has Lat Int64
22	4194304	0040 0000	IsInDanger
23	8388608	0080 0000	Being Interdicted
24	16777216	0100 0000	In MainShip
25	33554432	0200 0000	In Fighter
26	67108864	0400 0000	In SRV
27	134217728	0800 0000	Hud in Analysis mode
28	268435456	1000 0000	Night Vision
29	536870912	2000 0000	Altitude from Average radius
30‭	1073741824‬	4000 0000	fsdJump
31	2147483648	8000 0000	srvHighBeam
Flags2 bits:

Bit	Value	Hex	Meaning
0	1	0001	OnFoot
1	2	0002	InTaxi (or dropship/shuttle)
2	4	0004	InMulticrew (ie in someone else's ship)
3	8	0008	OnFootInStation
4	16	0010	OnFootOnPlanet
5	32	0020	AimDownSight
6	64	0040	LowOxygen
7	128	0080	LowHealth
8	256	0100	Cold
9	512	0200	Hot
10	1024	0400	VeryCold
11	2048	0800	VeryHot
12	4096	1000	Glide Mode
13	8192	2000	OnFootInHangar
14	16384	4000	OnFootSocialSpace
15	32768	8000	OnFootExterior
16	65536	0001 0000	BreathableAtmosphere
17	131072	0002 0000	Telepresence Multicrew
18	262144	0004 0000	Physical Multicrew

 */

//{ "timestamp":"2023-03-19T21:15:45Z", "event":"MaterialCollected", "Category":"Manufactured", "Name":"salvagedalloys", "Name_Localised":"Aleaciones recuperadas", "Count":3 }

public class JournalStatisticsLegacy : JournalLegacy
{
    public Combat Combat { get; set; }
}

public class LandingPads
{
    public int Small { get; set; }
    public int Medium { get; set; }
    public int Large { get; set; }
}

public class FactionEffectType
{
    public string Faction { get; set; }
    public List<EffectType> Effects { get; set; }
    public List<InfluenceType> Influence { get; set; }
    public string ReputationTrend { get; set; }
    public string Reputation { get; set; }
}

public class EffectType
{
    public string Effect { get; set; }
    public string Effect_Localised { get; set; }
    public string Trend { get; set; }
}

public class InfluenceType
{
    public Int64 SystemAddress { get; set; }
    public string Trend { get; set; }
    public string Influence { get; set; }
}
