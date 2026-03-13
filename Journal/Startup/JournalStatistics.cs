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


    public class JournalStatistics2 : JournalBase
    {
        public JournalStatistics2BankAccount Bank_Account { get; set; }
        public JournalStatistics2Combat Combat { get; set; }
        public JournalStatistics2Crime Crime { get; set; }
        public JournalStatistics2Smuggling Smuggling { get; set; }
        public JournalStatistics2Trading Trading { get; set; }
        public JournalStatistics2Mining Mining { get; set; }
        public JournalStatistics2Exploration Exploration { get; set; }
        public JournalStatistics2Passengers Passengers { get; set; }
        public JournalStatistics2SearchAndRescue Search_And_Rescue { get; set; }
        public JournalStatistics2Crafting Crafting { get; set; }
        public JournalStatistics2Crew Crew { get; set; }
        public JournalStatistics2Multicrew Multicrew { get; set; }

    }

    public class JournalStatistics2BankAccount
    {
        public int Current_Wealth { get; set; }
        public int Spent_On_Ships { get; set; }
        public int Spent_On_Outfitting { get; set; }
        public int Spent_On_Repairs { get; set; }
        public int Spent_On_Fuel { get; set; }
        public int Spent_On_Ammo_Consumables { get; set; }
        public int Insurance_Claims { get; set; }
        public int Spent_On_Insurance { get; set; }
    }

    public class JournalStatistics2Combat
    {
        public int Bounties_Claimed { get; set; }
        public int Bounty_Hunting_Profit { get; set; }
        public int Combat_Bonds { get; set; }
        public int Combat_Bond_Profits { get; set; }
        public int Assassinations { get; set; }
        public int Assassination_Profits { get; set; }
        public int Highest_Single_Reward { get; set; }
        public int Skimmers_Killed { get; set; }
    }

    public class JournalStatistics2Crafting
    {
        public int Spent_On_Crafting { get; set; }
        public int Count_Of_Used_Engineers { get; set; }
        public int Recipes_Generated { get; set; }
        public int Recipes_Generated_Rank_1 { get; set; }
        public int Recipes_Generated_Rank_2 { get; set; }
        public int Recipes_Generated_Rank_3 { get; set; }
        public int Recipes_Generated_Rank_4 { get; set; }
        public int Recipes_Generated_Rank_5 { get; set; }
        public int Recipes_Applied { get; set; }
        public int Recipes_Applied_Rank_1 { get; set; }
        public int Recipes_Applied_Rank_2 { get; set; }
        public int Recipes_Applied_Rank_3 { get; set; }
        public int Recipes_Applied_Rank_4 { get; set; }
        public int Recipes_Applied_Rank_5 { get; set; }
        public int Recipes_Applied_On_Previously_Modified_Modules { get; set; }
    }

    public class JournalStatistics2Crew
    {
        public int NpcCrew_TotalWages { get; set; }
        public int NpcCrew_Hired { get; set; }
        public int NpcCrew_Fired { get; set; }
        public int NpcCrew_Died { get; set; }
    }

    public class JournalStatistics2Crime
    {
        public int Fines { get; set; }
        public int Total_Fines { get; set; }
        public int Bounties_Received { get; set; }
        public int Total_Bounties { get; set; }
        public int Highest_Bounty { get; set; }
    }

    public class JournalStatistics2Exploration
    {
        public int Systems_Visited { get; set; }
        public int Fuel_Scooped { get; set; }
        public int Fuel_Purchased { get; set; }
        public int Exploration_Profits { get; set; }
        public int Planets_Scanned_To_Level_2 { get; set; }
        public int Planets_Scanned_To_Level_3 { get; set; }
        public int Highest_Payout { get; set; }
        public int Total_Hyperspace_Distance { get; set; }
        public int Total_Hyperspace_Jumps { get; set; }
        public double Greatest_Distance_From_Start { get; set; }
        public int Time_Played { get; set; }
    }

    public class JournalStatistics2Mining
    {
        public int Mining_Profits { get; set; }
        public int Quantity_Mined { get; set; }
        public int Materials_Collected { get; set; }
    }

    public class JournalStatistics2Multicrew
    {
        public int Multicrew_Time_Total { get; set; }
        public int Multicrew_Gunner_Time_Total { get; set; }
        public int Multicrew_Fighter_Time_Total { get; set; }
        public int Multicrew_Credits_Total { get; set; }
        public int Multicrew_Fines_Total { get; set; }
    }

    public class JournalStatistics2Passengers
    {
        public int Passengers_Missions_Bulk { get; set; }
        public int Passengers_Missions_VIP { get; set; }
        public int Passengers_Missions_Delivered { get; set; }
        public int Passengers_Missions_Ejected { get; set; }
    }

    public class JournalStatistics2SearchAndRescue
    {
        public int SearchRescue_Traded { get; set; }
        public int SearchRescue_Profit { get; set; }
        public int SearchRescue_Count { get; set; }
    }

    public class JournalStatistics2Smuggling
    {
        public int Black_Markets_Traded_With { get; set; }
        public int Black_Markets_Profits { get; set; }
        public int Resources_Smuggled { get; set; }
        public int Average_Profit { get; set; }
        public int Highest_Single_Transaction { get; set; }
    }

    public class JournalStatistics2Trading
    {
        public int Markets_Traded_With { get; set; }
        public int Market_Profits { get; set; }
        public int Resources_Traded { get; set; }
        public int Average_Profit { get; set; }
        public int Highest_Single_Transaction { get; set; }
    }



}