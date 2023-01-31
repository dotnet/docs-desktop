---
title: "Marking Routed Events as Handled, and Class Handling"
description: Learn about class handling and how handlers for a routed event can mark the event handled within the event data.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "tunneling events [WPF]"
  - "class listeners [WPF]"
  - "listeners [WPF]"
  - "Preview routed events [WPF]"
  - "instance listeners [WPF]"
  - "events [WPF], bubbling"
  - "suppressing events [WPF]"
  - "routed events [WPF], Preview"
  - "composited controls [WPF]"
  - "events [WPF], tunneling"
  - "routed events [WPF], marking as handled"
  - "controls [WPF], compositing"
  - "events [WPF], suppressing"
  - "bubbling events [WPF]"
ms.assetid: 5e745508-4861-4b48-b5f6-5fc7ce5289d2
---
# Marking Routed Events as Handled, and Class Handling

Handlers for a routed event can mark the event handled within the event data. Handling the event will effectively shorten the route. Class handling is a programming concept that is supported by routed events. A class handler has the opportunity to handle a particular routed event at a class level with a handler that is invoked before any instance handler on any instance of the class.  

<a name="prerequisites"></a>

## Prerequisites  

 This topic elaborates on concepts introduced in the [Routed Events Overview](routed-events-overview.md).  
  
<a name="When_to_Mark_Events_as_Handled"></a>

## When to Mark Events as Handled  

 When you set the value of the <xref:System.Windows.RoutedEventArgs.Handled%2A> property to `true` in the event data for a routed event, this is referred to as "marking the event handled". There is no absolute rule for when you should mark routed events as handled, either as an application author, or as a control author who responds to existing routed events or implements new routed events. For the most part, the concept of "handled" as carried in the routed event's event data should be used as a limited protocol for your own application's responses to the various routed events exposed in WPF APIs as well as for any custom routed events. Another way to consider the "handled" issue is that you should generally mark a routed event handled if your code responded to the routed event in a significant and relatively complete way. Typically, there should not be more than one significant response that requires separate handler implementations for any single routed event occurrence. If more responses are needed, then the necessary code should be implemented through application logic that is chained within a single handler rather than by using the routed event system for forwarding. The concept of what is "significant" is also subjective, and depends on your application or code. As general guidance, some "significant response" examples include: setting focus, modifying public state, setting properties that affect the visual representation, and raising other new events. Examples of nonsignificant responses include: modifying private state (with no visual impact, or programmatic representation), logging of events, or looking at arguments of an event and choosing not to respond to it.  
  
 The routed event system behavior reinforces this "significant response" model for using handled state of a routed event, because handlers added in XAML or the common signature of <xref:System.Windows.UIElement.AddHandler%2A> are not invoked in response to a routed event where the event data is already marked handled. You must go through the extra effort of adding a handler with the `handledEventsToo` parameter version (<xref:System.Windows.UIElement.AddHandler%28System.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29>) in order to handle routed events that are marked handled by earlier participants in the event route.  
  
 In some circumstances, controls themselves mark certain routed events as handled. A handled routed event represents a decision by WPF control authors that the control's actions in response to the routed event are significant or complete as part of the control implementation, and the event needs no further handling. Usually this is done by adding a class handler for an event, or by overriding one of the class handler virtuals that exist on a base class. You can still work around this event handling if necessary; see [Working Around Event Suppression by Controls](#WorkingAroundEventSuppressionByControls) later in this topic.  
  
<a name="Preview_Events_vs__Bubbling_Events_and_Handling"></a>

## "Preview" (Tunneling) Events vs. Bubbling Events, and Event Handling  

 Preview routed events are events that follow a tunneling route through the element tree. The "Preview" expressed in the naming convention is indicative of the general principle for input events that preview (tunneling) routed events are raised prior to the equivalent bubbling routed event. Also, input routed events that have a tunneling and bubbling pair have a distinct handling logic. If the tunneling/preview routed event is marked as handled by an event listener, then the bubbling routed event will be marked handled even before any listeners of the bubbling routed event receive it. The tunneling and bubbling routed events are technically separate events, but they deliberately share the same instance of event data to enable this behavior.  
  
 The connection between the tunneling and bubbling routed events is accomplished by the internal implementation of how any given WPF class raises its own declared routed events, and this is true of the paired input routed events. But unless this class-level implementation exists, there is no connection between a tunneling routed event and a bubbling routed event that share the naming scheme: without such implementation they would be two entirely separate routed events and would not be raised in sequence or share event data.  
  
 For more information about how to implement tunnel/bubble input routed event pairs in a custom class, see [Create a Custom Routed Event](how-to-create-a-custom-routed-event.md).  
  
