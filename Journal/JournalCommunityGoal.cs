using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{"timestamp":"2026-01-01T12:00:00Z","event":"CommunityGoal","CurrentGoals":[{"CGID":726,"Title":"Alliance Research Initiative - Trade","SystemName":"Kaushpoos","MarketName":"Neville Horizons","Expiry":"2026-01-17T14:58:14Z","IsComplete":false,"CurrentTotal":10062,"PlayerContribution":562,"NumContributors":101,"TopRankSize":10,"PlayerInTopRank":false,"TierReached":"Tier 1","PlayerPercentileBand":50,"Bonus":4000000000,"TopTier":{"Name":"Top 10 CMDRs","Bonus":"CR 200,000,000"}}]}
        public class JournalCommunityGoalCurrentGoal
    {
        public int CGID { get; set; }
        public string Title { get; set; }
        public string SystemName { get; set; }
        public string MarketName { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsComplete { get; set; }
        public int CurrentTotal { get; set; }
        public int PlayerContribution { get; set; }
        public int NumContributors { get; set; }
        public int TopRankSize { get; set; }
        public bool PlayerInTopRank { get; set; }
        public string TierReached { get; set; }
        public int PlayerPercentileBand { get; set; }
        public long Bonus { get; set; }
        public JournalCommunityGoalTopTier TopTier { get; set; }
    }

    public class JournalCommunityGoal : JournalBase
    {
        public List<JournalCommunityGoalCurrentGoal> CurrentGoals { get; set; }
    }

    public class JournalCommunityGoalTopTier
    {
        public string Name { get; set; }
        public string Bonus { get; set; }
    }

}