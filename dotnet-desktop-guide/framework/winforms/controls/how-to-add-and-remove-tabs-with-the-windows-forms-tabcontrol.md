---
title: Add and Remove Tabs with TabControl
description: Learn how to add and remove tabs with the Windows Forms TabControl control, which contains two TabPage controls. Access these tabs through the TabPages property.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "tabs [Windows Forms], removing from pages"
  - "TabPage control"
  - "TabControl control [Windows Forms], adding and removing tabs"
  - "tabs [Windows Forms], adding to pages"
  - "tab pages"
ms.assetid: 66d4dfca-41e8-44e3-9c80-fb7ac4cb1619
---
# How to: Add and Remove Tabs with the Windows Forms TabControl
By default, a <xref:System.Windows.Forms.TabControl> control contains two <xref:System.Windows.Forms.TabPage> controls. You can access these tabs through the <xref:System.Windows.Forms.TabControl.TabPages%2A> property.  
  
### To add a tab programmatically  
  
- Use the <xref:System.Windows.Forms.TabControl.TabPageCollection.Add%2A> method of the <xref:System.Windows.Forms.TabControl.TabPages%2A> property.  
  
    ```vb  
    Dim myTabPage As New TabPage()  
    myTabPage.Text = "TabPage" & (TabControl1.TabPages.Count + 1)  
    TabControl1.TabPages.Add(myTabPage)  
    ```  
  
    ```csharp  
    string title = "TabPage " + (tabControl1.TabCount + 1).ToString();  
    TabPage myTabPage = new TabPage(title);  
    tabControl1.TabPages.Add(myTabPage);  
    ```  
  
    ```cpp  
    String^ title = String::Concat("TabPage ",  
       (tabControl1->TabCount + 1).ToString());  
    TabPage^ myTabPage = gcnew TabPage(title);  
    tabControl1->TabPages->Add(myTabPage);  
    ```  
  
### To remove a tab programmatically  
  
- To remove selected tabs, use the <xref:System.Windows.Forms.TabControl.TabPageCollection.Remove%2A> method of the <xref:System.Windows.Forms.TabControl.TabPages%2A> property.  
  
     -or-  
  
- To remove all tabs, use the <xref:System.Windows.Forms.TabControl.TabPageCollection.Clear%2A> method of the <xref:System.Windows.Forms.TabControl.TabPages%2A> property.  
  
    ```vb  
    ' Removes the selected tab:  
    TabControl1.TabPages.Remove(TabControl1.SelectedTab)  
    ' Removes all the tabs:  
    TabControl1.TabPages.Clear()  
    ```  
  
    ```csharp  
    // Removes the selected tab:  
    tabControl1.TabPages.Remove(tabControl1.SelectedTab);  
    // Removes all the tabs:  
    tabControl1.TabPages.Clear();  
    ```  
  
    ```cpp  
    // Removes the selected tab:  
    tabControl1->TabPages->Remove(tabControl1->SelectedTab);  
    // Removes all the tabs:  
    tabControl1->TabPages->Clear();  
    ```  
  
## See also

- [TabControl Control Overview](tabcontrol-control-overview-windows-forms.md)
- [How to: Add a Control to a Tab Page](how-to-add-a-control-to-a-tab-page.md)
- [How to: Disable Tab Pages](how-to-disable-tab-pages.md)
- [How to: Change the Appearance of the Windows Forms TabControl](how-to-change-the-appearance-of-the-windows-forms-tabcontrol.md)
