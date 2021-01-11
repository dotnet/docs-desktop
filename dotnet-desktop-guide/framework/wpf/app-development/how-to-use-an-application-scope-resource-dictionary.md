---
title: "How to: Use an Application-Scope Resource Dictionary"
description: Learn how to define and use an application-scope custom resource dictionary in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dictionaries [WPF], resource"
  - "resource dictionaries [WPF], application-scope"
  - "application-scope resource dictionaries"
ms.assetid: 53857682-bd2c-4f2c-8f25-1307d0b451a2
---
# How to: Use an Application-Scope Resource Dictionary

This example shows how to define and use an application-scope custom resource dictionary.  
  
## Example  

 <xref:System.Windows.Application> exposes an application-scope store for shared resources: <xref:System.Windows.Application.Resources%2A>. By default, the <xref:System.Windows.Application.Resources%2A> property is initialized with an instance of the <xref:System.Windows.ResourceDictionary> type. You use this instance when you get and set application-scope properties using <xref:System.Windows.Application.Resources%2A>. For more information, see [How to: Get and Set an Application-Scope Resource](/previous-versions/dotnet/netframework-4.0/aa348547(v=vs.100)).
  
 If you have multiple resources that you set using <xref:System.Windows.Application.Resources%2A>, you can instead use a custom resource dictionary to store those resources and set <xref:System.Windows.Application.Resources%2A> with it instead. The following shows how you declare a custom resource dictionary using XAML.
  
 [!code-xaml[HOWTOResourceDictionaries#1](~/samples/snippets/csharp/VS_Snippets_Wpf/HowToResourceDictionaries/CSharp/MyResourceDictionary.xaml#1)]  
  
 Swapping entire resource dictionaries using <xref:System.Windows.Application.Resources%2A> allows you to support application-scope themes, where each theme is encapsulated by a single resource dictionary. The following example shows how to set the <xref:System.Windows.ResourceDictionary>.  
  
 [!code-xaml[HOWTOResourceDictionaries#2](~/samples/snippets/csharp/VS_Snippets_Wpf/HowToResourceDictionaries/CSharp/App.xaml#2)]  
  
 The following shows how you can get application-scope resources from the resource dictionary exposed by <xref:System.Windows.Application.Resources%2A> in XAML.  
  
 [!code-xaml[HOWTOResourceDictionaries#4](~/samples/snippets/csharp/VS_Snippets_Wpf/HowToResourceDictionaries/CSharp/MainWindow.xaml#4)]  
  
 The following shows how you can also get the resources in code.  
  
 [!code-csharp[HOWTOResourceDictionaries#3](~/samples/snippets/csharp/VS_Snippets_Wpf/HowToResourceDictionaries/CSharp/MainWindow.xaml.cs#3)]
 [!code-vb[HOWTOResourceDictionaries#3](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HowToResourceDictionaries/VB/MainWindow.xaml.vb#3)]  
  
 There are two considerations to make when using <xref:System.Windows.Application.Resources%2A>. First, the dictionary *key* is an object, so you must use exactly the same object instance when both setting and getting a property value. (Note that the key is case-sensitive when using a string.) Second, the dictionary *value* is an object, so you will have to convert the value to the desired type when getting a property value.  

Some resource types may automatically use a property defined by the type as an explicit key, such as the <xref:System.Windows.Style> and <xref:System.Windows.DataTemplate> types. This may override your `x:Key` value. To guarantee that your `x:Key` key is respected, declare it before the explicit key property. For more information, see [Styles, DataTemplates, and implicit keys](../advanced/xaml-resources-define.md#styles-datatemplates-and-implicit-keys).

## See also

- <xref:System.Windows.ResourceDictionary>
- <xref:System.Windows.Application.Resources%2A>
- [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define)
- [Merged Resource Dictionaries](../advanced/merged-resource-dictionaries.md)
