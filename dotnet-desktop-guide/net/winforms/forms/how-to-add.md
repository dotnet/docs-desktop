---
title: "Add a form to a project"
description: "Add a new form to a .NET Windows Forms project in Visual Studio"
ms.date: 10/26/2020
helpviewer_keywords:
  - "Windows Forms, create add form"
---

# How to add a form to a project (Windows Forms .NET)

Add forms to your project with Visual Studio. When your app has multiple forms, you can choose which is the startup form for your app, and you can display multiple forms at the same time.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Add a new form

Add a new form with Visual Studio.

01. In Visual Studio, find the **Project Explorer** pane. Right-click on the project and choose **Add** > **Form (Windows Forms)**.

    :::image type="content" source="media/how-to-add/right-click.png" alt-text="Right click solution explorer to add new form to windows forms project":::

01. In the **Name** box, type a name for your form, such as _MyNewForm_. Visual Studio will provide a default and unique name that you may use.

    :::image type="content" source="media/how-to-add/new-form-dialog.png" alt-text="Add item dialog in visual studio for windows forms":::

Once the form has been added, Visual Studio opens the form designer for the form.

## Add a project reference to a form

If you have the source files to a form, you can add the form to your project by copying the files into the same folder as your project. The project automatically references any code files that are in the same folder or child folder of your project.

Forms are made up of two files that share the same name: _form2.cs_ (_form2_ being an example of a file name) and _form2.Designer.cs_. Sometimes a resource file exists, sharing the same name, _form2.resx_. In in the previous example, _form2_ represents the base file name. You'll want to copy all related files to your project folder.

Alternatively, you can use Visual Studio to import a file into your project. When you add an existing file to your project, the file is copied into the same folder as your project.

01. In Visual Studio, find the **Project Explorer** pane. Right-click on the project and choose **Add** > **Existing Item**.

    :::image type="content" source="media/how-to-add/existing-right-click.png" alt-text="Right click solution explorer to add existing form to windows forms project":::

02. Navigate to the folder containing your form files.

03. Select the _form2.cs_ file, where _form2_ is the base file name of the related form files. Don't select the other files, such as _form2.Designer.cs_.

## See also

- [How to position and size a form (Windows Forms .NET)](how-to-position-and-resize.md)
- [Events overview (Windows Forms .NET)](events.md)
- [Position and layout of controls (Windows Forms .NET)](../controls/layout.md)
