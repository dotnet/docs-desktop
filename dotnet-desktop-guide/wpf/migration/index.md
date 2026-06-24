---
title: Overview of upgrading WPF apps
description: "Learn about the upgrade paths available for WPF apps, including modernizing from .NET Framework to .NET and upgrading between .NET versions."
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 06/11/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted

#customer intent: As a developer who maintains an existing WPF app, I want to understand my upgrade options so that I can plan and execute an upgrade to .NET.

---

# Overview of upgrading WPF apps

This article helps you understand what's involved in upgrading a Windows Presentation Foundation (WPF) app from .NET Framework to .NET. WPF is supported on .NET and receives active investment, including performance improvements, accessibility updates, and new features. If you maintain an existing WPF app and want to take advantage of those improvements or move to a supported .NET version, this article is for you.

The article covers the reasons to upgrade, the available upgrade paths, and the preparation work that makes the upgrade go smoothly. It also explains which .NET Framework technologies have no equivalent in .NET, how to fill API gaps using the Windows Compatibility Pack, and how breaking changes can affect your app.

For more information on differences between WPF on .NET Framework and .NET, see [Differences with WPF .NET](differences-from-net-framework.md).

[!INCLUDE [migration-shared](../../includes/migration-shared.md)]

## Related content

- [Differences with WPF .NET](differences-from-net-framework.md)
- [Upgrade a WPF app to .NET with GitHub Copilot modernization](how-to-upgrade-wpf.md)
- [Overview of porting from .NET Framework to .NET](/dotnet/core/porting/framework-overview)
- [.NET Framework technologies unavailable on .NET](/dotnet/core/porting/net-framework-tech-unavailable)
- [Prerequisites to porting code from .NET Framework](/dotnet/core/porting/premigration-needed-changes)
- [Breaking changes when porting code](/dotnet/core/porting/breaking-changes)
- [Use the Windows Compatibility Pack to port code to .NET](/dotnet/core/porting/windows-compat-pack)
