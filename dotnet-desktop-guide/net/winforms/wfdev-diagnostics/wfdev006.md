---
title: WFDEV006 warning
description: Learn about Windows Forms compile-time warning WFDEV006. ContextMenu, DataGrid, MainMenu, Menu, StatusBar, ToolBar are obsolete. They're provided for binary compatibility with .NET Framework.
ms.date: 03/04/2025
f1_keywords:
  - "WFDEV006"
helpviewer_keywords:
  - "WFDEV006"
---
# Compiler Warning WFDEV006

**Version introduced:** .NET 10 Preview 1

> `ContextMenu`, `DataGrid`, `MainMenu`, `Menu`, `StatusBar`, `ToolBar` are obsolete. They're provided for binary compatibility with .NET Framework.

Starting with .NET 10, some controls are provided for binary compatibility with .NET Framework, but they're marked as obsolete and aren't intended to be used directly from your code. They can't be instantiated. Referencing one of the following controls generates warning `WFDEV006` at compile time:

- <xref:System.Windows.Forms.ContextMenu>
- <xref:System.Windows.Forms.DataGrid>
- <xref:System.Windows.Forms.MainMenu>
- <xref:System.Windows.Forms.Menu>
- <xref:System.Windows.Forms.StatusBar>
- <xref:System.Windows.Forms.ToolBar>

In prior versions of .NET, referencing a .NET Framework library that used these types would result in an exception being thrown because .NET didn't provide these types. Starting with .NET 10, these types exist to improve compatibility with older .NET Framework libraries that can't be upgraded.

## Workaround

Replace references to these controls with their newer counterparts:

| Original control | New control                                    |
|------------------|------------------------------------------------|
| `ContextMenu`    | `ContextMenuStrip`                             |
| `DataGrid`       | `DataGridView`                                 |
| `MainMenu`       | `MenuStrip`                                    |
| `Menu`           | `ToolStripDropDown` or `ToolStripDropDownMenu` |
| `StatusBar`      | `StatusStrip`                                  |
| `ToolBar`        | `ToolStrip`                                    |

## Suppress a warning

If you must reference the obsolete APIs, for example to run reflection on them, you can suppress the warning in code or in your project file. However, these types can't be instantiated and are only provided for compatibility.

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFDEV006.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFDEV006</NoWarn>
  </PropertyGroup>
  ```

- Suppress the error in code with the `#pragma warning disable WFDEV006` directive.

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).
