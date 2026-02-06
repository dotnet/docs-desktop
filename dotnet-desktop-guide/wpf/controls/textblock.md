---
title: "TextBlock"
description: Learn how to use the TextBlock control to provide flexible text support for UI scenarios that don't require more than one paragraph of text.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "controls [WPF], TextBlock"
  - "TextBlock control [WPF]"
ms.assetid: ea5f7826-7a92-4de9-9eee-10ef700ce7b6
---
# TextBlock

The <xref:System.Windows.Controls.TextBlock> control provides flexible text support for WPF applications. Target this element primarily for basic UI scenarios that don't require more than one paragraph of text. It supports properties that enable precise control of presentation, such as <xref:System.Windows.Controls.TextBlock.FontFamily%2A>, <xref:System.Windows.Controls.TextBlock.FontSize%2A>, <xref:System.Windows.Controls.TextBlock.FontWeight%2A>, <xref:System.Windows.Controls.TextBlock.TextEffects%2A>, and <xref:System.Windows.Controls.TextBlock.TextWrapping%2A>. Add text content using the <xref:System.Windows.Controls.TextBlock.Text%2A> property. When you use it in XAML, content between the open and closing tag becomes the text of the element.

:::image type="content" source="./media/shared/textblock.png" alt-text="Screenshot of a WPF app demonstrating differnece TextBlock styles.":::

## Set text content

Set text content in a `TextBlock` using two approaches:

- **Text property**: For simple, uniformly formatted text, use the <xref:System.Windows.Controls.TextBlock.Text%2A> property. This approach is straightforward and applies the same formatting to all text.

  :::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="SimpleText":::

- **Inlines property**: For text with mixed formatting, use the <xref:System.Windows.Controls.TextBlock.Inlines%2A> property. This collection holds inline elements that let you apply different formatting to different parts of the text.

  :::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="InlineFormatting":::

## Inline elements and formatting

The <xref:System.Windows.Controls.TextBlock.Inlines%2A> property accepts a collection of <xref:System.Windows.Documents.Inline> elements that enable rich text formatting within a single `TextBlock`. Common inline elements include:

- <xref:System.Windows.Documents.Run>: Represents a run of unformatted or uniformly formatted text.
- <xref:System.Windows.Documents.Span>: Groups other inline elements and applies formatting to all contained elements.
- <xref:System.Windows.Documents.Bold>: Applies bold formatting to contained text.
- <xref:System.Windows.Documents.Italic>: Applies italic formatting to contained text.
- <xref:System.Windows.Documents.Underline>: Applies underline formatting to contained text.
- <xref:System.Windows.Documents.Hyperlink>: Creates clickable hyperlinks within the text.
- <xref:System.Windows.Documents.LineBreak>: Inserts a line break.

This example demonstrates using inline elements:

:::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="ComplexInline":::

You can also manipulate the `Inlines` collection programmatically to build formatted text dynamically:

:::code language="csharp" source="./snippets/textblock/csharp/MainWindow.xaml.cs" id="InlineCode":::

:::code language="vb" source="./snippets/textblock/vb/MainWindow.xaml.vb" id="InlineCode":::

## Text wrapping

The <xref:System.Windows.Controls.TextBlock.TextWrapping%2A> property controls how text behaves when it reaches the edge of the `TextBlock`. Set it to one of the <xref:System.Windows.TextWrapping> enumeration values:

- **`NoWrap`**: Text doesn't wrap and extends beyond the TextBlock if necessary.
- **`Wrap`**: Text wraps to the next line when it reaches the edge.
- **`WrapWithOverflow`**: Text wraps if possible, but if a single word is too long, it extends beyond the boundary.

:::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="TextWrapping":::

Text wrapping is particularly useful for responsive layouts and when displaying dynamic content where the text length is unknown.

## Typography and OpenType features

WPF TextBlock supports advanced OpenType typography features through the <xref:System.Windows.Documents.Typography> class. These features enable fine-grained control over text rendering, including:

- Ligatures (combining characters like "fi" into a single glyph)
- Kerning (adjusting spacing between specific character pairs)
- Stylistic alternates
- Small caps
- Swashes and ornamental characters

Access typography features through attached properties:

:::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="Typography":::

To set typography features in code, use the static methods on the `Typography` class:

:::code language="csharp" source="./snippets/textblock/csharp/MainWindow.xaml.cs" id="TypographyCode":::

:::code language="vb" source="./snippets/textblock/vb/MainWindow.xaml.vb" id="TypographyCode":::

For more information about typography features, see [Typography in WPF](../advanced/typography-in-wpf.md).

## Hyperlinks

Add clickable hyperlinks within a `TextBlock` using the <xref:System.Windows.Documents.Hyperlink> element. Hyperlinks support navigation to URIs and can respond to click events.

:::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="Hyperlink":::

Handle hyperlink navigation events to control behavior:

:::code language="xaml" source="./snippets/textblock/csharp/MainWindow.xaml" id="HyperlinkEvent":::

In the code-behind, handle the `RequestNavigate` event to open the link in the default browser:

:::code language="csharp" source="./snippets/textblock/csharp/MainWindow.xaml.cs" id="HyperlinkHandler":::

:::code language="vb" source="./snippets/textblock/vb/MainWindow.xaml.vb" id="HyperlinkHandler":::

## TextBlock vs RichTextBox

While `TextBlock` is ideal for displaying read-only text with formatting, consider using <xref:System.Windows.Controls.RichTextBox> when you need:

- Multiple paragraphs with different formatting
- User editing capabilities
- Text indentation
- More complex document structures

`TextBlock` provides better performance and a simpler programming model, making it the preferred choice for most UI text display scenarios.

## Reference

<xref:System.Windows.Controls.Label>

## Related Sections

[Documents in WPF](../advanced/documents-in-wpf.md)

[Flow Document Overview](../advanced/flow-document-overview.md)
