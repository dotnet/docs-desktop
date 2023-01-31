---
title: "Partial Trust Security"
description: Learn how WPF relies on both Code Access Security (CAS) and ClickOnce to enforce restrictions regarding critical system resources.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "partial trust security [WPF]"
  - "detecting permissions [WPF]"
  - "security settings for Internet Explorer [WPF]"
  - "partial trust applications [WPF], debugging"
  - "permissions [WPF], managing"
  - "debugging partial trust applications [WPF]"
  - "permissions [WPF], detecting"
  - "feature security requirements [WPF]"
  - "managing permissions [WPF]"
ms.assetid: ef2c0810-1dbf-4511-babd-1fab95b523b5
---
# WPF Partial Trust Security

<a name="introduction"></a> In general, Internet applications should be restricted from having direct access to critical system resources, to prevent malicious damage. By default, HTML and client-side scripting languages are not able to access critical system resources. Because Windows Presentation Foundation (WPF) browser-hosted applications can be launched from the browser, they should conform to a similar set of restrictions. To enforce these restrictions, WPF relies on both Code Access Security (CAS) and ClickOnce (see [WPF Security Strategy - Platform Security](wpf-security-strategy-platform-security.md)). By default, browser-hosted applications request the Internet zone CAS set of permissions, irrespective of whether they are launched from the Internet, the local intranet, or the local computer. Applications that run with anything less than the full set of permissions are said to be running with partial trust.  
  
 WPF provides a wide variety of support to ensure that as much functionality as possible can be used safely in partial trust, and along with CAS, provides additional support for partial trust programming.  
  
 This topic contains the following sections:  
  
