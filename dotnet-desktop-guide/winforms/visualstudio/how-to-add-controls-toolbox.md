---
title: Add controls to the Windows Forms Toolbox in Visual Studio
description: Learn how to add custom controls to the Visual Studio Toolbox for Windows Forms projects in .NET and .NET Framework.
author: adegeo
ms.author: adegeo
ms.service: dotnet-desktop
ms.topic: how-to
ms.date: 08/13/2025
ai-usage: ai-assisted

#customer intent: As a Windows Forms developer, I want to add custom controls to the Visual Studio Toolbox so that I can drag and drop them onto my forms during design time.

---

# Add controls to the Windows Forms Toolbox in Visual Studio

The Windows Forms **Toolbox** in Visual Studio displays controls that you can drag and drop onto your forms during design time. The method for adding custom controls to the Toolbox differs between .NET Framework and modern .NET projects, and has evolved with recent Visual Studio updates.

This article explains the various approaches to populate the Toolbox with custom controls for different project types and scenarios.

## Prerequisites

- Visual Studio 2022 (version 17.14 or later recommended for the latest features).
- A Windows Forms project (.NET Framework or .NET).

## Add controls from NuGet packages

The recommended approach for both .NET Framework and .NET projects is to use NuGet packages that contain the custom controls. This method ensures proper design-time support, metadata, and automatically manages dependencies. NuGet packages provide the most reliable way to distribute and consume Windows Forms controls, as they follow established conventions for separating design-time and runtime assemblies.

1. Right-click your project in **Solution Explorer**.
1. Select **Manage NuGet Packages**.
1. Search for and install the package containing your custom controls.
1. Build your project.
1. Open the Windows Forms designer.

The controls from the NuGet package automatically appear in the **Toolbox** under a category named after the package or assembly.

## Add controls from project references

When you have custom controls in another project within your solution, you can reference that project directly to make its controls available in the Toolbox. This approach is ideal for development scenarios where you're building custom controls as part of your solution and want immediate access to them during form design. Project references automatically handle build dependencies and provide full IntelliSense support.

1. Right-click your Windows Forms project in **Solution Explorer**.
1. Select **Add** > **Project Reference**.
1. Select the project containing your custom controls.
1. Select **OK**.
1. Build your solution.
1. Open the Windows Forms designer.

The custom controls from the referenced project appear in the **Toolbox**.

## Add controls from explicit assembly references

Starting with Visual Studio 17.14, you can add controls from explicit assembly references (standalone DLL files) to the **Toolbox**, which is useful for legacy controls and migration scenarios. This feature addresses a common challenge when working with older .NET Framework controls that aren't available as NuGet packages or when migrating existing applications that rely on standalone assembly files. The out-of-process designer automatically scans these references and extracts control metadata without loading the assemblies into Visual Studio itself.

# [.NET](#tab/dotnet)

Visual Studio doesn't support explicit assembly references in .NET projects. Alternatively, use [NuGet packages](#add-controls-from-nuget-packages) or [project references](#add-controls-from-project-references).

# [.NET Framework](#tab/dotnetframework)

Visual Studio 17.14 introduced automatic Toolbox support for explicit assembly references in .NET Framework projects using the out-of-process designer:

01. Right-click your project in **Solution Explorer**.
01. Select **Add** > **Reference**.
01. Select **Browse** and select your assembly (DLL file).
01. Select **OK**.
01. Build your project.
01. Enable the out-of-process designer if not already enabled:
    01. Go to **Tools** > **Options** > **Windows Forms Designer**.
    01. Set **Use the out-of-process designer** to **True**.
01. Open the Windows Forms designer.

The controls from the explicit assembly reference automatically appear in the **Toolbox**.

> [!NOTE]
> This feature is enabled by default in Visual Studio 17.14 and later. You can toggle it via **Tools** > **Options** > **Preview Features** if needed.

---

### Important considerations for explicit assembly references

- The out-of-process designer treats explicit assembly references as runtime-only.
- Advanced design-time features (custom CodeDomSerializer, UITypeEditor, TypeConverter) might not work as expected.
- For the best design-time experience, use NuGet packages that follow the [design-time/runtime separation model](https://github.com/microsoft/winforms-designer-extensibility/blob/main/docs/sdk/control-library-nuget-package-spec.md).

## Add controls manually using Choose Items

> [!IMPORTANT]
> This method only works with .NET Framework projects using the in-process designer and can't load 32-bit assemblies in 64-bit Visual Studio. It isn't supported for .NET projects.

For scenarios where automatic detection doesn't work, you can manually add controls to the Toolbox using the Choose Items dialog. This approach gives you explicit control over which controls are added and is useful when working with assemblies that don't automatically populate the Toolbox. This method only works with .NET Framework projects using the in-process designer and has limitations with 32-bit assemblies.

1. Right-click in the **Toolbox**.
1. Select **Choose Items**.
1. In the **Choose Toolbox Items** dialog, select **Browse**.
1. Navigate to and select your assembly (DLL file).
1. Select the controls you want to add.
1. Select **OK**.

The selected controls appear in the **Toolbox** and remain available for future use.

## Troubleshooting

If controls don't appear in the Toolbox or don't function correctly at design time, several common issues might be the cause. The following sections help you diagnose and resolve the most frequent problems encountered when adding custom controls to the Toolbox.

### Controls don't appear in the Toolbox

- Ensure your project builds successfully.
- Verify the assembly contains public controls that inherit from <xref:System.Windows.Forms.Control>.
- Check that you're using the correct designer (in-process vs. out-of-process).
- For .NET Framework projects with 32-bit assemblies, ensure you're using the out-of-process designer.

### Controls appear but don't work at design time

- For explicit assembly references, verify the controls don't require advanced design-time features.
- Consider migrating to NuGet packages with proper design-time/runtime separation.
- Check the Visual Studio Error List for any designer-related errors.

### Out-of-process designer issues

- Ensure you're using Visual Studio 17.14 or later for explicit assembly reference support.
- Check **Tools** > **Options** > **Windows Forms Designer** settings.
- Restart Visual Studio after changing designer settings.

## Related content

- [Troubleshoot designer issues with 32-bit assemblies](troubleshoot-32bit.md)
- [Windows Forms out-of-process designer extensibility](https://github.com/microsoft/winforms-designer-extensibility)
- [Create custom Windows Forms controls](/dotnet/desktop/winforms/controls/custom-control-painting-and-rendering)
