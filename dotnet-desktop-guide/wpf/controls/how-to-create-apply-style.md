---
title: How to create a style for a control
description: Learn how to create and reference a control style in Windows Presentation Foundation and .NET. Control styles can be implemented through resource dictionaries.
author: adegeo
ms.author: adegeo
ms.date: 03/20/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: how-to
ms.custom: update-template
dev_langs:
  - "csharp"
  - "vb"
#no-loc: [TextBlock, Setter]
---

# How to create a style for a control

By using Windows Presentation Foundation (WPF), you can customize an existing control's appearance by creating your own reusable style. You can apply styles globally to your app, windows, and pages, or directly to controls.

## Create a style

Think of a <xref:System.Windows.Style> as a convenient way to apply a set of property values to one or more elements. You can use a style on any element that derives from <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>, such as a <xref:System.Windows.Window> or a <xref:System.Windows.Controls.Button>.

The most common way to declare a style is as a resource in the `Resources` section of a XAML file. Because styles are resources, they follow the same scoping rules as all resources. Where you declare a style affects where you can apply it. For example, if you declare the style in the root element of your app definition XAML file, you can use the style anywhere in your app.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/App.xaml" id="AppResources":::

If you declare the style in one of the app's XAML files, you can use the style only in that XAML file. For more information about scoping rules for resources, see [Overview of XAML resources](../systems/xaml-resources-overview.md).

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/WindowSingleResource.xaml" id="WindowResources":::

A style consists of `<Setter>` child elements that set properties on the elements the style applies to. In the preceding example, the style applies to `TextBlock` types through the `TargetType` attribute. The style sets the <xref:System.Windows.Controls.Control.FontSize%2A> to `15` and the <xref:System.Windows.Controls.Control.FontWeight%2A> to `ExtraBold`. Add a `<Setter>` for each property the style changes.

## Apply a style implicitly

A <xref:System.Windows.Style> is a convenient way to apply a set of property values to more than one element. For example, consider the following <xref:System.Windows.Controls.TextBlock> elements and their default appearance in a window.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/Window1.xaml" id="SnippetTextBlocks":::

:::image type="content" source="./media/how-to-create-apply-style/stylingintro-textblocksbefore.png" alt-text="Styling sample screenshot before":::

You can change the default appearance by setting properties, such as <xref:System.Windows.Controls.Control.FontSize%2A> and <xref:System.Windows.Controls.Control.FontFamily%2A>, on each <xref:System.Windows.Controls.TextBlock> element directly. However, if you want your <xref:System.Windows.Controls.TextBlock> elements to share some properties, you can create a <xref:System.Windows.Style> in the `Resources` section of your XAML file, as shown here.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/Window1.xaml" id="SnippetDefaultTextBlockStyle":::

When you set the <xref:System.Windows.Style.TargetType%2A> of your style to the <xref:System.Windows.Controls.TextBlock> type and omit the `x:Key` attribute, the style applies to all the <xref:System.Windows.Controls.TextBlock> elements scoped to the style, which is generally the XAML file itself.

Now the <xref:System.Windows.Controls.TextBlock> elements appear as follows.

:::image type="content" source="./media/how-to-create-apply-style/stylingintro-textblocksbasestyle.png" alt-text="Styling sample screenshot base style":::

## Apply a style explicitly

If you add an `x:Key` attribute with a value to the style, the style no longer implicitly applies to all elements of <xref:System.Windows.Style.TargetType%2A>. Only elements that explicitly reference the style receive it.

Here's the style from the previous section, but declared with the `x:Key` attribute.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/WindowExplicitStyle.xaml" id="ExplicitStyleDeclare":::

To apply the style, set the <xref:System.Windows.FrameworkElement.Style%2A> property on the element to the `x:Key` value by using a [StaticResource markup extension](../advanced/staticresource-markup-extension.md), as shown here.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/WindowExplicitStyle.xaml" id="ExplicitStyleReference":::

Notice that the first <xref:System.Windows.Controls.TextBlock> element has the style applied to it while the second TextBlock element remains unchanged. The implicit style from the previous section changed to a style that declared the `x:Key` attribute. The style affects only elements that reference it directly.

:::image type="content" source="./media/how-to-create-apply-style/create-a-style-explicit-textblock.png" alt-text="Styling sample screenshot textblock":::

