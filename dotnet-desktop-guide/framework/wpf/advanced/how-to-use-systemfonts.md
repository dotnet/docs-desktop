---
title: "How to: Use SystemFonts"
description: An example of using the SystemFonts class to style and customize a button in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "system fonts [WPF]"
  - "fonts [WPF], system fonts"
  - "classes [WPF], SystemFonts"
ms.assetid: 3f46a4ec-2225-408a-8123-8838a8f7057a
---
# How to: Use SystemFonts

This example shows how to use the static resources of the <xref:System.Windows.SystemFonts> class in order to style or customize a button.  
  
## Example  

 System resources expose several system-determined values as both resources and properties in order to help you create visuals that are consistent with system settings. <xref:System.Windows.SystemFonts> is a class that contains both system font values as static properties, and properties that reference resource keys that can be used to access those values dynamically at run time. For example, <xref:System.Windows.SystemFonts.CaptionFontFamily%2A> is a <xref:System.Windows.SystemFonts> value, and <xref:System.Windows.SystemFonts.CaptionFontFamilyKey%2A> is a corresponding resource key.  
  
 In XAML, you can use the members of <xref:System.Windows.SystemFonts> as either static properties or dynamic resource references (with the static property value as the key). Use a dynamic resource reference if you want the font metric to automatically update while the application runs; otherwise, use a static value reference.  
  
> [!NOTE]
> The resource keys have the suffix "Key" appended to the property name.  
  
 The following example shows how to access and use the properties of <xref:System.Windows.SystemFonts> as static values in order to style or customize a button. This markup example assigns <xref:System.Windows.SystemFonts> values to a button.  
  
 [!code-xaml[SystemRes_snip#FontStaticResources](~/samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/Pane1.xaml#fontstaticresources)]  
  
 To use the values of <xref:System.Windows.SystemFonts> in code, you do not have to use either a static value or a dynamic resource reference. Instead, use the non-key properties of the <xref:System.Windows.SystemFonts> class. Although the non-key properties are apparently defined as static properties, the run-time behavior of WPF as hosted by the system will reevaluate the properties in real time and will properly account for user-driven changes to system values. The following example shows how to specify the font settings of a button.  
  
 [!code-csharp[SystemRes_snip#FontResourcesCode](~/samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/Pane1.xaml.cs#fontresourcescode)]
 [!code-vb[SystemRes_snip#FontResourcesCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SystemRes_snip/VisualBasic/Pane1.xaml.vb#fontresourcescode)]  
  
## See also

- <xref:System.Windows.SystemFonts>
- [Paint an Area with a System Brush](../graphics-multimedia/how-to-paint-an-area-with-a-system-brush.md)
- [Use SystemParameters](how-to-use-systemparameters.md)
- [Use System Fonts Keys](how-to-use-system-fonts-keys.md)
- [How-to Topics](resources-how-to-topics.md)
- [x:Static Markup Extension](/dotnet/desktop/xaml-services/xstatic-markup-extension)
- [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define)
- [DynamicResource Markup Extension](dynamicresource-markup-extension.md)
