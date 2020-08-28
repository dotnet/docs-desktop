---
title: "How to: Apply the PropertyNameChanged Pattern"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "custom controls [Windows Forms], property changes (using code)"
  - "data binding [Windows Forms], custom controls"
  - "PropertyNameChanged pattern [Windows Forms], applying"
ms.assetid: aa47ddf6-5223-40c4-833f-a78992194836
---
# How to: Apply the PropertyNameChanged Pattern
The following code example demonstrates how to apply the *PropertyName*Changed pattern to a custom control. Apply this pattern when you implement custom controls that are used with the Windows Forms data binding engine.  
  
## Example  
 [!code-csharp[System.Windows.Forms.ChangeNotification#3](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ChangeNotification/CS/Form1.cs#3)]
 [!code-vb[System.Windows.Forms.ChangeNotification#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ChangeNotification/VB/Form1.vb#3)]  
  
## Compiling the Code  
 To compile the previous code example:  
  
- Paste the code into an empty code file. You must use the custom control on a Windows Form that contains a `Main` method.  
  
## See also

- [How to: Implement the INotifyPropertyChanged Interface](how-to-implement-the-inotifypropertychanged-interface.md)
- [Change Notification in Windows Forms Data Binding](change-notification-in-windows-forms-data-binding.md)
- [Windows Forms Data Binding](windows-forms-data-binding.md)
