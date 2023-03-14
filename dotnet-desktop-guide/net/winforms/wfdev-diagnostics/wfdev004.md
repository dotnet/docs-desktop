---
title: WFDEV004 warning
description: Learn about Windows Forms compile-time warning WFDEV004.
ms.date: 03/13/2023
---
# WFDEV004: ListBox.DefaultItemHeight no longer used as default item height

Any reference to <xref:System.Windows.Forms.ListBox.DefaultItemHeight?displayProperty=nameWithType> will result in warning `WFDEV004` at compile time. This warning states that the `ListBox.DefaultItemHeight` constant is no longer used as the default item height. The default item height is now scaled according to the application default font.

## Workarounds

N/A

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable WFDEV004

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore WFDEV004
```

To suppress all the `WFDEV004` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);WFDEV004</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
