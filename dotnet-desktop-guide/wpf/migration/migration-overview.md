---
title: Choose your WPF migration path from .NET Framework
description: Understand your options for moving a WPF app from .NET Framework to modern .NET, and learn the standard terminology used throughout the migration documentation.
ms.date: 04/06/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: overview
ai-usage: ai-assisted
#customer intent: As a developer, I want to understand my options before migrating my WPF app from .NET Framework to modern .NET.
---

# Choose your WPF migration path from .NET Framework

Before you start migrating a Windows Presentation Foundation (WPF) app from .NET Framework to modern .NET, take a few minutes to choose the right path for your situation. The right choice depends on the complexity of your app, its dependencies, and how much time you can invest.

This article defines the terms used consistently across the migration documentation and provides a decision guide to help you pick the right approach.

## Terminology

The migration documentation uses the following terms consistently:

| Term | Definition |
|------|------------|
| **Upgrade** | The tooled, automated process of updating project files to target a newer version of .NET. Performed by the [.NET Upgrade Assistant](/dotnet/core/porting/upgrade-assistant-overview). |
| **Migrate** | The complete process of moving an app from .NET Framework to modern .NET, including project upgrades, code changes, resolving dependency conflicts, and testing. An upgrade is one step in a migration. |
| **Modernize** | Adopting modern .NET APIs and patterns *after* the initial migration. Examples include replacing the `WebBrowser` control with WebView2, or replacing `App.config` with `appsettings.json`. Modernization is optional but recommended. |
| **Port** | An older synonym for *migrate*, still used in the [porting guide](/dotnet/core/porting/) on learn.microsoft.com. Preserved in cross-references to that guide; avoid using it in new desktop documentation. |
| **.NET Framework** | The original Windows-only .NET runtime (versions 1.0 through 4.8.x). Always write in full; don't abbreviate. |
| **.NET** | The modern, cross-platform .NET runtime (.NET 5 and later). Write as **.NET 8**, **.NET 9**, or **.NET 10** when referring to a specific version. Don't use ".NET Core" for .NET 5 and later. |
| **WPF** | Windows Presentation Foundation. Always uppercase. Spell out in full on first use in an article; WPF is acceptable on subsequent uses. |

## Choose your migration path

Use the following table to identify the right approach for your app:

| If your app looks like this... | Recommended path |
|-------------------------------|-----------------|
| 1–3 projects, no WCF or COM dependencies, all NuGet packages have .NET support | [Upgrade with .NET Upgrade Assistant](index.md) |
| 4+ projects with a clear dependency hierarchy, no WCF | [Upgrade with .NET Upgrade Assistant](index.md), upgrading leaf projects first |
| Projects with WCF service dependencies | Migrate WCF to [CoreWCF](https://github.com/CoreWCF/CoreWCF) before or alongside the project upgrade |
| Projects with COM interop or P/Invoke | Upgrade the project first, then verify COM interop; most scenarios work as-is |
| Third-party UI controls (Telerik, DevExpress, Syncfusion) | Check your vendor's .NET compatibility matrix before upgrading |
| Significant UI redesign needed, or heavy unsupported legacy dependency load | Consider [rebuilding with WinUI 3](/windows/apps/winui/winui3/) |

> [!TIP]
> Run the [.NET Upgrade Assistant analysis](/dotnet/core/porting/upgrade-assistant-how-to-analyze) on your solution before committing to a path. It generates a compatibility report that surfaces blockers you might not know about.

## Upgrade order for multi-project solutions

When upgrading a solution with multiple projects, always start with the projects that have no dependencies on other projects in the solution, then work upward toward the main app.

For example, in a solution with:

- `MyApp.Data` (data access layer, no solution dependencies)
- `MyApp.Logic` (business logic, depends on `MyApp.Data`)
- `MyApp.UI` (the main WPF project, depends on both)

Upgrade `MyApp.Data` first, then `MyApp.Logic`, then `MyApp.UI`.

## Tools

The following tools help with different stages of migration:

| Tool | When to use |
|------|-------------|
| [.NET Upgrade Assistant (Visual Studio extension)](/dotnet/core/porting/upgrade-assistant-install) | Automates project file upgrades, NuGet updates, and common code fixes |
| [GitHub Copilot modernization agent](/dotnet/core/porting/) | AI-assisted guidance for larger or more complex migrations |
| [.NET API compatibility analyzer](/dotnet/standard/analyzers/api-analyzer) | Identifies .NET Framework APIs unavailable in modern .NET |
| [try-convert](https://github.com/dotnet/try-convert) | Manually converts legacy `.csproj` files to SDK-style format |

## Next steps

- [Upgrade a WPF app using .NET Upgrade Assistant](index.md) - step-by-step walkthrough for a typical app
- [Differences between WPF on .NET and .NET Framework](differences-from-net-framework.md) - API and behavior differences to watch for
- [Modernize after upgrading](/dotnet/core/porting/modernize) - adopt modern .NET patterns after migration
- [Porting from .NET Framework to .NET](/dotnet/core/porting/) - broad overview covering all project types
