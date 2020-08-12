---
title: "How to: Manually Manage Buffered Graphics"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "flicker [Windows Forms], reducing by manually managing graphics"
  - "graphics [Windows Forms], managing buffered"
ms.assetid: 4c2a90ee-bbbe-4ff6-9170-1b06c195c918
---
# How to: Manually Manage Buffered Graphics
For more advanced double buffering scenarios, you can use the .NET Framework classes to implement your own double-buffering logic. The class responsible for allocating and managing individual graphics buffers is the <xref:System.Drawing.BufferedGraphicsContext> class. Every application has its own default <xref:System.Drawing.BufferedGraphicsContext> that manages all of the default double buffering for that application. You can retrieve a reference to this instance by calling the <xref:System.Drawing.BufferedGraphicsManager.Current%2A>.  
  
### To obtain a reference to the default BufferedGraphicsContext  
  
- Set the <xref:System.Drawing.BufferedGraphicsManager.Current%2A> property, as shown in the following code example.  
  
     [!code-csharp[System.Windows.Forms.LegacyBufferedGraphics#11](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/CS/Class1.cs#11)]
     [!code-vb[System.Windows.Forms.LegacyBufferedGraphics#11](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/VB/Class1.vb#11)]  
  
    > [!NOTE]
    > You do not need to call the `Dispose` method on the <xref:System.Drawing.BufferedGraphicsContext> reference that you receive from the <xref:System.Drawing.BufferedGraphicsManager> class. The <xref:System.Drawing.BufferedGraphicsManager> handles all of the memory allocation and distribution for default <xref:System.Drawing.BufferedGraphicsContext> instances.  
  
     For graphically intensive applications such as animation, you can sometimes improve performance by using a dedicated <xref:System.Drawing.BufferedGraphicsContext> instead of the <xref:System.Drawing.BufferedGraphicsContext> provided by the <xref:System.Drawing.BufferedGraphicsManager>. This enables you to create and manage graphics buffers individually, without incurring the performance overhead of managing all the other buffered graphics associated with your application, though the memory consumed by the application will be greater.  
  
### To create a dedicated BufferedGraphicsContext  
  
- Declare and create a new instance of the <xref:System.Drawing.BufferedGraphicsContext> class, as shown in the following code example.  
  
     [!code-csharp[System.Windows.Forms.LegacyBufferedGraphics#12](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/CS/Class1.cs#12)]
     [!code-vb[System.Windows.Forms.LegacyBufferedGraphics#12](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.LegacyBufferedGraphics/VB/Class1.vb#12)]  
  
## See also

- <xref:System.Drawing.BufferedGraphicsContext>
- [Double Buffered Graphics](double-buffered-graphics.md)
- [How to: Manually Render Buffered Graphics](how-to-manually-render-buffered-graphics.md)
