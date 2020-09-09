---
title: "Security"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XAML files [WPF], sandbox behavior"
  - "browser-hosted application security [WPF]"
  - "application security [WPF]"
  - "navigation security [WPF]"
  - "loose XAML files [WPF], sandbox behavior"
  - "WPF security [WPF]"
  - "WebBrowser control [WPF], security"
  - "feature controls [WPF], security"
  - "XBAP security [WPF]"
  - "Internet Explorer security settings [WPF]"
ms.assetid: ee1baea0-3611-4e36-9ad6-fcd5205376fb
---
# Security (WPF)
<a name="introduction"></a> When developing Windows Presentation Foundation (WPF) standalone and browser-hosted applications, you must consider the security model. WPF standalone applications execute with unrestricted permissions ( CAS**FullTrust** permission set), whether deployed using Windows Installer (.msi), XCopy, or ClickOnce. Deploying partial-trust, standalone WPF applications with ClickOnce is unsupported. However, a full-trust host application can create a partial-trust <xref:System.AppDomain> using the .NET Framework Add-in model. For more information, see [WPF Add-Ins Overview](./app-development/wpf-add-ins-overview.md).  
  
 WPF browser-hosted applications are hosted by Windows Internet Explorer or Firefox, and can be either XAML browser applications (XBAPs) or loose [!INCLUDE[TLA#tla_xaml](../../includes/tlasharptla-xaml-md.md)] documents For more information, see [WPF XAML Browser Applications Overview](./app-development/wpf-xaml-browser-applications-overview.md).  
  
 WPF browser-hosted applications execute within a partial trust security sandbox, by default, which is limited to the default CAS**Internet** zone permission set. This effectively isolates WPF browser-hosted applications from the client computer in the same way that you would expect typical Web applications to be isolated. An XBAP can elevate privileges, up to Full Trust, depending on the security zone of the deployment URL and the client's security configuration. For more information, see [WPF Partial Trust Security](wpf-partial-trust-security.md).  
  
 This topic discusses the security model for Windows Presentation Foundation (WPF) standalone and browser-hosted applications.  
  
 This topic contains the following sections:  
  
- [Safe Navigation](#SafeTopLevelNavigation)  
  
- [Web Browsing Software Security Settings](#InternetExplorerSecuritySettings)  
  
- [WebBrowser Control and Feature Controls](#webbrowser_control_and_feature_controls)  
  
- [Disabling APTCA Assemblies for Partially Trusted Client Applications](#APTCA)  
  
- [Sandbox Behavior for Loose XAML Files](#LooseContentSandboxing)  
  
- [Resources for Developing WPF Applications that Promote Security](#BestPractices)  
  
<a name="SafeTopLevelNavigation"></a>
## Safe Navigation  
 For XBAPs, WPF distinguishes two types of navigation: application and browser.  
  
 *Application navigation* is navigation between items of content within an application that is hosted by a browser. *Browser navigation* is navigation that changes the content and location URL of a browser itself. The relationship between application navigation (typically XAML) and browser navigation (typically HTML) is shown in the following illustration:
  
 ![Relationship between application navigation and browser navigation.](./media/security-wpf/application-browser-navigation-relationship.png)  
  
 The type of content that is considered safe for an XBAP to navigate to is primarily determined by whether application navigation or browser navigation is used.  
  
<a name="Application_Navigation_Security"></a>
### Application Navigation Security  
 Application navigation is considered safe if it can be identified with a pack URI, which supports four types of content:  
  
|Content Type|Description|URI Example|  
|------------------|-----------------|-----------------|  
|Resource|Files that are added to a project with a build type of **Resource**.|`pack://application:,,,/MyResourceFile.xaml`|  
|Content|Files that are added to a project with a build type of **Content**.|`pack://application:,,,/MyContentFile.xaml`|  
|Site of origin|Files that are added to a project with a build type of **None**.|`pack://siteoforigin:,,,/MySiteOfOriginFile.xaml`|  
|Application code|XAML resources that have a compiled code-behind.<br /><br /> -or-<br /><br /> XAML files that are added to a project with a build type of **Page**.|`pack://application:,,,/MyResourceFile` `.xaml`|  
  
> [!NOTE]
> For more information about application data files and pack URIs, see [WPF Application Resource, Content, and Data Files](./app-development/wpf-application-resource-content-and-data-files.md).  
  
 Files of these content types can be navigated to by either the user or programmatically:  
  
- **User Navigation**. The user navigates by clicking a <xref:System.Windows.Documents.Hyperlink> element.  
  
- **Programmatic Navigation**. The application navigates without involving the user, for example, by setting the <xref:System.Windows.Navigation.NavigationWindow.Source%2A?displayProperty=nameWithType> property.  
  
<a name="Browser_Navigation_Security"></a>
### Browser Navigation Security  
 Browser navigation is considered safe only under the following conditions:  
  
- **User Navigation**. The user navigates by clicking a <xref:System.Windows.Documents.Hyperlink> element that is within the main <xref:System.Windows.Navigation.NavigationWindow>, not in a nested <xref:System.Windows.Controls.Frame>.  
  
- **Zone**. The content being navigated to is located on the Internet or the local intranet.  
  
- **Protocol**. The protocol being used is either **http**, **https**, **file**, or **mailto**.  
  
 If an XBAP attempts to navigate to content in a manner that does not comply with these conditions, a <xref:System.Security.SecurityException> is thrown.  
  
<a name="InternetExplorerSecuritySettings"></a>
## Web Browsing Software Security Settings  
 The security settings on your computer determine the access that any Web browsing software is granted. Web browsing software includes any application or component that uses the [WinINet](/windows/win32/wininet/portal) or [UrlMon](https://docs.microsoft.com/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767916(v=vs.85)) APIs, including Internet Explorer and PresentationHost.exe.  
  
 Internet Explorer provides a mechanism by which you can configure the functionality that is allowed to be executed by or from Internet Explorer, including the following:  
  
- .NET Framework-reliant components  
  
- ActiveX controls and plug-ins  
  
- Downloads  
  
- Scripting  
  
- User Authentication  
  
 The collection of functionality that can be secured in this way is configured on a per-zone basis for the **Internet**, **Intranet**, **Trusted Sites**, and **Restricted Sites** zones. The following steps describe how to configure your security settings:  
  
1. Open **Control Panel**.  
  
2. Click **Network and Internet** and then click **Internet Options**.  
  
     The Internet Options dialog box appears.  
  
3. On the **Security** tab, select the zone to configure the security settings for.  
  
4. Click the **Custom Level** button.  
  
     The **Security Settings** dialog box appears and you can configure the security settings for the selected zone.  
  
     ![Screenshot that shows the Security Settings dialog box.](./media/security-wpf/windows-presentation-foundation-security-settings.png)  
  
> [!NOTE]
> You can also get to the Internet Options dialog box from Internet Explorer. Click **Tools** and then click **Internet Options**.  
  
 Starting with Windows Internet Explorer 7, the following security settings specifically for .NET Framework are included:  
  
- **Loose XAML**. Controls whether Internet Explorer can navigate to and loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] files. (Enable, Disable, and Prompt options).  
  
- **XAML browser applications**. Controls whether Internet Explorer can navigate to and run XBAPs. (Enable, Disable, and Prompt options).  
  
 By default, these settings are all enabled for the **Internet**, **Local intranet**, and **Trusted sites** zones, and disabled for the **Restricted sites** zone.  
  
<a name="Security_Settings_for_IE6_and_Below"></a>
### Security-related WPF Registry Settings  
 In addition to the security settings available through the Internet Options, the following registry values are available for selectively blocking a number of security-sensitive WPF features. The values are defined under the following key:  
  
 `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\Windows Presentation Foundation\Features`  
  
 The following table lists the values that can be set.  
  
|Value Name|Value Type|Value Data|  
|----------------|----------------|----------------|  
|XBAPDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
|LooseXamlDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
|WebBrowserDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
|MediaAudioDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
|MediaImageDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
|MediaVideoDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
|ScriptInteropDisallow|REG_DWORD|1 to disallow; 0 to allow.|  
  
<a name="webbrowser_control_and_feature_controls"></a>
## WebBrowser Control and Feature Controls  
 The WPF <xref:System.Windows.Controls.WebBrowser> control can be used to host Web content. The WPF <xref:System.Windows.Controls.WebBrowser> control wraps the underlying WebBrowser ActiveX control. WPF provides some support for securing your application when you use the WPF <xref:System.Windows.Controls.WebBrowser> control to host untrusted Web content. However, some security features must be applied directly by the applications using the <xref:System.Windows.Controls.WebBrowser> control. For more information about the WebBrowser ActiveX control, see [WebBrowser Control Overviews and Tutorials](https://docs.microsoft.com/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa752041(v=vs.85)).  
  
> [!NOTE]
> This section also applies to the <xref:System.Windows.Controls.Frame> control since it uses the <xref:System.Windows.Controls.WebBrowser> to navigate to HTML content.  
  
 If the WPF <xref:System.Windows.Controls.WebBrowser> control is used to host untrusted Web content, your application should use a partial-trust <xref:System.AppDomain> to help insulate your application code from potentially malicious HTML script code. This is especially true if your application is interacting with the hosted script by using the <xref:System.Windows.Controls.WebBrowser.InvokeScript%2A> method and the <xref:System.Windows.Controls.WebBrowser.ObjectForScripting%2A> property. For more information, see [WPF Add-Ins Overview](./app-development/wpf-add-ins-overview.md).  
  
 If your application uses the WPF <xref:System.Windows.Controls.WebBrowser> control, another way to increase security and mitigate attacks is to enable Internet Explorer feature controls. Feature controls are additions to Internet Explorer that allow administrators and developers to configure features of Internet Explorer and applications that host the WebBrowser ActiveX control, which the WPF <xref:System.Windows.Controls.WebBrowser> control wraps. Feature controls can be configured by using the [CoInternetSetFeatureEnabled](https://docs.microsoft.com/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms537168(v=vs.85)) function or by changing values in the registry. For more information about feature controls, see [Introduction to Feature Controls](https://docs.microsoft.com/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms537184(v=vs.85)) and [Internet Feature Controls](https://docs.microsoft.com/previous-versions/windows/internet-explorer/ie-developer/general-info/ee330720(v=vs.85)).  
  
 If you are developing a standalone WPF application that uses the WPF <xref:System.Windows.Controls.WebBrowser> control, WPF automatically enables the following feature controls for your application.  
  
|Feature Control|  
|---------------------|  
|FEATURE_MIME_HANDLING|  
|FEATURE_MIME_SNIFFING|  
|FEATURE_OBJECT_CACHING|  
|FEATURE_SAFE_BINDTOOBJECT|  
|FEATURE_WINDOW_RESTRICTIONS|  
|FEATURE_ZONE_ELEVATION|  
|FEATURE_RESTRICT_FILEDOWNLOAD|  
|FEATURE_RESTRICT_ACTIVEXINSTALL|  
|FEATURE_ADDON_MANAGEMENT|  
|FEATURE_HTTP_USERNAME_PASSWORD_DISABLE|  
|FEATURE_SECURITYBAND|  
|FEATURE_UNC_SAVEDFILECHECK|  
|FEATURE_VALIDATE_NAVIGATE_URL|  
|FEATURE_DISABLE_TELNET_PROTOCOL|  
|FEATURE_WEBOC_POPUPMANAGEMENT|  
|FEATURE_DISABLE_LEGACY_COMPRESSION|  
|FEATURE_SSLUX|  
  
 Since these feature controls are enabled unconditionally, a full-trust application might be impaired by them. In this case, if there is no security risk for the specific application and the content it is hosting, the corresponding feature control can be disabled.  
  
 Feature controls are applied by the process instantiating the WebBrowser ActiveX object. Therefore, if you are creating a stand-alone application that can navigate to untrusted content, you should seriously consider enabling additional feature controls.  
  
> [!NOTE]
> This recommendation is based on general recommendations for MSHTML and SHDOCVW host security. For more information, see [The MSHTML Host Security FAQ: Part I of II](https://msrc-blog.microsoft.com/2009/04/02/the-mshtml-host-security-faq-part-i-of-ii/) and [The MSHTML Host Security FAQ: Part II of II](https://msrc-blog.microsoft.com/2009/04/03/the-mshtml-host-security-faq-part-ii-of-ii/).  
  
 For your executable, consider enabling the following feature controls by setting the registry value to 1.  
  
|Feature Control|  
|---------------------|  
|FEATURE_ACTIVEX_REPURPOSEDETECTION|  
|FEATURE_BLOCK_LMZ_IMG|  
|FEATURE_BLOCK_LMZ_OBJECT|  
|FEATURE_BLOCK_LMZ_SCRIPT|  
|FEATURE_RESTRICT_RES_TO_LMZ|  
|FEATURE_RESTRICT_ABOUT_PROTOCOL_IE7|  
|FEATURE_SHOW_APP_PROTOCOL_WARN_DIALOG|  
|FEATURE_LOCALMACHINE_LOCKDOWN|  
|FEATURE_FORCE_ADDR_AND_STATUS|  
|FEATURE_RESTRICTED_ZONE_WHEN_FILE_NOT_FOUND|  
  
 For your executable, consider disabling the following feature control by setting the registry value to 0.  
  
|Feature Control|  
|---------------------|  
|FEATURE_ENABLE_SCRIPT_PASTE_URLACTION_IF_PROMPT|  
  
 If you run a partial-trust XAML browser application (XBAP) that includes a WPF <xref:System.Windows.Controls.WebBrowser> control in Windows Internet Explorer, WPF hosts the WebBrowser ActiveX control in the address space of the Internet Explorer process. Since the WebBrowser ActiveX control is hosted in the Internet Explorer process, all of the feature controls for Internet Explorer are also enabled for the WebBrowser ActiveX control.  
  
 XBAPs running in Internet Explorer also get an additional level of security compared to normal standalone applications. This additional security is because Internet Explorer, and therefore the WebBrowser ActiveX control, runs in protected mode by default on Windows Vista and Windows 7. For more information about protected mode, see [Understanding and Working in Protected Mode Internet Explorer](https://docs.microsoft.com/previous-versions/windows/internet-explorer/ie-developer/).  
  
> [!NOTE]
> If you try to run an XBAP that includes a WPF <xref:System.Windows.Controls.WebBrowser> control in Firefox, while in the Internet zone, a <xref:System.Security.SecurityException> will be thrown. This is due to WPF security policy.  
  
<a name="APTCA"></a>
## Disabling APTCA Assemblies for Partially Trusted Client Applications  
 When managed assemblies are installed into the global assembly cache (GAC), they become fully trusted because the user must provide explicit permission to install them. Because they are fully trusted, only fully trusted managed client applications can use them. To allow partially trusted applications to use them, they must be marked with the <xref:System.Security.AllowPartiallyTrustedCallersAttribute> (APTCA). Only assemblies that have been tested to be safe for execution in partial trust should be marked with this attribute.  
  
 However, it is possible for an APTCA assembly to exhibit a security flaw after being installed into the  GAC . Once a security flaw is discovered, assembly publishers can produce a security update to fix the problem on existing installations, and to protect against installations that may occur after the problem is discovered. One option for the update is to uninstall the assembly, although that may break other fully trusted client applications that use the assembly.  
  
 WPF provides a mechanism by which an APTCA assembly can be disabled for partially trusted XBAPs without uninstalling the APTCA assembly.  
  
 To disable an APTCA assembly, you have to create a special registry key:  
  
 `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\policy\APTCA\<AssemblyFullName>, FileVersion=<AssemblyFileVersion>`  
  
 The following shows an example:  
  
 `HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\policy\APTCA\aptcagac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=215e3ac809a0fea7, FileVersion=1.0.0.0`  
  
 This key establishes an entry for the APTCA assembly. You also have to create a value in this key that enables or disables the assembly. The following are the details of the value:  
  
- Value Name: **APTCA_FLAG**.  
  
- Value Type: **REG_DWORD**.  
  
- Value Data: **1** to disable; **0** to enable.  
  
 If an assembly has to be disabled for partially trusted client applications, you can write an update that creates the registry key and value.  
  
> [!NOTE]
> Core .NET Framework assemblies are not affected by disabling them in this way because they are required for managed applications to run. Support for disabling APTCA assemblies is primarily targeted to third-party applications.  
  
<a name="LooseContentSandboxing"></a>
## Sandbox Behavior for Loose XAML Files  
 Loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] files are markup-only XAML files that do not depend on any code-behind, event handler, or application-specific assembly. When loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] files are navigated to directly from the browser, they are loaded in a security sandbox based on the default Internet zone permission set.  
  
 However, the security behavior is different when loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] files are navigated to from either a <xref:System.Windows.Navigation.NavigationWindow> or <xref:System.Windows.Controls.Frame> in a standalone application.  
  
 In both cases, the loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] file that is navigated to inherits the permissions of its host application. However, this behavior may be undesirable from a security perspective, particularly if a loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] file was produced by an entity that is either not trusted or unknown. This type of content is known as *external content*, and both <xref:System.Windows.Controls.Frame> and <xref:System.Windows.Navigation.NavigationWindow> can be configured to isolate it when navigated to. Isolation is achieved by setting the **SandboxExternalContent** property to true, as shown in the following examples for <xref:System.Windows.Controls.Frame> and <xref:System.Windows.Navigation.NavigationWindow>:  
  
 [!code-xaml[SecurityOverviewSnippets#FrameMARKUP](~/samples/snippets/csharp/VS_Snippets_Wpf/SecurityOverviewSnippets/CS/Window2.xaml#framemarkup)]  
  
 [!code-xaml[SecurityOverviewSnippets#NavigationWindowMARKUP](~/samples/snippets/csharp/VS_Snippets_Wpf/SecurityOverviewSnippets/CS/Window1.xaml#navigationwindowmarkup)]  
  
 With this setting, external content will be loaded into a process that is separate from the process that is hosting the application. This process is restricted to the default Internet zone permission set, effectively isolating it from the hosting application and the client computer.  
  
> [!NOTE]
> Even though navigation to loose [!INCLUDE[TLA2#tla_xaml](../../includes/tla2sharptla-xaml-md.md)] files from either a <xref:System.Windows.Navigation.NavigationWindow> or <xref:System.Windows.Controls.Frame> in a standalone application is implemented based on the WPF browser hosting infrastructure, involving the PresentationHost process, the security level is slightly less than when the content is loaded directly in Internet Explorer on Windows Vista and Windows 7 (which would still be through PresentationHost). This is because a standalone WPF application using a Web browser does not provide the additional Protected Mode security feature of Internet Explorer.  
  
<a name="BestPractices"></a>
## Resources for Developing WPF Applications that Promote Security  
 The following are some additional resources to help develop WPF applications that promote security:  
  
|Area|Resource|  
|----------|--------------|  
|Managed code|[Patterns and Practices Security Guidance for Applications](https://docs.microsoft.com/previous-versions/msp-n-p/ff650760(v=pandp.10))|  
|CAS|[Code Access Security](/dotnet/framework/misc/code-access-security)|  
|ClickOnce|[ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment)|  
|WPF|[WPF Partial Trust Security](wpf-partial-trust-security.md)|  
  
## See also

- [WPF Partial Trust Security](wpf-partial-trust-security.md)
- [WPF Security Strategy - Platform Security](wpf-security-strategy-platform-security.md)
- [WPF Security Strategy - Security Engineering](wpf-security-strategy-security-engineering.md)
- [Patterns and Practices Security Guidance for Applications](https://docs.microsoft.com/previous-versions/msp-n-p/ff650760(v=pandp.10))
- [Code Access Security](/dotnet/framework/misc/code-access-security)
- [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment)
- [XAML Overview (WPF)](/dotnet/desktop-wpf/fundamentals/xaml)
