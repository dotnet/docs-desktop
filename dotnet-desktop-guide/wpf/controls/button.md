---
title: "Button"
description: Learn about the Button control in this article, which reacts to user input from a mouse, keyboard, stylus, or other input device.
ms.date: 10/29/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "controls [WPF], Button"
  - "Button control [WPF]"
---
# Button

A <xref:System.Windows.Controls.Button> control reacts to user input from a mouse, keyboard, stylus, or other input device and raises a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event. A <xref:System.Windows.Controls.Button> is a basic UI component that can contain simple content such as text, and can also contain complex content such as images and <xref:System.Windows.Controls.Panel> controls.

:::image type="content" source="./media/ss-ctl-buttons.png" alt-text="Button control showing different states default, focused, and pressed":::

| Title | Description |
|-------|-------------|
| [Create a Button That Has an Image](how-to-create-a-button-that-has-an-image.md) | Learn how to add an image to a Button control. |

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information about modifying a control's template, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The content property for the Button control is `Content`. This property specifies the content displayed by the button, which can be simple text or complex UI elements.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Button> control.

| VisualState name | VisualStateGroup name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| MouseOver | CommonStates | The mouse pointer is positioned over the control. |
| Pressed | CommonStates | The control is pressed. |
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## See also

- <xref:System.Windows.Controls.Button>
- <xref:System.Windows.Controls.Primitives.ButtonBase>
- <xref:System.Windows.Controls.Primitives.RepeatButton>
- <xref:System.Windows.Controls.RadioButton>
