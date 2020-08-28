---
title: "How to: Put Quotation Marks in a String"
description: Learn how to place quotation marks in a string of text. Also, learn to use the Quote field as a constant.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "quotation marks"
  - "TextBox control [Windows Forms], displaying quotation marks"
  - "quotation marks [Windows Forms], adding to strings in text boxes"
ms.assetid: 68bdc3f3-4177-4eab-99cd-cac17a82b515
---
# How to: Put Quotation Marks in a String (Windows Forms)
Sometimes you might want to place quotation marks (" ") in a string of text. For example:  
  
 She said, "You deserve a treat!"  
  
 As an alternative, you can also use the <xref:Microsoft.VisualBasic.ControlChars.Quote> field as a constant.  
  
### To place quotation marks in a string in your code  
  
1. In Visual Basic, insert two quotation marks in a row as an embedded quotation mark. In Visual C# and Visual C++, insert the escape sequence \\" as an embedded quotation mark. For example, to create the preceding string, use the following code.  
  
    ```vb  
    Private Sub InsertQuote()  
       TextBox1.Text = "She said, ""You deserve a treat!"" "  
    End Sub  
    ```  
  
    ```csharp  
    private void InsertQuote(){  
       textBox1.Text = "She said, \"You deserve a treat!\" ";  
    }  
    ```  
  
    ```cpp  
    private:  
       void InsertQuote()  
       {  
          textBox1->Text = "She said, \"You deserve a treat!\" ";  
       }  
    ```  
  
     -or-  
  
2. Insert the ASCII or Unicode character for a quotation mark. In Visual Basic, use the ASCII character (34). In Visual C#, use the Unicode character (\u0022).  
  
    ```vb  
    Private Sub InsertAscii()  
       TextBox1.Text = "She said, " & Chr(34) & "You deserve a treat!" & Chr(34)  
    End Sub  
    ```  
  
    ```csharp  
    private void InsertAscii(){  
       textBox1.Text = "She said, " + '\u0022' + "You deserve a treat!" + '\u0022';  
    }  
    ```  
  
    > [!NOTE]
    > In this example, you cannot use \u0022 because you cannot use a universal character name that designates a character in the basic character set. Otherwise, you produce C3851. For more information, see [Compiler Error C3851](/cpp/error-messages/compiler-errors-2/compiler-error-c3851).  
  
     -or-  
  
3. You can also define a constant for the character, and use it where needed.  
  
    ```vb  
    Const quote As String = """"  
    TextBox1.Text = "She said, " & quote & "You deserve a treat!" & quote  
    ```  
  
    ```csharp  
    const string quote = "\"";  
    textBox1.Text = "She said, " + quote +  "You deserve a treat!"+ quote ;  
    ```  
  
    ```cpp  
    const String^ quote = "\"";  
    textBox1->Text = String::Concat("She said, ",  
       const_cast<String^>(quote), "You deserve a treat!",  
       const_cast<String^>(quote));  
    ```  
  
## See also

- <xref:System.Windows.Forms.TextBox>
- <xref:Microsoft.VisualBasic.ControlChars.Quote>
- [TextBox Control Overview](textbox-control-overview-windows-forms.md)
- [How to: Control the Insertion Point in a Windows Forms TextBox Control](how-to-control-the-insertion-point-in-a-windows-forms-textbox-control.md)
- [How to: Create a Password Text Box with the Windows Forms TextBox Control](how-to-create-a-password-text-box-with-the-windows-forms-textbox-control.md)
- [How to: Create a Read-Only Text Box](how-to-create-a-read-only-text-box-windows-forms.md)
- [How to: Select Text in the Windows Forms TextBox Control](how-to-select-text-in-the-windows-forms-textbox-control.md)
- [How to: View Multiple Lines in the Windows Forms TextBox Control](how-to-view-multiple-lines-in-the-windows-forms-textbox-control.md)
- [TextBox Control](textbox-control-windows-forms.md)
