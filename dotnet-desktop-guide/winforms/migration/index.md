---
title: Overview of upgrading Windows Forms apps
description: "Learn about the upgrade paths available for Windows Forms apps, including modernizing from .NET Framework to .NET and upgrading between .NET versions."
author: adegeo
ms.author: adegeo
ms.topic: overview
ms.date: 06/24/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted

#customer intent: As a developer who maintains an existing Windows Forms app, I want to understand my upgrade options so that I can plan and execute an upgrade to .NET.

---

# Overview of upgrading Windows Forms apps

This article helps you understand what's involved in upgrading a Windows Forms app from .NET Framework to .NET. Windows Forms is supported on .NET and receives active investment, including newer controls, high-DPI improvements, and accessibility updates. If you maintain an existing Windows Forms app and want to take advantage of those improvements or move to a supported .NET version, this article is for you.

The article covers the reasons to upgrade, the available upgrade paths, and the preparation work that makes the upgrade go smoothly. It also explains which .NET Framework technologies have no equivalent in .NET, how to fill API gaps using the Windows Compatibility Pack, and how breaking changes can affect your app.

For an example on how to upgrade, see [Upgrade a Windows Forms app to .NET with GitHub Copilot modernization](how-to-upgrade-winforms.md).

[!INCLUDE [migration-shared](../../includes/migration-shared.md)]

## Related content

- [Upgrade a Windows Forms app to .NET with GitHub Copilot](how-to-upgrade-winforms.md)
- [Port from .NET Framework to .NET](/dotnet/core/porting/framework-overview)
- [.NET Framework technologies unavailable on .NET 6+](/dotnet/core/porting/net-framework-tech-unavailable)
- [Prerequisites to port from .NET Framework](/dotnet/core/porting/premigration-needed-changes)
- [.NET breaking changes reference](/dotnet/core/compatibility/breaking-changes)
- [Use the Windows Compatibility Pack to port code](/dotnet/core/porting/windows-compat-pack)
