param(
    [switch]$Force
)

# Generador de clases tipadas de eventos del journal (estrategia json2csharp).
# Replica el flujo de Form1.EventCSharp pero en lote:
#   por cada tools/JournalSamples/<Event>.json -> POST a json2csharp.com/api/Default
#   -> post-procesa (Root -> Journal<Event> : JournalBase, quita timestamp/@event)
#   -> escribe en Journal/<Seccion>/Journal<Event>.cs
#   -> registra el <Compile Include> en EDCrew48.csproj

$ErrorActionPreference = "Stop"

# Evento -> subcarpeta dentro de Journal/ ("" = raiz). Coincide con la organizacion
# existente (Travel/, Startup/, PowerPlay/) y las secciones de la documentacion.
$Sections = @{
    "CarrierJumpRequest"       = "FleetCarriers"
    "CarrierStats"             = "FleetCarriers"
    "CarrierJump"              = "FleetCarriers"
    "CarrierBuy"               = "FleetCarriers"
    "CarrierDecommission"      = "FleetCarriers"
    "CarrierCancelDecommission"= "FleetCarriers"
    "CarrierBankTransfer"      = "FleetCarriers"
    "CarrierDepositFuel"       = "FleetCarriers"
    "CarrierCrewServices"      = "FleetCarriers"
    "CarrierFinance"           = "FleetCarriers"
    "CarrierShipPack"          = "FleetCarriers"
    "CarrierModulePack"        = "FleetCarriers"
    "CarrierTradeOrder"        = "FleetCarriers"
    "CarrierDockingPermission" = "FleetCarriers"
    "CarrierNameChanged"       = "FleetCarriers"
    "CarrierJumpCancelled"     = "FleetCarriers"
    "PowerplayCollect"         = "PowerPlay"
    "PowerplayDefect"          = "PowerPlay"
    "PowerplayDeliver"         = "PowerPlay"
    "PowerplayFastTrack"       = "PowerPlay"
    "PowerplayJoin"            = "PowerPlay"
    "PowerplayLeave"           = "PowerPlay"
    "PowerplaySalary"          = "PowerPlay"
    "PowerplayVote"            = "PowerPlay"
    "PowerplayVoucher"         = "PowerPlay"
    "LeaveBody"                = "Travel"
    "DockingCancelled"         = "Travel"
    "DockingTimeout"           = "Travel"
    "Liftoff"                  = "Travel"
    "Touchdown"                = "Travel"
    "ScanOrganic"              = "Odyssey"
    "Backpack"                 = "Odyssey"
    "BackpackChange"           = "Odyssey"
    "BookDropship"             = "Odyssey"
    "BookTaxi"                 = "Odyssey"
    "BuyMicroResources"        = "Odyssey"
    "BuySuit"                  = "Odyssey"
    "BuyWeapon"                = "Odyssey"
    "CancelDropship"           = "Odyssey"
    "CancelTaxi"               = "Odyssey"
    "CollectItems"             = "Odyssey"
    "CreateSuitLoadout"        = "Odyssey"
    "DeleteSuitLoadout"        = "Odyssey"
    "Disembark"                = "Odyssey"
    "DropItems"                = "Odyssey"
    "DropShipDeploy"           = "Odyssey"
    "Embark"                   = "Odyssey"
    "FCMaterials"              = "Odyssey"
    "LoadoutEquipModule"       = "Odyssey"
    "LoadoutRemoveModule"      = "Odyssey"
    "RenameSuitLoadout"        = "Odyssey"
    "SellMicroResources"       = "Odyssey"
    "SellOrganicData"          = "Odyssey"
    "SellSuit"                 = "Odyssey"
    "SellWeapon"               = "Odyssey"
    "SuitLoadout"              = "Odyssey"
    "SwitchSuitLoadout"        = "Odyssey"
    "TransferMicroResources"   = "Odyssey"
    "TradeMicroResources"      = "Odyssey"
    "UpgradeSuit"              = "Odyssey"
    "UpgradeWeapon"            = "Odyssey"
    "UseConsumable"            = "Odyssey"
    "ChangeCrewRole"           = "Crew"
    "CrewLaunchFighter"        = "Crew"
    "CrewMemberJoins"          = "Crew"
    "CrewMemberQuits"          = "Crew"
    "CrewMemberRoleChange"     = "Crew"
    "EndCrewSession"           = "Crew"
    "JoinACrew"                = "Crew"
    "KickCrewMember"           = "Crew"
    "QuitACrew"                = "Crew"
    "ShipyardBuy"              = "Shipyard"
    "ShipyardNew"              = "Shipyard"
    "ShipyardSell"             = "Shipyard"
    "Statistics"               = "Startup"
}

$RepoRoot = Split-Path -Parent $PSScriptRoot
$SamplesDir = Join-Path $PSScriptRoot "JournalSamples"
$CsprojPath = Join-Path $RepoRoot "EDCrew48.csproj"

$Settings = @{
    UsePascalCase            = "false"
    UseFields                = "false"
    AlwaysUseNullables       = "false"
    UseJsonAttributes        = "false"
    NullValueHandlingIgnore  = "false"
    UseJsonPropertyName      = "false"
    ImmutableClasses         = "false"
    RecordTypes              = "false"
    NoSettersForCollections  = "false"
}

function Get-EventName($file) {
    $sample = [System.IO.File]::ReadAllText($file)
    if ($sample -match '"event"\s*:\s*"([^"]+)"') { return $matches[1] }
    throw "No se encontro 'event' en $file"
}

