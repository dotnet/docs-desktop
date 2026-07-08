---
title: Upgrade a Windows Forms app to .NET with GitHub Copilot modernization
description: Walk through upgrading a Windows Forms app to .NET by using the GitHub Copilot modernization agent in Visual Studio.
author: adegeo
ms.author: adegeo
ms.date: 06/24/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: upgrade-and-migration-article  #Don't change.
ai-usage: ai-assisted
#customer intent: As a developer, I want to use GitHub Copilot modernization to upgrade my Windows Forms project to the latest version of .NET.
---

# Upgrade a Windows Forms app to .NET with GitHub Copilot modernization

This article walks through upgrading a Windows Forms desktop app to .NET by using the GitHub Copilot modernization agent. The agent runs in your editor, analyzes the project, and drives a three-stage workflow: assessment, planning, and execution.

The example uses the [Matching Game sample][winforms-sample], a small .NET Framework Windows Forms app made up of a main project and a class library.

## Prerequisites

- Windows operating system.
- Visual Studio 2026.
- [Download and extract the demo app used with this article.][winforms-sample]
- The .NET SDK for the version you're targeting. This article targets .NET 10.
- A Git repository for the solution. The agent commits its progress, so the project must be under source control.
- GitHub Copilot modernization enabled for Visual Studio. For more information, see [Install GitHub Copilot modernization](/dotnet/core/porting/github-copilot-app-modernization/install?pivots=visualstudio).

> [!TIP]
> Be sure to have a backup of your code, such as in source control or a copy, before you start.

## Open the solution

The Matching Game projects target .NET Framework 4.5. Visual Studio prompts you to retarget the projects to a supported version of .NET Framework when you open the solution.

1. Open the **MatchingGame** solution in Visual Studio.
1. Visual Studio displays the **Target Framework Not Installed** dialog.
1. Select **Update the target to .NET Framework 4.8 (Recommended)**, and then select **Continue**.
1. Open the **Git Changes** window and commit the retargeting changes.

## Important notes for Visual Basic

The GitHub Copilot modernization agent doesn't fully support Visual Basic .NET projects. The agent includes guardrails specifically designed to ensure C# projects upgrade reliably, and those guardrails interfere with VB project analysis and execution. If your solution contains VB projects, use one of these alternatives instead:

- **GitHub Copilot (standard agent)**: Use the regular Copilot agent—without the modernization agent—to guide the upgrade interactively.
- **[Upgrade Assistant](/dotnet/core/porting/upgrade-assistant-install)**: A dedicated migration tool with VB support.

> [!TIP]
> If your solution contains both C# and VB projects, you can still use the modernization agent for the C# projects. Upgrade the VB projects separately using one of the listed alternatives.

If you use the standard Copilot agent or upgrade manually, follow these steps:

1. If the project targets an unsupported version of .NET Framework, retarget it to .NET Framework 4.8 first. Visual Studio prompts you to do this when you open the solution, or you can change it in the project properties.
1. Update any outdated NuGet packages to their latest compatible versions.
1. Create a new VB Windows Forms project using a Visual Studio template or `dotnet new winforms -lang vb`. The template produces an SDK-style project file and settings, which have changed from .NET Framework.
1. Copy your `.vb` source files from the old project folder to the new project folder.
1. Copy any non-code files the project depends on, such as `app.config`, `.settings` files, images, icons, and other embedded resources.
1. Open the old project file (or `packages.config`) and note every NuGet package reference. Add those same packages to the new project using the NuGet Package Manager or `dotnet add package <name>`.
1. If the project references other projects in the solution, re-add those references in the new project.
1. Attempt to build the solution. Don't fix errors yet — the build output gives Copilot a concrete list of issues to work from.
1. Commit the current state to source control so you have a clean baseline before Copilot makes changes.
1. Open GitHub Copilot Chat, and ask it to resolve the remaining issues. For example:

   > This Visual Basic Windows Forms project was migrated from .NET Framework 4.8 to .NET 10. The project file and source files are in place, but the solution doesn't compile. Review the build errors and fix API incompatibilities, missing references, and any configuration migration issues.

1. Review the changes Copilot proposes, then rebuild and test the project.

## Initiate the upgrade

The Matching Game solution contains the **MatchingGame** app and the **MatchingGame.Logic** class library. The agent figures out the project graph on its own, so start the upgrade at the solution level.

1. In **Solution Explorer**, right-click the solution and select **Modernize**.

   The **GitHub Copilot Chat** window opens and starts a conversation with the modernization agent.

1. Select a model with strong reasoning and coding capabilities.
1. Tell the agent what you want to do. For example:

   > Upgrade everything to .NET 10.

   The agent reports the current state of the codebase and what it plans to do:

   - **Target Framework**: Indicates that the agent upgrades the projects to .NET 10.
   - **Flow Mode**: Defaults to **Automatic**. For complex apps, ask the agent to switch to **Guided** mode.
   - **Source Control**: Indicates that the agent creates a new working branch.

   The agent writes its work to `.github/upgrades/scenarios/dotnet-version-upgrade/` in your repository. If that folder already exists from a prior attempt, the agent asks whether to continue or start fresh.

