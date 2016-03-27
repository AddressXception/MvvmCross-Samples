$packageName = "b47d129b-b06b-47c6-b3ff-199f62cb3f12"

Function Get-InstalledFamilyName($solutionDir) {
    $installedApps = get-AppxPackage
    foreach ($app in $installedApps) {
        if ($app.Name -eq $packageName) {
            foreach ($id in (Get-AppxPackageManifest $app).package.applications.application.id)
            {
                $app.packagefamilyname+"!"+$id >> "$solutionDir\Installed-AppxFamilyName.txt"
            }
        }
    }
}

Function Main($solutionDir) {
    Get-InstalledFamilyName $solutionDir
}

if ($args.Length -eq 0) {
	"First Parameter was not the solution dir."
    $solutionDir = $((get-location).path)
} else {
	$solutionDir = $args[0]
}

Write-Host "Running PostBuild.ps1 on SolutionDir = $solutionDir"
	Main $solutionDir