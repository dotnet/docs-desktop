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

This article helps you understand what's involved in upgrading a Windows Forms app. The primary focus is migrating from .NET Framework to .NET, but upgrading between .NET versions is also covered.

Windows Forms is supported on .NET and receives active investment—including newer controls, high-DPI improvements, and accessibility updates. If you maintain an existing Windows Forms app and want to take advantage of those improvements, move to a supported .NET version, or keep your app on a runtime that still receives security patches, this article is for you.

The article covers the reasons to upgrade, the available upgrade paths, and the preparation work that makes the migration go smoothly. It also explains which .NET Framework technologies have no equivalent in .NET, how to fill API gaps using the Windows Compatibility Pack, and how breaking changes can affect your app. Finally, it introduces the GitHub Copilot modernization agent—the recommended tool for handling the upgrade process end to end.

## Why upgrade

<!--
- Explain the key reasons a developer should upgrade their Windows Forms app.
- .NET Framework is a Windows-only, closed-source runtime that no longer receives feature updates.
- Modern .NET offers performance improvements, new language and runtime features, open-source development, and active feature investment in Windows Forms.
- Security: older versions of .NET (and .NET Framework) eventually reach end-of-support and stop receiving security patches.
- .NET release cadence: explain the LTS vs STS release model briefly and why staying current matters.
- Reference: https://learn.microsoft.com/dotnet/core/porting/index (when to upgrade)
-->

.NET Framework is a Windows-only, closed-source runtime that no longer receives feature updates. While it continues to receive security patches for supported versions, it doesn't benefit from the performance work, language improvements, or active Windows Forms investment that .NET does. If you're maintaining a Windows Forms app on .NET Framework, upgrading to .NET gives you access to a faster, more capable platform that's actively developed in the open.

Security is a primary driver for staying current. Older .NET Framework and .NET versions eventually reach end-of-support and stop receiving security patches. Running an app on an unsupported runtime exposes it to unpatched vulnerabilities, which can create compliance and operational risk. The same applies to older .NET versions—each release has a defined support window, and apps running on an out-of-support version don't receive fixes. Upgrade before end-of-support to stay protected.

Beyond security, .NET offers meaningful performance improvements across runtime startup, throughput, and memory usage. Windows Forms on .NET also benefits from ongoing feature investment—newer controls, accessibility improvements, and high-DPI enhancements are shipped in .NET only. You also gain access to newer C# and Visual Basic language features, improved tooling, and a rich ecosystem of NuGet packages that target .NET.

.NET releases a new major version every year, alternating between long-term support (LTS) and standard-term support (STS) releases:

- **LTS releases** are supported for three years and are typically the best choice for production apps that prefer stability.
- **STS releases** are supported for 24 months and are useful when you want to adopt new features sooner.

Plan your upgrade cadence around these dates so your app is always on a supported version. For the current supported versions and end-of-support dates, see [.NET releases, patches, and support](/dotnet/core/releases-and-support).

## Upgrade paths

<!--
- Describe the two main upgrade scenarios for Windows Forms developers.
- Path 1: .NET Framework to modern .NET — the most significant change; project format, APIs, and some technologies change.
- Path 2: .NET version to a newer .NET version — smaller in scope; mainly target framework updates, dependency updates, and reviewing breaking changes.
- Mention that modernization (e.g., adopting new patterns, cloud migration) is a separate optional step after upgrading.
- Reference: https://learn.microsoft.com/dotnet/core/porting/index (choose an upgrade path)
-->

Most upgrades fall into one of two categories. Identify which path applies to your app, then use the guidance and tooling in this article to complete the work.

- **From .NET Framework to .NET.**

  The most significant change. The project file format, some APIs, and certain technologies are different. Review the prerequisites, assess your dependencies, and plan for API gaps before you start.

  After your app builds and runs on modern .NET, you can optionally take a modernization step to adopt newer patterns—such as `appsettings.json` configuration, dependency injection, or cloud services. Modernization is separate from upgrading and isn't required to complete the migration. For ideas and guidance, see [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize).

- **From an older .NET version to a newer one.**

  A smaller-scope upgrade. The main tasks are updating the target framework moniker, reviewing breaking changes for the versions you're crossing, and updating NuGet dependencies.

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

Upgrading from .NET Framework to .NET is the most significant migration path and the primary focus of this section. Windows Forms is supported on .NET and receives active investment, but the migration involves several categories of change to plan for before you start.

The first change is the project file format. .NET uses the SDK-style project format, which is more concise than the legacy format and replaces `<TargetFrameworkVersion>` with `<TargetFramework>`. You can convert your project file to SDK-style while it still targets .NET Framework, which reduces the scope of change during the actual port and gives you a better baseline to work from.