<a name="Class_Handlers_and_Instance_Handlers"></a>

## Class Handlers and Instance Handlers  

 Routed events consider two different types of listeners to the event: class listeners and instance listeners. Class listeners exist because types have called a particular <xref:System.Windows.EventManager> API ,<xref:System.Windows.EventManager.RegisterClassHandler%2A>, in their static constructor, or have overridden a class handler virtual method from an element base class. Instance listeners are particular class instances/elements where one or more handlers have been attached for that routed event by a call to <xref:System.Windows.UIElement.AddHandler%2A>. Existing WPF routed events make calls to <xref:System.Windows.UIElement.AddHandler%2A> as part of the common language runtime (CLR) event wrapper add{} and remove{} implementations of the event, which is also how the simple XAML mechanism of attaching event handlers via an attribute syntax is enabled. Therefore even the simple XAML usage ultimately equates to an <xref:System.Windows.UIElement.AddHandler%2A> call.  
  
 Elements within the visual tree are checked for registered handler implementations. Handlers are potentially invoked throughout the route, in the order that is inherent in the type of the routing strategy for that routed event. For instance, bubbling routed events will first invoke those handlers that are attached to the same element that raised the routed event. Then the routed event "bubbles" to the next parent element and so on until the application root element is reached.  
  
 From the perspective of the root element in a bubbling route, if class handling or any element closer to the source of the routed event invoke handlers that mark the event arguments as being handled, then handlers on the root elements are not invoked, and the event route is effectively shortened before reaching that root element. However, the route is not completely halted, because handlers can be added using a special conditional that they should still be invoked, even if a class handler or instance handler has marked the routed event as handled. This is explained in [Adding Instance Handlers That Are Raised Even When Events Are Marked Handled](#AddingInstanceHandlersthatAreRaisedEvenWhenEventsareMarkedHandled), later in this topic.  
  
 At a deeper level than the event route, there are also potentially multiple class handlers acting on any given instance of a class. This is because the class handling model for routed events enables all possible classes in a class hierarchy to each register its own class handler for each routed event. Each class handler is added to an internal store, and when the event route for an application is constructed, the class handlers are all added to the event route. Class handlers are added to the route such that the most-derived class handler is invoked first, and class handlers from each successive base class are invoked next. Generally, class handlers are not registered such that they also respond to routed events that were already marked handled. Therefore, this class handling mechanism enables one of two choices:  
  
- Derived classes can supplement the class handling that is inherited from the base class by adding a handler that does not mark the routed event handled, because the base class handler will be invoked sometime after the derived class handler.  
  
- Derived classes can replace the class handling from the base class by adding a class handler that marks the routed event handled. You should be cautious with this approach, because it will potentially change the intended base control design in areas such as visual appearance, state logic, input handling, and command handling.  
  
<a name="Class_Handling_of_Routed_Events"></a>

## Class Handling of Routed Events by Control Base Classes  

 On each given element node in an event route, class listeners have the opportunity to respond to the routed event before any instance listener on the element can. For this reason, class handlers are sometimes used to suppress routed events that a particular control class implementation does not wish to propagate further, or to provide special handling of that routed event that is a feature of the class. For instance, a class might raise its own class-specific event that contains more specifics about what some user input condition means in the context of that particular class. The class implementation might then mark the more general routed event as handled. Class handlers are typically added such that they are not invoked for routed events where shared event data was already marked handled, but for atypical cases there is also a <xref:System.Windows.EventManager.RegisterClassHandler%28System.Type%2CSystem.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29> signature that registers class handlers to invoke even when routed events are marked handled.  
  
### Class Handler Virtuals  

 Some elements, particularly the base elements such as <xref:System.Windows.UIElement>, expose empty "On*Event" and "OnPreview\*Event" virtual methods that correspond to their list of public routed events. These virtual methods can be overridden to implement a class handler for that routed event. The base element classes register these virtual methods as their class handler for each such routed event using <xref:System.Windows.EventManager.RegisterClassHandler%28System.Type%2CSystem.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29> as described earlier. The On\*Event virtual methods make it much simpler to implement class handling for the relevant routed events, without requiring special initialization in static constructors for each type. For instance, you can add class handling for the <xref:System.Windows.UIElement.DragEnter> event in any <xref:System.Windows.UIElement> derived class by overriding the <xref:System.Windows.UIElement.OnDragEnter%2A> virtual method. Within the override, you could handle the routed event, raise other events, initiate class-specific logic that might change element properties on instances, or any combination of those actions. You should generally call the base implementation in such overrides even if you mark the event handled. Calling the base implementation is strongly recommended because the virtual method is on the base class. The standard protected virtual pattern of calling the base implementations from each virtual essentially replaces and parallels a similar mechanism that is native to routed event class handling, whereby class handlers for all classes in a class hierarchy are called on any given instance, starting with the most-derived class' handler and continuing to the base class handler. You should only omit the base implementation call if your class has a deliberate requirement to change the base class handling logic. Whether you call the base implementation before or after your overriding code will depend on the nature of your implementation.  
  
#### Input Event Class Handling  

 The class handler virtual methods are all registered such that they are only invoked in cases where any shared event data are not already marked handled. Also, for the input events uniquely, the tunneling and bubbling versions typically are raised in sequence and share event data. This entails that for a given pair of class handlers of input events where one is the tunneling version and the other is the bubbling version, you may not want to mark the event handled immediately. If you implement the tunneling class handling virtual method to mark the event handled, that will prevent the bubbling class handler from being invoked (as well as preventing any normally registered instance handlers for either the tunneling or bubbling event from being invoked).  
  
 Once class handling on a node is complete, the instance listeners are considered.  
  
<a name="AddingInstanceHandlersthatAreRaisedEvenWhenEventsareMarkedHandled"></a>

## Adding Instance Handlers That Are Raised Even When Events Are Marked Handled  

 The <xref:System.Windows.UIElement.AddHandler%2A> method supplies a particular overload that allows you to add handlers that will be invoked by the event system whenever an event reaches the handling element in the route, even if some other handler has already adjusted the event data to mark that event as handled. This is not typically done. Generally, handlers can be written to adjust all areas of application code that might be influenced by an event, regardless of where it was handled in an element tree, even if multiple end results are desired. Also, typically there is really only one element that needs to respond to that event, and the appropriate application logic had already happened. But the `handledEventsToo` overload is available for the exceptional cases where some other element in an element tree or control compositing has already marked an event as handled, but other elements either higher or lower in the element tree (depending on route) still wish to have their own handlers invoked.  
  
#### When to Mark Handled Events as Unhandled  

 Generally, routed events that are marked handled should not be marked unhandled (<xref:System.Windows.RoutedEventArgs.Handled%2A> set back to `false`) even by handlers that act on `handledEventsToo`. However, some input events have high-level and lower-level event representations that can overlap when the high-level event is seen at one position in the tree and the low-level event at another position. For instance, consider the case where a child element listens to a high-level key event such as <xref:System.Windows.UIElement.TextInput> while a parent element listens to a low-level event such as <xref:System.Windows.UIElement.KeyDown>. If the parent element handles the low-level event, the higher-level event can be suppressed even in the child element that intuitively should have first opportunity to handle the event.  
  
 In these situations it may be necessary to add handlers to both parent elements and child elements for the low-level event. The child element handler implementation can mark the low-level event as handled, but the parent element handler implementation would set it unhandled again so that further elements up the tree (as well as the high-level event) can have the opportunity to respond. This situation is should be fairly rare.  
  
<a name="Deliberately_Suppressing_Input_Events_for_Control"></a>

## Deliberately Suppressing Input Events for Control Compositing  

 The main scenario where class handling of routed events is used is for input events and composited controls. A composited control is by definition composed of multiple practical controls or control base classes. Often the author of the control wishes to amalgamate all of the possible input events that each of the subcomponents might raise, in order to report the entire control as the singular event source. In some cases the control author might wish to suppress the events from components entirely, or substitute a component-defined event that carries more information or implies a more specific behavior. The canonical example that is immediately visible to any component author is how a Windows Presentation Foundation (WPF) <xref:System.Windows.Controls.Button> handles any mouse event that will eventually resolve to the intuitive event that all buttons have: a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event.  
  
 The <xref:System.Windows.Controls.Button> base class (<xref:System.Windows.Controls.Primitives.ButtonBase>) derives from <xref:System.Windows.Controls.Control> which in turn derives from <xref:System.Windows.FrameworkElement> and <xref:System.Windows.UIElement>, and much of the event infrastructure needed for control input processing is available at the <xref:System.Windows.UIElement> level. In particular, <xref:System.Windows.UIElement> processes general <xref:System.Windows.Input.Mouse> events that handle hit testing for the mouse cursor within its bounds, and provides distinct events for the most common button actions, such as <xref:System.Windows.UIElement.MouseLeftButtonDown>. <xref:System.Windows.UIElement> also provides an empty virtual <xref:System.Windows.UIElement.OnMouseLeftButtonDown%2A> as the preregistered class handler for <xref:System.Windows.UIElement.MouseLeftButtonDown>, and <xref:System.Windows.Controls.Primitives.ButtonBase> overrides it. Similarly, <xref:System.Windows.Controls.Primitives.ButtonBase> uses class handlers for <xref:System.Windows.UIElement.MouseLeftButtonUp>. In the overrides, which are passed the event data, the implementations mark that <xref:System.Windows.RoutedEventArgs> instance as handled by setting <xref:System.Windows.RoutedEventArgs.Handled%2A> to `true`, and that same event data is what continues along the remainder of the route to other class handlers and also to instance handlers or event setters. Also, the <xref:System.Windows.Controls.Primitives.ButtonBase.OnMouseLeftButtonUp%2A> override will next raise the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event. The end result for most listeners will be that the <xref:System.Windows.UIElement.MouseLeftButtonDown> and <xref:System.Windows.UIElement.MouseLeftButtonUp> events "disappear" and are replaced instead by <xref:System.Windows.Controls.Primitives.ButtonBase.Click>, an event that holds more meaning because it is known that this event originated from a true button and not some composite piece of the button or from some other element entirely.  
  
<a name="WorkingAroundEventSuppressionByControls"></a>

### Working Around Event Suppression by Controls  

 Sometimes this event suppression behavior within individual controls can interfere with some more general intentions of event handling logic for your application. For instance, if for some reason your application had a handler for <xref:System.Windows.UIElement.MouseLeftButtonDown> located at the application root element, you would notice that any mouse click on a button would not invoke <xref:System.Windows.UIElement.MouseLeftButtonDown> or <xref:System.Windows.UIElement.MouseLeftButtonUp> handlers at the root level. The event itself actually did bubble up (again, event routes are not truly ended, but the routed event system changes their handler invocation behavior after being marked handled). When the routed event reached the button, the <xref:System.Windows.Controls.Primitives.ButtonBase> class handling marked the <xref:System.Windows.UIElement.MouseLeftButtonDown> handled because it wished to substitute the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event with more meaning. Therefore, any standard <xref:System.Windows.UIElement.MouseLeftButtonDown> handler further up the route would not be invoked. There are two techniques you can use to ensure that your handlers would be invoked in this circumstance.  
  
 The first technique is to deliberately add the handler using the `handledEventsToo` signature of <xref:System.Windows.UIElement.AddHandler%28System.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29>. A limitation of this approach is that this technique for attaching an event handler is only possible from code, not from markup. The simple syntax of specifying the event handler name as an event attribute value via Extensible Application Markup Language (XAML) does not enable that behavior.  
  
 The second technique works only for input events, where the tunneling and bubbling versions of the routed event are paired. For these routed events, you can add handlers to the preview/tunneling equivalent routed event instead. That routed event will tunnel through the route starting from the root, so the button class handling code would not intercept it, presuming that you attached the Preview handler at some ancestor element level in the application's element tree. If you use this approach, be cautious about marking any Preview event handled. For the example given with <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> being handled at the root element, if you marked the event as <xref:System.Windows.RoutedEventArgs.Handled%2A> in the handler implementation, you would actually suppress the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event. That is typically not desirable behavior.  
  
## See also

- <xref:System.Windows.EventManager>
- [Preview Events](preview-events.md)
- [Create a Custom Routed Event](how-to-create-a-custom-routed-event.md)
- [Routed Events Overview](routed-events-overview.md)