1. Tell the agent `start` to begin the upgrade process.

## Review the assessment

In the assessment stage, the agent examines the project structure, dependencies, and code patterns to identify what needs to change. It writes the results to `assessment.md` in `.github/upgrades/scenarios/dotnet-version-upgrade/`.

When Copilot finishes the assessment, review the conversation output. It generally starts with something similar to the following:

```
Assessment Complete

I've analyzed the solution and created a full assessment — see .github/upgrades/scenarios/dotnet-version-upgrade/assessment.md.

Solution summary:
• Target: net48 → net10.0
• Projects: 2
• MatchingGame.Logic (Class Library)
• MatchingGame (Windows Forms)
• Issues: 883 (673 mandatory, 210 potential)
• Affected Technologies: Windows Forms (666), GDI+ / System.Drawing (208), Legacy Configuration System (2)

Key concerns:
• Both projects are legacy-format .csproj files — need conversion to SDK-style
• MatchingGame.csproj has API incompatibilities (binary + source) and an incompatible NuGet package
• WinForms remains supported on .NET 10 (Windows-only TFM)
• No reported security vulnerabilities
```

### Breakdown of the assessment

Copilot opens the `.github/upgrades/scenarios/dotnet-version-upgrade/assessment.md` file in the Visual Studio editor. Scroll down to the `MatchingGame\MatchingGame.csproj` section to see a table of issues:

> | Technology | Issues | Percentage | Migration Path |
> | :--- | :---: | :---: | :--- |
> | Legacy Configuration System | 2 | 0.2% | Legacy XML-based configuration system (app.config/web.config) that has been replaced by a more flexible configuration model in .NET Core. The old system was rigid and XML-based. Migrate to Microsoft.Extensions.Configuration with JSON/environment variables; use System.Configuration.ConfigurationManager NuGet package as interim bridge if needed. |
> | GDI+ / System.Drawing | 208 | 23.7% | System.Drawing APIs for 2D graphics, imaging, and printing that are available via NuGet package System.Drawing.Common. Note: Not recommended for server scenarios due to Windows dependencies; consider cross-platform alternatives like SkiaSharp or ImageSharp for new code. |
> | Windows Forms | 621 | 76.0% | Windows Forms APIs for building Windows desktop applications with traditional Forms-based UI that are available in .NET on Windows. Enable Windows Forms support: Option 1 (Recommended): Target net10.0-windows; Option 2: Add `<UseWindowsForms>true</UseWindowsForms>`; Option 3 (Legacy): Use Microsoft.NET.Sdk.WindowsDesktop SDK. |

Most of these issues aren't real problems. Look at the "Migration Path" column for the _GDI+_ row that lists 208 issues. The assessment flags these APIs because they're available in .NET Framework but not in .NET. The column explains the fix: add the `System.Drawing.Common` NuGet package to restore the APIs.

The _Windows Forms_ row lists 621 API issues for the same reason. Windows Forms APIs aren't available in .NET by default, but you restore them by targeting a Windows-specific framework like `net10.0-windows` and setting `<UseWindowsForms>true</UseWindowsForms>` in the project file. The **Option 3** suggests an incorrect option. Older versions of .NET required a Windows Forms project to specifically target the `Microsoft.NET.Sdk.WindowsDesktop` SDK, but now it's automatically referenced when `<UseWindowsForms>true</UseWindowsForms>` is set.

> [!TIP]
> To learn more about an option, ask Copilot for more information and context.

## Review the upgrade options

After the assessment, the agent presents upgrade strategy decisions and saves them to `upgrade-options.md` in `.github/upgrades/scenarios/dotnet-version-upgrade/`. For the Matching Game sample, the agent selects the following options:

| Aspect | Decision | Reason |
| --- | --- | --- |
| **Upgrade strategy** | Bottom-up. | The agent upgrades **MatchingGame.Logic** first because **MatchingGame** depends on it, then validates each tier before moving on. |
| **Project approach** | In-place. | Both projects migrate together because no other .NET Framework projects consume them. |
| **Unsupported packages** | Resolve inline. | The assessment found only a few incompatible packages, so the agent researches replacements as it works. |
| **Unsupported API handling** | Fix inline. | Most Windows Forms and GDI+ API changes for .NET are mechanical and don't require a separate planning pass. |
| **Windows native APIs** | Windows Compatibility Pack. | The app uses Windows Forms and GDI+ heavily and is inherently Windows-only. |
| **Nullable reference types** | Leave disabled. | The agent treats enabling nullable as a separate effort after migration. |

The agent also calls out risks that need your attention. For the Matching Game sample, the agent flags the `MetroFramework` packages because they're only available for .NET Framework. The likely outcome is removing `MetroFramework` and falling back to standard Windows Forms controls, which changes the visual style of the app.

