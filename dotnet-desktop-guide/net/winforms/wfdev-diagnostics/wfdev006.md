---
title: WFDEV006 warning
description: Learn about Windows Forms compile-time warning WFDEV006. ContextMenu, DataGrid, MainMenu, Menu, StatusBar, ToolBar are obsolete. They're provided for binary compatibility with .NET Framework.
ms.date: 03/03/2025
---
# WFDEV006: ContextMenu, DataGrid, MainMenu, Menu, StatusBar, ToolBar are obsolete

Starting with .NET 10, some controls are provided for binary compatibility with .NET Framework, but they're marked as obsolete and aren't intended to be used directly from your code. Referencing one of the following controls warning `WFDEV006` at compile time:

- <xref:System.Windows.Forms.ContextMenu>
- <xref:System.Windows.Forms.DataGrid>
- <xref:System.Windows.Forms.MainMenu>
- <xref:System.Windows.Forms.Menu>
- <xref:System.Windows.Forms.StatusBar>
- <xref:System.Windows.Forms.ToolBar>

Starting with .NET 10, these controls are provided for binary compatibility with .NET Framework, but they're marked as obsolete and aren't intended to be used directly from your code. Use a replacement control instead. Referencing one of these controls warning `WFDEV006` at compile time.

**Version introduced:** .NET 10 Preview 1

## Workarounds

Replace references to these controls with their .NET counterparts:

| Original control | New control                                    |
|------------------|------------------------------------------------|
| `ContextMenu`    | `ContextMenuStrip`                             |
| `DataGrid`       | `DataGridView`                                 |
| `MainMenu`       | `MenuStrip`                                    |
| `Menu`           | `ToolStripDropDown` or `ToolStripDropDownMenu` |
| `StatusBar`      | `StatusStrip`                                  |
| `ToolBar`        | `ToolStrip`                                    |

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFDEV006.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file to suppress the error:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFDEV006</NoWarn>
  </PropertyGroup>
  ```

- Suppress the error in code with the `#pragma warning disable WFDEV006` directive.

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).
