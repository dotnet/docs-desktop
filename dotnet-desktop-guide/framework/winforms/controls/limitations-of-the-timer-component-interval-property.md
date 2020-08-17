---
title: Limitations of Timer Component Interval Property
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "timers [Windows Forms], event intervals"
  - "Interval property [Windows Forms], limitations"
  - "timers [Windows Forms], Windows-based"
  - "Timer component [Windows Forms], limitations of Interval property"
ms.assetid: 7e5fb513-77e7-4046-a8e8-aab94e61ca0f
---
# Limitations of the Windows Forms Timer Component's Interval Property
The Windows Forms <xref:System.Windows.Forms.Timer> component has an <xref:System.Windows.Forms.Timer.Interval%2A> property that specifies the number of milliseconds that pass between one timer event and the next. Unless the component is disabled, a timer continues to receive the <xref:System.Windows.Forms.Timer.Tick> event at roughly equal intervals of time.  
  
 This component is designed for a Windows Forms environment. If you need a timer that is suitable for a server environment, see [Introduction to Server-Based Timers](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/tb9yt5e6(v=vs.90)).  
  
## The Interval Property  
 The <xref:System.Windows.Forms.Timer.Interval%2A> property has a few limitations to consider when you are programming a <xref:System.Windows.Forms.Timer> component:  
  
- If your application or another application is making heavy demands on the system — such as long loops, intensive calculations, or drive, network, or port access — your application may not get timer events as often as the <xref:System.Windows.Forms.Timer.Interval%2A> property specifies.  
  
- The interval is not guaranteed to elapse exactly on time. To ensure accuracy, the timer should check the system clock as needed, rather than try to keep track of accumulated time internally.  
  
- The precision of the <xref:System.Windows.Forms.Timer.Interval%2A> property is in milliseconds. Some computers provide a high-resolution counter that has a resolution higher than milliseconds. The availability of such a counter depends on the processor hardware of your computer.
  
## See also

- <xref:System.Windows.Forms.Timer>
- [Timer Component](timer-component-windows-forms.md)
- [Timer Component Overview](timer-component-overview-windows-forms.md)
