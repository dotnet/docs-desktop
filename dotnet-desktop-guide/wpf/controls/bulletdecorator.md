---
title: "BulletDecorator"
description: Learn about BulletDecorator in this article, including BulletDecorator's two content properties, Bullet and Child.
ms.date: 10/29/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
- "controls [WPF], BulletDecorator"
- "BulletDecorator control [WPF]"
ai-usage: ai-assisted
---

# BulletDecorator

The <xref:System.Windows.Controls.Primitives.BulletDecorator> control provides a way to align a bullet with content. It's a decorator control that arranges a bullet element alongside child content, creating a layout commonly used in lists, checkboxes, and radio buttons.

:::image type="content" source="./media/bulletdecorator/three-bullet-decorators.png" alt-text="Examples of CheckBox, RadioButton, and TextBox controls that use BulletDecorator for bullet alignment":::

## Styles and templates

The <xref:System.Windows.Controls.Primitives.BulletDecorator> control has the following styling characteristics:

### Content property

The <xref:System.Windows.Controls.Decorator.Child%2A> property serves as the content property for this control. This property defines the <xref:System.Windows.UIElement> that visually aligns with the bullet.

### Parts

This control doesn't define any template parts.

### Visual states

This control doesn't use visual states.

## Key concepts

The <xref:System.Windows.Controls.Primitives.BulletDecorator> has two main content properties:

- <xref:System.Windows.Controls.Primitives.BulletDecorator.Bullet%2A>: Defines the <xref:System.Windows.UIElement> to use as a bullet.
- <xref:System.Windows.Controls.Decorator.Child%2A>: Defines a <xref:System.Windows.UIElement> that visually aligns with the bullet.

The control automatically handles the layout and alignment between the bullet and child content, ensuring proper spacing and positioning.

## Examples

The following example shows how to create a simple <xref:System.Windows.Controls.Primitives.BulletDecorator> with a checkbox bullet and text content:

:::code language="xaml" source="./snippets/bulletdecorator/net/csharp/BulletDecoratorExamples/MainWindow.xaml" id="CheckBoxBullet":::

You can also use other elements as bullets:

:::code language="xaml" source="./snippets/bulletdecorator/net/csharp/BulletDecoratorExamples/MainWindow.xaml" id="CustomBullet":::

## See also

- <xref:System.Windows.Controls.Primitives.BulletDecorator>
