---
title: "Timer Component Overview"
ms.date: "03/30/2017"
f1_keywords: 
  - "Timer"
helpviewer_keywords: 
  - "Timer component [Windows Forms], about Timer components"
  - "timers [Windows Forms], about timers"
ms.assetid: e672c05b-a8b6-4b26-9e4d-9223aa9e3873
---
# Timer Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.Timer> is a component that raises an event at regular intervals. This component is designed for a Windows Forms environment. If you need a timer that is suitable for a server environment, see [Introduction to Server-Based Timers](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/tb9yt5e6(v=vs.90)).  
  
## Key Properties, Methods, and Events  
 The length of the intervals is defined by the <xref:System.Windows.Forms.Timer.Interval%2A> property, whose value is in milliseconds. When the component is enabled, the <xref:System.Windows.Forms.Timer.Tick> event is raised every interval. This is where you would add code to be executed. For more information, see [How to: Run Procedures at Set Intervals with the Windows Forms Timer Component](run-procedures-at-set-intervals-with-wf-timer-component.md). The key methods of the <xref:System.Windows.Forms.Timer> component are <xref:System.Windows.Forms.Timer.Start%2A> and <xref:System.Windows.Forms.Timer.Stop%2A>, which turn the timer on and off. When the timer is switched off, it resets; there is no way to pause a <xref:System.Windows.Forms.Timer> component.  
  
## See also

- <xref:System.Windows.Forms.Timer>
- [Timer Component](timer-component-windows-forms.md)
- [Limitations of the Windows Forms Timer Component's Interval Property](limitations-of-the-timer-component-interval-property.md)
