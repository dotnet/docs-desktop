---
title: How to get or set main app window
description: Learn about how to get and set the main application window for a Windows Presentation Foundation (WPF) application. The main window of an application is typically the startup window. This is sometimes specified by the StartupUri property.
ms.date: "03/24/2021"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "windows objects [WPF], setting"
  - "setting windows objects [WPF]"
  - "windows objects [WPF], getting"
  - "getting windows objects [WPF]"
---

# How to get or set the main application window (WPF .NET)

This article teaches you how to get or set the main application window for Windows Presentation Foundation (WPF). The first <xref:System.Windows.Window> that is instantiated within a WPF application is automatically set by <xref:System.Windows.Application> as the main application window. The main window is referenced with the <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType> property.

Much of the time a project template will set the <xref:System.Windows.Application.StartupUri%2A?displayProperty=nameWithType> to a XAML file within your application, such as :::no-loc text="_Window1.xaml_":::. This is the first window instantiated and shown by your application, and it becomes the main window.

> [!TIP]
>The default behavior for an application is to shutdown when the last window is closed. This behavior is controlled by the <xref:System.Windows.Application.ShutdownMode%2A?displayProperty=nameWithType> property. Instead, you can configure the application to shutdown if the <xref:System.Windows.Application.MainWindow%2A> is closed. Set <xref:System.Windows.Application.ShutdownMode%2A?displayProperty=nameWithType> to <xref:System.Windows.ShutdownMode.OnMainWindowClose> to enable this behavior.

## Set the main window in XAML

The templates that generate your WPF application typically set the <xref:System.Windows.Application.StartupUri%2A?displayProperty=nameWithType> property to a XAML file. This property is helpful because:

01. It's easily changeable to a different XAML file in your project.
01. Automatically instantiates and displays the specified window.
01. The specified window becomes the <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType>.

:::code language="xaml" source="snippets/how-to-get-set-main-application-window/csharp/App.xaml" highlight="5" :::

Instead of using <xref:System.Windows.Application.StartupUri%2A?displayProperty=nameWithType>, you can set the <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType> to a XAML-declared window. However, the window specified here won't be displayed and you must set its visibility.

:::code language="xaml" source="snippets/how-to-get-set-main-application-window_2/csharp/App.xaml" highlight="6-8" :::

> [!CAUTION]
> If you set both the <xref:System.Windows.Application.StartupUri%2A?displayProperty=nameWithType> and the <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType> properties, you'll display both windows when your application starts.

Also, you can use the <xref:System.Windows.Application.Startup?displayProperty=nameWithType> event to open a window. For more information, see [Use the Startup event to open a window](index.md#opening-a-window).

## Set the main window in code

The first window instantiated by your application automatically becomes the main window and is set to the <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType> property. To set a different main window, change this property to a window:

:::code language="csharp" source="snippets/how-to-get-set-main-application-window/csharp/App.xaml.cs" id="MainWindowDirect":::
:::code language="vb" source="snippets/how-to-get-set-main-application-window/vb/Application.xaml.vb" id="MainWindowDirect":::

If your application has never created an instance of a window, the following code is functionally equivalent to the previous code:

:::code language="csharp" source="snippets/how-to-get-set-main-application-window/csharp/App.xaml.cs" id="MainWindowIndirect":::
:::code language="vb" source="snippets/how-to-get-set-main-application-window/vb/Application.xaml.vb" id="MainWindowIndirect":::

As soon as the window object instance is created, it's assigned to <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType>.

## Get the main window

You can access the window chosen as the main window by inspecting the <xref:System.Windows.Application.MainWindow%2A?displayProperty=nameWithType> property. The following code displays a message box with the title of the main window when a button is clicked:

:::code language="csharp" source="snippets/how-to-get-set-main-application-window/csharp/Window1.xaml.cs" id="GetMainWindow":::
:::code language="vb" source="snippets/how-to-get-set-main-application-window/vb/Window1.xaml.vb" id="GetMainWindow":::

## See also

- [Overview of WPF windows](index.md)
- [Use the Startup event to open a window](index.md#opening-a-window)
- [How to open a window or dialog box](how-to-open-window-dialog-box.md)
- <xref:System.Windows.Application?displayProperty=fullName>
- <xref:System.Windows.Application.MainWindow?displayProperty=fullName>
- <xref:System.Windows.Application.StartupUri?displayProperty=fullName>
- <xref:System.Windows.Application.ShutdownMode?displayProperty=fullName>
