using System;
using System.Threading;
using System.Threading.Tasks;
using EDCrew.Pipeline;
using EDCrew.Pipeline.Handlers;
using Xunit;

namespace EDCrew.Tests.Pipeline
{
    public class StateHandlersTests
    {
        [Fact]
        public async Task PowerplayRank_StoresRankInState()
        {
            var state = new FakeCopilotState();
            var handler = new PowerplayRankHandler(state);
            var journal = new JournalPowerplayRank { Power = "Jerome Archer", Rank = 5 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Same(journal, state.JournalPowerRank);
        }

        [Fact]
        public async Task PowerplayMerits_StoresMeritsAndIncrementsCounter()
        {
            var state = new FakeCopilotState();
            var handler = new PowerplayMeritsHandler(state);
            var journal = new JournalPowerplayMerits { Power = "Jerome Archer", MeritsGained = 796, TotalMerits = 21739 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Same(journal, state.JournalPowerMerits);
            Assert.Equal(796, state.Counters.Merits);
        }

        [Fact]
        public async Task SquadronStartup_StoresSquadronInState()
        {
            var state = new FakeCopilotState();
            var handler = new SquadronStartupHandler(state);
            var journal = new JournalSquadronStartup { SquadronName = "UNION COSMOS", CurrentRank = 2 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Same(journal, state.Squadron);
        }

        [Fact]
        public async Task Statistics_StoresStatisticsInState()
        {
            var state = new FakeCopilotState();
            var handler = new StatisticsHandler(state);
            var journal = new JournalStatistics();

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Same(journal, state.JournalStatistics);
        }

        [Fact]
        public async Task Location_UpdatesSystem()
        {
            var state = new FakeCopilotState();
            var handler = new LocationHandler(state);
            var journal = new JournalLocation { StarSystem = "Wolf 397", SystemAddress = 3107576681170 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal("Wolf 397", state.StarSystem);
            Assert.Equal(3107576681170, state.SystemAddress);
        }

        [Fact]
        public async Task Docked_UpdatesStationAndSystem()
        {
            var state = new FakeCopilotState();
            var handler = new DockedHandler(state);
            var journal = new JournalDocked { StationName = "Lozino-Lozinskiy Mine", StarSystem = "Bakum" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal("Lozino-Lozinskiy Mine", state.StationName);
            Assert.Equal("Bakum", state.StarSystem);
        }

        [Fact]
        public async Task Undocked_ClearsStationName()
        {
            var state = new FakeCopilotState { StationName = "Lozino-Lozinskiy Mine" };
            var handler = new UndockedHandler(state);
            var journal = new JournalUndocked();

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal("", state.StationName);
        }

        [Fact]
        public async Task FSDJump_UpdatesStarSystem()
        {
            var state = new FakeCopilotState();
            var handler = new FSDJumpHandler(state);
            var journal = new JournalFSDJump { StarSystem = "Matire" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal("Matire", state.StarSystem);
        }

        [Fact]
        public async Task Materials_AssignsInventoryLists()
        {
            var state = new FakeCopilotState();
            var handler = new MaterialsHandler(state);
            var raw = new System.Collections.Generic.List<InventoryMaterialType>
            {
                new InventoryMaterialType { Name = "iron", Name_Localised = "Hierro", Count = 149 }
            };
            var journal = new JournalMaterials { Raw = raw, Encoded = null, Manufactured = null };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Same(raw, state.CategoriasInventario.Inventario.Raw);
        }

        [Fact]
        public async Task MaterialCollected_AddsPromptAndSpeaksAndUpdatesInventory()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            state.AddRawMaterial("iron", "Hierro", 10);
            var handler = new MaterialCollectedHandler(output, state);
            var journal = new JournalMaterialCollected { Name = "iron", Name_Localised = "Hierro", Count = 3 };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Inventory|", prompt);
            Assert.Contains("Material recogido Hierro (3) 13/300", prompt);
            var spoken = Assert.Single(output.Spoken);
            Assert.False(spoken.Npc);
        }

        [Fact]
        public async Task EngineerCraft_AddsPromptWithConsumedMaterials()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            state.AddRawMaterial("consumerfirmware", "Firmware de consumo modificado", 5);
            state.AddRawMaterial("selenium", "Selenio", 4);
            var handler = new EngineerCraftHandler(output, state);
            var journal = new JournalEngineerCraft
            {
                Ingredients = new System.Collections.Generic.List<IngredientType>
                {
                    new IngredientType { Name = "consumerfirmware", Name_Localised = "Firmware de consumo modificado", Count = 1 },
                    new IngredientType { Name = "selenium", Name_Localised = "Selenio", Count = 1 }
                }
            };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Inventory|", prompt);
            Assert.Contains("Material consumido Firmware de consumo modificado (1) 4/300 Selenio (1) 3/300", prompt);
            Assert.Empty(output.Spoken);
        }

        [Fact]
        public async Task MaterialTrade_AddsPromptPreservingPaidBug()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            state.AddRawMaterial("scanarchives", "Archivos de escáner no identificados", 102);
            state.AddRawMaterial("consumerfirmware", "Firmware de consumo modificado", 17);
            state.CategoriasInventario.Deltas = new System.Collections.Generic.Dictionary<string, int>
            {
                { "Firmware de consumo modificado", 0 }
            };
            var handler = new MaterialTradeHandler(output, state);
            var journal = new JournalMaterialTrade
            {
                Paid = new MaterialTradeDetailType { Material = "scanarchives", Material_Localised = "Archivos de escáner no identificados", Quantity = 102 },
                Received = new MaterialTradeDetailType { Material = "consumerfirmware", Material_Localised = "Firmware de consumo modificado", Quantity = 17 }
            };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Inventory|", prompt);
            Assert.Contains("Cambio 102 Archivos de escáner no identificados (0/300) por 17 Firmware de consumo modificado (17/300)", prompt);
            Assert.Empty(output.Spoken);
        }

        [Fact]
        public async Task MissionAccepted_AddsMissionToState()
        {
            var state = new FakeCopilotState();
            var handler = new MissionAcceptedHandler(state);
            var journal = new JournalMissionAccepted { MissionID = 947196382, LocalisedName = "Cajas negras" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.True(state.MissionAccepted.ContainsKey("947196382"));
            Assert.Same(journal, state.MissionAccepted["947196382"]);
        }

        [Fact]
        public async Task MissionAccepted_DoesNotDuplicateMission()
        {
            var state = new FakeCopilotState();
            var first = new JournalMissionAccepted { MissionID = 1 };
            var second = new JournalMissionAccepted { MissionID = 1 };
            var handler = new MissionAcceptedHandler(state);

            await handler.HandleAsync(first, CancellationToken.None);
            await handler.HandleAsync(second, CancellationToken.None);

            Assert.Single(state.MissionAccepted);
            Assert.Same(first, state.MissionAccepted["1"]);
        }

        [Fact]
        public async Task MissionCompleted_RemovesMissionAndPromptsWithRewards()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            state.AddRawMaterial("EmbeddedFirmware", "Firmware integrado modificado", 5);
            state.AddMissionAccepted("947196301", new JournalMissionAccepted { MissionID = 947196301 });
            var handler = new MissionCompletedHandler(output, state);
            var journal = new JournalMissionCompleted
            {
                MissionID = 947196301,
                Reward = 304528,
                MaterialsReward = new System.Collections.Generic.List<MaterialsRewardType>
                {
                    new MaterialsRewardType { Name = "EmbeddedFirmware", Name_Localised = "Firmware integrado modificado", Count = 5 }
                },
                CommodityReward = new System.Collections.Generic.List<CommodityRewardType>
                {
                    new CommodityRewardType { Name = "gold", Name_Localised = "Oro", Count = 10 }
                },
                FactionEffects = new System.Collections.Generic.List<FactionEffectType>
                {
                    new FactionEffectType
                    {
                        Faction = "Union Cosmos",
                        Influence = new System.Collections.Generic.List<InfluenceType>
                        {
                            new InfluenceType { SystemAddress = 672833021345, Trend = "UpGood", Influence = "++" }
                        },
                        Reputation = "++"
                    }
                }
            };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.False(state.MissionAccepted.ContainsKey("947196301"));
            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Misión completa recibidos 304528 créditos, 5 Firmware integrado modificado (10/300), 10 Oro", spoken.Text);
            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("MissionCompleted|", prompt);
            Assert.Contains("Misión completa recibidos 304528 créditos, 5 Firmware integrado modificado (10/300), 10 Oro", prompt);
            Assert.Contains("Union Cosmos", prompt);
            Assert.Contains("INFLUENCIA 2", prompt);
            Assert.Contains("REPUTACION 2", prompt);
        }

        [Fact]
        public async Task MissionAbandoned_RemovesMissionFromState()
        {
            var state = new FakeCopilotState();
            state.AddMissionAccepted("901234567", new JournalMissionAccepted { MissionID = 901234567 });
            var handler = new MissionAbandonedHandler(state);
            var journal = new JournalMissionAbandoned { MissionID = 901234567 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.False(state.MissionAccepted.ContainsKey("901234567"));
        }

        [Fact]
        public async Task ColonisationConstructionDepot_UpsertsProgress()
        {
            var state = new FakeCopilotState();
            var handler = new ColonisationConstructionDepotHandler(state);
            var first = new JournalColonisationConstructionDepot { MarketID = 3961417474, ConstructionProgress = 0.719192 };
            var second = new JournalColonisationConstructionDepot { MarketID = 3961417474, ConstructionProgress = 0.9 };

            await handler.HandleAsync(first, CancellationToken.None);
            await handler.HandleAsync(second, CancellationToken.None);

            Assert.Single(state.ColonisationProgress);
            Assert.Same(second, state.ColonisationProgress[3961417474m]);
        }

        [Fact]
        public async Task Dispatch_RoutesPowerplayRankEventToHandler()
        {
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new PowerplayRankHandler(state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"PowerplayRank\",\"Power\":\"Jerome Archer\",\"Rank\":5}");

            await dispatcher.DispatchAsync(journal);

            Assert.NotNull(state.JournalPowerRank);
            Assert.Equal(5, state.JournalPowerRank.Rank);
        }

        [Fact]
        public async Task Dispatch_RoutesMaterialCollectedEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            state.AddRawMaterial("shieldsoakanalysis", "Análisis de absorción de escudos inconsistente", 5);
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new MaterialCollectedHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"MaterialCollected\",\"Category\":\"Encoded\",\"Name\":\"shieldsoakanalysis\",\"Name_Localised\":\"Análisis de absorción de escudos inconsistente\",\"Count\":3}");

            await dispatcher.DispatchAsync(journal);

            var prompt = Assert.Single(output.Prompts);
            Assert.Contains("Material recogido", prompt);
        }

        [Fact]
        public async Task Dispatch_RoutesMissionAcceptedEventToHandler()
        {
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new MissionAcceptedHandler(state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"MissionAccepted\",\"MissionID\":947196382,\"LocalisedName\":\"Cajas negras\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.True(state.MissionAccepted.ContainsKey("947196382"));
        }
    }
}
