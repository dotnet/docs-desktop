---
title: Migrate a Windows Forms app to .NET 5
description: Learn how to port a .NET Framework Windows Forms application to .NET 5.
ms.date: 11/02/2020
ms.topic: how-to
---

# How to migrate a Windows Forms desktop app to .NET 5

This article describes how to migrate a Windows Forms desktop app from .NET Framework to .NET 5 or later. The .NET SDK includes support for Windows Forms applications. Windows Forms is still a Windows-only framework and only runs on Windows.

Migrating your app from .NET Framework to .NET 5 generally requires a new project file. .NET 5 uses SDK-style project files while .NET Framework typically uses the older Visual Studio project file. If you've ever opened a Visual Studio project file in a text editor, you know how verbose it is. SDK-style projects are smaller and don't require as many entries as the older project file format does.

To learn more about .NET 5, see [Introduction to .NET](/dotnet/core/introduction).

## Prerequisites

- [Visual Studio 2019 version 16.8 Preview](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+desktopguide+winforms)

  - Select the [Visual Studio Desktop workload](/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-workloads).

  - Select the [.NET 5 individual component](/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-individual-components).

- Preview WinForms designer in Visual Studio.

  To enable the designer, go to **Tools** > **Options** > **Environment** > **Preview Features** and select the **Use the preview Windows Forms designer for .NET Core apps** option.

