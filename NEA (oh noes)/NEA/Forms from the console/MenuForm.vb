Public Class MenuForm
    Public changesetting As String
    Public datadictionaryXY As New Dictionary(Of Integer, Integer)

    Private Sub MenuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GraphButton.Text = "Launch graph"
    End Sub

    Private Sub GraphButton_Click(sender As Object, e As EventArgs) Handles GraphButton.Click
        Me.Height = 600
        Me.Width = 800
        GraphButton.Location = New Drawing.Point(10, 10) '0,0 is top left

        If changesetting = "L" Then
            GraphButton.Location = New Drawing.Point(817, 12)
            Me.Height = 208
            Me.Width = 56

            myChart.Location = New Drawing.Point(12, 12)
            myChart.Height = 704
            myChart.Width = 719

            GraphDescBox.Location = New Drawing.Point(817, 272)
            GraphDescBox.Height = 208
            GraphDescBox.Width = 162
        Else
            GraphButton.Location = New Drawing.Point(415, 12)
            Me.Height = 208
            Me.Width = 56

            myChart.Location = New Drawing.Point(68, 12)
            myChart.Height = 704
            myChart.Width = 719

            GraphDescBox.Location = New Drawing.Point(68, 272)
            GraphDescBox.Height = 208
            GraphDescBox.Width = 162
        End If



        For Each x In datadictionaryXY.Keys
            myChart.Series("myGraphData").Points.AddXY(x, datadictionaryXY(x))
        Next
    End Sub
End Class
