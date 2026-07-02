Imports System.Windows
Imports System.Windows.Controls
Imports System.Text.RegularExpressions

Namespace SDKSample

    Public Class FindDialogBox
        Inherits Window

        Public Event TextFound As TextFoundEventHandler

        Protected Overridable Sub OnTextFound()
            RaiseEvent TextFound(Me, EventArgs.Empty)
        End Sub

        Private _index As Integer
        Private _length As Integer
        Private matches As MatchCollection
        Private matchIndex As Integer
        Private textBoxToSearch As TextBox

        Public Sub New(ByVal textBoxToSearch As TextBox)
            Me.matchIndex = 0
            Me.Index = 0
            Me.Length = 0
            Me.InitializeComponent()
            Me.textBoxToSearch = textBoxToSearch
            AddHandler Me.textBoxToSearch.TextChanged, New TextChangedEventHandler(AddressOf Me.textBoxToSearch_TextChanged)
        End Sub

        Private Sub criteria_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.ResetFind()
        End Sub

        Private Sub findNextButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim textToFind As String = Me.findWhatTextBox.Text

            ' Short-circuit: Did the user not provide any text at all?
            If String.IsNullOrEmpty(textToFind) Then Return

            If (Me.matches Is Nothing) Then
                Dim matchOptions As RegexOptions = RegexOptions.None

                ' Escape the user-typed text in case it contains regex special characters.
                Dim pattern As String = Regex.Escape(textToFind)

                ' Match whole word?
                If Me.matchWholeWordCheckBox.IsChecked.Value Then
                    If BeginsWithRegexWordChar(textToFind) Then pattern = "\b" & pattern
                    If EndsWithRegexWordChar(textToFind) Then pattern = pattern & "\b"
                End If

                ' Case sensitive
                If Not Me.caseSensitiveCheckBox.IsChecked.Value Then matchOptions = matchOptions Or RegexOptions.IgnoreCase

                ' Find matches
                Me.matches = Regex.Matches(Me.textBoxToSearch.Text, pattern, matchOptions)
                Me.matchIndex = 0
                If (Me.matches.Count = 0) Then
                    MessageBox.Show(("'" & Me.findWhatTextBox.Text & "' not found."), "Find")
                    Me.matches = Nothing
                    Return
                End If
            End If
            If (Me.matchIndex = Me.matches.Count) Then
                Dim result As MessageBoxResult = MessageBox.Show("No more matches found. Start at beginning?", "Find", MessageBoxButton.YesNo)
                If (result = MessageBoxResult.No) Then
                    Return
                End If
                Me.matchIndex = 0
            End If
            Dim match As Match = Me.matches.Item(Me.matchIndex)

            Me.Index = match.Index
            Me.Length = match.Length
            RaiseEvent TextFound(Me, EventArgs.Empty)

            Me.matchIndex += 1
        End Sub

        Private Shared Function BeginsWithRegexWordChar(ByVal literal As String) As Boolean
            If String.IsNullOrEmpty(literal) Then Return False
            Return Regex.IsMatch(literal(0).ToString(), "\w")
        End Function

        Private Shared Function EndsWithRegexWordChar(ByVal literal As String) As Boolean
            If String.IsNullOrEmpty(literal) Then Return False
            Return Regex.IsMatch(literal(literal.Length - 1).ToString(), "\w")
        End Function

        Private Sub findWhatTextBox_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
            Me.ResetFind()
        End Sub

        Private Sub ResetFind()
            Me.findNextButton.IsEnabled = True
            Me.matches = Nothing
        End Sub

        Private Sub textBoxToSearch_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
            Me.ResetFind()
        End Sub

        Public Property Index() As Integer
            Get
                Return Me._index
            End Get
            Set(ByVal value As Integer)
                Me._index = value
            End Set
        End Property

        Public Property Length() As Integer
            Get
                Return Me._length
            End Get
            Set(ByVal value As Integer)
                Me._length = value
            End Set
        End Property

        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MyBase.Close()
        End Sub
    End Class
End Namespace
