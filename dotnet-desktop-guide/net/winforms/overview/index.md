---
title: What is Windows Forms
description: This article gives an overview of Windows Forms with .NET Core and .NET 5.
ms.date: 10/26/2020
ms.topic: overview
#Customer intent: As a developer, I want to understand the components of Windows Forms so that I can understand the overall picture of Windows Forms.
---

# Desktop Guide (Windows Forms .NET)

Welcome to the Desktop Guide for Windows Forms, a UI framework that creates rich desktop client apps for Windows. The Windows Forms development platform supports a broad set of app development features, including controls, graphics, data binding, and user input. Windows Forms features a drag-and-drop visual designer in Visual Studio to easily create Windows Forms apps.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

There are two implementations of Windows Forms:

01. The open-source implementation hosted on [GitHub](https://github.com/dotnet/winforms).

    This version runs on .NET 5 and .NET Core 3.1. The Windows Forms Visual Designer requires, at a minimum, [Visual Studio 2019 version 16.8 Preview](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+desktopguide+winforms).

01. The .NET Framework 4 implementation that's supported by Visual Studio 2019 and Visual Studio 2017.

    .NET Framework 4 is a Windows-only version of .NET and is considered a Windows Operating System component. This version of Windows Forms is distributed with .NET Framework.

This Desktop Guide is written for Windows Forms on .NET 5. For more information about the .NET Framework version of Windows Forms, see [Windows Forms for .NET Framework](../../../framework/winforms/index.yml?view=netframeworkdesktop-4.8&preserve-view=true).

## Introduction

Windows Forms also provides one of the most productive ways to create desktop apps based on the visual designer provided in Visual Studio. It is a UI framework for building Windows desktop apps. It enables drag-and-drop of visual controls and other similar functionality that makes it easy to build desktop apps.

With Windows Forms you develop graphically rich apps that are easy to deploy, update, and work while offline or while connected to the internet. Windows Forms apps can access the local hardware and filesystem of the computer where the app is running.

To learn how to create a Windows Forms app, see [Tutorial: Create a new WinForms app (Windows Forms .NET)](../get-started/create-app-visual-studio.md).

## Build rich, interactive user interfaces

Windows Forms is a UI technology for .NET, a set of managed libraries that simplify common app tasks such as reading and writing to the file system. When you use a development environment like Visual Studio, you can create Windows Forms smart-client apps that display information, request input from users, and communicate with remote computers over a network.

In Windows Forms, a *form* is a visual surface on which you display information to the user. You ordinarily build Windows Forms apps by adding controls to forms and developing responses to user actions, such as mouse clicks or key presses. A *control* is a discrete UI element that displays data or accepts data input.

When a user does something to your form or one of its controls, the action generates an event. Your app reacts to these events with code, and processes the events when they occur.<!-- TODO  For more information, see [Creating Event Handlers in Windows Forms](creating-event-handlers-in-windows-forms.md).-->

Windows Forms contains a variety of controls that you can add to forms: controls that display text boxes, buttons, drop-down boxes, radio buttons, and even webpages.<!-- TODO For a list of all the controls you can use on a form, see [Controls to Use on Windows Forms](./controls/controls-to-use-on-windows-forms.md).--> If an existing control doesn't meet your needs, Windows Forms also supports creating your own custom controls using the <xref:System.Windows.Forms.UserControl> class.

Windows Forms has rich UI controls that emulate features in high-end apps like Microsoft Office. When you use the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.MenuStrip> control, you can create toolbars and menus that contain text and images, display submenus, and host other controls such as text boxes and combo boxes.

With the drag-and-drop **Windows Forms Designer** in Visual Studio, you can easily create Windows Forms apps. Just select the controls with your cursor and add them where you want on the form. The designer provides tools such as gridlines and snap lines to take the hassle out of aligning controls. You can use the <xref:System.Windows.Forms.FlowLayoutPanel>, <xref:System.Windows.Forms.TableLayoutPanel>, and <xref:System.Windows.Forms.SplitContainer> controls to create advanced form layouts in less time.

Finally, if you must create your own custom UI elements, the <xref:System.Drawing> namespace contains a large selection of classes to render lines, circles, and other shapes directly on a form.

### Create forms and controls

For step-by-step information about how to use these features, see the following Help topics.

| Description                                  | Help topic                                                                                            |
|----------------------------------------------|-------------------------------------------------------------------------------------------------------|
| Using forms                                  | [How to add a form to a project (Windows Forms .NET)](../forms/how-to-add.md)                         |
| Using controls on forms                      | [How to: Add Controls to Windows Forms](../controls/how-to-add-to-a-form.md)           |

<!-- TODO
| Using the <xref:System.Windows.Forms.ToolStrip> Control | [How to: Create a Basic ToolStrip with Standard Items Using the Designer](./controls/create-a-basic-wf-toolstrip-with-standard-items-using-the-designer.md) |
| Creating graphics with <xref:System.Drawing> | [Getting Started with Graphics Programming](./advanced/getting-started-with-graphics-programming.md)  |
| Creating custom controls                     | [How to: Inherit from the UserControl Class](./controls/how-to-inherit-from-the-usercontrol-class.md) |
-->

## Display and manipulate data

Many apps must display data from a database, XML or JSON file, web service, or other data source. Windows Forms provides a flexible control that is named the <xref:System.Windows.Forms.DataGridView> control for displaying such tabular data in a traditional row and column format, so that every piece of data occupies its own cell. When you use <xref:System.Windows.Forms.DataGridView>, you can customize the appearance of individual cells, lock arbitrary rows and columns in place, and display complex controls inside cells, among other features.

Connecting to data sources over a network is a simple task with Windows Forms. The <xref:System.Windows.Forms.BindingSource> component represents a connection to a data source, and exposes methods for binding data to controls, navigating to the previous and next records, editing records, and saving changes back to the original source. The <xref:System.Windows.Forms.BindingNavigator> control provides a simple interface over the <xref:System.Windows.Forms.BindingSource> component for users to navigate between records.

You can create data-bound controls easily by using the Data Sources window. The window displays data sources such as databases, web services, and objects in your project. You can create data-bound controls by dragging items from this window onto forms in your project. You can also data-bind existing controls to data by dragging objects from the Data Sources window onto existing controls.

Another type of data binding you can manage in Windows Forms is *settings*. Most apps must retain some information about their run-time state, such as the last-known size of forms, and retain user preference data, such as default locations for saved files. The Application Settings feature addresses these requirements by providing an easy way to store both types of settings on the client computer. After you define these settings by using either Visual Studio or a code editor, the settings are persisted as XML and automatically read back into memory at run time.

<!-- TODO
### Display and manipulate data

For step-by-step information about how to use these features, see the following Help topics.

| Description                                                   | Help topic                                                                                                                                                        |
|---------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Using the <xref:System.Windows.Forms.BindingSource> component | [How to: Bind Windows Forms Controls with the BindingSource Component Using the Designer](./controls/bind-wf-controls-with-the-bindingsource.md)                  |
| Working with ADO.NET data sources                             | [How to: Sort and Filter ADO.NET Data with the Windows Forms BindingSource Component](./controls/sort-and-filter-ado-net-data-with-wf-bindingsource-component.md) |
| Using the Data Sources window                                 | [Bind Windows Forms controls to data in Visual Studio](/visualstudio/data-tools/bind-windows-forms-controls-to-data-in-visual-studio)                             |
| Using app settings                                            | [How to: Create Application Settings](./advanced/how-to-create-application-settings.md)                                                                           |

-->

## Deploy apps to client computers

After you have written your app, you must send the app to your users so that they can install and run it on their own client computers. When you use the ClickOnce technology, you can deploy your apps from within Visual Studio by using just a few clicks, and provide your users with a URL pointing to your app on the web. ClickOnce manages all the elements and dependencies in your app, and ensures that the app is correctly installed on the client computer.

ClickOnce apps can be configured to run only when the user is connected to the network, or to run both online and offline. When you specify that an app should support offline operation, ClickOnce adds a link to your app in the user's **Start** menu. The user can then open the app without using the URL.

When you update your app, you publish a new deployment manifest and a new copy of your app to your web server. ClickOnce will detect that there is an update available and upgrade the user's installation; no custom programming is required to update old apps.

<!-- TODO

### Deploy ClickOnce apps

For a full introduction to ClickOnce, see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment). For step-by-step information about how to use these features, see the following Help topics,

