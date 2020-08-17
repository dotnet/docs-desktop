---
title: Designate a Button as the Accept Button
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "buttons [Windows Forms], default on Windows Forms"
  - "Accept button on Windows Forms"
  - "Button control [Windows Forms], designating as default"
  - "Windows Forms controls, default button on form"
ms.assetid: 22cc9da6-b913-4e04-9554-dee443ac5c3a
---
# How to: Designate a Windows Forms Button as the Accept Button
On any Windows Form, you can designate a <xref:System.Windows.Forms.Button> control to be the accept button, also known as the default button. Whenever the user presses the ENTER key, the default button is clicked regardless of which other control on the form has the focus.  
  
> [!NOTE]
> The exceptions to this are when the control with focus is another button — in that case, the button with the focus will be clicked — or a multiline text box, or a custom control that traps the ENTER key.  
  
### To designate the accept button  
  
1. Set the form's <xref:System.Windows.Forms.Form.AcceptButton%2A> property to the appropriate <xref:System.Windows.Forms.Button> control.  
  
    ```vb  
    Private Sub SetDefault(ByVal myDefaultBtn As Button)  
      Me.AcceptButton = myDefaultBtn
    End Sub  
    ```  
  
    ```csharp  
    private void SetDefault(Button myDefaultBtn)  
    {  
       this.AcceptButton = myDefaultBtn;  
    }  
    ```  
  
    ```cpp  
    private:  
       void SetDefault(Button ^ myDefaultBtn)  
       {  
          this->AcceptButton = myDefaultBtn;  
       }  
    ```  
  
## See also

- <xref:System.Windows.Forms.Form.AcceptButton%2A>
- [Button Control Overview](button-control-overview-windows-forms.md)
- [Ways to Select a Windows Forms Button Control](ways-to-select-a-windows-forms-button-control.md)
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [How to: Designate a Windows Forms Button as the Cancel Button](how-to-designate-a-windows-forms-button-as-the-cancel-button.md)
- [Button Control](button-control-windows-forms.md)
