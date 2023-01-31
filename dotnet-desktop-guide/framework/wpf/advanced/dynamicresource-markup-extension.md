---
title: "DynamicResource Markup Extension"
description: Learn about the DynamicResource markup Extensible Application Markup Language (XAML) extension of Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
f1_keywords: 
  - "DynamicResource"
  - "DynamicResourceExtension"
helpviewer_keywords: 
  - "XAML [WPF], DynamicResource markup extension"
  - "DynamicResource markup extensions [WPF]"
ms.assetid: 7324f243-03af-4c2b-b0db-26ac6cdfcbe4
---
# DynamicResource Markup Extension

Provides a value for any XAML property attribute by deferring that value to be a reference to a defined resource. Lookup behavior for that resource is analogous to run-time lookup.  
  
## XAML Attribute Usage  
  
```xml  
<object property="{DynamicResource key}" ... />  
```  
  
## XAML Property Element Usage  
  
```xml  
<object>  
  <object.property>  
    <DynamicResource ResourceKey="key" ... />  
  </object.property>  
</object>  
```  
  
## XAML Values  
  
| Value | Description |  
|-------|-------------|  
|`key`|The key for the requested resource. This key was initially assigned by the [x:Key Directive](/dotnet/desktop/xaml-services/xkey-directive) if a resource was created in markup, or was provided as the `key` parameter when calling <xref:System.Windows.ResourceDictionary.Add%2A?displayProperty=nameWithType> if the resource was created in code.|  
  
## Remarks  

 A `DynamicResource` will create a temporary expression during the initial compilation and thus defer lookup for resources until the requested resource value is actually required in order to construct an object. This may potentially be after the XAML page is loaded. The resource value will be found based on key search against all active resource dictionaries starting from the current page scope, and is substituted for the placeholder expression from compilation.  
  
> [!IMPORTANT]
> In terms of dependency property precedence, a `DynamicResource` expression is equivalent to the position where the dynamic resource reference is applied. If you set a local value for a property that previously had a `DynamicResource` expression as the local value, the `DynamicResource` is completely removed. For details, see [Dependency Property Value Precedence](dependency-property-value-precedence.md).  
  
 Certain resource access scenarios are particularly appropriate for `DynamicResource` as opposed to a [StaticResource Markup Extension](staticresource-markup-extension.md). See [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define) for a discussion about the relative merits and performance implications of `DynamicResource` and `StaticResource`.  
  
 The specified <xref:System.Windows.DynamicResourceExtension.ResourceKey%2A> should correspond to an existing resource determined by [x:Key Directive](/dotnet/desktop/xaml-services/xkey-directive) at some level in your page, application, the available control themes and external resources, or system resources, and the resource lookup will happen in that order. For more information about resource lookup for static and dynamic resources, see [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define).  
  
 A resource key may be any string defined in the [XamlName Grammar](/dotnet/desktop/xaml-services/xamlname-grammar). A resource key may also be other object types, such as a <xref:System.Type>. A <xref:System.Type> key is fundamental to how controls can be styled by themes. For more information, see [Control Authoring Overview](../controls/control-authoring-overview.md).  
  
 APIs for lookup of resource values, such as <xref:System.Windows.FrameworkElement.FindResource%2A>, follow the same resource lookup logic as used by `DynamicResource`.  
  
 The alternative declarative means of referencing a resource is as a [StaticResource Markup Extension](staticresource-markup-extension.md).  
  
 Attribute syntax is the most common syntax used with this markup extension. The string token provided after the `DynamicResource` identifier string is assigned as the <xref:System.Windows.DynamicResourceExtension.ResourceKey%2A> value of the underlying <xref:System.Windows.DynamicResourceExtension> extension class.  
  
 `DynamicResource` can be used in object element syntax. In this case, specifying the value of the <xref:System.Windows.DynamicResourceExtension.ResourceKey%2A> property is required.  
  
 `DynamicResource` can also be used in a verbose attribute usage that specifies the <xref:System.Windows.DynamicResourceExtension.ResourceKey%2A> property as a property=value pair:  
  
```xml  
<object property="{DynamicResource ResourceKey=key}" ... />  
```  
  
 The verbose usage is often useful for extensions that have more than one settable property, or if some properties are optional. Because `DynamicResource` has only one settable property, which is required, this verbose usage is not typical.  
  
 In the WPF XAML processor implementation, the handling for this markup extension is defined by the <xref:System.Windows.DynamicResourceExtension> class.  
  
 `DynamicResource` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in XAML use the { and } characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md).  
  
## See also

- [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define)
- [Resources and Code](resources-and-code.md)
- [x:Key Directive](/dotnet/desktop/xaml-services/xkey-directive)
- [XAML in WPF](xaml-in-wpf.md)
- [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md)
- [StaticResource Markup Extension](staticresource-markup-extension.md)
- [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md)
