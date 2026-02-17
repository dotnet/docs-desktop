# .NET 10 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 10 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10 upgrade.
3. Upgrade AllTemplates.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

No projects are excluded from this upgrade.

### Aggregate NuGet packages modifications across all projects

No NuGet package modifications are required for this upgrade.

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### AllTemplates.csproj modifications

Project properties changes:
- Project file needs to be converted to SDK-style format
- Target framework should be changed from `.NETFramework,Version=v4.8` to `net10.0-windows`

Other changes:
- Convert project from legacy .NET Framework format to modern SDK-style project format
- Update project references and dependencies to be compatible with .NET 10
- Make sure the project has the standard WPF settings in it
