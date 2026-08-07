using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDCrew.Pipeline.Handlers
{
    /// <summary>
    /// Migrado del switch de Form1 (case "MissionCompleted").
    /// </summary>
    public class MissionCompletedHandler : JournalHandler<JournalMissionCompleted>
    {
        private readonly ICopilotOutput _output;
        private readonly ICopilotState _state;

        public MissionCompletedHandler(ICopilotOutput output, ICopilotState state)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public override string EventName => "MissionCompleted";

        public override Task HandleAsync(JournalMissionCompleted journal, CancellationToken cancellationToken)
        {
            long mid = journal.MissionID;

            if (_state.MissionAccepted.ContainsKey(mid.ToString()))
            {
                _state.RemoveMissionAccepted(mid.ToString());
            }

            StringBuilder result = new StringBuilder($"Misión completa recibidos {journal.Reward} créditos");
            if (journal.MaterialsReward != null)
            {
                foreach (MaterialsRewardType r in journal.MaterialsReward)
                {
                    string material = r.Name_Localised != null ? r.Name_Localised : r.Name;

                    int inventario = _state.CategoriasInventario.Suma(material, r.Count);
                    int maximo = _state.CategoriasInventario.Maximo(material);
                    int delta = _state.CategoriasInventario.Deltas[material];

                    result.Append($", {r.Count} {material} ({inventario}/{maximo})");
                }
            }

            if (journal.CommodityReward != null)
            {
                foreach (CommodityRewardType r in journal.CommodityReward)
                {
                    string commodity = r.Name_Localised != null ? r.Name_Localised : r.Name;

                    result.Append($", {r.Count} {commodity}");
                }
            }

            _output.Speak(result.ToString());

            if (journal.FactionEffects != null)
            {
                foreach (var item in journal.FactionEffects)
                {
                    result.Append(" ");
                    result.Append(item.Faction);

                    if (item.Influence != null)
                    {
                        result.Append(", INFLUENCIA ");

                        foreach (var item2 in item.Influence)
                        {
                            result.Append(item2.Influence.Length);
                        }
                    }

                    if (item.Reputation != null)
                    {
                        result.Append(", REPUTACION ");
                        result.Append(item.Reputation.Length);
                    }
                }
            }

            _output.AddPrompt(result.ToString(), PromptType.MissionCompleted);
            return Task.CompletedTask;
        }
    }
}
