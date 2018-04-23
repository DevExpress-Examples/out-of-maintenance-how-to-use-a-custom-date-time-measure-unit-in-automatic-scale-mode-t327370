Namespace CustomDateTimeMeasureUnitSample
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.Chart = New DevExpress.XtraCharts.ChartControl()
            CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Chart
            '
            Me.Chart.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Chart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right
            Me.Chart.Location = New System.Drawing.Point(0, 0)
            Me.Chart.Name = "Chart"
            Me.Chart.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
            Me.Chart.Size = New System.Drawing.Size(624, 321)
            Me.Chart.TabIndex = 0
            '
            'Form1
            '
            Me.ClientSize = New System.Drawing.Size(624, 321)
            Me.Controls.Add(Me.Chart)
            Me.Name = "Form1"
            CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Friend WithEvents Chart As DevExpress.XtraCharts.ChartControl
    End Class
End Namespace

