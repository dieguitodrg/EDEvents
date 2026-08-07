using System.Threading;
using System.Threading.Tasks;
using EDCrew;
using EDCrew.Pipeline;
using EDCrew.Pipeline.Handlers;
using Xunit;

namespace EDCrew.Tests.Pipeline
{
    public class MigratedHandlersTests
    {
        [Fact]
        public async Task FSSBodySignals_AddsSignalToState()
        {
            var state = new FakeCopilotState();
            var handler = new FSSBodySignalsHandler(state);
            var journal = new JournalFSSBodySignals { BodyName = "Synuefe GT-H b43-1 1", SystemAddress = 223245345 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal(223245345, state.SystemAddress);
            Assert.Equal(223245345, state.OldSystemAddress);
            Assert.Single(state.BodySignals);
            Assert.Same(journal, state.BodySignals[0]);
        }

        [Fact]
        public async Task FSSBodySignals_ClearsSignalsWhenSystemChanges()
        {
            var state = new FakeCopilotState();
            state.OldSystemAddress = 223245345;
            state.BodySignals.Add(new JournalFSSBodySignals { BodyName = "A", SystemAddress = 223245345 });
            var handler = new FSSBodySignalsHandler(state);
            var journal = new JournalFSSBodySignals { BodyName = "B", SystemAddress = 99999 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Single(state.BodySignals);
            Assert.Same(journal, state.BodySignals[0]);
        }

        [Fact]
        public async Task Dispatch_RoutesFSSBodySignalsEventToHandler()
        {
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new FSSBodySignalsHandler(state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"FSSBodySignals\",\"BodyName\":\"Synuefe GT-H b43-1 1\",\"BodyID\":1,\"SystemAddress\":223245345,\"Signals\":[{\"Type\":\"$SAA_SignalType_Biological;\",\"Type_Localised\":\"Biológico\",\"Count\":3}]}");

            await dispatcher.DispatchAsync(journal);

            Assert.Single(state.BodySignals);
        }

        [Fact]
        public async Task ScanOrganic_AnalyseRegistersTrue()
        {
            var state = new FakeCopilotState();
            var handler = new ScanOrganicHandler(state);
            var journal = new JournalScanOrganic { SystemAddress = 223245345, BodyID = 7, Species_Localised = "Stratum cucumisis", ScanType = "Analyse" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.True(state.DictionaryScanned["223245345"]["7_Stratum cucumisis"]);
        }

        [Fact]
        public async Task ScanOrganic_LogRegistersFalse()
        {
            var state = new FakeCopilotState();
            var handler = new ScanOrganicHandler(state);
            var journal = new JournalScanOrganic { SystemAddress = 223245345, BodyID = 7, Species_Localised = "Stratum cucumisis", ScanType = "Log" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.False(state.DictionaryScanned["223245345"]["7_Stratum cucumisis"]);
        }

        [Fact]
        public async Task Dispatch_RoutesScanOrganicEventToHandler()
        {
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new ScanOrganicHandler(state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"ScanOrganic\",\"ScanType\":\"Analyse\",\"Species_Localised\":\"Stratum cucumisis\",\"SystemAddress\":223245345,\"Body\":7,\"BodyID\":7}");

            await dispatcher.DispatchAsync(journal);

            Assert.True(state.DictionaryScanned["223245345"]["7_Stratum cucumisis"]);
        }

        [Fact]
        public async Task ShipTargeted_FullScanSetsBountyPromptAndState()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var handler = new ShipTargetedHandler(output, state);
            var journal = new JournalShipTargeted { ScanStage = 3, Bounty = 5000, LegalStatus = "Wanted" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.True(state.StatusScanned);
            Assert.Same(journal, state.EventScannedShip);
            Assert.Equal("Recompensa de 5000 créditos", state.Bountyprompt);
            Assert.Equal(1, output.DisplayPageCalls);
        }

        [Fact]
        public async Task ShipTargeted_PartialScanResetsState()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { EventScannedShip = new JournalShipTargeted(), StatusScanned = true };
            var handler = new ShipTargetedHandler(output, state);
            var journal = new JournalShipTargeted { ScanStage = 1 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Null(state.EventScannedShip);
            Assert.False(state.StatusScanned);
            Assert.Equal(0, output.DisplayPageCalls);
        }

        [Fact]
        public async Task ShipTargeted_FetchingSubsystemContinuesCycles()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { FetchingSubsystem = true, Subsystem = "Power Plant" };
            var handler = new ShipTargetedHandler(output, state);
            var journal = new JournalShipTargeted { ScanStage = 3, Bounty = 0, Subsystem_Localised = null };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.True(state.FetchingSubsystem);
            var command = Assert.Single(output.Commands);
            Assert.Equal("Anterior Subsistema", command.Command);
            Assert.False(command.Voice);
        }

        [Fact]
        public async Task ShipTargeted_FoundSubsystemStopsFetching()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { FetchingSubsystem = true, Subsystem = null };
            var handler = new ShipTargetedHandler(output, state);
            var journal = new JournalShipTargeted { ScanStage = 3, Bounty = 0, Subsystem_Localised = null };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.False(state.FetchingSubsystem);
            Assert.Empty(output.Commands);
        }

        [Fact]
        public async Task Dispatch_RoutesShipTargetedEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new ShipTargetedHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"ShipTargeted\",\"TargetLocked\":true,\"Ship\":\"empire_fighter\",\"Ship_Localised\":\"Gu-97\",\"ScanStage\":3,\"PilotName\":\"$ShipName_Police_Empire;\",\"PilotRank\":\"Expert\",\"Faction\":\"6th Interstellar Corps\",\"LegalStatus\":\"Clean\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.True(state.StatusScanned);
            Assert.NotNull(state.EventScannedShip);
        }

        [Fact]
        public async Task Loadout_SetsShipAndSpeaksWithNato()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var handler = new LoadoutHandler(output, state);
            var journal = new JournalLoadout { Ship = "python", ShipName = "Banshee", ShipIdent = "ABC-123", ShipID = 7, StarSystem = "Wolf 397" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal("Banshee", state.ShipName);
            Assert.Equal("ABC-123", state.ShipIdent);
            Assert.Equal(7, state.ShipId);
            Assert.Equal("python", state.Ship);
            Assert.Equal("Wolf 397", state.StarSystem);
            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Bienvenido a NATO-ABC-123 Banshee Comandante", spoken.Text);
            var prompt = Assert.Single(output.Prompts);
            Assert.Contains("Bienvenido a ABC-123 Banshee", prompt);
        }

        [Fact]
        public async Task Loadout_SameShipDoesNotRepeat()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { ShipName = "Banshee" };
            var handler = new LoadoutHandler(output, state);
            var journal = new JournalLoadout { Ship = "python", ShipName = "Banshee", ShipIdent = "ABC-123", ShipID = 7, StarSystem = "Wolf 397" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Empty(output.Prompts);
            Assert.Empty(output.Spoken);
        }

        [Fact]
        public async Task Dispatch_RoutesLoadoutEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new LoadoutHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"Loadout\",\"Ship\":\"python\",\"ShipName\":\"Banshee\",\"ShipIdent\":\"ABC-123\",\"ShipID\":7,\"StarSystem\":\"Wolf 397\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Equal("Banshee", state.ShipName);
            Assert.Equal("ABC-123", state.ShipIdent);
        }