Once you apply a style explicitly or implicitly, it becomes sealed and can't be changed. If you want to change a style, create a new style to replace the existing one. For more information, see the <xref:System.Windows.Style.IsSealed%2A> property.

You can create an object that chooses a style to apply based on custom logic. For an example, see the example provided for the <xref:System.Windows.Controls.StyleSelector> class.

## Apply a style programmatically

To assign a named style to an element programmatically, get the style from the resources collection and assign it to the element's <xref:System.Windows.FrameworkElement.Style%2A> property. The items in a resources collection are of type <xref:System.Object>. Therefore, you must cast the retrieved style to a <xref:System.Windows.Style?displayProperty=fullName> before assigning it to the `Style` property. For example, the following code sets the style of a `TextBlock` named `textblock1` to the defined style `TitleText`.

:::code language="csharp" source="./snippets/how-to-create-apply-style/csharp/Window2.xaml.cs" id="SnippetSetStyleCode":::
:::code language="vb" source="./snippets/how-to-create-apply-style/vb/MainWindow.xaml.vb" id="SnippetSetStyleCode":::

## Extend a style

You might want your two <xref:System.Windows.Controls.TextBlock> elements to share some property values, such as the <xref:System.Windows.Controls.Control.FontFamily%2A> and the centered <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A>. But you also want the text **My Pictures** to have some additional properties. You can do that by creating a new style that's based on the first style, as shown in the following example.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/Window2.xaml" id="SnippetDefaultTextBlockStyleBasedOn":::

Then, apply the style to a `TextBlock`.

:::code language="xaml" source="./snippets/how-to-create-apply-style/csharp/Window2.xaml" id="SnippetTextBlocksExplicit":::

This `TextBlock` style is now centered, uses a `Comic Sans MS` font with a size of `26`, and sets the foreground color to the <xref:System.Windows.Media.LinearGradientBrush> shown in the example. It overrides the <xref:System.Windows.Controls.Control.FontSize%2A> value of the base style. If there's more than one <xref:System.Windows.Setter> pointing to the same property in a <xref:System.Windows.Style>, the `Setter` that is declared last takes precedence.

The following image shows what the <xref:System.Windows.Controls.TextBlock> elements look like now:

:::image type="content" source="./media/how-to-create-apply-style/stylingintro-textblocks.png" alt-text="Styled TextBlocks":::

This `TitleText` style extends the style that you created for the <xref:System.Windows.Controls.TextBlock> type, referenced by using `BasedOn="{StaticResource {x:Type TextBlock}}"`. You can also extend a style that has an `x:Key` by using the `x:Key` of the style. For example, if there was a style named `Header1` and you wanted to extend that style, you would use `BasedOn="{StaticResource Header1}"`.

## Relationship of the TargetType property and the x:Key attribute

As shown earlier, setting the <xref:System.Windows.Style.TargetType%2A> property to `TextBlock` without assigning the style an `x:Key` causes the style to apply to all <xref:System.Windows.Controls.TextBlock> elements. In this case, the `x:Key` is implicitly set to `{x:Type TextBlock}`. This behavior means that if you explicitly set the `x:Key` value to anything other than `{x:Type TextBlock}`, the <xref:System.Windows.Style> doesn't apply to all `TextBlock` elements automatically. Instead, you must apply the style (by using the `x:Key` value) to the `TextBlock` elements explicitly. If your style is in the resources section and you don't set the `TargetType` property on your style, then you must set the `x:Key` attribute.

In addition to providing a default value for the `x:Key`, the `TargetType` property specifies the type to which setter properties apply. If you don't specify a `TargetType`, you must qualify the properties in your <xref:System.Windows.Setter> objects by using a class name with the syntax `Property="ClassName.Property"`. For example, instead of setting `Property="FontSize"`, you must set <xref:System.Windows.Setter.Property%2A> to `"TextBlock.FontSize"` or `"Control.FontSize"`.

Also note that many WPF controls consist of a combination of other WPF controls. If you create a style that applies to all controls of a type, you might get unexpected results. For example, if you create a style that targets the <xref:System.Windows.Controls.TextBlock> type in a <xref:System.Windows.Window>, the style applies to all `TextBlock` controls in the window, even if the `TextBlock` is part of another control, such as a <xref:System.Windows.Controls.ListBox>.

## See also

- [How to create a template for a control](how-to-create-apply-template.md)
- [Overview of XAML resources](../systems/xaml-resources-overview.md)
- [XAML overview](../xaml/index.md)
