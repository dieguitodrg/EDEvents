using System;
using System.Collections.Generic;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Estado compartido del copiloto al que acceden los handlers del journal.
    /// Form1 lo implementa; los tests usan dobles.
    /// </summary>
    public interface ICopilotState
    {
        Counters Counters { get; }

        CategoriasInventario CategoriasInventario { get; }

        string StarSystem { get; set; }

        Int64 SystemAddress { get; set; }

        string StationName { get; set; }

        JournalPowerplayRank JournalPowerRank { get; set; }

        JournalPowerplayMerits JournalPowerMerits { get; set; }

        JournalStatistics JournalStatistics { get; set; }

        JournalSquadronStartup Squadron { get; set; }

        Dictionary<string, JournalMissionAccepted> MissionAccepted { get; }

        Dictionary<decimal, JournalColonisationConstructionDepot> ColonisationProgress { get; }

        void AddMissionAccepted(string key, JournalMissionAccepted mission);

        void RemoveMissionAccepted(string key);
    }
}
