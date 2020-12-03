# Overview of WPF & UWP Differences

The Universal Windows Platform (UWP) has its roots in SilverLight instead of being based on the Windows Presentation Foundation (WPF). UWP is implemented natively in C++ instead of WPF which was written in C# and C++ for lower-level functions. Due to being a completely different imlementation of XAML, designed to include more resource constrained devices, and support for more programming languages, there are several differences in UWP compared to WPF. These differences may be new functionality in UWP, slightly different ways of doing things or, more commonly, WPF features missing in UWP. These differences are not summarized by Microsoft which is prohibitive for developers familiar with WPF and that have to port existing code. This document is intended to provide an overview of the differences.

## XAML / Object Model

This section lists the main differences (primarily from a XAML viewpoint) between UWP and WPF. 

Legend:

 * ✔ Indicates the platform (defined by the WPF or UWP column) has the feature
 * ❌ Indicates the feature is generally missing in the platform
 * ⚡ Indicates the feature is only partially implemented compared to other platforms

### Markup Extensions & Directives

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>x:Array Extension</td>
  <td>✔</td>
  <td>❌</td>
  <td>x:Array isn't supported in UWP.</td>
 </tr>
 <tr>
  <td>x:Bind Extension</td>
  <td>❌</td>
  <td>✔</td>
  <td>The x:Bind markup extension has become a powerful feature of UWP over WPF. Compiled function bindings can be used for nearly anything and can replace other missing features like MultiBinding in most situations (Importantly, x:Bind isn't supported in control templates so it cannot replace MultiBinding there). Other advantages of x:Bind include debugging support as well as increased performance because it's compiled.</td>
 </tr>
 <tr>
  <td>x:Load Attribute</td>
  <td>❌</td>
  <td>✔</td>
  <td>You can use x:Load to optimize the startup, visual tree creation, and memory usage of your XAML app. Using x:Load has a similar visual effect to Visibility, except that when the element is not loaded, its memory is released and internally a small placeholder is used to mark its place in the visual tree.</td>
 </tr>
 <tr>
  <td>x:Static Extension</td>
  <td>✔</td>
  <td>❌</td>
  <td>The x:Static markup extension isn't implemented in UWP. In WPF this is used to access a static by-value code entity (constant, property, field, or enum).</td>
 </tr>
 <tr>
  <td>x:Type Extension</td>
  <td>✔</td>
  <td>❌</td>
  <td>The x:Type markup extension isn't implemented in UWP. In WPF this is used to get a type similar to `Type.GetType()`.</td>
 </tr>
 <tr>
  <td>x:TypeArguments Directive</td>
  <td>✔</td>
  <td>❌</td>
  <td>The x:TypeArguments directive isn't implemented in UWP which causes problems with generics. Missing this requires some work-arounds with classes and creating a non-generic class to use in XAML from a generic one.</td>
 </tr>
 <tr>
  <td>x:Uid Directive / .resw for localization</td>
  <td>⚡</td>
  <td>✔</td>
  <td>x:Uid exists in both WPF and UWP. However, using it to localize properties is quite a bit more complex in WPF (using LocBaml, csv files, the commmand line in a manual process). UWP provides a much more integrated localization system using x:Uid and .resw files similar to what existed in Windows Forms. WPF is sorely missing this type of localization support and this is a clear advantage of UWP.</td>
 </tr>
 <tr>
  <td>{DynamicResource} Extension</td>
  <td>✔</td>
  <td>❌</td>
  <td>The dynamic resource markup extension which is fairly common in WPF doesn't exist in UWP. A partial work-around requires custom markup extensions.</td>
 </tr>
 <tr>
  <td>Full Markup Extension</td>
  <td>✔</td>
  <td>❌</td>
  <td>UWP only implements a subset of the full markup extension support in WPF. This area needs to be expanded upon in the future.</td>
 </tr>
</table>
 
### Binding / Dependency Property System
 
<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>Coercion</td>
  <td>✔</td>
  <td>❌</td>
  <td>Coercion of Dependency Properties is not supported in UWP.</td>
 </tr>
 <tr>
  <td>Data (Input) Validation</td>
  <td>✔</td>
  <td>❌</td>
  <td>The entire WPF data validation system including the classes/inferfaces: ValidationRule (and all standard implementations), Binding.ValidationRules, IDataErrorInfo, INotifyDataErrorInfo, Binding.ValidatesOnNotifyDataErrors, etc. is not implemented in UWP. This will be added in WinUI 3.0 but the story for using this within the UWP app model with WinUI 3.0 is less clear.</td>
 </tr>
 <tr>
  <td>OneWayToSource BindingMode</td>
  <td>✔</td>
  <td>❌</td>
  <td></td>
 </tr>
 <tr>
  <td>Binding to ConverterParameter</td>
  <td>✔</td>
  <td>❌</td>
  <td></td>
 </tr>
 <tr>
  <td>MultiBinding /
  IMultiValueConverter</td>
  <td>✔</td>
  <td>❌</td>
  <td>Very useful feature in WPF for advanced binding scenearios no longer exists for UWP. UWP does have function binding with x:Bind though (Used to re-implement converter logic).</td>
 </tr>
 <tr>
  <td>ICommand</td>
  <td>✔</td>
  <td>⚡</td>
  <td>While the interface technically exists, ICommand is nothing like what it was in WPF. The programmer is now responsible for doing every little part of the command. This was improved in Windows 10 version 1809 which added XamlUICommand and StandardUICommand.</td>
 </tr>
 <tr>
  <td>RelativeSource / AncestorType</td>
  <td>✔</td>
  <td>⚡</td>
  <td>Not nearly as powerful in UWP, relative source only supports `{RelativeSource Self}` and `{RelativeSource TemplatedParent}` as compared to more powerful expressions in WPF like `{RelativeSource PreviousData}` or `{Binding RelativeSource={RelativeSource Mode=PreviousData, AncestorType={x:Type TextBox}}`.</td>
 </tr>
 <tr>
  <td>StringFormat</td>
  <td>✔</td>
  <td>❌</td>
  <td>XAML such as `{Binding DateValue, StringFormat=Date: {0:dddd yyyy-MM-dd}}` isn't supported in UWP and requires custom converters.</td>
 </tr>
</table>

### Styling

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>DataTriggers / PropertyTrigger / EventTrigger within Style.Triggers</td>
  <td>✔</td>
  <td>❌</td>
  <td></td>
 </tr>
 <tr>
  <td>VisualStateManager</td>
  <td>⚡</td>
  <td>✔</td>
  <td>A different concept from WPF that takes the place of DataTriggers, this is very verbose and more often than not increases complexity compared to data triggers.

@Felix-Dev VisualStateManager does exist in WPF (it was added in .NET Framework 4.0). It's not as elegant as in UWP though, i.e. it has no VisuaStateManager.Setters property. That means you have to use Storyboards to set your values.</td>
 </tr>
 <tr>
  <td>Implicit DataTemplate</td>
  <td>✔</td>
  <td>❌</td>
  <td>Set the DataType property of the DataTemplate to the corresponding type and the template is then applied automatically to all instances of that particular type</td>
 </tr>
 <tr>
  <td>Binding in Style setter</td>
  <td>✔</td>
  <td>❌</td>
  <td>Any other than TemplateBinding isn't support in a template/style within UWP</td>
 </tr>
 <tr>
  <td>BasedOn default Style</td>
  <td>✔</td>
  <td>⚡</td>
  <td>`BasedOn={StaticResource {x:Type TextBlock}` isn't supported in UWP but works in WPF. Instead, BasedOn requires the use of a key which is a problem as not all default styles define one. This is a specific example of the missing x:Type markup extension in UWP.</td>
 </tr>
</table>

### Classes/Objects

This section primarily describes differences in properties at the object or class level. As the number of differences in this section may become quite large, classes and properties are listed alphabetically and grouped together where it makes sense.

**Grid**

<details>
  <summary>Differences</summary>

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>BorderBrush</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's Grid. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>BorderThickness</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's Grid. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>ColumnSpacing / RowSpacing</td>
  <td>❌</td>
  <td>✔</td>
  <td>Similar to StackPanel.Spacing, the Grid's ColumnSpacing and RowSpacing properties provide a quick way to set a uniform horizortal and/or vertical distance between all child controls in a Grid. This was added to UWP and does not exist in WPF.</td>
 </tr>
 <tr>
  <td>CornerRadius</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's Grid. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>Padding</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's Grid. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>ShowGridLines</td>
  <td>✔</td>
  <td>❌</td>
  <td>While this property exists in WPF, it was only intended for debugging purposes and not production quality code (https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.grid.showgridlines). As such, it was removed from UWP.</td>
 </tr>
</table>

</details>

**StackPanel**

Additional properties such as WPF's `HasLogicalOrientation`, `HorizontalOffset` and `VerticalOffset` are purposely excluded from this section as they aren't considered useful.

<details>
  <summary>Differences</summary>

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>AreHorizontalSnapPointsRegular / AreScrollSnapPointsRegular / AreVerticalSnapPointsRegular</td>
  <td>❌</td>
  <td>✔</td>
  <td>Information on snapping points does not exist in WPF's StackPanel.</td>
 </tr>
 <tr>
  <td>BackgroundSizing</td>
  <td>❌</td>
  <td>✔</td>
  <td>https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.stackpanel.backgroundsizing</td>
 </tr>
 <tr>
  <td>BorderBrush</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's StackPanel. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>BorderThickness</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's StackPanel. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>CornerRadius</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's StackPanel. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>ExtentHeight</td>
  <td>✔</td>
  <td>❌</td>
  <td>https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.stackpanel.extentheight</td>
 </tr>
 <tr>
  <td>ExtentWidth</td>
  <td>✔</td>
  <td>❌</td>
  <td>https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.stackpanel.extentwidth</td>
 </tr>
 <tr>
  <td>Padding</td>
  <td>❌</td>
  <td>✔</td>
  <td>This property does not exist in WPF's StackPanel. It was added in UWP to help flatten the visual tree instead of requiring the use of a Border.</td>
 </tr>
 <tr>
  <td>Spacing</td>
  <td>❌</td>
  <td>✔</td>
  <td>The Spacing property is a quick way to set a uniform distance between all child controls in a StackPanel. This was added to UWP and does not exist in WPF.</td>
 </tr>
</table>

</details>

**UIElement**

<details>
  <summary>Differences</summary>

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
<tr>
  <td>IsVisible / IsVisibleChanged Event</td>
  <td>✔</td>
  <td>❌</td>
  <td>UWP has no way of tracking which controls are actually visible on the display. WPF has the UIElement.IsVisible property and the IsVisibleChanged event. This hinders the ability to optimize controls for performance.</td>
 </tr>
 <tr>
  <td>Visibility with Visibility.Hidden</td>
  <td>✔</td>
  <td>⚡</td>
  <td>UWP does not include the Visibility.Hidden enum value used for UIElement.Visibility. Hidden in WPF allowed a control to still be used in measure/layout but appear invisible when rendered for display.</td>
 </tr>
 <tr>
  <td>Clip</td>
  <td>✔</td>
  <td>⚡</td>
  <td>Both WPF and UWP have UIElement.Clip properties. However, WPF can take any Geometry allowing for non-rectangular clipping. UWP can only use a RectangleGeometry for clipping. WPF: public Geometry UIElement.Clip, UWP: public RectangleGeometry UIElement.Clip</td>
 </tr>
 <tr>
  <td>ClipToBounds</td>
  <td>✔</td>
  <td>❌</td>
  <td>In WPF it's possible to clip child contents to the parents bounds by setting ClipToBounds to True. UWP doesn't have this property at all. The work-around is to use UIElement.Clip which can only do rectangular clipping.</td>
 </tr>
 <tr>
  <td>LayoutTransform</td>
  <td>✔</td>
  <td>❌</td>
  <td>Layout transform is needed to transform elements before layouting. This allows for easily changing textbox direction and then putting it in a table. RenderTransform, as it applies after layout, does not resize parent controls for transformed children. See Transform3D for the UWP equivalent.</td>
 </tr>
 <tr>
  <td>Projection</td>
  <td>❌</td>
  <td>✔</td>
  <td>A 3-D projection effect applied to the element. Is more or less obsolete, use Transform3D instead.</td>
 </tr>
 <tr>
  <td>Transform3D</td>
  <td>❌</td>
  <td>✔</td>
  <td>Use the Transform3D property to apply a 3-D transform matrix to a XAML element. This lets you create effects where two-dimensional UI appears to exist in 3-D space relative to the user. Transform3D behaves much like RenderTransform, but allows transforms in three-dimensional space and not just two dimensions. It also support animations.</td>
 </tr>
</table>

</details>

**Minor Changes**

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>Header / HeaderTemplate</td>
  <td>❌</td>
  <td>✔</td>
  <td>Several controls in UWP support an additional Header content and HeaderTemplate property. This allows for quickly adding a description or title above a control which is useful in data-input scenarios. UWP controls with a header property include: ComboBox, DatePicker, ListViewBase, PasswordBox, TextBox, TimePicker, ToggleSwitch. Notably, the header property is not present on some controls such as: Button and CheckBox.</td>
 </tr>
 <tr>
  <td>ItemsControl. AlternationIndex / AlternationCount</td>
  <td>✔</td>
  <td>❌</td>
  <td>WPF has an easy way to change the style of items in a list using ItemsControl.AlternationIndex and ItemsControl.AlternationCount. This allows, for example, to change the background color of a listed item for even/odd entries. UWP doesn't support this at all in any controls. The partial work-around in UWP is to create a new control deriving from the framework's implementation and override the PrepareContainerForItemOverride() method.</td>
 </tr>
 <tr>
  <td>Thickness</td>
  <td>✔</td>
  <td>⚡</td>
  <td>The Thickness struct exposes fields for Top, Bottom, Left and Right instead of dependency properties as in WPF. This means you cannot Bind or asign resources to an individual thickness parameter.</td>
 </tr>
 <tr>
  <td>Size / Rect / Point</td>
  <td>✔</td>
  <td>✔</td>
  <td>Size, Rect and Point are fully supported in both WPF and UWP. However, UWP uses single-precision float types for properties instead of double in WPF. This creates an incompatiblity when porting code.</td>
 </tr>
</table>

**Unimplemented Classes**

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>Adorner</td>
  <td>✔</td>
  <td>❌</td>
  <td>https://docs.microsoft.com/en-us/dotnet/framework/wpf/controls/adorners-overview</td>
 </tr>
 <tr>
  <td>Supplemental Shapes: Arrow, Callout, Star, etc</td>
  <td>✔</td>
  <td>❌</td>
  <td>Several shapes present in WPF are missing in UWP.</td>
 </tr>
 <tr>
  <td>VisualBrush / DrawingBrush</td>
  <td>✔</td>
  <td>❌</td>
  <td>VisualBrush is not a XAML brush in UWP. Instead, must fall back to composition brushes which are not 1:1 equivalent. DrawingBrush is not supported at all in UWP.</td>
 </tr>
 <tr>
  <td>Window</td>
  <td>✔</td>
  <td>❌</td>
  <td>For some good reasons UWP has no concept of a window. This is fine for mobile devices but can be a problem for purely desktop applications. Without a window, there is no way to control an app's size or position. There are currently proposals to add this in the transition to WinUI 3.0.</td>
 </tr>
</table>

### Other

<table>
 <tr>
   <th>Item</th>
   <th>WPF</th>
   <th>UWP</th>
   <th>Notes</th>
 </tr>
 <tr>
  <td>Custom Cursor at runtime</td>
  <td>✔</td>
  <td>❌</td>
  <td></td>
 </tr>
 <tr>
  <td>Sub-pixel anti-aliasing</td>
  <td>✔</td>
  <td>❌</td>
  <td>Anti-aliasing in UWP along with rendering in general is poor compared to WPF. It's assumed this is for performance reasons on mobile devices and the web (Silverlight).</td>
 </tr>
 <tr>
  <td>Nested Types in XAML</td>
  <td>✔</td>
  <td>❌</td>
  <td>Nesting different types in XAML is generally not possible in UWP. Code such as `&lt;ListBox.ItemsSource&gt;&lt;x:Array&gt;&lt;s:string&gt;foo&lt;s/:string&gt;&lt;x/:Array&gt;` works in WPF but not in UWP.</td>
 </tr>
 <tr>
  <td>Event Tunneling / Event Bubbling / Routed Events</td>
  <td>✔</td>
  <td>⚡</td>
  <td>A lot more events are simply direct in UWP. Some cases of event bubbling such as ButtonBase.Click to parent are not supported in UWP. Event Tunneling, a concept fully supported in WPF, isn't support at all in UWP.</td>
 </tr>
</table>

## Quirks

 * Several UWP controls have reentrancy issues. For example, changing the selected item while in a ComboBox SelectionChanged event is largely not possible and will result in a crash. This makes validation directly in the event handler nearly impossible.
 * UWP controls are generally not as powerful as the WPF counterparts. For example, for several years the ComboBox in UWP was not editable. The UWP DatePicker also does not allow typing in a specific date.
 * UWP has no support for data (input) validation. This is a large issue for line-of-business apps migrating from WPF to UWP that heavily use this feature in view models or binding.
 * The UWP styling system is different enough from WPF to require extra effort during porting. UWP uses the VistualStateManger instead of concepts like DataTriggers or EventTriggers from WPF. Styling/Templating are one of the main differences.
 * The ResourceDictionary XAML markup in UWP supports far fewer features than in WPF.
 * UWP seems to follow only the XAML/2006 spec instead of [XAML/2009]((https://docs.microsoft.com/en-us/dotnet/desktop-wpf/xaml-services/xaml-2009-language-features)) supported by WPF 
 * Several UWP controls are sealed and new controls cannot derive from them
 * For advanced rendering, UWP has fewer features built in. This requires falling back to Win2D or composition more often.
 * There are several namespaces differences in UWP and WPF. For example, WPF has System.Windows.Media.Colors while UWP moves this to Windows.UI.Colors.
 * TextBlock and TextBox, for example, do not allow 'null' values for string-type Text properties. Setting null to `Text` will crash the app at runtime. This is one of the largest concerns when porting over from WPF as WPF accepts null without an issue; yet the same code may crash in UWP. The solution is to use `.Text = stringValue ?? string.Empty;` for all controls instead of setting a string directly.
 * In WPF it was possible to build templates using the [FrameworkElementFactory Class](https://docs.microsoft.com/en-us/dotnet/api/system.windows.frameworkelementfactory?view=netcore-3.1) without using XAML. This allowed for entire UI's to be created without markup (since instantiating controls is already possible in C# directly). However, the burden of maintaining two different ways of doing things became too much and Microsoft dropped this ability in UWP and deprecated it for WPF. Instead, it's necessary to write template XAML as a string in code then pass it to XamlReader.Load().

## Controls

This section describes the differences in controls in vanilla WPF and UWP (with the WinUI 2.x library). It excludes some primitives and shapes (Ellipse, Rect, etc.)

| WPF |	UWP |	Comments |
|-----|-----|----------|
| &#10006;                 |	AppBarButton	          | |
| &#10006;                 |	AppBarSeparator	       | |
| &#10006;                 | AppBarToggleButton	    | |
| &#10006;                 |	AutoSuggestBox	        | |
| Border                   |	Border	                | |
| BulletDecorator	         |	&#10006;               | |
| Button                   |	Button	                | |
| DatePicker               |	CalendarDatePicker	    | UWP DatePicker is different from WPF DatePicker. The WPF DatePicker is closer to the UWP CalendarDatePicker in functionality. |
| Calendar	                | CalendarView	          | |
| Canvas	                  | Canvas                 | |	
| &#10006;                 |	CaptureElement	        | |
| CheckBox                 |	CheckBox	              | |
| &#10006;                 |	ColorPicker	           | |
| ComboBox	                | ComboBox               | |	
| ToolBar                  |	CommandBar	            | |
| &#10006;                 |	CommandBarFlyout	      | First introduced in the Windows UI Library |	
| ContentControl           | ContentControl	        | |
| ContentPresenter         |	ContentPresenter	      | |
| DataGrid	                | &#10006;               | Available for UWP in the Windows Community Toolkit (albeit with many bugs) |
| &#10006;                 |	DatePicker	            | A picker to select a date without a calendar view does not exist in WPF. |
| &#10006;                 |	DatePickerFlyout	      | |
| DockPanel		              |	&#10006;               | Available for UWP in the Windows Community Toolkit |
| DocumentViewer		         |	&#10006;               | |
| &#10006;                 |	DropDownButton	        | First introduced in the Windows UI Library |
| Expander	                | &#10006;               |	Available for UWP in the Windows Community Toolkit |
| &#10006;                 |	FlipView	              | |
| FlowDocumentPageViewer		 |	&#10006;               | |
| FlowDocumentReader		     |	&#10006;               | |
| FlowDocumentScrollViewer |	&#10006;               | |
| &#10006;                 |	Flyout	                | |
| Frame                    |	Frame	                 | |
| Grid                     |	Grid                   | |	
| GridSplitter	            | &#10006;               |	Available for UWP in the Windows Community Toolkit |
| &#10006;                 |	GridView	              | |
| GroupBox		               | &#10006;               | |
| &#10006;                 |	Hub	                   | |
| &#10006;                 |	HubSection	            | |
| &#10006;                 |	HyperlinkButton	       | |
| Image                    |	Image	                 | |
| &#10006;                 |	InkCanvas	             | |
| &#10006;                 |	InkToolbar	            | |
| ItemsControl             |	ItemsControl	          | |
| &#10006;                 |	ItemsPresenter	        | |
| &#10006;                 |	ItemsRepeater	         | First introduced in the Windows UI Library |
| Label		                  | &#10006;               | Exists in WPF to align with Windows Forms |
| ListBox                  |	ListBox	               | |
| ListView	                | ListView	              | |
| &#10006;                 | MapControl	            | |
| &#10006;                 |	MediaElement	          | |
| &#10006;                 |	MediaTransportControls	| |
| Menu                     |	MenuBar	               | First introduced in the Windows Community Toolkit then Windows UI Library |
| ContextMenu	             | MenuFlyout	            | |
| &#10006;                 |	NavigationView	        | |
| Panel		                  | &#10006;               | |
| &#10006;                 |	ParallaxView	          | |
| PasswordBox              |	PasswordBox	           | |
| &#10006;                 |	PersonPicture		        | |
| &#10006;                 |	Pivot		                | |
| &#10006;                 |	PivotItem		            | |
| Popup                    |	Popup		                | |
| PrintDialog		            |	&#10006;               | |
| ProgressBar              |	ProgressBar		          | |
| &#10006;                 |	ProgressRing		         | |
| &#10006;                 |	PullToRefresh		        | |
| RadioButton	             | RadioButton		          | |
| &#10006;                 |	RatingControl		        | |
| Rectangle                |	Rectangle		            | |
| &#10006;                 |	RefreshContainer	      | First introduced in the Windows UI Library |
| &#10006;                 |	RelativePanel		        | |
| RepeatButton             |	RepeatButton	          | |
| RichTextBox              |	RichEditBox	           | |
| &#10006;                 |	RichTextBlock	         | |
| &#10006;                 |	RichTextBlockOverflow	 | |
| ScrollBar	               | ScrollBar	             | |
| ScrollContentPresenter   |	ScrollContentPresenter	| |
| ScrollViewer	            | ScrollViewer	          | |
| &#10006;                 | SearchBox              | |
| &#10006;                 |	SemanticZoom	          | |
| Separator		              | &#10006;               | |
| Slider	                  | Slider                 | |
| &#10006;                 |	SplitButton	           | First introduced in the Windows UI Library |
| &#10006;                 |	SplitView	             | |
| StackPanel	              | StackPanel	            | |
| StatusBar		              | &#10006;               | No longer a UI convention |
| &#10006;                 | SwipeControl	          | First introduced in the Windows UI Library |
| TabControl	              | TabView	               | First introduced in the Windows UI Library but now exists as part of WinUI. Originally, Pivot was used to replace tabs. |
| &#10006;                 |	TeachingTip            |	First introduced in the Windows UI Library |
| TextBlock                |	TextBlock	             | |
| TextBox                  |	TextBox	               | |
| &#10006;                 |	TimePicker	            | |
| &#10006;                 |	TimePickerFlyout	      | |
| ToggleButton             |	ToggleButton	          | |
| &#10006;                 |	ToggleSplitButton	     | First introduced in the Windows UI Library |
| &#10006;                 |	ToggleSwitch	          | |
| ToolTip	                 | ToolTip	               | |
| TreeView                 |	TreeView	              | |
| &#10006;                 |	TwoPaneView	           | First introduced in the Windows UI Library |
| &#10006;                 |	VariableSizedWrapGrid	 | |
| Viewbox	                 | Viewbox	               | |
| &#10006;                 | WebView	               | |
| WrapPanel		              | &#10006;               | Available for UWP in the Windows Community Toolkit |
| Window	                  | &#10006;               |	There is no top-level window concept in UWP |

## References

 1. http://dansuleski.com/so-what-else-could-be-missing-in-uwp/
 2. https://github.com/microsoft/microsoft-ui-xaml/issues/719

## Additional Resources

 * https://github.com/jbe2277/waf/wiki/UWP-vs.-WPF

## License

This document is licensed [CC BY-SA 4.0](https://creativecommons.org/licenses/by-sa/4.0/). For full text see: https://creativecommons.org/licenses/by-sa/4.0/legalcode