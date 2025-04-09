Imports System.Drawing
Imports System.Windows.Forms

Public Class Form2
    Private _lastClick As Date
    Private _inDoubleClick As Boolean
    Private _doubleClickArea As Rectangle
    Private _doubleClickMaxTime As TimeSpan
    Private _singleClickAction As Action
    Private _doubleClickAction As Action
    Private WithEvents _clickTimer As Timer

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _doubleClickMaxTime = TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime)

        _clickTimer = New Timer()
        _clickTimer.Interval = SystemInformation.DoubleClickTime

        _singleClickAction = Sub()
                                 MessageBox.Show("Single click")
                             End Sub

        _doubleClickAction = Sub()
                                 MessageBox.Show("Double click")
                             End Sub
    End Sub

    Private Sub Form2_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If _inDoubleClick Then

            _inDoubleClick = False

            Dim length As TimeSpan = Date.Now - _lastClick

            ' If double click is valid, respond
            If _doubleClickArea.Contains(e.Location) And length < _doubleClickMaxTime Then
                _clickTimer.Stop()
                Call _doubleClickAction()
            End If

            Return
        End If

        ' Double click was invalid, restart 
        _clickTimer.Stop()
        _clickTimer.Start()
        _lastClick = Date.Now
        _inDoubleClick = True
        _doubleClickArea = New Rectangle(e.Location - (SystemInformation.DoubleClickSize / 2),
                                         SystemInformation.DoubleClickSize)
    End Sub

    Private Sub SingleClickTimer_Tick(sender As Object, e As EventArgs) Handles _clickTimer.Tick
        ' Clear double click watcher and timer
        _inDoubleClick = False
        _clickTimer.Stop()

        Call _singleClickAction()
    End Sub

End Class