- [WPF Feature Partial Trust Support](#WPF_Feature_Partial_Trust_Support)  
  
- [Partial Trust Programming](#Partial_Trust_Programming)  
  
- [Managing Permissions](#Managing_Permissions)  
  
<a name="WPF_Feature_Partial_Trust_Support"></a>

## WPF Feature Partial Trust Support  

 The following table lists the high-level features of Windows Presentation Foundation (WPF) that are safe to use within the limits of the Internet zone permission set.  
  
 Table 1: WPF Features that are Safe in Partial Trust  
  
|Feature Area|Feature|  
|------------------|-------------|  
|General|Browser Window<br /><br /> Site of Origin Access<br /><br /> IsolatedStorage (512KB Limit)<br /><br /> UIAutomation Providers<br /><br /> Commanding<br /><br /> Input Method Editors (IMEs)<br /><br /> Tablet Stylus and Ink<br /><br /> Simulated Drag/Drop using Mouse Capture and Move Events<br /><br /> OpenFileDialog<br /><br /> XAML Deserialization (via XamlReader.Load)|  
|Web Integration|Browser Download Dialog<br /><br /> Top-Level User-Initiated Navigation<br /><br /> mailto:links<br /><br /> Uniform Resource Identifier Parameters<br /><br /> HTTPWebRequest<br /><br /> WPF Content Hosted in an IFRAME<br /><br /> Hosting of Same-Site HTML Pages using Frame<br /><br /> Hosting of Same Site HTML Pages using WebBrowser<br /><br /> Web Services (ASMX)<br /><br /> Web Services (using Windows Communication Foundation)<br /><br /> Scripting<br /><br /> Document Object Model|  
|Visuals|2D and 3D<br /><br /> Animation<br /><br /> Media (Site Of Origin and Cross-Domain)<br /><br /> Imaging/Audio/Video|  
|Reading|FlowDocuments<br /><br /> XPS Documents<br /><br /> Embedded & System Fonts<br /><br /> CFF & TrueType Fonts|  
|Editing|Spell Checking<br /><br /> RichTextBox<br /><br /> Plaintext and Ink Clipboard Support<br /><br /> User-Initiated Paste<br /><br /> Copying Selected Content|  
|Controls|General Controls|  
  
 This table covers the WPF features at a high level. For more detailed information, the Windows SDK documents the permissions that are required by each member in WPF. Additionally, the following features have more detailed information regarding partial trust execution, including special considerations.  
  
- XAML (see [XAML in WPF](advanced/xaml-in-wpf.md)).  
  
- Popups (see <xref:System.Windows.Controls.Primitives.Popup?displayProperty=nameWithType>).  
  
- Drag and Drop (see [Drag and Drop Overview](./advanced/drag-and-drop-overview.md)).  
  
- Clipboard (see <xref:System.Windows.Clipboard?displayProperty=nameWithType>).  
  
- Imaging (see <xref:System.Windows.Controls.Image?displayProperty=nameWithType>).  
  
- Serialization (see <xref:System.Windows.Markup.XamlReader.Load%2A?displayProperty=nameWithType>, <xref:System.Windows.Markup.XamlWriter.Save%2A?displayProperty=nameWithType>).  
  
- Open File Dialog Box (see <xref:Microsoft.Win32.OpenFileDialog?displayProperty=nameWithType>).  
  
 The following table outlines the WPF features that are not safe to run within the limits of the Internet zone permission set.  
  
 Table 2: WPF Features that are Not Safe in Partial Trust  
  
|Feature Area|Feature|  
|------------------|-------------|  
|General|Window (Application Defined Windows and Dialog Boxes)<br /><br /> SaveFileDialog<br /><br /> File System<br /><br /> Registry Access<br /><br /> Drag and Drop<br /><br /> XAML Serialization (via XamlWriter.Save)<br /><br /> UIAutomation Clients<br /><br /> Source Window Access (HwndHost)<br /><br /> Full Speech Support<br /><br /> Windows Forms Interoperability|  
|Visuals|Bitmap Effects<br /><br /> Image Encoding|  
|Editing|Rich Text Format Clipboard<br /><br /> Full XAML support|  
  
<a name="Partial_Trust_Programming"></a>

## Partial Trust Programming  

 For XBAP applications, code that exceeds the default permission set will have different behavior depending on the security zone. In some cases, the user will receive a warning when they attempt to install it. The user can choose to continue or cancel the installation. The following table describes the behavior of the application for each security zone and what you have to do for the application to receive full trust.  
  
|Security Zone|Behavior|Getting Full Trust|  
|-------------------|--------------|------------------------|  
|Local computer|Automatic full trust|No action is needed.|  
|Intranet and trusted sites|Prompt for full trust|Sign the XBAP with a certificate so that the user sees the source in the prompt.|  
|Internet|Fails with "Trust Not Granted"|Sign the XBAP with a certificate.|  
  
> [!NOTE]
> The behavior described in the previous table is for full trust XBAPs that do not follow the ClickOnce Trusted Deployment model.  
  
 In general, code that may exceed the allowed permissions is likely to be common code that is shared between both standalone and browser-hosted applications. CAS and WPF offer several techniques for managing this scenario.  
  
<a name="Detecting_Permissions_using_CAS"></a>

### Detecting Permissions Using CAS  

 In some situations, it is possible for shared code in library assemblies to be used by both standalone applications and XBAPs. In these cases, code may execute functionality that could require more permissions than the application's awarded permission set allows. Your application can detect whether or not it has a certain permission by using Microsoft .NET Framework security. Specifically, it can test whether it has a specific permission by calling the <xref:System.Security.CodeAccessPermission.Demand%2A> method on the instance of the desired permission. This is shown in the following example, which has code that queries for whether it has the ability to save a file to the local disk:  
  
 [!code-csharp[PartialTrustSecurityOverviewSnippets#DetectPermsCODE1](~/samples/snippets/csharp/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/CSharp/FileHandling.cs#detectpermscode1)]
 [!code-vb[PartialTrustSecurityOverviewSnippets#DetectPermsCODE1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/VisualBasic/FileHandling.vb#detectpermscode1)]  
[!code-csharp[PartialTrustSecurityOverviewSnippets#DetectPermsCODE2](~/samples/snippets/csharp/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/CSharp/FileHandling.cs#detectpermscode2)]
[!code-vb[PartialTrustSecurityOverviewSnippets#DetectPermsCODE2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/VisualBasic/FileHandling.vb#detectpermscode2)]  
  
 If an application does not have the desired permission, the call to <xref:System.Security.CodeAccessPermission.Demand%2A> will throw a security exception. Otherwise, the permission has been granted. `IsPermissionGranted` encapsulates this behavior and returns `true` or `false` as appropriate.  
  
<a name="Graceful_Degradation_of_Functionality"></a>

### Graceful Degradation of Functionality  

 Being able to detect whether code has the permission to do what it needs to do is interesting for code that can be executed from different zones. While detecting the zone is one thing, it is far better to provide an alternative for the user, if possible. For example, a full trust application typically enables users to create files anywhere they want, while a partial trust application can only create files in isolated storage. If the code to create a file exists in an assembly that is shared by both full trust (standalone) applications and partial trust (browser-hosted) applications, and both applications want users to be able to create files, the shared code should detect whether it is running in partial or full trust before creating a file in the appropriate location. The following code demonstrates both.  
  
 [!code-csharp[PartialTrustSecurityOverviewSnippets#DetectPermsGracefulCODE1](~/samples/snippets/csharp/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/CSharp/FileHandlingGraceful.cs#detectpermsgracefulcode1)]
 [!code-vb[PartialTrustSecurityOverviewSnippets#DetectPermsGracefulCODE1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/VisualBasic/FileHandlingGraceful.vb#detectpermsgracefulcode1)]  
[!code-csharp[PartialTrustSecurityOverviewSnippets#DetectPermsGracefulCODE2](~/samples/snippets/csharp/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/CSharp/FileHandlingGraceful.cs#detectpermsgracefulcode2)]
[!code-vb[PartialTrustSecurityOverviewSnippets#DetectPermsGracefulCODE2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PartialTrustSecurityOverviewSnippets/VisualBasic/FileHandlingGraceful.vb#detectpermsgracefulcode2)]  
  
 In many cases, you should be able to find a partial trust alternative.  
  
 In a controlled environment, such as an intranet, custom managed frameworks can be installed across the client base into the global assembly cache (GAC). These libraries can execute code that requires full trust, and be referenced from applications that are only allowed partial trust by using <xref:System.Security.AllowPartiallyTrustedCallersAttribute> (for more information, see [Security](security-wpf.md) and [WPF Security Strategy - Platform Security](wpf-security-strategy-platform-security.md)).  
  
<a name="Browser_Host_Detection"></a>

### Browser Host Detection  

 Using CAS to check for permissions is a suitable technique when you need to check on a per-permission basis. Although, this technique depends on catching exceptions as a part of normal processing, which is not recommended in general and can have performance issues. Instead, if your XAML browser application (XBAP) only runs within the Internet zone sandbox, you can use the <xref:System.Windows.Interop.BrowserInteropHelper.IsBrowserHosted%2A?displayProperty=nameWithType> property, which returns true for XAML browser applications (XBAPs).  
  
> [!NOTE]
> <xref:System.Windows.Interop.BrowserInteropHelper.IsBrowserHosted%2A> only distinguishes whether an application is running in a browser, not which set of permissions an application is running with.  
  
<a name="Managing_Permissions"></a>

## Managing Permissions  

 By default, XBAPs run with partial trust (default Internet zone permission set). However, depending on the requirements of the application, it is possible to change the set of permissions from the default. For example, if an XBAPs is launched from a local intranet, it can take advantage of an increased permission set, which is shown in the following table.  
  
 Table 3: LocalIntranet and Internet Permissions  
  
|Permission|Attribute|LocalIntranet|Internet|  
|----------------|---------------|-------------------|--------------|  
|DNS|Access DNS servers|Yes|No|  
|Environment Variables|Read|Yes|No|  
|File Dialogs|Open|Yes|Yes|  
|File Dialogs|Unrestricted|Yes|No|  
|Isolated Storage|Assembly isolation by user|Yes|No|  
|Isolated Storage|Unknown isolation|Yes|Yes|  
|Isolated Storage|Unlimited user quota|Yes|No|  
|Media|Safe audio, video, and images|Yes|Yes|  
|Printing|Default printing|Yes|No|  
|Printing|Safe printing|Yes|Yes|  
|Reflection|Emit|Yes|No|  
|Security|Managed code execution|Yes|Yes|  
|Security|Assert granted permissions|Yes|No|  
|User Interface|Unrestricted|Yes|No|  
|User Interface|Safe top level windows|Yes|Yes|  
|User Interface|Own Clipboard|Yes|Yes|  
|Web Browser|Safe frame navigation to HTML|Yes|Yes|  
  
> [!NOTE]
> Cut and Paste is only allowed in partial trust when user initiated.  
  
 If you need to increase permissions, you need to change the project settings and the ClickOnce application manifest. For more information, see [WPF XAML Browser Applications Overview](./app-development/wpf-xaml-browser-applications-overview.md). The following documents may also be helpful.  
  
- [Mage.exe (Manifest Generation and Editing Tool)](/dotnet/framework/tools/mage-exe-manifest-generation-and-editing-tool).  
  
- [MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)](/dotnet/framework/tools/mageui-exe-manifest-generation-and-editing-tool-graphical-client).  
  
- [Securing ClickOnce Applications](/visualstudio/deployment/securing-clickonce-applications).  
  
 If your XBAP requires full trust, you can use the same tools to increase the requested permissions. Although an XBAP will only receive full trust if it is installed on and launched from the local computer, the intranet, or from a URL that is listed in the browser's trusted or allowed sites. If the application is installed from the intranet or a trusted site, the user will receive the standard ClickOnce prompt notifying them of the elevated permissions. The user can choose to continue or cancel the installation.  
  
 Alternatively, you can use the ClickOnce Trusted Deployment model for full trust deployment from any security zone. For more information, see [Trusted Application Deployment Overview](/visualstudio/deployment/trusted-application-deployment-overview) and [Security](security-wpf.md).  
  
## See also

- [Security](security-wpf.md)
- [WPF Security Strategy - Platform Security](wpf-security-strategy-platform-security.md)
- [WPF Security Strategy - Security Engineering](wpf-security-strategy-security-engineering.md)
