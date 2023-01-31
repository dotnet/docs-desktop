---
title: "Code-Behind and XAML"
description: Learn about code-behind, which describes code that is joined with markup-defined objects when an XAML page is markup-compiled, in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XAML [WPF], code-behind"
  - "code-behind files [WPF], XAML"
ms.assetid: 9df6d3c9-aed3-471c-af36-6859b19d999f
---
# Code-Behind and XAML in WPF

<a name="introduction"></a> Code-behind is a term used to describe the code that is joined with markup-defined objects, when a XAML page is markup-compiled. This topic describes requirements for code-behind as well as an alternative inline code mechanism for code in XAML.  
  
 This topic contains the following sections:  
  
- [Prerequisites](#Prerequisites)  
  
- [Code-Behind and the XAML Language](#codebehind_and_the_xaml_language)  
  
- [Code-behind, Event Handler, and Partial Class Requirements in WPF](#Code_behind__Event_Handler__and_Partial_Class)  
  
- [x:Code](#x_Code)  
  
- [Inline Code Limitations](#Inline_Code_Limitations)  
  
<a name="Prerequisites"></a>

## Prerequisites  

 This topic assumes that you have read the [XAML in WPF](xaml-in-wpf.md) and have some basic knowledge of the CLR and object-oriented programming.  
  
<a name="codebehind_and_the_xaml_language"></a>

## Code-Behind and the XAML Language  

 The XAML language includes language-level features that make it possible to associate code files with markup files, from the markup file side. Specifically, the XAML language defines the language features [x:Class Directive](/dotnet/desktop/xaml-services/xclass-directive), [x:Subclass Directive](/dotnet/desktop/xaml-services/xsubclass-directive), and [x:ClassModifier Directive](/dotnet/desktop/xaml-services/xclassmodifier-directive). Exactly how the code should be produced, and how to integrate markup and code, is not part of what the XAML language specifies. It is left up to frameworks such as WPF to determine how to integrate the code, how to use XAML in the application and programming models, and the build actions or other support that all this requires.  
  
<a name="Code_behind__Event_Handler__and_Partial_Class"></a>

## Code-behind, Event Handler, and Partial Class Requirements in WPF  
  
- The partial class must derive from the type that backs the root element.  
  
- Note that under the default behavior of the markup compile build actions, you can leave the derivation blank in the partial class definition on the code-behind side. The compiled result will assume the page root's backing type to be the basis for the partial class, even if it not specified. However, relying on this behavior is not a best practice.  
  
- The event handlers you write in the code-behind must be instance methods and cannot be static methods. These methods must be defined by the partial class within the CLR namespace identified by `x:Class`. You cannot qualify the name of an event handler to instruct a XAML processor to look for an event handler for event wiring in a different class scope.  
  
- The handler must match the delegate for the appropriate event in the backing type system.  
  
- For the Microsoft Visual Basic language specifically, you can use the language-specific `Handles` keyword to associate handlers with instances and events in the handler declaration, instead of attaching handlers with attributes in WPF event system, such as certain routed event scenarios or attached events. For details, see [Visual Basic and WPF Event Handling](visual-basic-and-wpf-event-handling.md).  
  
<a name="x_Code"></a>

## x:Code  

 [x:Code](/dotnet/desktop/xaml-services/xcode-intrinsic-xaml-type) is a directive element defined in WPF schema) will not try to interpret the contents literally as XML.  
  
 [!code-xaml[XAMLOvwSupport#ButtonWithInlineCode](~/samples/snippets/csharp/VS_Snippets_Wpf/XAMLOvwSupport/CSharp/page4.xaml#buttonwithinlinecode)]  
  
<a name="Inline_Code_Limitations"></a>

## Inline Code Limitations  

 You should consider avoiding or limiting the use of inline code. In terms of architecture and coding philosophy, maintaining a separation between markup and code-behind keeps the designer and developer roles much more distinct. On a more technical level, the code that you write for inline code can be awkward to write, because you are always writing into the WPF mappings include most but not all CLR namespaces that are present in the WPF assemblies; you will have to fully qualify calls to types and members contained within the other CLR namespaces. You also cannot define anything beyond the partial class in the inline code, and all user code entities you reference must exist as a member or variable within the generated partial class. Other language specific programming features, such as macros or `#ifdef` against global variables or build variables, are also not available. For more information, see [x:Code Intrinsic XAML Type](/dotnet/desktop/xaml-services/xcode-intrinsic-xaml-type).  
  
## See also

- [XAML in WPF](xaml-in-wpf.md)
- [x:Code Intrinsic XAML Type](/dotnet/desktop/xaml-services/xcode-intrinsic-xaml-type)
- [Building a WPF Application](../app-development/building-a-wpf-application-wpf.md)
- [XAML Syntax In Detail](xaml-syntax-in-detail.md)
