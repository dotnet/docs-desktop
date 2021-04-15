---
title: WPF resources in code
description: Learn about how Windows Presentation Foundation (WPF) resources, typically defined and used in XAML, can be used in code. Resources can be accessed, created, and managed in code.
author: adegeo
ms.author: adegeo
ms.date: 04/01/2021
ms.topic: overview
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keys [WPF], using objects as"
  - "resources [WPF], accessing from procedural code"
  - "procedural code [WPF], creating resources with"
  - "procedural code [WPF], accessing resources from"
  - "resources [WPF], creating with procedural code"
---

# Resources in code (WPF .NET)

This overview concentrates on how Windows Presentation Foundation (WPF) resources can be accessed or created using code rather than XAML syntax. For more information on general resource usage and resources from a XAML syntax perspective, see [Overview of XAML resources](xaml-resources-overview.md).

## Accessing resources from code

The keys that identify XAML defined resources are also used to retrieve specific resources if you request the resource in code. The simplest way to retrieve a resource from code is to call either the <xref:System.Windows.FrameworkElement.FindResource%2A> or the <xref:System.Windows.FrameworkElement.TryFindResource%2A> method from framework-level objects in your application. The behavioral difference between these methods is what happens if the requested key isn't found. <xref:System.Windows.FrameworkElement.FindResource%2A> raises an exception. <xref:System.Windows.FrameworkElement.TryFindResource%2A> won't raise an exception but returns `null`. Each method takes the resource key as an input parameter, and returns a loosely typed object.

Typically, a resource key is a string, but there are [occasional nonstring usages](#using-objects-as-keys). The lookup logic for code resource resolution is the same as the dynamic resource reference XAML case. The search for resources starts from the calling element, then continues through parent elements in the logical tree. The lookup continues onwards into application resources, themes, and system resources if necessary. A code request for a resource will properly account for changes to those resources that happened during runtime.

The following code example demonstrates a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler that finds a resource by key, and uses the returned value to set a property.

:::code language="csharp" source="./snippets/xaml-resources-and-code/csharp/MainWindow.xaml.cs" id="ButtonBrush":::
:::code language="vb" source="./snippets/xaml-resources-and-code/vb/MainWindow.xaml.vb" id="ButtonBrush":::

An alternative method for assigning a resource reference is <xref:System.Windows.FrameworkElement.SetResourceReference%2A>. This method takes two parameters: the key of the resource, and the identifier for a particular dependency property that's present on the element instance to which the resource value should be assigned. Functionally, this method is the same and has the advantage of not requiring any casting of return values.

Still another way to access resources programmatically is to access the contents of the <xref:System.Windows.FrameworkElement.Resources%2A> property as a dictionary. Resource dictionaries are used to add new resources to existing collections, check to see if a given key name is already used by the collection, and other operations. If you're writing a WPF application entirely in code, you can also create the entire collection in code, assign resources to it. The collection can then be assigned to the <xref:System.Windows.FrameworkElement.Resources%2A> property of an element. This is described in the next section.

You can index within any given <xref:System.Windows.FrameworkElement.Resources%2A> collection, using a specific key as the index. Resources accessed in this way don't follow the normal runtime rules of resource resolution. You're only accessing that particular collection. Resource lookup doesn't traverse the resource scope to the root or the application if no valid object was found at the requested key. However, this approach may have performance advantages in some cases precisely because the scope of the search for the key is more constrained. For more information about how to work with a resource dictionary directly, see the <xref:System.Windows.ResourceDictionary> class.

## Creating resources with code

If you want to create an entire WPF application in code, you might also want to create any resources in that application in code. To achieve this, create a new <xref:System.Windows.ResourceDictionary> instance, and then add all the resources to the dictionary using successive calls to <xref:System.Windows.ResourceDictionary.Add%2A?displayProperty=nameWithType>. Then, assign the created <xref:System.Windows.ResourceDictionary> to set the <xref:System.Windows.FrameworkElement.Resources%2A> property on an element that's present in a page scope, or the <xref:System.Windows.Application.Resources%2A?displayProperty=nameWithType>. You could also maintain the <xref:System.Windows.ResourceDictionary> as a standalone object without adding it to an element. However, if you do this, you must access the resources within it by item key, as if it were a generic dictionary. A <xref:System.Windows.ResourceDictionary> that's not attached to an element `Resources` property wouldn't exist as part of the element tree and has no scope in a lookup sequence that can be used by <xref:System.Windows.FrameworkElement.FindResource%2A> and related methods.

## Using objects as keys

Most resource usages will set the key of the resource to be a string. However, various WPF features deliberately use the object type as a key instead of a string. The capability of having the resource be keyed by an object type is used by the WPF style and theming support. The styles and themes that become the default for an otherwise non-styled control are each keyed by the <xref:System.Type> of the control that they should apply to.

Being keyed by type provides a reliable lookup mechanism that works on default instances of each control type. The type can be detected by reflection and used for styling derived classes even though the derived type otherwise has no default style. You can specify a <xref:System.Type> key for a resource defined in XAML by using the [x:Type Markup Extension](/dotnet/desktop-wpf/xaml-services/xtype-markup-extension). Similar extensions exist for other nonstring key usages that support WPF features, such as [ComponentResourceKey Markup Extension](../../../framework/wpf/advanced/componentresourcekey-markup-extension.md).

For more information, see [Styles, DataTemplates, and implicit keys](xaml-resources-overview.md#styles-datatemplates-and-implicit-keys).

## See also

- [Overview of XAML resources](xaml-resources-overview.md)
- [How to define and reference a WPF resource](xaml-resources-how-to-define-and-reference.md)
- [How to use system resources](xaml-resources-how-to-use-system.md)
- [How to use application resources](xaml-resources-how-to-use-application.md)
