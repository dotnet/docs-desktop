---
title: "mc:ProcessContent Attribute"
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
description: Learn about the mc ProcessContent attribute.
helpviewer_keywords: 
  - "mc:ProcessContent attribute"
  - "XAML [WPF], mc:ProcessContent attribute"
ms.assetid: 2689b2c8-b4dc-4b71-b9bd-f95e619122d7
---
# mc:ProcessContent Attribute

Specifies which XAML elements should still have content processed by relevant parent elements, even if the immediate parent element may be ignored by a XAML processor due to specifying [mc:Ignorable Attribute](mc-ignorable-attribute.md). The `mc:ProcessContent` attribute supports markup compatibility both for custom namespace mapping and for XAML versioning.  
  
## XAML Attribute Usage  
  
```xaml  
<object  
  xmlns:ignorablePrefix="ignorableUri"  
  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
  mc:Ignorable="ignorablePrefix"...  
  mc:ProcessContent="ignorablePrefix:ThisElementCanBeIgnored"  
>  
    <ignorablePrefix:ThisElementCanBeIgnored>  
        [content]  
    </ignorablePrefix:ThisElementCanBeIgnored>  
</object>  
```  
  
## XAML Values  
  
| Value | Description |  
|-------|-------------|  
|*ignorablePrefix*|Any valid prefix string, per the XML 1.0 specification.|  
|*ignorableUri*|Any valid URI for designating a namespace, per the XML 1.0 specification.|  
|*ThisElementCanBeIgnored*|An element that can be ignored by Extensible Application Markup Language (XAML) processor implementations, if the underlying type cannot be resolved.|  
|*[content]*|*ThisElementCanBeIgnored* is marked ignorable. If the processor ignores that element, *[content]* is processed by *object*.|  
  
## Remarks  

 By default, a XAML processor will ignore content within an ignored element. You can specify a specific element by `mc:ProcessContent`, and a XAML processor will continue to process the content within the ignored element. This would typically be used if the content is nested within several tags, at least one of which is ignorable and at least one of which is not ignorable.  
  
 Multiple prefixes may be specified in the attribute, using a space separator, for example: `mc:ProcessContent="ignore:Element1 ignore:Element2"`.  
  
 The `http://schemas.openxmlformats.org/markup-compatibility/2006` namespace defines other elements and attributes that are not documented within this area of the SDK. For more information, see [XML Markup Compatibility Specification](/office/open-xml/introduction-to-markup-compatibility#markup-compatibility-in-the-open-xml-file-formats-specification).  
  
## See also

- [mc:Ignorable Attribute](mc-ignorable-attribute.md)
- [XAML in WPF](xaml-in-wpf.md)
