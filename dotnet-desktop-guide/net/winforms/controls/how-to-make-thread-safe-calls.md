---
title: How to make thread-safe calls to controls
description: Learn how to implement multithreading in your app by calling cross-thread controls in a thread-safe way. If you encounter the 'cross-thread operation not valid' error, use the InvokeRequired property to detect this error. The BackgroundWorker component is also an alternative to creating new threads.
ms.date: 06/20/2021
dev_langs:
  - "csharp"
  - "vb"
f1_keywords: 
  - "EHInvalidOperation.WinForms.IllegalCrossThreadCall"
helpviewer_keywords: 
  - "thread safety [Windows Forms], calling controls [Windows Forms]"
  - "calling controls [Windows Forms], thread safety [Windows Forms]"
  - "CheckForIllegalCrossThreadCalls property [Windows Forms]"
  - "Windows Forms controls [Windows Forms], multithreading"
  - "BackgroundWorker class [Windows Forms], examples"
  - "threading [Windows Forms], cross-thread calls"
  - "controls [Windows Forms], multithreading"
---

# How to make thread-safe calls to controls (Windows Forms .NET)

Multithreading can improve the performance of Windows Forms apps, but access to Windows Forms controls isn't inherently thread-safe. Multithreading can expose your code to serious and complex bugs. Two or more threads manipulating a control can force the control into an inconsistent state and lead to race conditions, deadlocks, and freezes or hangs. If you implement multithreading in your app, be sure to call cross-thread controls in a thread-safe way. For more information, see [Managed threading best practices](/dotnet/standard/threading/managed-threading-best-practices).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

There are two ways to safely call a Windows Forms control from a thread that didn't create that control. Use the <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=fullName> method to call a delegate created in the main thread, which in turn calls the control. Or, implement a <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType>, which uses an event-driven model to separate work done in the background thread from reporting on the results.

## Unsafe cross-thread calls

It's unsafe to call a control directly from a thread that didn't create it. The following code snippet illustrates an unsafe call to the <xref:System.Windows.Forms.TextBox?displayProperty=nameWithType> control. The `Button1_Click` event handler creates a new `WriteTextUnsafe` thread, which sets the main thread's <xref:System.Windows.Forms.TextBox.Text%2A?displayProperty=nameWithType> property directly.

:::code language="csharp" source="snippets/how-to-make-thread-safe-calls/cs/FormBad.cs" id="Bad":::
:::code language="vb" source="snippets/how-to-make-thread-safe-calls/vb/FormBad.vb" id="Bad":::

The Visual Studio debugger detects these unsafe thread calls by raising an <xref:System.InvalidOperationException> with the message, **Cross-thread operation not valid. Control accessed from a thread other than the thread it was created on.** The <xref:System.InvalidOperationException> always occurs for unsafe cross-thread calls during Visual Studio debugging, and may occur at app runtime. You should fix the issue, but you can disable the exception by setting the <xref:System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls%2A?displayProperty=nameWithType> property to `false`.

## Safe cross-thread calls

The following code examples demonstrate two ways to safely call a Windows Forms control from a thread that didn't create it:

1. The <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=fullName> method, which calls a delegate from the main thread to call the control.
2. A <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType> component, which offers an event-driven model.

In both examples, the background thread sleeps for one second to simulate work being done in that thread.

## Example: Use the Invoke method

The following example demonstrates a pattern for ensuring thread-safe calls to a Windows Forms control. It queries the <xref:System.Windows.Forms.Control.InvokeRequired%2A?displayProperty=fullName> property, which compares the control's creating thread ID to the calling thread ID. If they're different, you should call the <xref:System.Windows.Forms.Control.Invoke%2A?displayProperty=nameWithType> method.

The `WriteTextSafe` enables setting the <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.TextBox.Text%2A> property to a new value. The method queries <xref:System.Windows.Forms.Control.InvokeRequired%2A>. If <xref:System.Windows.Forms.Control.InvokeRequired%2A> returns `true`, `WriteTextSafe` recursively calls itself, passing the method as a delegate to the <xref:System.Windows.Forms.Control.Invoke%2A> method. If <xref:System.Windows.Forms.Control.InvokeRequired%2A> returns `false`, `WriteTextSafe` sets the <xref:System.Windows.Forms.TextBox.Text%2A?displayProperty=nameWithType> directly. The `Button1_Click` event handler creates the new thread and runs the `WriteTextSafe` method.

:::code language="csharp" source="snippets/how-to-make-thread-safe-calls/cs/FormThread.cs" id="Good":::
:::code language="vb" source="snippets/how-to-make-thread-safe-calls/vb/FormThread.vb" id="Good":::

## Example: Use a BackgroundWorker

An easy way to implement multithreading is with the <xref:System.ComponentModel.BackgroundWorker?displayProperty=nameWithType> component, which uses an event-driven model. The background thread raises the <xref:System.ComponentModel.BackgroundWorker.DoWork?displayProperty=nameWithType> event, which doesn't interact with the main thread. The main thread runs the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged?displayProperty=nameWithType> and <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted?displayProperty=nameWithType> event handlers, which can call the main thread's controls.

To make a thread-safe call by using <xref:System.ComponentModel.BackgroundWorker>, handle the <xref:System.ComponentModel.BackgroundWorker.DoWork> event. There are two events the background worker uses to report status: <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> and <xref:System.ComponentModel.BackgroundWorker.RunWorkerCompleted>. The `ProgressChanged` event is used to communicate status updates to the main thread, and the `RunWorkerCompleted` event is used to signal that the background worker has completed its work. To start the background thread, call <xref:System.ComponentModel.BackgroundWorker.RunWorkerAsync%2A?displayProperty=nameWithType>.

The example counts from 0 to 10 in the `DoWork` event, pausing for one second between counts. It uses the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> event handler to report the number back to the main thread and set the <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.TextBox.Text%2A> property. For the <xref:System.ComponentModel.BackgroundWorker.ProgressChanged> event to work, the <xref:System.ComponentModel.BackgroundWorker.WorkerReportsProgress%2A?displayProperty=nameWithType> property must be set to `true`.

:::code language="csharp" source="snippets/how-to-make-thread-safe-calls/cs/FormBackgroundWorker.cs" id="Background":::
:::code language="vb" source="snippets/how-to-make-thread-safe-calls/vb/FormBackgroundWorker.vb" id="Background":::
