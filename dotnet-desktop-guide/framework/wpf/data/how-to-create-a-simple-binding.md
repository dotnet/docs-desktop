---
title: "How to create a data binding"
description: Create a simple binding for your applications through this how-to example in Windows Presentation Foundation (WPF).
ms.date: 07/24/2024
helpviewer_keywords: 
  - "simple binding [WPF], creating"
  - "data binding [WPF], creating simple bindings"
  - "binding data [WPF], creating"
ms.assetid: 69b80f72-6259-44cb-8294-5bdcebca1e08
#customer intent: As a devleoper, I want to create a binding so that I can present information in a UI
---

# How to create a data binding

This article describes how to create a binding XAML. The example uses a data object that represents an employee at a company. This data object is bound to a XAML window that uses `TextBlock` controls to list the employee's details.

To learn more about data binding, see [Data binding overview in WPF](data-binding-overview.md). To learn more about data binding, see [Data binding overview in WPF](data-binding-overview.md).

:::image type="content" source="media/how-to-create-a-simple-binding/preview.png" alt-text="A WPF window that shows details about an employee, such as their first name, last name, title, hire date, and salary.":::

## Create a data object

In this example, an employee is used as the data object that the UI is bound to.

1.  Add a new class to your project and name it `Employee`.
1.  Replace the code with the following snippet:

    :::code language="csharp" source="./snippets/how-to-create-a-simple-binding/csharp/Employee.cs":::

The employee data object is a simple class that describes an employee:

- First and last name.
- Hire date.
- Title.
- Monthly income.

## Bind to a data object

The following XAML demonstrates using the `Employee` class as a data object. The root element's `DataContext` property is bound to a static resource declared in the XAML. The individual controls are bound to the properties of the `Employee`.

1.  Add a new **Window** to the project and name it `EmployeeView`
1.  Replace the XAML with the following snippet:

    > [!IMPORTANT]
    > The following snippet is taken from a C# project. If you're using Visual Basic, the `x:Class` should be declared without the `ArticleSample` namespace. You can see what the Visual Basic version looks like [here]().
    
    :::code language="xaml" source="./snippets/how-to-create-a-simple-binding/csharp/EmployeeView.xaml" highlight="7-9,33-37,43":::
    
The namespace of the code won't match your project's namespace, unless you created a project named **ArticleSample**. You can copy and paste the `Window.Resources` and root element (`StackPanel`) into you're **MainWindow** if you created a new project.

Here are some important aspects about the XAML code:

- A XAML resource is used to create an instance of the `Employee` class.

  Typically the data object is passed to or associated with the Window. This example hardcodes the employee for demonstration purposes.

  :::code language="xaml" source="./snippets/how-to-create-a-simple-binding/csharp/EmployeeView.xaml" range="6-10":::

- The root element (`StackPanel`) has its data context set to the hardcoded `Employee` instance.

  The child elements inherit their `DataContext` from the parent, unless explicitly set.

  :::code language="xaml" source="./snippets/how-to-create-a-simple-binding/csharp/EmployeeView.xaml" range="11":::

- The properties of the `Employee` instance are bound to the `TextBlock` controls.

  The `Binding` doesn't specify a `BindingSource`, so the `DataContext` is used as the source.

  :::code language="xaml" source="./snippets/how-to-create-a-simple-binding/csharp/EmployeeView.xaml" range="33-37":::

- A `TextBox` control is bound with `TwoWay` mode, allowing the `TextBox` to change the `Employee.Salary` property.

  :::code language="xaml" source="./snippets/how-to-create-a-simple-binding/csharp/EmployeeView.xaml" range="43":::

## Related content

- [Data Binding Overview](data-binding-overview.md)
- [How to: Create a Binding in Code](how-to-create-a-binding-in-code.md)
- [How-to Topics](data-binding-how-to-topics.md)
