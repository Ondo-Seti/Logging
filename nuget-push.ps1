<#

Default value for nuget source in local development is c:\local-nuget

Default value can be changed with following command
Usage example: nuget-push.ps1 -Source d:\local-nuget

TFS CI should supply following variables: SourceDEV, SourcePROD and ApiKey  

#>
param([String] $Source = "c:\local-nuget", [String] $SourceDEV, [String] $SourcePROD, [String] $ApiKey)

Push-Location $PSScriptRoot\artifacts

if ($env:BUILD_SOURCEBRANCHNAME -eq "dev"){
$Source = $SourceDEV }
elseif ($env:BUILD_SOURCEBRANCHNAME -eq "master"){
$Source = $SourcePROD }

foreach ($nupkg in ls *.nupkg| Where-Object {$_.Name -notlike "*symbols*"} )
{
    "`n"
    Write-Debug "Package $($nupkg.Name) is ready to push"
    "`n"
    nuget push $nupkg -ApiKey ($ApiKey,"no key")[$ApiKey -ne $NULL]  -Source $Source
    "`n"
    Write-Debug "Pushed $($nupkg.Name)"
} 