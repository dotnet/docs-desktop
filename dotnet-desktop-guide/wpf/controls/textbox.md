---
title: "TextBox"
description: Learn how to use the TextBox control to provide support for basic text input in Windows Presentation Foundation (WPF) applications.
ms.date: "01/28/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "controls [WPF], TextBox"
  - "TextBox control [WPF]"
ai-usage: ai-assisted
---
# TextBox

The <xref:System.Windows.Controls.TextBox> class enables you to display or edit unformatted text. A common use of a <xref:System.Windows.Controls.TextBox> is editing unformatted text in a form. For example, a form asking for the user's name, phone number, and other information would use <xref:System.Windows.Controls.TextBox> controls for text input.

:::image type="content" source="./media/shared/textbox.png" alt-text="Screenshot of four TextBox controls demonstrating different states.":::

The following table lists common tasks for working with the TextBox control:

| Title | Description |
|-------|-------------|
| [Create a Multiline TextBox Control](how-to-create-a-multiline-textbox-control.md) | Learn how to create a TextBox that accepts multiple lines of text. |
| [Detect When Text in a TextBox Has Changed](how-to-detect-when-text-in-a-textbox-has-changed.md) | Learn how to respond when text changes in a TextBox. |
| [Enable Tab Characters in a TextBox Control](how-to-enable-tab-characters-in-a-textbox-control.md) | Learn how to allow tab characters in a TextBox. |
| [Get a Collection of Lines from a TextBox](how-to-get-a-collection-of-lines-from-a-textbox.md) | Learn how to retrieve lines of text from a TextBox. |
| [Make a TextBox Control Read-Only](how-to-make-a-textbox-control-read-only.md) | Learn how to prevent editing in a TextBox. |
| [Position the Cursor at the Beginning or End of Text in a TextBox Control](position-the-cursor-at-the-beginning-or-end-of-text.md) | Learn how to set the cursor position in a TextBox. |
| [Retrieve a Text Selection](how-to-retrieve-a-text-selection.md) | Learn how to get selected text from a TextBox. |
| [Set Focus in a TextBox Control](how-to-set-focus-in-a-textbox-control.md) | Learn how to give focus to a TextBox. |
| [Set the Text Content of a TextBox Control](how-to-set-the-text-content-of-a-textbox-control.md) | Learn how to set the initial text in a TextBox. |
| [Enable Spell Checking in a Text Editing Control](how-to-enable-spell-checking-in-a-text-editing-control.md) | Learn how to enable spell checking in a TextBox. |
| [Use a Custom Context Menu with a TextBox](how-to-use-a-custom-context-menu-with-a-textbox.md) | Learn how to create a custom context menu for a TextBox. |
| [Use Spell Checking with a Context Menu](how-to-use-spell-checking-with-a-context-menu.md) | Learn how to integrate spell checking with a context menu. |
| [Add a Watermark to a TextBox](how-to-add-a-watermark-to-a-textbox.md) | Learn how to display placeholder text in a TextBox. |

## TextBox or RichTextBox?

Both <xref:System.Windows.Controls.TextBox> and <xref:System.Windows.Controls.RichTextBox> allow users to input text, but the two controls are used for different scenarios. A <xref:System.Windows.Controls.TextBox> requires less system resources than a <xref:System.Windows.Controls.RichTextBox>, so it's ideal when only plain text needs to be edited (that is, usage in a form). A <xref:System.Windows.Controls.RichTextBox> is a better choice when it's necessary for the user to edit formatted text, images, tables, or other supported content. For example, editing a document, article, or blog that requires formatting, images, and other content is best accomplished using a <xref:System.Windows.Controls.RichTextBox>. The following table summarizes the primary features of <xref:System.Windows.Controls.TextBox> and <xref:System.Windows.Controls.RichTextBox>.

|Control|Real-time Spellchecking|Context Menu|Formatting commands like <xref:System.Windows.Documents.EditingCommands.ToggleBold%2A> (Ctr+B)|<xref:System.Windows.Documents.FlowDocument> content like images, paragraphs, tables, and others|
|-------------|------------------------------|------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|<xref:System.Windows.Controls.TextBox>|Yes|Yes|No|No.|
|<xref:System.Windows.Controls.RichTextBox>|Yes|Yes|Yes (see [RichTextBox Overview](richtextbox.md))|Yes (see [RichTextBox Overview](richtextbox.md))|

> [!NOTE]
> Although <xref:System.Windows.Controls.TextBox> doesn't support formatting related editing commands like <xref:System.Windows.Documents.EditingCommands.ToggleBold%2A> (Ctr+B), many basic commands are supported by both controls such as <xref:System.Windows.Documents.EditingCommands.MoveToLineEnd%2A>. For more information, see <xref:System.Windows.Documents.EditingCommands>.

Features supported by <xref:System.Windows.Controls.TextBox> are covered in the sections below. For more information about <xref:System.Windows.Controls.RichTextBox>, see [RichTextBox Overview](richtextbox.md).

