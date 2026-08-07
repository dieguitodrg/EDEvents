using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "Bounty").
    /// </summary>
    public class BountyHandler : JournalHandler<JournalBounty>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public BountyHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "Bounty";

        public override Task HandleAsync(JournalBounty journal, CancellationToken cancellationToken)
        {
            _state.Counters.Total++;
            _state.Counters.Combat++;
            DateTime kill = DateTime.Now;
            TimeSpan delta = kill - _state.LastKill;
            _state.LastKill = kill;
            String target = journal.Target_Localised != null ? journal.Target_Localised : journal.Target;
            String vf = journal.VictimFaction_Localised != null ? journal.VictimFaction_Localised : journal.VictimFaction;

            String pilotname = "";
            String modelo = "";

            Console.WriteLine($"{_state.FaccionObjetivo} {vf}");

            if (_state.FaccionObjetivo != null && vf != null && vf.ToUpper() == _state.FaccionObjetivo.ToUpper()) _state.Counters.Faction++;

            if (_state.FactionVictims.ContainsKey(vf))
            {
                int _t = _state.FactionVictims[vf];
                _t++;
                _state.FactionVictims[vf] = _t;
            }
            else
            {
                _state.FactionVictims.Add(vf, 1);
            }

            _state.Promptmfd = $"BC {target} {journal.TotalReward}CR {vf}";

            pilotname = journal.PilotName_Localised != "" ? journal.PilotName_Localised : journal.PilotName;
            modelo = journal.Target;

            String speakmessage = $"Recompensa de {journal.TotalReward} créditos por la destrucción de {pilotname}, modelo {modelo} de {vf}";
            String promptmessage = $"{delta} " + speakmessage + $" ({_state.Counters.Combat}-{_state.Counters.Faction}-{_state.Counters.Total})";

            _output.DisplayPage();

            _output.AddPrompt(promptmessage, PromptType.Combat);

            _output.Speak(speakmessage);

            _state.EventMarked = null;

            return Task.CompletedTask;
        }
    }
}
