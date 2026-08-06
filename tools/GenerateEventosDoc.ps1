# Genera docs/eventos.md a partir del catalogo de la documentacion oficial
# (elite-journal.readthedocs.io) y de las clases Journal<Evento> existentes.

$RepoRoot = Split-Path -Parent $PSScriptRoot
$OutDir = Join-Path $RepoRoot "docs"
if (-not (Test-Path $OutDir)) { New-Item -ItemType Directory -Path $OutDir | Out-Null }
$OutFile = Join-Path $OutDir "eventos.md"

# Evento -> seccion (según elite-journal.readthedocs.io/en/latest/)
$Catalogue = [ordered]@{
    "Startup" = @("Cargo","ClearSavedGame","Commander","Loadout","Materials","Missions","NewCommander","LoadGame","Passengers","Powerplay","Progress","Rank","Reputation","Statistics")
    "Travel" = @("ApproachBody","Docked","DockingCancelled","DockingDenied","DockingGranted","DockingRequested","DockingTimeout","FSDJump","FSDTarget","LeaveBody","Liftoff","Location","StartJump","SupercruiseEntry","SupercruiseExit","Touchdown","Undocked","NavRouteClear")
    "Combat" = @("Bounty","CapShipBond","Died","EscapeInterdiction","FactionKillBond","FighterDestroyed","HeatDamage","HeatWarning","HullDamage","Interdicted","Interdiction","PVPKill","ShieldState","ShipTargeted","SRVDestroyed","UnderAttack")
    "Exploration" = @("CodexEntry","DiscoveryScan","Scan","FSSAllBodiesFound","FSSBodySignals","FSSDiscoveryScan","FSSSignalDiscovered","MaterialCollected","MaterialDiscarded","MaterialDiscovered","MultiSellExplorationData","NavBeaconScan","BuyExplorationData","SAAScanComplete","SAASignalsFound","ScanBaryCentre","SellExplorationData","Screenshot")
    "Trade" = @("AsteroidCracked","BuyTradeData","CollectCargo","EjectCargo","MarketBuy","MarketSell","MiningRefined")
    "StationServices" = @("BuyAmmo","BuyDrones","CargoDepot","CommunityGoal","CommunityGoalDiscard","CommunityGoalJoin","CommunityGoalReward","CrewAssign","CrewFire","CrewHire","EngineerApply","EngineerContribution","EngineerCraft","EngineerLegacyConvert","EngineerProgress","FetchRemoteModule","Market","MassModuleStore","MaterialTrade","MissionAbandoned","MissionAccepted","MissionCompleted","MissionFailed","MissionRedirected","ModuleBuy","ModuleRetrieve","ModuleSell","ModuleSellRemote","ModuleStore","ModuleSwap","Outfitting","PayBounties","PayFines","PayLegacyFines","RedeemVoucher","RefuelAll","RefuelPartial","Repair","RepairAll","RestockVehicle","ScientificResearch","SearchAndRescue","SellDrones","SellShipOnRebuy","SetUserShipName","Shipyard","ShipyardBuy","ShipyardNew","ShipyardSell","ShipyardTransfer","ShipyardSwap","StoredModules","StoredShips","TechnologyBroker","ClearImpound")
    "Powerplay" = @("PowerplayCollect","PowerplayDefect","PowerplayDeliver","PowerplayFastTrack","PowerplayJoin","PowerplayLeave","PowerplaySalary","PowerplayVote","PowerplayVoucher")
    "Squadrons" = @("AppliedToSquadron","DisbandedSquadron","InvitedToSquadron","JoinedSquadron","KickedFromSquadron","LeftSquadron","SharedBookmarkToSquadron","SquadronCreated","SquadronDemotion","SquadronPromotion","SquadronStartup","WonATrophyForSquadron")
    "FleetCarriers" = @("CarrierJump","CarrierBuy","CarrierStats","CarrierJumpRequest","CarrierDecommission","CarrierCancelDecommission","CarrierBankTransfer","CarrierDepositFuel","CarrierCrewServices","CarrierFinance","CarrierShipPack","CarrierModulePack","CarrierTradeOrder","CarrierDockingPermission","CarrierNameChanged","CarrierJumpCancelled")
    "Odyssey" = @("Backpack","BackpackChange","BookDropship","BookTaxi","BuyMicroResources","BuySuit","BuyWeapon","CancelDropship","CancelTaxi","CollectItems","CreateSuitLoadout","DeleteSuitLoadout","Disembark","DropItems","DropShipDeploy","Embark","FCMaterials","LoadoutEquipModule","LoadoutRemoveModule","RenameSuitLoadout","ScanOrganic","SellMicroResources","SellOrganicData","SellSuit","SellWeapon","ShipLocker","SuitLoadout","SwitchSuitLoadout","TransferMicroResources","TradeMicroResources","UpgradeSuit","UpgradeWeapon","UseConsumable")
    "Other" = @("AfmuRepairs","ApproachSettlement","ChangeCrewRole","CockpitBreached","CommitCrime","Continued","CrewLaunchFighter","CrewMemberJoins","CrewMemberQuits","CrewMemberRoleChange","CrimeVictim","DatalinkScan","DatalinkVoucher","DataScanned","DockFighter","DockSRV","EndCrewSession","FighterRebuilt","FuelScoop","Friends","JetConeBoost","JetConeDamage","JoinACrew","KickCrewMember","LaunchDrone","LaunchFighter","LaunchSRV","ModuleInfo","Music","NpcCrewPaidWage","NpcCrewRank","Promotion","ProspectedAsteroid","QuitACrew","RebootRepair","ReceiveText","RepairDrone","ReservoirReplenished","Resurrect","Scanned","SelfDestruct","SendText","Shutdown","Synthesis","SystemsShutdown","USSDrop","VehicleSwitch","WingAdd","WingInvite","WingJoin","WingLeave","CargoTransfer","SupercruiseDestinationDrop")
}

