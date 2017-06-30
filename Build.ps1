Write-Host "build: Build all started `n" -ForegroundColor Green

Push-Location $PSScriptRoot

if(Test-Path  .\artifacts) {

    Write-Host "build: Cleaning .\artifacts `n" -ForegroundColor Green	
    Remove-Item .\artifacts -Force -Recurse
}

if (Get-Command git -ErrorAction SilentlyContinue) 
{
 #default git local branch value is dev
 $gitLocalBranch = "dev"
 #get git local branch value
 $gitLocalBranch = $(git symbolic-ref --short -q HEAD)
}

$branch = @{ $true = $env:BUILD_SOURCEBRANCHNAME; $false = $gitLocalBranch}[$env:BUILD_SOURCEBRANCHNAME -ne $NULL];
#$buildNumber = @{ $true = $env:BUILD_SOURCEBRANCHNAME; $false = $(git rev-list --all --count)}[$env:BUILD_BUILDNUMBER -ne $NULL];
$revision = @{ $true = "{0:00000}" -f [convert]::ToInt32("0" + $env:BUILD_BUILDNUMBER, 10); $false = "local{0:00000}" -f [convert]::ToInt32("0" + $(git rev-list --all --count), 10)}[$env:BUILD_BUILDNUMBER -ne $NULL];
$suffix = @{ $true = ""; $false = "$($branch.Substring(0, [math]::Min(10,$branch.Length)))-$revision"}[$branch -eq "master" -and $revision -ne "local"]
$commitHash = $(git rev-parse --short HEAD)
$buildSuffix = @{ $true = "$($suffix)-$($commitHash)"; $false = "$($branch)-$($commitHash)" }[$suffix -ne ""]

Write-Host "build: Package version suffix is $suffix `n" -ForegroundColor Green
Write-Host "build: Build version suffix is $buildSuffix `n" -ForegroundColor Green

& dotnet restore --no-cache  /p:VersionSuffix=$suffix

foreach ($src in ls src/*) {
    Push-Location $src

	Write-Host "`n build: Packaging project in $src `n" -ForegroundColor Green	

    & dotnet build -c Release --version-suffix=$buildSuffix

    & dotnet pack -c Release --include-symbols -o ..\..\artifacts --version-suffix=$suffix --no-build
    
    if($LASTEXITCODE -ne 0) { exit 1 }    

    Pop-Location
}