---
title: Migrate a Windows Forms app to .NET 5
description: Teaches you how to port a .NET Framework Windows Forms application to .NET 5.
ms.date: 11/02/2020
ms.topic: how-to
---

# How to migrate a Windows Forms desktop app to .NET 5

This article describes how to migrate your Windows Forms-based desktop app from .NET Framework to .NET 5 or later. The .NET SDK includes support for Windows Forms applications. Windows Forms is still a Windows-only framework and only runs on Windows.

Migrating your app from .NET Framework to .NET 5 generally requires a new project file. .NET 5 uses SDK-style project files while .NET Framework typically uses the older Visual Studio project file. If you've ever opened a Visual Studio project file in a text editor, you know how verbose it is. SDK-style projects are smaller and don't require as many entries as their counterparts do.

To learn more about the benefits of .NET (not .NET Framework), see [Introduction to .NET](/dotnet/core/introduction).

## Prerequisites

- [Visual Studio 2019 version 16.8 Preview](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+desktopguide+winforms)

  - Enable the [Visual Studio Desktop workload](/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-workloads).

  - Enable the [.NET 5 individual component](/visualstudio/install/modify-visual-studio?view=vs-2019&preserve-view=true#modify-individual-components).

- Preview WinForms designer in Visual Studio.

  To enable the designer, go to **Tools** > **Options** > **Environment** > **Preview Features** and select the **Use the preview Windows Forms designer for .NET Core apps** option.

- This article uses the [Matching game]() sample app. If you want to follow along, download and open the application in Visual Studio. Otherwise, use your own app.

- Backup your project!

  Before migrating your app to .NET 5, backup your project! Incase something goes wrong and you want to revert back to .NET Framework, you can easily go back by simply restoring your backed up project.

### Consider

When migrating a .NET Framework Windows Forms application, there are a few things you must consider.

01. Check that your application is a good candidate for migration.

    Use the [.NET Portability Analyzer](/dotnet/standard/analyzers/portability-analyzer) to determine if your project will migrate to .NET 5. If your project has issues with .NET 5, the analyzer helps you identify those problems.

01. You're using a different version of Windows Forms.

    When .NET Core 3.0 was released, Windows Forms went [open source on GitHub](https://github.com/dotnet/winforms). The code for Windows Forms for .NET 5 is a fork of the .NET Framework Windows Forms codebase. It's possible some differences exist and your app won't migrate.

01. The [Windows Compatibility Pack][compat-pack] may help you migrate.

    Some APIs that are available in .NET Framework aren't available in .NET 5. The [Windows Compatibility Pack][compat-pack] adds many of these APIs and may help your Windows Forms app become compatible with .NET 5.

01. Update the NuGet packages used by your project.

    It's always a good practice to use the latest versions of NuGet packages before any migration. If your application is referencing any NuGet packages, update them to the latest version. Ensure your application builds successfully. After upgrading, if there are any package errors, downgrade the package to the latest version that doesn't break your code.

## Portability analyzer

It's best to use the .NET Portability Analyzer to scan your project for any issues you'll want to address before or after migrating your app to .NET 5. The .NET Portability Analyzer tool can be installed as a Visual Studio extension or used from the command line. For more information, see [.NET Portability Analyzer](/dotnet/standard/analyzers/portability-analyzer).

## NuGet packages

If your project is referencing NuGet packages, you probably have a **packages.config** file in your project folder. With SDK-style projects, NuGet package references are configured in the project file. Visual Studio project files can optionally define NuGet packages in the project file too. Since .NET 5 doesn't use **packages.config** for NuGet packages, these package references need to be migrated into the project file of the .NET Framework version of the app.

To migrate the **packages.config** file, do the following:

01. In **Solution explorer** find the project you're migrating.
02. Right-click on **packages.config** > **Migrate packages.config to ProjectReference**.
03. Select all of the top-level packages.

A build report is generated to let you know of any issues migrating the NuGet packages.

## Project file

The next step in migrating your app is converting the project file. As previously stated, .NET 5 uses SDK-style project files and won't load the Visual Studio project files that .NET Framework uses. However, there is the possibility that you're already using SDK-style projects. You can easily spot the difference in Visual Studio. Right-click on the project file in **Solution explorer** and look for the **Edit Project File** menu option. If this menu item is missing, you're using the old Visual Studio project format and need to upgrade.

To upgrade, do the following:

01. In **Solution explorer** find the project you're migrating.
01. Right-click on the project and select **Unload Project**.
01. Right-click on the project and select **Edit Project File**.
01. Copy-and-paste the project XML into a text text editor. You'll want a copy so that it's easy move content into the new project.
01. Erase the content of the file and paste in the the following:

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

This gives you the basic structure of the project, but it doesn't contain any of the settings from the old project file such as NuGet package references or project references. Using the old project information you copied to a text editor, copy the following:

01. With the `<PropertyGroup>` element in the new project, copy the following from the old project:

    - `<RootNamespace>`
    - `<AssemblyName>`

    Your project file should look similar to the following:

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

01. After the `</PropertyGroup>` element closure, copy the `<ItemGroup>` entries from the old project that contain `<ProjectReference>` or `<PackageReference>`.

    Your project file should look similar to the following:

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

    The `<ProjectReference>` elements don't need the `<Project>` and `<Name>` children, you can remove those:

    ```xml
    <ItemGroup>
      <ProjectReference Include="..\MatchingGame.Logic\MatchingGame.Logic.csproj" />
    </ItemGroup>
    ```

### Resources and settings

There are some other default files that come with every Windows Forms for .NET Framework app that your project probably still has, such as the *properties/Settings.settings* file and any *resx* file. Copy those entries from the old project file into an `<ItemGroup>` entry in the new project. After you copy the entries, change any `<Compile Include="value">` or `<EmbeddedResource Include="value">` to instead use `Update` otherwise you'll get a compiler error.

- Import the configuration for the *Settings.settings* file. Note that `Include` was changed to `Update` on the `<Compile>` element:

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

- Import the configuration for any *resx* file, such as the *properties/Resources.resx* file. Note that `Include` was changed to `Update` on both the `<Compile>` and `<EmbeddedResource>` elements, and `<SubType>` was removed from `<EmbeddedResource>`:

  ```xml
  <ItemGroup>
    <EmbeddedResource Update="Properties\Resources.resx">
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

Convert each project in your solution. In the case of this example, the **MatchingGame.Logic** project would also be converted.

## Edit App.config

If the *App.config* file, remove the `<supportedRuntime>` element.

```xml
<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
```

There are some things you should consider with the *App.config* file. The *App.config* file in .NET Framework was used to not only configure the app, but to configure runtime settings and behavior, such as logging. The *App.config* file in .NET 5+ (and .NET Core) is no longer used for runtime configuration. If your *App.config* file has these sections, they either won't be respected.

## Add the compatibility package

If you can't compile and receive errors similar to **The type or namespace \<some name> could not be found** or **The name \<some name> does not exist in the current context**, you may need to add the **Microsoft.Windows.Compatibility** package to your app. This package adds ~21K .NET APIs from .NET Framework, such as the `System.Configuration.ConfigurationManager` class and interacting with the Windows Registry.

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Windows.Compatibility" Version="5.0.0-rc.2.20475.5" />
</ItemGroup>
```

## Test your app

After you've finished migrating your app, test it! Testing is the best way to determine if there are behavior changes you need to address or if there are any bugs you need to fix.

## Next steps

- Learn about [breaking changes from .NET Framework to .NET Core](/dotnet/core/compatibility/fx-core#windows-forms).
- Read more about the [Windows Compatibility Pack][compat-pack].

[compat-pack]: /dotnet/core/porting/windows-compat-pack
