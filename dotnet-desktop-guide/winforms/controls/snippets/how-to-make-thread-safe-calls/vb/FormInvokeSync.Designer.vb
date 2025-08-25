<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvokeSync
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Button1 = New System.Windows.Forms.Button()
        TextBox1 = New System.Windows.Forms.TextBox()
        Button2 = New System.Windows.Forms.Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New System.Drawing.Point(27, 176)
        Button1.Name = "Button1"
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Good"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New System.Drawing.Point(27, 53)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New System.Drawing.Size(235, 90)
        TextBox1.TabIndex = 1
        ' 
        ' Button2
        ' 
        Button2.Location = New System.Drawing.Point(27, 205)
        Button2.Name = "Button2"
        Button2.Size = New System.Drawing.Size(75, 23)
        Button2.TabIndex = 2
        Button2.Text = "Bad"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' FormInvokeSync
        ' 
        AutoScaleDimensions = New System.Drawing.SizeF(7F, 15F)
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        ClientSize = New System.Drawing.Size(800, 450)
        Controls.Add(Button2)
        Controls.Add(TextBox1)
        Controls.Add(Button1)
        Name = "FormInvokeSync"
        Text = "FormThread"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
