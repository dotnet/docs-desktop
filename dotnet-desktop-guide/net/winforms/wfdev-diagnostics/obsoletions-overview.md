---
title: Obsolete Windows Forms features in .NET 7+
titleSuffix: ""
description: Learn about Windows Forms APIs that are marked as obsolete in .NET 7 and later versions that produce WFDEV compiler warnings.
ms.date: 01/30/2023
---

# Obsolete Windows Forms features in .NET 7+

Starting in .NET 7, some Windows Forms APIs are marked as obsolete (or otherwise produce a warning) with custom diagnostic IDs of the format `WFDEVXXX`.

If you encounter build warnings or errors due to usage of an obsolete API, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. Warnings or errors for these obsoletions *can't* be suppressed using the [standard diagnostic ID (CS0618)](/dotnet/csharp/language-reference/compiler-messages/cs0618) for obsolete types or members; use the custom `WFDEVXXX` diagnostic ID values instead. For more information, see [Suppress warnings](#suppress-warnings).

## Reference

The following table provides an index to the `WFDEVXXX` obsoletions and warnings in .NET 7+.

| Diagnostic ID | Warning or error | Description |
| - | - |
| [WFDEV001](wfdev001.md) | Warning | Casting to/from <xref:System.IntPtr> is unsafe. Use `WParamInternal`, `LParamInternal`, or `ResultInternal` instead. |
| [WFDEV002](wfdev002.md) | Warning/error | <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=nameWithType> is no longer used to provide accessible support for <xref:System.Windows.Forms.DomainUpDown> controls. Use <xref:System.Windows.Forms.AccessibleObject> instead. |
| [WFDEV003](wfdev003.md) | Warning | <xref:System.Windows.Forms.DomainUpDown.DomainItemAccessibleObject?displayProperty=nameWithType> is no longer used to provide accessible support for <xref:System.Windows.Forms.DomainUpDown> items. Use <xref:System.Windows.Forms.AccessibleObject> instead. |

## Suppress warnings

It's recommended that you use an available workaround whenever possible. However, if you cannot change your code, you can suppress warnings through a `#pragma` directive or a `<NoWarn>` project setting. If you must use the obsolete APIs and the `WFDEVXXX` diagnostic does not surface as an error, you can suppress the warning in code or in your project file.

To suppress the warnings in code:

```csharp
// Disable the warning.
#pragma warning disable WFDEV001

// Code that uses obsolete API.
//...

// Re-enable the warning.
#pragma warning restore WFDEV001
```

To suppress the warnings in a project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net7.0</TargetFramework>
   <!-- NoWarn below suppresses WFDEV001 project-wide -->
   <NoWarn>$(NoWarn);WFDEV001</NoWarn>
   <!-- To suppress multiple warnings, you can use multiple NoWarn elements -->
   <NoWarn>$(NoWarn);WFDEV001</NoWarn>
   <NoWarn>$(NoWarn);WFDEV003</NoWarn>
   <!-- Alternatively, you can suppress multiple warnings by using a semicolon-delimited list -->
   <NoWarn>$(NoWarn);WFDEV001;WFDEV003</NoWarn>
  </PropertyGroup>
</Project>
```

> [!NOTE]
> Suppressing warnings in this way only disables the obsoletion warnings you specify. It doesn't disable any other warnings, including obsoletion warnings with different diagnostic IDs.

## See also

- [Obsolete .NET features in .NET 5+](/dotnet/fundamentals/syslib-diagnostics/obsoletions-overview)
<!-- - (add link to breaking change page here...)-->
