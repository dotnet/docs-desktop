Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblGreeting = New Label()
        btnGreet = New Button()
        SuspendLayout()
        ' 
        ' lblGreeting
        ' 
        lblGreeting.AutoSize = True
        lblGreeting.Location = New Point(20, 20)
        lblGreeting.Name = "lblGreeting"
        lblGreeting.Size = New Size(0, 20)
        lblGreeting.TabIndex = 0
        ' 
        ' btnGreet
        ' 
        btnGreet.Location = New Point(20, 50)
        btnGreet.Name = "btnGreet"
        btnGreet.Size = New Size(100, 30)
        btnGreet.TabIndex = 1
        btnGreet.Text = "Greet"
        ' 
        ' Form1
        ' 
        ClientSize = New Size(300, 120)
        Controls.Add(lblGreeting)
        Controls.Add(btnGreet)
        Name = "Form1"
        Text = "Host Builder App"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblGreeting As System.Windows.Forms.Label
    Friend WithEvents btnGreet As System.Windows.Forms.Button

End Class
