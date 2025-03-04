---
title: WFDEV005 warning
description: Learn about Windows Forms compile-time warning WFDEV005. 'Clipboard.GetData(string)' is obsolete. Use 'Clipboard.TryGetData<T>' methods instead.
ms.date: 03/04/2025
f1_keywords:
  - "WFDEV005"
helpviewer_keywords:
  - "WFDEV005"
---
# Compiler Warning WFDEV005

**Version introduced:** .NET 10 Preview 1

> `Clipboard.GetData(string)` is obsolete. Use `Clipboard.TryGetData<T>` methods instead.

Using <xref:System.Windows.Forms.Clipboard.GetData(System.String)?displayProperty=nameWithType> generates warning `WFDEV005` at compile time. `Clipboard.GetData(System.String)` relies on `BinaryFormatter`, which is deprecated for security reasons. For more information, see [Windows Forms migration guide for BinaryFormatter](/dotnet/standard/serialization/binaryformatter-migration-guide/winforms-applications).

## Workaround

Replace references to `Clipboard.GetData` with <xref:System.Windows.Forms.Clipboard.TryGetData*?displayProperty=nameWithType>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFDEV005.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file to suppress the error:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFDEV005</NoWarn>
  </PropertyGroup>
  ```

- Suppress the error in code with the `#pragma warning disable WFDEV005` directive.

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).
