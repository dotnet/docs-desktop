---
title: "How to: Add controls to the Toolbox"
description: "Learn how to add controls to the Visual Studio Toolbox in Windows Forms applications for both .NET Framework and .NET, including new explicit assembly references support."
ms.date: 04/17/2025
ms.service: dotnet-desktop
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Windows Forms, adding controls"
  - "Toolbox [Windows Forms], adding controls"
  - "controls [Windows Forms], adding to Toolbox"
  - ".NET Framework, Toolbox population"
  - ".NET, Toolbox population"
---

# How to: Add controls to the Toolbox

The Visual Studio **Toolbox** automatically displays controls from assemblies in your current solution. However, the way you add controls from external assemblies differs between .NET Framework and .NET projects. This article describes the different methods for populating the **Toolbox** and explains the key differences between .NET Framework and .NET approaches.

## Key differences: .NET Framework vs .NET

The approach for populating the **Toolbox** changed significantly from .NET Framework to .NET:

### .NET Framework approach

- Direct assembly references automatically populate the **Toolbox**
- Manual **Choose Items** dialog works with most assemblies
- 32-bit assemblies work in Visual Studio 2019 and earlier (32-bit IDE)
- COM and ActiveX controls are directly supported

### .NET approach

- **Toolbox** population primarily through NuGet packages
- Project references within the same solution
- Out-of-process designer handles cross-platform scenarios
- Enhanced support for explicit assembly references (Visual Studio 17.14+)

## Migrating from .NET Framework to .NET

When migrating from .NET Framework to .NET, you need to adjust how you populate the **Toolbox**:

### Convert assembly references to NuGet packages

01. **Identify external assemblies**: Review your project references for third-party controls.
01. **Find NuGet equivalents**: Search for NuGet packages that provide the same controls.
01. **Update project file**: Replace assembly references with NuGet package references.
01. **Verify Toolbox population**: Rebuild the project and confirm controls appear in the **Toolbox**.

### Handle legacy assemblies

For assemblies that don't have NuGet packages:

01. **Check for .NET compatibility**: Verify if the assembly works with .NET.
01. **Use explicit assembly references**: Add the assembly as a direct file reference.
01. **Enable out-of-process designer**: For .NET Framework projects, enable the out-of-process designer if needed.
01. **Consider alternatives**: Look for modern replacements or create wrapper NuGet packages.

### Migration checklist

- [ ] Catalog all external control libraries in your .NET Framework project
- [ ] Search NuGet.org for equivalent packages
- [ ] Test controls in a new .NET project
- [ ] Update documentation and build processes
- [ ] Verify all design-time functionality works correctly

## Automatic Toolbox population

The **Toolbox** automatically populates with controls from:

### For all project types:

- Current project references
- Other projects in your solution

### For .NET Framework projects:

- Direct assembly references
- COM and ActiveX components
- Global Assembly Cache (GAC) assemblies

### For .NET projects:

- NuGet packages installed in your solution
- Explicit assembly references (Visual Studio 17.14+)

## Adding controls: .NET Framework projects

### Method 1: Direct assembly references

The traditional approach for .NET Framework projects:

01. Right-click your project in **Solution Explorer**.
01. Select **Add** > **Reference**.
01. Browse to and select the assembly file.
01. Controls from the assembly automatically appear in the **Toolbox**.

### Method 2: Choose Items dialog

01. Right-click the **Toolbox** and select **Choose Items**.
01. In the **Choose Toolbox Items** dialog, browse for the assembly containing your controls.
01. Select the controls you want to add and click **OK**.

### Method 3: COM/ActiveX controls

01. Right-click the **Toolbox** and select **Choose Items**.
01. Switch to the **COM Components** tab.
01. Select the COM components you want to add.
01. Controls become available in the **Toolbox**.

## Adding controls: .NET projects

### Method 1: NuGet packages (recommended)

The preferred approach for .NET projects:

01. Right-click your project in **Solution Explorer**.
01. Select **Manage NuGet Packages**.
01. Search for and install packages containing controls.
01. Controls automatically appear in the **Toolbox** after installation.

### Method 2: Project references

Adding a project reference automatically makes controls available:

01. Right-click your project in **Solution Explorer**.
01. Select **Add** > **Project Reference**.
01. Choose the project containing the controls.
01. The controls appear automatically in the **Toolbox**.

### Method 3: Assembly references (limited support)

01. Right-click your project in **Solution Explorer**.
01. Select **Add** > **Reference**.
01. Browse to and select the assembly file.
01. Note: Controls might not appear in the **Toolbox** without additional configuration.

## Why the approach changed

The shift from .NET Framework to .NET introduced architectural changes that affect **Toolbox** population:

### .NET Framework (in-process designer)

- Visual Studio and your app run in the same process
- Direct assembly loading is straightforward
- All referenced assemblies are immediately available to the designer
- 32-bit assemblies work in 32-bit Visual Studio versions