Not all .NET Framework APIs are available in .NET. Some APIs exist on the surface but throw `PlatformNotSupportedException` at runtime. The Windows Compatibility Pack (`Microsoft.Windows.Compatibility` NuGet package) fills many of these gaps by providing access to Windows-specific APIs such as the Windows Registry, Windows Event Log, and more. For details, see [Use the Windows Compatibility Pack to port code to .NET](/dotnet/core/porting/windows-compat-pack).

Some .NET Framework technologies have no equivalent in .NET and require alternative approaches. Application domains, .NET Remoting, Code Access Security (CAS), Security Transparency, Windows Workflow Foundation, and `System.EnterpriseServices` (COM+) aren't supported. For the full list and recommended alternatives, see the [Unavailable technologies](#unavailable-technologies) section.

Finally, audit your third-party dependencies. Controls and libraries that target only .NET Framework might not work on .NET. Prefer NuGet packages that target .NET Standard 2.0 or .NET directly. For packages that haven't been ported, look for community alternatives or check whether the Windows Compatibility Pack covers the needed APIs.

For a step-by-step guide, see [How to upgrade a Windows Forms app to .NET](how-to-upgrade-winforms.md).

### Upgrade between .NET versions

<!--
- Upgrading from an older .NET version (e.g., .NET 6) to a newer one (e.g., .NET 8 or .NET 9) is typically a smaller effort.
- Primarily involves updating the target framework moniker in the project file.
- Review breaking changes documentation for the versions being crossed.
- Check for dependency updates that may be required.
- Reference: https://learn.microsoft.com/dotnet/core/porting/breaking-changes
-->

Moving from one .NET version to another—for example, from .NET 6 to .NET 8 or .NET 9—is typically a smaller effort than migrating from .NET Framework. The core task is updating the `<TargetFramework>` property in your project file to the new target framework moniker. For example, changing `net6.0-windows` to `net9.0-windows`.

Before you update the target, review the breaking changes documentation for every version you're crossing. Breaking changes can be behavioral, affect binary or source compatibility, or change design-time behavior. Even minor version gaps can introduce changes that affect your app. Review [Breaking changes in .NET](/dotnet/core/compatibility/breaking-changes) and filter to the version range you're upgrading across.

After updating the target framework, update your NuGet dependencies. Packages that target older .NET versions might have newer releases that take advantage of the current runtime. Check for updates and prefer packages that target the version you're moving to. Some packages might also have deprecated APIs or changed behavior in newer versions, so review release notes when updating.

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

Before you begin porting your app to .NET, complete a set of preparatory steps while your project still targets .NET Framework. Doing this groundwork first reduces the scope of change during the actual migration and gives you a cleaner, validated baseline to start from. For a complete reference, see [Prerequisites to porting code from .NET Framework](/dotnet/core/porting/premigration-needed-changes).

- **Upgrade your tooling.**

  Ensure you're running a version of Visual Studio that supports the version of .NET you intend to target. Newer SDK versions include improved migration support, better analyzers, and updated project templates. For the relationship between the .NET SDK, MSBuild, and Visual Studio versions, see [Versioning relationship between the .NET SDK, MSBuild, and Visual Studio](/dotnet/core/porting/versioning-sdk-msbuild-vs).

- **Target .NET Framework 4.7.2 or later.**

  Retarget your project to .NET Framework 4.7.2 or higher before porting. This version provides the broadest API compatibility surface with .NET Standard 2.0, which reduces the number of API gaps you'll encounter during migration.

  In Visual Studio, right-click the project, select **Properties**, and then change the **Target Framework** dropdown to **.NET Framework 4.7.2**. Recompile and fix any issues before proceeding.

- **Convert to PackageReference format.**

  If your project uses a `packages.config` file to manage NuGet references, migrate to `PackageReference` format. PackageReference is the modern approach and integrates directly into the SDK-style project format you'll adopt in the next step.

  In Visual Studio, right-click `packages.config` in Solution Explorer and select **Migrate packages.config to PackageReference**. Review the migration output and resolve any warnings before continuing.

- **Convert to SDK-style project format.**

  Switch your project file to the [SDK-style format](/dotnet/core/project-sdk/overview). SDK-style projects are more concise, support multi-targeting, and are required for .NET. This conversion can be done while still targeting .NET Framework, so it's a safe preparatory step. Many conversion tools handle this automatically, or you can convert manually by replacing the project file content with the SDK-style equivalent and re-adding necessary properties.

