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
        CustomControl11 = New CustomControl1()
        SuspendLayout()
        ' 
        ' CustomControl11
        ' 
        CustomControl11.Location = New Point(12, 12)
        CustomControl11.Name = "CustomControl11"
        CustomControl11.Size = New Size(228, 117)
        CustomControl11.TabIndex = 0
        CustomControl11.Text = "CustomControl11"
        CustomControl11.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(252, 141)
        Controls.Add(CustomControl11)
        Name = "Form1"
        Text = "Custom Control VB"
        ResumeLayout(False)
    End Sub

    Friend WithEvents CustomControl11 As CustomControl1
End Class
