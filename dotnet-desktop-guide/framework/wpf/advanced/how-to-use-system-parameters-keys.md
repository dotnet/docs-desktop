---
title: "How to: Use System Parameters Keys"
description: Learn how to use system parameter keys to expose system metrics that help you create visuals that are consistent with system settings.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "resource keys [WPF], SystemParameters class"
  - "classes [WPF], SystemParameters"
ms.assetid: 77571283-d16c-45bb-9f69-cafbbf72b21e
---
# How to: Use System Parameters Keys

System resources expose a number of system metrics as resources to help developers create visuals that are consistent with system settings. <xref:System.Windows.SystemParameters> is a class that contains both system parameter values and resource keys that bind to the values—for example, <xref:System.Windows.SystemParameters.FullPrimaryScreenHeight%2A> and <xref:System.Windows.SystemParameters.FullPrimaryScreenHeightKey%2A>. System parameter metrics can be used as either static or dynamic resources. Use a dynamic resource if you want the parameter metric to update automatically while the application runs; otherwise use a static resource.  
  
> [!NOTE]
> Dynamic resources have the keyword *Key* appended to the property name.  
  
 The following example shows how to access and use system parameter dynamic resources to style or customize a button. This XAML example sizes a button by assigning <xref:System.Windows.SystemParameters> values to the button's width and height.  
  
## Example  

 [!code-xaml[SystemRes_snip#ParameterDynamicResources](~/samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/MyApp.xaml#parameterdynamicresources)]  
  
## See also

- [Paint an Area with a System Brush](../graphics-multimedia/how-to-paint-an-area-with-a-system-brush.md)
- [Use SystemFonts](how-to-use-systemfonts.md)
- [Use SystemParameters](how-to-use-systemparameters.md)
