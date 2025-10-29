# WPF Control Screenshot App

This application provides a convenient way to take screenshots of individual WPF controls for documentation purposes.

## Features

- **Left Panel**: List of WPF controls to preview
- **Right Panel**: Clean preview area with screenshot functionality
- **Screenshot Capture**: Save PNG images of the selected control
- **Extensible**: Easy to add new control examples

## How to Use

1. **Select a Control**: Click on any control name in the left panel
2. **Preview**: The selected control will appear in the right panel preview area
3. **Take Screenshot**: Click the "Take Screenshot" button to save the control as a PNG image
4. **Save Location**: Choose where to save the screenshot file

## Adding New Control Pages

To add a new control page:

1. Copy the `Pages/TemplatePage.xaml` and `Pages/TemplatePage.xaml.cs` files
2. Rename them to `[ControlName]Page.xaml` and `[ControlName]Page.xaml.cs`
3. Update the `x:Class` attribute in the XAML to match: `AllTemplatesCS.Pages.[ControlName]Page`
4. Update the class name in the code-behind file
5. Replace the template content with your control examples
6. The control will automatically be available when you select it from the list

## Current Control Pages

The following controls already have example pages created:
- Border
- Button  
- CheckBox
- ComboBox
- Grid
- ListBox
- ProgressBar
- RadioButton
- Slider
- StackPanel
- TextBox

## Screenshot Area

The preview area has a generous border around it to ensure clean screenshots with proper whitespace. The background is white to provide good contrast for most controls.

## Controls Still Needed

You can create pages for the remaining controls listed in the left panel:
- BulletDecorator, Calendar, Canvas, ContextMenu, DataGrid, DatePicker
- DockPanel, DocumentViewer, Expander, FlowDocument controls, Frame
- GridSplitter, GroupBox, Image, Label, ListView, Menu, Panel
- PasswordBox, Popup, PrintDialog, RepeatButton, RichTextBox
- ScrollBar, ScrollViewer, Separator, StatusBar, TabControl
- TextBlock, ToolBar, ToolTip, TreeView, WrapPanel, Viewbox

## Technical Notes

- Built for .NET 10
- Uses WPF Frame navigation to switch between control examples
- Screenshot functionality uses RenderTargetBitmap for high-quality captures
- All control pages inherit from System.Windows.Controls.Page
