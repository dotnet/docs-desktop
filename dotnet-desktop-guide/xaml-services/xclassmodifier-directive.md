---
title: "x:ClassModifier Directive"
ms.date: "03/30/2017"
f1_keywords: 
  - "xClassModifier"
  - "x:ClassModifier"
  - "ClassModifier"
helpviewer_keywords: 
  - "XAML [XAML Services], x:ClassModifier attribute"
  - "x:ClassModifier attribute [XAML Services]"
  - "ClassModifier attribute in XAML [XAML Services]"
ms.assetid: ef30ab78-d334-4668-917d-c9f66c3b6aea
---
# x:ClassModifier Directive
Modifies XAML compilation behavior when `x:Class` is also provided. Specifically, instead of creating a partial `class` that has a `Public` access level (the default), the provided `x:Class` is created with a `NotPublic` access level. This behavior affects the access level for the class in the generated assemblies.

## XAML Attribute Usage

```xaml
<object x:Class="namespace.classname" x:ClassModifier="NotPublic">
   ...
</object>
```

## XAML Values

|||
|-|-|
|*NotPublic*|The exact string to pass to specify <xref:System.Reflection.TypeAttributes.Public?displayProperty=nameWithType> versus <xref:System.Reflection.TypeAttributes.NotPublic?displayProperty=nameWithType> varies, depending on the code-behind programming language that you use. See Remarks.|

## Dependencies

[x:Class](xclass-directive.md) must also be provided on the same element, and that element must be the root element in a page. For more information, see [\[MS-XAML\] Section 4.3.1.8](https://docs.microsoft.com/previous-versions/msp-n-p/ff650760(v=pandp.10)).

## Remarks

The value of `x:ClassModifier` in .NET XAML Services usage varies by programming language. The string to use depends on how each language implements its <xref:System.CodeDom.Compiler.CodeDomProvider> and the type converters it returns to define the meanings for <xref:System.Reflection.TypeAttributes.Public?displayProperty=nameWithType> and <xref:System.Reflection.TypeAttributes.NotPublic?displayProperty=nameWithType>, and whether that language is case sensitive.

- For C#, the string to pass to designate <xref:System.Reflection.TypeAttributes.NotPublic?displayProperty=nameWithType> is `internal`.

- For Microsoft Visual Basic .NET, the string to pass to designate <xref:System.Reflection.TypeAttributes.NotPublic?displayProperty=nameWithType> is `Friend`.

- For C++/CLI, no targets exist that support compiling XAML; therefore, the value to pass is unspecified.

You can also specify <xref:System.Reflection.TypeAttributes.Public?displayProperty=nameWithType> (`public` in C#, `Public` in Visual Basic); however, specifying <xref:System.Reflection.TypeAttributes.Public?displayProperty=nameWithType> is infrequently done because <xref:System.Reflection.TypeAttributes.Public?displayProperty=nameWithType> is already the default behavior.

Other values with equivalent user code access-level restrictions, such as `private` in C#, are not relevant for `x:ClassModifier` because nested class references are not supported in XAML, and therefore, the <xref:System.Reflection.TypeAttributes.NotPublic?displayProperty=nameWithType> modifier has the same effect.

## Security Notes

The access level as declared in `x:ClassModifier` is still subject to interpretation by particular frameworks and their capabilities. WPF includes capabilities to load and instantiate types where `x:ClassModifier` is `internal`, if that class is referenced from a WPF resource through a pack URI reference. As a consequence of this case and potentially others like it implemented by other frameworks, do not rely exclusively on `x:ClassModifier` to block all possible instantiation attempts.

## See also

- [x:Class Directive](xclass-directive.md)
- [Code-Behind and XAML in WPF](../../framework/wpf/advanced/code-behind-and-xaml-in-wpf.md)
- [x:FieldModifier Directive](xfieldmodifier-directive.md)
- [Security (WPF)](../../framework/wpf/security-wpf.md)
- [Types Migrated from WPF to System.Xaml](../../framework/wpf/advanced/types-migrated-from-wpf-to-system.md)
