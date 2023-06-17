---
title: Upgrade a WPF app to .NET 7
description: Learn how to upgrade a .NET Framework (or previous .NET) Windows Presentation Foundation (WPF) application to .NET 7.
ms.date: 06/01/2023
ms.topic: how-to
---

# How to upgrade a WPF desktop app to .NET 7

This article describes how to upgrade a Windows Presentation Foundation (WPF) desktop app to .NET 7. Even though WPF runs on .NET, a cross-platform technology, WPF is still a Windows-only framework. The following WPF-related project types can be upgraded with the .NET Upgrade Assistant:

- WPF project
- Control library
- .NET library

If you're upgrading from .NET Framework to .NET, consider reviewing the [Differences with WPF .NET](differences-from-net-framework.md) article and the [Porting from .NET Framework to .NET](/dotnet/core/porting/) guide.

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

Once all of the supporting libraries are upgraded, the main app project can be upgraded. Perform the following steps:

01. Right-click on the **WebSiteRatings** project in the **Solution Explorer** window and select **Upgrade**:
01. Select **In-place project upgrade** as the upgrade mode.
01. Select **.NET 7.0** for the target framework and select **Next**.
01. Leave all of the artifacts selected and select **Upgrade selection**.

After the upgrade is complete, the results are shown. If an item has a warning symbol, it means that there's a note for you to read, which you can do by expanding the item.

## Generate a clean build

After your project is upgraded, clean and compile it.

01. Right-click on the **WebSiteRatings** project in the **Solution Explorer** window and select **Clean**.
01. Right-click on the **WebSiteRatings** project in the **Solution Explorer** window and select **Build**.

If your application encountered any errors, you can find them in the **Error List** window with a recommendation how to fix them.

## Post-upgrade steps

If your project is being upgraded from .NET Framework to .NET, review the information in the [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize) article.

After upgrading, you'll want to:

- Check your NuGet packages.

  The .NET Upgrade Assistant upgraded some packages to new versions. With the sample app provided in this article, the `Microsoft.Data.Sqlite` NuGet package was upgraded from **1.0.0** to **7.0.5**. However, **1.0.0** depends on the `SQLite` NuGet package, but **7.0.5** removes that dependency. The `SQLite` NuGet package is still referenced by the project, although it's no longer required. Both `SQLite` and `SQLite.Native` NuGet packages can be removed from the project.

- Clean up the old NuGet packages.

  The _packages.config_ file is no longer required and can be deleted from your project, as the NuGet package references are now declared in the project file. Additionally, the local NuGet package cache folder, named _Packages_, is in either the folder or the parent folder of the project. This local cache folder can be deleted. The new NuGet package references use a global cache folder for packages, available in the user's profile directory, named _.nuget\\packages_.

- Remove the `System.Configuration` library.

  Most .NET Framework apps reference the `System.Configuration` library. After upgrading, it's possible that this library is still directly referenced.

  The `System.Configuration` library uses the _app.config_ file to provide run-time configuration options to your app. For .NET, this library was replaced by the `System.Configuration.ConfigurationManager` NuGet package. Remove reference to the library and add the NuGet package to your project.

- Check for places to modernize your app.

  APIs and libraries have changed quite a bit since .NET was released. And in most cases, .NET Framework doesn't have access to these improvements. By upgrading to .NET, your now has access to more modern libraries.

  The next sections describe areas you modernize the sample app used by this article.

## Modernize: Web browser control

The <xref:System.Windows.Controls.WebBrowser> control referenced by the WPF sample app is based on Internet Explorer, which is out-of-date. WPF for .NET can use the **WebView2** control based on Microsoft Edge. Complete the following steps to upgrade to the new <xref:Microsoft.Web.WebView2.Wpf.WebView2> web browser control:

01. Add the `Microsoft.Web.WebView2` NuGet package.
01. In the _MainWindow.xaml_ file:

    01. Import the control to the **wpfControls** namespace in the root element:

        :::code language="xaml" source="./snippets/index/csharp/WebSiteRatings/MainWindow.xaml" range="1-13" highlight="10" :::

    01. Down where the `<Border>` element is declared, remove the `WebBrowser` control and replace it with the `wpfControls:WebView2` control:

        :::code language="xaml" source="./snippets/index/csharp/WebSiteRatings/MainWindow.xaml" range="51-53" :::

01. Edit the _MainWindow.xaml.cs_ code behind file. Update the `ListBox_SelectionChanged` method to set the `browser.Source` property to a valid <xref:System.Uri>. This code previously passed in the website URL as a string, but the <xref:Microsoft.Web.WebView2.Wpf.WebView2> control requires a `Uri`.

    :::code language="csharp" source="./snippets/index/csharp/WebSiteRatings/MainWindow.xaml.cs" range="38-46" highlight="43" :::

Depending on which version of Windows a user of your app is running, they may need to install the WebView2 runtime. For more information, see [Get started with WebView2 in WPF apps](/microsoft-edge/webview2/get-started/wpf).

## Modernize: appsettings.json

.NET Framework uses the _App.config_ file to load settings for your app, such as connection strings and logging providers. .NET now uses the _appsettings.json_ file for app settings. _App.config_ files are supported in .NET through the `System.Configuration.ConfigurationManager` NuGet package, and support for _appsettings.json_ is provided by the `Microsoft.Extensions.Configuration` NuGet package.

As other libraries upgrade to .NET, they modernize by supporting _appsettings.json_ instead of _App.config_. For example, logging providers in .NET Framework that have been upgraded for .NET 6+ no longer use _App.config_ for settings. It's good to follow their direction and also move away from using _App.config_ where you can.

### Use appsettings.json with the WPF sample app

As an example, after upgrading the WPF sample app, use _appsettings.json_ for the connection string to the local database.

01. Remove the `System.Configuration.ConfigurationManager` NuGet package.
01. Add the `Microsoft.Extensions.Configuration.Json` NuGet package.
01. Add a file to the project named _appsettings.json_.
01. Set the _appsettings.json_ file to copy to the output directory.

    Set the **copy to output** setting through Visual Studio using the **Properties** window after selecting the file in the **Solution Explorer**. Alternatively you can edit the project directly and add the following `ItemGroup`:

    ```xml
      <ItemGroup>
        <Content Include="appsettings.json">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </Content>
      </ItemGroup>
    ```

01. Migrate the settings in the _App.config_ file to a new _appsettings.json_ file.

    In the WPF sample app, _app.config_ only contained a single connection string. Edit the _appsettings.json_ file to define the connection string:

    :::code language="json" source="./snippets/index/csharp/WebSiteRatings/appsettings.json":::

01. Edit the _App.xaml.cs_ file, instancing a configuration object that loads the _appsettings.json_ file, the added lines are highlighted:

    :::code language="csharp" source="./snippets/index/csharp/WebSiteRatings/App.xaml.cs" highlight="2,11,15-17":::

01. In the _.\\Models\\Database.cs_ file, change the `OpenConnection` method to use the new `App.Config` property. This requires importing the `Microsoft.Extensions.Configuration` namespace:

    :::code language="csharp" source="./snippets/index/csharp/WebSiteRatings/Models/Database.cs" range="1-12" highlight="3,9-10" :::

    `GetConnectionString` is an extension method provided by the `Microsoft.Extensions.Configuration` namespace.

[wpf-sample]: https://github.com/dotnet/samples/tree/main/wpf/WebSiteBrowser/
