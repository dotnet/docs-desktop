---
title: WFDEV001 warning
description: Learn about Windows Forms compile-time warning WFDEV001. 'WParam', 'LParam', 'Result' are obsolete internally to Windows Forms.
ms.date: 03/03/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
f1_keywords:
  - "WFDEV001"
helpviewer_keywords:
  - "WFDEV001"
# NOTE: This article is really for internal Microsoft employees maintaining Windows Forms
---
# WFDEV001: WParam, LParam, and Message.Result are obsolete

**Version introduced:** .NET 7

> [!IMPORTANT]
> This article is intended for those maintaining Windows Forms. This warning doesn't apply to using Windows Forms.

To reduce the risk of cast and overflow exceptions associated with <xref:System.IntPtr> on different platforms, the Windows Forms SDK disallows direct use of <xref:System.Windows.Forms.Message.WParam?displayProperty=nameWithType>, <xref:System.Windows.Forms.Message.LParam?displayProperty=nameWithType>, and <xref:System.Windows.Forms.Message.Result?displayProperty=nameWithType>. Projects that use the `DEBUG` build of the Windows Forms SDK and that reference <xref:System.Windows.Forms.Message.WParam>, <xref:System.Windows.Forms.Message.LParam>, or <xref:System.Windows.Forms.Message.Result> will fail to compile due to warning `WFDEV001`.

## Workaround

Update your code to use the new internal properties, either `WParamInternal`, `LParamInternal`, or `ResultInternal` depending on the situation.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFDEV001.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFDEV001</NoWarn>
  </PropertyGroup>
  ```

- Suppress in code with the `#pragma warning disable WFDEV001` directive.

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).
