---
title: "Threading Model"
description: Learn about situations where you might need multiple threads in your Windows Presentation Foundation application. Single threaded solutions are preferred.
ms.date: 10/26/2023
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "text on buttons [WPF], updating"
  - "message processing [WPF], nested"
  - "blocking operations [WPF]"
  - "Common Language Runtime (CLR), locking mechanism"
  - "locking mechanism of Common Language Runtime (CLR)"
  - "threading model [WPF]"
  - "Word [WPF], spelling checking"
  - "button text [WPF], updating"
  - "spelling checking in Word [WPF]"
  - "asynchronous behavior [WPF], exposing"
  - "nested message processing [WPF]"
  - "reentrancy [WPF]"
ms.assetid: 02d8fd00-8d7c-4604-874c-58e40786770b
---
# Threading model

Windows Presentation Foundation (WPF) is designed to save developers from the difficulties of threading. As a result, most WPF developers don't write an interface that uses more than one thread. Because multithreaded programs are complex and difficult to debug, they should be avoided when single-threaded solutions exist.

 No matter how well architected, however, no UI framework is able to provide a single-threaded solution for every sort of problem. WPF comes close, but there are still situations where multiple threads improve user interface (UI) responsiveness or application performance. After discussing some background material, this article explores some of these situations and then concludes with a discussion of some lower-level details.

> [!NOTE]
> This topic discusses threading by using the <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A> method for asynchronous calls. The `InvokeAsync` method takes an <xref:System.Action> or <xref:System.Func%601> as a parameter, and returns a <xref:System.Windows.Threading.DispatcherOperation> or <xref:System.Windows.Threading.DispatcherOperation%601>, which has a <xref:System.Windows.Threading.DispatcherOperation.Task%2A> property. You can use the `await` keyword with either the <xref:System.Windows.Threading.DispatcherOperation> or the associated <xref:System.Threading.Tasks.Task>. If you need to wait synchronously for the <xref:System.Threading.Tasks.Task> that is returned by a <xref:System.Windows.Threading.DispatcherOperation> or <xref:System.Windows.Threading.DispatcherOperation%601>, call the <xref:System.Windows.Threading.TaskExtensions.DispatcherOperationWait%2A> extension method. Calling <xref:System.Threading.Tasks.Task.Wait%2A?displayProperty=nameWithType> will result in a **deadlock**. For more information about using a <xref:System.Threading.Tasks.Task> to perform asynchronous operations, see [Task-based asynchronous programming](/dotnet/standard/parallel-programming/task-based-asynchronous-programming).
>
> To make a synchronous call, use the <xref:System.Windows.Threading.Dispatcher.Invoke%2A> method, which also has overloads that takes a delegate, <xref:System.Action>, or <xref:System.Func%601> parameter.

<a name="threading_overview"></a>

