<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClearableTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        btnClear = New Button()
        txtValue = New TextBox()
        lblTitle = New Label()
        SuspendLayout()
        ' 
        ' btnClear
        ' 
        btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClear.Location = New Point(157, 23)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(31, 23)
        btnClear.TabIndex = 5
        btnClear.Text = "↻"
        btnClear.UseVisualStyleBackColor = True
        ' 
        ' txtValue
        ' 
        txtValue.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtValue.Location = New Point(3, 23)
        txtValue.Name = "txtValue"
        txtValue.Size = New Size(148, 23)
        txtValue.TabIndex = 4
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(3, 5)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(38, 15)
        lblTitle.TabIndex = 3
        lblTitle.Text = "label1"
        ' 
        ' ClearableTextBox
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnClear)
        Controls.Add(txtValue)
        Controls.Add(lblTitle)
        MinimumSize = New Size(84, 53)
        Name = "ClearableTextBox"
        Size = New Size(191, 53)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private WithEvents btnClear As Button
    Private WithEvents txtValue As TextBox
    Private WithEvents lblTitle As Label
End Class
