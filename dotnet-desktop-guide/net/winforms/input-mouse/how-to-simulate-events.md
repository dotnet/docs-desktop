---
title: "Simulate mouse events"
description: Learn how to simulate mouse events with the 
ms.date: "07/16/2020"
ms.topic: how-to
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keyboards [Windows Forms], event simulation"
  - "user input [Windows Forms], simulating"
  - "SendKeys [Windows Forms], using"
---
# How to simulate mouse events (Windows Forms .NET)

Windows Forms provides several options for programmatically simulating mouse and keyboard input. This topic provides an overview of these options.

## Simulating Keyboard Input

Although you can simulate keyboard input by using the strategies discussed above for mouse input, Windows Forms also provides the <xref:System.Windows.Forms.SendKeys> class for sending keystrokes to the active application.

> [!CAUTION]
> If your application is intended for international use with a variety of keyboards, the use of <xref:System.Windows.Forms.SendKeys.Send%2A?displayProperty=nameWithType> could yield unpredictable results and should be avoided.

## Behavior

Behind the scenes, the <xref:System.Windows.Forms.SendKeys> class is susceptible to timing issues, which some developers have had to work around. The default mode of `SendKeys` is to use an older Windows implementation for sending input. If that fails, a newer Windows implementation is used. 

 is susceptible to timing issues, but is slightly faster than and may require changes to the workarounds. The <xref:System.Windows.Forms.SendKeys> class tries to use the previous implementation first, and if that fails, uses the new implementation. As a result, the <xref:System.Windows.Forms.SendKeys> class may behave differently on different operating systems. Additionally, when the <xref:System.Windows.Forms.SendKeys> class uses the new implementation, the <xref:System.Windows.Forms.SendKeys.SendWait%2A> method will not wait for messages to be processed when they are sent to another process.
>
> If your application relies on consistent behavior regardless of the operating system, you can force the <xref:System.Windows.Forms.SendKeys> class to use the new implementation by adding the following application setting to your app.config file.
>
> ```xml
> <appSettings>
>  <add key="SendKeys" value="SendInput"/>
> </appSettings>
> ```
>
> To force the <xref:System.Windows.Forms.SendKeys> class to use the previous implementation, use the value `"JournalHook"` instead.

## To send a keystroke to the same application

Call the <xref:System.Windows.Forms.SendKeys.Send%2A> or <xref:System.Windows.Forms.SendKeys.SendWait%2A> method of the <xref:System.Windows.Forms.SendKeys> class. The specified keystrokes will be received by the active control of the application. The following code example uses <xref:System.Windows.Forms.SendKeys.Send%2A> to simulate pressing the ENTER key when the user double-clicks the surface of the form. This example assumes a <xref:System.Windows.Forms.Form> with a single <xref:System.Windows.Forms.Button> control that has a tab index of 0.

[!code-cpp[System.Windows.Forms.SimulateKeyPress#10](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/cpp/form1.cpp#10)]
[!code-csharp[System.Windows.Forms.SimulateKeyPress#10](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/CS/form1.cs#10)]
[!code-vb[System.Windows.Forms.SimulateKeyPress#10](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/VB/form1.vb#10)]

## To send a keystroke to a different application

Activate the application window that will receive the keystrokes, and then call the <xref:System.Windows.Forms.SendKeys.Send%2A> or <xref:System.Windows.Forms.SendKeys.SendWait%2A> method. Because there is no managed method to activate another application, you must use native Windows methods to force focus on other applications. The following code example uses platform invoke to call the `FindWindow` and `SetForegroundWindow` methods to activate the Calculator application window, and then calls <xref:System.Windows.Forms.SendKeys.SendWait%2A> to issue a series of calculations to the Calculator application.

> [!NOTE]
> The correct parameters of the `FindWindow` call that locates the Calculator application vary based on your version of Windows.  The following code finds the Calculator application on Windows 7. On Windows Vista, change the first parameter to "SciCalc". You can use the Spy++ tool, included with Visual Studio, to determine the correct parameters.

[!code-cpp[System.Windows.Forms.SimulateKeyPress#5](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/cpp/form1.cpp#5)]
[!code-csharp[System.Windows.Forms.SimulateKeyPress#5](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/CS/form1.cs#5)]
[!code-vb[System.Windows.Forms.SimulateKeyPress#5](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.SimulateKeyPress/VB/form1.vb#5)]


## See also
