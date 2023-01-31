---
title: "Optimizing Performance: Application Resources"
description: Learn how to optimize the performance of application resources in Windows Presentation Foundation (WPF) applications.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application resources [WPF], performance"
  - "resources [WPF], performance"
  - "static resources [WPF]"
  - "sharing resources [WPF]"
  - "brushes [WPF], performance"
  - "sharing brushes without copying [WPF]"
ms.assetid: 62b88488-c08e-4804-b7de-a1c34fbe929c
---
# Optimizing Performance: Application Resources

WPF allows you to share application resources so that you can support a consistent look or behavior across similar-typed elements. This topic provides a few recommendations in this area that can help you improve the performance of your applications.  
  
 For more information on resources, see [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define).  
  
## Sharing resources  

 If your application uses custom controls and defines resources in a <xref:System.Windows.ResourceDictionary> (or XAML Resources node), it is recommended that you either define the resources at the <xref:System.Windows.Application> or <xref:System.Windows.Window> object level, or define them in the default theme for the custom controls. Defining resources in a custom control's <xref:System.Windows.ResourceDictionary> imposes a performance impact for every instance of that control. For example, if you have performance-intensive brush operations defined as part of the resource definition of a custom control and many instances of the custom control, the application's working set will increase significantly.  
  
 To illustrate this point, consider the following. Let's say you are developing a card game using WPF. For most card games, you need 52 cards with 52 different faces. You decide to implement a card custom control and you define 52 brushes (each representing a card face) in the resources of your card custom control. In your main application, you initially create 52 instances of this card custom control. Each instance of the card custom control generates 52 instances of <xref:System.Windows.Media.Brush> objects, which gives you a total of 52 * 52 <xref:System.Windows.Media.Brush> objects in your application. By moving the brushes out of the card custom control resources to the <xref:System.Windows.Application> or <xref:System.Windows.Window> object level, or defining them in the default theme for the custom control, you reduce the working set of the application, since you are now sharing the 52 brushes among 52 instances of the card control.  
  
## Sharing a Brush without Copying  

 If you have multiple elements using the same <xref:System.Windows.Media.Brush> object, define the brush as a resource and reference it, rather than defining the brush inline in XAML. This method will create one instance and reuse it, whereas defining brushes inline in XAML creates a new instance for each element.  
  
 The following markup sample illustrates this point:  
  
 [!code-xaml[Performance#PerformanceSnippet7](~/samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/BrushResource.xaml#performancesnippet7)]  
  
## Use Static Resources when Possible  

 A static resource provides a value for any XAML property attribute by looking up a reference to an already defined resource. Lookup behavior for that resource is analogous to compile-time lookup.  
  
 A dynamic resource, on the other hand, will create a temporary expression during the initial compilation and thus defer lookup for resources until the requested resource value is actually required in order to construct an object. Lookup behavior for that resource is analogous to run-time lookup, which imposes a performance impact. Use static resources whenever possible in your application, using dynamic resources only when necessary.  
  
 The following markup sample shows the use of both types of resources:  
  
 [!code-xaml[Performance#PerformanceSnippet8](~/samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/DynamicResource.xaml#performancesnippet8)]  
  
## See also

- [Optimizing WPF Application Performance](optimizing-wpf-application-performance.md)
- [Planning for Application Performance](planning-for-application-performance.md)
- [Taking Advantage of Hardware](optimizing-performance-taking-advantage-of-hardware.md)
- [Layout and Design](optimizing-performance-layout-and-design.md)
- [2D Graphics and Imaging](optimizing-performance-2d-graphics-and-imaging.md)
- [Object Behavior](optimizing-performance-object-behavior.md)
- [Text](optimizing-performance-text.md)
- [Data Binding](optimizing-performance-data-binding.md)
- [Other Performance Recommendations](optimizing-performance-other-recommendations.md)
