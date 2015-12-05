Param(
  [string]$version = 0.0.0
)
$nuspec_dir = resolve-path .

#Updates the version number of the nuspecfiles
function UpdateVersionNumber($nuspecFile, $versionNumber)
{
    Write-Host "Updating internal dependency version numbers for: $nuspecFile"
    [xml]$myXML = Get-Content $nuspecFile
    $dependencies = $myXML.package.metadata.dependencies.group
    if($dependencies -ne $null)
    {
        foreach($dependency in $dependencies.dependency)
        {
            if($dependency.id.StartsWith($package_base_name))
            {
                $dependency.SetAttribute("version", $versionNumber)
            }
        }
    }
    $myXml.Save($nuspecFile)
}
dir "$nuspec_dir\" *.nuspec | ForEach-Object {UpdateVersionNumber $_ $version}