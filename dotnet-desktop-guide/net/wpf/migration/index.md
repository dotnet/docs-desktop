---
title: Upgrade a WPF app to .NET 7
description: Learn how to upgrade a .NET Framework (or previous .NET) Windows Presentation Foundation (WPF) application to .NET 7.
ms.date: 05/23/2023
ms.topic: how-to
---

# How to upgrade a WPF desktop app to .NET 7

This article describes how to upgrade a Windows Presentation Foundation (WPF) desktop app to .NET 7. Even though WPF runs on .NET, a cross-platform technology, WPF is still a Windows-only framework. The following WPF-related project types can be upgraded with the .NET Upgrade Assistant:

- WPF project
- Control library
- .NET library

You should also review the information in the [Porting from .NET Framework to .NET](/dotnet/core/porting/) guide, and the [Differences with WPF .NET](differences-from-net-framework.md) article.

> [!WARNING]
> Don't upgrade Visual Basic WPF projects. There seems to be a bug with the extension. This article will be updated when the bug is fixed.

## Prerequisites

- Windows Operating System
- [Visual Studio 2022 version 17.1 or later to target .NET 7](https://visualstudio.microsoft.com/downloads/)
- [Visual Studio 2022 version 17.7 Preview 1 or later to target .NET 8](https://visualstudio.microsoft.com/downloads/)
- [.NET Upgrade Assistant extension for Visual Studio](/dotnet/core/porting/upgrade-assistant-install#install-the-visual-studio-extension)

## Demo app

This article was written in the context of upgrading the **Web Favorites Sample** project, which you can download from the [.NET Samples GitHub repository][wpf-sample].

## Initiate the upgrade

If you're upgrading multiple projects, start with projects that have no dependencies. In the Web Favorites sample, the **WebSiteRatings** project depends on the **StarVoteControl** library, so **StarVoteControl** should be upgraded first.

> [!TIP]
> Be sure to have a backup of your code, such as in source control or a copy.

Use the following steps to upgrade a project in Visual Studio:

01. Right-click on the **StarVoteControl** project in the **Solution Explorer** window and select **Upgrade**:

    :::image type="content" source="media/index/vs-upgrade.png" alt-text="The .NET Upgrade Assistant's Upgrade menu item in Visual Studio.":::

    A new tab is opened that prompts you to choose how you want the upgrade to be performed.

01. Select **In-place project upgrade**.
01. Next, select the target framework. Based on the type of project you're upgrading, different options are presented. **.NET Standard 2.0** is a good choice if the library doesn't rely on a desktop technology like WPF and can be used by both .NET Framework projects and .NET projects. However, the latest .NET releases provide many language and compiler improvements over .NET Standard.

    Select **.NET 7.0** and then select **Next**.

    :::image type="content" source="media/index/vs-target-framework.png" alt-text="The .NET Upgrade Assistant's target framework decision tab.":::

01. A tree is shown with all of the artifacts related to the project, such as code files and libraries. You can upgrade individual artifacts or the entire project, which is the default. Select **Upgrade selection** to start the upgrade.

    When the upgrade is finished, the results are displayed:

    :::image type="content" source="media/index/vs-upgrade-results.png" alt-text="The .NET Upgrade Assistant's upgrade results tab, showing 7 out of the 21 items were skipped.":::

    Artifacts with a solid green circle were upgraded while empty green circles were skipped. Skipped artifacts mean that the upgrade assistant didn't find anything to upgrade.

Now that the app's supporting library is upgraded, upgrade the main app.

### Upgrade the app

Once all of the supporting libraries are upgraded, the main app project can be upgraded. With the example app, there's only one library project to upgrade, which was upgraded in the previous section.

01. Right-click on the **WebSiteRatings** project in the **Solution Explorer** window and select **Upgrade**:
01. Select **In-place project upgrade** as the upgrade mode.
01. Select **.NET 7.0** for the target framework and select **Next**.
01. Leave all of the artifacts selected and select **Upgrade selection**.

After the upgrade is complete, the results are shown. If an item has a warning symbol, it means that there's a note for you to read, which you can do by expanding the item.

## Generate a clean build

After your project is upgraded, clean and compile it.

01. Right-click on the **WebSiteRatings** project in the **Solution Explorer** window and select **Clean**.
01. Right-click on the **WebSiteRatings** project in the **Solution Explorer** window and select **Build**.

Any errors and incompatibilities are listed in the **Error List** window.

[wpf-sample]: https://github.com/dotnet/samples/tree/main/wpf/WebSiteBrowser/
