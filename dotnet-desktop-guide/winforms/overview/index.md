---
title: What is Windows Forms
description: This article gives an overview of Windows Forms with .NET
ms.date: 04/02/2025
ms.service: dotnet-desktop
ms.topic: overview
#Customer intent: As a developer, I want to understand the components of Windows Forms so that I can understand the overall picture of Windows Forms.
---

# Windows Forms for .NET

Welcome to the Desktop Guide for Windows Forms, a UI framework that creates rich desktop client apps for Windows. The Windows Forms development platform supports a broad set of app development features, including controls, graphics, data binding, and user input. Windows Forms features a drag-and-drop visual designer in Visual Studio to easily create Windows Forms apps.

There are two implementations of Windows Forms:

01. The open-source implementation hosted on [GitHub](https://github.com/dotnet/winforms).

    This version runs on .NET 6 and later versions.

    The latest version is Windows Forms for .NET 9 using [Visual Studio 2022 version 17.12](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022+desktopguide+winforms).

01. The .NET Framework 4 implementation that's supported by Visual Studio 2022, Visual Studio 2019, and Visual Studio 2017.

    .NET Framework 4 is a Windows-only version of .NET and is considered a Windows Operating System component. This version of Windows Forms is distributed with .NET Framework.

    For more information about the .NET Framework version of Windows Forms, see [Windows Forms for .NET Framework](../../../framework/winforms/index.yml?view=netframeworkdesktop-4.8&preserve-view=true).

## Introduction

Windows Forms is a UI framework for building Windows desktop apps. It provides one of the most productive ways to create desktop apps based on the visual designer provided in Visual Studio. Functionality such as drag-and-drop placement of visual controls makes it easy to build desktop apps.

With Windows Forms, you develop graphically rich apps that are easy to deploy, update, and work while offline or while connected to the internet. Windows Forms apps can access the local hardware and file system of the computer where the app is running.

To learn how to create a Windows Forms app, see [Tutorial: Create a new WinForms app](../get-started/create-app-visual-studio.md).

## Why migrate from .NET Framework

Windows Forms for .NET provides new features and enhancements over .NET Framework. For more information, see [What's new in Windows Forms for .NET 9](../whats-new/net90.md). To learn how to upgrade an app, see [How to upgrade a Windows Forms desktop app to .NET](../migration/index.md)

## Build rich, interactive user interfaces

Windows Forms is a UI technology for .NET, a set of managed libraries that simplify common app tasks such as reading and writing to the file system. When you use a development environment like Visual Studio, you can create Windows Forms smart-client apps that display information, request input from users, and communicate with remote computers over a network.

In Windows Forms, a *form* is a visual surface on which you display information to the user. You ordinarily build Windows Forms apps by adding controls to forms and developing responses to user actions, such as mouse clicks or key presses. A *control* is a discrete UI element that displays data or accepts data input.

When a user does something to your form or one of its controls, the action generates an event. Your app reacts to these events with code, and processes the events when they occur. For more information, see [Creating Event Handlers in Windows Forms](creating-event-handlers-in-windows-forms.md).

Windows Forms contains a variety of controls that you can add to forms: controls that display text boxes, buttons, drop-down boxes, radio buttons, and even webpages. For a list of all the controls you can use on a form, see [Controls to Use on Windows Forms](./controls/controls-to-use-on-windows-forms.md). If an existing control doesn't meet your needs, Windows Forms also supports creating your own custom controls using the <xref:System.Windows.Forms.UserControl> class. For more information, see [How to create a user control](../controls-design/how-to-create-usercontrol.md).

Windows Forms has rich UI controls that emulate features in high-end apps like Microsoft Office. When you use the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.MenuStrip> controls, you can create toolbars and menus that contain text and images, display submenus, and host other controls such as text boxes and combo boxes.

With the drag-and-drop **Windows Forms Designer** in Visual Studio, you can easily create Windows Forms apps. Just select the controls with your cursor and place them where you want on the form. The designer provides tools such as gridlines and snap lines to take the hassle out of aligning controls. You can use the <xref:System.Windows.Forms.FlowLayoutPanel>, <xref:System.Windows.Forms.TableLayoutPanel>, and <xref:System.Windows.Forms.SplitContainer> controls to create advanced form layouts in less time.

Finally, if you must create your own custom UI elements, the <xref:System.Drawing> namespace contains a large selection of classes to render lines, circles, and other shapes directly on a form.

> **.NET Framework Only**
>
> Windows Forms controls are not designed to be marshaled across application domains. For this reason, Microsoft does not support passing a Windows Forms control across an <xref:System.AppDomain> boundary, even though the <xref:System.Windows.Controls.Control> base type of <xref:System.MarshalByRefObject> would seem to indicate that this is possible. Windows Forms applications that have multiple application domains are supported as long as no Windows Forms controls are passed across application domain boundaries.

### Create forms and controls

For step-by-step information about how to use these features, see the following Help topics.

- [How to add a form to a project](../forms/how-to-add.md)
- [How to add Controls to a form](../controls/how-to-add-to-a-form.md)

## Display and manipulate data

Many apps must display data from a database, XML or JSON file, web service, or other data source. Windows Forms provides a flexible control that is named the <xref:System.Windows.Forms.DataGridView> control for displaying such tabular data in a traditional row and column format, so that every piece of data occupies its own cell. When you use <xref:System.Windows.Forms.DataGridView>, you can customize the appearance of individual cells, lock arbitrary rows and columns in place, and display complex controls inside cells, among other features.

Connecting to data sources over a network is a simple task with Windows Forms. The <xref:System.Windows.Forms.BindingSource> component represents a connection to a data source, and exposes methods for binding data to controls, navigating to the previous and next records, editing records, and saving changes back to the original source. The <xref:System.Windows.Forms.BindingNavigator> control provides a simple interface over the <xref:System.Windows.Forms.BindingSource> component for users to navigate between records.

You can create data-bound controls easily by using the Data Sources window in Visual Studio. The window displays data sources such as databases, web services, and objects in your project. You can create data-bound controls by dragging items from this window onto forms in your project. You can also data-bind existing controls to data by dragging objects from the Data Sources window onto existing controls.

Another type of data binding you can manage in Windows Forms is *settings*. Most apps must retain some information about their run-time state, such as the last-known size of forms, and retain user preference data, such as default locations for saved files. The Application Settings feature addresses these requirements by providing an easy way to store both types of settings on the client computer. After you define these settings by using either Visual Studio or a code editor, the settings are persisted as XML and automatically read back into memory at run time.

## Related content

- 
