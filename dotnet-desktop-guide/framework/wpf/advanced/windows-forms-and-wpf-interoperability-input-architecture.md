---
title: "Windows Forms and WPF interop input architecture"
titleSuffix: ""
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "input architecture [WPF interoperability]"
  - "messages [WPF]"
  - "Windows Forms [WPF], interoperability with"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "modeless forms [WPF]"
  - "ElementHost keyboard and messages [WPF]"
  - "keyboard interoperation [WPF]"
  - "WindowsFormsHost keyboard and messages [WPF]"
  - "modeless dialog boxes [WPF]"
ms.assetid: 0eb6f137-f088-4c5e-9e37-f96afd28f235
description: Learn how these technologies implement keyboard and message processing to enable smooth interoperation in hybrid applications.
---
# Windows Forms and WPF Interoperability Input Architecture

Interoperation between the WPF and Windows Forms requires that both technologies have the appropriate keyboard input processing. This topic describes how these technologies implement keyboard and message processing to enable smooth interoperation in hybrid applications.  
  
 This topic contains the following subsections:  
  
- Modeless Forms and Dialog Boxes  
  
- WindowsFormsHost Keyboard and Message Processing  
  
- ElementHost Keyboard and Message Processing  
  
## Modeless Forms and Dialog Boxes  

 Call the <xref:System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop%2A> method on the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element to open a modeless form or dialog box from a WPF-based application.  
  
 Call the <xref:System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop%2A> method on the <xref:System.Windows.Forms.Integration.ElementHost> control to open a modeless WPF page in a Windows Forms-based application.  
  
## WindowsFormsHost Keyboard and Message Processing  

 When hosted by a WPF-based application, Windows Forms keyboard and message processing consists of the following:  
  
- The <xref:System.Windows.Forms.Integration.WindowsFormsHost> class acquires messages from the WPF message loop, which is implemented by the <xref:System.Windows.Interop.ComponentDispatcher> class.  
  
- The <xref:System.Windows.Forms.Integration.WindowsFormsHost> class creates a surrogate Windows Forms message loop to ensure that ordinary Windows Forms keyboard processing occurs.  
  
- The <xref:System.Windows.Forms.Integration.WindowsFormsHost> class implements the <xref:System.Windows.Interop.IKeyboardInputSink> interface to coordinate focus management with WPF.  
  
- The <xref:System.Windows.Forms.Integration.WindowsFormsHost> controls register themselves and start their message loops.  
  
 The following sections describe these parts of the process in more detail.  
  
### Acquiring Messages from the WPF Message Loop  

 The <xref:System.Windows.Interop.ComponentDispatcher> class implements the message loop manager for WPF. The <xref:System.Windows.Interop.ComponentDispatcher> class provides hooks to enable external clients to filter messages before WPF processes them.  
  
 The interoperation implementation handles the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event, which enables Windows Forms controls to process messages before WPF controls.  
  
### Surrogate Windows Forms Message Loop  

 By default, the <xref:System.Windows.Forms.Application?displayProperty=nameWithType> class contains the primary message loop for Windows Forms applications. During interoperation, the Windows Forms message loop does not process messages. Therefore, this logic must be reproduced. The handler for the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event performs the following steps:  
  
1. Filters the message using the <xref:System.Windows.Forms.IMessageFilter> interface.  
  
2. Calls the <xref:System.Windows.Forms.Control.PreProcessMessage%2A?displayProperty=nameWithType> method.  
  
3. Translates and dispatches the message, if it is required.  
  
4. Passes the message to the hosting control, if no other controls process the message.  
  
### IKeyboardInputSink Implementation  

 The surrogate message loop handles keyboard management. Therefore, the <xref:System.Windows.Interop.IKeyboardInputSink.TabInto%2A?displayProperty=nameWithType> method is the only <xref:System.Windows.Interop.IKeyboardInputSink> member that requires an implementation in the <xref:System.Windows.Forms.Integration.WindowsFormsHost> class.  
  
 By default, the <xref:System.Windows.Interop.HwndHost> class returns `false` for its <xref:System.Windows.Interop.HwndHost.System%23Windows%23Interop%23IKeyboardInputSink%23TabInto%2A> implementation. This prevents tabbing from a WPF control to a Windows Forms control.  
  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> implementation of the <xref:System.Windows.Interop.IKeyboardInputSink.TabInto%2A?displayProperty=nameWithType> method performs the following steps:  
  
1. Finds the first or last Windows Forms control that is contained by the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control and that can receive focus. The control choice depends on traversal information.  
  
2. Sets focus to the control and returns `true`.  
  
3. If no control can receive focus, returns `false`.  
  
### WindowsFormsHost Registration  

 When the window handle to a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control is created, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control calls an internal static method that registers its presence for the message loop.  
  
 During registration, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control examines the message loop. If the message loop has not been started, the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event handler is created. The message loop is considered to be running when the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event handler is attached.  
  
 When the window handle is destroyed, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control removes itself from registration.  
  
