---
title: What's new in Windows Forms
description: Learn about what's new in Windows Forms. This article covers changes to Windows Forms since .NET 5 was released.
ms.date: 02/13/2025
ms.topic: conceptual
ai-usage: ai-assisted
---

# What's new in Windows Forms

Each .NET release introduces a new version of Windows Forms (WinForms). This article gives you a summery of what's new in each release.

## .NET 10 Preview

This section describes the main changes to WinForms for each .NET 10 Preview.

- .NET 10 Preview 1
  - [Clipboard changes](net100.md#preview-1)

## .NET 9

WinForms in .NET 9 introduces several modern improvements. The asynchronous forms functionality provides APIs to help run UI-related operations asynchronously, making it easier to integrate with contemporary asynchronous programming patterns. The removal of BinaryFormatter eliminates a long-standing security risk by preventing unsafe deserialization practices. Additionally, experimental dark mode support has been added, allowing applications to adapt their color schemes to better suit dark environments.

- [Async forms](net90.md#async-forms)
- [BinaryFormatter no longer supported](net90.md#binaryformatter-no-longer-supported)
- [Dark mode](net90.md#dark-mode)
- [FolderBrowserDialog enhancements](net90.md#folderbrowserdialog-enhancements)
- [System.Drawing new features and enhancements](net90.md#systemdrawing-new-features-and-enhancements)
- [ToolStrip](net90.md#toolstrip)

## .NET 8

In .NET 8, Windows Forms has again enhanced DPI support, notably through Visual Studio DPI improvements. This enhancement allows the Windows Designer to run in a DPI-unaware mode independently from Visual Studio, ensuring that your app’s design remains sharp while Visual Studio itself stays at its native DPI setting. Another key focus area was data binding improvements and button commands.

- [Data binding improvements](net80.md#data-binding-improvements)
- [Button commands](net80.md#button-commands)
- [Visual Studio DPI improvements](net80.md#visual-studio-dpi-improvements)
- [High DPI improvements](net80.md#high-dpi-improvements)
- [Miscellaneous improvements](net80.md#miscellaneous-improvements)

## .NET 7

In .NET 7, significant improvements have been made to High DPI rendering. These enhancements ensure that nested controls, such as buttons within panels on tab pages, scale correctly according to the current monitor's DPI settings. This feature, which is opt-in for .NET 7, will be enabled by default in .NET 8.

- [Overview of WinForms on .NET 7](net70.md)
- [High DPI improvements](net70.md#high-dpi-improvements)
- [Accessibility improvements and fixes](net70.md#accessibility-improvements-and-fixes)
- [Data binding improvements (preview)](net70.md#data-binding-improvements-preview)
- [Miscellaneous improvements](net70.md#miscellaneous-improvements)
- [See also](net70.md#see-also)

## .NET 6

The focus of .NET 5 for WinForms included updated templates for C# that use global directives, file-scoped namespaces, and nullable reference types. A new application bootstrap was introduced, which simplifies the configuration of Windows Forms applications by using the `ApplicationConfiguration.Initialize` method.

- [Overview of WinForms on .NET 6](net60.md)
- [Updated templates for C#](net60.md#updated-templates-for-c)
- [New application bootstrap](net60.md#new-application-bootstrap)
- [Change the default font](net60.md#change-the-default-font)
- [Visual Studio designer improvements](net60.md#visual-studio-designer-improvements)
- [High DPI improvements for PerMonitorV2](net60.md#high-dpi-improvements-for-permonitorv2)
- [New APIs](net60.md#new-apis)
- [Updated APIs](net60.md#updated-apis)
- [Improved accessibility](net60.md#improved-accessibility)

## .NET 5

The focus of .NET 5 for WinForms was to introduce enhanced features, new controls, and improved existing controls.

- [Overview of WinForms on .NET 5](net50.md)
- [Enhanced features](net50.md#enhanced-features)
- [New controls](net50.md#new-controls)
- [Enhanced controls](net50.md#enhanced-controls)
