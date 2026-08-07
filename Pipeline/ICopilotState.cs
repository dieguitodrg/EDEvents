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

        string Commander { get; set; }

        string Ship { get; set; }

        string ShipName { get; set; }

        string ShipIdent { get; set; }

        int ShipId { get; set; }

        List<JournalFSSBodySignals> BodySignals { get; }

        Int64 OldSystemAddress { get; set; }

        JournalShipTargeted EventScannedShip { get; set; }

        JournalShipTargeted EventMarked { get; set; }

        bool StatusScanned { get; set; }

        string Promptmfd { get; set; }

        string Bountyprompt { get; set; }

        DateTime LastKill { get; set; }

        Dictionary<string, int> FactionVictims { get; }

        string FaccionObjetivo { get; set; }

        bool SpeakNpc { get; }

        bool SpeakSystem { get; }

        bool FetchingSubsystem { get; set; }

        string Subsystem { get; set; }

        void AddMissionAccepted(string key, JournalMissionAccepted mission);

        void RemoveMissionAccepted(string key);

        void AddScanned(string key, bool value);

        void AddDictionaryScanned(string systemAddress, string body, string speciesLocalised, bool analysed);
    }
}
