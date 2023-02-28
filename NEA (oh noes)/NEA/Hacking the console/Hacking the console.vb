Module Module1
    Sub PrintMenu1()
        Console.Clear()
        Console.WriteLine("To select an option, use the up & down arrows to navigate and press enter")
        Console.WriteLine("    New menu 1")
        Console.WriteLine("    Colour settings")
        Console.WriteLine("    Option 3")
        Console.WriteLine("    Exit")
    End Sub

    Sub PrintMenu2()
        Do
            Console.Clear()
            Console.WriteLine("To select an option, press the letter and press enter")
            Console.WriteLine("[A] Option A")
            Console.WriteLine("[B] Option B")
            Console.WriteLine("[X] Exit")
            Console.WriteLine("[0] Back")
            Dim userchoice As String = Console.ReadLine
            Select Case userchoice
                Case 0
                    Exit Do
                Case "A"
                    Console.WriteLine("Option A")
                    Threading.Thread.Sleep(2000)
                Case "B"
                    Console.WriteLine("Option B")
                    Threading.Thread.Sleep(2000)
                Case "X"
                    End
                Case Else
                    Console.WriteLine("Not valid")
                    Threading.Thread.Sleep(2000)
            End Select

        Loop
        Console.Clear()
    End Sub

    Sub PrintColourSettings()
        Console.Clear()
        Console.WriteLine("To select an option, use the up & down arrows to navigate and press enter")
        Console.WriteLine("    Change text colour")
        Console.WriteLine("    Display a picture")
        Console.WriteLine("    Exit")

        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        Console.Write(">>")
        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("  ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write(">>")
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 3 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("  ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write(">>")
                    End If
                Case ConsoleKey.Enter
                    Select Case Console.CursorTop
                        Case 1
                            ColourChange()
                            Exit Do
                        Case 2
                            Console.CursorTop = 4
                            Console.WriteLine(" >>------->")
                            Console.ReadKey()
                            Exit Do
                        Case 3
                            Exit Do
                    End Select
            End Select
        Loop
        Console.Clear()
    End Sub

    Sub ColourChange()
        Console.Clear()
        Console.WriteLine("To select an option, use the up & down arrows to navigate and press enter")
        Console.WriteLine("    White")
        Console.WriteLine("    Yellow")
        Console.WriteLine("    Blue")
        Console.WriteLine("    Back")

        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        Console.Write(">>")
        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("  ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write(">>")
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 4 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("  ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write(">>")
                    End If
                Case ConsoleKey.Enter
                    Select Case Console.CursorTop
                        Case 1
                            Console.ForegroundColor = ConsoleColor.White
                            Exit Do
                        Case 2
                            Console.ForegroundColor = ConsoleColor.Yellow
                            Exit Do
                        Case 3
                            Console.ForegroundColor = ConsoleColor.Blue
                            Exit Do
                        Case 4
                            Exit Do
                    End Select
            End Select
        Loop
        Console.Clear()
    End Sub

    Sub Main()
        Console.CursorVisible = False 'no flashing cursor
        PrintMenu1()
        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        Console.Write(">>")

        Do
            'readkey, no enter required
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("  ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write(">>")
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 4 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("  ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write(">>")
                    End If
                Case ConsoleKey.Enter
                    Select Case Console.CursorTop 'number of the row where cursor is
                        Case 1
                            PrintMenu2()
                            Main()
                        Case 2
                            PrintColourSettings()
                            Main()
                        Case 3
                            Console.CursorTop = 10
                            Console.WriteLine("3 chosen")
                            Threading.Thread.Sleep(2000)
                            Console.CursorTop = 10
                            Console.WriteLine("                     ")
                            Console.CursorTop = currentchoice
                        Case 4
                            Exit Do
                    End Select
            End Select



        Loop
    End Sub

End Module
