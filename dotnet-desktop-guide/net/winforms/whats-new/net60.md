---
title: What's new in Windows Forms .NET 6
description: Learn about what's new in Windows Forms for .NET 6. Windows Forms. .NET provides new features and enhancements over .NET Framework.
ms.date: 10/28/2021
ms.topic: conceptual
---

# What's new for .NET 6 (Windows Forms .NET)

Windows Forms for .NET 6 adds the following features and enhancements over .NET Framework.

There are a few breaking changes you should be aware of when migrating from .NET Framework to .NET 6. For more information, see [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).

## Updated templates for C\#

.NET 6 introduced many [changes to the standard console application templates](/dotnet/core/whats-new/dotnet-6#c-10-and-templates). In line with those changes, the Windows Forms templates for C# have been updated to enable [`global using` directives](/dotnet/core/project-sdk/overview#implicit-using-directives), [file-scoped namespaces](/dotnet/csharp/fundamentals/types/namespaces), and [nullable reference types](/dotnet/csharp/nullable-references) by default.

One feature of the new C# templates that has not been carried forward with Windows Forms is [top-level statements](/dotnet/csharp/fundamentals/program-structure/top-level-statements). The typical Windows Forms application requires the `[STAThread]` attribute and consists of multiple types split across multiple files, such as the designer code files, so using **top-level statements** doesn't make sense.

## New application bootstrap

The templates that generate a new Windows Forms application create a `Main` method which serves as the entry point for your application when it runs. This method contains code that configures Windows Forms and displays the first form, known as the bootstrap code:

```csharp
class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
}
```

In .NET 6, these templates have been modified to use the new bootstrap system, invoked by the `ApplicationConfiguration.Initialize` method.

```csharp
class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
```

This method is automatically generated at compile time and contains the code to configure Windows Forms. The project file can control these settings now too, and you can avoid configuring it in code. For example, the generated method looks similar to the following code:

```csharp
public static void Initialize()
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.SetHighDpiMode(HighDpiMode.SystemAware);
}
```

## Project-level application settings

## Change the default font

The default font used by Windows Forms, represented by the read-only [`Control.DefaultFont`](https://docs.microsoft.com/dotnet/api/system.windows.forms.control.defaultfont?view=windowsdesktop-6.0) property, can now be changed.

Windows Forms on .NET Core 3.0 introduced a new default font for Windows Forms: **Segoe UI, 9pt**. This font better aligned to the [Windows user experience (UX) guidelines](https://docs.microsoft.com/windows/win32/uxguide/vis-fonts#fonts-and-colors). However, .NET Framework uses **Microsoft Sans Serif, 8.25pt** as the default font. This change made it harder for some customers to migrate their large applications that utilized a pixel-perfect layout from .NET Framework to .NET. The only way to change the font for the whole application was to edit every form in the project, setting the <xref:System.Windows.Forms.Control.Font> property to an alternate font.

The default font can now be set in two ways:

- Set the default font in the project file to be used by the [application bootstrap](#new-application-bootstrap) code:

  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
  
    <!-- other settings -->
  
    <PropertyGroup>
      <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>
    </PropertyGroup>
  
  </Project>
  
 \- or -
 
 - Call the the <xref:System.Windows.Forms.Application.SetDefaultFont%2A?displayProperty=nameWithType> API in the old way (but with no designer support):

 ````csharp
  class Program
  {
      [STAThread]
      static void Main()
      {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.SetHighDpiMode(HighDpiMode.SystemAware);
          Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8.25f));
          Application.Run(new Form1());
      }
  }

## Visual Studio designer improvements

TODO: Text
TODO: Image comparing differences

## New API

- <xref:System.Windows.Forms.Application.SetDefaultFont?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.IsAncestorSiteInDesignMode?displayProperty=fullName>
- <xref:System.Windows.Forms.ProfessionalColors.StatusStripBorder?displayProperty=fullName>
- <xref:System.Windows.Forms.ProfessionalColorTable.StatusStripBorder?displayProperty=fullName>
- <xref:Microsoft.VisualBasic.ApplicationServices?displayProperty=fullName> introduces the following API:

  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventHandler?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs.MinimumSplashScreenDisplayTime?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs.MinimumSplashScreenDisplayTime?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs.Font?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs.Font?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs.HighDpiMode?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.ApplyApplicationDefaultsEventArgs.HighDpiMode?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.ApplyApplicationDefaults?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.HighDpiMode?displayProperty=fullName>
  - <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.HighDpiMode?displayProperty=fullName>

## Updated APIs

- <xref:System.Windows.Forms.Control.Invoke?displayProperty=fullName> now accepts <xref:System.Action?displayProperty=fullName> and <xref:System.Func%601?displayProperty=fullName> as input parameters.
- <xref:System.Windows.Forms.Control.BeingInvoke?displayProperty=fullName> now accepts <xref:System.Action?displayProperty=fullName> as an input parameter.
- <xref:System.Windows.Forms.DialogResult?displayProperty=fullName> is extended with the following members:

  - `TryAgain`
  - `Continue`

- <xref:System.Windows.Forms.Form?displayProperty=fullName> is extended with the following property:

  - <xref:System.Windows.Forms.Form.MdiChildrenMinimizedAnchorBottom?displayProperty=fullName>

- <xref:System.Windows.Forms.MessageBoxButtons?displayProperty=fullName> is extended with the following member:

  - `CancelTryContinue`

- <xref:System.Windows.Forms.MessageBoxDefaultButton?displayProperty=fullName> is extended with the following member:

  - `Button4`

- <xref:System.Windows.Forms.LinkClickedEventArgs?displayProperty=fullName> has now a new constructor and extended with the following properties:

  - <xref:System.Windows.Forms.LinkClickedEventArgs.LinkLength?displayProperty=fullName>
  - <xref:System.Windows.Forms.LinkClickedEventArgs.LinkStart?displayProperty=fullName>

- <xref:System.Windows.Forms.NotifyIcon.Text?displayProperty=fullName> is now limited to 127 characters (from 63).

## Enhanced features

- High DPI improvements.
TODO: @dreddy-work to provide text.
- Windows 11 style default tooltip behavior makes the tooltip remain open when mouse hovers over it, and not disappear automatically. The tooltip can be dismissed by CONTROL or ESCAPE keys.
- Microsoft UI Automation patterns work better with accessibility tools like Narrator and Jaws.


## More runtime designers

The missing designers and designer-related infrastructure that existed in .NET Framework and enable building a general-purpose designer (e.g., a report designer) have been added:

- System.ComponentModel.Design.ComponentDesigner
- System.Windows.Forms.Design.ButtonBaseDesigner
- System.Windows.Forms.Design.ComboBoxDesigner
- System.Windows.Forms.Design.ControlDesigner
- System.Windows.Forms.Design.DocumentDesigner
- System.Windows.Forms.Design.DocumentDesigner
- System.Windows.Forms.Design.FormDocumentDesigner
- System.Windows.Forms.Design.GroupBoxDesigner
- System.Windows.Forms.Design.LabelDesigner
- System.Windows.Forms.Design.ListBoxDesigner
- System.Windows.Forms.Design.ListViewDesigner
- System.Windows.Forms.Design.MaskedTextBoxDesigner
- System.Windows.Forms.Design.PanelDesigner
- System.Windows.Forms.Design.ParentControlDesigner
- System.Windows.Forms.Design.ParentControlDesigner
- System.Windows.Forms.Design.PictureBoxDesigner
- System.Windows.Forms.Design.RadioButtonDesigner
- System.Windows.Forms.Design.RichTextBoxDesigner
- System.Windows.Forms.Design.ScrollableControlDesigner
- System.Windows.Forms.Design.ScrollableControlDesigner
- System.Windows.Forms.Design.TextBoxBaseDesigner
- System.Windows.Forms.Design.TextBoxDesigner
- System.Windows.Forms.Design.ToolStripDesigner
- System.Windows.Forms.Design.ToolStripDropDownDesigner
- System.Windows.Forms.Design.ToolStripItemDesigner
- System.Windows.Forms.Design.ToolStripMenuItemDesigner
- System.Windows.Forms.Design.TreeViewDesigner
- System.Windows.Forms.Design.UpDownBaseDesigner
- System.Windows.Forms.Design.UserControlDocumentDesigner

## See also

- [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms)
- [Tutorial: Create a new WinForms app](../get-started/create-app-visual-studio.md)
- [How to migrate a Windows Forms desktop app to .NET 6](../migration/index.md)
