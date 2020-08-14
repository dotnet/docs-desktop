---
title: "How to: Set Pen Width and Alignment"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "pens [Windows Forms], setting width"
  - "pens [Windows Forms], setting alignment"
ms.assetid: a202af36-4d31-4401-a126-b232f51db581
---
# How to: Set Pen Width and Alignment
When you create a <xref:System.Drawing.Pen>, you can supply the pen width as one of the arguments to the constructor. You can also change the pen width with the <xref:System.Drawing.Pen.Width%2A> property of the <xref:System.Drawing.Pen> class.  
  
 A theoretical line has a width of 0. When you draw a line that is 1 pixel wide, the pixels are centered on the theoretical line. If you draw a line that is more than one pixel wide, the pixels are either centered on the theoretical line or appear to one side of the theoretical line. You can set the pen alignment property of a <xref:System.Drawing.Pen> to determine how the pixels drawn with that pen will be positioned relative to theoretical lines.  
  
 The values <xref:System.Drawing.Drawing2D.PenAlignment.Center>, <xref:System.Drawing.Drawing2D.PenAlignment.Outset>, and <xref:System.Drawing.Drawing2D.PenAlignment.Inset> that appear in the following code examples are members of the <xref:System.Drawing.Drawing2D.PenAlignment> enumeration.  
  
 The following code example draws a line twice: once with a black pen of width 1 and once with a green pen of width 10.  
  
### To vary the width of a pen  
  
- Set the value of the <xref:System.Drawing.Pen.Alignment%2A> property to <xref:System.Drawing.Drawing2D.PenAlignment.Center> (the default) to specify that pixels drawn with the green pen will be centered on the theoretical line. The following illustration shows the resulting line.  
  
     ![A black thin line with green highlight.](./media/how-to-set-pen-width-and-alignment/green-pixels-centered-line.gif)  
  
     The following code example draws a rectangle twice: once with a black pen of width 1 and once with a green pen of width 10.  
  
     [!code-csharp[System.Drawing.UsingAPen#41](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#41)]
     [!code-vb[System.Drawing.UsingAPen#41](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#41)]  
  
### To change the alignment of a pen  
  
- Set the value of the <xref:System.Drawing.Pen.Alignment%2A> property to <xref:System.Drawing.Drawing2D.PenAlignment.Center> to specify that the pixels drawn with the green pen will be centered on the boundary of the rectangle.  
  
     The following illustration shows the resulting rectangle:
  
     ![A rectangle drawn with black thin lines with green highlight.](./media/how-to-set-pen-width-and-alignment/green-pixels-centered-rectangle.gif)  
  
     [!code-csharp[System.Drawing.UsingAPen#42](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#42)]
     [!code-vb[System.Drawing.UsingAPen#42](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#42)]  
  
### To create an inset pen  
  
- Change the green pen's alignment by modifying the third statement in the preceding code example as follows:  
  
     [!code-csharp[System.Drawing.UsingAPen#43](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#43)]
     [!code-vb[System.Drawing.UsingAPen#43](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#43)]  
  
     Now the pixels in the wide green line appear on the inside of the rectangle as shown in the following illustration:
  
     ![A rectangle drawn with black lines with the wide green line inside.](./media/how-to-set-pen-width-and-alignment/green-pixels-inside-rectangle.gif)  
  
## See also

- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
- [Graphics and Drawing in Windows Forms](graphics-and-drawing-in-windows-forms.md)
