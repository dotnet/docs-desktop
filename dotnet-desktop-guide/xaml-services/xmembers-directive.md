---
title: "x:Members Directive"
ms.date: "03/30/2017"
ms.assetid: 155b393d-3b49-4c5a-8c9e-b3d9893af4e4
---
# x:Members Directive
Holds a set of members that are defined in markup, which apply to the x:Class of the parent element.

## XAML Attribute Usage

```xaml
<object x:Class="className">
<x:Members>
  oneOrMoreMembers
</x:Members
</object>
```

## XAML Values

|||
|-|-|
|`className`|Name of the backing class or partial class for the XAML production. See Remarks.|
|`oneOrMoreMembers`|One or more object elements that represent member definitions. Typically, these are `x:Property` object elements. See Remarks.|

## Remarks

In .NET XAML Services implementation, there is no backing class or underlying member implementation for `x:Members`. `x:Members` is a special XAML member that can exist as a member on any type. In a XAML node stream, `x:Members` is represented as a member named `Members`, from the XAML language XAML namespace. The member `Members` contains a read-only generic list of `Member` objects. In typical markup the individual members are specified as `x:Property` property elements. `x:Property` is a more precise type specifically for properties of types and is assignable to `x:Member`. For more information, see [x:Property Directive](xproperty-directive.md).

To support a practical usage of `x:Members` as a means to specify member definitions in markup, the members must be associated with a class that can be modified. The intended model is that `x:Members` exists as a member of a type that specifies an `x:Class`. However, the mechanism for associating types and members or for producing dynamic member definitions is not supported at .NET XAML Services level. This is left to individual frameworks that have application models that support member definitions from XAML. Typically, MSBUILD build actions that markup-compile the XAML and either integrate it with code-behind or produce pure from-XAML assemblies are needed to support that feature.

## x:Members for Windows Workflow Foundation

For Windows Workflow Foundation, `x:Members` contains the members of a custom activity composed entirely in XAML, or XAML –defined dynamic members for an activity designer with code-behind. `x:Class` must also be specified on the root element of the XAML production. This is not a requirement at .NET XAML Services level, but becomes a requirement when the XAML production is loaded by the MSBUILD build actions that support custom activities and Windows Workflow Foundation XAML in general. `x:Members` must be the first child element in markup of the object element that declares the `x:Class`.
