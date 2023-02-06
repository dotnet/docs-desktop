---
title: "mc:Ignorable Attribute"
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
description: Learn about the mc Ignorable attribute.
helpviewer_keywords: 
  - "mc XML namespace prefix [WPF]"
  - "mc:Ignorable attribute"
  - "XML [WPF], mc namespace prefix"
  - "XAML [WPF], mc:Ignorable attribute"
  - "mc:ProcessContent attribute"
  - "XAML [WPF], mc:ProcessContent attribute"
ms.assetid: acd9a6ef-b7ca-4146-abb6-60f3b366e9ec
---
# mc:Ignorable Attribute

Specifies which XML namespace prefixes encountered in a markup file may be ignored by a XAML processor. The `mc:Ignorable` attribute supports markup compatibility both for custom namespace mapping and for XAML versioning.  
  
## XAML Attribute Usage (Single Prefix)  
  
```xaml  
<object  
  xmlns:ignorablePrefix="ignorableUri"  
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
  mc:Ignorable="ignorablePrefix"...>  
    <ignorablePrefix1:ThisElementCanBeIgnored/>  
</object>  
```  
  
## XAML Attribute Usage (Two Prefixes)  
  
```xaml  
<object  
  xmlns:ignorablePrefix1="ignorableUri"  
  xmlns:ignorablePrefix2="ignorableUri2"  
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
  mc:Ignorable="ignorablePrefix1 ignorablePrefix2"...>  
    <ignorablePrefix1:ThisElementCanBeIgnored/>  
</object>  
```  
  
## XAML Values  
  
| Value | Description |  
|-------|-------------|  
|*ignorablePrefix, ignorablePrefix1, etc.*|Any valid prefix string, per the XML 1.0 specification.|  
|*ignorableUri*|Any valid URI for designating a namespace, per the XML 1.0 specification.|  
|*ThisElementCanBeIgnored*|An element that can be ignored by Extensible Application Markup Language (XAML) processor implementations, if the underlying type cannot be resolved.|  
  
## Remarks  

 The `mc` XML namespace prefix is the recommended prefix convention to use when mapping the XAML compatibility namespace `http://schemas.openxmlformats.org/markup-compatibility/2006`.  
  
 Elements or attributes where the prefix portion of the element name are identified as `mc:Ignorable` will not raise errors when processed by a XAML processor. If that attribute could not be resolved to an underlying type or programming construct, then that element is ignored. Note however that ignored elements might still generate additional parsing errors for additional element requirements that are side effects of that element not being processed. For instance, a particular element content model might require exactly one child element, but if the specified child element was in an `mc:Ignorable` prefix, and the specified child element could not be resolved to a type, then the XAML processor might raise an error.  
  
 `mc:Ignorable` only applies to namespace mappings to identifier strings. `mc:Ignorable` does not apply to namespace mappings into assemblies, which specify a CLR namespace and an assembly (or default to the current executable as the assembly).  
  
 If you are implementing a XAML processor, your processor implementation must not raise parsing or processing errors on type resolution for any element or attribute that is qualified by a prefix that is identified as `mc:Ignorable`. But your processor implementation can still raise exceptions that are a secondary result of an element failing to load or be processed, such as the one-child element example given earlier.  
  
 By default, a XAML processor will ignore content within an ignored element. However, you can specify an additional attribute, [mc:ProcessContent Attribute](mc-processcontent-attribute.md), to require continued processing of content within an ignored element by the next available parent element.  
  
 Multiple prefixes can be specified in the attribute, using one or more white-space characters as the separator, for example: `mc:Ignorable="ignore1 ignore2"`.  

 The `http://schemas.openxmlformats.org/markup-compatibility/2006` namespace defines other elements and attributes that are not documented within this area of the SDK. For more information, see [XML Markup Compatibility Specification](/office/open-xml/introduction-to-markup-compatibility#markup-compatibility-in-the-open-xml-file-formats-specification).  
  
## See also

- <xref:System.Windows.Markup.XamlReader>
- [PresentationOptions:Freeze Attribute](presentationoptions-freeze-attribute.md)
- [XAML in WPF](xaml-in-wpf.md)
- [Documents in WPF](documents-in-wpf.md)
