---
title: Merged resource dictionaries
description: Learn about Windows Presentation Foundation (WPF) for .NET merged resource dictionaries. Define and reference XAML resources outside of a compiled WPF application.
author: adegeo
ms.author: adegeo
ms.date: 03/30/2021
ms.topic: conceptual
helpviewer_keywords: 
  - "merged resource dictionaries [WPF]"
  - "dictionaries [WPF], merged resources"
---

# Merged resource dictionaries (WPF .NET)

Windows Presentation Foundation (WPF) resources support a merged resource dictionary feature. This feature provides a way to define the resources portion of a WPF application outside of the compiled XAML application. Resources can then be shared across applications and are also more conveniently isolated for localization.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Create a merged dictionary

In markup, you use the following syntax to introduce a merged resource dictionary into a page:

```xaml
<Page.Resources>
  <ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
      <ResourceDictionary Source="myresourcedictionary.xaml"/>
      <ResourceDictionary Source="myresourcedictionary2.xaml"/>
    </ResourceDictionary.MergedDictionaries>
  </ResourceDictionary>
</Page.Resources>
```

The <xref:System.Windows.ResourceDictionary> element doesn't have an [x:Key Directive](../../../xaml-services/xkey-directive.md), which is generally required for all items in a resource collection. But another `ResourceDictionary` reference within the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection is a special case, reserved for this merged resource dictionary scenario. Further, the `ResourceDictionary` that introduces a merged resource dictionary can't have an [x:Key Directive](../../../xaml-services/xkey-directive.md).

Typically, each <xref:System.Windows.ResourceDictionary> within the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection specifies a <xref:System.Windows.ResourceDictionary.Source%2A> attribute. The value of `Source` should be a uniform resource identifier (URI) that resolves to the location of the resources file to be merged. The destination of that URI must be another XAML file, with `ResourceDictionary` as its root element.

> [!NOTE]
> It's legal to define resources within a <xref:System.Windows.ResourceDictionary> that's specified as a merged dictionary, either as an alternative to specifying <xref:System.Windows.ResourceDictionary.Source%2A>, or in addition to whatever resources are included from the specified source. However, this isn't a common scenario. The main scenario for merged dictionaries is to merge resources from external file locations. If you want to specify resources within the markup for a page, define these in the main `ResourceDictionary` and not in the merged dictionaries.

## Merged dictionary behavior

Resources in a merged dictionary occupy a location in the resource lookup scope that's just after the scope of the main resource dictionary they are merged into. Although a resource key must be unique within any individual dictionary, a key can exist multiple times in a set of merged dictionaries. In this case, the resource that's returned will come from the last dictionary found sequentially in the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection. If the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection was defined in XAML, then the order of the merged dictionaries in the collection is the order of the elements as provided in the markup. If a key is defined in the primary dictionary and also in a dictionary that was merged, then the resource that's returned will come from the primary dictionary. These scoping rules apply equally for both static resource references and dynamic resource references.

## Merged dictionaries and code

Merged dictionaries can be added to a `Resources` dictionary through code. The default, initially empty <xref:System.Windows.ResourceDictionary> that exists for any `Resources` property also has a default, initially empty <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection property. To add a merged dictionary through code, you obtain a reference to the desired primary `ResourceDictionary`, get its `MergedDictionaries` property value, and call `Add` on the generic `Collection` that's contained in `MergedDictionaries`. The object you add must be a new `ResourceDictionary`.

In code, you don't set the <xref:System.Windows.ResourceDictionary.Source%2A> property. Instead, you must obtain a `ResourceDictionary` object by either creating one or loading one. One way to load an existing `ResourceDictionary` to call <xref:System.Windows.Markup.XamlReader.Load%2A?displayProperty=nameWithType> on an existing XAML file stream that has a `ResourceDictionary` root, then casting the return value to `ResourceDictionary`.

## Merged dictionary URIs

There are several techniques for how to include a merged resource dictionary, which are indicated by the uniform resource identifier (URI) format that you use. Broadly speaking, these techniques can be divided into two categories: resources that are compiled as part of the project, and resources that aren't compiled as part of the project.

For resources that are compiled as part of the project, you can use a relative path that refers to the resource location. The relative path is evaluated during compilation. Your resource must be defined as part of the project as a **Resource** build action. If you include a resource _.xaml_ file in the project as **Resource**, you don't need to copy the resource file to the output directory, the resource is already included within the compiled application. You can also use **Content** build action, but you must then copy the files to the output directory and also deploy the resource files in the same path relationship to the executable.

> [!NOTE]
> Don't use the **Embedded Resource** build action. The build action itself is supported for WPF applications, but the resolution of <xref:System.Windows.ResourceDictionary.Source%2A> doesn't incorporate <xref:System.Resources.ResourceManager>, and thus cannot separate the individual resource out of the stream. You could still use **Embedded Resource** for other purposes so long as you also used <xref:System.Resources.ResourceManager> to access the resources.

<a name="packuri"></a>

A related technique is to use a **Pack URI** to a XAML file, and refer to it as **Source**. **Pack URI** enables references to components of referenced assemblies and other techniques. For more information on **Pack URIs**, see [WPF Application Resource, Content, and Data Files](../../../framework/wpf/app-development/wpf-application-resource-content-and-data-files.md).

For resources that aren't compiled as part of the project, the URI is evaluated at run time. You can use a common URI transport such as _file:_ or _http:_ to refer to the resource file. The disadvantage of using the non-compiled resource approach is that _file:_ access requires additional deployment steps, and _http:_ access implies the Internet security zone.

## Reusing merged dictionaries

You can reuse or share merged resource dictionaries between applications, because the resource dictionary to merge can be referenced through any valid uniform resource identifier (URI). Exactly how you do this depends on your application deployment strategy and which application model you follow. The [previously mentioned **Pack URI** strategy](#packuri) provides a way to commonly source a merged resource across multiple projects during development by sharing an assembly reference. In this scenario the resources are still distributed by the client, and at least one of the applications must deploy the referenced assembly. It's also possible to reference merged resources through a distributed URI that uses the _http:_ protocol.

Writing merged dictionaries as local application files or to local shared storage is another possible merged dictionary and application deployment scenario.

## Localization

If resources that need to be localized are isolated to dictionaries that are merged into primary dictionaries, and kept as loose XAML, these files can be localized separately. This technique is a lightweight alternative to localizing the satellite resource assemblies. For details, see [WPF Globalization and Localization Overview](../../../framework/wpf/advanced/wpf-globalization-and-localization-overview.md).

## See also

- <xref:System.Windows.ResourceDictionary>
- [Overview of XAML resources](xaml-resources-overview.md)
- [Resources in code](xaml-resources-and-code.md)
- [WPF Application Resource, Content, and Data Files](../../../framework/wpf/app-development/wpf-application-resource-content-and-data-files.md)
- [WPF Globalization and Localization Overview](../../../framework/wpf/advanced/wpf-globalization-and-localization-overview.md)