- **Update NuGet dependencies.**

  Update all NuGet packages to their latest versions and prefer packages that target .NET Standard 2.0, rather than packages that target .NET Framework only. This reduces the risk of dependency blockers when you change the target framework. Review package release notes for any breaking changes introduced in newer versions.

All of the previous suggestions ensure that your projects are in a good state before you upgrade to .NET.

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

Several .NET Framework technologies have no equivalent in .NET and require alternative approaches before your app can run on the new runtime. Identify whether your app depends on any of these technologies early, because they represent the most disruptive category of migration work. For the full reference, see [.NET Framework technologies unavailable on .NET](/dotnet/core/porting/net-framework-tech-unavailable).

- **Application domains**

  `AppDomain` isn't supported. Use <xref:System.Runtime.Loader.AssemblyLoadContext> for dynamic assembly loading, and use separate processes or containers for isolation. Some `AppDomain` API members are present but throw <xref:System.PlatformNotSupportedException> at runtime.

- **Remoting**

  .NET Remoting isn't supported. Use <xref:System.IO.Pipes> or <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> for local IPC, or gRPC and ASP.NET Core for cross-machine communication. Calls to `BeginInvoke()` and `EndInvoke()` on delegate objects also throw `PlatformNotSupportedException`.

- **Code Access Security (CAS)**

  — CAS isn't supported and is no longer a security boundary. Use OS-level security boundaries such as virtualization, containers, or user accounts instead.

- **Security transparency**

  Security transparency, which separated sandboxed code from security-critical code, is no longer supported as a security boundary. Like CAS, this feature relied on runtime enforcement that .NET doesn't provide. Use OS-level isolation mechanisms instead.

- **Windows Workflow Foundation (WF)**

  WF isn't supported in .NET. If your app hosts or uses workflows, consider [CoreWF](https://github.com/UiPath/corewf), an open-source port of the Windows Workflow Foundation runtime that targets .NET.

- **System.EnterpriseServices (COM+)**

  <xref:System.EnterpriseServices> isn't supported. Apps that use COM+ services such as object pooling, transactions, or role-based security through `System.EnterpriseServices` need to be redesigned to use alternatives. For distributed transactions, consider `System.Transactions`. For service hosting scenarios, consider ASP.NET Core or worker services.

Be aware that some APIs in these areas are present in .NET but throw <xref:System.PlatformNotSupportedException> at runtime rather than failing at compile time. Test your app on .NET early in the migration to surface these issues before you invest in a full port.

## Windows Compatibility Pack

<!--
- When porting from .NET Framework, many APIs that were present in .NET Framework are missing in modern .NET.
- The Windows Compatibility Pack (Microsoft.Windows.Compatibility NuGet package) fills that gap.
- It provides approximately 20,000 APIs covering areas such as: Windows Registry, Windows Event Log, WMI, Performance Counters, Directory Services, Windows ACLs, Windows Services, and more.
- It's especially useful for apps that must stay on Windows and want to migrate incrementally.
- Reference: https://learn.microsoft.com/dotnet/core/porting/windows-compat-pack
-->

One of the most common issues when porting from .NET Framework is missing APIs. .NET Standard deliberately excludes technologies that can't work across all platforms—such as the Windows Registry, WMI, and reflection emit—so those APIs aren't available by default. The `Microsoft.Windows.Compatibility` NuGet package fills that gap. It provides about 20,000 APIs across the following technology areas:

- Windows Registry
- Windows Event Log
- Windows Management Instrumentation (WMI)
- Windows Performance Counters
- Directory Services
- Windows Access Control Lists (ACL)
- Windows Services
- Windows Cryptography
- Windows Communication Foundation (WCF)
- Ports, ODBC, CodeDom, and more

The pack sits on top of .NET Standard 2.0 and is especially useful when migrating incrementally. It lets you get your app building and running on .NET first, then tackle deeper modernization later, without having to rewrite Windows-specific API usage up front.

To add it to your project, install the [`Microsoft.Windows.Compatibility`](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) NuGet package:

```dotnetcli
dotnet add package Microsoft.Windows.Compatibility
```

For full details, see [Use the Windows Compatibility Pack to port code to .NET](/dotnet/core/porting/windows-compat-pack).

## Breaking changes

<!--
- When porting from .NET Framework to .NET, or upgrading between .NET versions, breaking changes can affect the app.
- Types of breaking changes: behavioral, binary compatibility, source compatibility, design-time.
- Breaking changes in Windows Forms are documented in the breaking changes reference.
- Developers should review the breaking changes list for the version range they're crossing before upgrading.
- Use the Platform Compatibility Analyzer to identify APIs that may throw PlatformNotSupportedException.
- Reference: https://learn.microsoft.com/dotnet/core/porting/breaking-changes
-->

