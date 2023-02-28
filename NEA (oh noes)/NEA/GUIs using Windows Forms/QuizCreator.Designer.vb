<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuizCreator
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
        Me.QuizNameGroupBox = New System.Windows.Forms.GroupBox()
        Me.QuizNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CorrectAnswerComboBox = New System.Windows.Forms.ComboBox()
        Me.TextBoxD = New System.Windows.Forms.TextBox()
        Me.TextBoxC = New System.Windows.Forms.TextBox()
        Me.TextBoxB = New System.Windows.Forms.TextBox()
        Me.TextBoxA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.QuestionTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.QuestionNumberTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AddQuestionButton = New System.Windows.Forms.Button()
        Me.ClearTextButton = New System.Windows.Forms.Button()
        Me.MainMenuButton = New System.Windows.Forms.Button()
        Me.QuizNameGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'QuizNameGroupBox
        '
        Me.QuizNameGroupBox.BackColor = System.Drawing.Color.CadetBlue
        Me.QuizNameGroupBox.Controls.Add(Me.QuizNameTextBox)
        Me.QuizNameGroupBox.Controls.Add(Me.Label1)
        Me.QuizNameGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.QuizNameGroupBox.Name = "QuizNameGroupBox"
        Me.QuizNameGroupBox.Size = New System.Drawing.Size(595, 100)
        Me.QuizNameGroupBox.TabIndex = 0
        Me.QuizNameGroupBox.TabStop = False
        Me.QuizNameGroupBox.Text = "GroupBox1"
        '
        'QuizNameTextBox
        '
        Me.QuizNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuizNameTextBox.Location = New System.Drawing.Point(114, 46)
        Me.QuizNameTextBox.Name = "QuizNameTextBox"
        Me.QuizNameTextBox.Size = New System.Drawing.Size(274, 28)
        Me.QuizNameTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quiz name"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.CadetBlue
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.CorrectAnswerComboBox)
        Me.GroupBox1.Controls.Add(Me.TextBoxD)
        Me.GroupBox1.Controls.Add(Me.TextBoxC)
        Me.GroupBox1.Controls.Add(Me.TextBoxB)
        Me.GroupBox1.Controls.Add(Me.TextBoxA)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.QuestionTextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.QuestionNumberTextBox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 430)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 343)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(157, 30)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Correct answer"
        '
        'CorrectAnswerComboBox
        '
        Me.CorrectAnswerComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CorrectAnswerComboBox.FormattingEnabled = True
        Me.CorrectAnswerComboBox.Items.AddRange(New Object() {"A", "B", "C", "D"})
        Me.CorrectAnswerComboBox.Location = New System.Drawing.Point(195, 343)
        Me.CorrectAnswerComboBox.Name = "CorrectAnswerComboBox"
        Me.CorrectAnswerComboBox.Size = New System.Drawing.Size(167, 30)
        Me.CorrectAnswerComboBox.TabIndex = 14
        '
        'TextBoxD
        '
        Me.TextBoxD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxD.Location = New System.Drawing.Point(195, 276)
        Me.TextBoxD.Name = "TextBoxD"
        Me.TextBoxD.Size = New System.Drawing.Size(274, 28)
        Me.TextBoxD.TabIndex = 13
        '
        'TextBoxC
        '
        Me.TextBoxC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxC.Location = New System.Drawing.Point(195, 233)
        Me.TextBoxC.Name = "TextBoxC"
        Me.TextBoxC.Size = New System.Drawing.Size(274, 28)
        Me.TextBoxC.TabIndex = 12
        '
        'TextBoxB
        '
        Me.TextBoxB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxB.Location = New System.Drawing.Point(195, 193)
        Me.TextBoxB.Name = "TextBoxB"
        Me.TextBoxB.Size = New System.Drawing.Size(274, 28)
        Me.TextBoxB.TabIndex = 11
        '
        'TextBoxA
        '
        Me.TextBoxA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxA.Location = New System.Drawing.Point(195, 148)
        Me.TextBoxA.Name = "TextBoxA"
        Me.TextBoxA.Size = New System.Drawing.Size(274, 28)
        Me.TextBoxA.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(165, 276)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 32)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "D"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(165, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 32)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "C"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(165, 189)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 32)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "B"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(165, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 32)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "A"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(157, 54)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Multiple choice answers"
        '
        'QuestionTextBox
        '
        Me.QuestionTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuestionTextBox.Location = New System.Drawing.Point(169, 66)
        Me.QuestionTextBox.Multiline = True
        Me.QuestionTextBox.Name = "QuestionTextBox"
        Me.QuestionTextBox.Size = New System.Drawing.Size(300, 70)
        Me.QuestionTextBox.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Question"
        '
        'QuestionNumberTextBox
        '
        Me.QuestionNumberTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuestionNumberTextBox.Location = New System.Drawing.Point(169, 32)
        Me.QuestionNumberTextBox.Name = "QuestionNumberTextBox"
        Me.QuestionNumberTextBox.Size = New System.Drawing.Size(43, 28)
        Me.QuestionNumberTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Question number"
        '
        'AddQuestionButton
        '
        Me.AddQuestionButton.BackColor = System.Drawing.Color.MediumOrchid
        Me.AddQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AddQuestionButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddQuestionButton.Location = New System.Drawing.Point(61, 598)
        Me.AddQuestionButton.Name = "AddQuestionButton"
        Me.AddQuestionButton.Size = New System.Drawing.Size(175, 93)
        Me.AddQuestionButton.TabIndex = 2
        Me.AddQuestionButton.Text = "Add question"
        Me.AddQuestionButton.UseVisualStyleBackColor = False
        '
        'ClearTextButton
        '
        Me.ClearTextButton.BackColor = System.Drawing.Color.MediumOrchid
        Me.ClearTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearTextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearTextButton.Location = New System.Drawing.Point(268, 598)
        Me.ClearTextButton.Name = "ClearTextButton"
        Me.ClearTextButton.Size = New System.Drawing.Size(175, 93)
        Me.ClearTextButton.TabIndex = 3
        Me.ClearTextButton.Text = "Clear text"
        Me.ClearTextButton.UseVisualStyleBackColor = False
        '
        'MainMenuButton
        '
        Me.MainMenuButton.BackColor = System.Drawing.Color.MediumOrchid
        Me.MainMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MainMenuButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuButton.Location = New System.Drawing.Point(469, 598)
        Me.MainMenuButton.Name = "MainMenuButton"
        Me.MainMenuButton.Size = New System.Drawing.Size(175, 93)
        Me.MainMenuButton.TabIndex = 4
        Me.MainMenuButton.Text = "Main menu"
        Me.MainMenuButton.UseVisualStyleBackColor = False
        '
        'QuizCreator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.ClientSize = New System.Drawing.Size(800, 794)
        Me.Controls.Add(Me.MainMenuButton)
        Me.Controls.Add(Me.ClearTextButton)
        Me.Controls.Add(Me.AddQuestionButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.QuizNameGroupBox)
        Me.Name = "QuizCreator"
        Me.Text = "QuizCreator"
        Me.QuizNameGroupBox.ResumeLayout(False)
        Me.QuizNameGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents QuizNameGroupBox As GroupBox
    Friend WithEvents QuizNameTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents QuestionNumberTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents QuestionTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CorrectAnswerComboBox As ComboBox
    Friend WithEvents TextBoxD As TextBox
    Friend WithEvents TextBoxC As TextBox
    Friend WithEvents TextBoxB As TextBox
    Friend WithEvents TextBoxA As TextBox
    Friend WithEvents AddQuestionButton As Button
    Friend WithEvents ClearTextButton As Button
    Friend WithEvents MainMenuButton As Button
End Class
