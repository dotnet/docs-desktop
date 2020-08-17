---
title: Designate a Button as the Cancel Button
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "buttons [Windows Forms], cancel buttons"
  - "Button control [Windows Forms], designating as cancel button"
ms.assetid: 252f0834-e54b-44d9-96f7-ee5f50e94f2c
---
# How to: Designate a Windows Forms Button as the Cancel Button
On any Windows Form, you can designate a <xref:System.Windows.Forms.Button> control to be the cancel button. A cancel button is clicked whenever the user presses the ESC key, regardless of which other control on the form has the focus. Such a button is usually programmed to enable the user to quickly exit an operation without committing to any action.  
  
### To designate the cancel button  
  
1. Set the form's <xref:System.Windows.Forms.Form.CancelButton%2A> property to the appropriate <xref:System.Windows.Forms.Button> control.  
  
    ```vb  
    Private Sub SetCancelButton(ByVal myCancelBtn As Button)  
       Me.CancelButton = myCancelBtn  
    End Sub  
    ```  
  
    ```csharp  
    private void SetCancelButton(Button myCancelBtn)  
    {  
       this.CancelButton = myCancelBtn;  
    }  
    ```  
  
    ```cpp  
    private:  
       void SetCancelButton(Button ^ myCancelBtn)  
       {  
          this->CancelButton = myCancelBtn;  
       }  
    ```  
  
## See also

- <xref:System.Windows.Forms.Form.CancelButton%2A>
- [Button Control Overview](button-control-overview-windows-forms.md)
- [Ways to Select a Windows Forms Button Control](ways-to-select-a-windows-forms-button-control.md)
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [How to: Designate a Windows Forms Button as the Accept Button](how-to-designate-a-windows-forms-button-as-the-accept-button.md)
- [Button Control](button-control-windows-forms.md)
