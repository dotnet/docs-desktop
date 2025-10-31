# WPF Controls Template Parts and Categorization Table

This table provides a comprehensive overview of WPF controls, their template parts (including inherited parts from base classes), and their categorization as Content Controls, Header Controls, etc.

## Table of Controls

| Control Name | Base Class | Control Type | Template Parts | Inherited Template Parts | Description |
|--------------|------------|--------------|---------------|-------------------------|-------------|
| **Button** | ButtonBase | Content Control | None | None | Basic button control |
| **CheckBox** | ToggleButton | Content Control | None | None | Checkbox control |
| **RadioButton** | ToggleButton | Content Control | None | None | Radio button control |
| **ComboBox** | Selector | Content Control | PART_EditableTextBox (TextBox)<br>PART_Popup (Popup) | None | Dropdown selection control |
| **ComboBoxItem** | ListBoxItem | Content Control | None | None | Individual item in ComboBox |
| **DatePicker** | Control | Content Control | PART_Root (Grid)<br>PART_TextBox (DatePickerTextBox)<br>PART_Button (Button)<br>PART_Popup (Popup) | None | Date selection control |
| **Calendar** | Control | Content Control | PART_Root (Panel)<br>PART_CalendarItem (CalendarItem) | None | Calendar date selection control |
| **CalendarItem** | Control | Content Control | PART_Root (FrameworkElement)<br>PART_HeaderButton (Button)<br>PART_PreviousButton (Button)<br>PART_NextButton (Button)<br>PART_MonthView (Grid)<br>PART_YearView (Grid)<br>PART_DisabledVisual (FrameworkElement)<br>DayTitleTemplate (DataTemplate) | None | Calendar month/year/decade display |
| **CalendarDayButton** | Button | Content Control | None | None | Individual day button in calendar |
| **CalendarButton** | Button | Content Control | None | None | Month/year button in calendar |
| **ScrollViewer** | ContentControl | Content Control | PART_HorizontalScrollBar (ScrollBar)<br>PART_VerticalScrollBar (ScrollBar)<br>PART_ScrollContentPresenter (ScrollContentPresenter) | None | Scrollable content container |
| **TabControl** | Selector | Content Control | PART_SelectedContentHost | None | Tabbed content container |
| **PasswordBox** | Control | Content Control | PART_ContentHost | None | Password input control |
| **GridViewColumnHeader** | ButtonBase | Header Control | PART_HeaderGripper (Thumb)<br>PART_FloatingHeaderCanvas (Canvas) | None | Column header with resize gripper |
| **ContentControl** | Control | Content Control | None | None | Base class for content controls |
| **HeaderedContentControl** | ContentControl | Header + Content Control | None | None | Base class for controls with header and content |
| **ItemsControl** | Control | Items Control | None | None | Base class for item container controls |
| **HeaderedItemsControl** | ItemsControl | Header + Items Control | None | None | Base class for item controls with headers |
| **ListBox** | Selector | Items Control | None | None | List selection control |
| **ListBoxItem** | ContentControl | Content Control | None | None | Individual item in ListBox |
| **ListView** | ListBox | Items Control | None | None | Enhanced list view control |
| **TreeView** | ItemsControl | Items Control | None | None | Hierarchical tree control |
| **Menu** | MenuBase | Items Control | None | None | Menu control |
| **ToolBar** | HeaderedItemsControl | Items Control | None | None | Toolbar control |
| **StatusBar** | ItemsControl | Items Control | None | None | Status bar control |
| **StatusBarItem** | ContentControl | Content Control | None | None | Individual item in StatusBar |
| **TextBox** | TextBoxBase | Content Control | PART_ContentHost | None | Text input control |
| **RichTextBox** | TextBoxBase | Content Control | PART_ContentHost | None | Rich text input control |
| **ProgressBar** | RangeBase | Content Control | PART_Track (FrameworkElement)<br>PART_Indicator (FrameworkElement)<br>PART_GlowRect (FrameworkElement) | None | Progress indicator |
| **Slider** | RangeBase | Content Control | PART_Track (Track)<br>PART_SelectionRange (FrameworkElement) | None | Value selection slider |
| **ScrollBar** | RangeBase | Content Control | None | None | Scroll bar control |
| **Expander** | HeaderedContentControl | Header + Content Control | None | None | Expandable content container |
| **GroupBox** | HeaderedContentControl | Header + Content Control | None | None | Grouped content container |
| **TabItem** | HeaderedContentControl | Header + Content Control | None | None | Individual tab item |
| **TreeViewItem** | HeaderedItemsControl | Header + Items Control | None | None | Individual tree node |
| **MenuItem** | HeaderedItemsControl | Header + Items Control | None | None | Individual menu item |
| **ToolTip** | ContentControl | Content Control | None | None | Tooltip display |
| **Popup** | FrameworkElement | Primitive | None | None | Popup window primitive |
| **Thumb** | Control | Primitive | None | None | Draggable element primitive |
| **RepeatButton** | ButtonBase | Primitive | None | None | Auto-repeating button primitive |
| **ToggleButton** | ButtonBase | Primitive | None | None | Toggle state button primitive |
| **Border** | Decorator | Decorator | None | None | Border and background decorator |
| **Viewbox** | Decorator | Decorator | None | None | Scaling content decorator |
| **Canvas** | Panel | Panel | None | None | Absolute positioning panel |
| **StackPanel** | Panel | Panel | None | None | Sequential stacking panel |
| **WrapPanel** | Panel | Panel | None | None | Wrapping layout panel |
| **DockPanel** | Panel | Panel | None | None | Docking layout panel |
| **Grid** | Panel | Panel | None | None | Grid-based layout panel |
| **UniformGrid** | Panel | Panel | None | None | Uniform grid layout panel |

