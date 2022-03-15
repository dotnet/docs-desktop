---
title: Pack URIs
description: Learn about the many ways to use uniform resource identifiers (URIs) to identify and load files in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
helpviewer_keywords:
  - "pack URI scheme [WPF]"
  - "loading embedded resources [WPF]"
  - "URIs (Uniform Resource Identifiers)"
  - "Uniform Resource Identifiers (URIs)"
  - "loading non-resource files"
  - "application management [WPF]"
ms.assetid: 43adb517-21a7-4df3-98e8-09e9cdf764c4
---
# Pack URIs in WPF

In Windows Presentation Foundation (WPF), uniform resource identifiers (URIs) are used to identify and load files in many ways, including the following:

- Specifying the user interface (UI) to show when an application first starts.

- Loading images.

- Navigating to pages.

- Loading non-executable data files.

Furthermore, URIs can be used to identify and load files from a variety of locations, including the following:

- The current assembly.

- A referenced assembly.

- A location relative to an assembly.

- The application's site of origin.

To provide a consistent mechanism for identifying and loading these types of files from these locations, WPF leverages the extensibility of the *pack URI scheme*. This topic provides an overview of the scheme, covers how to construct pack URIs for a variety of scenarios, discusses absolute and relative URIs and URI resolution, before showing how to use pack URIs from both markup and code.

<a name="The_Pack_URI_Scheme"></a>

## The Pack URI Scheme

