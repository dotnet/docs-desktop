---
title: What's new in Windows Forms .NET 8
description: Learn about what's new in Windows Forms for .NET 8. Windows Forms. .NET provides new features and enhancements over .NET 7.
ms.date: 11/11/2024
ms.topic: whats-new
#customer intent: As a developer, I want to know what's changed so that I can remain up-to-date.
---

# What's new in Windows Forms for .NET 8

This article describes some of the new Windows Forms features and enhancements in .NET 8.

There are a few breaking changes you should be aware of when migrating from .NET Framework to .NET 8. For more information, see [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).

## Data binding improvements

A new data binding engine was in preview with .NET 7, and is now fully enabled in .NET 8. Though not as extensive as the existing Windows Forms data binding engine, this new engine is modeled after WPF, which makes it easier to implement MVVM design principles.

The enhanced data binding capabilities make it simpler to fully utilize the MVVM pattern and employ object-relational mappers from ViewModels in Windows Forms. This reduces the amount of code in code-behind files. More importantly, it enables code sharing between Windows Forms and other .NET GUI frameworks like WPF, UWP/WinUI, and .NET MAUI. It's important to note that while the previously mentioned GUI frameworks use XAML as a UI technology, XAML isn't coming to Windows Forms.

The <xref:System.Windows.Forms.IBindableComponent> interface and the <xref:System.Windows.Forms.BindableComponent> class drive the new binding system. <xref:System.Windows.Forms.Control> implements the interface and provides new data binding capabilities to Windows Forms.

## Button commands

Button commands were in preview with .NET 7, and is now fully enabled in .NET 8. Similar to WPF, the instance of an object that implements the <xref:System.Windows.Input.ICommand> interface can be assigned to the button's <xref:System.Windows.Forms.ButtonBase.Command%2A> property. When the button is clicked, the command is invoked.

An optional parameter can be provided when the command is invoked, by the specifying a value for the button's <xref:System.Windows.Forms.ButtonBase.CommandParameter%2A> property.

The `Command` and `CommandParameter` properties are set in the designer through the **Properties** window, under **(DataBindings)**, as illustrated by the following image.

:::image type="content" source="media/net80/commands.png" alt-text="The Visual Studio properties window highlighting a Windows Forms' Button's Command and CommandParameter properties.":::

Buttons also listen to the <xref:System.Windows.Input.ICommand.CanExecuteChanged%2A?displayProperty=nameWithType> event, which causes the control to query the <xref:System.Windows.Input.ICommand.CanExecute%2A?displayProperty=nameWithType> method. When that method returns `true`, the control is enabled; the control is disabled when `false`is returned.

## Visual Studio DPI improvements

Visual Studio 2022 17.8 Introduces DPI-unaware designer tabs. Previously, the Windows Designer tab in Visual Studio ran at the DPI of Visual Studio. This causes problems when you're designing a DPI-unaware Windows Forms app. Now you can ensure that the designer runs at the same scale as you want the app to run, either DPI-aware or not. Before this feature was introduced, you had to run Visual Studio in DPI-unaware mode, which made Visual Studio itself blurry when scaling was applied in Windows. Now you can leave Visual Studio alone and let the designer run DPI-unaware.

You can enable the DPI-unaware designer for the Windows Forms project by adding `<ForceDesignerDPIUnaware>` to the project file, and setting the value to `true`.

:::code language="xml" source="./snippets/net80/csharp/snippets.csproj" range="3-11" highlight="7":::

> [!IMPORTANT]
> Visual Studio reads this setting when the project is loaded, and not when it's changed. After changing this setting, unload and reload your project to get Visual Studio to respect it.

## High DPI improvements

High DPI rendering with <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2> has been improved:

- Correctly scale nested controls. For example, a button that's in a panel, which is placed on a tab page.
- Scale <xref:System.Windows.Forms.Form.MaximumSize?displayProperty=nameWithType> and <xref:System.Windows.Forms.Form.MinimumSize?displayProperty=nameWithType> properties based on the current monitor DPI settings.

  Starting with .NET 8, this feature is enabled by default and you need to opt out of it to revert to the previous behavior.
  
  To disable the feature, add `System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi` to the `configProperties` setting in [_runtimeconfig.json_](/dotnet/core/runtime-config/#runtimeconfigjson), and set the value to false:
  
  ```json
  {
    "runtimeOptions": {
      "tfm": "net8.0",
      "frameworks": [
          ...
      ],
      "configProperties": {
        "System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi": false,
      }
    }
  }
  ```

## Miscellaneous improvements

Here are some other notable changes:

- The code that handled `FolderBrowserDialog` was improved, fixing a few memory leaks.
- The code base for Windows Forms has been slowly enabling C# nullability, rooting out any potential null-reference errors.
- The `System.Drawing` source code was migrated to the [Windows Forms GitHub repository](https://github.com/dotnet/winforms).
- Modern Windows icons can be accessed by a new API, <xref:System.Drawing.SystemIcons.GetStockIcon%2A?displayProperty=fullName>. The <xref:System.Drawing.StockIconId?displayProperty=fullName> enumeration lists all of the available system icons.
- More designers are available at run-time now. For more information, see [GitHub issue #4908](https://github.com/dotnet/winforms/issues/4908).