function ConvertTo-JournalClass([string]$ClassName, [string]$code) {
    # quita el comentario de cabecera y renombra la clase raiz
    $code = $code -replace '(?m)^// Root myDeserializedClass.*(\r?\n)?', ''
    $code = $code -replace 'public class Root', "public class Journal$ClassName : JournalBase"
    # quita timestamp/@event heredados de JournalBase
    $code = $code -replace '(?m)^\s*public DateTime timestamp\s*\{\s*get;\s*set;\s*\}\s*\r?\n', ''
    $code = $code -replace '(?m)^\s*public string @event\s*\{\s*get;\s*set;\s*\}\s*\r?\n', ''
    # campos 64-bit que json2csharp puede tipar como int si el sample usa valores
    # pequenos; en los journals reales son Int64
    $code = $code -replace '\bint\s+SystemAddress\b', 'Int64 SystemAddress'
    $code = $code -replace '\bint\s+MarketID\b', 'Int64 MarketID'
    $code = $code -replace '\bint\s+MissionID\b', 'Int64 MissionID'
    # prefija los tipos helper top-level con Journal<Evento> para evitar
    # colisiones entre las clases generadas y las ya existentes (Signal, Crew, ...)
    $helpers = [regex]::Matches($code, '(?m)^\s*public class (\w+)\s*\{') | ForEach-Object { $_.Groups[1].Value } |
        Where-Object { $_ -ne "Journal$ClassName" } | Sort-Object -Unique
    foreach ($h in $helpers) {
        $nested = "Journal${ClassName}${h}"
        $code = $code -replace "(?<![A-Za-z0-9_])class $h\b", "class $nested"
        $code = $code -replace "List<List<$h>>", "List<List<$nested>>"
        $code = $code -replace "List<$h>", "List<$nested>"
        $code = $code -replace "Dictionary<string,\s*$h>", "Dictionary<string, $nested>"
        $code = $code -replace "public $h\s+([A-Za-z0-9_]+)\s*\{", "public $nested `$1 {"
    }
    return $code.TrimEnd()
}

$generated = @()
$errors = @()

Get-ChildItem -Path $SamplesDir -Filter "*.json" | Sort-Object Name | ForEach-Object {
    $sampleFile = $_.FullName
    $eventName = Get-EventName $sampleFile

    $section = if ($Sections.ContainsKey($eventName)) { $Sections[$eventName] } else { "" }
    $dir = if ($section) { Join-Path $RepoRoot "Journal\$section" } else { Join-Path $RepoRoot "Journal" }
    $outFile = Join-Path $dir "Journal$eventName.cs"

    if ((Test-Path $outFile) -and -not $Force) {
        Write-Output ("SKIP  {0} (ya existe: {1})" -f $eventName, (Split-Path $outFile -Leaf))
        return
    }

    $sample = ([System.IO.File]::ReadAllText($sampleFile)).Trim()

    $payload = @{
        input       = $sample
        operationid = "jsontocsharp"
        settings    = $Settings
    }

    try {
        $jsonBody = $payload | ConvertTo-Json -Depth 5
        $utf8Body = [System.Text.Encoding]::UTF8.GetBytes($jsonBody)
        $resp = Invoke-RestMethod -Uri "https://json2csharp.com/api/Default" -Method Post `
            -Body $utf8Body -ContentType "application/json; charset=utf-8" -TimeoutSec 60
        $code = [string]$resp
        $classBody = ConvertTo-JournalClass $eventName $code

        $fileContent = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //$sample
    $classBody

}
"@

        New-Item -ItemType Directory -Path $dir -Force | Out-Null
        [System.IO.File]::WriteAllText($outFile, $fileContent, (New-Object System.Text.UTF8Encoding($true)))
        $generated += $outFile
        Write-Output ("OK    {0} -> Journal\{1}\{2}" -f $eventName, $section, "Journal$eventName.cs")
    }
    catch {
        $errors += "{0}: {1}" -f $eventName, $_.Exception.Message
        Write-Output ("ERROR {0}: {1}" -f $eventName, $_.Exception.Message)
    }

    Start-Sleep -Milliseconds 800
}

# registra en el csproj (old-style: <Compile Include> explicito) todas las
# clases Journal<Event> existentes que aun no esten listadas
$csproj = [System.IO.File]::ReadAllText($CsprojPath)
$anchor = "    <Compile Include=`"Pipeline\JournalHandler.cs`" />"
if ($csproj.Contains($anchor)) {
    $newEntries = @()
    Get-ChildItem -Path (Join-Path $RepoRoot "Journal") -Recurse -Filter "Journal*.cs" | ForEach-Object {
        $rel = $_.FullName.Substring([System.IO.Path]::GetFullPath($RepoRoot).TrimEnd('\').Length + 1)
        if (-not $csproj.Contains("Compile Include=`"$rel`"")) {
            $newEntries += "    <Compile Include=`"$rel`" />"
        }
    }
    if ($newEntries.Count -gt 0) {
        $csproj = $csproj.Replace($anchor, $anchor + "`r`n" + ($newEntries -join "`r`n"))
        [System.IO.File]::WriteAllText($CsprojPath, $csproj, (New-Object System.Text.UTF8Encoding($true)))
        Write-Output ("CSPROJ: {0} entradas anadidas" -f $newEntries.Count)
    } else {
        Write-Output "CSPROJ: sin entradas nuevas"
    }
} else {
    Write-Output "CSPROJ: no se encontro el ancla, anadir manualmente"
}

Write-Output ("RESUMEN: {0} generadas, {1} errores" -f $generated.Count, $errors.Count)
if ($errors.Count -gt 0) { $errors | ForEach-Object { Write-Output ("  - " + $_) } }
