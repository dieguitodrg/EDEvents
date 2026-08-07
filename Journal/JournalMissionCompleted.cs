using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //{ "timestamp":"2023-12-04T22:31:14Z", "event":"MissionCompleted", "Faction":"Union Cosmos", "Name":"Mission_Salvage_name", "LocalisedName":"Operación de recuperación de Cajas negras", "MissionID":947196301, "Commodity":"$USSCargoBlackBox_Name;", "Commodity_Localised":"Cajas negras", "Count":4, "DestinationSystem":"Bakum", "DestinationStation":"Lozino-Lozinskiy Mine", "Reward":304528, "MaterialsReward":[ { "Name":"EmbeddedFirmware", "Name_Localised":"Firmware integrado modificado", "Category":"$MICRORESOURCE_CATEGORY_Encoded;", "Category_Localised":"Codificado", "Count":5 } ], "FactionEffects":[ { "Faction":"Union Cosmos", "Effects":[ { "Effect":"$MISSIONUTIL_Interaction_Summary_EP_up;", "Effect_Localised":"La economía de $#MinorFaction; ha mejorado en el sistema $#System;.", "Trend":"UpGood" } ], "Influence":[ { "SystemAddress":672833021345, "Trend":"UpGood", "Influence":"++" } ], "ReputationTrend":"UpGood", "Reputation":"++" }, { "Faction":"", "Effects":[  ], "Influence":[ { "SystemAddress":5581678973650, "Trend":"DownBad", "Influence":"+" } ], "ReputationTrend":"DownBad", "Reputation":"+" } ] }
public class EffectType
    {
        public string Effect { get; set; }
        public string Effect_Localised { get; set; }
        public string Trend { get; set; }
    }

    public class FactionEffectType
    {
        public string Faction { get; set; }
        public List<EffectType> Effects { get; set; }
        public List<InfluenceType> Influence { get; set; }
        public string ReputationTrend { get; set; }
        public string Reputation { get; set; }
    }

    public class InfluenceType
    {
        public Int64 SystemAddress { get; set; }
        public string Trend { get; set; }
        public string Influence { get; set; }
    }

    public class MaterialsRewardType
    {
        public string Name { get; set; }
        public string Name_Localised { get; set; }
        public string Category { get; set; }
        public string Category_Localised { get; set; }
        public int Count { get; set; }
    }

    public class JournalMissionCompleted : JournalBase
    {
        
        
        public string Faction { get; set; }
        public string Name { get; set; }
        public string LocalisedName { get; set; }
        public int MissionID { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public int Count { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public int Reward { get; set; }
        public List<MaterialsRewardType> MaterialsReward { get; set; }
        public List<CommodityRewardType> CommodityReward { get; set; }
        public List<FactionEffectType> FactionEffects { get; set; }
    }


}