## Overview and the dispatcher

 Typically, WPF applications start with two threads: one for handling rendering and another for managing the UI. The rendering thread effectively runs hidden in the background while the UI thread receives input, handles events, paints the screen, and runs application code. Most applications use a single UI thread, although in some situations it is best to use several. We'll discuss this with an example later.

 The UI thread queues work items inside an object called a <xref:System.Windows.Threading.Dispatcher>. The <xref:System.Windows.Threading.Dispatcher> selects work items on a priority basis and runs each one to completion.  Every UI thread must have at least one <xref:System.Windows.Threading.Dispatcher>, and each <xref:System.Windows.Threading.Dispatcher> can execute work items in exactly one thread.

 The trick to building responsive, user-friendly applications is to maximize the <xref:System.Windows.Threading.Dispatcher> throughput by keeping the work items small. This way items never get stale sitting in the <xref:System.Windows.Threading.Dispatcher> queue waiting for processing. Any perceivable delay between input and response can frustrate a user.

 How then are WPF applications supposed to handle big operations? What if your code involves a large calculation or needs to query a database on some remote server? Usually, the answer is to handle the big operation in a separate thread, leaving the UI thread free to tend to items in the <xref:System.Windows.Threading.Dispatcher> queue. When the big operation is complete, it can report its result back to the UI thread for display.

 Historically, Windows allows UI elements to be accessed only by the thread that created them. This means that a background thread in charge of some long-running task cannot update a text box when it is finished. Windows does this to ensure the integrity of UI components. A list box could look strange if its contents were updated by a background thread during painting.

 WPF has a built-in mutual exclusion mechanism that enforces this coordination. Most classes in WPF derive from <xref:System.Windows.Threading.DispatcherObject>. At construction, a <xref:System.Windows.Threading.DispatcherObject> stores a reference to the <xref:System.Windows.Threading.Dispatcher> linked to the currently running thread. In effect, the <xref:System.Windows.Threading.DispatcherObject> associates with the thread that creates it. During program execution, a <xref:System.Windows.Threading.DispatcherObject> can call its public <xref:System.Windows.Threading.DispatcherObject.VerifyAccess%2A> method. <xref:System.Windows.Threading.DispatcherObject.VerifyAccess%2A> examines the <xref:System.Windows.Threading.Dispatcher> associated with the current thread and compares it to the <xref:System.Windows.Threading.Dispatcher> reference stored during construction. If they don't match, <xref:System.Windows.Threading.DispatcherObject.VerifyAccess%2A> throws an exception. <xref:System.Windows.Threading.DispatcherObject.VerifyAccess%2A> is intended to be called at the beginning of every method belonging to a <xref:System.Windows.Threading.DispatcherObject>.

 If only one thread can modify the UI, how do background threads interact with the user? A background thread can ask the UI thread to perform an operation on its behalf. It does this by registering a work item with the <xref:System.Windows.Threading.Dispatcher> of the UI thread. The <xref:System.Windows.Threading.Dispatcher> class provides the methods for registering work items: <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A?displayProperty=nameWithType>, <xref:System.Windows.Threading.Dispatcher.BeginInvoke%2A?displayProperty=nameWithType>, and <xref:System.Windows.Threading.Dispatcher.Invoke%2A?displayProperty=nameWithType>. These methods schedule a delegate for execution. `Invoke` is a synchronous call – that is, it doesn't return until the UI thread actually finishes executing the delegate. `InvokeAsync` and `BeginInvoke` are asynchronous and return immediately.

 The <xref:System.Windows.Threading.Dispatcher> orders the elements in its queue by priority. There are ten levels that may be specified when adding an element to the <xref:System.Windows.Threading.Dispatcher> queue. These priorities are maintained in the <xref:System.Windows.Threading.DispatcherPriority> enumeration.

<a name="samples"></a>

<a name="prime_number"></a>

