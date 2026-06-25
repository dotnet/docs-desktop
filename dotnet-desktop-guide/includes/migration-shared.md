---
author: adegeo
ms.author: adegeo
ms.date: 06/24/2026
ms.update-cycle: 1825-days
ms.topic: include
---

## Why upgrade

.NET Framework is a Windows-only, closed-source runtime that no longer receives feature updates. While it continues to receive security patches for supported versions, it doesn't benefit from the performance work, language improvements, or active investment that .NET does. If you're maintaining a Windows app on .NET Framework, upgrading to .NET gives you access to a faster, more capable platform that's actively developed in the open.

Staying current on .NET versions matters too. Each .NET release has a defined support window, and apps running on an out-of-support version stop receiving security patches and fixes. Upgrade before end-of-support to stay protected.

.NET offers meaningful performance improvements across runtime startup, throughput, and memory usage. Desktop apps on .NET also benefit from ongoing feature investment, including newer controls, accessibility improvements, high-DPI enhancements, and better integration with Windows. Some features, such as Dark Mode on Windows 11, are available only on .NET. You also gain access to newer C# and Visual Basic language features, improved tooling, and a rich ecosystem of NuGet packages that target .NET.

.NET releases a new major version every year, alternating between long-term support (LTS) and standard-term support (STS) releases:

- **LTS releases** are supported for three years and are typically the best choice for production apps that prefer stability.
- **STS releases** are supported for 24 months and are useful when you want to adopt new features sooner.

Plan your upgrade cadence around these dates so your app is always on a supported version. For the current supported versions and end-of-support dates, see [.NET releases, patches, and support](/dotnet/core/releases-and-support).

## Upgrade paths

Most upgrades fall into one of two categories. Identify which path applies to your app, then use the guidance and tooling in this article to complete the work.

- **From .NET Framework to .NET:** The most significant change.

  The project file format, some APIs, and certain technologies are different. Review the prerequisites, assess your dependencies, and plan for API gaps before you start.

  After your app builds and runs on .NET, you can optionally adopt newer patterns, such as `appsettings.json` configuration, dependency injection, or cloud services. Adopting these patterns is separate from the modernization to .NET and isn't required to complete the upgrade. For ideas and guidance, see [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize).

- **From an older .NET version to a newer one:** A smaller-scope upgrade.

  The main tasks are updating the target framework moniker, reviewing breaking changes for the versions you're crossing, and updating NuGet dependencies.

### Upgrade from .NET Framework to .NET

Upgrading from .NET Framework to .NET is the most significant upgrade path and the primary focus of this section.

> [!IMPORTANT]
> Even though .NET is a cross-platform technology, Windows desktop apps for .NET remain Windows only.

One change is the project file format. .NET uses the SDK-style project format, which is more concise than the legacy format. You can convert your project file to SDK-style while it still targets .NET Framework, which reduces the scope of change during the actual port and gives you a better baseline to work from.

Not all .NET Framework APIs are available in .NET. Some APIs exist on the surface but throw `PlatformNotSupportedException` at runtime. The Windows Compatibility Pack (`Microsoft.Windows.Compatibility` NuGet package) fills many of these gaps by providing access to Windows-specific APIs such as the Windows Registry, Windows Event Log, and more. For details, see [Use the Windows Compatibility Pack to port code to .NET](/dotnet/core/porting/windows-compat-pack).

