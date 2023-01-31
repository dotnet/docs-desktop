---
title: "Inline Styles and Templates"
description: Learn about inline styles and templates and how to make resource references to existing styles and templates rather than define new ones inline. 
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "inline templates [WPF]"
  - "styles [WPF], inline"
  - "templates [WPF], inline"
  - "inline styles [WPF]"
ms.assetid: 69a1a3f9-acb5-4e2c-9c43-2e376c055ac4
---
# Inline Styles and Templates

XAML that take the types <xref:System.Windows.Style> and <xref:System.Windows.FrameworkTemplate> almost always make resource references to existing styles and templates rather than define new ones inline.  
  
## Limitations of Inline Styles and Templates  

 In Extensible Application Markup Language (XAML), style and template properties can technically be set in one of two ways. You can use attribute syntax to reference a style that was defined within a resource, for example `<`*object*`Style="{StaticResource`*myResourceKey*`}" .../>`. Or you can use property element syntax to define a style inline, for instance:  
  
 `<` *object* `>`  
  
 `<` *object* `.Style>`  
  
 `<` `Style`  `.../>`  
  
 `</` *object* `.Style>`  
  
 `</` *object* `>`  
  
 The attribute usage is much more common. A style that is defined inline and not defined in resources is necessarily scoped to the containing element only, and cannot be re-used as easily because it has no resource key. In general a resource-defined style is more versatile and useful, and is more in keeping with the general Windows Presentation Foundation (WPF) programming model principle of separating program logic in code from design in markup.  
  
 Usually there is no reason to set a style or template inline, even if you only intend to use that style or template in that location. Most elements that can take a style or template also support a content property and a content model. If you are only using whatever logical tree you create through styling or templating once, it would be even easier to just fill that content property with the equivalent child elements in direct markup. This would bypass the style and template mechanisms altogether.  
  
 Other syntaxes enabled by markup extensions that return an object are also possible for styles and templates. Two such extensions that have possible scenarios include [TemplateBinding](templatebinding-markup-extension.md) and <xref:System.Windows.Data.Binding>.  
  
## See also

- [Styling and Templating](../controls/styles-templates-overview.md)