Review the proposed options and tell the agent what you want to change. For example, tell the agent to enable nullable reference types or to pause and discuss `MetroFramework` replacements first. When you're done, reply `confirm` to lock in the selections and move to planning.

## Review the plan

In the planning stage, the agent converts the assessment and your confirmed options into a detailed specification. It writes the result to `plan.md` and creates a `scenario-instructions.md` file that stores preferences, decisions, and custom instructions for the upgrade.

> [!IMPORTANT]
> If **Flow Mode** is **Automatic**, the agent starts executing the plan without time to review.

The plan covers items such as the upgrade order across projects, the target framework moniker for each project (`net10.0-windows` for Windows Forms projects), package update paths, and risk mitigations for the breaking changes the assessment found.

To review and customize the plan:

1. Open `plan.md` in `.github/upgrades/scenarios/dotnet-version-upgrade/`.
1. Review the upgrade strategies and dependency updates.
1. Edit the plan to adjust steps or add context as needed.
1. Tell the agent to move to the execution stage.

> [!CAUTION]
> The plan depends on project interdependencies. The upgrade doesn't succeed if you modify the plan in a way that prevents the upgrade path from completing. For example, if **MatchingGame** depends on **MatchingGame.Logic** and you remove **MatchingGame.Logic** from the plan, upgrading **MatchingGame** might fail.

## Run the upgrade

In the execution stage, the agent breaks the plan into sequential, concrete tasks with validation criteria. The agent writes the task list to `.github/upgrades/scenarios/dotnet-version-upgrade/tasks.md` and tracks overall progress in that file. For each task, the agent creates a folder under `.github/upgrades/scenarios/dotnet-version-upgrade/tasks/` that contains a Markdown file describing the task and a markdown file that reports the task's progress.

For the Matching Game sample, the task list typically includes upgrading **MatchingGame.Logic** first, then **MatchingGame**, restoring packages, building the solution, and committing the changes.

To run the upgrade:

1. Tell the agent to start the upgrade.
1. Monitor progress by reviewing `tasks.md` as the agent updates task statuses. Open the per-task folders under `tasks/` for the task description and a detailed progress report.
1. If the agent encounters a problem it can't resolve, provide the requested help. For example, the agent might ask you to choose between two replacement APIs or confirm whether to keep a deprecated package.
1. Based on your responses, the agent adapts its strategy to the remaining tasks and continues.

The agent commits changes according to the Git strategy you configured during pre-initialization: per task, per group of tasks, or at the end.

### Notes for Visual Basic projects

Visual Basic Windows Forms projects on .NET Framework often use `System.Configuration` settings files and `My` extensions, such as `My.Computer` and `My.User`. The `My` extensions were removed in .NET. The agent flags these patterns during assessment and proposes fixes during execution, but you might need to confirm individual changes during a guided run.

If the agent migrates the project but it doesn't compile, verify that the project file targets Windows and references Windows Forms. The `<PropertyGroup>` element should look like the following snippet:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <OutputType>WinExe</OutputType>
    <MyType>WindowsForms</MyType>

    <!-- Other settings removed for brevity. -->
  </PropertyGroup>
</Project>
```

## Verify the upgrade

When the upgrade finishes, the agent recommends next steps in the chat response. Prompt the agent to generate a comprehensive change report with "Generate a change report."

Review the final task status in `tasks.md` and confirm that every step is complete.

To verify the upgrade:

1. Build the solution and address any compilation errors.
1. Run the app and confirm that forms load and behave as expected.

   The default font in Windows Forms changed between .NET Framework and .NET, so check forms and custom controls for layout differences.

1. Run any unit tests in the solution and fix failures.
1. Confirm that updated NuGet packages are compatible with your app.
1. Test the app thoroughly to verify the upgrade succeeded.

> [!TIP]
> If the project won't run and a debugger can't be attached, try restarting Visual Studio. Migrating project files from .NET Framework to .NET might confuse the Windows Forms designer without a restart.

The **Windows Forms Matching Game Sample** is now upgraded to .NET 10.

## Post-upgrade experience

If you ported the app from .NET Framework to .NET, review [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize) for ideas on adopting newer patterns, such as `appsettings.json` configuration, dependency injection, or cloud services. Adopting these patterns is separate from upgrading to .NET and isn't required to complete the upgrade.

## Related content

- [Overview of upgrading Windows Forms apps](index.md)
- [Best practices for GitHub Copilot modernization](/dotnet/core/porting/github-copilot-app-modernization/best-practices)
- [Porting from .NET Framework to .NET](/dotnet/core/porting/)
- [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize)
- [Breaking changes when porting code](/dotnet/core/porting/breaking-changes)

[winforms-sample]: https://github.com/dotnet/samples/tree/main/upgrades/matching-game-netframework/winforms
