---
title: Overview of upgrading Windows Forms apps
description: "Learn about the upgrade paths available for Windows Forms apps, including migrating from .NET Framework to modern .NET and upgrading between .NET versions."
author: adegeo
ms.author: adegeo
ms.topic: overview #Don't change
ms.date: 06/11/2026
ai-usage: ai-assisted

#customer intent: As a developer who maintains an existing Windows Forms app, I want to understand my upgrade options so that I can plan and execute a migration to modern .NET.

---

<!-- REFERENCE MATERIAL AND RULES

## Key Content Requirements

### Audience Focus

- Primary audience: Windows Forms developers on .NET Framework
- Secondary audience: Windows Forms developers on older .NET versions
- Remember: Windows Forms is Windows-only; don't reference cross-platform features

### Terminology

- Use ".NET" not "modern .NET"
- Windows Forms remains Windows-only (not cross-platform)

### Tool Promotion

**IMPORTANT**: We **promote** the **GitHub Copilot Modernization Agent**, not the .NET Upgrade Assistant.

- ✅ **Recommended**: GitHub Copilot Modernization Agent
- ❌ **Deprecated**: .NET Upgrade Assistant (mention only as deprecated/historical)

### Upgrade Scenarios to Cover

The article must address multiple upgrade scenarios:

1. **.NET Framework to .NET** - The traditional "port" scenario
2. **.NET version-to-version upgrades** - Moving from older .NET to newer .NET (e.g., .NET 6 to .NET 9)
3. **Dependency upgrades** - Updating NuGet packages, libraries, and third-party components
4. **Service upgrades** - Modernizing authentication, data access, cloud services

## Reference Material

Use these articles as source material for ideas and content:

- Generic overview about upgrades: https://learn.microsoft.com/dotnet/core/porting/index
- .NET Framework upgrade specific overview: https://learn.microsoft.com/dotnet/core/porting/framework-overview
- Windows Compatibility Pack to port code: https://learn.microsoft.com/dotnet/core/porting/windows-compat-pack
- .NET Framework technologies unavailable: https://learn.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable
- Breaking changes can affect porting your app: https://learn.microsoft.com/dotnet/core/porting/breaking-changes
- Prerequisites to port from .NET Framework: https://learn.microsoft.com/dotnet/core/porting/premigration-needed-changes

When linking to this content, use the `/dotnet/...` URL path since the article will be published on learn.microsoft.com.

-->

# Overview of upgrading Windows Forms apps

<!--
- Briefly introduce the purpose of this article: helping developers understand what it means to upgrade a Windows Forms app.
- State that the primary focus is migrating from .NET Framework to modern .NET, but version-to-version .NET upgrades are also covered.
- Mention that Windows Forms is supported on modern .NET and receives ongoing improvements.
- Help the reader determine if this article is for them: they maintain an existing Windows Forms app and want to move to a newer version of .NET.
-->

## Why upgrade

<!--
- Explain the key reasons a developer should upgrade their Windows Forms app.
- .NET Framework is a Windows-only, closed-source runtime that no longer receives feature updates.
- Modern .NET offers performance improvements, new language and runtime features, open-source development, and active feature investment in Windows Forms.
- Security: older versions of .NET (and .NET Framework) eventually reach end-of-support and stop receiving security patches.
- .NET release cadence: explain the LTS vs STS release model briefly and why staying current matters.
- Reference: https://learn.microsoft.com/dotnet/core/porting/index (when to upgrade)
-->

## Upgrade paths

<!--
- Describe the two main upgrade scenarios for Windows Forms developers.
- Path 1: .NET Framework to modern .NET — the most significant change; project format, APIs, and some technologies change.
- Path 2: .NET version to a newer .NET version — smaller in scope; mainly target framework updates, dependency updates, and reviewing breaking changes.
- Mention that modernization (e.g., adopting new patterns, cloud migration) is a separate optional step after upgrading.
- Reference: https://learn.microsoft.com/dotnet/core/porting/index (choose an upgrade path)
-->

### Upgrade from .NET Framework to modern .NET

<!--
- This is the most complex upgrade path and is the primary focus of this section.
- Both Windows Forms and WPF are available on modern .NET, but they remain Windows-only.
- Key changes when upgrading from .NET Framework:
  - Project file format changes to SDK-style.
  - Some APIs available in .NET Framework aren't available in modern .NET.
  - Some technologies are completely unavailable (see the "Unavailable technologies" section).
  - Third-party controls and libraries may not have been ported to .NET.
- Reference: https://learn.microsoft.com/dotnet/core/porting/framework-overview
-->

### Upgrade between .NET versions

