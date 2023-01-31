---
title: WFDEV002 warning
description: Learn about Windows Forms compile-time warning/error WFDEV002.
ms.date: 09/09/2022
---
# WFDEV002: DomainUpDownAccessibleObject should not be used

Any reference to <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=fullName> will result in warning `WFDEV002`. This warning states that <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject> is no longer used to provide accessible support for <xref:System.Windows.Forms.DomainUpDown> controls. The <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject> type was never intended for public use.

> [!NOTE]
> This warning was promoted to an error starting in .NET 8, and you can no longer suppress the error. For more information, see [WFDEV002 obsoletion is now an error](/dotnet/core/compatibility/windows-forms/8.0/domainupdownaccessibleobject).

## Workarounds

- Update your code to use <xref:System.Windows.Forms.AccessibleObject> instead of <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject>.
- If you're using .NET 7, you can [suppress the warning](#suppress-a-warning-net-7-only) and your code will continue to compile and run.

## Suppress a warning (.NET 7 only)

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable WFDEV002

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore WFDEV002
```

To suppress all the `WFDEV002` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);WFDEV002</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
