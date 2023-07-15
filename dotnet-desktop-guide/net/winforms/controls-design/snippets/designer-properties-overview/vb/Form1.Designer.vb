<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        ctlFirstName = New ClearableTextBox()
        ctlLastName = New ClearableTextBox()
        lblFullName = New Label()
        SuspendLayout()
        ' 
        ' ctlFirstName
        ' 
        ctlFirstName.Location = New Point(12, 12)
        ctlFirstName.MinimumSize = New Size(84, 53)
        ctlFirstName.Name = "ctlFirstName"
        ctlFirstName.Size = New Size(191, 53)
        ctlFirstName.TabIndex = 0
        ctlFirstName.Title = "First Name"
        ' 
        ' ctlLastName
        ' 
        ctlLastName.Location = New Point(12, 71)
        ctlLastName.MinimumSize = New Size(84, 53)
        ctlLastName.Name = "ctlLastName"
        ctlLastName.Size = New Size(191, 53)
        ctlLastName.TabIndex = 1
        ctlLastName.Title = "Last Name"
        ' 
        ' lblFullName
        ' 
        lblFullName.AutoSize = True
        lblFullName.Location = New Point(12, 252)
        lblFullName.Name = "lblFullName"
        lblFullName.Size = New Size(41, 15)
        lblFullName.TabIndex = 2
        lblFullName.Text = "Label1"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(416, 276)
        Controls.Add(lblFullName)
        Controls.Add(ctlLastName)
        Controls.Add(ctlFirstName)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ctlFirstName As ClearableTextBox
    Friend WithEvents ctlLastName As ClearableTextBox
    Friend WithEvents lblFullName As Label
End Class
