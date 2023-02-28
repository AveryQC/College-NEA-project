Imports System.IO

Public Class SaveFileException
    Inherits Exception

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class

Module Module1
    Function FindFile(ByVal filename As String) As Integer
        Try
            Using reader As New StreamReader(filename & ".txt")
                While Not reader.EndOfStream
                    Console.WriteLine(reader.ReadLine())
                End While
            End Using
        Catch ex As FileNotfoundException
            Throw New SaveFileException("File not found")
        End Try

    End Function

    Sub Main()
        Dim loopal As Boolean = True
        While loopal
            Try
                Console.Write("Enter a filename (without the extension): ")
                Dim savefileName As String = Console.ReadLine()
                FindFile(savefileName)
            Catch ex As SaveFileException
                Console.WriteLine(ex.Message)
                Console.WriteLine("Press any key to terminate the program")
                loopal = False
            End Try
            Console.WriteLine()
        End While

        Console.ReadKey()
    End Sub
End Module
