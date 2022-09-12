---
title: WFDEV001 warning
description: Learn about the Windows Forms obsoletions that generate compile-time warning WFDEV001.
ms.date: 09/09/2022
---
# WFDEV001: WParam, LParam, and Message.Result are obsolete

To reduce the risk of cast and overflow exceptions associated with <xref:System.IntPtr> on different platforms, the Windows Forms SDK disallows direct use of <xref:System.Windows.Forms.Message.WParam?displayProperty=nameWithType>, <xref:System.Windows.Forms.Message.LParam?displayProperty=nameWithType>, and <xref:System.Windows.Forms.Message.Result?displayProperty=nameWithType>. Projects that use the `DEBUG` build of the Windows Forms SDK and that reference <xref:System.Windows.Forms.Message.WParam>, <xref:System.Windows.Forms.Message.LParam>, or <xref:System.Windows.Forms.Message.Result> will fail to compile due to warning `WFDEV001`.

## Workarounds

Update your code to use the new internal properties, either `WParamInternal`, `LParamInternal`, or `ResultInternal` depending on the situation.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable WFDEV001

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore WFDEV001
```

To suppress all the `WFDEV001` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);WFDEV001</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
