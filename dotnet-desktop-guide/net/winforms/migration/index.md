---
title: Upgrade a .NET Framework WinForms app to .NET 8
description: Learn how to upgrade a .NET Framework (or previous .NET) Windows Forms application to .NET 8 with the Upgrade Assistant in Visual Studio.
ms.date: 04/08/2024
ms.topic: how-to
#customer intent: As a developer, I want to use the .NET Upgrade Assistant to automatically upgrade my projects to the latest version of .NET.
---

# Upgrade a .NET Framework Windows Forms desktop app to .NET 8

This article describes how to upgrade a Windows Forms desktop app to .NET 8 using the Upgrade Assistant. Even though Windows Forms runs on .NET, a cross-platform technology, Windows Forms is still a Windows-only framework. The following Windows Forms-related project types can be upgraded with the .NET Upgrade Assistant:

- Windows Forms project
- Control library
- .NET library

## Prerequisites

- Windows Operating System.
- [Download and extract the demo app used with this article.][winforms-sample]
- [Visual Studio 2022 version 17.8 or later to target .NET 8.](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022+desktopguide+winforms+migration)
- [.NET Upgrade Assistant extension for Visual Studio.](/dotnet/core/porting/upgrade-assistant-install#install-the-visual-studio-extension)

## Upgrade the dependencies first

If you're upgrading multiple projects, start with projects that have no dependencies. In the Matching Game sample, the **MatchingGame** project depends on the **MatchingGame.Logic** library, so **MatchingGame.Logic** should be upgraded first.

> [!TIP]
> Be sure to have a backup of your code, such as in source control or a copy.

Use the following steps to upgrade a project in Visual Studio:

01. Right-click on the **MatchingGame.Logic** project in the **Solution Explorer** window and select **Upgrade**:

    :::image type="content" source="media/index/vs-upgrade.png" alt-text="A screenshot of the .NET Upgrade Assistant's Upgrade menu item in Visual Studio.":::

    A new tab is opened that prompts you to choose which type of upgrade you want to perform.

01. Select **Upgrade project to a newer .NET version**.

    :::image type="content" source="media/index/step-2-initial-tab.png" alt-text="A screenshot of the .NET Upgrade Assistant tab. The 'Upgrade project to a newer .NET version' option is highlighted.":::

01. Select **In-place project upgrade**.

    :::image type="content" source="media/index/step-3-project-upgrade-item.png" alt-text="A screenshot of the .NET Upgrade Assistant tab. The 'In-place project upgrade' option is highlighted.":::

01. Next, select the target framework. Based on the type of project you're upgrading, you're presented with different options. **.NET Standard 2.0** can be used by both .NET Framework and .NET. This is a good choice if the library doesn't rely on a desktop technology like Windows Forms. However, the latest .NET releases provide many language and compiler improvements over .NET Standard.

    Select **.NET 8.0** and then select **Next**.

    :::image type="content" source="media/index/step-4-net8.png" alt-text="A screenshot of the .NET Upgrade Assistant. The target framework ptompt is open and .NET 8 is highlighted along with the 'Next' button.":::

01. A tree is shown with all of the artifacts related to the project, such as code files and libraries. You can upgrade individual artifacts or the entire project, which is the default. Select **Upgrade selection** to start the upgrade.

01. When the upgrade is finished, the results are displayed:

    :::image type="content" source="media/index/step-5-results1.png" alt-text="A screenshot of the .NET Upgrade Assistant's upgrade results tab, showing the migrated items from the project.":::

    Artifacts with a solid green circle were upgraded while empty green circles were skipped. Skipped artifacts mean that the upgrade assistant didn't find anything to upgrade.

Now that the app's supporting library is upgraded, upgrade the main app.

## Upgrade the main project

Once all of the supporting libraries are upgraded, the main app project can be upgraded. With the example app, there's only one library project to upgrade, which was upgraded in the previous section.

01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Upgrade**:
01. Select **Upgrade project to a newer .NET version**.
01. Select **In-place project upgrade** as the upgrade mode.
01. Select **.NET 8.0** for the target framework and select **Next**.
01. Leave all of the artifacts selected and select **Upgrade selection**.

After the upgrade is complete, the results are shown. Notice how the Windows Forms project has a warning symbol. Expand that item and more information is shown about that step:

:::image type="content" source="media/index/step-final-results2.png" alt-text="A screenshot of the .NET Upgrade Assistant's upgrade results tab, showing some of the result items have warning symbols.":::

Notice that the project upgrade component mentions that the default font has changed. Because the font may affect control layout, you need to check every form and custom control in your project to ensure the UI is arranged correctly.

## Generate a clean build

After your main project is upgraded, clean and compile it.

01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Clean**.
01. Right-click on the **MatchingGame** project in the **Solution Explorer** window and select **Build**.

If your application encountered any errors, you can find them in the **Error List** window with a recommendation how to fix them.

The **Windows Forms Matching Game Sample** project is now upgraded to .NET 8.

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

## Related content

- [Porting from .NET Framework to .NET.](/dotnet/core/porting/)

  The porting guide provides an overview of what you shuold consider when porting your code from .NET Framework to .NET. The complexity of your projects dictates how much work you'll do after the initial migration of the project files.

- [Modernize after upgrading to .NET from .NET Framework.](/dotnet/core/porting/modernize)

  The world of .NET has changed a lot since .NET Framework. This link provides some information about how to modernize your app after you've upgraded it.

[winforms-sample]: https://github.com/dotnet/samples/tree/main/windowsforms/matching-game
