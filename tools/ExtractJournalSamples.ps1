# Cosecha de samples JSON reales desde los journals del usuario.
# Para cada evento sin clase tipada, busca el primer ejemplo en los logs y
# lo guarda en tools/JournalSamples/<Evento>.json (si aun no existe).
# Imprime al final la lista de eventos SIN sample (para fabricar de la doc).

param(
    [string]$LogDir = "$env:USERPROFILE\Saved Games\Frontier Developments\Elite Dangerous"
)

$Missing = @(
    "Statistics", "DockingCancelled", "DockingTimeout", "Liftoff", "Touchdown",
    "CapShipBond", "Died", "EscapeInterdiction", "HeatDamage", "PVPKill", "SRVDestroyed",
    "CodexEntry", "DiscoveryScan", "FSSAllBodiesFound", "MaterialDiscarded",
    "MaterialDiscovered", "MultiSellExplorationData", "BuyExplorationData",
    "SAAScanComplete", "SAASignalsFound", "SellExplorationData", "Screenshot",
    "AsteroidCracked", "BuyTradeData", "MiningRefined",
    "CommunityGoal", "CommunityGoalDiscard", "CommunityGoalJoin", "CommunityGoalReward",
    "CrewAssign", "CrewFire", "CrewHire", "EngineerApply", "EngineerContribution",
    "EngineerLegacyConvert", "FetchRemoteModule", "MassModuleStore", "ModuleSellRemote",
    "ModuleSwap", "RefuelPartial", "Repair", "RestockVehicle", "ScientificResearch",
    "SellShipOnRebuy", "SetUserShipName", "ShipyardBuy", "ShipyardNew", "ShipyardSell",
    "TechnologyBroker", "ClearImpound",
    "PowerplayDefect", "PowerplayDeliver", "PowerplayFastTrack", "PowerplayJoin",
    "PowerplayLeave", "PowerplaySalary", "PowerplayVote", "PowerplayVoucher",
    "AppliedToSquadron", "DisbandedSquadron", "InvitedToSquadron", "JoinedSquadron",
    "KickedFromSquadron", "LeftSquadron", "SharedBookmarkToSquadron", "SquadronCreated",
    "SquadronDemotion", "SquadronPromotion", "WonATrophyForSquadron",
    "CarrierJump", "CarrierBuy", "CarrierDecommission", "CarrierCancelDecommission",
    "CarrierBankTransfer", "CarrierDepositFuel", "CarrierCrewServices", "CarrierFinance",
    "CarrierShipPack", "CarrierModulePack", "CarrierTradeOrder",
    "CarrierDockingPermission", "CarrierNameChanged", "CarrierJumpCancelled",
    "Backpack", "BackpackChange", "BookDropship", "BookTaxi", "BuyMicroResources",
    "BuySuit", "BuyWeapon", "CancelDropship", "CancelTaxi", "CollectItems",
    "CreateSuitLoadout", "DeleteSuitLoadout", "Disembark", "DropItems", "DropShipDeploy",
    "Embark", "FCMaterials", "LoadoutEquipModule", "LoadoutRemoveModule",
    "RenameSuitLoadout", "SellMicroResources", "SellOrganicData", "SellSuit", "SellWeapon",
    "SuitLoadout", "SwitchSuitLoadout", "TransferMicroResources", "TradeMicroResources",
    "UpgradeSuit", "UpgradeWeapon", "UseConsumable",
    "AfmuRepairs", "ChangeCrewRole", "CockpitBreached", "Continued", "CrewLaunchFighter",
    "CrewMemberJoins", "CrewMemberQuits", "CrewMemberRoleChange", "CrimeVictim",
    "DatalinkScan", "DatalinkVoucher", "DataScanned", "DockSRV", "EndCrewSession",
    "JetConeBoost", "JetConeDamage", "JoinACrew", "KickCrewMember", "LaunchSRV",
    "NpcCrewRank", "ProspectedAsteroid", "QuitACrew", "RebootRepair", "RepairDrone",
    "Resurrect", "SelfDestruct", "SendText", "Synthesis", "SystemsShutdown",
    "VehicleSwitch", "CargoTransfer"
)

$SamplesDir = Join-Path $PSScriptRoot "JournalSamples"
if (-not (Test-Path $SamplesDir)) { New-Item -ItemType Directory -Path $SamplesDir | Out-Null }

$logs = Get-ChildItem $LogDir -Filter "*.log" | Sort-Object Name
$found = @()
$notFound = @()

foreach ($ev in $Missing) {
    $out = Join-Path $SamplesDir "$ev.json"
    if (Test-Path $out) { $found += $ev; continue }
    $hit = $null
    foreach ($l in $logs) {
        $hit = Select-String -Path $l.FullName -Pattern ('"event":"' + $ev + '"') -SimpleMatch:$false | Select-Object -First 1
        if ($hit) { break }
    }
    if ($hit) {
        Set-Content -LiteralPath $out -Value ($hit.Line.Trim()) -Encoding UTF8
        $found += $ev
    } else {
        $notFound += $ev
    }
}

Write-Output "=== CON SAMPLE EN LOGS ($($found.Count)) ==="
$found | Sort-Object | ForEach-Object { Write-Output $_ }
Write-Output ""
Write-Output "=== SIN SAMPLE, FABRICAR DE LA DOC ($($notFound.Count)) ==="
$notFound | Sort-Object | ForEach-Object { Write-Output $_ }
