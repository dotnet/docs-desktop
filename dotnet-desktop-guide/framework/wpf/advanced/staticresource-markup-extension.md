---
title: "StaticResource Markup Extension"
description: Provides a value for any XAML property attribute by looking up a reference to an already defined resource.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
f1_keywords: 
  - "StaticResource"
  - "StaticResourceExtension"
helpviewer_keywords: 
  - "XAML [WPF], StaticResource markup extension"
  - "StaticResource markup extensions [WPF]"
ms.assetid: 97af044c-71f1-4617-9a94-9064b68185d2
---
# StaticResource Markup Extension

Provides a value for any XAML property attribute by looking up a reference to an already defined resource. Lookup behavior for that resource is analogous to load-time lookup, which will look for resources that were previously loaded from the markup of the current XAML page as well as other application sources, and will generate that resource value as the property value in the run-time objects.  
  
## XAML Attribute Usage  
  
```xml  
<object property="{StaticResource key}" ... />  
```  
  
## XAML Object Element Usage  
  
```xml  
<object>  
  <object.property>  
<StaticResource ResourceKey="key" ... />  
  </object.property>  
</object>  
```  
  
## XAML Values  
  
| Value | Description |  
|-------|-------------|  
|`key`|The key for the requested resource. This key was initially assigned by the [x:Key Directive](/dotnet/desktop/xaml-services/xkey-directive) if a resource was created in markup, or was provided as the `key` parameter when calling <xref:System.Windows.ResourceDictionary.Add%2A?displayProperty=nameWithType> if the resource was created in code.|  
  
## Remarks  
  
> [!IMPORTANT]
> A `StaticResource` must not attempt to make a forward reference to a resource that is defined lexically further within the XAML file. Attempting to do so is not supported, and even if such a reference does not fail, attempting the forward reference will incur a load time performance penalty when the internal hash tables representing a <xref:System.Windows.ResourceDictionary> are searched. For best results, adjust the composition of your resource dictionaries such that forward references can be avoided. If you cannot avoid a forward reference, use [DynamicResource Markup Extension](dynamicresource-markup-extension.md) instead.  
  
 The specified <xref:System.Windows.StaticResourceExtension.ResourceKey%2A> should correspond to an existing resource, identified with an [x:Key Directive](/dotnet/desktop/xaml-services/xkey-directive) at some level in your page, application, the available control themes and external resources, or system resources. The resource lookup occurs in that order. For more information about resource lookup behavior for static and dynamic resources, see [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define).  
  
 A resource key can be any string defined in the [XamlName Grammar](/dotnet/desktop/xaml-services/xamlname-grammar). A resource key can also be other object types, such as a <xref:System.Type>. A <xref:System.Type> key is fundamental to how controls can be styled by themes, through an implicit style key. For more information, see [Control Authoring Overview](../controls/control-authoring-overview.md).  
  
 The alternative declarative means of referencing a resource is as a [DynamicResource Markup Extension](dynamicresource-markup-extension.md).  
  
 Attribute syntax is the most common syntax used with this markup extension. The string token provided after the `StaticResource` identifier string is assigned as the <xref:System.Windows.StaticResourceExtension.ResourceKey%2A> value of the underlying <xref:System.Windows.StaticResourceExtension> extension class.  
  
 `StaticResource` can be used in object element syntax. In this case, specifying the value of the <xref:System.Windows.StaticResourceExtension.ResourceKey%2A> property is required.  
  
 `StaticResource` can also be used in a verbose attribute usage that specifies the <xref:System.Windows.StaticResourceExtension.ResourceKey%2A> property as a property=value pair:  
  
```xml  
<object property="{StaticResource ResourceKey=key}" ... />  
```  
  
 The verbose usage is often useful for extensions that have more than one settable property, or if some properties are optional. Because `StaticResource` has only one settable property, which is required, this verbose usage is not typical.  
  
 In the WPF XAML processor implementation, the handling for this markup extension is defined by the <xref:System.Windows.StaticResourceExtension> class.  
  
 `StaticResource` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in XAML use the { and } characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md).  
  
## See also

- [Styling and Templating](../controls/styles-templates-overview.md)
- [XAML in WPF](xaml-in-wpf.md)
- [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md)
- [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define)
- [Resources and Code](resources-and-code.md)
