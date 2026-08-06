using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2024-10-26T11:39:27Z", "event":"Statistics", "Bank_Account":{ "Current_Wealth":32798123393, "Spent_On_Ships":1430574997, "Spent_On_Outfitting":3069745764, "Spent_On_Repairs":31174696, "Spent_On_Fuel":1656168, "Spent_On_Ammo_Consumables":6059459, "Insurance_Claims":60, "Spent_On_Insurance":266238413, "Owned_Ship_Count":34, "Spent_On_Suits":12450000, "Spent_On_Weapons":1625000, "Spent_On_Suit_Consumables":0, "Suits_Owned":4, "Weapons_Owned":9, "Spent_On_Premium_Stock":12875000, "Premium_Stock_Bought":3 }, "Combat":{ "Bounties_Claimed":19914, "Bounty_Hunting_Profit":4752889089, "Combat_Bonds":14333, "Combat_Bond_Profits":1311883435, "Assassinations":227, "Assassination_Profits":417779060, "Highest_Single_Reward":2391200, "Skimmers_Killed":31, "OnFoot_Combat_Bonds":0, "OnFoot_Combat_Bonds_Profits":0, "OnFoot_Vehicles_Destroyed":0, "OnFoot_Ships_Destroyed":0, "Dropships_Taken":0, "Dropships_Booked":0, "Dropships_Cancelled":0, "ConflictZone_High":0, "ConflictZone_Medium":0, "ConflictZone_Low":0, "ConflictZone_Total":0, "ConflictZone_High_Wins":0, "ConflictZone_Medium_Wins":0, "ConflictZone_Low_Wins":0, "ConflictZone_Total_Wins":0, "Settlement_Defended":0, "Settlement_Conquered":0, "OnFoot_Skimmers_Killed":2, "OnFoot_Scavs_Killed":0 }, "Crime":{ "Notoriety":0, "Fines":152, "Total_Fines":14946829, "Bounties_Received":210, "Total_Bounties":802400, "Highest_Bounty":148900, "Malware_Uploaded":0, "Settlements_State_Shutdown":0, "Production_Sabotage":0, "Production_Theft":3, "Total_Murders":27, "Citizens_Murdered":9, "Omnipol_Murdered":0, "Guards_Murdered":18, "Data_Stolen":0, "Goods_Stolen":13, "Sample_Stolen":0, "Total_Stolen":13, "Turrets_Destroyed":0, "Turrets_Overloaded":0, "Turrets_Total":0, "Value_Stolen_StateChange":0, "Profiles_Cloned":1 }, "Smuggling":{ "Black_Markets_Traded_With":19, "Black_Markets_Profits":67017325, "Resources_Smuggled":8935, "Average_Profit":1175742.5438596, "Highest_Single_Transaction":4865900 }, "Trading":{ "Markets_Traded_With":455, "Market_Profits":21737243979, "Resources_Traded":714801, "Average_Profit":9975788.8843506, "Highest_Single_Transaction":265135669, "Data_Sold":0, "Goods_Sold":0, "Assets_Sold":0 }, "Mining":{ "Mining_Profits":1243747894, "Quantity_Mined":626, "Materials_Collected":50071 }, "Exploration":{ "Systems_Visited":4305, "Exploration_Profits":107491404, "Planets_Scanned_To_Level_2":17799, "Planets_Scanned_To_Level_3":17795, "Efficient_Scans":73, "Highest_Payout":1946292, "Total_Hyperspace_Distance":201830, "Total_Hyperspace_Jumps":11024, "Greatest_Distance_From_Start":5384.3376885066, "Time_Played":11000880, "OnFoot_Distance_Travelled":64952, "Shuttle_Journeys":0, "Shuttle_Distance_Travelled":0, "Spent_On_Shuttles":0, "First_Footfalls":3, "Planet_Footfalls":80, "Settlements_Visited":20 }, "Passengers":{ "Passengers_Missions_Accepted":1918, "Passengers_Missions_Disgruntled":114, "Passengers_Missions_Bulk":3185, "Passengers_Missions_VIP":8442, "Passengers_Missions_Delivered":11627, "Passengers_Missions_Ejected":89 }, "Search_And_Rescue":{ "SearchRescue_Traded":200, "SearchRescue_Profit":4874361, "SearchRescue_Count":85, "Salvage_Legal_POI":384400, "Salvage_Legal_Settlements":0, "Salvage_Illegal_POI":0, "Salvage_Illegal_Settlements":0, "Maglocks_Opened":4, "Panels_Opened":8, "Settlements_State_FireOut":0, "Settlements_State_Reboot":0 }, "TG_ENCOUNTERS":{ "TG_ENCOUNTER_KILLED":240, "TG_ENCOUNTER_TOTAL":12, "TG_ENCOUNTER_TOTAL_LAST_SYSTEM":"Merope", "TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP":"3310-03-16 18:37", "TG_ENCOUNTER_TOTAL_LAST_SHIP":"Anaconda" }, "Crafting":{ "Count_Of_Used_Engineers":15, "Recipes_Generated":5872, "Recipes_Generated_Rank_1":569, "Recipes_Generated_Rank_2":740, "Recipes_Generated_Rank_3":1221, "Recipes_Generated_Rank_4":1710, "Recipes_Generated_Rank_5":1632, "Suit_Mods_Applied":0, "Weapon_Mods_Applied":0, "Suits_Upgraded":0, "Weapons_Upgraded":0, "Suits_Upgraded_Full":0, "Weapons_Upgraded_Full":0, "Suit_Mods_Applied_Full":0, "Weapon_Mods_Applied_Full":0 }, "Crew":{ "NpcCrew_TotalWages":1815748209, "NpcCrew_Hired":4, "NpcCrew_Fired":3, "NpcCrew_Died":6 }, "Multicrew":{ "Multicrew_Time_Total":123246, "Multicrew_Gunner_Time_Total":10051, "Multicrew_Fighter_Time_Total":256, "Multicrew_Credits_Total":20093761, "Multicrew_Fines_Total":0 }, "Material_Trader_Stats":{ "Trades_Completed":670, "Materials_Traded":45822, "Encoded_Materials_Traded":13674, "Raw_Materials_Traded":7212, "Grade_1_Materials_Traded":10788, "Grade_2_Materials_Traded":9700, "Grade_3_Materials_Traded":12381, "Grade_4_Materials_Traded":9778, "Grade_5_Materials_Traded":3175, "Assets_Traded_In":0, "Assets_Traded_Out":0 }, "CQC":{ "CQC_Credits_Earned":740, "CQC_Time_Played":450, "CQC_KD":0.25, "CQC_Kills":1, "CQC_WL":0 }, "FLEETCARRIER":{ "FLEETCARRIER_EXPORT_TOTAL":314092, "FLEETCARRIER_IMPORT_TOTAL":207323, "FLEETCARRIER_TRADEPROFIT_TOTAL":2060739952, "FLEETCARRIER_TRADESPEND_TOTAL":5129272208, "FLEETCARRIER_STOLENPROFIT_TOTAL":0, "FLEETCARRIER_STOLENSPEND_TOTAL":0, "FLEETCARRIER_DISTANCE_TRAVELLED":36403.29205884, "FLEETCARRIER_TOTAL_JUMPS":193, "FLEETCARRIER_SHIPYARD_SOLD":0, "FLEETCARRIER_SHIPYARD_PROFIT":0, "FLEETCARRIER_OUTFITTING_SOLD":324, "FLEETCARRIER_OUTFITTING_PROFIT":1996126, "FLEETCARRIER_REARM_TOTAL":348, "FLEETCARRIER_REFUEL_TOTAL":1402, "FLEETCARRIER_REFUEL_PROFIT":0, "FLEETCARRIER_REPAIRS_TOTAL":334, "FLEETCARRIER_VOUCHERS_REDEEMED":0, "FLEETCARRIER_VOUCHERS_PROFIT":0 }, "Exobiology":{ "Organic_Genus_Encountered":11, "Organic_Species_Encountered":28, "Organic_Variant_Encountered":49, "Organic_Data_Profits":983604400, "Organic_Data":118, "First_Logged_Profits":34360000, "First_Logged":6, "Organic_Systems":45, "Organic_Planets":59, "Organic_Genus":10, "Organic_Species":12 } }
        public class JournalStatisticsBankAccount
    {
        public long Current_Wealth { get; set; }
        public int Spent_On_Ships { get; set; }
        public long Spent_On_Outfitting { get; set; }
        public int Spent_On_Repairs { get; set; }
        public int Spent_On_Fuel { get; set; }
        public int Spent_On_Ammo_Consumables { get; set; }
        public int Insurance_Claims { get; set; }
        public int Spent_On_Insurance { get; set; }
        public int Owned_Ship_Count { get; set; }
        public int Spent_On_Suits { get; set; }
        public int Spent_On_Weapons { get; set; }
        public int Spent_On_Suit_Consumables { get; set; }
        public int Suits_Owned { get; set; }
        public int Weapons_Owned { get; set; }
        public int Spent_On_Premium_Stock { get; set; }
        public int Premium_Stock_Bought { get; set; }
    }

    public class JournalStatisticsCombat
    {
        public int Bounties_Claimed { get; set; }
        public long Bounty_Hunting_Profit { get; set; }
        public int Combat_Bonds { get; set; }
        public int Combat_Bond_Profits { get; set; }
        public int Assassinations { get; set; }
        public int Assassination_Profits { get; set; }
        public int Highest_Single_Reward { get; set; }
        public int Skimmers_Killed { get; set; }
        public int OnFoot_Combat_Bonds { get; set; }
        public int OnFoot_Combat_Bonds_Profits { get; set; }
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

    public class JournalStatisticsCQC
    {
        public int CQC_Credits_Earned { get; set; }
        public int CQC_Time_Played { get; set; }
        public double CQC_KD { get; set; }
        public int CQC_Kills { get; set; }
        public int CQC_WL { get; set; }
    }

    public class JournalStatisticsCrafting
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

    public class JournalStatisticsCrew
    {
        public int NpcCrew_TotalWages { get; set; }
        public int NpcCrew_Hired { get; set; }
        public int NpcCrew_Fired { get; set; }
        public int NpcCrew_Died { get; set; }
    }

    public class JournalStatisticsCrime
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

    public class JournalStatisticsExobiology
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

    public class JournalStatisticsExploration
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

    public class JournalStatisticsFLEETCARRIER
    {
        public int FLEETCARRIER_EXPORT_TOTAL { get; set; }
        public int FLEETCARRIER_IMPORT_TOTAL { get; set; }
        public int FLEETCARRIER_TRADEPROFIT_TOTAL { get; set; }
        public long FLEETCARRIER_TRADESPEND_TOTAL { get; set; }
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

    public class JournalStatisticsMaterialTraderStats
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

    public class JournalStatisticsMining
    {
        public int Mining_Profits { get; set; }
        public int Quantity_Mined { get; set; }
        public int Materials_Collected { get; set; }
    }

    public class JournalStatisticsMulticrew
    {
        public int Multicrew_Time_Total { get; set; }
        public int Multicrew_Gunner_Time_Total { get; set; }
        public int Multicrew_Fighter_Time_Total { get; set; }
        public int Multicrew_Credits_Total { get; set; }
        public int Multicrew_Fines_Total { get; set; }
    }

    public class JournalStatisticsPassengers
    {
        public int Passengers_Missions_Accepted { get; set; }
        public int Passengers_Missions_Disgruntled { get; set; }
        public int Passengers_Missions_Bulk { get; set; }
        public int Passengers_Missions_VIP { get; set; }
        public int Passengers_Missions_Delivered { get; set; }
        public int Passengers_Missions_Ejected { get; set; }
    }

    public class JournalStatistics : JournalBase
    {
        public JournalStatisticsBankAccount Bank_Account { get; set; }
        public JournalStatisticsCombat Combat { get; set; }
        public JournalStatisticsCrime Crime { get; set; }
        public JournalStatisticsSmuggling Smuggling { get; set; }
        public JournalStatisticsTrading Trading { get; set; }
        public JournalStatisticsMining Mining { get; set; }
        public JournalStatisticsExploration Exploration { get; set; }
        public JournalStatisticsPassengers Passengers { get; set; }
        public JournalStatisticsSearchAndRescue Search_And_Rescue { get; set; }
        public JournalStatisticsTGENCOUNTERS TG_ENCOUNTERS { get; set; }
        public JournalStatisticsCrafting Crafting { get; set; }
        public JournalStatisticsCrew Crew { get; set; }
        public JournalStatisticsMulticrew Multicrew { get; set; }
        public JournalStatisticsMaterialTraderStats Material_Trader_Stats { get; set; }
        public JournalStatisticsCQC CQC { get; set; }
        public JournalStatisticsFLEETCARRIER FLEETCARRIER { get; set; }
        public JournalStatisticsExobiology Exobiology { get; set; }
    }

    public class JournalStatisticsSearchAndRescue
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

    public class JournalStatisticsSmuggling
    {
        public int Black_Markets_Traded_With { get; set; }
        public int Black_Markets_Profits { get; set; }
        public int Resources_Smuggled { get; set; }
        public double Average_Profit { get; set; }
        public int Highest_Single_Transaction { get; set; }
    }

    public class JournalStatisticsTGENCOUNTERS
    {
        public int TG_ENCOUNTER_KILLED { get; set; }
        public int TG_ENCOUNTER_TOTAL { get; set; }
        public string TG_ENCOUNTER_TOTAL_LAST_SYSTEM { get; set; }
        public string TG_ENCOUNTER_TOTAL_LAST_TIMESTAMP { get; set; }
        public string TG_ENCOUNTER_TOTAL_LAST_SHIP { get; set; }
    }

    public class JournalStatisticsTrading
    {
        public int Markets_Traded_With { get; set; }
        public long Market_Profits { get; set; }
        public int Resources_Traded { get; set; }
        public double Average_Profit { get; set; }
        public int Highest_Single_Transaction { get; set; }
        public int Data_Sold { get; set; }
        public int Goods_Sold { get; set; }
        public int Assets_Sold { get; set; }
    }

}