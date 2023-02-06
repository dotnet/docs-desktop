---
title: Globalization
description: Learn about globalization support in Windows Presentation Foundation (WPF) to help you write WPF applications for the global market.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "XAML [WPF], international user interface"
  - "XAML [WPF], globalization"
  - "international user interface [WPF], XAML"
  - "globalization [WPF]"
ms.assetid: 4571ccfe-8a60-4f06-9b37-7ac0b1c2d10f
---
# Globalization for WPF

This topic introduces issues that you should be aware of when writing Windows Presentation Foundation (WPF) applications for the global market. The globalization programming elements are defined in .NET in the <xref:System.Globalization> namespace.

<a name="xaml_globalization"></a>

## XAML Globalization

 Extensible Application Markup Language (XAML) is based on XML and takes advantage of the globalization support defined in the XML specification. The following sections describe some XAML features that you should be aware of.

<a name="char_reference"></a>

### Character References

A character reference gives the UTF16 code unit of the particular Unicode character it represents, in either decimal or hexadecimal. The following example shows a decimal character reference for the COPTIC CAPITAL LETTER HORI, or 'Ϩ':

```xaml
&#1000;
```

The following example shows a hexadecimal character reference. Notice that it has an **x** in front of the hexadecimal number.

```xaml
&#x3E8;
```

<a name="encoding"></a>

### Encoding

 The encoding supported by XAML are ASCII, Unicode UTF-16, and UTF-8. The encoding statement is at the beginning of XAML document. If no encoding attribute exists and there is no byte-order, the parser defaults to UTF-8. UTF-8 and UTF-16 are the preferred encodings. UTF-7 is not supported. The following example demonstrates how to specify a UTF-8 encoding in a XAML file.

```xaml
?xml encoding="UTF-8"?
```

<a name="lang_attrib"></a>

### Language Attribute

 XAML uses [xml:lang](/dotnet/desktop/xaml-services/xml-language-handling) to represent the language attribute of an element.  To take advantage of the <xref:System.Globalization.CultureInfo> class, the language attribute value needs to be one of the culture names predefined by <xref:System.Globalization.CultureInfo>. [xml:lang](/dotnet/desktop/xaml-services/xml-language-handling) is inheritable in the element tree (by XML rules, not necessarily because of dependency property inheritance) and its default value is an empty string if it is not assigned explicitly.

 The language attribute is very useful for specifying dialects. For example, French has different spelling, vocabulary, and pronunciation in France, Quebec, Belgium, and Switzerland. Also Chinese, Japanese, and Korean share code points in Unicode, but the ideographic shapes are different and they use totally different fonts.

 The following Extensible Application Markup Language (XAML) example uses the `fr-CA` language attribute to specify Canadian French.

```xaml
<TextBlock xml:lang="fr-CA">Découvrir la France</TextBlock>
```

<a name="unicode"></a>

### Unicode

 WPF application can use <xref:System.Globalization.StringInfo> to manipulate strings without understanding whether they have surrogate pairs or combining characters.

<a name="design_intl_ui_with_xaml"></a>

## Designing an International User Interface with XAML

 This section describes user interface (UI) features that you should consider when writing an application.

<a name="intl_text"></a>

### International Text

 WPF includes built-in processing for all Microsoft .NET Framework supported writing systems.

 The following scripts are currently supported:

- Arabic

- Bengali

- Devanagari

- Cyrillic

- Greek

- Gujarati

- Gurmukhi

- Hebrew

- Ideographic scripts

- Kannada

- Lao

- Latin

- Malayalam

- Mongolian

- Odia

- Syriac

- Tamil

- Telugu

- Thaana

- Thai*

- Tibetan

 *In this release the display and editing of Thai text is supported; word breaking is not.

 The following scripts are not currently supported:

- Khmer

- Korean Old Hangul

- Myanmar

- Sinhala

 All the writing system engines support OpenType fonts. OpenType fonts can include the OpenType layout tables that enable font creators to design better international and high-end typographic fonts. The OpenType font layout tables contain information about glyph substitutions, glyph positioning, justification, and baseline positioning, enabling text-processing applications to improve text layout.

 OpenType fonts allow the handling of large glyph sets using Unicode encoding. Such encoding enables broad international support as well as for typographic glyph variants.

 WPF text rendering is powered by Microsoft ClearType sub-pixel technology that supports resolution independence. This significantly improves legibility and provides the ability to support high quality magazine style documents for all scripts.