## ElementHost Keyboard and Message Processing  

 When hosted by a Windows Forms application, WPF keyboard and message processing consists of the following:  
  
- <xref:System.Windows.Interop.HwndSource>, <xref:System.Windows.Interop.IKeyboardInputSink>, and <xref:System.Windows.Interop.IKeyboardInputSite> interface implementations.  
  
- Tabbing and arrow keys.  
  
- Command keys and dialog box keys.  
  
- Windows Forms accelerator processing.  
  
 The following sections describe these parts in more detail.  
  
### Interface Implementations  

 In Windows Forms, keyboard messages are routed to the window handle of the control that has focus. In the <xref:System.Windows.Forms.Integration.ElementHost> control, these messages are routed to the hosted element. To accomplish this, the <xref:System.Windows.Forms.Integration.ElementHost> control provides an <xref:System.Windows.Interop.HwndSource> instance. If the <xref:System.Windows.Forms.Integration.ElementHost> control has focus, the <xref:System.Windows.Interop.HwndSource> instance routes most keyboard input so that it can be processed by the WPF <xref:System.Windows.Input.InputManager> class.  
  
 The <xref:System.Windows.Interop.HwndSource> class implements the <xref:System.Windows.Interop.IKeyboardInputSink> and <xref:System.Windows.Interop.IKeyboardInputSite> interfaces.  
  
 Keyboard interoperation relies on implementing the <xref:System.Windows.Interop.IKeyboardInputSite.OnNoMoreTabStops%2A> method to handle TAB key and arrow key input that moves focus out of hosted elements.  
  
### Tabbing and Arrow Keys  

 The Windows Forms selection logic is mapped to the <xref:System.Windows.Interop.HwndSource.System%23Windows%23Interop%23IKeyboardInputSink%23TabInto%2A> and <xref:System.Windows.Interop.IKeyboardInputSite.OnNoMoreTabStops%2A> methods to implement TAB and arrow key navigation. Overriding the <xref:System.Windows.Forms.Integration.ElementHost.Select%2A> method accomplishes this mapping.  
  
### Command Keys and Dialog Box Keys  

 To give WPF the first opportunity to process command keys and dialog keys, Windows Forms command preprocessing is connected to the <xref:System.Windows.Interop.IKeyboardInputSink.TranslateAccelerator%2A> method. Overriding the <xref:System.Windows.Forms.Control.ProcessCmdKey%2A?displayProperty=nameWithType> method connects the two technologies.  
  
 With the <xref:System.Windows.Interop.IKeyboardInputSink.TranslateAccelerator%2A> method, the hosted elements can handle any key message, such as WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, including command keys, such as TAB, ENTER, ESC, and arrow keys. If a key message is not handled, it is sent up the Windows Forms ancestor hierarchy for handling.  
  
### Accelerator Processing  

 To process accelerators correctly, Windows Forms accelerator processing must be connected to the WPF <xref:System.Windows.Input.AccessKeyManager> class. Additionally, all WM_CHAR messages must be correctly routed to hosted elements.  
  
 Because the default <xref:System.Windows.Interop.HwndSource> implementation of the <xref:System.Windows.Interop.IKeyboardInputSink.TranslateChar%2A> method returns `false`, WM_CHAR messages are processed using the following logic:  
  
- The <xref:System.Windows.Forms.Control.IsInputChar%2A?displayProperty=nameWithType> method is overridden to ensure that all WM_CHAR messages are forwarded to hosted elements.  
  
- If the ALT key is pressed, the message is WM_SYSCHAR. Windows Forms does not preprocess this message through the <xref:System.Windows.Forms.Control.IsInputChar%2A> method. Therefore, the <xref:System.Windows.Forms.Control.ProcessMnemonic%2A> method is overridden to query the WPF <xref:System.Windows.Input.AccessKeyManager> for a registered accelerator. If a registered accelerator is found, <xref:System.Windows.Input.AccessKeyManager> processes it.  
  
- If the ALT key is not pressed, the WPF <xref:System.Windows.Input.InputManager> class processes the unhandled input. If the input is an accelerator, the <xref:System.Windows.Input.AccessKeyManager> processes it. The <xref:System.Windows.Input.InputManager.PostProcessInput> event is handled for WM_CHAR messages that were not processed.  
  
 When the user presses the ALT key, accelerator visual cues are shown on the whole form. To support this behavior, all <xref:System.Windows.Forms.Integration.ElementHost> controls on the active form receive WM_SYSKEYDOWN messages, regardless of which control has focus.  
  
 Messages are sent only to <xref:System.Windows.Forms.Integration.ElementHost> controls in the active form.  
  
## See also

- <xref:System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop%2A>
- <xref:System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop%2A>
- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Walkthrough: Hosting a Windows Forms Composite Control in WPF](walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)
- [Walkthrough: Hosting a WPF Composite Control in Windows Forms](walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
- [WPF and Win32 Interoperation](wpf-and-win32-interoperation.md)
