---
title: "Generics in XAML"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "generics [XAML Services]"
ms.assetid: 835bfed7-585c-4216-ae67-b674edab8b92
---
# Generics in XAML

.NET XAML Services as implemented in <xref:System.Xaml?displayProperty=fullName> provides support for using generic CLR types. This support includes specifying the constraints of generics as a type argument and enforcing the constraint by calling the appropriate `Add` method for generic collection cases. This topic describes aspects of using and referencing generic types in XAML.

## x:TypeArguments

`x:TypeArguments` is a directive defined by the XAML language. When it is used as a member of a XAML type that is backed by a generic type, `x:TypeArguments` passes constraining type arguments of the generic to the backing constructor. For reference syntax that pertains to .NET XAML Services use of `x:TypeArguments`, which includes syntax examples, see [x:TypeArguments Directive](xtypearguments-directive.md).

Because `x:TypeArguments` takes a string, and has type converter backing, it is typically declared in XAML usage as an attribute.

In the XAML node stream, the information declared by `x:TypeArguments` can be obtained from <xref:System.Xaml.XamlType.TypeArguments%2A?displayProperty=nameWithType> at a `StartObject` position in the node stream. The return value of <xref:System.Xaml.XamlType.TypeArguments%2A?displayProperty=nameWithType> is a list of <xref:System.Xaml.XamlType> values. Determination of whether a XAML type represents a generic type can be made by calling <xref:System.Xaml.XamlType.IsGeneric%2A?displayProperty=nameWithType>.

## Rules and Syntax Conventions for Generics in XAML

In XAML, a generic type must always be represented as a constrained generic. An unconstrained generic is never present in the XAML type system or a XAML node stream and cannot be represented in XAML markup. A generic can be referenced within XAML attribute syntax for cases where it is a nested type constraint of a generic being referenced by `x:TypeArguments`, or for cases where `x:Type` supplies a CLR type reference for a generic type. Referencing generics is supported through the <xref:System.Xaml.Schema.XamlTypeTypeConverter> class defined by .NET XAML Services.

The XAML attribute syntax form enabled by <xref:System.Xaml.Schema.XamlTypeTypeConverter> alters the typical MSIL / CLR syntax convention that uses angle brackets for types and constraints of generics, and instead substitutes parentheses for the constraint container. For an example, see [x:TypeArguments Directive](xtypearguments-directive.md).

## Generics and XAML 2009 Features

If you use XAML 2009 instead of mapping the CLR base types to obtain XAML types for common language primitives, you can use [XAML 2009 built-in types](types-for-primitives.md) as information items in `x:TypeArguments`. For example, you could declare the following (prefix mappings not shown, but `x` is the XAML language XAML namespace for XAML 2009):

```xaml
<my:BusinessObject x:TypeArguments="x:String,x:Int32"/>
```

## Generics Support in WPF

For XAML 2006 usage when specifically targeting WPF, [x:Class](xclass-directive.md) must also be provided on the same element as `x:TypeArguments`, and that element must be the root element in a XAML document. The root element must map to a generic type with at least one type argument. An example is <xref:System.Windows.Navigation.PageFunction%601>.

Possible workarounds to support generic usages include defining a custom markup extension that can return generic types, or providing a wrapping class definition that derives from a generic type but flattens the generic constraint in its own class definition.

In WPF you can use XAML 2009 features together with `x:TypeArguments`, but only for loose XAML (XAML that is not markup-compiled). Markup-compiled XAML for WPF and the BAML form of XAML do not currently support the XAML 2009 keywords and features.

Custom workflows in Windows Workflow Foundation for .NET Framework 3.5 do not support generic XAML usage.

## See also

- [x:TypeArguments Directive](xtypearguments-directive.md)
- [x:Class Directive](xclass-directive.md)
- [Built-in Types for Common XAML Language Primitives](types-for-primitives.md)
