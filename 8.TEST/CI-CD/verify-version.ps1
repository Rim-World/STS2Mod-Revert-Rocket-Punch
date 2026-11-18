param(
    [string]$ExpectedVersion
)

$ErrorActionPreference = 'Stop'
$root = Resolve-Path (Join-Path $PSScriptRoot '..\..') | Select-Object -ExpandProperty Path
$manifestPath = Join-Path $root '9.SRC\RevertRocketPunch\RevertRocketPunch.json'
$changelogPath = Join-Path $root 'CHANGELOG.md'
$versionLogDir = Join-Path $root '7.ChangeLog'

$manifest = Get-Content $manifestPath -Raw | ConvertFrom-Json
$version = [string]$manifest.version
if ([string]::IsNullOrWhiteSpace($version)) {
    throw "manifest version is empty: $manifestPath"
}

$changelog = Get-Content $changelogPath -Raw
$changelogMatch = [regex]::Match($changelog, '(?m)^##\s*\[(\d+\.\d+\.\d+)\]')
if (-not $changelogMatch.Success) {
    throw "CHANGELOG.md has no released version heading: $changelogPath"
}
$changelogVersion = $changelogMatch.Groups[1].Value

$versionLogVersions = Get-ChildItem $versionLogDir -Filter '*.md' |
    Where-Object { $_.Name -ne 'ChangeLog.md' } |
    ForEach-Object {
        $text = Get-Content $_.FullName -Raw
        [regex]::Matches($text, '(?m)^##\s*(\d+\.\d+\.\d+)') | ForEach-Object { $_.Groups[1].Value }
    }
if (-not $versionLogVersions) {
    throw "7.ChangeLog has no version heading: $versionLogDir"
}
$versionLogVersion = $versionLogVersions | Sort-Object { [version]$_ } | Select-Object -Last 1

$versions = @{
    'manifest' = $version
    'CHANGELOG.md' = $changelogVersion
    '7.ChangeLog' = $versionLogVersion
}
if ($ExpectedVersion) {
    $versions['ExpectedVersion'] = $ExpectedVersion
}

$distinct = $versions.Values | Sort-Object -Unique
if ($distinct.Count -ne 1) {
    $detail = ($versions.GetEnumerator() | Sort-Object Name | ForEach-Object { "$($_.Name)=$($_.Value)" }) -join ', '
    throw "version mismatch: $detail"
}

Write-Host "version check OK: $version"
