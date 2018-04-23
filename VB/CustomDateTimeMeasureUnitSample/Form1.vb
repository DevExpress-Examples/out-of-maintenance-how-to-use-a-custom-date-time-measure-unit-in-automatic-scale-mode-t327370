Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace CustomDateTimeMeasureUnitSample
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        #Region "#ChartConfiguring"
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Chart.Series.Add(GenerateSeries(10000))

            Dim diagram As XYDiagram = TryCast(Chart.Diagram, XYDiagram)
            If diagram Is Nothing Then
                Return
            End If

            diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Average
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Automatic
            diagram.AxisX.DateTimeScaleOptions.AutomaticMeasureUnitsCalculator = New CustomDateTimeMeasureUnitsCalculator()

            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = False
        End Sub
        #End Region ' #ChartConfiguring

        Private Function GenerateSeries(ByVal pointCount As Integer) As Series
            Dim series As Series = New Series With {.Name = "Generated data", .View = New SideBySideBarSeriesView()}
            Dim time As Date = Date.Now
            Dim generator As New Random()
            For i As Integer = 0 To pointCount - 1
                time = time.AddHours(1)
                series.Points.Add(New SeriesPoint(time, generator.NextDouble()))
            Next i
            Return series
        End Function
    End Class

    #Region "#DateTimeUnitsCalculatorImpl"
    Friend Class CustomDateTimeMeasureUnitsCalculator
        Implements IDateTimeMeasureUnitsCalculator

        Private Const daysInWeek As Integer = 7
        Private Const daysInMonth As Integer = 30
        Private Const daysInQuarter As Integer = 4 * daysInMonth
        Private Const daysInYear As Integer = 365

        Private Const minCount As Integer = 5

        Public Function CalculateMeasureUnit(
                ByVal series As IEnumerable(Of Series),
                ByVal axisLength As Double,
                ByVal pixelsPerUnit As Integer,
                ByVal visualMin As Double,
                ByVal visualMax As Double,
                ByVal wholeMin As Double,
                ByVal wholeMax As Double) As DateTimeMeasureUnit Implements IDateTimeMeasureUnitsCalculator.CalculateMeasureUnit
            ' Calculate visual range in msecs.
            Dim visualRange As Double = visualMax - visualMin
            Dim ts As TimeSpan = TimeSpan.FromMilliseconds(visualRange)
            If ts.TotalDays >= 1.0R Then
                If ts.TotalDays <= minCount * daysInWeek Then
                    Return DateTimeMeasureUnit.Day
                End If
                If ts.TotalDays <= minCount * daysInMonth Then
                    Return DateTimeMeasureUnit.Week
                End If
                If ts.TotalDays <= minCount * daysInQuarter Then
                    Return DateTimeMeasureUnit.Month
                End If
                If ts.TotalDays <= minCount * daysInYear Then
                    Return DateTimeMeasureUnit.Quarter
                Else
                    Return DateTimeMeasureUnit.Year
                End If
            ElseIf ts.TotalHours >= 20.0R Then
                Return DateTimeMeasureUnit.Hour
            ElseIf ts.TotalMinutes >= 20.0R Then
                Return DateTimeMeasureUnit.Minute
            ElseIf ts.TotalSeconds >= 20.0R Then
                Return DateTimeMeasureUnit.Second
            Else
                Return DateTimeMeasureUnit.Millisecond
            End If
        End Function
    End Class
    #End Region ' #DateTimeUnitsCalculatorImpl
End Namespace
