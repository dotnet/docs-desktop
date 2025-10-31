Goal:
The control documentation for WPF is very out-of-date. Most articles show Windows XP screenshots of the controls.

I had AI look at the controls section of the TOC, which lists all of these controls, and then build me a list of each control covered by this reference material

I then fed that list into another AI and told it to genereate me a WPF testing app that could list all of these controls on the left, along with a display section on the right, so that I could capture new screenshots.

After a little bit of iteration on the content, I was able to get the app designed to my liking.

Next:

I then needed to generate a PLAN file that describes the problem I have, the goals I want to achieve, and the detailed steps to complete the goals.

- I gave AI a link to the GitHub issue I was working on. It had some basic information about what was wrong and what I could do to fix it. From that I had it write the problem statement and suggested fix based on the conversation in the issue.

- I hand edited the result to include some extra details that I knew about, then asked it to create a comprehensive plan to address the issue.

Next:

I told AI to create a comprehensive reference mapping each WPF control to its category and documentation file path within the repository. Then evaluate what it has in the docuemntation file and what's missing (such as screenshots). This was put in the CONTROL-REFERENCE.md file:

```
| Control | Category | File Path | Missing Content | Priority |
|---------|----------|-----------|----------------|----------|
| Border | Layout Controls | `dotnet-desktop-guide/wpf/controls/border.md` | Minimal content, no overview, no screenshots, missing examples | High |
| Canvas | Layout Controls | `dotnet-desktop-guide/wpf/controls/canvas.md` | Minimal content, no overview, no screenshots, missing examples | High |
| DockPanel | Layout Controls | `dotnet-desktop-guide/wpf/controls/dockpanel.md` | Minimal content, no overview, no screenshots, missing examples | High |
```

Next:

I cloned the WPF code repository, opened it in visual studio, then asked AI to build me a list of controls, what code file they're located in and add the details to CONTROL-REFERENCE.md.

Then I asked AI to split all of this out into individual markdown files, one for each control that had simple information, like

```markdown
# Control
**CodeFile**: path/to/file.cs
```

Then I created a complex prompt that could be run on each control.md file to gather information about it in the source code:

```markdown
---
mode: agent
---
You're researching information about WPF and updating the markdown files related to controls. The markdown file is a reference file that doesn't need any extra paragraphs or descriptions, it will be used later to generate documentation. Don't read other markdown files, only use source code files to gather information.

You don't need to build any workspace or compile any files.

Process the controls in context. The markdown file at least has the path to the source code of the control, defined by the **CodeFile** value. Other information might be incorrect. You must replace all information with correct information from the source code file. Gather the following information about the control and update the markdown file according to the template below. Two exmaple templates are included, one for the Calendar control and one for the Button control (when updating those controls still research the information from the source code):

## Template filled out for Calendar

````
# Calendar

- **ControlName**: Calendar
- **CodeFile**: System/Windows/Controls/Calendar.cs
- **BaseClass**: Control
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Root | Panel | The root panel that contains the calendar layout. |
| PART_CalendarItem | CalendarItem | The calendar item that displays the month, year, or decade view. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
````

## Template filled out for Button

````
# Button

- **ControlName**: Button
- **CodeFile**: System/Windows/Controls/Button.cs
- **BaseClass**: ButtonBase
- **ControlType**: ContentControl
- **ContentProperty**: Content

## Template parts

This control doesn't define any template parts.

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Normal | CommonStates | The control is in its normal state. |
| MouseOver | CommonStates | The mouse is over the control. |
| Pressed | CommonStates | The control is pressed. |
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
````

## Template instructions

The following information describe the parts of the template:

- **ControlName**: The name of the control class.
- **CodeFile**: The path to the code file for the control.
- **BaseClass**: The direct base class of the control.
- **ControlType**: Determine the control type by checking if the control derives from `ContentControl`, `HeaderedContentControl`, `ItemsControl`, or none of these (in which case it is just a `Control`).
- **ContentProperty**: Check if the control class has a `ContentProperty` attribute. Check if any base class in the inheritance chain has a `ContentProperty` attribute. If found, use the value of the attribute as the content property. If no `ContentProperty` attribute is found in the inheritance chain, use `None`.
- **Template parts**: Look for a `TemplatePart` attribute that defines a template part name and type. Gather all template parts defined on the control and its base classes up to the first base class. Most template parts names are defined with a constant, use the constant value as the part name.
- **Visual states**: Use the following steps to determine the visual states used by a control:
  1. In the control's source code, if the control overrides `ChangeVisualState` and then calls a `GoToState` method, gather the visual states names and their group (group is defined elsewhere, like the control style in the default theme file`src/Microsoft.DotNet.Wpf/src/Themes/PresentationFramework.Aero2/themes/Aero2.NormalColor.xaml`).
  2. Check the class inheritance chain for an override of `ChangeVisualState`.
  **NOTE**: The base class `Control` defines the state group `ValidationStates` with the states of `Valid`, `InvalidFocused`, and `InvalidUnfocused`. As long as the inheritence chain calls `ChangeVisualState`, these states should be included for the control. Always place `ValidationStates` at the end of the visual states table.
  **HINT**: Code files with the pattern `**/*visualstate*.cs` may have visual state names and group names defined to help identifying the name value of a visual state.
```

Next

I ran through every .md file I had previously generated (86 files) and ran the prompt in Visual Studio GitHub Copilot to scan the WPF code base for information about each control and fill out the .md file. I had a hard time keeping AI in control to mass generate information about each control. In the end, I needed to process every file individually through the reusable prompt. Even still, sometimes it would veer of course and pull in and edit other files. In those moments I needed to **Undo** the action and try again.

In the end, I got a markdown file filled out for each control that looked like the following:

```markdown
# Calendar

- **ControlName**: Calendar
- **CodeFile**: System/Windows/Controls/Calendar.cs
- **BaseClass**: Control
- **ControlType**: Control
- **ContentProperty**: None

## Template parts

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_Root | Panel | The root panel that contains the calendar layout. |
| PART_CalendarItem | CalendarItem | The calendar item that displays the month, year, or decade view. |

## Visual states

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but does not have keyboard focus. |
```

Next

I copied the control files to the documentation repository so that I could use AI to update each control ref documentation with the current state of the control.


