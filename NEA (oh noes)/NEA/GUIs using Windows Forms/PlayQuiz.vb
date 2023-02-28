Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class PlayQuiz
    Structure quizquestions
        Dim questionnumber As Integer
        Dim questions As String
        Dim a As String
        Dim b As String
        Dim c As String
        Dim d As String
        Dim correct As String
    End Structure

    Dim myQuizQuestions As New List(Of quizquestions)
    Dim gboxes As New List(Of GroupBox)

    Private Sub PlayQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filename As String
        filename = InputBox("Type in filename", "Filename")

        Dim question As quizquestions
        Using reader As StreamReader = New StreamReader(filename)
            Do Until reader.EndOfStream
                question.questionnumber = reader.ReadLine
                question.questions = reader.ReadLine
                question.a = reader.ReadLine
                question.b = reader.ReadLine
                question.c = reader.ReadLine
                question.d = reader.ReadLine
                question.correct = reader.ReadLine
                myQuizQuestions.Add(question)
            Loop
        End Using

        Dim numOfQuestions = myQuizQuestions.Count
        Dim locationvariable As Integer = 0
        For i = 1 To numOfQuestions
            Dim g As New GroupBox
            g.Name = "g" & i
            g.BackColor = Color.LightGray
            g.Text = "question" & i
            g.Location = New Point(10, 10 + locationvariable)
            g.Size = New Size(360, 150)
            gboxes.Add(g)
            Me.Controls.Add(g)
            locationvariable += 200
        Next

        For Each question In myQuizQuestions
            Dim l As New Label
            l.Name = question.questionnumber
            l.Text = question.questions
            l.Location = New Point(15, 15)
            l.Size = New Size(300, 60)
            l.BorderStyle = BorderStyle.FixedSingle
            gboxes(question.questionnumber - 1).Controls.Add(l)
            Me.Controls.Add(gboxes(question.questionnumber - 1))

            Dim a As New Label
            a.Name = "AnswerLabel" & question.questionnumber
            a.Text = "Answer"
            a.Location = New Point(15, 90)
            a.Font = New Font("Arial", 11)
            gboxes(question.questionnumber - 1).Controls.Add(a)
            Me.Controls.Add(gboxes(question.questionnumber - 1))

            Dim c As New ComboBox
            c.Name = question.questionnumber & "combo"
            c.Location = New Point(125, 90)
            c.Font = New Font("Arial", 11)
            c.Items.Add(question.a)
            c.Items.Add(question.b)
            c.Items.Add(question.c)
            c.Items.Add(question.d)
            gboxes(question.questionnumber - 1).Controls.Add(c)
            Me.Controls.Add(gboxes(question.questionnumber - 1))
        Next

        Dim b As New Button
        b.Name = "menuButton"
        b.Text = "main menu"
        b.Location = New Point(640, locationvariable - 150)
        b.Size = New Size(140, 50)
        b.Font = New Font("Arial", 11)
        b.FlatStyle = FlatStyle.Popup
        b.BackColor = Color.Cyan
        AddHandler b.Click, AddressOf Me.Buttonsclick
        Me.Controls.Add(b)

    End Sub

    Private Sub Buttonsclick(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CheckAnswersButton_Click(sender As Object, e As EventArgs) Handles CheckAnswersButton.Click
        Dim score As Integer = 0
        Dim count As Integer = 0
        For Each g As GroupBox In Me.Controls.OfType(Of GroupBox)
            For Each c As ComboBox In g.Controls.OfType(Of ComboBox)
                If c.SelectedIndex = Asc(myQuizQuestions(count).correct) - 97 Then
                    score += 1
                End If
                count += 1
            Next
        Next
        MsgBox("Your score: " & score,, "Score")

    End Sub
End Class