---
title: WFDEV004 warning
description: Learn about Windows Forms compile-time warning WFDEV004. Form.OnClosing, Form.OnClosed, Form.Closing, and Form.Closed, are obsolete.
ms.date: 03/04/2025
f1_keywords:
  - "WFDEV004"
helpviewer_keywords:
  - "WFDEV004"
---
# Compiler Warning WFDEV004

**Version introduced:** .NET 10 Preview 1

> [Form.OnClosing], [Form.OnClosed] and the corresponding events are obsolete. Use [Form.OnFormClosing], [Form.OnFormClosed], [Form.FormClosing] and [Form.FormClosed] instead.

These methods and events are provided for backwards compatibility and they shouldn't be used. Instead, reference the replacement methods and events.

## Workaround

Replace the obsolete member with the new member:

| Old member       | New member           |
|------------------|----------------------|
| [Form.OnClosing] | [Form.OnFormClosing] |
| [Form.OnClosed]  | [Form.OnFormClosed]  |
| [Form.Closing]   | [Form.FormClosing]   |
| [Form.Closed]    | [Form.FormClosed]    |

## Suppress a warning

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFDEV004.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFDEV004</NoWarn>
  </PropertyGroup>
  ```

- Suppress in code with the `#pragma warning disable WFDEV004` directive.

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).

[Form.OnClosing]: xref:System.Windows.Forms.Form.OnClosing(System.ComponentModel.CancelEventArgs)
[Form.OnClosed]: xref:System.Windows.Forms.Form.OnClosed(System.EventArgs)
[Form.OnFormClosing]: xref:System.Windows.Forms.Form.OnFormClosing(System.Windows.Forms.FormClosingEventArgs)
[Form.OnFormClosed]: xref:System.Windows.Forms.Form.OnFormClosed(System.Windows.Forms.FormClosedEventArgs)
[Form.FormClosing]: xref:System.Windows.Forms.Form.FormClosing
[Form.FormClosed]: xref:System.Windows.Forms.Form.FormClosed
[Form.Closing]: xref:System.Windows.Forms.Form.Closing
[Form.Closed]: xref:System.Windows.Forms.Form.Closed
