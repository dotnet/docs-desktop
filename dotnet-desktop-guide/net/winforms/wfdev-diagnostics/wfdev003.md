---
title: WFDEV003 warning
description: Learn about Windows Forms compile-time warning WFDEV003. 'DomainUpDown.DomainItemAccessibleObject' is obsolete. Use 'AccessibleObject' instead.
ms.date: 03/04/2025
f1_keywords:
  - "WFDEV003"
helpviewer_keywords:
  - "WFDEV003"
---
# Compiler Warning WFDEV003

**Version introduced:** .NET 7

> `DomainUpDown.DomainItemAccessibleObject` is obsolete. Use `AccessibleObject` instead.

Reference to [DomainUpDown.DomainItemAccessibleObject](xref:system.windows.forms.domainupdown.domainitemaccessibleobject) generates warning `WFDEV003` at compile time. This warning states that `DomainItemAccessibleObject` is no longer used to provide accessible support for items in <xref:System.Windows.Forms.DomainUpDown> controls. This type was never intended for public use.

Previously, objects of this type were served to accessibility tools that navigated the hierarchy of a `DomainUpDown` control. In .NET 7 and later versions, instances of type <xref:System.Windows.Forms.AccessibleObject> are used to represent items in a `DomainUpDown` control for accessibility tools.

## Workaround

Replace references of [DomainUpDown.DomainItemAccessibleObject](xref:system.windows.forms.domainupdown.domainitemaccessibleobject) with <xref:System.Windows.Forms.AccessibleObject>.

## Suppress a warning

Suppress the warning with either of the following methods:

- Set the severity of the rule in the _.editorConfig_ file.

  ```ini
  [*.{cs,vb}]
  dotnet_diagnostic.WFDEV003.severity = none
  ```

  For more information about editor config files, see [Configuration files for code analysis rules](/dotnet/fundamentals/code-analysis/configuration-files).

- Add the following `PropertyGroup` to your project file to suppress the error:

  ```xml
  <PropertyGroup>
      <NoWarn>$(NoWarn);WFDEV003</NoWarn>
  </PropertyGroup>
  ```

- Suppress the error in code with the `#pragma warning disable WFDEV003` directive.

For more information, see [How to suppress code analysis warnings](/dotnet/fundamentals/code-analysis/suppress-warnings).
