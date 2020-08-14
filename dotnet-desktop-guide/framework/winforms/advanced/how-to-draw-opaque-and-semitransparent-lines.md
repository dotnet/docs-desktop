---
title: "How to: Draw Opaque and Semitransparent Lines"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "drawing [Windows Forms], lines"
  - "transparency [Windows Forms], lines"
  - "lines [Windows Forms], drawing alpha blended"
  - "alpha blending [Windows Forms], drawing lines"
ms.assetid: 8f2508af-f495-4223-b5cc-646cbbb520eb
---
# How to: Draw Opaque and Semitransparent Lines
When you draw a line, you must pass a <xref:System.Drawing.Pen> object to the <xref:System.Drawing.Graphics.DrawLine%2A> method of the <xref:System.Drawing.Graphics> class. One of the parameters of the <xref:System.Drawing.Pen.%23ctor%2A> constructor is a <xref:System.Drawing.Color> object. To draw an opaque line, set the alpha component of the color to 255. To draw a semitransparent line, set the alpha component to any value from 1 through 254.  
  
 When you draw a semitransparent line over a background, the color of the line is blended with the colors of the background. The alpha component specifies how the line and background colors are mixed; alpha values near 0 place more weight on the background colors, and alpha values near 255 place more weight on the line color.  
  
## Example  
 The following example draws a bitmap and then draws three lines that use the bitmap as a background. The first line uses an alpha component of 255, so it is opaque. The second and third lines use an alpha component of 128, so they are semitransparent; you can see the background image through the lines. The statement that sets the <xref:System.Drawing.Graphics.CompositingQuality%2A> property causes the blending for the third line to be done in conjunction with gamma correction.  
  
 [!code-csharp[System.Drawing.AlphaBlending#11](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.AlphaBlending/CS/Class1.cs#11)]
 [!code-vb[System.Drawing.AlphaBlending#11](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.AlphaBlending/VB/Class1.vb#11)]  
  
 The following illustration shows the output of the following code:  
  
 ![Illustration that shows opaque and semitransparent output](./media/how-to-draw-opaque-and-semitransparent-lines/opaque-semitransparent-lines.png)  

## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## See also

- [Alpha Blending Lines and Fills](alpha-blending-lines-and-fills.md)
- [How to: Give Your Control a Transparent Background](../controls/how-to-give-your-control-a-transparent-background.md)
- [How to: Draw with Opaque and Semitransparent Brushes](how-to-draw-with-opaque-and-semitransparent-brushes.md)
