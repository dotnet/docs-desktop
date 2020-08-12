---
title: "How to: Run an Operation in the Background"
description: Learn how to use the BackgroundWorker class to run a time-consuming Windows Forms operation in the background.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "background tasks"
  - "forms [Windows Forms], multithreading"
  - "forms [Windows Forms], background operations"
  - "background threads"
  - "BackgroundWorker class [Windows Forms], examples"
  - "threading [Windows Forms], background operations"
  - "background operations"
ms.assetid: 5b56e2aa-dc05-444f-930c-2d7b23f9ad5b
---
# How to: Run an Operation in the Background
If you have an operation that will take a long time to complete, and you do not want to cause delays in your user interface, you can use the <xref:System.ComponentModel.BackgroundWorker> class to run the operation on another thread.  
  
 The following code example shows how to run a time-consuming operation in the background. The form has **Start** and **Cancel** buttons. Click the **Start** button to run an asynchronous operation. Click the **Cancel** button to stop a running asynchronous operation. The outcome of each operation is displayed in a <xref:System.Windows.Forms.MessageBox>.  
  
 There is extensive support for this task in Visual Studio.  
  
 Also see [Walkthrough: Running an Operation in the Background](walkthrough-running-an-operation-in-the-background.md).  
  
## Example  
 [!code-csharp[System.ComponentModel.BackgroundWorker.Example#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/CS/Form1.cs#1)]
 [!code-vb[System.ComponentModel.BackgroundWorker.Example#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.BackgroundWorker.Example/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.ComponentModel.BackgroundWorker>
- <xref:System.ComponentModel.DoWorkEventArgs>
- [How to: Implement a Form That Uses a Background Operation](how-to-implement-a-form-that-uses-a-background-operation.md)
- [BackgroundWorker Component](backgroundworker-component.md)