The pack URI scheme is used by the [Open Packaging Conventions](https://www.ecma-international.org/publications/standards/Ecma-376.htm) (OPC) specification, which describes a model for organizing and identifying content. The key elements of this model are packages and parts, where a *package* is a logical container for one or more logical *parts*. The following figure illustrates this concept.

![Package and Parts diagram](./media/pack-uris-in-wpf/wpf-package-parts-diagram.png)

To identify parts, the OPC specification leverages the extensibility of RFC 2396 (Uniform Resource Identifiers (URI): Generic Syntax) to define the pack URI scheme.

The scheme that is specified by a URI is defined by its prefix; http, ftp, and file are well-known examples. The pack URI scheme uses "pack" as its scheme, and contains two components: authority and path. The following is the format for a pack URI.

pack://*authority*/*path*

The *authority* specifies the type of package that a part is contained by, while the *path* specifies the location of a part within a package.

This concept is illustrated by the following figure:

![Relationship among package, authority, and path](./media/pack-uris-in-wpf/wpf-relationship-diagram.png)

Packages and parts are analogous to applications and files, where an application (package) can include one or more files (parts), including:

- Resource files that are compiled into the local assembly.

- Resource files that are compiled into a referenced assembly.

- Resource files that are compiled into a referencing assembly.

- Content files.

- Site of origin files.

To access these types of files, WPF supports two authorities: application:/// and siteoforigin:///. The application:/// authority identifies application data files that are known at compile time, including resource and content files. The siteoforigin:/// authority identifies site of origin files. The scope of each authority is shown in the following figure.

![Pack URI diagram](./media/pack-uris-in-wpf/wpf-pack-uri-scheme.png)

> [!NOTE]
> The authority component of a pack URI is an embedded URI that points to a package and must conform to RFC 2396. Additionally, the "/" character must be replaced with the "," character, and reserved characters such as "%" and "?" must be escaped. See the OPC for details.

The following sections explain how to construct pack URIs using these two authorities in conjunction with the appropriate paths for identifying resource, content, and site of origin files.

<a name="Resource_File_Pack_URIs___Local_Assembly"></a>

## Resource File Pack URIs

Resource files are configured as MSBuild `Resource` items and are compiled into assemblies. WPF supports the construction of pack URIs that can be used to identify resource files that are either compiled into the local assembly or compiled into an assembly that is referenced from the local assembly.

<a name="Local_Assembly_Resource_File"></a>

### Local Assembly Resource File

The pack URI for a resource file that is compiled into the local assembly uses the following authority and path:

- **Authority**: application:///.

- **Path**: The name of the resource file, including its path, relative to the local assembly project folder root.

The following example shows the pack URI for a XAML resource file that is located in the root of the local assembly's project folder.

`pack://application:,,,/ResourceFile.xaml`

The following example shows the pack URI for a XAML resource file that is located in a subfolder of the local assembly's project folder.

`pack://application:,,,/Subfolder/ResourceFile.xaml`

<a name="Resource_File_Pack_URIs___Referenced_Assembly"></a>

### Referenced Assembly Resource File

The pack URI for a resource file that is compiled into a referenced assembly uses the following authority and path:

- **Authority**: application:///.

- **Path**: The name of a resource file that is compiled into a referenced assembly. The path must conform to the following format:

  *AssemblyShortName*{*;Version*]{*;PublicKey*];component/*Path*

  - **AssemblyShortName**: the short name for the referenced assembly.

  - **;Version** [optional]: the version of the referenced assembly that contains the resource file. This is used when two or more referenced assemblies with the same short name are loaded.

  - **;PublicKey** [optional]: the public key that was used to sign the referenced assembly. This is used when two or more referenced assemblies with the same short name are loaded.

  - **;component**: specifies that the assembly being referred to is referenced from the local assembly.

  - **/Path**: the name of the resource file, including its path, relative to the root of the referenced assembly's project folder.

The following example shows the pack URI for a XAML resource file that is located in the root of the referenced assembly's project folder.

`pack://application:,,,/ReferencedAssembly;component/ResourceFile.xaml`

The following example shows the pack URI for a XAML resource file that is located in a subfolder of the referenced assembly's project folder.

`pack://application:,,,/ReferencedAssembly;component/Subfolder/ResourceFile.xaml`

The following example shows the pack URI for a XAML resource file that is located in the root folder of a referenced, version-specific assembly's project folder.

`pack://application:,,,/ReferencedAssembly;v1.0.0.1;component/ResourceFile.xaml`

Note that the pack URI syntax for referenced assembly resource files can be used only with the application:/// authority. For example, the following is not supported in WPF.

`pack://siteoforigin:,,,/SomeAssembly;component/ResourceFile.xaml`

<a name="Content_File_Pack_URIs"></a>

## Content File Pack URIs

The pack URI for a content file uses the following authority and path:

- **Authority**: application:///.

- **Path**: The name of the content file, including its path relative to the file system location of the application's main executable assembly.

The following example shows the pack URI for a XAML content file, located in the same folder as the executable assembly.

`pack://application:,,,/ContentFile.xaml`

The following example shows the pack URI for a XAML content file, located in a subfolder that is relative to the application's executable assembly.

`pack://application:,,,/Subfolder/ContentFile.xaml`

> [!NOTE]
> HTML content files cannot be navigated to. The URI scheme only supports navigation to HTML files that are located at the site of origin.

<a name="The_siteoforigin_____Authority"></a>

## Site of Origin Pack URIs

The pack URI for a site of origin file uses the following authority and path:

- **Authority**: siteoforigin:///.

- **Path**: The name of the site of origin file, including its path relative to the location from which the executable assembly was launched.

The following example shows the pack URI for a XAML site of origin file, stored in the location from which the executable assembly is launched.

`pack://siteoforigin:,,,/SiteOfOriginFile.xaml`

The following example shows the pack URI for a XAML site of origin file, stored in subfolder that is relative to the location from which the application's executable assembly is launched.

`pack://siteoforigin:,,,/Subfolder/SiteOfOriginFile.xaml`

<a name="Page_Files"></a>

## Page Files

XAML files that are configured as MSBuild `Page` items are compiled into assemblies in the same way as resource files. Consequently, MSBuild `Page` items can be identified using pack URIs for resource files.

The types of XAML files that are commonly configured as MSBuild`Page` items have one of the following as their root element:

- <xref:System.Windows.Window?displayProperty=nameWithType>

- <xref:System.Windows.Controls.Page?displayProperty=nameWithType>

- <xref:System.Windows.Navigation.PageFunction%601?displayProperty=nameWithType>

- <xref:System.Windows.ResourceDictionary?displayProperty=nameWithType>

- <xref:System.Windows.Documents.FlowDocument?displayProperty=nameWithType>

- <xref:System.Windows.Controls.UserControl?displayProperty=nameWithType>

<a name="Absolute_vs_Relative_Pack_URIs"></a>

## Absolute vs. Relative Pack URIs

A fully qualified pack URI includes the scheme, the authority, and the path, and it is considered an absolute pack URI. As a simplification for developers, XAML elements typically allow you to set appropriate attributes with a relative pack URI, which includes only the path.

For example, consider the following absolute pack URI for a resource file in the local assembly.

`pack://application:,,,/ResourceFile.xaml`

The relative pack URI that refers to this resource file would be the following.

`/ResourceFile.xaml`

> [!NOTE]
> Because site of origin files are not associated with assemblies, they can only be referred to with absolute pack URIs.

By default, a relative pack URI is considered relative to the location of the markup or code that contains the reference. If a leading backslash is used, however, the relative pack URI reference is then considered relative to the root of the application. For example, consider the following project structure.

`App.xaml`

`Page2.xaml`

`\SubFolder`

`+ Page1.xaml`

`+ Page2.xaml`

If Page1.xaml contains a URI that references *Root*\SubFolder\Page2.xaml, the reference can use the following relative pack URI.

`Page2.xaml`

If Page1.xaml contains a URI that references *Root*\Page2.xaml, the reference can use the following relative pack URI.

`/Page2.xaml`

<a name="Pack_URI_Resolution"></a>

## Pack URI Resolution

The format of pack URIs makes it possible for pack URIs for different types of files to look the same. For example, consider the following absolute pack URI.

`pack://application:,,,/ResourceOrContentFile.xaml`

This absolute pack URI could refer to either a resource file in the local assembly or a content file. The same is true for the following relative URI.

`/ResourceOrContentFile.xaml`

In order to determine the type of file that a pack URI refers to, WPF resolves URIs for resource files in local assemblies and content files by using the following heuristics:

1. Probe the assembly metadata for an <xref:System.Windows.Resources.AssemblyAssociatedContentFileAttribute> attribute that matches the pack URI.

2. If the <xref:System.Windows.Resources.AssemblyAssociatedContentFileAttribute> attribute is found, the path of the pack URI refers to a content file.

3. If the <xref:System.Windows.Resources.AssemblyAssociatedContentFileAttribute> attribute is not found, probe the set resource files that are compiled into the local assembly.

4. If a resource file that matches the path of the pack URI is found, the path of the pack URI refers to a resource file.

5. If the resource is not found, the internally created <xref:System.Uri> is invalid.

URI resolution does not apply for URIs that refer to the following:

- Content files in referenced assemblies: these file types are not supported by WPF.

- Embedded files in referenced assemblies: URIs that identify them are unique because they include both the name of the referenced assembly and the `;component` suffix.

- Site of origin files: URIs that identify them are unique because they are the only files that can be identified by pack URIs that contain the siteoforigin:/// authority.

One simplification that pack URI resolution allows is for code to be somewhat independent of the locations of resource and content files. For example, if you have a resource file in the local assembly that is reconfigured to be a content file, the pack URI for the resource remains the same, as does the code that uses the pack URI.

<a name="Programming_with_Pack_URIs"></a>

## Programming with Pack URIs

Many WPF classes implement properties that can be set with pack URIs, including:

- <xref:System.Windows.Application.StartupUri%2A?displayProperty=nameWithType>

- <xref:System.Windows.Controls.Frame.Source%2A?displayProperty=nameWithType>

- <xref:System.Windows.Navigation.NavigationWindow.Source%2A?displayProperty=nameWithType>

- <xref:System.Windows.Documents.Hyperlink.NavigateUri%2A?displayProperty=nameWithType>

- <xref:System.Windows.Window.Icon%2A?displayProperty=nameWithType>

- <xref:System.Windows.Controls.Image.Source%2A?displayProperty=nameWithType>

These properties can be set from both markup and code. This section demonstrates the basic constructions for both and then shows examples of common scenarios.

<a name="Using_Pack_URIs_in_Markup"></a>

### Using Pack URIs in Markup

A pack URI is specified in markup by setting the element of an attribute with the pack URI. For example:

`<element attribute="pack://application:,,,/File.xaml" />`

Table 1 illustrates the various absolute pack URIs that you can specify in markup.

Table 1: Absolute Pack URIs in Markup

|File|Absolute pack URI|
|----------|-------------------------------------------------------------------------------------------------------------------------|
|Resource file - local assembly|`"pack://application:,,,/ResourceFile.xaml"`|
|Resource file in subfolder - local assembly|`"pack://application:,,,/Subfolder/ResourceFile.xaml"`|
|Resource file - referenced assembly|`"pack://application:,,,/ReferencedAssembly;component/ResourceFile.xaml"`|
|Resource file in subfolder of referenced assembly|`"pack://application:,,,/ReferencedAssembly;component/Subfolder/ResourceFile.xaml"`|
|Resource file in versioned referenced assembly|`"pack://application:,,,/ReferencedAssembly;v1.0.0.0;component/ResourceFile.xaml"`|
|Content file|`"pack://application:,,,/ContentFile.xaml"`|
|Content file in subfolder|`"pack://application:,,,/Subfolder/ContentFile.xaml"`|
|Site of origin file|`"pack://siteoforigin:,,,/SOOFile.xaml"`|
|Site of origin file in subfolder|`"pack://siteoforigin:,,,/Subfolder/SOOFile.xaml"`|

Table 2 illustrates the various relative pack URIs that you can specify in markup.

Table 2: Relative Pack URIs in Markup

|File|Relative pack URI|
|----------|-------------------------------------------------------------------------------------------------------------------------|
|Resource file in local assembly|`"/ResourceFile.xaml"`|
|Resource file in subfolder of local assembly|`"/Subfolder/ResourceFile.xaml"`|
|Resource file in referenced assembly|`"/ReferencedAssembly;component/ResourceFile.xaml"`|
|Resource file in subfolder of referenced assembly|`"/ReferencedAssembly;component/Subfolder/ResourceFile.xaml"`|
|Content file|`"/ContentFile.xaml"`|
|Content file in subfolder|`"/Subfolder/ContentFile.xaml"`|

<a name="Using_Pack_URIs_in_Code"></a>

### Using Pack URIs in Code

You specify a pack URI in code by instantiating the <xref:System.Uri> class and passing the pack URI as a parameter to the constructor. This is demonstrated in the following example.

```csharp
Uri uri = new Uri("pack://application:,,,/File.xaml");
```

By default, the <xref:System.Uri> class considers pack URIs to be absolute. Consequently, an exception is raised when an instance of the <xref:System.Uri> class is created with a relative pack URI.

```csharp
Uri uri = new Uri("/File.xaml");
```

Fortunately, the <xref:System.Uri.%23ctor%28System.String%2CSystem.UriKind%29> overload of the <xref:System.Uri> class constructor accepts a parameter of type <xref:System.UriKind> to allow you to specify whether a pack URI is either absolute or relative.

```csharp
// Absolute URI (default)
Uri absoluteUri = new Uri("pack://application:,,,/File.xaml", UriKind.Absolute);
// Relative URI
Uri relativeUri = new Uri("/File.xaml",
                        UriKind.Relative);
```

You should specify only <xref:System.UriKind.Absolute> or <xref:System.UriKind.Relative> when you are certain that the provided pack URI is one or the other. If you don't know the type of pack URI that is used, such as when a user enters a pack URI at run time, use <xref:System.UriKind.RelativeOrAbsolute> instead.

```csharp
// Relative or Absolute URI provided by user via a text box
TextBox userProvidedUriTextBox = new TextBox();
Uri uri = new Uri(userProvidedUriTextBox.Text, UriKind.RelativeOrAbsolute);
```

Table 3 illustrates the various relative pack URIs that you can specify in code by using <xref:System.Uri?displayProperty=nameWithType>.

Table 3: Absolute Pack URIs in Code

|File|Absolute pack URI|
|----------|-------------------------------------------------------------------------------------------------------------------------|
|Resource file - local assembly|`Uri uri = new Uri("pack://application:,,,/ResourceFile.xaml", UriKind.Absolute);`|
|Resource file in subfolder - local assembly|`Uri uri = new Uri("pack://application:,,,/Subfolder/ResourceFile.xaml", UriKind.Absolute);`|
|Resource file - referenced assembly|`Uri uri = new Uri("pack://application:,,,/ReferencedAssembly;component/ResourceFile.xaml", UriKind.Absolute);`|
|Resource file in subfolder of referenced assembly|`Uri uri = new Uri("pack://application:,,,/ReferencedAssembly;component/Subfolder/ResourceFile.xaml", UriKind.Absolute);`|
|Resource file in versioned referenced assembly|`Uri uri = new Uri("pack://application:,,,/ReferencedAssembly;v1.0.0.0;component/ResourceFile.xaml", UriKind.Absolute);`|
|Content file|`Uri uri = new Uri("pack://application:,,,/ContentFile.xaml", UriKind.Absolute);`|
|Content file in subfolder|`Uri uri = new Uri("pack://application:,,,/Subfolder/ContentFile.xaml", UriKind.Absolute);`|
|Site of origin file|`Uri uri = new Uri("pack://siteoforigin:,,,/SOOFile.xaml", UriKind.Absolute);`|
|Site of origin file in subfolder|`Uri uri = new Uri("pack://siteoforigin:,,,/Subfolder/SOOFile.xaml", UriKind.Absolute);`|

Table 4 illustrates the various relative pack URIs that you can specify in code using <xref:System.Uri?displayProperty=nameWithType>.

Table 4: Relative Pack URIs in Code

|File|Relative pack URI|
|----------|-------------------------------------------------------------------------------------------------------------------------|
|Resource file - local assembly|`Uri uri = new Uri("/ResourceFile.xaml", UriKind.Relative);`|
|Resource file in subfolder - local assembly|`Uri uri = new Uri("/Subfolder/ResourceFile.xaml", UriKind.Relative);`|
|Resource file - referenced assembly|`Uri uri = new Uri("/ReferencedAssembly;component/ResourceFile.xaml", UriKind.Relative);`|
|Resource file in subfolder - referenced assembly|`Uri uri = new Uri("/ReferencedAssembly;component/Subfolder/ResourceFile.xaml", UriKind.Relative);`|
|Content file|`Uri uri = new Uri("/ContentFile.xaml", UriKind.Relative);`|
|Content file in subfolder|`Uri uri = new Uri("/Subfolder/ContentFile.xaml", UriKind.Relative);`|

<a name="Common_Pack_URI_Scenarios"></a>

### Common Pack URI Scenarios

The preceding sections have discussed how to construct pack URIs to identify resource, content, and site of origin files. In WPF, these constructions are used in a variety of ways, and the following sections cover several common usages.

<a name="Specifying_the_UI_to_Show_when_an_Application_Starts"></a>

#### Specifying the UI to Show When an Application Starts

<xref:System.Windows.Application.StartupUri%2A> specifies the first UI to show when a WPF application is launched. For standalone applications, the UI can be a window, as shown in the following example.

[!code-xaml[PackURIOverviewSnippets#StartupUriWindow](~/samples/snippets/csharp/VS_Snippets_Wpf/PackURIOverviewSnippets/CS/Copy of App.xaml#startupuriwindow)]

Standalone applications and XAML browser applications (XBAPs) can also specify a page as the initial UI, as shown in the following example.

[!code-xaml[PackURIOverviewSnippets#StartupUriPage](~/samples/snippets/csharp/VS_Snippets_Wpf/PackURIOverviewSnippets/CS/App.xaml#startupuripage)]

If the application is a standalone application and a page is specified with <xref:System.Windows.Application.StartupUri%2A>, WPF opens a <xref:System.Windows.Navigation.NavigationWindow> to host the page. For XBAPs, the page is shown in the host browser.

<a name="Navigating_to_a_Page"></a>

#### Navigating to a Page

The following example shows how to navigate to a page.

[!code-xaml[NavigationOverviewSnippets#HyperlinkXAML1](~/samples/snippets/csharp/VS_Snippets_Wpf/NavigationOverviewSnippets/CSharp/PageWithHyperlink.xaml#hyperlinkxaml1)]
[!code-xaml[NavigationOverviewSnippets#HyperlinkXAML2](~/samples/snippets/csharp/VS_Snippets_Wpf/NavigationOverviewSnippets/CSharp/PageWithHyperlink.xaml#hyperlinkxaml2)]
[!code-xaml[NavigationOverviewSnippets#HyperlinkXAML3](~/samples/snippets/csharp/VS_Snippets_Wpf/NavigationOverviewSnippets/CSharp/PageWithHyperlink.xaml#hyperlinkxaml3)]

For more information on the various ways to navigate in WPF, see [Navigation Overview](navigation-overview.md).

<a name="Specifying_a_Window_Icon"></a>

#### Specifying a Window Icon

The following example shows how to use a URI to specify a window's icon.

[!code-xaml[WindowIconSnippets#WindowIconSetXAML](~/samples/snippets/xaml/VS_Snippets_Wpf/WindowIconSnippets/XAML/MainWindow.xaml#windowiconsetxaml)]

For more information, see <xref:System.Windows.Window.Icon%2A>.

<a name="Loading_Image__Audio__and_Video_Files"></a>

#### Loading Image, Audio, and Video Files

WPF allows applications to use a wide variety of media types, all of which can be identified and loaded with pack URIs, as shown in the following examples.

[!code-xaml[MediaPlayerVideoSample#VideoPackURIAtSOO](~/samples/snippets/csharp/VS_Snippets_Wpf/MediaPlayerVideoSample/CS/HomePage.xaml#videopackuriatsoo)]

[!code-xaml[MediaPlayerAudioSample#AudioPackURIAtSOO](~/samples/snippets/csharp/VS_Snippets_Wpf/MediaPlayerAudioSample/CS/HomePage.xaml#audiopackuriatsoo)]

[!code-xaml[ImageSample#ImagePackURIContent](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageSample/CS/HomePage.xaml#imagepackuricontent)]

For more information on working with media content, see [Graphics and Multimedia](../graphics-multimedia/index.md).

<a name="Loading_a_Resource_Dictionary_from_the_Site_of_Origin"></a>

#### Loading a Resource Dictionary from the Site of Origin

Resource dictionaries (<xref:System.Windows.ResourceDictionary>) can be used to support application themes. One way to create and manage themes is to create multiple themes as resource dictionaries that are located at an application's site of origin. This allows themes to be added and updated without recompiling and redeploying an application. These resource dictionaries can be identified and loaded using pack URIs, which is shown in the following example.

[!code-xaml[ResourceDictionarySnippets#ResourceDictionaryPackURI](~/samples/snippets/csharp/VS_Snippets_Wpf/ResourceDictionarySnippets/CS/App.xaml#resourcedictionarypackuri)]

For an overview of themes in WPF, see [Styling and Templating](../controls/styles-templates-overview.md).

## See also

- [WPF Application Resource, Content, and Data Files](wpf-application-resource-content-and-data-files.md)