Some .NET Framework technologies have no equivalent in .NET and require alternative approaches, such as Application Domains, Code Access Security (CAS), and Windows Workflow Foundation. For more information, see the [Unavailable .NET Framework technologies](#unavailable-net-framework-technologies) section.

Audit your third-party dependencies. Controls and libraries that target only .NET Framework might not work on .NET. Prefer NuGet packages that target .NET Standard 2.0 or .NET directly. For packages that haven't been ported, look for community alternatives or check whether the Windows Compatibility Pack covers the needed APIs.

### Upgrade between .NET versions

Moving from one .NET version to another—for example, from .NET 9 to .NET 10—is typically a smaller effort than modernizing from .NET Framework. The core task is updating the `<TargetFramework>` property in your project file to the new target framework moniker. For example, changing `net9.0-windows` to `net10.0-windows`.

Before you update the target, review the breaking changes documentation for every version you're crossing. Breaking changes can be behavioral, affect binary or source compatibility, or change design-time behavior. Even minor version gaps can introduce changes that affect your app. Review [Breaking changes in .NET](/dotnet/core/compatibility/breaking-changes) and filter to the version range you're upgrading across.

After updating the target framework, update your NuGet dependencies. Packages that target older .NET versions might have newer releases that take advantage of the current runtime. Check for updates and prefer packages that target the version you're moving to. Some packages might also have deprecated APIs or changed behavior in newer versions, so review release notes when updating.

## GitHub Copilot app modernization

The [GitHub Copilot modernization agent](/dotnet/core/porting/github-copilot-app-modernization/overview) is the recommended tool for upgrading Windows Forms and WPF apps. It's an AI-powered, end-to-end experience built into GitHub Copilot that handles the entire upgrade process.

The agent follows a three-stage workflow:

- **Assessment.** Copilot examines your project structure, dependencies, and code patterns. It identifies breaking changes, API compatibility problems, deprecated patterns, and the overall upgrade scope. It then presents strategy decisions, such as upgrade order and compatibility handling, for you to review before proceeding.

- **Planning.** Copilot converts the assessment and your confirmed choices into a detailed upgrade plan, documenting upgrade strategies, refactoring approaches, dependency paths, and risk mitigations.

- **Execution.** Copilot breaks the plan into sequential tasks with validation criteria, applies code fixes, and commits changes incrementally. If it encounters a problem it can't resolve automatically, it asks for your help and learns from the correction.

All upgrade state is stored in `.github/upgrades/` in your repository, so you can pause and resume across sessions or switch between development environments without losing progress.

The agent supports these upgrade paths:

- .NET Framework (any version) to .NET 8 or later
- .NET Core 1.x–3.x to .NET 8 or later
- .NET 5-7 to .NET 8 or later
- Migration to Azure services

It's available in Visual Studio 2026, Visual Studio 2022 17.14.16+, Visual Studio Code, and GitHub CLI. To start an upgrade in Visual Studio, right-click your solution or project in Solution Explorer and select **Modernize**, or open the GitHub Copilot Chat window and type `@Modernize`. In Visual Studio Code, open the GitHub Copilot Chat panel and type `@modernize-dotnet`.

For setup and usage details, see [What is GitHub Copilot modernization?](/dotnet/core/porting/github-copilot-app-modernization/overview).

## Unavailable .NET Framework technologies

Several .NET Framework technologies have no equivalent in .NET and require alternative approaches before your app can run on the new runtime. Identify whether your app depends on any of these technologies early, because they represent the most disruptive category of migration work. For the full reference, see [.NET Framework technologies unavailable on .NET](/dotnet/core/porting/net-framework-tech-unavailable).

- **Application domains**

  `AppDomain` isn't supported. Use <xref:System.Runtime.Loader.AssemblyLoadContext> for dynamic assembly loading, and use separate processes or containers for isolation. Some `AppDomain` API members are present but throw <xref:System.PlatformNotSupportedException> at runtime.

- **Remoting**

  .NET Remoting isn't supported. Use <xref:System.IO.Pipes> or <xref:System.IO.MemoryMappedFiles.MemoryMappedFile> for local IPC, or gRPC and ASP.NET Core for cross-machine communication. Calls to `BeginInvoke()` and `EndInvoke()` on delegate objects also throw `PlatformNotSupportedException`.

- **Code Access Security (CAS)**

  CAS isn't supported and is no longer a security boundary. Use OS-level security boundaries such as virtualization, containers, or user accounts instead.

- **Security transparency**

  Security transparency, which separated sandboxed code from security-critical code, is no longer supported as a security boundary. Like CAS, this feature relied on runtime enforcement that .NET doesn't provide. Use OS-level isolation mechanisms instead.

- **Windows Workflow Foundation (WF)**

  WF isn't supported in .NET. If your app hosts or uses workflows, consider [CoreWF](https://github.com/UiPath/corewf), an open-source port of the Windows Workflow Foundation runtime that targets .NET.

- **System.EnterpriseServices (COM+)**

  <xref:System.EnterpriseServices> isn't supported. Apps that use COM+ services such as object pooling, transactions, or role-based security through `System.EnterpriseServices` need to be redesigned to use alternatives. For distributed transactions, consider `System.Transactions`. For service hosting scenarios, consider ASP.NET Core or worker services.

Be aware that some APIs in these areas are present in .NET but throw <xref:System.PlatformNotSupportedException> at runtime rather than failing at compile time. Test your app on .NET early in the migration to surface these issues before you invest in a full port.

## Before you start upgrading from .NET Framework

Before you begin porting your app to .NET, complete a set of preparatory steps while your project still targets .NET Framework. Doing this groundwork first reduces the scope of change during the actual upgrade and gives you a cleaner, validated baseline to start from. For a complete reference, see [Prerequisites to porting code from .NET Framework](/dotnet/core/porting/premigration-needed-changes).

- **Upgrade your tooling.**

  Ensure you're running a version of Visual Studio that supports the version of .NET you intend to target. Newer SDK versions include improved migration support, better analyzers, and updated project templates. For the relationship between the .NET SDK, MSBuild, and Visual Studio versions, see [Versioning relationship between the .NET SDK, MSBuild, and Visual Studio](/dotnet/core/porting/versioning-sdk-msbuild-vs).

- **Target .NET Framework 4.7.2 or later.**

  Retarget your project to .NET Framework 4.7.2 or higher before porting. This version provides the broadest API compatibility surface with .NET Standard 2.0, which reduces the number of API gaps you'll encounter during the upgrade.

  In Visual Studio, right-click the project, select **Properties**, and then change the **Target Framework** dropdown to **.NET Framework 4.7.2**. Recompile and fix any issues before proceeding.

- **Convert to PackageReference format.**

  If your project uses a `packages.config` file to manage NuGet references, migrate to `PackageReference` format. PackageReference is the modern approach and integrates directly into the SDK-style project format you'll adopt in the next step.

  In Visual Studio, right-click `packages.config` in Solution Explorer and select **Migrate packages.config to PackageReference**. Review the migration output and resolve any warnings before continuing.

- **Convert to SDK-style project format.**

  Switch your project file to the [SDK-style format](/dotnet/core/project-sdk/overview). SDK-style projects are more concise, support multi-targeting, and are required for .NET. This conversion can be done while still targeting .NET Framework, so it's a safe preparatory step. Many conversion tools handle this automatically, or you can convert manually by replacing the project file content with the SDK-style equivalent and re-adding necessary properties.

- **Update NuGet dependencies.**

  Update all NuGet packages to their latest versions and prefer packages that target .NET Standard 2.0, rather than packages that target .NET Framework only. This reduces the risk of dependency blockers when you change the target framework. Review package release notes for any breaking changes introduced in newer versions.

All of the previous suggestions ensure that your projects are in a good state before you upgrade to .NET.

## Windows Compatibility Pack

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

The pack sits on top of .NET Standard 2.0 and is especially useful when modernizing incrementally. It lets you get your app building and running on .NET first, then tackle deeper refactoring later, without having to rewrite Windows-specific API usage up front.

To add it to your project, install the [`Microsoft.Windows.Compatibility`](https://www.nuget.org/packages/Microsoft.Windows.Compatibility) NuGet package:

```dotnetcli
dotnet add package Microsoft.Windows.Compatibility
```

For full details, see [Use the Windows Compatibility Pack to port code to .NET](/dotnet/core/porting/windows-compat-pack).

## Breaking changes

Breaking changes are an expected part of any upgrade, whether you're porting from .NET Framework or moving between .NET versions. Reviewing them before you start prevents surprises late in the migration. For the full reference, see [Breaking changes when porting code](/dotnet/core/porting/breaking-changes).

Breaking changes fall into several categories, and not all of them cause compile-time errors:

- **Behavioral changes** affect how an API works at runtime. The signature stays the same, but the output, exceptions thrown, or internal behavior changes. These are the hardest to catch because they don't produce build errors.
- **Binary compatibility** changes affect whether existing compiled assemblies continue to work without recompilation. Removing or altering a public API surface breaks binary compatibility.
- **Source compatibility** changes require you to modify source code before it compiles successfully against the newer version.
- **Design-time compatibility** changes affect how projects open and behave in Visual Studio or other design environments.

When porting from .NET Framework, you're crossing a large version gap, so the list of potential changes is longer. When upgrading between .NET versions—for example, from .NET 6 to .NET 9—the scope is narrower, but every version in between can introduce changes that affect your app. Review breaking changes for each version you skip, not just the target version.

Breaking changes specific to Windows Forms are documented in [Breaking changes for migration from .NET Framework to .NET](/dotnet/core/compatibility/breaking-changes). Filter the breaking changes reference to the version range you're upgrading across, and review entries that apply to APIs your app uses.

## Post-upgrade tasks

After your app builds and runs on .NET, complete a few cleanup tasks to remove artifacts left over from the upgrade.

**Review NuGet packages.**

The upgrade process might have updated packages to newer versions. Some of those newer versions remove dependencies that older versions required. After the upgrade, check each updated package and remove any transitive dependencies that are no longer needed. Review the release notes for updated packages to catch behavioral changes that don't cause build errors.

**Clean up old NuGet artifacts.**

If your project used a `packages.config` file to manage NuGet references, it's no longer needed after migrating to `PackageReference` format. Delete it from your project. You can also delete the local `packages` folder in your project or solution directory—NuGet now stores packages in a global cache folder at `.nuget\packages` in your user profile.

**Update `System.Configuration` references.**

Most .NET Framework apps reference `System.Configuration` directly. After upgrading, your project might still carry that reference. The `System.Configuration` library reads from the _app.config_ file for run-time configuration. In .NET, replace it with the [`System.Configuration.ConfigurationManager`](https://www.nuget.org/packages/System.Configuration.ConfigurationManager) NuGet package, which provides the same API surface without the direct framework assembly reference.

## Modernize after upgrading

Once your app runs on .NET, you can adopt modern patterns that aren't available in .NET Framework. These changes aren't required to complete the upgrade, but they improve maintainability and take advantage of active investment in .NET. For a broader set of ideas, see [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize).

**Migrate from App.config to appsettings.json.**

.NET Framework uses _App.config_ for run-time settings such as connection strings and logging configuration. .NET apps typically use _appsettings.json_ instead, provided by the `Microsoft.Extensions.Configuration` NuGet package. Many libraries—including logging providers—have dropped _App.config_ support in favor of _appsettings.json_. Migrating aligns your app with the ecosystem and simplifies configuration as you add new dependencies.

_App.config_ files continue to work in .NET through the `System.Configuration.ConfigurationManager` NuGet package, so you can migrate incrementally. For guidance, see [Configuration in .NET](/dotnet/core/extensions/configuration).

**Replace the WebBrowser control with WebView2 (WPF).**

The <xref:System.Windows.Controls.WebBrowser> control is based on Internet Explorer, which is no longer supported. WPF for .NET can use the `WebView2` control based on Microsoft Edge instead. `WebView2` provides a modern, actively maintained browser control with improved performance, security, and web standards support.

Add the [`Microsoft.Web.WebView2`](https://www.nuget.org/packages/Microsoft.Web.WebView2/) NuGet package to your project. Depending on which version of Windows a user runs, they might need to install the WebView2 runtime separately. For more information, see [Introduction to Microsoft Edge WebView2](/microsoft-edge/webview2/).
