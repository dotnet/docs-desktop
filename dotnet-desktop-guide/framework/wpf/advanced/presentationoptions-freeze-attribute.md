---
title: "PresentationOptions:Freeze Attribute"
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
description: Learn about the Freeze attribute.
helpviewer_keywords: 
  - "Freeze attribute [WPF]"
  - "Freezable elements [WPF]"
  - "PresentationOptions prefix [WPF]"
ms.assetid: 391032dd-2fba-4804-bb8a-3b071797a9f4
---
# PresentationOptions:Freeze Attribute

Sets the <xref:System.Windows.Freezable.IsFrozen%2A> state to `true` on the containing <xref:System.Windows.Freezable> element. Default behavior for a <xref:System.Windows.Freezable> without the `PresentationOptions:Freeze` attribute specified is that <xref:System.Windows.Freezable.IsFrozen%2A> is `false` at load time, and dependent on general <xref:System.Windows.Freezable> behavior at runtime.  
  
## XAML Attribute Usage  
  
```xaml  
<object  
  xmlns:PresentationOptions="http://schemas.microsoft.com/winfx/2006/xaml/presentation/options"  
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
  mc:Ignorable="PresentationOptions">  
    <freezableElement PresentationOptions:Freeze="true"/>  
</object>  
```  
  
## XAML Values  
  
| Value| Description|  
|------|------------|  
|`PresentationOptions`|An XML namespace prefix, which can be any valid prefix string, per the XML 1.0 specification. The prefix `PresentationOptions` is used for identification purposes in this documentation.|  
|`freezableElement`|An element that instantiates any derived class of <xref:System.Windows.Freezable>.|  
  
## Remarks  

 The `Freeze` attribute is the only attribute or other programming element defined in the `http://schemas.microsoft.com/winfx/2006/xaml/presentation/options` XML namespace. The `Freeze` attribute exists in this special namespace specifically so that it can be designated as ignorable, using [mc:Ignorable Attribute](mc-ignorable-attribute.md) as part of the root element declarations. The reason that `Freeze` must be able to be ignorable is because not all XAML processor implementations are able to freeze a <xref:System.Windows.Freezable> at load time; this capability is not part of the XAML specification.  
  
 The ability to process the `Freeze` attribute is specifically built in to the WPF XAML processor when processing the `Freeze` attribute on <xref:System.Windows.Freezable> elements at load time.  
  
 Any value for the `Freeze` attribute other than `true` (not case sensitive) generates a load time error. (Specifying the `Freeze` attribute as `false` is not an error, but that is already the default, so setting to `false` does nothing).  
  
## See also

- <xref:System.Windows.Freezable>
- [Freezable Objects Overview](freezable-objects-overview.md)
- [mc:Ignorable Attribute](mc-ignorable-attribute.md)
