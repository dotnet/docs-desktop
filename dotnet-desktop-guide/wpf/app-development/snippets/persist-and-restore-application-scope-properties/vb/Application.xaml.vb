Imports System.IO
Imports System.IO.IsolatedStorage

Class Application

    Private _filename As String = "App.data"

    Public Sub New()
        ' Initialize application-scope property
        Properties("NumberOfAppSessions") = "0"
    End Sub

    Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
        ' Restore application-scope property from isolated storage
        Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForDomain()
        Try
            If storage.FileExists(_filename) Then

                Using stream As IsolatedStorageFileStream = storage.OpenFile(_filename, FileMode.Open, FileAccess.Read)
                    Using reader As New StreamReader(stream)

                        ' Restore each application-scope property individually
                        Do While Not reader.EndOfStream
                            Dim keyValue() As String = reader.ReadLine().Split(New Char() {","c})
                            Properties(keyValue(0)) = keyValue(1)
                        Loop

                    End Using
                End Using

            End If

        Catch ex As DirectoryNotFoundException
            ' Path the file didn't exist
        Catch ex As IsolatedStorageException
            ' Storage was removed or doesn't exist
            ' -or-
            ' If using .NET 6+ the inner exception contains the real cause
        End Try
    End Sub

    Private Sub App_Exit(ByVal sender As Object, ByVal e As ExitEventArgs)
        'Increase the amount of times the app was opened
        Properties("NumberOfAppSessions") = Integer.Parse(DirectCast(Properties("NumberOfAppSessions"), String)) + 1

        ' Persist application-scope property to isolated storage
        Dim storage As IsolatedStorageFile = IsolatedStorageFile.GetUserStoreForDomain()

        Using stream As IsolatedStorageFileStream = storage.OpenFile(_filename, FileMode.Create, FileAccess.Write)
            Using writer As New StreamWriter(stream)

                ' Persist each application-scope property individually
                For Each key As String In Properties.Keys
                    writer.WriteLine("{0},{1}", key, Properties(key))
                Next key

            End Using
        End Using
    End Sub

End Class
