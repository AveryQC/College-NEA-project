Module Module1

    Sub Main()
        Console.WriteLine("Opening the menu")
        Dim myMenu As New MenuForm

        Console.Write("How many data points do you want to plot?: ")
        Dim maxpoints As Integer = Console.ReadLine()

        For i = 0 To maxpoints - 1
            Console.Write("Enter x value: ")
            Dim num1 As String = Console.ReadLine()
            Console.Write("Enter y value: ")
            Dim num2 As Integer = Console.ReadLine()
            myMenu.datadictionaryXY.Add(num1, num2)
        Next

        Console.Write("[L]eft or [R]ight hand mode? ")
        If Console.ReadLine() = "L" Then
            myMenu.changesetting = "L"
        Else
            myMenu.changesetting = "R"
        End If

        myMenu.ShowDialog()

        Console.WriteLine("Menu closed")
        Console.ReadKey()
    End Sub
End Module
