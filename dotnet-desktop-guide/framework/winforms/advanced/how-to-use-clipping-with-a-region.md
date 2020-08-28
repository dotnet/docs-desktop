---
title: "How to: Use Clipping with a Region"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "regions [Windows Forms], clipping"
  - "regions [Windows Forms], restricting drawing surface"
ms.assetid: 43d121b4-e14c-4901-b25c-2d6c25ba4e29
---
# How to: Use Clipping with a Region
One of the properties of the <xref:System.Drawing.Graphics> class is the clip region. All drawing done by a given <xref:System.Drawing.Graphics> object is restricted to the clip region of that <xref:System.Drawing.Graphics> object. You can set the clip region by calling the <xref:System.Drawing.Graphics.SetClip%2A> method.  
  
## Example  
 The following example constructs a path that consists of a single polygon. Then the code constructs a region, based on that path. The region is passed to the <xref:System.Drawing.Graphics.SetClip%2A> method of a <xref:System.Drawing.Graphics> object, and then two strings are drawn.  
  
 The following illustration shows the clipped strings:  
  
 ![Screenshot that shows clipped strings.](./media/how-to-use-clipping-with-a-region/clipped-strings-polygon.png)  
  
 [!code-csharp[System.Drawing.MiscLegacyTopics#41](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/CS/Class1.cs#41)]
 [!code-vb[System.Drawing.MiscLegacyTopics#41](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.MiscLegacyTopics/VB/Class1.vb#41)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See also

- [Regions in GDI+](regions-in-gdi.md)
- [Using Regions](using-regions.md)
