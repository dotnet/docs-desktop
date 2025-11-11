Imports System
Imports System.Collections.Generic
Imports System.Reflection.Metadata
Imports System.Windows.Forms

Namespace ClipboardExamples
    Public Class TestConfigurationExample

        Public Class Person
            Public Property Name As String
            Public Property Age As Integer
        End Class

        ' <TestConfiguration>
        Public Shared Sub TestBinaryFormatterConfiguration()
            ' Test data to verify configuration
            Dim testPerson As New Person With {.Name = "Test User", .Age = 30}

            Try
                ' Test storing data (this should work with proper configuration)
                Clipboard.SetData("TestPerson", testPerson)
                Console.WriteLine("Successfully stored test data on clipboard")

                ' Test retrieving with type resolver
                Dim retrievedPerson As Person = Nothing
                If Clipboard.TryGetData("TestPerson", AddressOf SecureTypeResolver, retrievedPerson) Then
                    Console.WriteLine($"Successfully retrieved: {retrievedPerson.Name}, Age: {retrievedPerson.Age}")
                Else
                    Console.WriteLine("Failed to retrieve test data")
                End If

                ' Test that unauthorized types are rejected
                Try
                    Dim testResult As Person = Nothing
                    Clipboard.TryGetData("TestPerson", AddressOf UnauthorizedTypeResolver, testResult)
                    Console.WriteLine("ERROR: Unauthorized type was not rejected!")
                Catch ex As InvalidOperationException
                    Console.WriteLine($"SUCCESS: Unauthorized type properly rejected - {ex.Message}")
                End Try

            Catch ex As Exception
                Console.WriteLine($"Configuration test failed: {ex.Message}")
            End Try
        End Sub

        Private Shared Function SecureTypeResolver(typeName As TypeName) As Type
            Dim allowedTypes As New Dictionary(Of String, Type) From {
                {"ClipboardExamples.Person", GetType(Person)}
            }

            Dim allowedType As Type = Nothing
            If allowedTypes.TryGetValue(typeName.FullName, allowedType) Then
                Return allowedType
            End If

            Throw New InvalidOperationException($"Type '{typeName.FullName}' is not permitted")
        End Function

        Private Shared Function UnauthorizedTypeResolver(typeName As TypeName) As Type
            ' Intentionally restrictive resolver to test rejection
            Throw New InvalidOperationException($"No types are permitted by this test resolver")
        End Function
        ' </TestConfiguration>

    End Class
End Namespace