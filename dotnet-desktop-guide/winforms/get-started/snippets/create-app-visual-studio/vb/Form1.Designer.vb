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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lstNames = New System.Windows.Forms.ListBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(138, 55)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add Name"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(138, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 23)
        Me.txtName.TabIndex = 6
        '
        'lstNames
        '
        Me.lstNames.FormattingEnabled = True
        Me.lstNames.ItemHeight = 15
        Me.lstNames.Location = New System.Drawing.Point(12, 27)
        Me.lstNames.Name = "lstNames"
        Me.lstNames.Size = New System.Drawing.Size(120, 94)
        Me.lstNames.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(44, 15)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Names"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(252, 141)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lstNames)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Names"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents btnAdd As Button
    Private WithEvents txtName As TextBox
    Private WithEvents lstNames As ListBox
    Private WithEvents label1 As Label
End Class
