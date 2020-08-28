---
title: "How to: Set Tab Stops in Drawn Text"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "text [Windows Forms], drawing with tab stops"
  - "tabs [Windows Forms], drawn text"
ms.assetid: 64878f98-39ba-4303-b63f-0859ab682eeb
---
# How to: Set Tab Stops in Drawn Text
You can set tab stops for text by calling the <xref:System.Drawing.StringFormat.SetTabStops%2A> method of a <xref:System.Drawing.StringFormat> object and then passing that <xref:System.Drawing.StringFormat> object to the <xref:System.Drawing.Graphics.DrawString%2A> method of the <xref:System.Drawing.Graphics> class.  
  
> [!NOTE]
> The <xref:System.Windows.Forms.TextRenderer?displayProperty=nameWithType> does not support adding tab stops to drawn text, although you can expand existing tab stops using the <xref:System.Windows.Forms.TextFormatFlags.ExpandTabs?displayProperty=nameWithType> flag.  
  
## Example  
 The following example sets tab stops at 150, 250, and 350. Then, the code displays a tabbed list of names and test scores.  
  
 The following illustration shows the tabbed text:  
  
 ![Screenshot that shows a tabbed list of names and scores.](./media/how-to-set-tab-stops-in-drawn-text/tab-list-names-test-scores.png)  
  
 The following code passes two arguments to the <xref:System.Drawing.StringFormat.SetTabStops%2A> method. The second argument is an array that contains tab offsets. The first argument passed to <xref:System.Drawing.StringFormat.SetTabStops%2A> is 0, which indicates that the first offset in the array is measured from position 0, the left edge of the bounding rectangle.  
  
 [!code-csharp[System.Drawing.FontsAndText#41](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.FontsAndText/CS/Class1.cs#41)]
 [!code-vb[System.Drawing.FontsAndText#41](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.FontsAndText/VB/Class1.vb#41)]  
  
## Compiling the Code  
  
- The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See also

- [Using Fonts and Text](using-fonts-and-text.md)
- [How to: Draw Text with GDI](how-to-draw-text-with-gdi.md)
