---
title: WFDEV003 warning
description: Learn about Windows Forms compile-time warning WFDEV003.
ms.date: 09/09/2022
---
# WFDEV003: DomainItemAccessibleObject should not be used

Any reference to <xref:System.Windows.Forms.DomainUpDown.DomainItemAccessibleObject?displayProperty=fullName> will result in warning `WFDEV003`. This warning states that <xref:System.Windows.Forms.DomainUpDown.DomainItemAccessibleObject> is no longer used to provide accessible support for items in <xref:System.Windows.Forms.DomainUpDown> controls. This type was never intended for public use.

Previously, objects of this type were served to accessibility tools that navigated the hierarchy of a <xref:System.Windows.Forms.DomainUpDown> control. In .NET 7 and later versions, instances of type <xref:System.Windows.Forms.AccessibleObject> are used to represent items in a <xref:System.Windows.Forms.DomainUpDown> control for accessibility tools.

## Workarounds

Remove invocations of the public constructor for the <xref:System.Windows.Forms.DomainUpDown.DomainItemAccessibleObject> type. Use <xref:System.Windows.Forms.AccessibleObject?displayProperty=fullName> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable WFDEV003

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore WFDEV003
```

To suppress all the `WFDEV003` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);WFDEV003</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