### .NET (out-of-process designer)

- Visual Studio (64-bit .NET Framework) runs separately from your app (.NET)
- Cross-process communication required for designer functionality
- NuGet packages provide structured metadata for designer integration
- Enhanced separation between runtime and design-time assemblies

This architectural change improves cross-platform support and enables .NET applications to work with the .NET Framework-based Visual Studio designer, but requires different approaches for **Toolbox** population.

## Explicit assembly references (out-of-process designer)

Visual Studio 17.14 Preview 3 introduces enhanced **Toolbox** support for explicit assembly references in the Windows Forms out-of-process designer. This feature addresses challenges when working with legacy .NET Framework projects.

### What are explicit assembly references?

Explicit assembly references are stand-alone assemblies directly referenced in your project that are not:

- Pulled in through NuGet packages
- Project references  
- Part of the Global Assembly Cache (GAC)

These assemblies often represent legacy .NET Framework components, especially 32-bit assemblies that cannot be easily upgraded to modern .NET.

### Benefits of the new feature

Previously, the **Toolbox** only displayed controls from NuGet packages or project references. Explicit assembly references were invisible to the **Toolbox**, creating limitations for developers working with legacy codebases.

The enhanced feature provides:

- Automatic detection of controls in explicit assembly references
- Support for 32-bit assemblies in the out-of-process designer
- Improved integration for legacy Windows Forms controls
- Simplified migration and maintenance workflows

### How it works

When you launch the Windows Forms out-of-process designer for a .NET Framework project:

01. The designer automatically scans all references in the solution.
01. It identifies explicit assembly references without loading them into Visual Studio.
01. Using Roslyn APIs, the designer analyzes metadata to extract **Toolbox** item information.
01. Eligible controls appear in the **Toolbox** ready for drag-and-drop.

### Important limitations

Explicit assembly references have some limitations due to the out-of-process designer architecture:

- **Runtime-only treatment**: All explicit assembly references are treated as runtime-only assemblies.
- **Limited design-time functionality**: Advanced design-time features might not work as expected.
- **No design-time separation**: Unlike NuGet packages that can separate runtime and design-time assemblies, explicit references cannot provide this separation.

For the best experience with custom design-time features, use NuGet packages that follow the [specified layout](https://github.com/microsoft/winforms-designer-extensibility/blob/main/docs/sdk/control-library-nuget-package-spec.md) for proper runtime and design-time separation.

### Configuration

This feature is enabled by default starting with Visual Studio 17.14 Preview 3 for .NET Framework projects. To toggle this functionality:

01. Go to **Tools** > **Options** > **Preview Features**.
01. Find the explicit assembly references option.
01. Enable or disable as needed.

The feature is currently available for .NET Framework projects, with plans to extend support to .NET projects in future Visual Studio releases.

### Requirements

- Visual Studio 17.14 Preview 3 or later
- .NET Framework projects
- [Out-of-process designer enabled](troubleshoot-32bit.md#out-of-process-designer)

## Troubleshooting

### Controls don't appear in Toolbox

If controls don't appear in the **Toolbox**:

01. Verify the assembly contains public controls that inherit from <xref:System.Windows.Forms.Control> or <xref:System.ComponentModel.Component>.
01. Rebuild your solution.
01. Check that the assembly targets a compatible .NET Framework version.
01. For 32-bit assemblies, ensure the [out-of-process designer](troubleshoot-32bit.md) is enabled.

### 32-bit assembly issues

For 32-bit assemblies or COM components:

01. Enable the [out-of-process designer](troubleshoot-32bit.md#use-the-out-of-process-designer).
01. Ensure you're using Visual Studio 17.9 or later.
01. Consider upgrading to 64-bit versions of your components if available.

### Design-time issues

If controls appear in the **Toolbox** but don't work properly at design time:

01. Check if the control library supports the out-of-process designer.
01. Verify that any custom designers or type converters are compatible.
01. Consider using NuGet packages with proper design-time support instead of explicit assembly references.

## See also

- [Windows Forms controls](../controls/index.md)
- [The designer changes since .NET Framework](../controls-design/designer-differences-framework.md)
- [Migrate a Windows Forms app to .NET](../migration/index.md)
- [Choose Toolbox Items Dialog Box (Visual Studio)](/previous-versions/visualstudio/visual-studio-2010/dyca0t6t(v=vs.100))
- [Troubleshoot 32-bit problems](troubleshoot-32bit.md)
- [Windows Forms out-of-process designer extensibility](https://github.com/microsoft/winforms-designer-extensibility)
- [Visual Studio Toolbox support for explicit assembly references](https://devblogs.microsoft.com/visualstudio/toolbox-support-for-explicit-assembly-references-in-windows-forms-out-of-process-designer/)
