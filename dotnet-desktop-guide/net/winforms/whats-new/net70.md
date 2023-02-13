---
title: What's new in Windows Forms .NET 7
description: Learn about what's new in Windows Forms for .NET 7. Windows Forms. .NET provides new features and enhancements over .NET Framework.
ms.date: 02/08/2023
ms.topic: conceptual
---

# What's new for .NET 7 (Windows Forms .NET)

This article describes some of the new Windows Forms features and enhancements in .NET 7.

There are a few breaking changes you should be aware of when migrating from .NET Framework to .NET 7. For more information, see [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).

## High DPI improvements

High DPI rendering with <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2> has been improved:

- Correctly scale nested controls. For example, a button that's in a panel, which is placed on a tab page.
- Scale <xref:System.Windows.Forms.Form.MaximumSize?displayProperty=nameWithType> and <xref:System.Windows.Forms.Form.MinimumSize?displayProperty=nameWithType> properties based on the current monitor DPI settings for applications that run `ApplicationHighDpiMode` set to `PerMonitorV2`.

  In .NET 7, this feature is disabled by default and you must opt in to receive this change. Starting with .NET 8, this feature is enabled by default and you need to opt out of it to revert to the previous behavior.  
  
  To enable feature, set the `configProperties` setting in [_runtimeconfig.json_](/dotnet/core/runtime-config/#runtimeconfigjson):
  
  ```json
  {
    "runtimeOptions": {
      "tfm": "net7.0",
      "frameworks": [
          ...
      ],
      "configProperties": {
        "System.Windows.Forms.ScaleTopLevelFormMinMaxSizeForDpi": true,
      }
    }
  }
  ```

## Accessibility improvements and fixes

This release adds further improvements to accessibility, including but not limited to the following items:

- Many announcement-related issues observed in screen readers have been addressed, ensuring the information about controls is correct. For example, <xref:System.Windows.Forms.ListView> now correctly announces when a group is expanded or collapsed.

- More controls now provide UI Automation support:
  - <xref:System.Windows.Forms.TreeView>
  - <xref:System.Windows.Forms.DateTimePicker>
  - <xref:System.Windows.Forms.ToolStripContainer>
  - <xref:System.Windows.Forms.ToolStripPanel>
  - <xref:System.Windows.Forms.FlowLayoutPanel>
  - <xref:System.Windows.Forms.TableLayoutPanel>
  - <xref:System.Windows.Forms.SplitContainer>
  - <xref:System.Windows.Forms.PrintPreviewControl>
  - <xref:System.Windows.Forms.WebBrowser>

- Memory leaks related to running a Windows Forms application under assistive tools, such as Narrator, have been fixed.
- Assistive tools now accurately draw focus indicators and report correct bounding rectangles for nested forms and some elements of composite controls, such as <xref:System.Windows.Forms.DataGridView>, <xref:System.Windows.Forms.ListView>, and <xref:System.Windows.Forms.TabControl>.
- The Automation UI [ExpandCollapse Control Pattern](/windows/win32/winauto/uiauto-implementingexpandcollapse) has been properly implemented in <xref:System.Windows.Forms.ListView>, <xref:System.Windows.Forms.TreeView>, and <xref:System.Windows.Forms.PropertyGrid> controls, and only activates for expandable items.
- Various color contrast ratio corrections in controls.
- Visibility improvements for <xref:System.Windows.Forms.ToolStripTextBox> and <xref:System.Windows.Forms.ToolStripButton> in high-contrast themes.

## Data binding improvements (preview)

While Windows Forms already had a powerful binding engine, a more modern form of data binding, similar to data binding provided by WPF, is being introduced.

The new data binding features allow you to fully embrace the MVVM pattern and the use of object-relational mappers from ViewModels in Windows Forms easier than before. This, in turn, makes it possible to reduce code in the code-behind files, and opens new testing possibilities. More importantly, it enables code sharing between Windows Forms and other .NET GUI frameworks such as WPF, UWP/WinUI, and MAUI. And to clarify a commonly asked question, there aren't any plans to introduce XAML in Windows Forms.

These new data binding features are in preview for .NET 7, and more work on this feature will happen in .NET 8.

To enable the new binding, add the `EnablePreviewFeatures` setting to your project file. This is supported in both C# and Visual Basic.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <!-- other settings -->

  <PropertyGroup>
    <EnablePreviewFeatures>true</EnablePreviewFeatures>
  </PropertyGroup>

</Project>
```

The following code snippet demonstrates the new properties, events, and methods added to the various classes in Windows Forms. Even though the following code example is in C#, it also applies to Visual Basic.

```csharp
public class Control  {
    [BindableAttribute(true)]
    public virtual object DataContext { get; set; }
    [BrowsableAttribute(true)]
    public event EventHandler DataContextChanged;
    protected virtual void OnDataContextChanged(EventArgs e);
    protected virtual void OnParentDataContextChanged(EventArgs e);
}

[RequiresPreviewFeaturesAttribute]
public abstract class BindableComponent : Component, IBindableComponent, IComponent, IDisposable {
    protected BindableComponent();
    public BindingContext? BindingContext { get; set; }
    public ControlBindingsCollection DataBindings { get; }
    public event EventHandler BindingContextChanged;
    protected virtual void OnBindingContextChanged(EventArgs e);
}

public abstract class ButtonBase : Control {
    [BindableAttribute(true)]
    [RequiresPreviewFeaturesAttribute]
    public ICommand? Command { get; set; }
    [BindableAttribute(true)]
    public object? CommandParameter { [RequiresPreviewFeaturesAttribute] get; [RequiresPreviewFeaturesAttribute] set; }
    [RequiresPreviewFeaturesAttribute]
    public event EventHandler? CommandCanExecuteChanged;
    [RequiresPreviewFeaturesAttribute]
    public event EventHandler? CommandChanged;
    [RequiresPreviewFeaturesAttribute]
    public event EventHandler? CommandParameterChanged;
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnCommandCanExecuteChanged(EventArgs e);
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnCommandChanged(EventArgs e);
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnCommandParameterChanged(EventArgs e);
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnRequestCommandExecute(EventArgs e);
}

public abstract class ToolStripItem : BindableComponent, IComponent, IDisposable, IDropTarget {
    [BindableAttribute(true)]
    [RequiresPreviewFeaturesAttribute]
    public ICommand Command { get; set; }
    [BindableAttribute(true)]
    public object CommandParameter { [RequiresPreviewFeaturesAttribute] get; [RequiresPreviewFeaturesAttribute] set; }
    [RequiresPreviewFeaturesAttribute]
    public event EventHandler CommandCanExecuteChanged;
    [RequiresPreviewFeaturesAttribute]
    public event EventHandler CommandChanged;
    [RequiresPreviewFeaturesAttribute]
    public event EventHandler CommandParameterChanged;
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnCommandCanExecuteChanged(EventArgs e);
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnCommandChanged(EventArgs e);
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnCommandParameterChanged(EventArgs e);
    [RequiresPreviewFeaturesAttribute]
    protected virtual void OnRequestCommandExecute(EventArgs e);
}
```

## Miscellaneous improvements

Here are some other notable changes:

- Drag-and-drop handling matches the Windows drag-and-drop functionality with richer display effects such as icons and text labels.
- Folder and file dialogs allow for more options:
  - Add to recent
  - Check write access
  - Expanded mode
  - OK requires interaction
  - Select read-only
  - Show hidden files
  - Show pinned places
  - Show preview
- <xref:System.Windows.Forms.ErrorProvider> has a <xref:System.Windows.Forms.ErrorProvider.HasErrors> property now.
- Form's snap layout is fixed for Windows 11.

## See also

- [.NET Blog - What's new in Windows Forms in .NET 7](https://devblogs.microsoft.com/dotnet/winforms-enhancements-in-dotnet-7)
- [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms)
- [Tutorial: Create a new WinForms app](../get-started/create-app-visual-studio.md)
- [How to migrate a Windows Forms desktop app to .NET 5](../migration/index.md)
