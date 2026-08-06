using System;
using System.Threading;
using System.Threading.Tasks;
using EDCrew.Pipeline;
using EDCrew.Pipeline.Handlers;
using Xunit;

namespace EDCrew.Tests.Pipeline
{
    public class OutputHandlersTests
    {
        [Fact]
        public async Task PowerplayCollect_AddsMeritsPrompt()
        {
            var output = new FakeCopilotOutput();
            var handler = new PowerplayCollectHandler(output);
            var journal = new JournalPowerplayCollect
            {
                timestamp = new DateTime(2026, 8, 6, 12, 0, 0),
                Power = "Aisling Duval",
                Type_Localised = "Manifestos de consolidación",
                Count = 15
            };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Merits|", prompt);
            Assert.Contains("Recogidos 15 Manifestos de consolidación para Aisling Duval", prompt);
        }

        [Fact]
        public async Task CollectCargo_AddsPromptAndSpeaksRecuperada()
        {
            var output = new FakeCopilotOutput();
            var handler = new CollectCargoHandler(output);
            var journal = new JournalCollectCargo { Type = "USSCargoBlackBox", Type_Localised = "Cajas negras", Stolen = false };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Inventory|", prompt);
            Assert.Contains("Mercancía Cajas negras recuperada", prompt);
            var spoken = Assert.Single(output.Spoken);
            Assert.Equal("Mercancía Cajas negras recuperada", spoken.Text);
            Assert.False(spoken.Npc);
        }

        [Fact]
        public async Task CollectCargo_Stolen_AddsRobada()
        {
            var output = new FakeCopilotOutput();
            var handler = new CollectCargoHandler(output);
            var journal = new JournalCollectCargo { Type = "gold", Type_Localised = null, Stolen = true };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Contains("Mercancía gold robada", output.Prompts[0]);
        }

        [Fact]
        public async Task EjectCargo_AddsPromptAndSpeaksAbandonada()
        {
            var output = new FakeCopilotOutput();
            var handler = new EjectCargoHandler(output);
            var journal = new JournalEjectCargo { Count = 12, Type = "gold", Type_Localised = "Oro", Abandoned = true };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Inventory|", prompt);
            Assert.Contains("Mercancía 12 Oro abandonada", prompt);
            var spoken = Assert.Single(output.Spoken);
            Assert.False(spoken.Npc);
        }

        [Fact]
        public async Task DockingGranted_AddsNavigationPromptAndSpeaks()
        {
            var output = new FakeCopilotOutput();
            var handler = new DockingGrantedHandler(output);
            var journal = new JournalDockingGranted { StationName = "Henderson's Inheritance", LandingPad = 3 };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Navigation|", prompt);
            Assert.Contains("Henderson's Inheritance", prompt);
            Assert.Contains("Plataforma 3", prompt);
            var spoken = Assert.Single(output.Spoken);
            Assert.False(spoken.Npc);
        }

        [Fact]
        public async Task DockingGranted_ReplacesColonisationShipToken()
        {
            var output = new FakeCopilotOutput();
            var handler = new DockingGrantedHandler(output);
            var journal = new JournalDockingGranted { StationName = "$EXT_PANEL_ColonisationShip;", LandingPad = 1 };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Contains("Nave de Colonización del Sistema", output.Prompts[0]);
        }

        [Fact]
        public async Task StartJump_Hyperspace_AddsNavigationPromptAndSpeaks()
        {
            var output = new FakeCopilotOutput();
            var handler = new StartJumpHandler(output);
            var journal = new JournalStartJump { JumpType = "Hyperspace", StarSystem = "Sol", StarClass = "G" };

            await handler.HandleAsync(journal, CancellationToken.None);

            var prompt = Assert.Single(output.Prompts);
            Assert.StartsWith("Navigation|", prompt);
            Assert.Contains("Saltando a Sol clase espectral G", prompt);
            Assert.Single(output.Spoken);
        }

        [Fact]
        public async Task StartJump_Supercruise_ProducesNoOutput()
        {
            var output = new FakeCopilotOutput();
            var handler = new StartJumpHandler(output);
            var journal = new JournalStartJump { JumpType = "Supercruise" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Empty(output.Prompts);
            Assert.Empty(output.Spoken);
        }

        [Fact]
        public async Task Dispatch_RoutesCollectCargoEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new CollectCargoHandler(output));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"CollectCargo\",\"Type\":\"gold\",\"Type_Localised\":\"Oro\",\"Stolen\":false}");

            await dispatcher.DispatchAsync(journal);

            var prompt = Assert.Single(output.Prompts);
            Assert.Contains("Oro", prompt);
        }

        [Fact]
        public async Task Dispatch_RoutesStartJumpEventToHandler()
        {
            var output = new FakeCopilotOutput();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new StartJumpHandler(output));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"StartJump\",\"JumpType\":\"Hyperspace\",\"StarSystem\":\"Sol\",\"StarClass\":\"G\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Contains("Saltando a Sol clase espectral G", Assert.Single(output.Prompts));
        }
    }
}