## Single-threaded app with a long-running calculation

 Most graphical user interfaces (GUIs) spend a large portion of their time idle while waiting for events that are generated in response to user interactions. With careful programming this idle time can be used constructively, without affecting the responsiveness of the UI. The WPF threading model doesn't allow input to interrupt an operation happening in the UI thread. This means you must be sure to return to the <xref:System.Windows.Threading.Dispatcher> periodically to process pending input events before they get stale.

 A sample app demonstrating the concepts of this section can be downloaded from GitHub for either [C#](https://github.com/dotnet/samples/tree/main/wpf/Threading/PrimeNumber/net48/csharp) or [Visual Basic](https://github.com/dotnet/samples/tree/main/wpf/Threading/PrimeNumber/net48/vb).

 Consider the following example:

 :::image type="content" source="./media/threading-model/threading-prime-numbers.png" alt-text="Screenshot that shows threading of prime numbers.":::

 This simple application counts upwards from three, searching for prime numbers. When the user clicks the **Start** button, the search begins. When the program finds a prime, it updates the user interface with its discovery. At any point, the user can stop the search.

 Although simple enough, the prime number search could go on forever, which presents some difficulties.  If we handled the entire search inside of the click event handler of the button, we would never give the UI thread a chance to handle other events. The UI would be unable to respond to input or process messages. It would never repaint and never respond to button clicks.

 We could conduct the prime number search in a separate thread, but then we would need to deal with synchronization issues. With a single-threaded approach, we can directly update the label that lists the largest prime found.

 If we break up the task of calculation into manageable chunks, we can periodically return to the <xref:System.Windows.Threading.Dispatcher> and process events. We can give WPF an opportunity to repaint and process input.

 The best way to split processing time between calculation and event handling is to manage calculation from the <xref:System.Windows.Threading.Dispatcher>. By using the <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A> method, we can schedule prime number checks in the same queue that UI events are drawn from. In our example, we schedule only a single prime number check at a time. After the prime number check is complete, we schedule the next check immediately. This check proceeds only after pending UI events have been handled.

 :::image type="content" source="./media/threading-model/threading-dispatcher-queue.png" alt-text="Screenshot that shows the dispatcher queue.":::

 Microsoft Word accomplishes spell checking using this mechanism. Spell checking is done in the background using the idle time of the UI thread. Let's take a look at the code.

 The following example shows the XAML that creates the user interface.

> [!IMPORTANT]
> The XAML shown in this article is from a C# project. Visual Basic XAML is slightly different when declaring the backing class for the XAML.

 :::code language="xaml" source="./snippets/threading-model/csharp/PrimeNumber.xaml":::

 The following example shows the code-behind.

 :::code language="csharp" source="./snippets/threading-model/csharp/PrimeNumber.xaml.cs" id="full":::
 :::code language="vb" source="./snippets/threading-model/vb/PrimeNumber.xaml.vb" id="full":::

 Besides updating the text on the <xref:System.Windows.Controls.Button>, the `StartStopButton_Click` handler is responsible for scheduling the first prime number check by adding a delegate to the <xref:System.Windows.Threading.Dispatcher> queue. Sometime after this event handler has completed its work, the <xref:System.Windows.Threading.Dispatcher> will select the delegate for execution.

 As we mentioned earlier, <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A> is the <xref:System.Windows.Threading.Dispatcher> member used to schedule a delegate for execution. In this case, we choose the <xref:System.Windows.Threading.DispatcherPriority.SystemIdle> priority. The <xref:System.Windows.Threading.Dispatcher> will execute this delegate only when there are no important events to process. UI responsiveness is more important than number checking. We also pass a new delegate representing the number-checking routine.

 :::code language="csharp" source="./snippets/threading-model/csharp/PrimeNumber.xaml.cs" id="check_number":::
 :::code language="vb" source="./snippets/threading-model/vb/PrimeNumber.xaml.vb" id="check_number":::

 This method checks if the next odd number is prime. If it is prime, the method directly updates the `bigPrime` <xref:System.Windows.Controls.TextBlock> to reflect its discovery. We can do this because the calculation is occurring in the same thread that was used to create the control. Had we chosen to use a separate thread for the calculation, we would have to use a more complicated synchronization mechanism and execute the update in the UI thread. We'll demonstrate this situation next.

<a name="multi_browser"></a>

## Multiple windows, multiple threads

Some WPF applications require multiple top-level windows. It's perfectly acceptable for one Thread/Dispatcher combination to manage multiple windows, but sometimes several threads do a better job. This is especially true if there's any chance that one of the windows will monopolize the thread.

Windows Explorer works in this fashion. Each new Explorer window belongs to the original process, but it's created under the control of an independent thread. When Explorer becomes nonresponsive, such as when looking for network resources, other Explorer windows continue to be responsive and usable.

We can demonstrate this concept with the following example.

:::image type="complex" source="./media/threading-model/threading-multiwindow-ui.png" alt-text="A screenshot of a WPF window that's duplicated four times. Three of the windows indicate that they're using the same thread, while the other two are on different threads.":::

The top three windows of this image share the same thread identifier: 1. The two other windows have different thread identifiers: Nine and 4. There's a magenta colored rotating ‼️ glyph in the top right of each window.

:::image-end:::

This example contains a window with a rotating `‼️` glyph, a **Pause** button, and two other buttons that create a new window under the current thread or in a new thread. The `‼️` glyph is constantly rotating until the **Pause** button is pressed, which pauses the thread for five seconds. At the bottom of the window, the thread identifier is displayed.

When the **Pause** button is pressed, all windows under the same thread become nonresponsive. Any window under a different thread continues to work normally.

The following example is the XAML to the window:

:::code language="xaml" source="./snippets/threading-model/csharp/MultiWindow.xaml":::

The following example shows the code-behind.

:::code language="csharp" source="./snippets/threading-model/csharp/MultiWindow.xaml.cs" id="full":::
:::code language="vb" source="./snippets/threading-model/vb/MultiWindow.xaml.vb" id="full":::

The following are some of the details to be noted:

- The <xref:System.Threading.Tasks.Task.Delay(System.TimeSpan)?displayProperty=nameWithType> task is used to cause the current thread to pause for five seconds when the **Pause** button is pressed.

  :::code language="csharp" source="./snippets/threading-model/csharp/MultiWindow.xaml.cs" id="delay":::
  :::code language="vb" source="./snippets/threading-model/vb/MultiWindow.xaml.vb" id="delay":::

- The `SameThreadWindow_Click` event handler immediently shows a new window under the current thread. The `NewThreadWindow_Click` event handler creates a new thread that starts executing the `ThreadStartingPoint` method, which in turn shows a new window, as described in the next bullet point.

  :::code language="csharp" source="./snippets/threading-model/csharp/MultiWindow.xaml.cs" id="buttons" highlight="2,6":::
  :::code language="vb" source="./snippets/threading-model/vb/MultiWindow.xaml.vb" id="buttons" highlight="2,6":::

- The `ThreadStartingPoint` method is the starting point for the new thread. The new window is created under the control of this thread. WPF automatically creates a new <xref:System.Windows.Threading.Dispatcher?displayProperty=nameWithType> to manage the new thread. All we have to do to make the window functional is to start the <xref:System.Windows.Threading.Dispatcher?displayProperty=nameWithType>.

  :::code language="csharp" source="./snippets/threading-model/csharp/MultiWindow.xaml.cs" id="thread":::
  :::code language="vb" source="./snippets/threading-model/vb/MultiWindow.xaml.vb" id="thread":::

A sample app demonstrating the concepts of this section can be downloaded from GitHub for either [C#](https://github.com/dotnet/samples/tree/main/wpf/Threading/MultithreadedWindow/net48/csharp) or [Visual Basic](https://github.com/dotnet/samples/tree/main/wpf/Threading/MultithreadedWindow/net48/vb).

<a name="weather_sim"></a>

## Handle a blocking operation with Task.Run

Handling blocking operations in a graphical application can be difficult. We don't want to call blocking methods from event handlers because the application appears to freeze up. The previous example created new windows in their own thread, letting each window run independent from one another. While we can create a new thread with <xref:System.Windows.Threading.Dispatcher?displayProperty=nameWithType>, it becomes difficult to synchronize the new thread with the main UI thread after the work is completed. Because the new thread can't modify the UI directly, we have to use <xref:System.Windows.Threading.Dispatcher.InvokeAsync%2A?displayProperty=nameWithType>, <xref:System.Windows.Threading.Dispatcher.BeginInvoke%2A?displayProperty=nameWithType>, or <xref:System.Windows.Threading.Dispatcher.Invoke%2A?displayProperty=nameWithType>, to insert delegates into the <xref:System.Windows.Threading.Dispatcher> of the UI thread. Eventually, these delegates are executed with permission to modify UI elements.

There's an easier way to run the code on a new thread while synchronizing the results, the [Task-based asynchronous pattern (TAP)](/dotnet/standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap). It's based on the <xref:System.Threading.Tasks.Task> and <xref:System.Threading.Tasks.Task%601> types in the `System.Threading.Tasks` namespace, which are used to represent asynchronous operations. TAP uses a single method to represent the initiation and completion of an asynchronous operation. There are a few benefits to this pattern:

- The caller of a `Task` can choose to run the code asynchronously or synchronously.
- Progress can be reported from the `Task`.
- The calling code can suspend execution and wait for the result of the operation.

### Task.Run example

In this example, we mimic a remote procedure call that retrieves a weather forecast. When the button is clicked, the UI is updated to indicate that the data fetch is in progress, while a task is started to mimic fetching the weather forecast. When the task is started, the button event handler code is suspended until the task finishes. After the task finishes, the event handler code continues to run. The code is suspended, and it doesn't block the rest of the UI thread. The synchronization context of WPF handles suspending the code, which allows WPF to continue to run.

:::image type="complex" source="./media/threading-model/threading-weather-ui.png" alt-text="A diagram that demonstrates the workflow of the example app.":::

A diagram demonstrating the example app's workflow. The app has a single button with the text "Fetch Forecast." There's an arrow pointing to the next phase of the app after the button is pressed, which is a clock image placed in the center of the app indicating that the app is busy fetching data. After some time, the app returns with either an image of the sun or of rain clouds, depending on the result of the data.

:::image-end:::

A sample app demonstrating the concepts of this section can be downloaded from GitHub for either [C#](https://github.com/dotnet/samples/tree/main/wpf/Threading/Weather/net48/csharp) or [Visual Basic](https://github.com/dotnet/samples/tree/main/wpf/Threading/Weather/net48/vb). The XAML for this example is quite large and not provided in this article. Use the previous GitHub links to browse the XAML. The XAML uses a single button to fetch the weather.

Consider the code-behind to the XAML:

:::code language="csharp" source="./snippets/threading-model/csharp/Weather.xaml.cs" id="full":::
:::code language="vb" source="./snippets/threading-model/vb/Weather.xaml.vb" id="full":::

The following are some of the details to be noted.

- The button event handler

  :::code language="csharp" source="./snippets/threading-model/csharp/Weather.xaml.cs" id="button" highlight="1,10":::
  :::code language="vb" source="./snippets/threading-model/vb/Weather.xaml.vb" id="button" highlight="1,10":::

  Notice that the event handler was declared with `async` (or `Async` with Visual Basic). An "async" method allows suspension of the code when an awaited method, such as `FetchWeatherFromServerAsync`, is called. This is designated by the `await` (or `Await` with Visual Basic) keyword. Until the `FetchWeatherFromServerAsync` finishes, the button's handler code is suspended and control is returned to the caller. This is similar to a synchronous method except that a synchronous method waits for every operation in the method to finish after which control is returned to the caller.

  Awaited methods utilize the threading context of the current method, which with the button handler, is the UI thread. This means that calling `await FetchWeatherFromServerAsync();` (Or `Await FetchWeatherFromServerAsync()` with Visual Basic) causes the code in `FetchWeatherFromServerAsync` to run on the UI thread, but isn't executed on the dispatcher has time to run it, similar to how the [Single-threaded app with a long-running calculation](#single-threaded-app-with-a-long-running-calculation) example operates. However, notice that `await Task.Run` is used. This creates a new thread on the thread pool for the designated task instead of the current thread. So `FetchWeatherFromServerAsync` runs on its own thread.

- Fetching the Weather

  :::code language="csharp" source="./snippets/threading-model/csharp/Weather.xaml.cs" id="fetch_weather":::
  :::code language="vb" source="./snippets/threading-model/vb/Weather.xaml.vb" id="fetch_weather":::

  To keep things simple, we don't actually have any networking code in this example. Instead, we simulate the delay of network access by putting our new thread to sleep for four seconds. In this time, the original UI thread is still running and responding to UI events while the button's event handler is paused until the new thread completes. To demonstrate this, we've left an animation running, and you can resize the window. If the UI thread was paused or delayed, the animation wouldn't be shown and you couldn't interact with the window.

  When the `Task.Delay` is finished, and we've randomly selected our weather forecast, the weather status is returned to the caller.

- Updating the UI

  :::code language="csharp" source="./snippets/threading-model/csharp/Weather.xaml.cs" id="button" highlight="14-27":::
  :::code language="vb" source="./snippets/threading-model/vb/Weather.xaml.vb" id="button" highlight="14-30":::

  When the task finishes and the UI thread has time, the caller of `Task.Run`, the button's event handler, is resumed. The rest of the method stops the clock animation and chooses an image to describe the weather. It displays this image and enables the "fetch forecast" button.

A sample app demonstrating the concepts of this section can be downloaded from GitHub for either [C#](https://github.com/dotnet/samples/tree/main/wpf/Threading/Weather/net48/csharp) or [Visual Basic](https://github.com/dotnet/samples/tree/main/wpf/Threading/Weather/net48/vb).

<a name="stumbling_points"></a>

## Technical details and stumbling points

The following sections describe some of the details and stumbling points you may come across with multithreading.

### Nested pumping

 Sometimes it is not feasible to completely lock up the UI thread. Let's consider the <xref:System.Windows.MessageBox.Show%2A> method of the <xref:System.Windows.MessageBox> class. <xref:System.Windows.MessageBox.Show%2A> doesn't return until the user clicks the OK button. It does, however, create a window that must have a message loop in order to be interactive. While we are waiting for the user to click OK, the original application window does not respond to user input. It does, however, continue to process paint messages. The original window redraws itself when covered and revealed.

 :::image type="content" source="./media/threading-model/threading-message-loop.png" alt-text="Screenshot that shows a MessageBox with an OK button":::

 Some thread must be in charge of the message box window. WPF could create a new thread just for the message box window, but this thread would be unable to paint the disabled elements in the original window (remember the earlier discussion of mutual exclusion). Instead, WPF uses a nested message processing system. The <xref:System.Windows.Threading.Dispatcher> class includes a special method called <xref:System.Windows.Threading.Dispatcher.PushFrame%2A>, which stores an application's current execution point then begins a new message loop. When the nested message loop finishes, execution resumes after the original <xref:System.Windows.Threading.Dispatcher.PushFrame%2A> call.

 In this case, <xref:System.Windows.Threading.Dispatcher.PushFrame%2A> maintains the program context at the call to <xref:System.Windows.MessageBox.Show%2A?displayProperty=nameWithType>, and it starts a new message loop to repaint the background window and handle input to the message box window. When the user clicks OK and clears the pop-up window, the nested loop exits and control resumes after the call to <xref:System.Windows.MessageBox.Show%2A>.

### Stale routed events

 The routed event system in WPF notifies entire trees when events are raised.

```xaml
<Canvas MouseLeftButtonDown="handler1" 
        Width="100"
        Height="100"
        >
  <Ellipse Width="50"
            Height="50"
            Fill="Blue" 
            Canvas.Left="30"
            Canvas.Top="50" 
            MouseLeftButtonDown="handler2"
            />
</Canvas>
```

 When the left mouse button is pressed over the ellipse, `handler2` is executed. After `handler2` finishes, the event is passed along to the <xref:System.Windows.Controls.Canvas> object, which uses `handler1` to process it. This happens only if `handler2` does not explicitly mark the event object as handled.

 It's possible that `handler2` will take a great deal of time processing this event. `handler2` might use <xref:System.Windows.Threading.Dispatcher.PushFrame%2A> to begin a nested message loop that doesn't return for hours. If `handler2` does not mark the event as handled when this message loop is complete, the event is passed up the tree even though it is very old.

### Reentrancy and locking

 The locking mechanism of the common language runtime (CLR) doesn't behave exactly as one might imagine; one might expect a thread to cease operation completely when requesting a lock. In actuality, the thread continues to receive and process high-priority messages. This helps prevent deadlocks and make interfaces minimally responsive, but it introduces the possibility for subtle bugs.  The vast majority of the time you don't need to know anything about this, but under rare circumstances (usually involving Win32 window messages or COM STA components) this can be worth knowing.

 Most interfaces are not built with thread safety in mind because developers work under the assumption that a UI is never accessed by more than one thread. In this case, that single thread may make environmental changes at unexpected times, causing those ill effects that the <xref:System.Windows.Threading.DispatcherObject> mutual exclusion mechanism is supposed to solve. Consider the following pseudocode:

 :::image type="content" source="./media/threading-model/threading-reentrancy.png" alt-text="Diagram that shows threading reentrancy.":::

 Most of the time that's the right thing, but there are times in WPF where such unexpected reentrancy can really cause problems. So, at certain key times, WPF calls <xref:System.Windows.Threading.Dispatcher.DisableProcessing%2A>, which changes the lock instruction for that thread to use the WPF reentrancy-free lock, instead of the usual CLR lock.

 So why did the CLR team choose this behavior? It had to do with COM STA objects and the finalization thread. When an object is garbage collected, its `Finalize` method is run on the dedicated finalizer thread, not the UI thread. And therein lies the problem, because a COM STA object that was created on the UI thread can only be disposed on the UI thread. The CLR does the equivalent of a <xref:System.Windows.Threading.Dispatcher.BeginInvoke%2A> (in this case using Win32's `SendMessage`). But if the UI thread is busy, the finalizer thread is stalled and the COM STA object can't be disposed, which creates a serious memory leak. So the CLR team made the tough call to make locks work the way they do.

 The task for WPF is to avoid unexpected reentrancy without reintroducing the memory leak, which is why we don't block reentrancy everywhere.

## See also

- [Single-Threaded Application with Long-Running Calculation Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Threading/SingleThreadedApplication)
