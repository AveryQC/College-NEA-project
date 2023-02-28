Module Module1

    Function mazeInitialisation(ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Dim maze(mazeWidth, mazeHeight) As String

        'starting points
        Dim currentX As Integer = Int(mazeWidth * Rnd())
        Dim currentY As Integer = Int(mazeHeight * Rnd())
        Dim nextX As Integer = currentX
        Dim nextY As Integer = currentY

        'backtrack movement stack And detector
        Dim backtrackstack(mazeWidth * mazeHeight * 2) As String
        Dim btsTop As Integer = 0

        maze = BTmazegenerator(maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
        Return maze
    End Function

    Function BTmazegenerator(ByVal maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer, ByVal currentX As Integer, ByVal currentY As Integer, ByVal nextX As Integer, ByVal nextY As Integer, ByVal backtrackstack() As String, ByVal btsTop As Integer)
        'Random Movement
        Dim Movement As String() = {"N", "E", "W", "S"}
        Dim nextMovement As Integer
        Dim randomMovement As String() = {"", "", "", ""}
        Dim nextMove As String
        Dim nextMovecounter As Integer = 0

        While randomMovement(3) = ""
            nextMovement = Int(4 * Rnd())
            nextMove = Movement(nextMovement)
            Movement(nextMovement) = ""
            For i = nextMovecounter To 3
                If randomMovement(i) = nextMove Then
                    Exit For
                ElseIf randomMovement(i) = "" Then
                    randomMovement(i) = nextMove
                    nextMovecounter += 1
                    Exit For
                End If
            Next
        End While

        'available cell checking And movement
        For n = 0 To 1
            For i = 0 To 3
                If randomMovement(i) = "N" Then
                    nextY -= 1
                    If nextY < 0 Then
                        nextY = currentY
                    ElseIf maze(currentX, nextY) <> "" Then
                        nextY = currentY
                    Else
                        maze(currentX, currentY) += "N"
                        backtrackstack(btsTop) = "S"
                        btsTop += 1
                        currentY = nextY
                        maze(currentX, currentY) += "S"
                        maze = BTmazegenerator(maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If
                ElseIf randomMovement(i) = "E" Then
                    nextX += 1
                    If nextX > mazeWidth Then
                        nextX = currentX
                    ElseIf maze(nextX, currentY) <> "" Then
                        nextX = currentX
                    Else
                        maze(currentX, currentY) += "E"
                        backtrackstack(btsTop) = "W"
                        btsTop += 1
                        currentX = nextX
                        maze(currentX, currentY) += "W"
                        maze = BTmazegenerator(maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If
                ElseIf randomMovement(i) = "W" Then
                    nextX -= 1
                    If nextX < 0 Then
                        nextX = currentX
                    ElseIf maze(nextX, currentY) <> "" Then
                        nextX = currentX
                    Else
                        maze(currentX, currentY) += "W"
                        backtrackstack(btsTop) = "E"
                        btsTop += 1
                        currentX = nextX
                        maze(currentX, currentY) += "E"
                        maze = BTmazegenerator(maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If
                ElseIf randomMovement(i) = "S" Then
                    nextY += 1
                    If nextY > mazeHeight Then
                        nextY = currentY
                    ElseIf maze(currentX, nextY) <> "" Then
                        nextY = currentY
                    Else
                        maze(currentX, currentY) += "S"
                        backtrackstack(btsTop) = "N"
                        btsTop += 1
                        currentY = nextY
                        maze(currentX, currentY) += "N"
                        maze = BTmazegenerator(maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If
                End If
            Next
        Next

        'time to backtrack?
        If backtrackstack(btsTop) = "N" Then
            currentY += 1
        ElseIf backtrackstack(btsTop) = "E" Then
            currentX += 1
        ElseIf backtrackstack(btsTop) = "W" Then
            currentX -= 1
        ElseIf backtrackstack(btsTop) = "S" Then
            currentY += 1
        End If

        backtrackstack(btsTop) = ""
        btsTop -= 1

        Return maze
    End Function

    Sub mazeDisplay(ByVal maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Console.Clear()
        Console.SetCursorPosition(0, 0)

        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                Console.Write(cellPrint(maze, x, y))
            Next
            Console.WriteLine()
            Threading.Thread.Sleep(50)
        Next

        'For l = 0 To mazeHeight
        '    For r = 0 To mazeWidth
        '        If Len(maze(r, l)) = 1 Then
        '            Console.Write(maze(r, l) & "   ")
        '        ElseIf Len(maze(r, l)) = 2 Then
        '            Console.Write(maze(r, l) & "  ")
        '        ElseIf Len(maze(r, l)) = 3 Then
        '            Console.Write(maze(r, l) & " ")
        '        End If
        '    Next
        '    Console.WriteLine()
        'Next

    End Sub

    Function cellPrint(ByVal maze As String(,), ByVal x As Integer, ByVal y As Integer) As String
        If Len(maze(x, y)) = 1 Then
            If maze(x, y) = "N" Then
                Return " ▀ "
            ElseIf maze(x, y) = "S" Then
                Return " ▄ "
            ElseIf maze(x, y) = "E" Then
                Return " ■═"
            ElseIf maze(x, y) = "W" Then
                Return "═■ "
            End If
        ElseIf Len(maze(x, y)) = 2 Then
            If maze(x, y).Contains("N") And maze(x, y).Contains("E") Then
                Return " ╚═"
            ElseIf maze(x, y).Contains("N") And maze(x, y).Contains("W") Then
                Return "═╝ "
            ElseIf maze(x, y).Contains("S") And maze(x, y).Contains("E") Then
                Return " ╔═"
            ElseIf maze(x, y).Contains("S") And maze(x, y).Contains("W") Then
                Return "═╗ "
            ElseIf maze(x, y).Contains("E") And maze(x, y).Contains("W") Then
                Return "═══"
            ElseIf maze(x, y).Contains("N") And maze(x, y).Contains("S") Then
                Return " ║ "
            End If
        ElseIf Len(maze(x, y)) = 3 Then
            If maze(x, y).Contains("N") And maze(x, y).Contains("E") And maze(x, y).Contains("W") Then
                Return "═╩═"
            ElseIf maze(x, y).Contains("N") And maze(x, y).Contains("W") And maze(x, y).Contains("S") Then
                Return "═╣ "
            ElseIf maze(x, y).Contains("S") And maze(x, y).Contains("E") And maze(x, y).Contains("N") Then
                Return " ╠═"
            ElseIf maze(x, y).Contains("S") And maze(x, y).Contains("W") And maze(x, y).Contains("E") Then
                Return "═╦═"
            End If
        End If

    End Function

    Sub mazeMovement(ByVal maze As String(,), ByVal mazeWidth As Integer, mazeHeight As Integer)
        Dim startPosX As Integer = Int(mazeWidth * Rnd())
        Dim startPosY As Integer = 0
        Dim endPosX As Integer = Int(mazeWidth * Rnd())
        Dim endPosY As Integer = mazeHeight

        Console.SetCursorPosition(endPosX * 3, endPosY)
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write(cellPrint(maze, endPosX, endPosY))

        Console.SetCursorPosition(startPosX * 3, startPosY)
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(cellPrint(maze, startPosX, startPosY))
        Console.ForegroundColor = ConsoleColor.Gray


        Dim currentPosX As Integer = startPosX
        Dim currentPosY As Integer = startPosY
        Dim movestack(mazeWidth * mazeHeight) As String
        Dim msTop As Integer = 0

        Console.CursorVisible = False
        While currentPosX <> endPosX Or currentPosY <> endPosY
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.UpArrow
                    If movestack(msTop) = "S" Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        currentPosY -= 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        movestack(msTop) = ""
                        msTop -= 1

                    Else
                        If maze(currentPosX, currentPosY).Contains("N") Then
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            currentPosY -= 1
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            movestack(msTop) = "N"
                            msTop += 1
                        End If
                    End If

                Case ConsoleKey.RightArrow
                    If movestack(msTop) = "W" Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        currentPosX += 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        movestack(msTop) = ""
                        msTop -= 1

                    Else
                        If maze(currentPosX, currentPosY).Contains("E") Then
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            currentPosX += 1
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))
                            Console.ForegroundColor = ConsoleColor.DarkYellow

                            movestack(msTop) = "E"
                            msTop += 1
                        End If
                    End If

                Case ConsoleKey.DownArrow
                    If movestack(msTop) = "N" Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        currentPosY += 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        movestack(msTop) = ""
                        msTop -= 1

                    Else
                        If maze(currentPosX, currentPosY).Contains("S") Then
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            currentPosY += 1
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            movestack(msTop) = "S"
                            msTop += 1
                        End If
                    End If

                Case ConsoleKey.LeftArrow
                    If movestack(msTop) = "E" Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        currentPosX -= 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write(cellPrint(maze, currentPosX, currentPosY))

                        movestack(msTop) = ""
                        msTop -= 1

                    Else
                        If maze(currentPosX, currentPosY).Contains("W") Then
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            currentPosX -= 1
                            Console.SetCursorPosition(currentPosX * 3, currentPosY)
                            Console.ForegroundColor = ConsoleColor.DarkYellow
                            Console.Write(cellPrint(maze, currentPosX, currentPosY))

                            movestack(msTop) = "W"
                            msTop += 1
                        End If
                    End If
            End Select

            Console.SetCursorPosition(endPosX * 3, endPosY)
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write(cellPrint(maze, endPosX, endPosY))

            Console.SetCursorPosition(startPosX * 3, startPosY)
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write(cellPrint(maze, startPosX, startPosY))
            Console.ForegroundColor = ConsoleColor.Gray

        End While
    End Sub

    Sub Main()
        Dim repeat As Boolean = True
        Dim loopSelection As String

        While repeat = True
            Console.Clear()
            loopSelection = ""
            Randomize()

            Dim mazeWidth As Integer = 0
            Dim mazeHeight As Integer = 0

            While mazeWidth < 10 Or mazeWidth > 50
                Try
                    Console.Write("Enter the width of the maze with a value between 10 and 50: ")
                    mazeWidth = Console.ReadLine()
                    If mazeWidth < 10 Or mazeWidth > 500 Then
                        Console.WriteLine("Value entered is invalid")
                    End If
                Catch ex As Exception
                    Console.WriteLine("Value entered is invalid")
                End Try
            End While
            mazeWidth -= 1

            While mazeHeight < 10 Or mazeHeight > 50
                Try
                    Console.Write("Enter the height of the maze with a value between 10 and 50: ")
                    mazeHeight = Console.ReadLine()
                    If mazeHeight < 10 Or mazeHeight > 50 Then
                        Console.WriteLine("Value entered is invalid")
                    End If
                Catch ex As Exception
                    Console.Write("Value entered is invalid")
                End Try
            End While
            mazeHeight -= 1

            Dim maze(,) As String = mazeInitialisation(mazeWidth, mazeHeight)
            mazeDisplay(maze, mazeWidth, mazeHeight)

            mazeMovement(maze, mazeWidth, mazeHeight)

            Console.SetCursorPosition(0, mazeHeight + 2)
            Console.WriteLine()
            Do
                Console.Write("Generate a new maze? [Y]es / [N]o ")
                loopSelection = Console.ReadLine
                If loopSelection = "Y" Or loopSelection = "y" Then
                    repeat = True
                ElseIf loopSelection = "N" Or loopSelection = "n" Then
                    repeat = False
                Else
                    Console.WriteLine("Input invalid")
                End If
            Loop Until loopSelection = "Y" Or loopSelection = "y" Or loopSelection = "N" Or loopSelection = "n"
        End While

        Console.WriteLine()
        Console.Write("Exiting program.")
        Threading.Thread.Sleep(400)
        Console.Write(".")
        Threading.Thread.Sleep(400)
        Console.Write(".")
        Threading.Thread.Sleep(400)
    End Sub
End Module