- This article uses the [Matching game](https://github.com/dotnet/samples/tree/master/windowsforms/matching-game/net45/) sample app. If you want to follow along, download and open the application in Visual Studio. Otherwise, use your own app.

### Consider

When migrating a .NET Framework Windows Forms application, there are a few things you must consider.

01. Check that your application is a good candidate for migration.

    Use the [.NET Portability Analyzer](/dotnet/standard/analyzers/portability-analyzer) to determine if your project will migrate to .NET 5. If your project has issues with .NET 5, the analyzer helps you identify those problems. The .NET Portability Analyzer tool can be installed as a Visual Studio extension or used from the command line. For more information, see [.NET Portability Analyzer](/dotnet/standard/analyzers/portability-analyzer).

01. You're using a different version of Windows Forms.

    When .NET Core 3.0 was released, Windows Forms went [open source on GitHub](https://github.com/dotnet/winforms). The code for Windows Forms for .NET 5 is a fork of the .NET Framework Windows Forms codebase. It's possible some differences exist and your app will be difficult to migrate.

01. The [Windows Compatibility Pack][compat-pack] may help you migrate.

    Some APIs that are available in .NET Framework aren't available in .NET 5. The [Windows Compatibility Pack][compat-pack] adds many of these APIs and may help your Windows Forms app become compatible with .NET 5.

01. Update the NuGet packages used by your project.

    It's always a good practice to use the latest versions of NuGet packages before any migration. If your application is referencing any NuGet packages, update them to the latest version. Ensure your application builds successfully. After upgrading, if there are any package errors, downgrade the package to the latest version that doesn't break your code.

## Back up your projects

The first step to migrating a project is to back up your project! If something goes wrong, you can restore your code to its original state by restoring your backup. Don't rely on tools such as the .NET Portability Analyzer to back up your project, even if they seem to. It's best to personally create a copy of the original project.

## NuGet packages

If your project is referencing NuGet packages, you probably have a **packages.config** file in your project folder. With SDK-style projects, NuGet package references are configured in the project file. Visual Studio project files can optionally define NuGet packages in the project file too. .NET 5 doesn't use **packages.config** for NuGet packages. NuGet package references must be migrated into the project file before migration.

To migrate the **packages.config** file, do the following steps:

01. In **Solution explorer**, find the project you're migrating.
02. Right-click on **packages.config** > **Migrate packages.config to PackageReference**.
03. Select all of the top-level packages.

A build report is generated to let you know of any issues migrating the NuGet packages.

## Project file

The next step in migrating your app is converting the project file. As previously stated, .NET 5 uses SDK-style project files and won't load the Visual Studio project files that .NET Framework uses. However, there's the possibility that you're already using SDK-style projects. You can easily spot the difference in Visual Studio. Right-click on the project file in **Solution explorer** and look for the **Edit Project File** menu option. If this menu item is missing, you're using the old Visual Studio project format and need to upgrade.

Convert each project in your solution. If you're using the sample app previously referenced, both the **MatchingGame** and **MatchingGame.Logic** projects would be converted.

To convert a project, do the following steps:

01. In **Solution explorer**, find the project you're migrating.
01. Right-click on the project and select **Unload Project**.
01. Right-click on the project and select **Edit Project File**.
01. Copy-and-paste the project XML into a text editor. You'll want a copy so that it's easy to move content into the new project.
01. Erase the content of the file and paste the following XML:

    ```xml
    <Project Sdk="Microsoft.NET.Sdk">

      <PropertyGroup>
        <OutputType>WinExe</OutputType>
        <TargetFramework>net5.0-windows</TargetFramework>
        <UseWindowsForms>true</UseWindowsForms>
        <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
      </PropertyGroup>

    </Project>
    ```

    > [!IMPORTANT]
    > Libraries don't need to define an `<OutputType>` setting. Remove that entry if you're upgrading a library project.

This XML gives you the basic structure of the project. However, it doesn't contain any of the settings from the old project file. Using the old project information you previously copied to a text editor, do the following steps:

01. Copy the following elements from the old project file into the `<PropertyGroup>` element in the new project file:

    - `<RootNamespace>`
    - `<AssemblyName>`

    Your project file should look similar to the following XML:

    ```xml
    <Project Sdk="Microsoft.NET.Sdk">

      <PropertyGroup>
        <OutputType>WinExe</OutputType>
        <TargetFramework>net5.0-windows</TargetFramework>
        <UseWindowsForms>true</UseWindowsForms>
        <GenerateAssemblyInfo>false</GenerateAssemblyInfo>

        <RootNamespace>MatchingGame</RootNamespace>
        <AssemblyName>MatchingGame</AssemblyName>
      </PropertyGroup>

    </Project>
    ```

01. Copy the `<ItemGroup>` elements from the old project file that contain `<ProjectReference>` or `<PackageReference>` into the new file after the `</PropertyGroup>` closing tag.

    Your project file should look similar to the following XML:

    ```xml
    <Project Sdk="Microsoft.NET.Sdk">

      <PropertyGroup>
        (contains settings previously described)
      </PropertyGroup>

      <ItemGroup>
        <ProjectReference Include="..\MatchingGame.Logic\MatchingGame.Logic.csproj">
          <Project>{36b3e6e2-a9ae-4924-89ae-7f0120ce08bd}</Project>
          <Name>MatchingGame.Logic</Name>
        </ProjectReference>
      </ItemGroup>
      <ItemGroup>
        <PackageReference Include="MetroFramework">
          <Version>1.2.0.3</Version>
        </PackageReference>
      </ItemGroup>

    </Project>
    ```

    The `<ProjectReference>` elements don't need the `<Project>` and `<Name>` children, so you can remove those settings:

    ```xml
    <ItemGroup>
      <ProjectReference Include="..\MatchingGame.Logic\MatchingGame.Logic.csproj" />
    </ItemGroup>
    ```

### Resources and settings

One thing to note about the difference between .NET Framework projects and the SDK-style projects used by .NET 5 is that .NET Framework projects use an opt-in model for code files. Any code file you want to compile needs to be explicitly defined in your project file. SDK-style projects are reverse, they default to opt-out behavior: All code files starting from the project's directory and below are automatically included in your project. You don't need to migrate these entries if they are simple and without settings. This is the same for other common files such as _resx_.

Windows Forms projects also include Windows Form project specific files, such as _Properties/Settings.settings_ and _Properties/Resources.resx_. These files may need to be migrated they are declared in your original project.

Copy those entries from the old project file into an `<ItemGroup>` element in the new project. After you copy the entries, change any `<Compile Include="value">` or `<EmbeddedResource Include="value">` elements to instead use `Update` instead of `Include`.

- Import the configuration for the _Settings.settings_ file. Notice that the `<Compile>` entry's `Update` attribute was changed from `Include` to `Update` because code files are already included:

  ```xml
  <ItemGroup>
    <None Include="Properties\Settings.settings">
      <Generator>SettingsSingleFileGenerator</Generator>
      <LastGenOutput>Settings.Designer.cs</LastGenOutput>
    </None>
    <Compile Update="Properties\Settings.Designer.cs">
      <AutoGen>True</AutoGen>
      <DependentUpon>Settings.settings</DependentUpon>
      <DesignTimeSharedInput>True</DesignTimeSharedInput>
    </Compile>
  </ItemGroup>
  ```

  Notice that the _Properties\Settings.settings_ entry remained `Include`. The project doesn't automatically include _settings_ files.

  > [!IMPORTANT]
  > **Visual Basic** projects typically use the folder _My Project_ while C# projects typically use the folder _Properties_ for the default project settings file.
  
- Import the configuration for any _resx_ file, such as the _properties/Resources.resx_ file. Notice that the `Include` was changed to `Update` on both the `<Compile>` and `<EmbeddedResource>` elements, and `<SubType>` was removed from `<EmbeddedResource>`:

  ```xml
  <ItemGroup>
    <EmbeddedResource Include="Properties\Resources.resx">
      <Generator>ResXFileCodeGenerator</Generator>
      <LastGenOutput>Resources.Designer.cs</LastGenOutput>
    </EmbeddedResource>
    <Compile Update="Properties\Resources.Designer.cs">
      <AutoGen>True</AutoGen>
      <DependentUpon>Resources.resx</DependentUpon>
      <DesignTime>True</DesignTime>
    </Compile>
  </ItemGroup>
  ```

  > [!IMPORTANT]
  > **Visual Basic** projects typically use the folder _My Project_ while C# projects typically use the folder _Properties_ for the default project resource file.

### Visual Basic

Visual Basic language projects require extra configuration.

01. Import the configuration file _My Project\Application.myapp_ setting. Notice that the `<Compile>` element uses the `Update` attribute instead of the `Include` attribute.

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

### Reload the project

After you convert a project to the new SDK-style format, reload the project in Visual Studio:

01. In **Solution Explorer**, find the project you converted.
01. Right-click on the project and select **Reload Project**.

    If the project fails to load, you may have introduced a mistake in the XML of the project. Open the project file for editing and try to identify and fix the mistake. If you can't find a mistake, try starting over.

## Edit App.config

If your app has an _App.config_ file, remove the `<supportedRuntime>` element:

```xml
<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
```

There are some things you should consider with the *App.config* file. The *App.config* file in .NET Framework was used not only to configure the app, but to configure runtime settings and behavior, such as logging. The *App.config* file in .NET 5+ (and .NET Core) is no longer used for runtime configuration. If your *App.config* file has these sections, they won't be respected.

## Add the compatibility package

If your project file is loading correctly, but compilation fails for your project and you receive errors similar to the following:

- **The type or namespace \<some name> could not be found**
- **The name \<some name> does not exist in the current context**

You may need to add the [`Microsoft.Windows.Compatibility`](https://www.nuget.org/packages/Microsoft.Windows.Compatibility/) package to your app. This package adds ~21,000 .NET APIs from .NET Framework, such as the `System.Configuration.ConfigurationManager` class and APIs for interacting with the Windows Registry. Add the `Microsoft.Windows.Compatibility` package.

Edit your project file and add the following `<ItemGroup>` element:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Windows.Compatibility" Version="5.0.0" />
</ItemGroup>
```

## Test your app

After you've finished migrating your app, test it!

## Next steps

- Learn about [breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).
- Read more about the [Windows Compatibility Pack][compat-pack].

[compat-pack]: /dotnet/core/porting/windows-compat-pack
