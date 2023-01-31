---
title: "How to: Implement a Dependency Property"
description: Define a dependency property in Windows Presentation Foundation, by backing a common language runtime property with a DependencyProperty field.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dependency properties [WPF], backing properties with"
  - "properties [WPF], backing with dependency properties"
ms.assetid: 855fd6d7-19ac-493c-bf5e-2f40b57cdc92
---
# How to: Implement a Dependency Property

This example shows how to back a common language runtime (CLR) property with a <xref:System.Windows.DependencyProperty> field, thus defining a dependency property. When you define your own properties and want them to support many aspects of Windows Presentation Foundation (WPF) functionality, including styles, data binding, inheritance, animation, and default values, you should implement them as a dependency property.  
  
## Example  

 The following example first registers a dependency property by calling the <xref:System.Windows.DependencyProperty.Register%2A> method. The name of the identifier field that you use to store the name and characteristics of the dependency property must be the <xref:System.Windows.DependencyProperty.Name%2A> you chose for the dependency property as part of the <xref:System.Windows.DependencyProperty.Register%2A> call, appended by the literal string `Property`. For instance, if you register a dependency property with a <xref:System.Windows.DependencyProperty.Name%2A> of `Location`, then the identifier field that you define for the dependency property must be named `LocationProperty`.  
  
 In this example, the name of the dependency property and its CLR accessor is `State`; the identifier field is `StateProperty`; the type of the property is <xref:System.Boolean>; and the type that registers the dependency property is `MyStateControl`.  
  
 If you fail to follow this naming pattern, designers might not report your property correctly, and certain aspects of property system style application might not behave as expected.  
  
 You can also specify default metadata for a dependency property. This example registers the default value of the `State` dependency property to be `false`.  
  
 [!code-csharp[PropertySystemEsoterics#MyStateControl](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertySystemEsoterics/CSharp/SDKSampleLibrary/class1.cs#mystatecontrol)]
 [!code-vb[PropertySystemEsoterics#MyStateControl](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertySystemEsoterics/visualbasic/sdksamplelibrary/class1.vb#mystatecontrol)]  
  
 For more information about how and why to implement a dependency property, as opposed to just backing a CLR property with a private field, see [Dependency Properties Overview](dependency-properties-overview.md).  
  
## See also

- [Dependency Properties Overview](dependency-properties-overview.md)
- [How-to Topics](properties-how-to-topics.md)
