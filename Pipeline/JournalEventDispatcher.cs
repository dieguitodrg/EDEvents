using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Registra handlers por nombre de evento del journal y despacha los
    /// eventos ya deserializados. Sustituirá progresivamente el switch de
    /// Form1.ProcessFile.
    /// </summary>
    public class JournalEventDispatcher
    {
        private readonly Dictionary<string, IJournalHandler> _handlers =
            new Dictionary<string, IJournalHandler>(StringComparer.OrdinalIgnoreCase);

        public void Register(IJournalHandler handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            _handlers[handler.EventName] = handler;
        }

        public bool HasHandler(string eventName)
        {
            return !string.IsNullOrEmpty(eventName) && _handlers.ContainsKey(eventName);
        }

        public async Task DispatchAsync(JournalBase journal, CancellationToken cancellationToken = default)
        {
            if (journal == null || string.IsNullOrEmpty(journal.@event)) return;

            if (_handlers.TryGetValue(journal.@event, out IJournalHandler handler))
            {
                await handler.HandleAsync(journal, cancellationToken);
            }
        }
    }
}
