---
title: "Handling User Input"
description: Learn about keyboard and mouse events when handling an event, control authors should override the protected method.
ms.date: "03/30/2017"
ms.service: dotnet-framework
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "custom controls [Windows Forms], user input using code"
  - "custom controls [Windows Forms], keyboard events using code"
  - "custom controls [Windows Forms], mouse events using code"
ms.assetid: d9b12787-86f6-4022-8e0f-e12d312c4af2
---
# Handling User Input

This topic describes the main keyboard and mouse events provided by <xref:System.Windows.Forms.Control?displayProperty=nameWithType>. When handling an event, control authors should override the protected `On`*EventName* method rather than attaching a delegate to the event. For a review of events, see [Raising Events from a Component](/previous-versions/visualstudio/visual-studio-2013/sh2e3k5z(v=vs.120)).  
  
> [!NOTE]
> If there is no data associated with an event, an instance of the base class <xref:System.EventArgs> is passed as an argument to the `On`*EventName* method.  
  
## Keyboard Events  

The common keyboard events that your control can handle are <xref:System.Windows.Forms.Control.KeyDown>, <xref:System.Windows.Forms.Control.KeyPress>, and <xref:System.Windows.Forms.Control.KeyUp>.  
  
|Event Name|Method to Override|Description of Event|  
|----------------|------------------------|--------------------------|  
|`KeyDown`|`void OnKeyDown(KeyEventArgs)`|Raised only when a key is initially pressed.|  
|`KeyPress`|`void OnKeyPress`<br /><br /> `(KeyPressEventArgs)`|Raised every time a key is pressed. If a key is held down, a <xref:System.Windows.Forms.Control.KeyPress> event is raised at the repeat rate defined by the operating system.|  
|`KeyUp`|`void OnKeyUp(KeyEventArgs)`|Raised when a key is released.|  
  
> [!NOTE]
> Handling keyboard input is considerably more complex than overriding the events in the preceding table and is beyond the scope of this topic. For more information, see [Overview of using the keyboard](../input-keyboard/overview.md).
  
## Mouse Events  

The mouse events that your control can handle are <xref:System.Windows.Forms.Control.MouseDown>, <xref:System.Windows.Forms.Control.MouseEnter>, <xref:System.Windows.Forms.Control.MouseHover>, <xref:System.Windows.Forms.Control.MouseLeave>, <xref:System.Windows.Forms.Control.MouseMove>, and <xref:System.Windows.Forms.Control.MouseUp>. For more information, see [Overview of using the mouse](../input-mouse/overview.md).
  
|Event Name|Method to Override|Description of Event|  
|----------------|------------------------|--------------------------|  
|`MouseDown`|`void OnMouseDown(MouseEventArgs)`|Raised when the mouse button is pressed while the pointer is over the control.|  
|`MouseEnter`|`void OnMouseEnter(EventArgs)`|Raised when the pointer first enters the region of the control.|  
|`MouseHover`|`void OnMouseHover(EventArgs)`|Raised when the pointer hovers over the control.|  
|`MouseLeave`|`void OnMouseLeave(EventArgs)`|Raised when the pointer leaves the region of the control.|  
|`MouseMove`|`void OnMouseMove(MouseEventArgs)`|Raised when the pointer moves in the region of the control.|  
|`MouseUp`|`void OnMouseUp(MouseEventArgs)`|Raised when the mouse button is released while the pointer is over the control or the pointer leaves the region of the control.|  
  
## See also

- [Defining an Event](../controls-design/usercontrol-overview.md)
- [Events](/dotnet/standard/events/index)
