Public Class MainMenu
    Private Sub CreatorButton_Click(sender As Object, e As EventArgs) Handles CreatorButton.Click
        QuizCreator.Show()
    End Sub

    Private Sub PlayButton_Click(sender As Object, e As EventArgs) Handles PlayButton.Click
        PlayQuiz.Show()
    End Sub
End Class
