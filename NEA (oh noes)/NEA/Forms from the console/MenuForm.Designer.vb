<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuForm
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.GraphButton = New System.Windows.Forms.Button()
        Me.myChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GraphDescBox = New System.Windows.Forms.TextBox()
        CType(Me.myChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GraphButton
        '
        Me.GraphButton.Location = New System.Drawing.Point(68, 12)
        Me.GraphButton.Name = "GraphButton"
        Me.GraphButton.Size = New System.Drawing.Size(208, 56)
        Me.GraphButton.TabIndex = 0
        Me.GraphButton.Text = "Graph button"
        Me.GraphButton.UseVisualStyleBackColor = True
        '
        'myChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.myChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.myChart.Legends.Add(Legend1)
        Me.myChart.Location = New System.Drawing.Point(415, 12)
        Me.myChart.Name = "myChart"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "myGraphData"
        Me.myChart.Series.Add(Series1)
        Me.myChart.Size = New System.Drawing.Size(704, 719)
        Me.myChart.TabIndex = 1
        Me.myChart.Text = "Chart1"
        '
        'GraphDescBox
        '
        Me.GraphDescBox.Location = New System.Drawing.Point(68, 269)
        Me.GraphDescBox.Multiline = True
        Me.GraphDescBox.Name = "GraphDescBox"
        Me.GraphDescBox.Size = New System.Drawing.Size(208, 162)
        Me.GraphDescBox.TabIndex = 2
        '
        'MenuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 743)
        Me.Controls.Add(Me.GraphDescBox)
        Me.Controls.Add(Me.myChart)
        Me.Controls.Add(Me.GraphButton)
        Me.Name = "MenuForm"
        Me.Text = "MenuForm"
        CType(Me.myChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GraphButton As Windows.Forms.Button
    Friend WithEvents myChart As Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GraphDescBox As Windows.Forms.TextBox
End Class
