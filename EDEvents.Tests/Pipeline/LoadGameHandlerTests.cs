using System;
using System.Threading;
using System.Threading.Tasks;
using EDCrew.Pipeline;
using EDCrew.Pipeline.Handlers;
using Xunit;

namespace EDCrew.Tests.Pipeline
{
    public class LoadGameHandlerTests
    {
        [Fact]
        public async Task HandleAsync_AddsNewGameHeaderToThreePrompts()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var handler = new LoadGameHandler(output, state);
            var journal = new JournalLoadGame { Commander = "Test", ShipIdent = "ABC-123" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal(3, output.Prompts.Count);
            Assert.Contains("Juego Nuevo", output.Prompts[0]);
            Assert.Contains("Juego Nuevo", output.Prompts[1]);
            Assert.Contains("Juego Nuevo", output.Prompts[2]);
        }

        [Fact]
        public async Task HandleAsync_SetsCommanderAndShipIdentInState()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var handler = new LoadGameHandler(output, state);
            var journal = new JournalLoadGame { Commander = "Test", ShipIdent = "ABC-123" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal("Test", state.Commander);
            Assert.Equal("ABC-123", state.ShipIdent);
        }

        [Fact]
        public async Task Dispatch_LoadGameEvent_ReachesRegisteredHandler()
        {
            var output = new FakeCopilotOutput();
            var state = new FakeCopilotState();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new LoadGameHandler(output, state));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"LoadGame\",\"Commander\":\"Test\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Equal(3, output.Prompts.Count);
            Assert.Equal("Test", state.Commander);
        }

        [Fact]
        public async Task Dispatch_UnregisteredEvent_IsIgnored()
        {
            var output = new FakeCopilotOutput();
            var dispatcher = new JournalEventDispatcher();

            await dispatcher.DispatchAsync(new JournalBase { @event = "Missions" });

            Assert.Empty(output.Prompts);
        }
    }
}
