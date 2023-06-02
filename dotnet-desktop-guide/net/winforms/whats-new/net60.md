---
title: What's new in Windows Forms .NET 6
description: Learn about what's new in Windows Forms for .NET 6. Windows Forms. .NET provides new features and enhancements over .NET Framework.
ms.date: 11/11/2021
ms.topic: conceptual
---

# What's new for .NET 6 (Windows Forms .NET)

This article describes some of the new Windows Forms features and enhancements in .NET 6.

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

In .NET 6, these templates have been modified to use the new bootstrap code, invoked by the `ApplicationConfiguration.Initialize` method.

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

The new bootstrap code is used by Visual Studio to configure the Windows Forms Visual Designer. If you opt-out of using the new bootstrap code, by restoring the old code and bypassing the `ApplicationConfiguration.Initialize` method, the Windows Forms Visual Designer won't respect the bootstrap settings you set.

The settings generated in the `Initialize` method are controlled by the project file.

### Project-level application settings

To complement the [new application bootstrap](#new-application-bootstrap) feature of Windows Forms, a few `Application` settings previously set in the startup code of the application should be set in the project file. The project file can configure the following application settings:

| Project setting                                                                                                               | Default value   | Corresponding API                                                                                    |
|-------------------------------------------------------------------------------------------------------------------------------|-----------------|----------------------------------------------------------------------------------------|
| [ApplicationVisualStyles](/dotnet/core/project-sdk/msbuild-props-desktop#applicationvisualstyles)                             | `true`          | `Application.EnableVisualStyles`                                                    |
| [ApplicationUseCompatibleTextRendering](/dotnet/core/project-sdk/msbuild-props-desktop#applicationusecompatibletextrendering) | `false`         | `Application.SetCompatibleTextRenderingDefault`                                |
| [ApplicationHighDpiMode](/dotnet/core/project-sdk/msbuild-props-desktop#applicationhighdpimode)                               | `SystemAware`   | `Application.SetHighDpiMode`                                 |
| [ApplicationDefaultFont](/dotnet/core/project-sdk/msbuild-props-desktop#applicationdefaultfont)                               | `Segoe UI, 9pt` | `Application.SetDefaultFont` |

The following example demonstrates a project file that sets these application-related properties:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net6.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
    <ImplicitUsings>enable</ImplicitUsings>

    <ApplicationVisualStyles>true</ApplicationVisualStyles>
    <ApplicationUseCompatibleTextRendering>false</ApplicationUseCompatibleTextRendering>
    <ApplicationHighDpiMode>SystemAware</ApplicationHighDpiMode>
    <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>

  </PropertyGroup>

</Project>
```

The Windows Forms Visual Designer uses these settings. For more information, see the [Visual Studio designer improvements section](#visual-studio-designer-improvements).

## Change the default font

Windows Forms on .NET Core 3.0 introduced a new default font for Windows Forms: **Segoe UI, 9pt**. This font better aligned to the [Windows user experience (UX) guidelines](/windows/win32/uxguide/vis-fonts#fonts-and-colors). However, .NET Framework uses **Microsoft Sans Serif, 8.25pt** as the default font. This change made it harder for some customers to migrate their large applications that utilized a pixel-perfect layout from .NET Framework to .NET. The only way to change the font for the whole application was to edit every form in the project, setting the <xref:System.Windows.Forms.Control.Font> property to an alternate font.

The default font can now be set in two ways:

- Set the default font in the project file to be used by the [application bootstrap](#new-application-bootstrap) code:

  > [!IMPORTANT]
  > This is the preferred way. Using the project to configure the new application bootstrap system allows Visual Studio to use these settings in the designer.
  
  In the following example, the project file configures Windows Forms to use the same font that .NET Framework uses.

  ```xml
  <Project Sdk="Microsoft.NET.Sdk">
  
    <!-- other settings -->
  
    <PropertyGroup>
      <ApplicationDefaultFont>Microsoft Sans Serif, 8.25pt</ApplicationDefaultFont>
    </PropertyGroup>
  
  </Project>
  ```
  
 \- or -

- Call the the <xref:System.Windows.Forms.Application.SetDefaultFont%2A?displayProperty=nameWithType> API in the old way (but with no designer support):

  ```csharp
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
  ```

## Visual Studio designer improvements

The Windows Forms Visual Designer now accurately reflects the default font. Previous versions of Windows Forms for .NET didn't properly display the **Segoe UI** font in the Visual Designer, and was actually designing the form with the .NET Framework's default font. Because of the new [new application bootstrap](#new-application-bootstrap) feature, the Visual Designer accurately reflects the default font. Additionally, the Visual Designer respects the default font that's set in the project file.

:::image type="content" source="media/net60/appbootstrap.png" alt-text="Windows Forms designer is using the default font setting in Visual Studio":::

### More runtime designers

Designers that existed in the .NET Framework and enabled building a general-purpose designer, for example building a report designer, have been added to .NET 6:

- <xref:System.ComponentModel.Design.ComponentDesigner?displayProperty=fullName>
- System.Windows.Forms.Design.ButtonBaseDesigner
- System.Windows.Forms.Design.ComboBoxDesigner
- <xref:System.Windows.Forms.Design.ControlDesigner?displayProperty=fullName>
- <xref:System.Windows.Forms.Design.DocumentDesigner?displayProperty=fullName>
- <xref:System.Windows.Forms.Design.DocumentDesigner?displayProperty=fullName>
- System.Windows.Forms.Design.FormDocumentDesigner
- System.Windows.Forms.Design.GroupBoxDesigner
- System.Windows.Forms.Design.LabelDesigner
- System.Windows.Forms.Design.ListBoxDesigner
- System.Windows.Forms.Design.ListViewDesigner
- System.Windows.Forms.Design.MaskedTextBoxDesigner
- System.Windows.Forms.Design.PanelDesigner
- <xref:System.Windows.Forms.Design.ParentControlDesigner?displayProperty=fullName>
- <xref:System.Windows.Forms.Design.ParentControlDesigner?displayProperty=fullName>
- System.Windows.Forms.Design.PictureBoxDesigner
- System.Windows.Forms.Design.RadioButtonDesigner
- System.Windows.Forms.Design.RichTextBoxDesigner
- <xref:System.Windows.Forms.Design.ScrollableControlDesigner?displayProperty=fullName>
- <xref:System.Windows.Forms.Design.ScrollableControlDesigner?displayProperty=fullName>
- System.Windows.Forms.Design.TextBoxBaseDesigner
- System.Windows.Forms.Design.TextBoxDesigner
- System.Windows.Forms.Design.ToolStripDesigner
- System.Windows.Forms.Design.ToolStripDropDownDesigner
- System.Windows.Forms.Design.ToolStripItemDesigner
- System.Windows.Forms.Design.ToolStripMenuItemDesigner
- System.Windows.Forms.Design.TreeViewDesigner
- System.Windows.Forms.Design.UpDownBaseDesigner
- System.Windows.Forms.Design.UserControlDocumentDesigner

## High DPI improvements for PerMonitorV2

High DPI rendering with <xref:System.Windows.Forms.HighDpiMode.PerMonitorV2> have been improved:

- Controls are created with the same DPI awareness as the application.
- Container controls and MDI child windows have improved scaling behaviors.

  For example, in .NET 5, moving a Windows Forms app from a monitor with 200% scaling to a monitor with 100% scaling would result in misplaced controls. This has been greatly improved in .NET 6:

  :::image type="content" source="media/net60/highdpi.png" alt-text="High DPI improvements in .NET 6 for Windows Forms":::

## New APIs

- <xref:System.Windows.Forms.Application.SetDefaultFont%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.IsAncestorSiteInDesignMode%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.ProfessionalColors.StatusStripBorder%2A?displayProperty=fullName>
- <xref:System.Windows.Forms.ProfessionalColorTable.StatusStripBorder%2A?displayProperty=fullName>

### New Visual Basic APIs

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

- <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=fullName> now accepts <xref:System.Action?displayProperty=fullName> and <xref:System.Func%601?displayProperty=fullName> as input parameters.
- <xref:System.Windows.Forms.Control.BeginInvoke%2A?displayProperty=fullName> now accepts <xref:System.Action?displayProperty=fullName> as an input parameter.
- <xref:System.Windows.Forms.DialogResult?displayProperty=fullName> is extended with the following members:

  - `TryAgain`
  - `Continue`

- <xref:System.Windows.Forms.Form?displayProperty=fullName> has a new property: <xref:System.Windows.Forms.Form.MdiChildrenMinimizedAnchorBottom>
- <xref:System.Windows.Forms.MessageBoxButtons?displayProperty=fullName> is extended with the following member:

  - `CancelTryContinue`

- <xref:System.Windows.Forms.MessageBoxDefaultButton?displayProperty=fullName> is extended with the following member:

  - `Button4`

- <xref:System.Windows.Forms.LinkClickedEventArgs?displayProperty=fullName> has now a new constructor and extended with the following properties:

  - <xref:System.Windows.Forms.LinkClickedEventArgs.LinkLength?displayProperty=fullName>
  - <xref:System.Windows.Forms.LinkClickedEventArgs.LinkStart?displayProperty=fullName>

- <xref:System.Windows.Forms.NotifyIcon.Text?displayProperty=fullName> is now limited to 127 characters (from 63).

## Improved accessibility

Microsoft UI Automation patterns work better with accessibility tools like Narrator and Jaws.

## See also

- [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms)
- [Tutorial: Create a new WinForms app](../get-started/create-app-visual-studio.md)
- [How to upgrade a Windows Forms desktop app to .NET 7](../migration/index.md)
