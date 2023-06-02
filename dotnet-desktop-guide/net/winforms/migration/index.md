---
title: Upgrade a Windows Forms app to .NET 7
description: Learn how to upgrade a .NET Framework (or previous .NET) Windows Forms application to .NET 7.
ms.date: 06/01/2023
ms.topic: how-to
---

# How to upgrade a Windows Forms desktop app to .NET 7

This article describes how to upgrade a Windows Forms desktop app to .NET 7. Even though Windows Forms runs on .NET, a cross-platform technology, Windows Forms is still a Windows-only framework. The following Windows Forms-related project types can be upgraded with the .NET Upgrade Assistant:

- Windows Forms project
- Control library
- .NET library

You should also review the information in the [Porting from .NET Framework to .NET](/dotnet/core/porting/) guide.

> [!WARNING]
> Don't upgrade Visual Basic Windows Forms projects. There seems to be a bug with the extension. This article will be updated when the bug is fixed.

## Prerequisites

- Windows Operating System
- [Visual Studio 2022 version 17.1 or later to target .NET 7](https://visualstudio.microsoft.com/downloads/)
- [Visual Studio 2022 version 17.7 Preview 1 or later to target .NET 8](https://visualstudio.microsoft.com/downloads/)
- [.NET Upgrade Assistant extension for Visual Studio](/dotnet/core/porting/upgrade-assistant-install#install-the-visual-studio-extension)

## Demo app

This article was written in the context of upgrading the **Windows Forms Matching Game Sample** project, which you can download from the [.NET Samples GitHub repository][winforms-sample].

> [!IMPORTANT]
> Due to a bug in Windows Forms for .NET 7, the sample project crashes on startup after upgrading. This is fixed in upcoming .NET Desktop Runtime 7.0.6 release. The latest .NET 8 preview contains the same fix.

## Initiate the upgrade

If you're upgrading multiple projects, start with projects that have no dependencies. In the Matching Game sample, the **MatchingGame** project depends on the **MatchingGame.Logic** library, so **MatchingGame.Logic** should be upgraded first.

> [!TIP]
> Be sure to have a backup of your code, such as in source control or a copy.

Use the following steps to upgrade a project in Visual Studio:

01. Right-click on the **MatchingGame.Logic** project in the **Solution Explorer** window and select **Upgrade**:

    :::image type="content" source="media/index/vs-upgrade.png" alt-text="The .NET Upgrade Assistant's Upgrade menu item in Visual Studio.":::

    A new tab is opened that prompts you to choose how you want the upgrade to be performed.

01. Select **In-place project upgrade**.
01. Next, select the target framework. Based on the type of project you're upgrading, you're presented with different options. **.NET Standard 2.0** is a good choice if the library doesn't rely on a desktop technology like Windows Froms and can be used by both .NET Framework projects and .NET projects. However, the latest .NET releases provide many language and compiler improvements over .NET Standard.

    Select **.NET 7.0** and then select **Next**.

    :::image type="content" source="media/index/vs-target-framework.png" alt-text="The .NET Upgrade Assistant's target framework decision tab.":::

01. A tree is shown with all of the artifacts related to the project, such as code files and libraries. You can upgrade individual artifacts or the entire project, which is the default. Select **Upgrade selection** to start the upgrade.

    When the upgrade is finished, the results are displayed:

    :::image type="content" source="media/index/vs-upgrade-results.png" alt-text="The .NET Upgrade Assistant's upgrade results tab, showing two out of the 13 items were skipped.":::

    Artifacts with a solid green circle were upgraded while empty green circles were skipped. Skipped artifacts mean that the upgrade assistant didn't find anything to upgrade.

Now that the app's supporting library is upgraded, upgrade the main app.

### Upgrade the app

Once all of the supporting libraries are upgraded, the main app project can be upgraded. With the example app, there's only one library project to upgrade, which was upgraded in the previous section.

01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Upgrade**:
01. Select **In-place project upgrade** as the upgrade mode.
01. Select **.NET 7.0** for the target framework and select **Next**.
01. Leave all of the artifacts selected and select **Upgrade selection**.

After the upgrade is complete, the results are shown. Notice how the Windows Forms project has a warning symbol. Expand that and more information is shown about that step:

:::image type="content" source="media/index/vs-upgrade-warning.png" alt-text="The .NET Upgrade Assistant's upgrade results tab, showing some of the result items have warning symbols.":::

Notice that the project upgrade component mentions that the default font has changed. Because the font may affect control layout, you need to check every form and custom control in your project to ensure the UI is arranged correctly.

## Generate a clean build

After your project is upgraded, clean and compile it.

01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Clean**.
01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Build**.

If your application encountered any errors, you can find them in the **Error List** window with a recommendation how to fix them.

<!--
### Visual Basic

Visual Basic language projects require extra configuration.

01. Import the configuration file _My Project\\Application.myapp_ setting. Notice that the `<Compile>` element uses the `Update` attribute instead of the `Include` attribute.

    ```xml
    <ItemGroup>
      <None Include="My Project\Application.myapp">
        <Generator>MyApplicationCodeGenerator</Generator>
        <LastGenOutput>Application.Designer.vb</LastGenOutput>
      </None>
      <Compile Update="My Project\Application.Designer.vb">
        <AutoGen>True</AutoGen>
        <DependentUpon>Application.myapp</DependentUpon>
        <DesignTime>True</DesignTime>
      </Compile>
    </ItemGroup>
    ```

01. Add the `<MyType>WindowsForms</MyType>` setting to the `<PropertyGroup>` element:

    ```xml
    <PropertyGroup>
      (contains settings previously described)

      <MyType>WindowsForms</MyType>
    </PropertyGroup>
    ```

    This setting imports the `My` namespace members Visual Basic programmers are familiar with.

01. Import the namespaces defined by your project.

    Visual Basic projects can automatically import namespaces into every code file. Copy the `<ItemGroup>` elements from the old project file that contain `<Import>` into the new file after the `</PropertyGroup>` closing tag.

    ```xml
    <ItemGroup>
      <Import Include="Microsoft.VisualBasic" />
      <Import Include="System" />
      <Import Include="System.Collections" />
      <Import Include="System.Collections.Generic" />
      <Import Include="System.Data" />
      <Import Include="System.Drawing" />
      <Import Include="System.Diagnostics" />
      <Import Include="System.Windows.Forms" />
      <Import Include="System.Linq" />
      <Import Include="System.Xml.Linq" />
      <Import Include="System.Threading.Tasks" />
    </ItemGroup>
    ```

    If you can't find any `<Import>` statements, or your project fails to compile, make sure you at least have the following `<Import>` statements defined in your project:

    ```xml
    <ItemGroup>
      <Import Include="System.Data" />
      <Import Include="System.Drawing" />
      <Import Include="System.Windows.Forms" />
    </ItemGroup>
    ```

01. From the original project, copy the `<Option*>` and `<StartupObject>` settings to the `<PropertyGroup>` element:

    ```xml
    <PropertyGroup>
      (contains settings previously described)

      <OptionExplicit>On</OptionExplicit>
      <OptionCompare>Binary</OptionCompare>
      <OptionStrict>Off</OptionStrict>
      <OptionInfer>On</OptionInfer>
      <StartupObject>MatchingGame.My.MyApplication</StartupObject>
    </PropertyGroup>
    ```

-->

## Conclusion

The **Windows Forms Matching Game Sample** project is now upgraded to .NET 7. Your results will be different when you migrate your own project. Make sure you take the time to review the [Porting from .NET Framework to .NET](/dotnet/core/porting/) guide and the [Modernize after upgrading to .NET from .NET Framework](/dotnet/core/porting/modernize) article.

[winforms-sample]: https://github.com/dotnet/samples/tree/main/windowsforms/matching-game