# Eventos que usa el switch del journal en Form1.cs (journal.@event)
$SwitchCases = @("ColonisationConstructionDepot","PowerplayRank","PowerplayMerits","SquadronStartup","Statistics","FSSBodySignals","ShipTargeted","Loadout","FSDJump","Materials","MaterialCollected","EngineerCraft","MaterialTrade","MissionAccepted","MissionCompleted","MissionAbandoned","ReceiveText","FactionKillBond","Bounty","Location","Docked","Undocked","ScanOrganic")

# Eventos con handler registrado en el pipeline
$PipelineHandlers = @("LoadGame","PowerplayCollect","CollectCargo","EjectCargo","DockingGranted","StartJump")

$classes = Get-ChildItem (Join-Path $RepoRoot "Journal") -Recurse -Filter "Journal*.cs" |
    Where-Object { $_.BaseName -ne "JournalBase" } | ForEach-Object { $_.BaseName.Substring(7) } | Sort-Object -Unique

$sb = New-Object System.Text.StringBuilder
[void]$sb.AppendLine("# Catalogo de eventos del journal")
[void]$sb.AppendLine("")
[void]$sb.AppendLine("Fuente: [elite-journal.readthedocs.io](https://elite-journal.readthedocs.io/en/latest/).")
[void]$sb.AppendLine("")
$bt = [char]96
[void]$sb.AppendLine("Clases totales: **$($classes.Count)**. Generadas automaticamente desde muestras reales o fabricadas segun la doc con " + $bt + "tools/GenerateJournalClasses.ps1" + $bt + ".")
[void]$sb.AppendLine("")
[void]$sb.AppendLine("| Evento | Seccion | Clase C# | Usado en el switch | Pipeline |")
[void]$sb.AppendLine("|---|---|---|---|---|")

foreach ($section in $Catalogue.Keys) {
    foreach ($ev in $Catalogue[$section]) {
        $hasClass = $ev -in $classes
        $cls = if ($hasClass) { "Journal$ev" } else { "-" }
        $sw = if ($ev -in $SwitchCases) { "si" } else { "" }
        $pl = if ($ev -in $PipelineHandlers) { "si" } else { "" }
        $bt = [char]96
        $clsCell = if ($hasClass) { $bt + "Journal$ev" + $bt } else { "-" }
        [void]$sb.AppendLine("| $ev | $section | $clsCell | $sw | $pl |")
    }
}

[System.IO.File]::WriteAllText($OutFile, $sb.ToString(), (New-Object System.Text.UTF8Encoding($true)))
Write-Output "Generado $OutFile"
Write-Output ("Filas: " + (($Catalogue.Values | ForEach-Object { $_.Count } | Measure-Object -Sum).Sum))
