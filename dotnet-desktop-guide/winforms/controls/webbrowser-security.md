---
title: "WebBrowser Security"
description: Learn about WebBrowser Security, which is designed to work in full trust only. HTML in the control can come from external Web servers.
ms.date: "03/30/2017"
ms.service: dotnet-framework
helpviewer_keywords:
  - "WebBrowser control [Windows Forms], security"
  - "security [Windows Forms], WebBrowser control"
ms.assetid: 0968846e-48ee-485a-9797-65b5b9a622f8
---
# WebBrowser Security

The <xref:System.Windows.Forms.WebBrowser> control is designed to work in full trust only. The HTML content displayed in the control can come from external Web servers and may contain unmanaged code in the form of scripts or Web controls. If you use the <xref:System.Windows.Forms.WebBrowser> control in this situation, the control is no less secure than Internet Explorer would be, but the managed <xref:System.Windows.Forms.WebBrowser> control does not prevent such unmanaged code from running.

For more information about security issues relating to the underlying ActiveX `WebBrowser` control, see [WebBrowser Control](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa752040(v=vs.85)).

## See also

- <xref:System.Windows.Forms.WebBrowser>
- [WebBrowser Control Overview](webbrowser-control-overview.md)
- [WebBrowser Control](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa752040(v=vs.85))
