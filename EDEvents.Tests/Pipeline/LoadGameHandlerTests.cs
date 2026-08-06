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
            var handler = new LoadGameHandler(output);
            var journal = new JournalLoadGame { Commander = "Test" };

            await handler.HandleAsync(journal, CancellationToken.None);

            Assert.Equal(3, output.Prompts.Count);
            Assert.Contains("Juego Nuevo", output.Prompts[0]);
            Assert.Contains("Juego Nuevo", output.Prompts[1]);
            Assert.Contains("Juego Nuevo", output.Prompts[2]);
        }

        [Fact]
        public async Task Dispatch_LoadGameEvent_ReachesRegisteredHandler()
        {
            var output = new FakeCopilotOutput();
            var dispatcher = new JournalEventDispatcher();
            dispatcher.Register(new LoadGameHandler(output));

            var journal = EDCrew.Reader.ReadJson(
                "{\"timestamp\":\"2026-08-06T12:00:00Z\",\"event\":\"LoadGame\",\"Commander\":\"Test\"}");

            await dispatcher.DispatchAsync(journal);

            Assert.Equal(3, output.Prompts.Count);
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
