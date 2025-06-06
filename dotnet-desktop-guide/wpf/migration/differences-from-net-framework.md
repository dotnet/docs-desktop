---
title: Differences between .NET Framework and .NET
description: Describes the differences between the .NET Framework implementation of Windows Presentation Foundation (WPF) and .NET WPF.
author: adegeo
ms.date: 02/15/2023
ms.service: dotnet-desktop
ms.author: adegeo
ms.topic: conceptual
---

# Differences with WPF .NET

This article describes the differences between Windows Presentation Foundation (WPF) on .NET and .NET Framework. WPF for .NET is an [open-source framework](https://github.com/dotnet/wpf) forked from the original WPF for .NET Framework source code.

There are a few features of .NET Framework that .NET doesn't support. For more information on unsupported technologies, see [.NET Framework technologies unavailable on .NET](/dotnet/core/porting/net-framework-tech-unavailable).

## SDK-style projects

.NET uses SDK-style project files. These project files are different from the traditional .NET Framework project files managed by Visual Studio. To migrate your .NET Framework WPF apps to .NET, you must convert your projects. For more information, see [How to upgrade a WPF desktop app to .NET 7](index.md).

## NuGet package references

If your .NET Framework app lists its NuGet dependencies in a *packages.config* file, migrate to the [`<PackageReference>`](/nuget/consume-packages/package-references-in-project-files) format:

01. In Visual Studio, open the **Solution Explorer** pane.
01. In your WPF project, right-click **packages.config** > **Migrate packages.config to PackageReference**.

:::image type="content" source="media/differences-from-net-framework/package-reference-migration.png" alt-text="The Solution Explorer's context menu in Visual Studio, displaying the 'Migrate packages.config' item.":::

A dialog will appear showing calculated top-level NuGet dependencies and asking which other NuGet packages should be promoted to top level. Select **OK** and the *packages.config* file will be removed from the project and `<PackageReference>` elements will be added to the project file.

When your project uses `<PackageReference>`, packages aren't stored locally in a *Packages* folder, they're stored globally. Open the project file and remove any `<Analyzer>` elements that referred to the *Packages* folder. These analyzers are automatically included with the NuGet package references.

## Code Access Security

Code Access Security (CAS) is not supported by modern .NET, it's a .NET Framework-only concept. All CAS-related functionality is treated under the assumption of full-trust. WPF for .NET removes CAS-related code. The public API surface of these types still exists to ensure that calls into these types succeed.

Publicly defined CAS-related types were moved out of the WPF assemblies and into the Core .NET library assemblies. The WPF assemblies have type-forwarding set to the new location of the moved types.

| Source assembly | Target assembly | Type                |
| --------------- | --------------- | ------------------- |
| WindowsBase.dll | System.Security.Permissions.dll | <xref:System.Security.Permissions.MediaPermission> <br /> <xref:System.Security.Permissions.MediaPermissionAttribute> <br /> <xref:System.Security.Permissions.MediaPermissionAudio> <br /> <xref:System.Security.Permissions.MediaPermissionImage> <br /> <xref:System.Security.Permissions.MediaPermissionVideo> <br /> <xref:System.Security.Permissions.WebBrowserPermission> <br /> <xref:System.Security.Permissions.WebBrowserPermissionAttribute> <br /> <xref:System.Security.Permissions.WebBrowserPermissionLevel> |
| System.Xaml.dll | System.Security.Permissions.dll | <xref:System.Xaml.Permissions.XamlLoadPermission> |
| System.Xaml.dll | System.Windows.Extension.dll    | <xref:System.Xaml.Permissions.XamlAccessLevel><br/> |

> [!NOTE]
> In order to minimize porting friction, the functionality for storing and retrieving information related to the following properties was retained in the `XamlAccessLevel` type.
>
> - `PrivateAccessToTypeName`
> - `AssemblyNameString`
