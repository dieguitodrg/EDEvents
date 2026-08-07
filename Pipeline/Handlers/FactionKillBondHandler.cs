using System;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "FactionKillBond").
    /// </summary>
    public class FactionKillBondHandler : JournalHandler<JournalFactionKillBond>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public FactionKillBondHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "FactionKillBond";

        public override Task HandleAsync(JournalFactionKillBond journal, CancellationToken cancellationToken)
        {
            DateTime kill = DateTime.Now;
            TimeSpan delta = kill - _state.LastKill;
            _state.LastKill = kill;

            _state.Counters.Combat++;
            _state.Counters.Total++;

            String af = journal.AwardingFaction_Localised != null ? journal.AwardingFaction_Localised : journal.AwardingFaction;
            String vf = journal.VictimFaction_Localised != null ? journal.VictimFaction_Localised : journal.VictimFaction;

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

            String pilotname = "";
            String modelo = "";

            String speakmessage = $"{af} Bono de combate de {journal.Reward} créditos por destruir {vf}";
            String promptmessage = $"{delta} " + speakmessage + $" ({_state.Counters.Combat}-{_state.Counters.Faction}-{_state.Counters.Total})";
            _state.Promptmfd = $"FKB {journal.Reward} {vf}";

            if (_state.EventMarked != null)
            {
                pilotname = _state.EventMarked.PilotName_Localised != "" ? _state.EventMarked.PilotName_Localised : _state.EventMarked.PilotName;
                modelo = _state.EventMarked.Ship_Localised != null ? _state.EventMarked.Ship_Localised : _state.EventMarked.Ship;
                speakmessage = $"{af} Bono de combate de {journal.Reward} créditos por destruir a {pilotname}, modelo {modelo} de {vf}";
                promptmessage = $"{delta} " + speakmessage + $" ({_state.Counters.Combat}-{_state.Counters.Faction}-{_state.Counters.Total})";
            }

            _output.DisplayPage();

            _output.AddPrompt(promptmessage, PromptType.Combat);
            _output.Speak(speakmessage);

            _state.EventMarked = null;

            return Task.CompletedTask;
        }
    }
}
