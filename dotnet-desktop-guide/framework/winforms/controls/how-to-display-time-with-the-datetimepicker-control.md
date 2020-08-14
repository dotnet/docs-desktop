---
title: "How to: Display Time with the DateTimePicker Control"
description: Learn how to use the Windows Forms DateTimePicker control to enable users to select a date and time, and to display that date and time in the specified format.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "time [Windows Forms], displaying in DateTimePicker control"
  - "examples [Windows Forms], DateTimePicker control"
  - "DateTimePicker control [Windows Forms], displaying time"
ms.assetid: 0c1c8b40-1b50-4301-a90c-39516775ccb1
---
# How to: Display Time with the DateTimePicker Control
If you want your application to enable users to select a date and time, and to display that date and time in the specified format, use the <xref:System.Windows.Forms.DateTimePicker> control. The following procedure shows how to use the <xref:System.Windows.Forms.DateTimePicker> control to display the time.  
  
### To display the time with the DateTimePicker control  
  
1. Set the <xref:System.Windows.Forms.DateTimePicker.Format%2A> property to <xref:System.Windows.Forms.DateTimePickerFormat.Time>  
  
     [!code-csharp[System.Windows.Forms.DateTimePickerTimeOnly#2](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DateTimePickerTimeOnly/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.DateTimePickerTimeOnly#2](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DateTimePickerTimeOnly/VB/Form1.vb#2)]  
  
2. Set the <xref:System.Windows.Forms.DateTimePicker.ShowUpDown%2A> property for the <xref:System.Windows.Forms.DateTimePicker> to `true`.  
  
     [!code-csharp[System.Windows.Forms.DateTimePickerTimeOnly#3](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DateTimePickerTimeOnly/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.DateTimePickerTimeOnly#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DateTimePickerTimeOnly/VB/Form1.vb#3)]  
  
## Example  
 The following code sample shows how to create a <xref:System.Windows.Forms.DateTimePicker> that enables users to choose a time only.  
  
 [!code-csharp[System.Windows.Forms.DateTimePickerTimeOnly#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DateTimePickerTimeOnly/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.DateTimePickerTimeOnly#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DateTimePickerTimeOnly/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- [DateTimePicker Control](datetimepicker-control-windows-forms.md)
