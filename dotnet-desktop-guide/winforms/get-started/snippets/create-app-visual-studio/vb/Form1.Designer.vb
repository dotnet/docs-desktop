<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnAdd = New Button()
        Label1 = New Label()
        txtName = New TextBox()
        lstNames = New ListBox()
        SuspendLayout()
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(163, 115)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(75, 23)
        btnAdd.TabIndex = 0
        btnAdd.Text = "Button1"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(34, 43)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(118, 43)
        txtName.Name = "txtName"
        txtName.Size = New Size(100, 23)
        txtName.TabIndex = 2
        ' 
        ' lstNames
        ' 
        lstNames.FormattingEnabled = True
        lstNames.Location = New Point(12, 91)
        lstNames.Name = "lstNames"
        lstNames.Size = New Size(120, 94)
        lstNames.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lstNames)
        Controls.Add(txtName)
        Controls.Add(Label1)
        Controls.Add(btnAdd)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents lstNames As ListBox

End Class
