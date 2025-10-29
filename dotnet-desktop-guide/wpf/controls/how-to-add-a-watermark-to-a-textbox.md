---
title: "Add a placeholder to a TextBox"
description: Learn how to add a placeholder to a TextBox via the included code examples in XAML, C#, and Visual Basic.
ms.date: 03/13/2025
ms.service: dotnet-framework
ms.update-cycle: 1825-days
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: df89bdd8-a0fb-45e0-b312-dd53332d01a8

#customer intent: As a developer, I want to modify the TextBox control to display information that helps a user understand what type of input is required.

---
# Add a placeholder to a TextBox

The following example shows how to display placeholder text in a <xref:System.Windows.Controls.TextBox> when the `TextBox` is empty. When the `TextBox` has text, the placeholder text is hidden. Placeholder text help users understand what type of input the `TextBox` expects.

:::image type="content" source="./media/how-to-add-a-watermark-to-a-textbox/placeholder-example.png" alt-text="An example app with two TextBox controls that have placeholders in them. The first Textbox provides an example of a name and the second an example of an email.":::

In this article you learn how to:

- Create an attached property to provide the placeholder text.
- Create an adorner to display the placeholder text.
- Add the attached property to a <xref:System.Windows.Controls.TextBox> control.

## Create an attached property

With attached properties, you can append values to a control. You use this feature a lot in WPF, such as when you set `Grid.Row` or `Panel.ZIndex` properties on a control. For more information, see [Attached Properties Overview](../properties/attached-properties-overview.md). This example uses attached properties to add placeholder text to a <xref:System.Windows.Controls.TextBox>.

01. Add a new class to your project named `TextBoxHelper` and open it.
01. Add the following namespaces:

    :::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="Namespaces":::
    :::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="Namespaces":::

01. Create a new dependency property named `Placeholder`.

    This dependency property uses the property changed callback delegate.

    :::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="AttachedProperty":::
    :::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="AttachedProperty":::

01. Create the `OnPlaceholderChanged` method to integrate the attached property with a `TextBox`.

    :::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="OnPlaceholderChanged":::
    :::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="OnPlaceholderChanged":::

    There are two ways this method is called when the attached property value changes:

    - When the attached property is first added to a `TextBox`, this method is called. That action provides an opportunity for the attached property to integrate with the control's events.
    - Whenever this property is changed, the adorner can be invalidated to refresh the visual placeholder text.

    The `GetOrCreateAdorner` method is created in the next section.

01. Create the event handlers for the `TextBox`.

    :::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="EventHandlers":::
    :::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="EventHandlers":::

    The <xref:System.Windows.FrameworkElement.Loaded> event is handled so that the adorner can be created after the control's template is applied. The handler removes itself after the event is raised and the adorner is created.

    The <xref:System.Windows.Controls.Primitives.TextBoxBase.TextChanged> event is handled to ensure that the adorner is hidden or displayed depending if the <xref:System.Windows.Controls.TextBox.Text> is set to a value.

## Create an adorner

The <xref:System.Windows.Documents.Adorner> is a visual that's bound to a control and rendered in an <xref:System.Windows.Documents.AdornerLayer>. For more information, see [Adorners](adorners.md).

01. Open the `TextBoxHelper` class.
01. Add the following code to create the `GetOrCreateAdorner` method.

    :::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="GetOrCreateAdorner":::
    :::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="GetOrCreateAdorner":::

    This method provides a safe way to either add or retrieve the <xref:System.Windows.Documents.Adorner>. Adorners require extra safety because they're added to the control's <xref:System.Windows.Documents.AdornerLayer>, which might not exist. When a XAML attached property is applied to a control, the control's template hasn't yet been applied to create the visual tree, so the adorner layer doesn't exist. The adorner layer must be retrieved after the control is loaded. The adorner layer might also be missing if a template that omits the adorner layer is applied to the control.

01. Add a child class named `PlaceholderAdorner` to the `TextBoxHelper` class.

    :::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="Adorner":::
    :::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="Adorner":::

    An adorner inherits from the <xref:System.Windows.Documents.Adorner> class. This particular adorner overrides the <xref:System.Windows.UIElement.OnRender(System.Windows.Media.DrawingContext)> method to draw the placeholder text. Let's breakdown the code:

    - First, check that the placeholder text exists by calling `TextBoxHelper.GetPlaceholder(textBoxControl)`.
    - Create a <xref:System.Windows.Media.FormattedText> object. This object contains all of the information about what text is drawn on the visual.
    - Both the <xref:System.Windows.Media.FormattedText.MaxTextWidth?displayProperty=nameWithType> and <xref:System.Windows.Media.FormattedText.MaxTextHeight?displayProperty=nameWithType> properties are set to the region of the control. They're also set a minimum value of 10 to make sure the `FormattedText` object is valid.
    - The `renderingOffset` stores the position of the drawn text.
    - Use the `PART_ContentHost` If the control's template declares it. This part represents where the text is drawn on the control's template. If that part is found, modify the `renderingOffset` to account for its position.
    - Draw the text by calling <xref:System.Windows.Media.DrawingContext.DrawText(System.Windows.Media.FormattedText,System.Windows.Point)> and passing the `FormattedText` object and the position of the text.

## Apply the attached property

Once the attached property is defined, its namespace needs to be imported into the XAML, and then referenced on a <xref:System.Windows.Controls.TextBox> control. The following code maps the .NET namespace `DotnetDocsSample` to the XML namespace `l`.

:::code language="xaml" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/MainWindow.xaml" highlight="4,10,13":::

The attached property is added to a `TextBox` using the syntax `xmlNamespace:Class.Property`.

## Complete example

The following code is the complete `TextBoxHelper` class.

:::code language="csharp" source="./snippets/how-to-add-a-watermark-to-a-textbox/csharp/TextBoxHelper.cs" id="FullClass":::
:::code language="vb" source="./snippets/how-to-add-a-watermark-to-a-textbox/vb/TextBoxHelper.vb" id="FullClass":::

## See also

- [TextBox Overview](textbox-overview.md)
- [Adorners](adorners.md)
- [Attached Properties Overview](../properties/attached-properties-overview.md)
