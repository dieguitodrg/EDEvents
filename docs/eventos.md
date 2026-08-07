# Catalogo de eventos del journal

Fuente: [elite-journal.readthedocs.io](https://elite-journal.readthedocs.io/en/latest/).

Clases totales: **256**. Generadas automaticamente desde muestras reales o fabricadas segun la doc con `tools/GenerateJournalClasses.ps1`.

| Evento | Seccion | Clase C# | Usado en el switch | Pipeline |
|---|---|---|---|---|
| Cargo | Startup | `JournalCargo` |  |  |
| ClearSavedGame | Startup | `JournalClearSavedGame` |  |  |
| Commander | Startup | `JournalCommander` |  |  |
| Loadout | Startup | `JournalLoadout` | si |  |
| Materials | Startup | `JournalMaterials` |  | si |
| Missions | Startup | `JournalMissions` |  |  |
| NewCommander | Startup | `JournalNewCommander` |  |  |
| LoadGame | Startup | `JournalLoadGame` |  | si |
| Passengers | Startup | `JournalPassengers` |  |  |
| Powerplay | Startup | `JournalPowerplay` |  |  |
| Progress | Startup | `JournalProgress` |  |  |
| Rank | Startup | `JournalRank` |  |  |
| Reputation | Startup | `JournalReputation` |  |  |
| Statistics | Startup | `JournalStatistics` |  | si |
| ApproachBody | Travel | `JournalApproachBody` |  |  |
| Docked | Travel | `JournalDocked` |  | si |
| DockingCancelled | Travel | `JournalDockingCancelled` |  |  |
| DockingDenied | Travel | `JournalDockingDenied` |  |  |
| DockingGranted | Travel | `JournalDockingGranted` |  | si |
| DockingRequested | Travel | `JournalDockingRequested` |  |  |
| DockingTimeout | Travel | `JournalDockingTimeout` |  |  |
| FSDJump | Travel | `JournalFSDJump` |  | si |
| FSDTarget | Travel | `JournalFSDTarget` |  |  |
| LeaveBody | Travel | `JournalLeaveBody` |  |  |
| Liftoff | Travel | `JournalLiftoff` |  |  |
| Location | Travel | `JournalLocation` |  | si |
| StartJump | Travel | `JournalStartJump` |  | si |
| SupercruiseEntry | Travel | `JournalSupercruiseEntry` |  |  |
| SupercruiseExit | Travel | `JournalSupercruiseExit` |  |  |
| Touchdown | Travel | `JournalTouchdown` |  |  |
| Undocked | Travel | `JournalUndocked` |  | si |
| NavRouteClear | Travel | `JournalNavRouteClear` |  |  |
| Bounty | Combat | `JournalBounty` | si |  |
| CapShipBond | Combat | `JournalCapShipBond` |  |  |
| Died | Combat | `JournalDied` |  |  |
| EscapeInterdiction | Combat | `JournalEscapeInterdiction` |  |  |
| FactionKillBond | Combat | `JournalFactionKillBond` | si |  |
| FighterDestroyed | Combat | `JournalFighterDestroyed` |  |  |
| HeatDamage | Combat | `JournalHeatDamage` |  |  |
| HeatWarning | Combat | `JournalHeatWarning` |  |  |
| HullDamage | Combat | `JournalHullDamage` |  |  |
| Interdicted | Combat | `JournalInterdicted` |  |  |
| Interdiction | Combat | `JournalInterdiction` |  |  |
| PVPKill | Combat | `JournalPVPKill` |  |  |
| ShieldState | Combat | `JournalShieldState` |  |  |
| ShipTargeted | Combat | `JournalShipTargeted` | si |  |
| SRVDestroyed | Combat | `JournalSRVDestroyed` |  |  |
| UnderAttack | Combat | `JournalUnderAttack` |  |  |
| CodexEntry | Exploration | `JournalCodexEntry` |  |  |
| DiscoveryScan | Exploration | `JournalDiscoveryScan` |  |  |
| Scan | Exploration | `JournalScan` |  |  |
| FSSAllBodiesFound | Exploration | `JournalFSSAllBodiesFound` |  |  |
| FSSBodySignals | Exploration | `JournalFSSBodySignals` | si |  |
| FSSDiscoveryScan | Exploration | `JournalFSSDiscoveryScan` |  |  |
| FSSSignalDiscovered | Exploration | `JournalFSSSignalDiscovered` |  |  |
| MaterialCollected | Exploration | `JournalMaterialCollected` |  | si |
| MaterialDiscarded | Exploration | `JournalMaterialDiscarded` |  |  |
| MaterialDiscovered | Exploration | `JournalMaterialDiscovered` |  |  |
| MultiSellExplorationData | Exploration | `JournalMultiSellExplorationData` |  |  |
| NavBeaconScan | Exploration | `JournalNavBeaconScan` |  |  |
| BuyExplorationData | Exploration | `JournalBuyExplorationData` |  |  |
| SAAScanComplete | Exploration | `JournalSAAScanComplete` |  |  |
| SAASignalsFound | Exploration | `JournalSAASignalsFound` |  |  |
| ScanBaryCentre | Exploration | `JournalScanBaryCentre` |  |  |
| SellExplorationData | Exploration | `JournalSellExplorationData` |  |  |
| Screenshot | Exploration | `JournalScreenshot` |  |  |
| AsteroidCracked | Trade | `JournalAsteroidCracked` |  |  |
| BuyTradeData | Trade | `JournalBuyTradeData` |  |  |
| CollectCargo | Trade | `JournalCollectCargo` |  | si |
| EjectCargo | Trade | `JournalEjectCargo` |  | si |
| MarketBuy | Trade | `JournalMarketBuy` |  |  |
| MarketSell | Trade | `JournalMarketSell` |  |  |
| MiningRefined | Trade | `JournalMiningRefined` |  |  |
| BuyAmmo | StationServices | `JournalBuyAmmo` |  |  |
| BuyDrones | StationServices | `JournalBuyDrones` |  |  |
| CargoDepot | StationServices | `JournalCargoDepot` |  |  |
| CommunityGoal | StationServices | `JournalCommunityGoal` |  |  |
| CommunityGoalDiscard | StationServices | `JournalCommunityGoalDiscard` |  |  |
| CommunityGoalJoin | StationServices | `JournalCommunityGoalJoin` |  |  |
| CommunityGoalReward | StationServices | `JournalCommunityGoalReward` |  |  |
| CrewAssign | StationServices | `JournalCrewAssign` |  |  |
| CrewFire | StationServices | `JournalCrewFire` |  |  |
| CrewHire | StationServices | `JournalCrewHire` |  |  |
| EngineerApply | StationServices | `JournalEngineerApply` |  |  |
| EngineerContribution | StationServices | `JournalEngineerContribution` |  |  |
| EngineerCraft | StationServices | `JournalEngineerCraft` |  | si |
| EngineerLegacyConvert | StationServices | `JournalEngineerLegacyConvert` |  |  |
| EngineerProgress | StationServices | `JournalEngineerProgress` |  |  |
| FetchRemoteModule | StationServices | `JournalFetchRemoteModule` |  |  |
| Market | StationServices | `JournalMarket` |  |  |
| MassModuleStore | StationServices | `JournalMassModuleStore` |  |  |
| MaterialTrade | StationServices | `JournalMaterialTrade` |  | si |
| MissionAbandoned | StationServices | `JournalMissionAbandoned` |  | si |
| MissionAccepted | StationServices | `JournalMissionAccepted` |  | si |
| MissionCompleted | StationServices | `JournalMissionCompleted` |  | si |
| MissionFailed | StationServices | `JournalMissionFailed` |  |  |
| MissionRedirected | StationServices | `JournalMissionRedirected` |  |  |
| ModuleBuy | StationServices | `JournalModuleBuy` |  |  |
| ModuleRetrieve | StationServices | `JournalModuleRetrieve` |  |  |
| ModuleSell | StationServices | `JournalModuleSell` |  |  |
| ModuleSellRemote | StationServices | `JournalModuleSellRemote` |  |  |
| ModuleStore | StationServices | `JournalModuleStore` |  |  |
| ModuleSwap | StationServices | `JournalModuleSwap` |  |  |
| Outfitting | StationServices | `JournalOutfitting` |  |  |
| PayBounties | StationServices | `JournalPayBounties` |  |  |
| PayFines | StationServices | `JournalPayFines` |  |  |
| PayLegacyFines | StationServices | `JournalPayLegacyFines` |  |  |
| RedeemVoucher | StationServices | `JournalRedeemVoucher` |  |  |
| RefuelAll | StationServices | `JournalRefuelAll` |  |  |
| RefuelPartial | StationServices | `JournalRefuelPartial` |  |  |
| Repair | StationServices | `JournalRepair` |  |  |
| RepairAll | StationServices | `JournalRepairAll` |  |  |
| RestockVehicle | StationServices | `JournalRestockVehicle` |  |  |
| ScientificResearch | StationServices | `JournalScientificResearch` |  |  |
| SearchAndRescue | StationServices | `JournalSearchAndRescue` |  |  |
| SellDrones | StationServices | `JournalSellDrones` |  |  |
| SellShipOnRebuy | StationServices | `JournalSellShipOnRebuy` |  |  |
| SetUserShipName | StationServices | `JournalSetUserShipName` |  |  |
| Shipyard | StationServices | `JournalShipyard` |  |  |
| ShipyardBuy | StationServices | `JournalShipyardBuy` |  |  |
| ShipyardNew | StationServices | `JournalShipyardNew` |  |  |
| ShipyardSell | StationServices | `JournalShipyardSell` |  |  |
| ShipyardTransfer | StationServices | `JournalShipyardTransfer` |  |  |
| ShipyardSwap | StationServices | `JournalShipyardSwap` |  |  |
| StoredModules | StationServices | `JournalStoredModules` |  |  |
| StoredShips | StationServices | `JournalStoredShips` |  |  |
| TechnologyBroker | StationServices | `JournalTechnologyBroker` |  |  |
| ClearImpound | StationServices | `JournalClearImpound` |  |  |
| PowerplayCollect | Powerplay | `JournalPowerplayCollect` |  | si |
| PowerplayDefect | Powerplay | `JournalPowerplayDefect` |  |  |
| PowerplayDeliver | Powerplay | `JournalPowerplayDeliver` |  |  |
| PowerplayFastTrack | Powerplay | `JournalPowerplayFastTrack` |  |  |
| PowerplayJoin | Powerplay | `JournalPowerplayJoin` |  |  |
| PowerplayLeave | Powerplay | `JournalPowerplayLeave` |  |  |
| PowerplayMerits | Powerplay | `JournalPowerplayMerits` |  | si |
| PowerplayRank | Powerplay | `JournalPowerplayRank` |  | si |
| PowerplaySalary | Powerplay | `JournalPowerplaySalary` |  |  |
| PowerplayVote | Powerplay | `JournalPowerplayVote` |  |  |
| PowerplayVoucher | Powerplay | `JournalPowerplayVoucher` |  |  |
| AppliedToSquadron | Squadrons | `JournalAppliedToSquadron` |  |  |
| DisbandedSquadron | Squadrons | `JournalDisbandedSquadron` |  |  |
| InvitedToSquadron | Squadrons | `JournalInvitedToSquadron` |  |  |
| JoinedSquadron | Squadrons | `JournalJoinedSquadron` |  |  |
| KickedFromSquadron | Squadrons | `JournalKickedFromSquadron` |  |  |
| LeftSquadron | Squadrons | `JournalLeftSquadron` |  |  |
| SharedBookmarkToSquadron | Squadrons | `JournalSharedBookmarkToSquadron` |  |  |
| SquadronCreated | Squadrons | `JournalSquadronCreated` |  |  |
| SquadronDemotion | Squadrons | `JournalSquadronDemotion` |  |  |
| SquadronPromotion | Squadrons | `JournalSquadronPromotion` |  |  |
| SquadronStartup | Squadrons | `JournalSquadronStartup` |  | si |
| WonATrophyForSquadron | Squadrons | `JournalWonATrophyForSquadron` |  |  |
| CarrierJump | FleetCarriers | `JournalCarrierJump` |  |  |
| CarrierBuy | FleetCarriers | `JournalCarrierBuy` |  |  |
| CarrierStats | FleetCarriers | `JournalCarrierStats` |  |  |
| CarrierJumpRequest | FleetCarriers | `JournalCarrierJumpRequest` |  |  |
| CarrierDecommission | FleetCarriers | `JournalCarrierDecommission` |  |  |
| CarrierCancelDecommission | FleetCarriers | `JournalCarrierCancelDecommission` |  |  |
| CarrierBankTransfer | FleetCarriers | `JournalCarrierBankTransfer` |  |  |
| CarrierDepositFuel | FleetCarriers | `JournalCarrierDepositFuel` |  |  |
| CarrierCrewServices | FleetCarriers | `JournalCarrierCrewServices` |  |  |
| CarrierFinance | FleetCarriers | `JournalCarrierFinance` |  |  |
| CarrierShipPack | FleetCarriers | `JournalCarrierShipPack` |  |  |
| CarrierModulePack | FleetCarriers | `JournalCarrierModulePack` |  |  |
| CarrierTradeOrder | FleetCarriers | `JournalCarrierTradeOrder` |  |  |
| CarrierDockingPermission | FleetCarriers | `JournalCarrierDockingPermission` |  |  |
| CarrierNameChanged | FleetCarriers | `JournalCarrierNameChanged` |  |  |
| CarrierJumpCancelled | FleetCarriers | `JournalCarrierJumpCancelled` |  |  |
| Backpack | Odyssey | `JournalBackpack` |  |  |
| BackpackChange | Odyssey | `JournalBackpackChange` |  |  |
| BookDropship | Odyssey | `JournalBookDropship` |  |  |
| BookTaxi | Odyssey | `JournalBookTaxi` |  |  |
| BuyMicroResources | Odyssey | `JournalBuyMicroResources` |  |  |
| BuySuit | Odyssey | `JournalBuySuit` |  |  |
| BuyWeapon | Odyssey | `JournalBuyWeapon` |  |  |
| CancelDropship | Odyssey | `JournalCancelDropship` |  |  |
| CancelTaxi | Odyssey | `JournalCancelTaxi` |  |  |
| CollectItems | Odyssey | `JournalCollectItems` |  |  |
| CreateSuitLoadout | Odyssey | `JournalCreateSuitLoadout` |  |  |
| DeleteSuitLoadout | Odyssey | `JournalDeleteSuitLoadout` |  |  |
| Disembark | Odyssey | `JournalDisembark` |  |  |
| DropItems | Odyssey | `JournalDropItems` |  |  |
| DropShipDeploy | Odyssey | `JournalDropShipDeploy` |  |  |
| Embark | Odyssey | `JournalEmbark` |  |  |
| FCMaterials | Odyssey | `JournalFCMaterials` |  |  |
| LoadoutEquipModule | Odyssey | `JournalLoadoutEquipModule` |  |  |
| LoadoutRemoveModule | Odyssey | `JournalLoadoutRemoveModule` |  |  |
| RenameSuitLoadout | Odyssey | `JournalRenameSuitLoadout` |  |  |
| ScanOrganic | Odyssey | `JournalScanOrganic` | si |  |
| SellMicroResources | Odyssey | `JournalSellMicroResources` |  |  |
| SellOrganicData | Odyssey | `JournalSellOrganicData` |  |  |
| SellSuit | Odyssey | `JournalSellSuit` |  |  |
| SellWeapon | Odyssey | `JournalSellWeapon` |  |  |
| ShipLocker | Odyssey | `JournalShipLocker` |  |  |
| SuitLoadout | Odyssey | `JournalSuitLoadout` |  |  |
| SwitchSuitLoadout | Odyssey | `JournalSwitchSuitLoadout` |  |  |
| TransferMicroResources | Odyssey | `JournalTransferMicroResources` |  |  |
| TradeMicroResources | Odyssey | `JournalTradeMicroResources` |  |  |
| UpgradeSuit | Odyssey | `JournalUpgradeSuit` |  |  |
| UpgradeWeapon | Odyssey | `JournalUpgradeWeapon` |  |  |
| UseConsumable | Odyssey | `JournalUseConsumable` |  |  |
| AfmuRepairs | Other | `JournalAfmuRepairs` |  |  |
| ApproachSettlement | Other | `JournalApproachSettlement` |  |  |
| ChangeCrewRole | Other | `JournalChangeCrewRole` |  |  |
| CockpitBreached | Other | `JournalCockpitBreached` |  |  |
| CommitCrime | Other | `JournalCommitCrime` |  |  |
| Continued | Other | `JournalContinued` |  |  |
| CrewLaunchFighter | Other | `JournalCrewLaunchFighter` |  |  |
| CrewMemberJoins | Other | `JournalCrewMemberJoins` |  |  |
| CrewMemberQuits | Other | `JournalCrewMemberQuits` |  |  |
| CrewMemberRoleChange | Other | `JournalCrewMemberRoleChange` |  |  |
| CrimeVictim | Other | `JournalCrimeVictim` |  |  |
| DatalinkScan | Other | `JournalDatalinkScan` |  |  |
| DatalinkVoucher | Other | `JournalDatalinkVoucher` |  |  |
| DataScanned | Other | `JournalDataScanned` |  |  |
| DockFighter | Other | `JournalDockFighter` |  |  |
| DockSRV | Other | `JournalDockSRV` |  |  |
| EndCrewSession | Other | `JournalEndCrewSession` |  |  |
| FighterRebuilt | Other | `JournalFighterRebuilt` |  |  |
| FuelScoop | Other | `JournalFuelScoop` |  |  |
| Friends | Other | `JournalFriends` |  |  |
| JetConeBoost | Other | `JournalJetConeBoost` |  |  |
| JetConeDamage | Other | `JournalJetConeDamage` |  |  |
| JoinACrew | Other | `JournalJoinACrew` |  |  |
| KickCrewMember | Other | `JournalKickCrewMember` |  |  |
| LaunchDrone | Other | `JournalLaunchDrone` |  |  |
| LaunchFighter | Other | `JournalLaunchFighter` |  |  |
| LaunchSRV | Other | `JournalLaunchSRV` |  |  |
| ModuleInfo | Other | `JournalModuleInfo` |  |  |
| Music | Other | `JournalMusic` |  |  |
| NpcCrewPaidWage | Other | `JournalNpcCrewPaidWage` |  |  |
| NpcCrewRank | Other | `JournalNpcCrewRank` |  |  |
| Promotion | Other | `JournalPromotion` |  |  |
| ProspectedAsteroid | Other | `JournalProspectedAsteroid` |  |  |
| QuitACrew | Other | `JournalQuitACrew` |  |  |
| RebootRepair | Other | `JournalRebootRepair` |  |  |
| ReceiveText | Other | `JournalReceiveText` | si |  |
| RepairDrone | Other | `JournalRepairDrone` |  |  |
| ReservoirReplenished | Other | `JournalReservoirReplenished` |  |  |
| Resurrect | Other | `JournalResurrect` |  |  |
| Scanned | Other | `JournalScanned` |  |  |
| SelfDestruct | Other | `JournalSelfDestruct` |  |  |
| SendText | Other | `JournalSendText` |  |  |
| Shutdown | Other | `JournalShutdown` |  |  |
| Synthesis | Other | `JournalSynthesis` |  |  |
| SystemsShutdown | Other | `JournalSystemsShutdown` |  |  |
| USSDrop | Other | `JournalUSSDrop` |  |  |
| VehicleSwitch | Other | `JournalVehicleSwitch` |  |  |
| WingAdd | Other | `JournalWingAdd` |  |  |
| WingInvite | Other | `JournalWingInvite` |  |  |
| WingJoin | Other | `JournalWingJoin` |  |  |
| WingLeave | Other | `JournalWingLeave` |  |  |
| CargoTransfer | Other | `JournalCargoTransfer` |  |  |
| SupercruiseDestinationDrop | Other | `JournalSupercruiseDestinationDrop` |  |  |
