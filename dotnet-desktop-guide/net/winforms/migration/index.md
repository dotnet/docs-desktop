---
title: Upgrade a .NET Framework WinForms app to .NET
description: Learn how to upgrade a .NET Framework (or previous .NET) Windows Forms application to .NET with the .NET Upgrade Assistant and Visual Studio.
ms.date: 11/20/2024
ms.topic: upgrade-and-migration-article  #Don't change.
#customer intent: As a developer, I want to use the .NET Upgrade Assistant to automatically upgrade my projects to the latest version of .NET.
---

# Migrate from Windows Forms .NET Framework to .NET

This article describes how to upgrade a Windows Forms desktop app to .NET using .NET Upgrade Assistant. Windows Forms remains a Windows-only framework, even though .NET is a cross-platform technology.

## Prerequisites

- Windows Operating System.
- [Download and extract the demo app used with this article.][winforms-sample]
- [Visual Studio 2022 version 17.12 or later to target .NET 9.](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022+desktopguide+winforms+migration)
- [.NET Upgrade Assistant extension for Visual Studio.](/dotnet/core/porting/upgrade-assistant-install#install-the-visual-studio-extension)

## Assessment

You should analyze your projects before performing an upgrade. Performing code analysis on your projects with .NET Upgrade Assistant generates a report that you can refer to, to identify potential migration blockers.

To analyze your projects and generate a report, right-click on the solution file in **Solution Explorer** and select **Upgrade**. For more information about performing an analysis, see [Analyze projects with .NET Upgrade Assistant](/dotnet/core/porting/upgrade-assistant-how-to-analyze).

## Migrate dependencies

If you're upgrading multiple projects, start with projects that have no dependencies. In the Matching Game sample, the **MatchingGame** project depends on the **MatchingGame.Logic** library, so **MatchingGame.Logic** should be upgraded first.

> [!TIP]
> Be sure to have a backup of your code, such as in source control or a copy.

Use the following steps to upgrade a project in Visual Studio:

01. Right-click on the **MatchingGame.Logic** project in the **Solution Explorer** window and select **Upgrade**:

    :::image type="content" source="media/index/vs-upgrade.png" alt-text="A screenshot of the .NET Upgrade Assistant's Upgrade menu item in Visual Studio.":::

    A new tab is opened that prompts you to choose which upgrade you want to perform.

01. Select **In-place project upgrade**.

    :::image type="content" source="media/index/step-1-inplace.png" alt-text="A screenshot of the .NET Upgrade Assistant tab. The 'In-place project upgrade' option is highlighted.":::

01. Next, select the target framework.

    Based on the type of project you're upgrading, you're presented with different options. **.NET Standard 2.0** can be used by both .NET Framework and .NET. This is a good choice if the library doesn't rely on a desktop technology like Windows Forms, which this project does.

    Select **.NET 9.0** and then select **Next**.

    :::image type="content" source="media/index/step-2-framework.png" alt-text="A screenshot of the .NET Upgrade Assistant. The target framework prompt is open and .NET 8 is highlighted along with the 'Next' button.":::

01. A tree is shown with all of the artifacts related to the project, such as code files and libraries. You can upgrade individual artifacts or the entire project, which is the default. Select **Upgrade selection** to start the upgrade.

    :::image type="content" source="media/index/step-3-components.png" alt-text="A screenshot of the .NET Upgrade Assistant. The 'Select Components' page is open with the 'Upgrade selection' button highlighted.":::

01. When the upgrade is finished, the results are displayed:

    :::image type="content" source="media/index/step-4-results1.png" alt-text="A screenshot of the .NET Upgrade Assistant's upgrade results tab, showing the migrated items from the project.":::

    Artifacts with a solid green circle were upgraded while empty green circles were skipped. Skipped artifacts mean that the upgrade assistant didn't find anything to upgrade.

Now that the app's supporting library is upgraded, upgrade the main app.

### Notes for Visual Basic projects

Currently, the .NET Upgrade Assistant doesn't recognize the use of `System.Configuration` in the settings file created by the Visual Basic templates on .NET Framework. It also doesn't respect the use of the `My` extensions used in .NET Framework projects, such as `My.Computer` and `My.User`. These extensions were removed in .NET. Because of these two problems, a Visual Basic library won't compile after being migrated with .NET Upgrade Assistant.

To fix this problem, the project must target Windows and reference Windows Forms.

01. After the migration is complete, double-click the **MatchingGame.Logic** project in the **Solution Explorer** window.
01. Locate the `<Project>/<PropertyGroup>` element.
01. In the XML editor, change the value of `<TargetFramework>` from `net9.0` to `net9.0-windows`.
01. Add `<UseWindowsForms>true</UseWindowsForms>` to the line after `<TargetFramework>`.

The project settings should look like the following snippet:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <OutputType>Library</OutputType>
    <MyType>Windows</MyType>

    ... other settings removed for brevity ...
```

## Migrate the main project

Once all of the supporting libraries are upgraded, the main app project can be upgraded. With the example app, there's only one library project to upgrade, which was upgraded in the previous section.

01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Upgrade**:
01. Select **In-place project upgrade**.
01. Select **.NET 9.0** for the target framework and select **Next**.
01. Leave all of the artifacts selected and select **Upgrade selection**.

After the upgrade is complete, the results are shown. Notice how the Windows Forms project has a warning symbol. Expand that item and more information is shown about that step:

:::image type="content" source="media/index/step-4-results2.png" alt-text="A screenshot of the .NET Upgrade Assistant's upgrade results tab, showing some of the result items have warning symbols.":::

Notice that the project upgrade component mentions that the default font changed. Because the font might affect control layout, you need to check every form and custom control in your project to ensure the UI is arranged correctly.

## Generate a clean build

After your main project is upgraded, clean and compile it.

01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Clean**.
01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Build**.

If your application encountered any errors, you can find them in the **Error List** window with a recommendation how to fix them.

The **Windows Forms Matching Game Sample** project is now upgraded to .NET 9.

## Post-upgrade experience

If you're porting an app from .NET Framework to .NET, review the [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize) article.

## Related content

- [Porting from .NET Framework to .NET.](/dotnet/core/porting/)

  The porting guide provides an overview of what you should consider when porting your code from .NET Framework to .NET. The complexity of your projects dictates how much work you'll do after the initial migration of the project files.

- [Modernize after upgrading to .NET from .NET Framework.](/dotnet/core/porting/modernize)

  The world of .NET has changed a lot since .NET Framework. This link provides some information about how to modernize your app after you upgrade.

[winforms-sample]: https://github.com/dotnet/samples/tree/main/windowsforms/matching-game