|Description|Help topic|
|-----------------|----------------|
|Deploying an app by using ClickOnce|[How to: Publish a ClickOnce Application using the Publish Wizard](/visualstudio/deployment/how-to-publish-a-clickonce-application-using-the-publish-wizard)<br /><br /> [Walkthrough: Manually Deploying a ClickOnce Application](/visualstudio/deployment/walkthrough-manually-deploying-a-clickonce-application)|
|Updating a ClickOnce deployment|[How to: Manage Updates for a ClickOnce Application](/visualstudio/deployment/how-to-manage-updates-for-a-clickonce-application)|
|Managing security with ClickOnce|[How to: Enable ClickOnce Security Settings](/visualstudio/deployment/how-to-enable-clickonce-security-settings)|
-->

<!-- TODO
## Other controls and features

There are many other features in Windows Forms that make implementing common tasks fast and easy, such as support for creating dialog boxes, printing, adding help and documentation, and localizing your app to multiple languages.

### Implement other controls and features

For step-by-step information about how to use these features, see the following Help topics.

| Description | Help topic |
|-------------|------------|
|Printing the contents of a form | [How to: Print Graphics in Windows Forms](./advanced/how-to-print-graphics-in-windows-forms.md)<br /><br /> [How to: Print a Multi-Page Text File in Windows Forms](./advanced/how-to-print-a-multi-page-text-file-in-windows-forms.md) |
|Learn more about Windows Forms security | [Security in Windows Forms Overview](security-in-windows-forms-overview.md) |
-->

## See also

- [Tutorial: Create a new WinForms app (Windows Forms .NET)](../get-started/create-app-visual-studio.md)
- [How to add a form to a project (Windows Forms .NET)](../forms/how-to-add.md)
- [Add a control (Windows Forms .NET)](../controls/how-to-add-to-a-form.md)