<a name="intl_layout"></a>

### International Layout

 WPF provides a very convenient way to support horizontal, bidirectional, and vertical layouts. In presentation framework the <xref:System.Windows.FrameworkElement.FlowDirection%2A> property can be used to define layout. The flow direction patterns are:

- *LeftToRight* - horizontal layout for Latin, East Asian and so forth.

- *RightToLeft* - bidirectional for Arabic, Hebrew and so forth.

<a name="developing_localizable_apps"></a>

## Developing Localizable Applications

 When you write an application for global consumption you should keep in mind that the application must be localizable. The following topics point out things to consider.

<a name="mui"></a>

### Multilingual User Interface

 Multilingual User Interfaces (MUI) is a Microsoft support for switching UIs from one language to another. A WPF application uses the assembly model to support MUI. One application contains language-neutral assemblies as well as language-dependent satellite resource assemblies. The entry point is a managed .EXE in the main assembly.  WPF resource loader takes advantage of the Framework's resource manager to support resource lookup and fallback. Multiple language satellite assemblies work with the same main assembly. The resource assembly that is loaded depends on the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> of the current thread.

<a name="localizable_ui"></a>

### Localizable User Interface

 UI. UI and use a programming language such as C# to react to user interaction.

 From a resource point of view, a UI is a resource element and therefore its final distribution format must be localizable to support international languages. Because XAML cannot handle events many XAML applications contain blocks of code to do this. For more information, see [XAML in WPF](xaml-in-wpf.md). Code is stripped out and compiled into different binaries when a XAML file is tokenized into the BAML form of XAML. The BAML form of XAML files, images, and other types of managed resource objects are embedded in the satellite resource assembly, which can be localized into other languages, or the main assembly when localization is not required.

> [!NOTE]
> WPF applications support all the FrameworkCLR resources including string tables, images, and so forth.

<a name="building_localizable_apps"></a>

### Building Localizable Applications

 Localization means to adapt a UI to different cultures. To make a WPF application localizable, developers need to build all the localizable resources into a resource assembly. The resource assembly is localized into different languages, and the code-behind uses resource management API to load. One of the files required for a WPF application is a project file (.proj). All resources that you use in your application should be included in the project file. The following example from a .csproj file shows how to do this.

```xml
<Resource Include="data\picture1.jpg"/>
<EmbeddedResource Include="data\stringtable.en-US.restext"/>
```

 To use a resource in your application instantiate a <xref:System.Resources.ResourceManager> and load the resource you want to use. The following example demonstrates how to do this.

 [!code-csharp[LocalizationResources#2](~/samples/snippets/csharp/VS_Snippets_Wpf/LocalizationResources/CSharp/page1.xaml.cs#2)]

<a name="using_clickonce"></a>

## Using ClickOnce with Localized Applications

 ClickOnce is a new Windows Forms deployment technology that will ship with Visual Studio 2005. It enables application installation and upgrading of Web applications. When an application that was deployed with ClickOnce is localized it can only be viewed on the localized culture. For example, if a deployed application is localized to Japanese it can only be viewed on Japanese Microsoft Windows not on English Windows. This presents a problem because it is a common scenario for Japanese users to run an English version of Windows.

 The solution to this problem is setting the neutral language fallback attribute. An application developer can optionally remove resources from the main assembly and specify that the resources can be found in a satellite assembly corresponding to a specific culture. To control this process use the <xref:System.Resources.NeutralResourcesLanguageAttribute>. The constructor of the <xref:System.Resources.NeutralResourcesLanguageAttribute> class has two signatures, one that takes an <xref:System.Resources.UltimateResourceFallbackLocation> parameter to specify the location where the <xref:System.Resources.ResourceManager> should extract the fallback resources: main assembly or satellite assembly. The following example shows how to use the attribute. For the ultimate fallback location, the code causes the <xref:System.Resources.ResourceManager> to look for the resources in the "de" subdirectory of the directory of the currently executing assembly.

```csharp
[assembly: NeutralResourcesLanguageAttribute(
    "de" , UltimateResourceFallbackLocation.Satellite)]
```

## See also

- [WPF Globalization and Localization Overview](wpf-globalization-and-localization-overview.md)