        [Fact]
        public async Task ReceiveText_FormatsMessageAndSpeaksWithNpc()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { SpeakNpc = true };
            var handler = new ReceiveTextHandler(output, state);
            var journal = new JournalReceiveText { Channel = "npc", From = "$Name_AX_Military;", Message = "Solicitando asistencia" };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.Contains("Mensaje Recibido de Piloto AX: Solicitando asistencia", prompt);
            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Mensaje Recibido de Piloto AX: Solicitando asistencia", spoken.Text);
            Assert.True(spoken.Npc);
        }

        [Fact]
        public async Task ReceiveText_SkipsSpeakWhenNpcFiltered()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { SpeakNpc = false };
            var handler = new ReceiveTextHandler(output, state);
            var journal = new JournalReceiveText { Channel = "npc", From = "NPC", Message = "Hola" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Single(output.Prompts);
            Assert.Empty(output.Spoken);
        }

        [Fact]
        public async Task ReceiveText_SkipsCommsEnteredMessage()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var handler = new ReceiveTextHandler(output, state);
            var journal = new JournalReceiveText { Channel = "npc", From = "NPC", Message = "$COMMS_entered..." };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Empty(output.Prompts);
            Assert.Empty(output.Spoken);
        }

        [Fact]
        public async Task Dispatch_RoutesReceiveTextEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new ReceiveTextHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"ReceiveText\",\"Channel\":\"npc\",\"From\":\"$Name_AX_Military;\",\"Message\":\"Solicitando asistencia\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Single(output.Prompts);
        }

        [Fact]
        public async Task FactionKillBond_IncrementsCountersAndFactionVictims()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { FaccionObjetivo = "Union Cosmos" };
            var handler = new FactionKillBondHandler(output, state);
            var journal = new JournalFactionKillBond { AwardingFaction = "Federation", VictimFaction = "Union Cosmos", Reward = 5000 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal(1, state.Counters.Combat);
            Assert.Equal(1, state.Counters.Total);
            Assert.Equal(1, state.Counters.Faction);
            Assert.Equal(1, state.FactionVictims["Union Cosmos"]);
            Assert.Equal("FKB 5000 Union Cosmos", state.Promptmfd);
            Assert.Equal(1, output.DisplayPageCalls);
            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Federation Bono de combate de 5000 créditos por destruir Union Cosmos", spoken.Text);
        }

        [Fact]
        public async Task FactionKillBond_UsesEventMarkedPilot()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState
            {
                FaccionObjetivo = "Union Cosmos",
                EventMarked = new JournalShipTargeted { PilotName = "$npc;", PilotName_Localised = "Piloto Pirata", Ship = "empire_fighter", Ship_Localised = "Gu-97" }
            };
            var handler = new FactionKillBondHandler(output, state);
            var journal = new JournalFactionKillBond { AwardingFaction = "Federation", VictimFaction = "Union Cosmos", Reward = 5000 };

            await handler.HandleAsync(journal, CancellationToken.None);

            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Federation Bono de combate de 5000 créditos por destruir a Piloto Pirata, modelo Gu-97 de Union Cosmos", spoken.Text);
            Assert.Null(state.EventMarked);
        }

        [Fact]
        public async Task Dispatch_RoutesFactionKillBondEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new FactionKillBondHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"FactionKillBond\",\"Reward\":29967,\"AwardingFaction\":\"Union Cosmos\",\"VictimFaction\":\"Movement for Pini Liberals\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Equal(1, state.Counters.Combat);
            Assert.Equal(1, state.FactionVictims["Movement for Pini Liberals"]);
        }

        [Fact]
        public async Task Bounty_IncrementsCountersAndSpeaks()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState { FaccionObjetivo = "HIP 18713 Jet Society" };
            var handler = new BountyHandler(output, state);
            var journal = new JournalBounty
            {
                PilotName = "$npc_name_decorate:#name=Malark;",
                PilotName_Localised = "Malark",
                Target = "ferdelance",
                Target_Localised = "Fer-de-Lance",
                TotalReward = 5000,
                VictimFaction = "HIP 18713 Jet Society"
            };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal(1, state.Counters.Combat);
            Assert.Equal(1, state.Counters.Total);
            Assert.Equal(1, state.Counters.Faction);
            Assert.Equal(1, state.FactionVictims["HIP 18713 Jet Society"]);
            Assert.Equal("BC Fer-de-Lance 5000CR HIP 18713 Jet Society", state.Promptmfd);
            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Recompensa de 5000 créditos por la destrucción de Malark, modelo ferdelance de HIP 18713 Jet Society", spoken.Text);
        }

        [Fact]
        public async Task Dispatch_RoutesBountyEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new BountyHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"Bounty\",\"PilotName\":\"$npc_name_decorate:#name=Malark;\",\"PilotName_Localised\":\"Malark\",\"Target\":\"ferdelance\",\"Target_Localised\":\"Fer-de-Lance\",\"TotalReward\":1122556,\"VictimFaction\":\"HIP 18713 Jet Society\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Equal(1, state.Counters.Combat);
            Assert.Equal(1, state.FactionVictims["HIP 18713 Jet Society"]);
        }
    }
}