### Real-time spellchecking

You can enable real-time spellchecking in a <xref:System.Windows.Controls.TextBox> or <xref:System.Windows.Controls.RichTextBox>. When spellchecking is turned on, a red line appears underneath any misspelled words (see the following picture).

:::image type="content" source="./media/editing-textbox-with-spellchecking.png" alt-text="Screenshot of a TextBox control with spell checking enabled, showing a red underline beneath a misspelled word.":::

To learn how to enable spellchecking, see [Enable Spell Checking in a Text Editing Control](how-to-enable-spell-checking-in-a-text-editing-control.md).

### Context menu

By default, both <xref:System.Windows.Controls.TextBox> and <xref:System.Windows.Controls.RichTextBox> have a context menu that appears when a user right-clicks inside the control. The context menu allows the user to cut, copy, or paste (see the following picture).

:::image type="content" source="./media/editing-textbox-with-context-menu.png" alt-text="Screenshot of a TextBox control displaying a context menu with cut, copy, and paste options.":::

You can create your own custom context menu to override the default behavior. For more information, see [Use a Custom Context Menu with a TextBox](how-to-use-a-custom-context-menu-with-a-textbox.md).

## Creating TextBoxes

A <xref:System.Windows.Controls.TextBox> can be a single line in height or comprise multiple lines. A single line <xref:System.Windows.Controls.TextBox> is best for inputting small amounts of plain text (for example, "Name", "Phone Number", and other information in a form). The following example shows how to create a single line <xref:System.Windows.Controls.TextBox>.

[!code-xaml[TextBoxMiscSnippets_snip#BasicTextBoxExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/csharp/basictextboxexample.xaml#basictextboxexamplewholepage)]

You can also create a <xref:System.Windows.Controls.TextBox> that allows the user to enter multiple lines of text. For example, if your form asked for a biographical sketch of the user, you would want to use a <xref:System.Windows.Controls.TextBox> that supports multiple lines of text. The following example shows how to use Extensible Application Markup Language (XAML) to define a <xref:System.Windows.Controls.TextBox> control that automatically expands to accommodate multiple lines of text.

[!code-xaml[TextBox_MiscCode#_MultilineTextBoxXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml#_multilinetextboxxaml)]

Setting the <xref:System.Windows.Controls.TextBox.TextWrapping%2A> attribute to `Wrap` causes text to wrap to a new line when the edge of the <xref:System.Windows.Controls.TextBox> control is reached, automatically expanding the <xref:System.Windows.Controls.TextBox> control to include room for a new line, if necessary.

Setting the <xref:System.Windows.Controls.Primitives.TextBoxBase.AcceptsReturn%2A> attribute to `true` causes a new line to be inserted when the RETURN key is pressed, once again automatically expanding the <xref:System.Windows.Controls.TextBox> to include room for a new line, if necessary.

The <xref:System.Windows.Controls.Primitives.TextBoxBase.VerticalScrollBarVisibility%2A> attribute adds a scroll bar to the <xref:System.Windows.Controls.TextBox>, so that the contents of the <xref:System.Windows.Controls.TextBox> can be scrolled through if the <xref:System.Windows.Controls.TextBox> expands beyond the size of the frame or window that encloses it.

For more information on different tasks associated with using a <xref:System.Windows.Controls.TextBox>, see the how-to topics listed at the top of this article.

## Detect when content changes

Usually the <xref:System.Windows.Controls.Primitives.TextBoxBase.TextChanged> event should be used to detect whenever the text in a <xref:System.Windows.Controls.TextBox> or <xref:System.Windows.Controls.RichTextBox> changes, rather than <xref:System.Windows.UIElement.KeyDown> as you might expect. For an example, see [Detect When Text in a TextBox Has Changed](how-to-detect-when-text-in-a-textbox-has-changed.md).

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.TextBox> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.TextBox> control uses the <xref:System.Windows.Controls.TextBox.Text> property to display the text content.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.TextBox> control.

| Part | Type | Description |
|------|------|-------------|
| PART_ContentHost | <xref:System.Windows.FrameworkElement> | The framework element that hosts the text content. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.TextBox> control.

| VisualState Name | VisualStateGroup Name | Description |
|------------------|----------------------|-------------|
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
| MouseOver | CommonStates | The mouse is over the control. |
| Normal | CommonStates | The control is in its normal state. |
| ReadOnly | CommonStates | The control is in read-only mode. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |

## See also

- <xref:System.Windows.Controls.PasswordBox>
- <xref:System.Windows.Controls.RichTextBox>
- <xref:System.Windows.Controls.TextBlock>
- <xref:System.Windows.Controls.TextBox>
- <xref:System.Windows.Documents.EditingCommands>
- [RichTextBox Overview](richtextbox.md)
- [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating)
- [WPF Controls Gallery Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Getting%20Started/ControlsAndLayout)
