Imports System.IO
Public Class QuizCreator
    Private Sub MainMenuButton_Click(sender As Object, e As EventArgs) Handles MainMenuButton.Click
        Me.Close()
    End Sub

    Private Sub ClearTextButton_Click(sender As Object, e As EventArgs) Handles ClearTextButton.Click
        QuestionNumberTextBox.Clear()
        QuestionTextBox.Clear()
        TextBoxA.Clear()
        TextBoxB.Clear()
        TextBoxC.Clear()
        TextBoxD.Clear()
        CorrectAnswerComboBox.Text = ""
    End Sub

    Private Sub AddQuestionButton_Click(sender As Object, e As EventArgs) Handles AddQuestionButton.Click
        Dim filename As String = QuizNameTextBox.Text
        Dim append As Boolean = True

        Using writer As StreamWriter = New StreamWriter(filename, append)
            writer.WriteLine(QuestionNumberTextBox.Text)
            writer.WriteLine(QuestionTextBox.Text)
            writer.WriteLine(TextBoxA.Text)
            writer.WriteLine(TextBoxB.Text)
            writer.WriteLine(TextBoxC.Text)
            writer.WriteLine(TextBoxD.Text)
            writer.WriteLine(CorrectAnswerComboBox.Text)
        End Using
        MsgBox("Question saved")

    End Sub
End Class