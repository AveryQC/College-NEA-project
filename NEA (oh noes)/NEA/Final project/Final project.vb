Module Module1

    Dim colourArray(2) As Integer

    Function MazeInitialisation(ByRef mazeWidth As Integer, ByRef mazeHeight As Integer, ByVal mazeMode As String, ByVal eActive As Boolean)
        Randomize()
        Dim maze(mazeWidth, mazeHeight) As String
        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                maze(x, y) = " "
            Next
        Next

        If mazeMode = "I" And eActive = False Then
            maze = IrregularMazeShapeChoice(maze, mazeWidth, mazeHeight)
        ElseIf mazeMode = "M" Then
            maze = MinefieldMaze(maze, mazeWidth, mazeHeight)
        ElseIf mazeMode = "I" And eActive = True Then
            Dim randomMaze As Integer = Int(7 * Rnd() + 1)
            While randomMaze = 1 Or randomMaze = 7
                randomMaze = Int(7 * Rnd() + 1)
            End While

            If randomMaze = 2 Then
                IrregularMazeL(maze, mazeWidth, mazeHeight)
            ElseIf randomMaze = 3 Then
                IrregularMazeS(maze, mazeWidth, mazeHeight)
            ElseIf randomMaze = 4 Then
                IrregularMazeT(maze, mazeWidth, mazeHeight)
            ElseIf randomMaze = 5 Then
                IrregularMazeX(maze, mazeWidth, mazeHeight)
            ElseIf randomMaze = 6 Then
                IrregularMazeO(maze, mazeWidth, mazeHeight)
            End If
        End If

        Dim currentX As Integer = Int(mazeWidth * Rnd())
        Dim currentY As Integer = Int(mazeHeight * Rnd())
        While maze(currentX, currentY) = "Q"
            currentX = Int(mazeWidth * Rnd())
            currentY = Int(mazeHeight * Rnd())
        End While
        Dim nextX As Integer
        Dim nextY As Integer

        Dim backtrackstack(mazeWidth * mazeHeight) As String
        Dim btsTop As Integer

        Dim validCellCount As Integer
        Dim invalidCell As Boolean

        While validCellCount < (mazeWidth * mazeHeight) / 2 Or invalidCell = True
            nextX = currentX
            nextY = currentY
            btsTop = 0
            validCellCount = 1
            invalidCell = False
            maze = BTmazegenerator(validCellCount, maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If maze(x, y).Count > 1 And maze(x, y).Contains("Q") Then
                        invalidCell = True
                    End If
                Next
            Next
        End While

        Return maze
    End Function

    Function MinefieldMaze(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Randomize()
        Dim numberOfMines As Integer = (mazeWidth * mazeHeight) / 5
        While numberOfMines > 0
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If Int(20 * Rnd() + 1) = Int(20 * Rnd() + 1) And Not maze(x, y).Contains("Q") And numberOfMines > 0 Then
                        maze(x, y) = "Q"
                        numberOfMines -= 1
                    End If
                Next
            Next
        End While

        Return maze
    End Function

    Sub IMSCMenuEditor2(ByVal type As Integer)
        If type = 1 Then
            Console.SetCursorPosition(3, 1)
            Console.Write("- L -")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(3, 2)
            Console.Write("     ")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(3, 3)
            Console.Write(" ■   ")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(3, 4)
            Console.Write(" ■ ■ ")
            Threading.Thread.Sleep(200)

        ElseIf type = 2 Then
            Console.SetCursorPosition(13, 1)
            Console.Write("- S -")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(13, 2)
            Console.Write("  ■ ■")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(13, 3)
            Console.Write("■ ■ ■")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(13, 4)
            Console.Write("■ ■  ")
            Threading.Thread.Sleep(200)

        ElseIf type = 3 Then
            Console.SetCursorPosition(23, 1)
            Console.Write("- T -")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(23, 2)
            Console.Write("■ ■ ■")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(23, 3)
            Console.Write("  ■  ")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(23, 4)
            Console.Write("  ■  ")
            Threading.Thread.Sleep(200)

        ElseIf type = 4 Then
            Console.SetCursorPosition(33, 1)
            Console.Write("- X -")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(33, 2)
            Console.Write("  ■  ")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(33, 3)
            Console.Write("■ ■ ■")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(33, 4)
            Console.Write("  ■  ")
            Threading.Thread.Sleep(200)

        ElseIf type = 5 Then
            Console.SetCursorPosition(43, 1)
            Console.Write("- O -")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(43, 2)
            Console.Write("■ ■ ■")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(43, 3)
            Console.Write("■   ■")
            Threading.Thread.Sleep(200)
            Console.SetCursorPosition(43, 4)
            Console.Write("■ ■ ■")
            Threading.Thread.Sleep(200)

        End If
    End Sub

    Sub IMSCMenuEditor1(ByVal type As Integer)
        Console.SetCursorPosition((10 * type) - 9, 1)
        Console.Write("┌")
        Console.SetCursorPosition((10 * type) - 9, 2)
        Console.Write("│")
        Console.SetCursorPosition((10 * type) - 9, 3)
        Console.Write("│")
        Console.SetCursorPosition((10 * type) - 9, 4)
        Console.Write("│")
        Console.SetCursorPosition((10 * type) - 9, 5)
        Console.Write("└")

        Console.SetCursorPosition((10 * type) - 1, 1)
        Console.Write("┐")
        Console.SetCursorPosition((10 * type) - 1, 2)
        Console.Write("│")
        Console.SetCursorPosition((10 * type) - 1, 3)
        Console.Write("│")
        Console.SetCursorPosition((10 * type) - 1, 4)
        Console.Write("│")
        Console.SetCursorPosition((10 * type) - 1, 5)
        Console.Write("┘")
    End Sub

    Function IrregularMazeShapeChoice(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Console.ForegroundColor = ConsoleColor.White
        Do
            Console.WriteLine("--- Shape selection ---")
            Console.WriteLine("   - L -     - S -     - T -     - X -     - O -   ")
            Console.WriteLine("               ■ ■     ■ ■ ■       ■       ■ ■ ■   ")
            Console.WriteLine("    ■        ■ ■ ■       ■       ■ ■ ■     ■   ■   ")
            Console.WriteLine("    ■ ■      ■ ■         ■         ■       ■ ■ ■   ")
            Console.WriteLine("                                                   ")

            Dim currentchoice As Integer = 1
            Console.SetCursorPosition(currentchoice, 2)
            SetColour(2)
            IMSCMenuEditor1(currentchoice)
            Console.ForegroundColor = ConsoleColor.White

            Do
                Dim keypressed As ConsoleKey
                keypressed = Console.ReadKey(True).Key

                Select Case keypressed
                    Case ConsoleKey.A, ConsoleKey.LeftArrow
                        If currentchoice > 1 Then
                            Console.ForegroundColor = ConsoleColor.Black
                            IMSCMenuEditor1(currentchoice)
                            currentchoice -= 1
                            SetColour(2)
                            IMSCMenuEditor1(currentchoice)
                        ElseIf currentchoice = 1 Then
                            Console.ForegroundColor = ConsoleColor.Black
                            IMSCMenuEditor1(currentchoice)
                            currentchoice = 5
                            SetColour(2)
                            IMSCMenuEditor1(currentchoice)
                        End If
                    Case ConsoleKey.D, ConsoleKey.RightArrow
                        If currentchoice < 5 Then
                            Console.ForegroundColor = ConsoleColor.Black
                            IMSCMenuEditor1(currentchoice)
                            currentchoice += 1
                            SetColour(2)
                            IMSCMenuEditor1(currentchoice)
                        ElseIf currentchoice = 5 Then
                            Console.ForegroundColor = ConsoleColor.Black
                            IMSCMenuEditor1(currentchoice)
                            currentchoice = 1
                            SetColour(2)
                            IMSCMenuEditor1(currentchoice)
                        End If

                    Case ConsoleKey.Enter, ConsoleKey.E
                        Select Case currentchoice
                            Case 1
                                SetColour(2)
                                IMSCMenuEditor2(currentchoice)
                                IrregularMazeL(maze, mazeWidth, mazeHeight)
                            Case 2
                                SetColour(2)
                                IMSCMenuEditor2(currentchoice)
                                IrregularMazeS(maze, mazeWidth, mazeHeight)
                            Case 3
                                SetColour(2)
                                IMSCMenuEditor2(currentchoice)
                                IrregularMazeT(maze, mazeWidth, mazeHeight)
                            Case 4
                                SetColour(2)
                                IMSCMenuEditor2(currentchoice)
                                IrregularMazeX(maze, mazeWidth, mazeHeight)
                            Case 5
                                SetColour(2)
                                IMSCMenuEditor2(currentchoice)
                                IrregularMazeO(maze, mazeWidth, mazeHeight)
                        End Select
                        Return maze
                End Select
            Loop
        Loop

    End Function

    Function IrregularMazeL(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Randomize()
        Dim noCorner As Integer = Int(4 * Rnd() + 1)
        If noCorner = 1 Then 'tl
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 2) - 1) And y < ((mazeHeight / 2) - 1) Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        ElseIf noCorner = 2 Then 'tr
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > (mazeWidth / 2) And y < ((mazeHeight / 2) - 1) Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        ElseIf noCorner = 3 Then 'bl
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 2) - 1) And y > (mazeHeight / 2) Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        Else 'br
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > (mazeWidth / 2) And y > (mazeHeight / 2) Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next
        End If

        Return maze
    End Function

    Function IrregularMazeS(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Randomize()
        Dim noCorners As Integer = Int(2 * Rnd() + 1)
        If noCorners = 1 Then 'br tl
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 3) + 2) And y < ((mazeHeight / 3) + 2) Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > ((mazeWidth / 3) * 2) - 2 And y > ((mazeHeight / 3) * 2) - 2 Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        Else 'tr bl
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > ((mazeWidth / 3) * 2) - 2 And y < ((mazeHeight / 3) + 2) Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 3) + 2) And y > ((mazeHeight / 3) * 2) - 2 Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next
        End If

        Return maze
    End Function

    Function IrregularMazeT(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Randomize()
        Dim noCorners As Integer = Int(4 * Rnd() + 1)

        If noCorners = 1 Then 'tl bl
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 3) + 8) And y < ((mazeHeight / 3) + 2) Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 3) + 8) And y > ((mazeHeight / 3) * 2) - 2 Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        ElseIf noCorners = 2 Then 'tl tr
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 3) + 2) And y < ((mazeHeight / 3) + 8) Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > ((mazeWidth / 3) * 2) - 2 And y < ((mazeHeight / 3) + 8) Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        ElseIf noCorners = 3 Then 'tr br
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > ((mazeWidth / 3) * 2) - 8 And y < ((mazeHeight / 3) + 2) Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > ((mazeWidth / 3) * 2) - 8 And y > ((mazeHeight / 3) * 2) - 2 Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        Else 'br bl
            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x > ((mazeWidth / 3) * 2) - 2 And y > ((mazeHeight / 3) * 2) - 8 Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

            For y = 0 To mazeHeight
                For x = 0 To mazeWidth
                    If x < ((mazeWidth / 3) + 2) And y > ((mazeHeight / 3) * 2) - 8 Then
                        maze(x, y) = "Q"
                    ElseIf maze(x, y) = "Q" Then
                        maze(x, y) = "Q"
                    Else
                        maze(x, y) = " "
                    End If
                Next
            Next

        End If

        Return maze
    End Function

    Function IrregularMazeX(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                If x < ((mazeWidth / 3) + 1) And y < ((mazeHeight / 3) + 1) Then
                    maze(x, y) = "Q"
                ElseIf maze(x, y) = "Q" Then
                    maze(x, y) = "Q"
                Else
                    maze(x, y) = " "
                End If
            Next
        Next

        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                If x < ((mazeWidth / 3) + 1) And y > ((mazeHeight / 3) * 2) - 1 Then
                    maze(x, y) = "Q"
                ElseIf maze(x, y) = "Q" Then
                    maze(x, y) = "Q"
                Else
                    maze(x, y) = " "
                End If
            Next
        Next

        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                If x > ((mazeWidth / 3) * 2) - 1 And y < ((mazeHeight / 3) + 1) Then
                    maze(x, y) = "Q"
                ElseIf maze(x, y) = "Q" Then
                    maze(x, y) = "Q"
                Else
                    maze(x, y) = " "
                End If
            Next
        Next

        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                If x > ((mazeWidth / 3) * 2) - 1 And y > ((mazeHeight / 3) * 2) - 1 Then
                    maze(x, y) = "Q"
                ElseIf maze(x, y) = "Q" Then
                    maze(x, y) = "Q"
                Else
                    maze(x, y) = " "
                End If
            Next
        Next

        Return maze
    End Function

    Function IrregularMazeO(ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                If x > ((mazeWidth / 3) - 2) And x < ((mazeWidth / 3) * 2) + 2 And y > ((mazeHeight / 3) - 2) And y < ((mazeHeight / 3) * 2) + 2 Then
                    maze(x, y) = "Q"
                Else
                    maze(x, y) = " "
                End If
            Next
        Next
        Return maze
    End Function

    Function BTmazegenerator(ByRef validCellCount As Integer, ByRef maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer, ByVal currentX As Integer, ByVal currentY As Integer, ByVal nextX As Integer, ByVal nextY As Integer, ByVal backtrackstack() As String, ByVal btsTop As Integer)
        Dim Movement As String() = {"N", "E", "W", "S"}
        Dim nextMovement As Integer
        Dim randomMovement As String() = {"", "", "", ""}
        Dim nextMove As String
        Dim nextMovecounter As Integer

        Randomize()
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

        For n = 0 To 3
            For i = 0 To 3
                If randomMovement(i) = "N" Then
                    nextY -= 1
                    If nextY < 0 Then
                        nextY = currentY
                    ElseIf maze(currentX, nextY).Contains("Q") Or maze(currentX, nextY) <> " " Then
                        nextY = currentY
                    Else
                        maze(currentX, currentY) += "N"
                        validCellCount += 1
                        backtrackstack(btsTop) = "S"
                        btsTop += 1
                        currentY = nextY
                        maze(currentX, currentY) += "S"
                        maze = BTmazegenerator(validCellCount, maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If

                ElseIf randomMovement(i) = "E" Then
                    nextX += 1
                    If nextX > mazeWidth Then
                        nextX = currentX
                    ElseIf maze(nextX, currentY).Contains("Q") Or maze(nextX, currentY) <> " " Then
                        nextX = currentX
                    Else
                        maze(currentX, currentY) += "E"
                        validCellCount += 1
                        backtrackstack(btsTop) = "W"
                        btsTop += 1
                        currentX = nextX
                        maze(currentX, currentY) += "W"
                        maze = BTmazegenerator(validCellCount, maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If

                ElseIf randomMovement(i) = "W" Then
                    nextX -= 1
                    If nextX < 0 Then
                        nextX = currentX
                    ElseIf maze(nextX, currentY).Contains("Q") Or maze(nextX, currentY) <> " " Then
                        nextX = currentX
                    Else
                        maze(currentX, currentY) += "W"
                        validCellCount += 1
                        backtrackstack(btsTop) = "E"
                        btsTop += 1
                        currentX = nextX
                        maze(currentX, currentY) += "E"
                        maze = BTmazegenerator(validCellCount, maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If

                ElseIf randomMovement(i) = "S" Then
                    nextY += 1
                    If nextY > mazeHeight Then
                        nextY = currentY
                    ElseIf maze(currentX, nextY).Contains("Q") Or maze(currentX, nextY) <> " " Then
                        nextY = currentY
                    Else
                        maze(currentX, currentY) += "S"
                        validCellCount += 1
                        backtrackstack(btsTop) = "N"
                        btsTop += 1
                        currentY = nextY
                        maze(currentX, currentY) += "N"
                        maze = BTmazegenerator(validCellCount, maze, mazeWidth, mazeHeight, currentX, currentY, nextX, nextY, backtrackstack, btsTop)
                    End If
                End If
            Next
        Next

        If backtrackstack.Count = btsTop Then
            btsTop = backtrackstack.Count - 1
        End If
        backtrackstack(btsTop) = ""

        Return maze
    End Function

    Sub MazeDisplay(ByVal maze As String(,), ByVal mazeWidth As Integer, ByVal mazeHeight As Integer)
        Console.Clear()
        Console.SetCursorPosition(0, 0)
        Console.ForegroundColor = ConsoleColor.White

        For y = 0 To mazeHeight
            For x = 0 To mazeWidth
                Console.Write(CellPrint(maze, x, y))
            Next
            Console.WriteLine()
            Threading.Thread.Sleep(50)
        Next

    End Sub

    Function CellPrint(ByVal maze As String(,), ByVal x As Integer, ByVal y As Integer) As String
        If Len(maze(x, y)) - 1 = 1 Then
            If maze(x, y).Contains("N") Then
                Return " ▀ "
            ElseIf maze(x, y).Contains("S") Then
                Return " ▄ "
            ElseIf maze(x, y).Contains("E") Then
                Return " ■═"
            ElseIf maze(x, y).Contains("W") Then
                Return "═■ "
            ElseIf maze(x, y).Contains("Q") Or maze(x, y).Contains(" ") Then
                Return "   "
            Else
                Return " E1"
            End If
        ElseIf Len(maze(x, y)) - 1 = 2 Then
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
            Else
                Return " E2"
            End If
        ElseIf Len(maze(x, y)) - 1 = 3 Then
            If maze(x, y).Contains("N") And maze(x, y).Contains("E") And maze(x, y).Contains("W") Then
                Return "═╩═"
            ElseIf maze(x, y).Contains("N") And maze(x, y).Contains("W") And maze(x, y).Contains("S") Then
                Return "═╣ "
            ElseIf maze(x, y).Contains("S") And maze(x, y).Contains("E") And maze(x, y).Contains("N") Then
                Return " ╠═"
            ElseIf maze(x, y).Contains("S") And maze(x, y).Contains("W") And maze(x, y).Contains("E") Then
                Return "═╦═"
            Else
                Return " E3"
            End If
        Else
            Return "   "
        End If

    End Function

    Sub MazeMovement(ByVal maze As String(,), ByVal mazeWidth As Integer, mazeHeight As Integer)
        Dim startPosX As Integer
        Dim startPosY As Integer
        Dim endPosX As Integer
        Dim endPosY As Integer
        Console.CursorVisible = False

        Dim seFound As Boolean = False
        For ys = 0 To mazeHeight
            For xs = 0 To mazeWidth
                If Len(maze(xs, ys)) - 1 = 1 And Not maze(xs, ys).Contains("Q") And seFound = False Then
                    startPosX = xs
                    startPosY = ys
                    seFound = True
                End If
            Next
        Next

        seFound = False
        For ye = mazeHeight To 0 Step -1
            For xe = mazeWidth To 0 Step -1
                If Len(maze(xe, ye)) - 1 = 1 And Not maze(xe, ye).Contains("Q") And seFound = False Then
                    endPosX = xe
                    endPosY = ye
                    seFound = True
                End If
            Next
        Next

        Console.SetCursorPosition(endPosX * 3, endPosY)
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write(CellPrint(maze, endPosX, endPosY))

        Console.SetCursorPosition(startPosX * 3, startPosY)
        Console.ForegroundColor = ConsoleColor.Red
        Console.Write(CellPrint(maze, startPosX, startPosY))
        Console.ForegroundColor = ConsoleColor.White

        Dim currentPosX As Integer = startPosX
        Dim currentPosY As Integer = startPosY

        Console.CursorVisible = False
        While currentPosX <> endPosX Or currentPosY <> endPosY
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If maze(currentPosX, currentPosY).Contains("N") Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(1)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))

                        currentPosY -= 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(0)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))
                    End If

                Case ConsoleKey.D, ConsoleKey.RightArrow
                    If maze(currentPosX, currentPosY).Contains("E") Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(1)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))

                        currentPosX += 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(0)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))
                    End If

                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If maze(currentPosX, currentPosY).Contains("S") Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(1)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))

                        currentPosY += 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(0)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))
                    End If

                Case ConsoleKey.A, ConsoleKey.LeftArrow
                    If maze(currentPosX, currentPosY).Contains("W") Then
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(1)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))

                        currentPosX -= 1
                        Console.SetCursorPosition(currentPosX * 3, currentPosY)
                        SetColour(0)
                        Console.Write(CellPrint(maze, currentPosX, currentPosY))
                    End If
                Case ConsoleKey.R
                    Console.SetCursorPosition(0, mazeHeight + 2)
                    Console.Write("Resetting maze.")
                    Threading.Thread.Sleep(400)
                    Console.Write(".")
                    Threading.Thread.Sleep(400)
                    Console.Write(".")
                    Threading.Thread.Sleep(400)

                    MazeDisplay(maze, mazeWidth, mazeHeight)
                    currentPosX = startPosX
                    currentPosY = startPosY
                Case ConsoleKey.X
                    Console.SetCursorPosition(0, mazeHeight + 2)
                    Console.Write("Exiting maze.")
                    Threading.Thread.Sleep(400)
                    Console.Write(".")
                    Threading.Thread.Sleep(400)
                    Console.Write(".")
                    Threading.Thread.Sleep(400)
                    Exit Sub
            End Select

            Console.SetCursorPosition(endPosX * 3, endPosY)
            Console.ForegroundColor = ConsoleColor.Green
            Console.Write(CellPrint(maze, endPosX, endPosY))

            Console.SetCursorPosition(startPosX * 3, startPosY)
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write(CellPrint(maze, startPosX, startPosY))
            Console.ForegroundColor = ConsoleColor.White

        End While
    End Sub

    Sub ControlDisplay()
        Console.Clear()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine("--- Controls in game ---")
        Console.WriteLine("Movement:          W       ^
                 A S D   < v > 

Restart:         R

Exit maze:       X

Endless - Next:  D  >

Endless - Quit:  A  <

New game:        Y, N   ENTER")

        Console.WriteLine()
        Console.WriteLine("--- Controls in menus ---")
        Console.WriteLine("Navigation:        W       ^
                 A S D   < v > 

Colour options:  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12

Select/confirm:  E       ENTER")

        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("Press any key to exit")
        Console.ReadKey()
    End Sub

    Sub SetColour(ByVal selection As Integer)
        Select Case colourArray(selection)
            Case 1
                Console.ForegroundColor = ConsoleColor.Red
            Case 2
                Console.ForegroundColor = ConsoleColor.DarkRed
            Case 3
                Console.ForegroundColor = ConsoleColor.Yellow
            Case 4
                Console.ForegroundColor = ConsoleColor.DarkYellow
            Case 5
                Console.ForegroundColor = ConsoleColor.Green
            Case 6
                Console.ForegroundColor = ConsoleColor.DarkGreen
            Case 7
                Console.ForegroundColor = ConsoleColor.Blue
            Case 8
                Console.ForegroundColor = ConsoleColor.DarkBlue
            Case 9
                Console.ForegroundColor = ConsoleColor.Magenta
            Case 10
                Console.ForegroundColor = ConsoleColor.DarkMagenta
            Case 11
                Console.ForegroundColor = ConsoleColor.Cyan
            Case 12
                Console.ForegroundColor = ConsoleColor.DarkCyan
        End Select
    End Sub

    Sub ColourPrint()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("1: Red")
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine("2: Dark red")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("3: Yellow")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("4: Dark yellow")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("5: Green")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine("6: Dark green")
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("7: Blue")
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.WriteLine("8: Dark blue")
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine("9: Magenta")
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("10: Dark magenta")
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("11: Cyan")
        Console.ForegroundColor = ConsoleColor.DarkCyan
        Console.WriteLine("12: Dark Cyan")
        Console.WriteLine()
    End Sub

    Sub ColourSettings()
        Console.Clear()
        Console.CursorVisible = False
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("--- Colour settings ---")
        Console.WriteLine("    Player")
        Console.WriteLine("    Trail")
        Console.WriteLine("    Menu arrows")
        Console.WriteLine("    Return")
        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        SetColour(2)
        Console.Write(">>>")
        Console.ForegroundColor = ConsoleColor.White

        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key
            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 4
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 4 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 4 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.Enter, ConsoleKey.E
                    Select Case Console.CursorTop
                        Case 1
                            SetColour(2)
                            Dim printWord As String = "Player"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next

                            Dim playerColour As Integer = 0
                            Console.Clear()
                            While playerColour = 0
                                ColourPrint()
                                Console.ForegroundColor = ConsoleColor.White
                                Console.Write("Enter in the number you want to set the player's colour as: ")
                                Try
                                    playerColour = Console.ReadLine()
                                Catch ex As Exception
                                    playerColour = 0
                                End Try
                                If playerColour > 0 And playerColour < 13 And playerColour <> colourArray(1) Then
                                    Console.Write("Colour saved!")
                                    Threading.Thread.Sleep(800)
                                    colourArray(0) = playerColour
                                ElseIf playerColour > 12 Or playerColour < 1 Then
                                    playerColour = 0
                                    Console.Write("Invalid input")
                                    Threading.Thread.Sleep(800)
                                    Console.Clear()
                                ElseIf playerColour = colourArray(1) Then
                                    playerColour = 0
                                    Console.Write("Player and trail colours can't be the same")
                                    Threading.Thread.Sleep(800)
                                    Console.Clear()
                                End If
                            End While

                        Case 2
                            SetColour(2)
                            Dim printWord As String = "Trail"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next

                            Dim trailColour As Integer = 0
                            Console.Clear()
                            While trailColour = 0
                                ColourPrint()
                                Console.ForegroundColor = ConsoleColor.White
                                Console.Write("Enter in the number you want to set the player's trail colour as: ")
                                Try
                                    trailColour = Console.ReadLine()
                                Catch ex As Exception
                                    trailColour = 0
                                End Try
                                If trailColour > 0 And trailColour < 13 And trailColour <> colourArray(0) Then
                                    Console.Write("Colour saved!")
                                    Threading.Thread.Sleep(800)
                                    colourArray(1) = trailColour
                                ElseIf trailColour > 12 Or trailColour < 1 Then
                                    trailColour = 0
                                    Console.Write("Invalid input")
                                    Threading.Thread.Sleep(800)
                                    Console.Clear()
                                ElseIf trailColour = colourArray(0) Then
                                    trailColour = 0
                                    Console.Write("Player and trail colours can't be the same")
                                    Threading.Thread.Sleep(800)
                                    Console.Clear()
                                End If
                            End While

                        Case 3
                            SetColour(2)
                            Dim printWord As String = "Menu arrows"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next

                            Dim arrowColour As Integer = 0
                            Console.Clear()
                            While arrowColour = 0
                                ColourPrint()
                                Console.ForegroundColor = ConsoleColor.White
                                Console.Write("Enter in the number you want to set the menu arrow colour as: ")
                                Try
                                    arrowColour = Console.ReadLine()
                                Catch ex As Exception
                                    arrowColour = 0
                                End Try
                                If arrowColour > 0 And arrowColour < 13 Then
                                    Console.Write("Colour saved!")
                                    Threading.Thread.Sleep(800)
                                    colourArray(2) = arrowColour
                                ElseIf arrowColour > 12 Or arrowColour < 1 Then
                                    arrowColour = 0
                                    Console.Write("Invalid input")
                                    Threading.Thread.Sleep(800)
                                    Console.Clear()
                                End If
                            End While

                        Case 4
                            SetColour(2)
                            Dim printWord As String = "Return"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Exit Sub
                    End Select

                    Console.Clear()
                    Console.CursorVisible = False
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine("--- Colour settings ---")
                    Console.WriteLine("    Player")
                    Console.WriteLine("    Trail")
                    Console.WriteLine("    Menu arrows")
                    Console.WriteLine("    Return")
                    currentchoice = 1
                    Console.SetCursorPosition(0, currentchoice)
                    SetColour(2)
                    Console.Write(">>>")
                    Console.ForegroundColor = ConsoleColor.White
            End Select

        Loop
    End Sub

    Sub SettingsMenu()
        Console.Clear()
        Console.CursorVisible = False
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("--- Settings ---")
        Console.WriteLine("    Controls")
        Console.WriteLine("    Colours")
        Console.WriteLine("    Return")
        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        SetColour(2)
        Console.Write(">>>")
        Console.ForegroundColor = ConsoleColor.White

        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 3
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 3 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 3 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.Enter, ConsoleKey.E
                    Select Case Console.CursorTop
                        Case 1
                            SetColour(2)
                            Dim printWord As String = "Controls"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            ControlDisplay()
                        Case 2
                            SetColour(2)
                            Dim printWord As String = "Colours"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            ColourSettings()
                        Case 3
                            SetColour(2)
                            Dim printWord As String = "Return"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Exit Sub
                    End Select

                    Console.Clear()
                    Console.CursorVisible = False
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine("--- Settings ---")
                    Console.WriteLine("    Controls")
                    Console.WriteLine("    Colours")
                    Console.WriteLine("    Return")
                    currentchoice = 1
                    Console.SetCursorPosition(0, currentchoice)
                    SetColour(2)
                    Console.Write(">>>")
                    Console.ForegroundColor = ConsoleColor.White
            End Select

        Loop
    End Sub

    Function DifficultySelection() As String
        Console.Clear()
        Console.CursorVisible = False
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("--- Difficulty selection ---")
        Console.WriteLine("    Simple")
        Console.WriteLine("    Regular")
        Console.WriteLine("    Hard")
        Console.WriteLine("    Complex")
        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        SetColour(2)
        Console.Write(">>>")
        Console.ForegroundColor = ConsoleColor.White

        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 4
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 4 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 4 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.Enter, ConsoleKey.E
                    Select Case Console.CursorTop
                        Case 1
                            SetColour(2)
                            Dim printWord As String = "Simple"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "S"
                        Case 2
                            SetColour(2)
                            Dim printWord As String = "Regular"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "R"
                        Case 3
                            SetColour(2)
                            Dim printWord As String = "Hard"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "H"
                        Case 4
                            SetColour(2)
                            Dim printWord As String = "Complex"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "C"
                    End Select
            End Select
        Loop
    End Function

    Function GameMode() As String
        Console.Clear()
        Console.CursorVisible = False
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("--- Game mode ---")
        Console.WriteLine("    Normal")
        Console.WriteLine("    Irregular")
        Console.WriteLine("    Minefield")
        Console.WriteLine("    Endless")
        Console.WriteLine("    Return")
        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        SetColour(2)
        Console.Write(">>>")
        Console.ForegroundColor = ConsoleColor.White

        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 5
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 5 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 5 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.Enter, ConsoleKey.E
                    Select Case Console.CursorTop
                        Case 1
                            SetColour(2)
                            Dim printWord As String = "Normal"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "N"
                        Case 2
                            SetColour(2)
                            Dim printWord As String = "Irregular"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "I"
                        Case 3
                            SetColour(2)
                            Dim printWord As String = "Minefield"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "M"
                        Case 4
                            SetColour(2)
                            Dim printWord As String = "Endless"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "E"
                        Case 5
                            SetColour(2)
                            Dim printWord As String = "Return"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "R"
                    End Select
            End Select
        Loop
    End Function

    Function MainMenu() As String
        Console.CursorVisible = False
        Dim currentchoice As Integer = 1
        Console.SetCursorPosition(0, currentchoice)
        SetColour(2)
        Console.Write(">>>")
        Console.ForegroundColor = ConsoleColor.White

        Do
            Dim keypressed As ConsoleKey
            keypressed = Console.ReadKey(True).Key

            Select Case keypressed
                Case ConsoleKey.W, ConsoleKey.UpArrow
                    If currentchoice > 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice -= 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 1 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 3
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.S, ConsoleKey.DownArrow
                    If currentchoice < 3 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice += 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    ElseIf currentchoice = 3 Then
                        Console.SetCursorPosition(0, currentchoice)
                        Console.Write("   ")
                        currentchoice = 1
                        Console.SetCursorPosition(0, currentchoice)
                        SetColour(2)
                        Console.Write(">>>")
                        Console.ForegroundColor = ConsoleColor.White
                    End If
                Case ConsoleKey.Enter, ConsoleKey.E
                    Select Case Console.CursorTop
                        Case 1
                            SetColour(2)
                            Dim printWord As String = "Play"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Dim gameSelection As String = GameMode()
                            If gameSelection <> "R" Then
                                Return gameSelection
                            End If
                        Case 2
                            SetColour(2)
                            Dim printWord As String = "Settings"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            SettingsMenu()
                        Case 3
                            SetColour(2)
                            Dim printWord As String = "Exit"
                            Console.SetCursorPosition(4, currentchoice)
                            For h = 0 To Len(printWord) - 1
                                Console.Write(printWord(h))
                                Threading.Thread.Sleep(60)
                            Next
                            Return "X"
                    End Select
                    Console.Clear()
                    Console.CursorVisible = False
                    Console.ForegroundColor = ConsoleColor.White
                    Console.WriteLine("--- Menu ---")
                    Console.WriteLine("    Play")
                    Console.WriteLine("    Settings")
                    Console.WriteLine("    Exit")
                    currentchoice = 1
                    Console.SetCursorPosition(0, currentchoice)
                    SetColour(2)
                    Console.Write(">>>")
                    Console.ForegroundColor = ConsoleColor.White
            End Select
        Loop
    End Function

    Sub Main()
        Console.SetWindowSize(149, 50)
        Console.ForegroundColor = ConsoleColor.White
        colourArray(0) = 7 : colourArray(1) = 4 : colourArray(2) = 5
        Dim repeat As Boolean = True
        Dim loopSelection As String
        Dim firstPlay As Boolean = True
        Dim eActive As Boolean

        While repeat = True
            Randomize()
            Dim mazeWidth As Integer
            Dim mazeHeight As Integer
            eActive = False

            Console.Clear()
            Console.ForegroundColor = ConsoleColor.White
            If firstPlay = True Then
                Console.WriteLine("--- Menu ---")
                Console.WriteLine("    Play        *Use the arrow keys  ")
                Console.WriteLine("    Settings    to navigate and the  ")
                Console.WriteLine("    Exit        ENTER key to select* ")
                firstPlay = False
            Else
                Console.WriteLine("--- Menu ---")
                Console.WriteLine("    Play    ")
                Console.WriteLine("    Settings")
                Console.WriteLine("    Exit    ")
            End If

            Dim mazeMode As String = MainMenu()
            If mazeMode = "N" Then
                Dim mazeDifficulty As String = DifficultySelection()
                If mazeDifficulty = "S" Then
                    mazeWidth = 9
                    mazeHeight = 9
                ElseIf mazeDifficulty = "R" Then
                    mazeWidth = Int(11 * Rnd() + 20)
                    mazeHeight = Int(11 * Rnd() + 20)
                ElseIf mazeDifficulty = "H" Then
                    mazeWidth = Int(11 * Rnd() + 30)
                    mazeHeight = Int(11 * Rnd() + 30)
                ElseIf mazeDifficulty = "C" Then
                    mazeWidth = 44
                    mazeHeight = 44
                End If
            ElseIf mazeMode = "I" Or mazeMode = "M" Then
                mazeWidth = 24
                mazeHeight = 24
            ElseIf mazeMode = "E" Then
                eActive = True
            ElseIf mazeMode = "X" Then
                Exit While
            End If

            Console.Clear()
            If mazeMode = "E" Then
                Randomize()
                Dim nextMaze As Integer
                Do
                    Dim mazeTypes As String() = {"N", "I", "M"}
                    Dim nextMazeType As String
                    nextMazeType = Int(5 * Rnd() + 1)
                    While nextMazeType = 1 Or nextMazeType = 5
                        nextMazeType = Int(5 * Rnd() + 1)
                    End While

                    Select Case nextMazeType
                        Case 2
                            Dim normalMazeDifficulty As Integer
                            normalMazeDifficulty = Int(5 * Rnd() + 1)
                            While normalMazeDifficulty = 1 Or normalMazeDifficulty = 5
                                normalMazeDifficulty = Int(6 * Rnd() + 1)
                            End While

                            Select Case normalMazeDifficulty
                                Case 2
                                    mazeWidth = 9
                                    mazeHeight = 9
                                Case 3
                                    mazeWidth = Int(11 * Rnd() + 20)
                                    mazeHeight = Int(11 * Rnd() + 20)
                                Case 4
                                    mazeWidth = Int(11 * Rnd() + 30)
                                    mazeHeight = Int(11 * Rnd() + 30)
                                Case 5
                                    mazeWidth = 44
                                    mazeHeight = 44
                            End Select
                            mazeMode = "N"
                        Case 3
                            mazeWidth = 24
                            mazeHeight = 24
                            mazeMode = "I"
                        Case 4
                            mazeWidth = 24
                            mazeHeight = 24
                            mazeMode = "M"
                    End Select

                    Dim maze(,) As String = MazeInitialisation(mazeWidth, mazeHeight, mazeMode, eActive)
                    MazeDisplay(maze, mazeWidth, mazeHeight)
                    MazeMovement(maze, mazeWidth, mazeHeight)

                    Console.SetCursorPosition(0, mazeHeight + 2)
                    Console.WriteLine("Press D or the right arrow to proceed to the next maze")
                    Console.WriteLine("Press A or the left arrow key to exit")
                    Dim keypressed As ConsoleKey
                    Do
                        keypressed = Console.ReadKey(True).Key
                        Select Case keypressed
                            Case ConsoleKey.D, ConsoleKey.RightArrow
                                nextMaze = 1
                            Case ConsoleKey.A, ConsoleKey.LeftArrow
                                nextMaze = 0
                            Case Else
                                nextMaze = 2
                        End Select
                    Loop Until nextMaze <> 2
                Loop Until nextMaze = 0
            Else
                Dim maze(,) As String = MazeInitialisation(mazeWidth, mazeHeight, mazeMode, eActive)
                MazeDisplay(maze, mazeWidth, mazeHeight)
                MazeMovement(maze, mazeWidth, mazeHeight)
            End If

            If eActive = True Then
                Console.SetCursorPosition(0, mazeHeight + 2)
                Console.WriteLine("                                                      ")
                Console.WriteLine("                                     ")
            End If

            Console.SetCursorPosition(0, mazeHeight + 2)
            Do
                Console.Write("Play again? [Y]es / [N]o ")
                loopSelection = Console.ReadLine()
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
        Console.ForegroundColor = ConsoleColor.White
        Console.Write("Exiting program.")
        Threading.Thread.Sleep(400)
        Console.Write(".")
        Threading.Thread.Sleep(400)
        Console.Write(".")
        Threading.Thread.Sleep(400)
    End Sub

End Module

