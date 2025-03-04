---
title: WFDEV002 error
description: Learn about Windows Forms compile-time error WFDEV002. 'DomainUpDown.DomainUpDownAccessibleObject' is obsolete. Use 'AccessibleObject' instead.
ms.date: 03/04/2025
---
# WFDEV002: DomainUpDownAccessibleObject should not be used

**Version introduced:** .NET 7

Reference to <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=nameWithType> generates warning `WFDEV002` at compile time. This error states that `DomainUpDownAccessibleObject` is no longer used to provide accessible support for `DomainUpDown` controls. The `DomainUpDownAccessibleObject` type was never intended for public use.

## Workaround

Replace references of <xref:System.Windows.Forms.DomainUpDown.DomainUpDownAccessibleObject?displayProperty=nameWithType> with <xref:System.Windows.Forms.AccessibleObject?displayProperty=fullName>.

## Suppress a warning

This warning was promoted to an error starting in .NET 8, and you can no longer suppress the error. For more information, see [WFDEV002 obsoletion is now an error](/dotnet/core/compatibility/windows-forms/8.0/domainupdownaccessibleobject).
