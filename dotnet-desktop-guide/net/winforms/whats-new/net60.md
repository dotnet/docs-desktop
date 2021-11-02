---
title: What's new in Windows Forms .NET 6
description: Learn about what's new in Windows Forms for .NET 6. Windows Forms. .NET provides new features and enhancements over .NET Framework.
ms.date: 10/28/2021
ms.topic: conceptual
---

# What's new for .NET 6 (Windows Forms .NET)

Windows Forms for .NET 6 adds the following features and enhancements over .NET Framework.

There are a few breaking changes you should be aware of when migrating from .NET Framework to .NET 6. For more information, see [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).

## New application bootstrap

TODO

## Updated templates for C#

In line with [related changes in .NET workloads](../../sdk/6.0/csharp-template-code.md), Windows Forms templates for C# have been updated to support `global using` directives, file-scoped namespaces, and nullable reference types. Because a typical Windows Forms app consist of multiple types split across multiple files, for example, Form1.cs and Form1.Designer.cs, top-level statements are notably absent from the Windows Forms templates. However, the updated templates do include application bootstrap code. This can cause incompatibility if you target an earlier version of .NET.

TODO: note about .NET Framework templates. @OliaG to provide text.

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
TODO: @mmcgaw to provide text.
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
- [Tutorial: Create a new WinForms app (Windows Forms .NET)](../get-started/create-app-visual-studio.md)
- [How to migrate a Windows Forms desktop app to .NET 6](../migration/index.md)
