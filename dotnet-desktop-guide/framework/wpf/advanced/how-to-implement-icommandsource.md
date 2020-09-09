---
title: "How to: Implement ICommandSource"
ms.date: "12/05/2019"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ICommandSource interfaces [WPF], implementing"
ms.assetid: 7452dd39-6e11-44bf-806a-31d87f3772ac
---
# How to: Implement ICommandSource

This example shows how to create a command source by implementing <xref:System.Windows.Input.ICommandSource>. A command source is an object that knows how to invoke a command. The <xref:System.Windows.Input.ICommandSource> interface exposes three members:

- <xref:System.Windows.Input.ICommandSource.Command%2A>: the command that will be invoked.
- <xref:System.Windows.Input.ICommandSource.CommandParameter%2A>: a user-defined data type which is passed from the command source to the method that handles the command.
- <xref:System.Windows.Input.ICommandSource.CommandTarget%2A>: the object that the command is being executed on.

In this example, a class is created that inherits from the <xref:System.Windows.Controls.Slider> control and implements the  <xref:System.Windows.Input.ICommandSource> interface.
  
## Example

WPF provides a number of classes which implement <xref:System.Windows.Input.ICommandSource>, such as <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.MenuItem>, and <xref:System.Windows.Documents.Hyperlink>. A command source defines how it invokes a command. These classes invoke a command when they're clicked and they only become a command source when their <xref:System.Windows.Input.ICommandSource.Command%2A> property is set.

In this example, you'll invoke the command when the slider is moved, or more accurately, when the <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> property is changed.

The following is the class definition:

[!code-csharp[ImplementICommandSource#ImplementICommandSourceClassDefinition](~/samples/snippets/csharp/VS_Snippets_Wpf/ImplementICommandSource/CSharp/CommandSlider.cs#implementicommandsourceclassdefinition)]
[!code-vb[ImplementICommandSource#ImplementICommandSourceClassDefinition](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImplementICommandSource/visualbasic/commandslider.vb#implementicommandsourceclassdefinition)]

The next step is to implement the <xref:System.Windows.Input.ICommandSource> members. In this example, the properties are implemented as <xref:System.Windows.DependencyProperty> objects. This enables the properties to use data binding. For more information about the <xref:System.Windows.DependencyProperty> class, see the [Dependency Properties Overview](dependency-properties-overview.md). For more information about data binding, see the [Data Binding Overview](/dotnet/desktop-wpf/data/data-binding-overview).

Only the <xref:System.Windows.Input.ICommandSource.Command%2A> property is shown here.

[!code-csharp[ImplementICommandSource#ImplementICommandSourceCommandPropertyDefinition](~/samples/snippets/csharp/VS_Snippets_Wpf/ImplementICommandSource/CSharp/CommandSlider.cs#implementicommandsourcecommandpropertydefinition)]
[!code-vb[ImplementICommandSource#ImplementICommandSourceCommandPropertyDefinition](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImplementICommandSource/visualbasic/commandslider.vb#implementicommandsourcecommandpropertydefinition)]  
  
The following is the <xref:System.Windows.DependencyProperty> change callback:

[!code-csharp[ImplementICommandSource#ImplementICommandSourceCommandChanged](~/samples/snippets/csharp/VS_Snippets_Wpf/ImplementICommandSource/CSharp/CommandSlider.cs#implementicommandsourcecommandchanged)]
[!code-vb[ImplementICommandSource#ImplementICommandSourceCommandChanged](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImplementICommandSource/visualbasic/commandslider.vb#implementicommandsourcecommandchanged)]

The next step is to add and remove the command which is associated with the command source. The <xref:System.Windows.Input.ICommandSource.Command%2A> property cannot simply be overwritten when a new command is added, because the event handlers associated with the previous command, if there was one, must be removed first.

[!code-csharp[ImplementICommandSource#ImplementICommandSourceHookUnHookCommands](~/samples/snippets/csharp/VS_Snippets_Wpf/ImplementICommandSource/CSharp/CommandSlider.cs#implementicommandsourcehookunhookcommands)]
[!code-vb[ImplementICommandSource#ImplementICommandSourceHookUnHookCommands](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImplementICommandSource/visualbasic/commandslider.vb#implementicommandsourcehookunhookcommands)]

The next step is to create logic for the <xref:System.Windows.Input.ICommand.CanExecuteChanged> handler.

The <xref:System.Windows.Input.ICommand.CanExecuteChanged> event notifies the command source that the ability of the command to execute on the current command target may have changed. When a command source receives this event, it typically calls the <xref:System.Windows.Input.ICommand.CanExecute%2A> method on the command. If the command cannot execute on the current command target, the command source will typically disable itself. If the command can execute on the current command target, the command source will typically enable itself.

[!code-csharp[ImplementICommandSource#ImplementICommandCanExecuteChanged](~/samples/snippets/csharp/VS_Snippets_Wpf/ImplementICommandSource/CSharp/CommandSlider.cs#implementicommandcanexecutechanged)]
[!code-vb[ImplementICommandSource#ImplementICommandCanExecuteChanged](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImplementICommandSource/visualbasic/commandslider.vb#implementicommandcanexecutechanged)]

The last step is the <xref:System.Windows.Input.ICommand.Execute%2A> method. If the command is a <xref:System.Windows.Input.RoutedCommand>, the <xref:System.Windows.Input.RoutedCommand> <xref:System.Windows.Input.RoutedCommand.Execute%2A> method is called; otherwise, the <xref:System.Windows.Input.ICommand> <xref:System.Windows.Input.ICommand.Execute%2A> method is called.

[!code-csharp[ImplementICommandSource#ImplementICommandExecute](~/samples/snippets/csharp/VS_Snippets_Wpf/ImplementICommandSource/CSharp/CommandSlider.cs#implementicommandexecute)]
[!code-vb[ImplementICommandSource#ImplementICommandExecute](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImplementICommandSource/visualbasic/commandslider.vb#implementicommandexecute)]

## See also

- <xref:System.Windows.Input.ICommandSource>
- <xref:System.Windows.Input.ICommand>
- <xref:System.Windows.Input.RoutedCommand>
- [Commanding Overview](commanding-overview.md)
