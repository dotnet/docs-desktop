---
title: "Collection-Type Dependency Properties"
description: Learn how to implement and initialize collection-type dependency properties in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "properties [WPF], dependency"
  - "properties [WPF], collection-type"
  - "dependency properties [WPF]"
  - "collection-type properties [WPF]"
ms.assetid: 99f96a42-3ab7-4f64-a16b-2e10d654e97c
---
# Collection-Type Dependency Properties

This topic provides guidance and suggested patterns for how to implement a dependency property where the type of the property is a collection type.  

<a name="implementing"></a>

## Implementing a Collection-Type Dependency Property  

 For a dependency property in general, the implementation pattern that you follow is that you define a CLR property wrapper, where that property is backed by a <xref:System.Windows.DependencyProperty> identifier rather than a field or other construct. You follow this same pattern when you implement a collection-type property. However, a collection-type property introduces some complexity to the pattern whenever the type that is contained within the collection is itself a <xref:System.Windows.DependencyObject> or <xref:System.Windows.Freezable> derived class.  
  
<a name="initializing"></a>

## Initializing the Collection Beyond the Default Value  

 When you create a dependency property, you do not specify the property default value as the initial field value. Instead, you specify the default value through the dependency property metadata. If your property is a reference type, the default value specified in dependency property metadata is not a default value per instance; instead it is a default value that applies to all instances of the type. Therefore you must be careful to not use the singular static collection defined by the collection property metadata as the working default value for newly created instances of your type. Instead, you must make sure that you deliberately set the collection value to a unique (instance) collection as part of your class constructor logic. Otherwise you will have created an unintentional singleton class.  
  
 Consider the following example. The following section of the example shows the definition for a class `Aquarium`, which contains a flaw with the default value. The class defines the collection type dependency property `AquariumObjects`, which uses the generic <xref:System.Collections.Generic.List%601> type with a <xref:System.Windows.FrameworkElement> type constraint. In the <xref:System.Windows.DependencyProperty.Register%28System.String%2CSystem.Type%2CSystem.Type%2CSystem.Windows.PropertyMetadata%29> call for the dependency property, the metadata establishes the default value to be a new generic <xref:System.Collections.Generic.List%601>.

> [!WARNING]
> The following code does not behave correctly.

 [!code-csharp[PropertiesOvwSupport2#CollectionProblemDefinition](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport2/CSharp/page.xaml.cs#collectionproblemdefinition)]
 [!code-vb[PropertiesOvwSupport2#CollectionProblemDefinition](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport2/visualbasic/page.xaml.vb#collectionproblemdefinition)]  
  
 However, if you just left the code as shown, that single list default value is shared for all instances of `Aquarium`. If you ran the following test code, which is intended to show how you would instantiate two separate `Aquarium` instances and add a single different `Fish` to each of them, you would see a surprising result:  
  
 [!code-csharp[PropertiesOvwSupport#CollectionProblemTestCode](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page4.xaml.cs#collectionproblemtestcode)]
 [!code-vb[PropertiesOvwSupport#CollectionProblemTestCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page4.xaml.vb#collectionproblemtestcode)]  
  
 Instead of each collection having a count of one, each collection has a count of two! This is because each `Aquarium` added its `Fish` to the default value collection, which resulted from a single constructor call in the metadata and is therefore shared between all instances. This situation is almost never what you want.  
  
 To correct this problem, you must reset the collection dependency property value to a unique instance, as part of the class constructor call. Because the property is a read-only dependency property, you use the <xref:System.Windows.DependencyObject.SetValue%28System.Windows.DependencyPropertyKey%2CSystem.Object%29> method to set it, using the <xref:System.Windows.DependencyPropertyKey> that is only accessible within the class.  
  
 [!code-csharp[PropertiesOvwSupport#CollectionProblemCtor](~/samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page4.xaml.cs#collectionproblemctor)]
 [!code-vb[PropertiesOvwSupport#CollectionProblemCtor](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page4.xaml.vb#collectionproblemctor)]  
  
 Now, if you ran that same test code again, you could see more expected results, where each `Aquarium` supported its own unique collection.  
  
 There would be a slight variation on this pattern if you chose to have your collection property be read-write. In that case, you could call the public set accessor from the constructor to do the initialization, which would still be calling the nonkey signature of <xref:System.Windows.DependencyObject.SetValue%28System.Windows.DependencyProperty%2CSystem.Object%29> within your set wrapper, using a public <xref:System.Windows.DependencyProperty> identifier.  
  
## Reporting Binding Value Changes from Collection Properties  

 A collection property that is itself a dependency property does not automatically report changes to its subproperties. If you are creating bindings into a collection, this can prevent the binding from reporting changes, thus invalidating some data binding scenarios. However, if you use the collection type <xref:System.Windows.FreezableCollection%601> as your collection type, then subproperty changes to contained elements in the collection are properly reported, and binding works as expected.  
  
 To enable subproperty binding in a dependency object collection, create the collection property as type <xref:System.Windows.FreezableCollection%601>, with a type constraint for that collection to any <xref:System.Windows.DependencyObject> derived class.  
  
## See also

- <xref:System.Windows.FreezableCollection%601>
- [XAML and Custom Classes for WPF](xaml-and-custom-classes-for-wpf.md)
- [Data Binding Overview](../data/data-binding-overview.md)
- [Dependency Properties Overview](dependency-properties-overview.md)
- [Custom Dependency Properties](custom-dependency-properties.md)
- [Dependency Property Metadata](dependency-property-metadata.md)
