---
title: "How to: Register an Attached Property"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "attached properties [WPF], registering"
  - "registering attached properties [WPF]"
ms.assetid: eb47bd94-0451-4f8d-8fb6-95f7812ac05b
description: Learn how to register an attached property and provide public accessors so that the property in both WPF types are also implemented as dependency properties. 
---
# How to: Register an Attached Property

This example shows how to register an attached property and provide public accessors so that you can use the property in both WPF types are also implemented as dependency properties. You can use dependency properties on any <xref:System.Windows.DependencyObject> types.  
  
## Example  

 The following example shows how to register an attached property as a dependency property, by using the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method. The provider class has the option of providing default metadata for the property that is applicable when the property is used on another class, unless that class overrides the metadata. In this example, the default value of the `IsBubbleSource` property is set to `false`.  
  
 The provider class for an attached property (even if it is not registered as a dependency property) must provide static get and set accessors that follow the naming convention `Set`*[AttachedPropertyName]* and `Get`*[AttachedPropertyName]*. These accessors are required so that the acting XAML reader can recognize the property as an attribute in XAML and resolve the appropriate types.  
  
 [!code-csharp[WPFAquariumSln#RegisterAttachedBubbler](~/samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#registerattachedbubbler)]
 [!code-vb[WPFAquariumSln#RegisterAttachedBubbler](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#registerattachedbubbler)]  
  
## See also

- <xref:System.Windows.DependencyProperty>
- [Dependency Properties Overview](dependency-properties-overview.md)
- [Custom Dependency Properties](custom-dependency-properties.md)
- [How-to Topics](properties-how-to-topics.md)
