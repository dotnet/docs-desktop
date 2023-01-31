---
title: "ComponentResourceKey Markup Extension"
description: Learn about the ComponentResourceKey markup XAML extension of Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
f1_keywords: 
  - "ComponentResourceKey"
  - "ComponentResourceKeyExtension"
helpviewer_keywords: 
  - "ComponentResourceKey markup extension [WPF]"
  - "XAML [WPF], ComponentResourceKey markup extension"
ms.assetid: d6bcdbe6-61b3-40a7-b381-4e02185b5a85
---
# ComponentResourceKey Markup Extension

Defines and references keys for resources that are loaded from external assemblies. This enables a resource lookup to specify a target type in an assembly, rather than an explicit resource dictionary in an assembly or on a class.  
  
## XAML Attribute Usage (setting key, compact)  
  
```xml  
<object x:Key="{ComponentResourceKey {x:Type targetTypeName}, targetID}" ... />  
```  
  
## XAML Attribute Usage (setting key, verbose)  
  
```xml  
<object x:Key="{ComponentResourceKey TypeInTargetAssembly={x:Type targetTypeName}, ResourceID=targetID}" ... />  
```  
  
## XAML Attribute Usage (requesting resource, compact)  
  
```xml  
<object property="{DynamicResource {ComponentResourceKey {x:Type targetTypeName}, targetID}}" ... />  
```  
  
## XAML Attribute Usage (requesting resource, verbose)  
  
```xml  
<object property="{DynamicResource {ComponentResourceKey TypeInTargetAssembly={x:Type targetTypeName}, ResourceID=targetID}}" ... />  
```  
  
## XAML Values  
  
| Value | Description |  
|-------|-------------|  
|`targetTypeName`|The name of the public common language runtime (CLR) type that is defined in the resource assembly.|  
|`targetID`|The key for the resource. When resources are looked up, `targetID` will be analogous to the [x:Key Directive](/dotnet/desktop/xaml-services/xkey-directive) of the resource.|  
  
## Remarks  

 As seen in the usages above, a {`ComponentResourceKey`} markup extension usage is found in two places:  
  
- The definition of a key within a theme resource dictionary, as provided by a control author.  
  
- Accessing a theme resource from the assembly, when you are retemplating the control but want to use property values that come from resources provided by the control's themes.  
  
 For referencing component resources that come from themes, it is generally recommended that you use `{DynamicResource}` rather than `{StaticResource}`. This is shown in the usages. `{DynamicResource}` is recommended because the theme itself can be changed by the user. If you want the component resource that most closely matches the control author's intent for supporting a theme, you should enable your component resource reference to be dynamic also.  
  
 The <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> identifies a type that exists in the target assembly where the resource is actually defined. A `ComponentResourceKey` can be defined and used independently of knowing exactly where the <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> is defined, but eventually must resolve the type through referenced assemblies.  
  
 A common usage for <xref:System.Windows.ComponentResourceKey> is to define keys that are then exposed as members of a class. For this usage, you use the <xref:System.Windows.ComponentResourceKey> class constructor, not the markup extension. For more information, see <xref:System.Windows.ComponentResourceKey>, or the "Defining and Referencing Keys for Theme Resources" section of the topic [Control Authoring Overview](../controls/control-authoring-overview.md).  
  
 For both establishing keys and referencing keyed resources, attribute syntax is commonly used for the `ComponentResourceKey` markup extension.  
  
 The compact syntax shown relies on the <xref:System.Windows.ComponentResourceKey.%23ctor%2A> constructor signature and positional parameter usage of a markup extension. The order in which the `targetTypeName` and `targetID` are given is important. The verbose syntax relies on the <xref:System.Windows.ComponentResourceKey.%23ctor%2A> parameterless constructor, and then sets the <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> and <xref:System.Windows.ComponentResourceKey.ResourceId%2A> in a way that is analogous to a true attribute syntax on an object element. In the verbose syntax, the order in which the properties are set is not important. The relationship and mechanisms of these two alternatives (compact and verbose) is described in more detail in the topic [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md).  
  
 Technically, the value for `targetID` can be any object, it does not have to be a string. However, the most common usage in WPF is to align the `targetID` value with forms that are strings, and where such strings are valid in the [XamlName Grammar](/dotnet/desktop/xaml-services/xamlname-grammar).  
  
 `ComponentResourceKey` can be used in object element syntax. In this case, specifying the value of both the <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> and <xref:System.Windows.ComponentResourceKey.ResourceId%2A> properties is required to properly initialize the extension.  
  
 In the WPF XAML reader implementation, the handling for this markup extension is defined by the <xref:System.Windows.ComponentResourceKey> class.  
  
 `ComponentResourceKey` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in XAML use the { and } characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md).  
  
## See also

- <xref:System.Windows.ComponentResourceKey>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Authoring Overview](../controls/control-authoring-overview.md)
- [XAML in WPF](xaml-in-wpf.md)
- [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md)