Breaking changes are an expected part of any upgrade—whether you're porting from .NET Framework or moving between .NET versions. Reviewing them before you start prevents surprises late in the migration. For the full reference, see [Breaking changes when porting code](/dotnet/core/porting/breaking-changes).

Breaking changes fall into several categories, and not all of them cause compile-time errors:

- **Behavioral changes** affect how an API works at runtime. The signature stays the same, but the output, exceptions thrown, or internal behavior changes. These are the hardest to catch because they don't produce build errors.
- **Binary compatibility** changes affect whether existing compiled assemblies continue to work without recompilation. Removing or altering a public API surface breaks binary compatibility.
- **Source compatibility** changes require you to modify source code before it compiles successfully against the newer version.
- **Design-time compatibility** changes affect how projects open and behave in Visual Studio or other design environments.

When porting from .NET Framework, you're crossing a large version gap, so the list of potential changes is longer. When upgrading between .NET versions—for example, from .NET 6 to .NET 9—the scope is narrower, but every version in between can introduce changes that affect your app. Review breaking changes for each version you skip, not just the target version.

Breaking changes specific to Windows Forms are documented in [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms). Filter the breaking changes reference to the version range you're upgrading across, and review entries that apply to APIs your app uses.

## GitHub Copilot app modernization

<!--
- The GitHub Copilot app modernization agent is the recommended tool for upgrading Windows Forms apps.
- It provides an AI-assisted, end-to-end experience: assesses the project, writes an upgrade plan, applies automated code fixes, and validates the result.
- Supports upgrading from .NET Framework to latest .NET, upgrading between .NET versions, and migration to Azure.
- Supports Windows Forms projects.
- Included with Visual Studio 2022 17.14.16 or later and Visual Studio 2026.
- Best for projects with many dependencies or Windows-specific APIs.
- Reference: https://learn.microsoft.com/dotnet/core/porting/framework-overview (GitHub Copilot modernization agent section)
-->

The [GitHub Copilot modernization agent](/dotnet/core/porting/github-copilot-app-modernization/overview) is the recommended tool for upgrading Windows Forms apps. It's an AI-powered, end-to-end experience built into GitHub Copilot that handles the entire upgrade process—from initial assessment through code fixes and validation—with minimal manual intervention.

The agent follows a three-stage workflow:

- **Assessment.** Copilot examines your project structure, dependencies, and code patterns. It identifies breaking changes, API compatibility problems, deprecated patterns, and the overall upgrade scope. It then presents strategy decisions—such as upgrade order and compatibility handling—for you to review before proceeding.

- **Planning.** Copilot converts the assessment and your confirmed choices into a detailed upgrade plan, documenting upgrade strategies, refactoring approaches, dependency paths, and risk mitigations.

- **Execution.** Copilot breaks the plan into sequential tasks with validation criteria, applies code fixes, and commits changes incrementally. If it encounters a problem it can't resolve automatically, it asks for your help and learns from the correction.

All upgrade state is stored in `.github/upgrades/` in your repository, so you can pause and resume across sessions or switch between development environments without losing progress.

The agent supports these upgrade paths for Windows Forms projects:

- .NET Framework (any version) to .NET 8 or later
- .NET Core 1.x–3.x to .NET 8 or later
- .NET 5 or later to .NET 8 or later
- Migration to Azure services

It's available in Visual Studio 2022 17.14 or later, Visual Studio Code (via the GitHub Copilot Chat panel), and GitHub.com. In Visual Studio, right-click your solution or project in Solution Explorer and select **Modernize**, or open the GitHub Copilot Chat window and type `@Modernize`. In Visual Studio Code, open the GitHub Copilot Chat panel and type `@modernize-dotnet`.

For setup and usage details, see [What is GitHub Copilot modernization?](/dotnet/core/porting/github-copilot-app-modernization/overview).

## Related content

- [How to upgrade a Windows Forms app to .NET](how-to-upgrade-winforms.md)
- [Overview of porting from .NET Framework to .NET](https://learn.microsoft.com/dotnet/core/porting/framework-overview)
- [.NET Framework technologies unavailable on .NET](https://learn.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable)
- [Prerequisites to porting code from .NET Framework](https://learn.microsoft.com/dotnet/core/porting/premigration-needed-changes)
- [Breaking changes when porting code](https://learn.microsoft.com/dotnet/core/porting/breaking-changes)
- [Use the Windows Compatibility Pack to port code to .NET](https://learn.microsoft.com/dotnet/core/porting/windows-compat-pack)
