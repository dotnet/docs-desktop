---
title: What's new in Windows Forms
description: Learn about what is new in Windows Forms for .NET. Windows Forms for .NET provides new features and enhancements over .NET Framework.
ms.date: 11/05/2020
ms.topic: conceptual
---

# What's new (Windows Forms.NET)

Windows Forms for .NET adds the following features and enhancements over .NET Framework.

There are a few breaking changes you should be aware of when migrating from .NET Framework to .NET. For more information, see [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).

## Enhanced features

- Microsoft UI Automation patterns work better with accessibility tools like Narrator and Jaws.
- Significant work on performance and reliability.
- Better support for high DPI resolutions such as 4k monitors.
- The default font matches the current Windows design recommendations.

  > [!CAUTION]
  > This may impact the layout of apps migrated from .NET Framework.

## New controls

The following new controls have been added since .NET Framework:

- <xref:System.Windows.Forms.TaskDialog?displayProperty=fullName>
  
  A task dialog is a dialog box that can be used to display information and receive simple input from the user. Like a message box, it is formatted by the operating system according to parameters you set. However, a task dialog has more features than a message box. For more information, see the [Task dialog sample](https://github.com/dotnet/samples/tree/master/windowsforms/TaskDialogDemo).

- <xref:Microsoft.Web.WebView2.WinForms.WebView2?displayProperty=fullName>

  A new web browser control with modern web support. Based on Edge (Chromium). For more information, see [Getting started with WebView2 in Windows Forms](/microsoft-edge/webview2/gettingstarted/winforms).

## Enhanced controls

- <xref:System.Windows.Forms.ListView?displayProperty=fullName>

  - Supports collapsible groups.
  - Footers
  - Group subtitle, task, title images, and collapse/expand functionality.

- <xref:System.Windows.Forms.FolderBrowserDialog?displayProperty=fullName>

  This dialog has been upgraded to use the modern Windows experience instead of the old Windows 7 experience.

- <xref:System.Windows.Forms.FileDialog?displayProperty=fullName>

  - Added support for <xref:System.Windows.Forms.FileDialog.ClientGuid>.

    This property enables a calling application to associate a GUID with a dialog's persisted state. A dialog's state can include factors such as the last visited folder and the position and size of the dialog. Typically, this state is persisted based on the name of the executable file. By specifying a GUID, an application can have different persisted states for different versions of the dialog within the same application (for example, an import dialog and an open dialog).

- <xref:System.Windows.Forms.TextRenderer?displayProperty=fullName>

  Support added for <xref:System.ReadOnlySpan%601> to enhance performance of rendering text.

## See also

- [Breaking changes in Windows Forms](/dotnet/core/compatibility/winforms).
- [How to migrate a Windows Forms desktop app to .NET 5](../migration/index.md).
