---
title: "How to: Use Application Resources"
description: Learn how to use Application Resources so that resources defined at the application level can be accessed by all other pages that are part of the application.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "application resources [WPF]"
  - "resources [WPF], application resources"
ms.assetid: 507ea937-5191-406b-8797-0a3d9f94156d
---
# How to: Use Application Resources

This example shows how to use application resources.  
  
## Example  

 The following example shows an application definition file. The application definition file defines a resource section (a value for the <xref:System.Windows.Application.Resources%2A> property). Resources defined at the application level can be accessed by all other pages that are part of the application. In this case, the resource is a declared style. Because a complete style that includes a control template can be lengthy, this example omits the control template that is defined within the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> property setter of the style.  
  
 [!code-xaml[ResourcesApplication#PreTemplateResource](~/samples/snippets/csharp/VS_Snippets_Wpf/ResourcesApplication/CS/app.xaml#pretemplateresource)]  
[!code-xaml[ResourcesApplication#PostTemplateResource](~/samples/snippets/csharp/VS_Snippets_Wpf/ResourcesApplication/CS/app.xaml#posttemplateresource)]  
  
 The following example shows a XAML page that references the application-level resource that the previous example defined. The resource is referenced by using a     [StaticResource Markup Extension](staticresource-markup-extension.md) that specifies the unique resource key for the requested resource. No resource with key of "GelButton" is found in the current page, so the resource lookup scope for the requested resource continues beyond the current page and into the defined application-level resources.  
  
 [!code-xaml[ResourcesApplication#ConsumingPage](~/samples/snippets/csharp/VS_Snippets_Wpf/ResourcesApplication/CS/page1.xaml#consumingpage)]  
  
## See also

- [XAML Resources](/dotnet/desktop-wpf/fundamentals/xaml-resources-define)
- [Application Management Overview](../app-development/application-management-overview.md)
- [How-to Topics](resources-how-to-topics.md)
