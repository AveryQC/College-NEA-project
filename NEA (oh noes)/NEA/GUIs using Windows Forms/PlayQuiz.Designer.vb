<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayQuiz
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CheckAnswersButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CheckAnswersButton
        '
        Me.CheckAnswersButton.Location = New System.Drawing.Point(640, 34)
        Me.CheckAnswersButton.Name = "CheckAnswersButton"
        Me.CheckAnswersButton.Size = New System.Drawing.Size(124, 38)
        Me.CheckAnswersButton.TabIndex = 0
        Me.CheckAnswersButton.Text = "Check answers"
        Me.CheckAnswersButton.UseVisualStyleBackColor = True
        '
        'PlayQuiz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CheckAnswersButton)
        Me.Name = "PlayQuiz"
        Me.Text = "PlayQuiz"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CheckAnswersButton As Button
End Class
