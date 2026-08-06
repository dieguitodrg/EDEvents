using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Base para handlers tipados. El dispatcher invoca el cast seguro:
    /// si el journal deserializado no coincide con el tipo esperado, se ignora.
    /// </summary>
    public abstract class JournalHandler<TEvent> : IJournalHandler
        where TEvent : JournalBase
    {
        public abstract string EventName { get; }

        Task IJournalHandler.HandleAsync(JournalBase journal, CancellationToken cancellationToken)
        {
            return journal is TEvent typed
                ? HandleAsync(typed, cancellationToken)
                : Task.CompletedTask;
        }

        public abstract Task HandleAsync(TEvent journal, CancellationToken cancellationToken);
    }
}