<!--
- Upgrading from an older .NET version (e.g., .NET 6) to a newer one (e.g., .NET 8 or .NET 9) is typically a smaller effort.
- Primarily involves updating the target framework moniker in the project file.
- Review breaking changes documentation for the versions being crossed.
- Check for dependency updates that may be required.
- Reference: https://learn.microsoft.com/dotnet/core/porting/breaking-changes
-->

## Before you start

<!--
- Describe the prerequisite steps needed before beginning a migration from .NET Framework to modern .NET.
- These can often be done while still targeting .NET Framework, making the actual migration step simpler.
- Step 1: Upgrade to Visual Studio / MSBuild tooling that supports the target .NET version.
- Step 2: Retarget the .NET Framework project to at least .NET Framework 4.7.2 to ensure the best API compatibility surface.
- Step 3: Convert packages.config references to PackageReference format in the project file.
- Step 4: Convert to SDK-style project format.
- Step 5: Update NuGet dependencies to the latest versions and prefer .NET Standard targets where available.
- Reference: https://learn.microsoft.com/dotnet/core/porting/premigration-needed-changes
-->

## Unavailable technologies

<!--
- Some .NET Framework technologies don't exist in modern .NET and require code changes or alternative approaches.
- List the major unavailable technologies relevant to Windows Forms developers:
  - Application domains (AppDomain): no longer supported; use separate processes or AssemblyLoadContext instead.
  - .NET Remoting: not supported; use IPC mechanisms or gRPC/ASP.NET Core for cross-process scenarios.
  - Code Access Security (CAS): deprecated; use OS-level security boundaries (containers, user accounts).
  - Security Transparency: no longer a supported security boundary.
  - Windows Workflow Foundation (WF): not supported; consider CoreWF as an alternative.
  - System.EnterpriseServices (COM+): not supported.
- Note that some APIs may exist on the surface but throw PlatformNotSupportedException at runtime.
- Reference: https://learn.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable
-->

## Windows Compatibility Pack

<!--
- When porting from .NET Framework, many APIs that were present in .NET Framework are missing in modern .NET.
- The Windows Compatibility Pack (Microsoft.Windows.Compatibility NuGet package) fills that gap.
- It provides approximately 20,000 APIs covering areas such as: Windows Registry, Windows Event Log, WMI, Performance Counters, Directory Services, Windows ACLs, Windows Services, and more.
- It's especially useful for apps that must stay on Windows and want to migrate incrementally.
- Note that many APIs in the pack are Windows-only; use the Platform Compatibility Analyzer to detect cross-platform issues if needed.
- Reference: https://learn.microsoft.com/dotnet/core/porting/windows-compat-pack
-->

## Breaking changes

<!--
- When porting from .NET Framework to .NET, or upgrading between .NET versions, breaking changes can affect the app.
- Types of breaking changes: behavioral, binary compatibility, source compatibility, design-time.
- Breaking changes in Windows Forms are documented in the breaking changes reference.
- Developers should review the breaking changes list for the version range they're crossing before upgrading.
- Use the Platform Compatibility Analyzer to identify APIs that may throw PlatformNotSupportedException.
- Reference: https://learn.microsoft.com/dotnet/core/porting/breaking-changes
-->

## Tools for upgrading

<!--
- Several tools are available to assist with upgrading Windows Forms apps; this section introduces them.
- Emphasize that even when using tools, the developer must review and validate the results.
-->

### GitHub Copilot app modernization (recommended)

<!--
- The GitHub Copilot app modernization agent is the recommended tool for upgrading Windows Forms apps.
- It provides an AI-assisted, end-to-end experience: assesses the project, writes an upgrade plan, applies automated code fixes, and validates the result.
- Supports upgrading from .NET Framework to latest .NET, upgrading between .NET versions, and migration to Azure.
- Supports Windows Forms projects.
- Included with Visual Studio 2022 17.14.16 or later and Visual Studio 2026.
- Best for projects with many dependencies or Windows-specific APIs.
- Reference: https://learn.microsoft.com/dotnet/core/porting/framework-overview (GitHub Copilot modernization agent section)
-->

## Related content

- [How to upgrade a Windows Forms app to .NET](how-to-upgrade-winforms.md)
- [Overview of porting from .NET Framework to .NET](https://learn.microsoft.com/dotnet/core/porting/framework-overview)
- [.NET Framework technologies unavailable on .NET](https://learn.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable)
- [Prerequisites to porting code from .NET Framework](https://learn.microsoft.com/dotnet/core/porting/premigration-needed-changes)
- [Breaking changes when porting code](https://learn.microsoft.com/dotnet/core/porting/breaking-changes)
- [Use the Windows Compatibility Pack to port code to .NET](https://learn.microsoft.com/dotnet/core/porting/windows-compat-pack)
