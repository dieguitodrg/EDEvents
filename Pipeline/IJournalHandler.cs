using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Handler tipado para un evento del journal. Registrado en
    /// <see cref="JournalEventDispatcher"/> por nombre de evento.
    /// </summary>
    public interface IJournalHandler
    {
        string EventName { get; }

        Task HandleAsync(JournalBase journal, CancellationToken cancellationToken);
    }
}
