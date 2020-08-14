---
title: Create Access Keys for Controls
ms.date: 08/20/2019
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "controls [Windows Forms], access keys"
  - "Button control [Windows Forms], access keys"
  - "dialog box controls [Windows Forms], mnemonics"
  - "access keys [Windows Forms], creating for controls"
  - "mnemonics [Windows Forms], adding to dialog box controls"
  - "mnemonics"
  - "ampersand character in shortcut key"
  - "Windows Forms controls, access keys"
  - "examples [Windows Forms], controls"
  - "Text property [Windows Forms], specifying access keys for controls"
  - "keyboard shortcuts [Windows Forms], creating for controls"
  - "access keys [Windows Forms], Windows Forms"
  - "ALT key"
ms.assetid: 4faa0991-28ec-4eca-91db-51dc2cd6a7ac
---
# How to: Create access keys for Windows Forms controls

An *access key* is an underlined character in the text of a menu, menu item, or the label of a control such as a button. With an access key, the user can "click" a button by pressing the Alt key in combination with the predefined access key. For example, if a button runs a procedure to print a form, and therefore its `Text` property is set to "Print," adding an ampersand before the letter "P" causes the letter "P" to be underlined in the button text at run time. The user can run the command associated with the button by pressing Alt+P.

Controls that cannot receive focus can't have access keys.

## Programmatic

Set the `Text` property to a string that includes an ampersand (&) before the letter that will be the shortcut.

```vb
' Set the letter "P" as an access key.
Button1.Text = "&Print"
```

```csharp
// Set the letter "P" as an access key.
button1.Text = "&Print";
```

```cpp
// Set the letter "P" as an access key.
button1->Text = "&Print";
```

> [!NOTE]
> To use an ampersand in a caption without creating an access key, include two ampersands (&&). A single ampersand is displayed in the caption and no characters are underlined.

## Designer

In the **Properties** window of Visual Studio, set the **Text** property to a string that includes an ampersand ('&') before the letter that will be the access key. For example, to set the letter "P" as the access key, enter **&Print**.

## See also

- <xref:System.Windows.Forms.Button>
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [How to: Set the Text Displayed by a Windows Forms Control](how-to-set-the-text-displayed-by-a-windows-forms-control.md)
- [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
