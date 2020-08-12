---
title: Unmanaged apps
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ActiveX controls [Windows Forms]"
  - "COM interop [Windows Forms], Windows Forms"
  - "COM [Windows Forms]"
  - "Windows Forms, unmanaged"
  - "Windows Forms, interop"
ms.assetid: 81bc100c-fa49-4614-85a6-0f7ab59eac8a
---
# Windows Forms and Unmanaged Applications
Windows Forms applications and controls can interoperate with unmanaged applications, with some caveats. The following sections describe the scenarios and configurations that Windows Forms applications and controls support and those that they do not support.  
  
## In This Section  
 [Windows Forms and Unmanaged Applications Overview](windows-forms-and-unmanaged-applications-overview.md)  
 Offers general information about how to use and implement Windows Forms controls that work with unmanaged applications.  
  
 [How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method](com-interop-by-displaying-a-windows-form-shadow.md)  
 Provides a code example that shows how to use the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method to run a Windows Form in an unmanaged application.  
  
 [How to: Support COM Interop by Displaying Each Windows Form on Its Own Thread](how-to-support-com-interop-by-displaying-each-windows-form-on-its-own-thread.md)  
 Provides a code example that shows how to run a Windows Form on its own thread.  
  
 Also see [Walkthrough: Supporting COM Interop by Displaying Each Windows Form on Its Own Thread](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ms233639(v=vs.100)).  
  
## Reference  
 <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType>  
 Used to create a separate thread for a Windows Form.  
  
 <xref:System.Windows.Forms.Application.Run%2A?displayProperty=nameWithType>  
 Starts a message loop for a thread.  
  
 <xref:System.Windows.Forms.Control.Invoke%2A>  
 Marshals calls from an unmanaged application to a form.  
  
## Related Sections  
 [Exposing .NET Framework Components to COM](../../interop/exposing-dotnet-components-to-com.md)  
 Offers general information about how to use .NET Framework types in unmanaged applications.
