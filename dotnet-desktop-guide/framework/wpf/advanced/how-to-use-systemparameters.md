---
title: "How to: Use SystemParameters"
description: Learn how to use the SystemParameters class and its properties to style or customize a button.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "classes [WPF], SystemParameters"
ms.assetid: 02e7a5de-94eb-4953-b91c-52e6c872ad5b
---
# How to: Use SystemParameters

This example shows how to access and use the properties of <xref:System.Windows.SystemParameters> in order to style or customize a button.  
  
## Example  

 System resources expose several system based settings as resources in order to help you create visuals that are consistent with system settings. <xref:System.Windows.SystemParameters> is a class that contains both system parameter value properties, and resource keys that bind to the values. For example, <xref:System.Windows.SystemParameters.FullPrimaryScreenHeight%2A> is a <xref:System.Windows.SystemParameters> property value and <xref:System.Windows.SystemParameters.FullPrimaryScreenHeightKey%2A> is the corresponding resource key.  
  
 In XAML, you can use the members of <xref:System.Windows.SystemParameters> as either a static property usage, or a dynamic resource references (with the static property value as the key). Use a dynamic resource reference if you want the system based value to update automatically while the application runs; otherwise, use a static reference. Resource keys have the suffix `Key` appended to the property name.  
  
 The following example shows how to access and use the static values of <xref:System.Windows.SystemParameters> to style or customize a button. This markup example sizes a button by applying <xref:System.Windows.SystemParameters> values to a button.  
  
 [!code-xaml[SystemRes_snip#ParameterStaticResources](~/samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/Pane1.xaml#parameterstaticresources)]  
  
 To use the values of <xref:System.Windows.SystemParameters> in code, you do not have to use either static references or dynamic resource references. Instead, use the values of the <xref:System.Windows.SystemParameters> class. Although the non-key properties are apparently defined as static properties, the runtime behavior of WPF as hosted by the system will reevaluate the properties in realtime, and will properly account for user-driven changes to system values. The following example shows how to set the width and height of a button by using <xref:System.Windows.SystemParameters> values.  
  
 [!code-csharp[SystemRes_snip#ParameterResourcesCode](~/samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/Pane1.xaml.cs#parameterresourcescode)]
 [!code-vb[SystemRes_snip#ParameterResourcesCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SystemRes_snip/VisualBasic/Pane1.xaml.vb#parameterresourcescode)]  
  
## See also

- <xref:System.Windows.SystemParameters>
- [Paint an Area with a System Brush](../graphics-multimedia/how-to-paint-an-area-with-a-system-brush.md)
- [Use SystemFonts](how-to-use-systemfonts.md)
- [Use System Parameters Keys](how-to-use-system-parameters-keys.md)
- [How-to Topics](resources-how-to-topics.md)
