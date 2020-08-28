---
title: "How to: Draw a Line on a Windows Form"
description: Learn how to draws a line on a form by handling the Paint event, and then perform the drawing using the Graphics property of the PaintEventArgs.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
f1_keywords: 
  - "Graphics.DrawLine"
helpviewer_keywords: 
  - "examples [Windows Forms], drawing lines on forms"
  - "drawing [Windows Forms], lines"
  - "lines [Windows Forms], drawing"
  - "drawing lines"
ms.assetid: 55c1dbeb-75d0-430c-9814-a24b8971ad8c
---
# How to: Draw a Line on a Windows Form
This example draws a line on a form. Typically, when you draw on a form, you handle the form’s  <xref:System.Windows.Forms.Control.Paint> event and perform the drawing using the <xref:System.Windows.Forms.PaintEventArgs.Graphics%2A> property of the <xref:System.Windows.Forms.PaintEventArgs>, as shown in this example  
  
## Example  
 [!code-csharp[System.Drawing.UsingAPen#11](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#11)]
 [!code-vb[System.Drawing.UsingAPen#11](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#11)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs>`e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## Robust Programming  
 You should always call <xref:System.IDisposable.Dispose%2A> on any objects that consume system resources, such as <xref:System.Drawing.Pen> objects.  
  
## See also

- <xref:System.Drawing.Graphics.DrawLine%2A>
- <xref:System.Windows.Forms.Control.OnPaint%2A>
- [Getting Started with Graphics Programming](getting-started-with-graphics-programming.md)
- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
- [Graphics and Drawing in Windows Forms](graphics-and-drawing-in-windows-forms.md)
