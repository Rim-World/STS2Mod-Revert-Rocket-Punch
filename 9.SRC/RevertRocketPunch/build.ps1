param(
    [string]$Sts2DataDir
)

$ErrorActionPreference = 'Stop'

$root = $PSScriptRoot
$game = 'C:\Game\Steam\steamapps\common\Slay the Spire 2'
$godot = 'C:\Godot&GDRE\Godot_v4.5.1-stable_mono_win64\Godot_v4.5.1-stable_mono_win64_console.exe'
$modId = 'RevertRocketPunch'
$modOut = Join-Path $game "mods\$modId"

Write-Host '==> Verify version consistency'
$versionGate = Join-Path $root '..\..\8.TEST\CI-CD\verify-version.ps1'
if (-not (Test-Path $versionGate)) { throw "Version gate not found: $versionGate" }
& $versionGate

Write-Host '==> Build .NET assembly'
$buildArgs = @((Join-Path $root "$modId.csproj"), '-c', 'Debug', '-p:NuGetAudit=false')
if ($Sts2DataDir) { $buildArgs += "-p:Sts2DataDir=$Sts2DataDir" }
dotnet build @buildArgs
if ($LASTEXITCODE -ne 0) { throw 'dotnet build failed' }

$dll = Join-Path $root '.godot\mono\temp\bin\Debug\RevertRocketPunch.dll'
$pdb = Join-Path $root '.godot\mono\temp\bin\Debug\RevertRocketPunch.pdb'
if (-not (Test-Path $dll)) { throw "DLL not found: $dll" }

Write-Host '==> Godot import (generate .import/.ctex metadata)'
Push-Location $root
try {
    & $godot '--headless' '--import' '--path' $root 2>&1 | Out-Host
    if ($LASTEXITCODE -ne 0) { throw "Godot import failed: $LASTEXITCODE" }

    Write-Host '==> Godot export pck'
    New-Item -ItemType Directory -Force -Path $modOut | Out-Null
    $pck = Join-Path $modOut 'RevertRocketPunch.pck'
    & $godot '--headless' '--export-pack' 'Windows Desktop' $pck '--path' $root 2>&1 | Out-Host
    if ($LASTEXITCODE -ne 0) { throw "Godot export-pack failed: $LASTEXITCODE" }
}
finally {
    Pop-Location
}

Write-Host "==> Copy files to $modOut"
Copy-Item $dll (Join-Path $modOut 'RevertRocketPunch.dll') -Force
if (Test-Path $pdb) { Copy-Item $pdb (Join-Path $modOut 'RevertRocketPunch.pdb') -Force }
Copy-Item (Join-Path $root 'RevertRocketPunch.json') (Join-Path $modOut 'RevertRocketPunch.json') -Force

Write-Host '==> Done'