## Control Categorization

### Content Controls
Controls that can contain a single child element:
- ContentControl (base)
- Button, CheckBox, RadioButton
- ComboBox, ComboBoxItem, DatePicker, Calendar
- ScrollViewer, TabControl
- PasswordBox, TextBox, RichTextBox
- ProgressBar, Slider, ScrollBar
- ToolTip, CalendarItem, CalendarDayButton, CalendarButton
- ListBoxItem, StatusBarItem

### Header Controls
Controls that have both a header and content:
- HeaderedContentControl (base)
- Expander, GroupBox, TabItem
- GridViewColumnHeader

### Items Controls
Controls that can contain multiple child items:
- ItemsControl (base)
- ListBox, ListView, TreeView
- Menu, ToolBar, StatusBar

### Header + Items Controls
Controls that have a header and can contain multiple items:
- HeaderedItemsControl (base)
- TreeViewItem, MenuItem

### Panels
Layout containers for arranging child elements:
- Panel (base)
- Canvas, StackPanel, WrapPanel
- DockPanel, Grid, UniformGrid

### Decorators
Controls that enhance a single child element:
- Decorator (base)
- Border, Viewbox

### Primitives
Low-level building blocks:
- Popup, Thumb, RepeatButton, ToggleButton

## Template Parts Details

### Common Template Part Patterns

1. **PART_ContentHost**: Used in text input controls (TextBox, RichTextBox, PasswordBox) to host the text content
2. **PART_Popup**: Used in dropdown controls (ComboBox, DatePicker) for the popup portion
3. **PART_ScrollViewer or scroll-related parts**: Used in scrollable controls
4. **PART_*Button**: Interactive button elements within composite controls (CalendarItem, DatePicker)
5. **PART_*Gripper**: Resizing handles (like in GridViewColumnHeader)
6. **PART_*View**: Different view modes (MonthView, YearView in CalendarItem)
7. **PART_Track**: Track elements for range-based controls (Slider, ProgressBar)
8. **PART_Indicator**: Progress/value indicator elements

### Control Template Part Details

#### Range-Based Controls
- **Slider**: Uses PART_Track (Track) for the slider track and PART_SelectionRange for selection visualization
- **ProgressBar**: Uses PART_Track for the background, PART_Indicator for progress display, and PART_GlowRect for indeterminate animation
- **ScrollBar**: Typically implemented with RepeatButton and Thumb primitives

#### Complex Controls
- **Calendar System**: Multi-level template structure with Calendar → CalendarItem → CalendarDayButton/CalendarButton
- **ComboBox**: Combines text input (PART_EditableTextBox) with dropdown (PART_Popup)
- **DatePicker**: Similar to ComboBox but specialized for date selection

### Calendar Control Complex Structure

The Calendar control system demonstrates complex template part hierarchies:
- **Calendar** contains **CalendarItem** as PART_CalendarItem
- **CalendarItem** has multiple template parts for navigation (PART_HeaderButton, PART_PreviousButton, PART_NextButton) and display views (PART_MonthView, PART_YearView)
- **CalendarDayButton** and **CalendarButton** are used within the CalendarItem's views

### Inheritance Hierarchy for Template Parts

Controls inherit template parts from their base classes, creating a cumulative set of available parts:

- **ContentControl** → provides content hosting functionality
- **HeaderedContentControl** → adds header functionality to ContentControl
- **ItemsControl** → provides items collection functionality  
- **HeaderedItemsControl** → adds header functionality to ItemsControl
- **Selector** → adds selection functionality to ItemsControl
- **RangeBase** → provides value range functionality
- **TextBoxBase** → provides text editing functionality
- **ButtonBase** → provides button functionality for Button, ToggleButton, RepeatButton

## Usage Notes

1. **Template Parts are Optional**: Controls can function without all template parts, but may lose some functionality
2. **Naming Convention**: Template parts follow the "PART_" prefix convention
3. **Type Safety**: Each template part specifies its expected type
4. **Inheritance**: Child classes inherit template part requirements from base classes
5. **Custom Templates**: When creating custom templates, include expected template parts for full functionality
6. **Complex Controls**: Some controls like Calendar have nested template structures with multiple levels of template parts
7. **Item Containers**: Controls like ListBoxItem, ComboBoxItem, StatusBarItem serve as containers for individual items in their parent controls

This table serves as a reference for WPF developers working with control templates and understanding the structure and capabilities of built-in WPF controls.