---
title: "XAML Loading and Dependency Properties"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "custom dependency properties [WPF]"
  - "dependency properties [WPF], XAML loading and"
  - "loading XML data [WPF]"
ms.assetid: 6eea9f4e-45ce-413b-a266-f08238737bf2
description: Learn about XAML loading and dependency properties and the current WPF implementation of its XAML processor.
---
# XAML Loading and Dependency Properties

The current WPF implementation of its WPF XAML processor uses property system methods for dependency properties when loading binary XAML and processing attributes that are dependency properties. This effectively bypasses the property wrappers. When you implement custom dependency properties, you must account for this behavior and should avoid placing any other code in your property wrapper other than the property system methods <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A>.  

<a name="prerequisites"></a>

## Prerequisites  

 This topic assumes that you understand dependency properties both as consumer and author and have read [Dependency Properties Overview](dependency-properties-overview.md) and [Custom Dependency Properties](custom-dependency-properties.md). You should also have read [XAML in WPF](xaml-in-wpf.md) and [XAML Syntax In Detail](xaml-syntax-in-detail.md).  
  
<a name="implementation"></a>

## The WPF XAML Loader Implementation, and Performance  

 For implementation reasons, it is computationally less expensive to identify a property as a dependency property and access the property system <xref:System.Windows.DependencyObject.SetValue%2A> method to set it, rather than using the property wrapper and its setter. This is because a XAML processor must infer the entire object model of the backing code based only on knowing the type and member relationships that are indicated by the structure of the markup and various strings.  
  
 The type is looked up through a combination of xmlns and assembly attributes, but identifying the members, determining which could support being set as an attribute, and resolving what types the property values support would otherwise require extensive reflection using <xref:System.Reflection.PropertyInfo>. Because dependency properties on a given type are accessible as a storage table through the property system, the WPF implementation of its XAML processor uses this table and infers that any given property *ABC* can be more efficiently set by calling <xref:System.Windows.DependencyObject.SetValue%2A> on the containing <xref:System.Windows.DependencyObject> derived type, using the dependency property identifier *ABCProperty*.  
  
<a name="implications"></a>

## Implications for Custom Dependency Properties  

 Because the current WPF implementation of the XAML processor behavior for property setting bypasses the wrappers entirely, you should not put any additional logic into the set definitions of the wrapper for your custom dependency property. If you put such logic in the set definition, then the logic will not be executed when the property is set in XAML rather than in code.  
  
 Similarly, other aspects of the XAML processor that obtain property values from XAML processing also use <xref:System.Windows.DependencyObject.GetValue%2A> rather than using the wrapper. Therefore, you should also avoid any additional implementation in the `get` definition beyond the <xref:System.Windows.DependencyObject.GetValue%2A> call.  
  
 The following example is a recommended dependency property definition with wrappers, where the property identifier is stored as a `public` `static` `readonly` field, and the `get` and `set` definitions contain no code beyond the necessary property system methods that define the dependency property backing.  
  
 [!code-csharp[WPFAquariumSln#AGWithWrapper](~/samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#agwithwrapper)]
 [!code-vb[WPFAquariumSln#AGWithWrapper](~/samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#agwithwrapper)]  
  
## See also

- [Dependency Properties Overview](dependency-properties-overview.md)
- [XAML in WPF](xaml-in-wpf.md)
- [Dependency Property Metadata](dependency-property-metadata.md)
- [Collection-Type Dependency Properties](collection-type-dependency-properties.md)
- [Dependency Property Security](dependency-property-security.md)
- [Safe Constructor Patterns for DependencyObjects](safe-constructor-patterns-for-dependencyobjects.md)
