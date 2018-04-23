using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomDateTimeMeasureUnitSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        #region #ChartConfiguring
        private void Form1_Load(object sender, EventArgs e) {
            chart.Series.Add(GenerateSeries(10000));

            XYDiagram diagram = chart.Diagram as XYDiagram;
            if (diagram == null) return;

            diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Average;
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Automatic;
            diagram.AxisX.DateTimeScaleOptions.AutomaticMeasureUnitsCalculator = new CustomDateTimeMeasureUnitsCalculator();

            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;
        }
        #endregion #ChartConfiguring

        Series GenerateSeries(int pointCount) {
            Series series = new Series {
                Name = "Generated data",
                View = new SideBySideBarSeriesView()
            };
            DateTime time = DateTime.Now;
            Random generator = new Random();
            for (int i = 0; i < pointCount; ++i) {
                time = time.AddHours(1);
                series.Points.Add(new SeriesPoint(time, generator.NextDouble()));
            }
            return series;
        }
    }

    #region #DateTimeUnitsCalculatorImpl
    class CustomDateTimeMeasureUnitsCalculator : IDateTimeMeasureUnitsCalculator {
        const int daysInWeek = 7;
        const int daysInMonth = 30;
        const int daysInQuarter = 4 * daysInMonth;
        const int daysInYear = 365;

        const int minCount = 5;

        public DateTimeMeasureUnit CalculateMeasureUnit(
                IEnumerable<Series> series, 
                double axisLength, 
                int pixelsPerUnit, 
                double visualMin, 
                double visualMax, 
                double wholeMin, 
                double wholeMax) {
            // Calculate visual range in msecs.
            double visualRange = visualMax - visualMin;
            TimeSpan ts = TimeSpan.FromMilliseconds(visualRange);
            if (ts.TotalDays >= 1.0d) {
                if (ts.TotalDays <= minCount * daysInWeek)
                    return DateTimeMeasureUnit.Day;
                if (ts.TotalDays <= minCount * daysInMonth)
                    return DateTimeMeasureUnit.Week;
                if (ts.TotalDays <= minCount * daysInQuarter)
                    return DateTimeMeasureUnit.Month;
                if (ts.TotalDays <= minCount * daysInYear)
                    return DateTimeMeasureUnit.Quarter;
                else
                    return DateTimeMeasureUnit.Year;
            }
            else if (ts.TotalHours >= 20.0d)
                return DateTimeMeasureUnit.Hour;
            else if (ts.TotalMinutes >= 20.0d)
                return DateTimeMeasureUnit.Minute;
            else if (ts.TotalSeconds >= 20.0d)
                return DateTimeMeasureUnit.Second;
            else
                return DateTimeMeasureUnit.Millisecond;
        }
    }
    #endregion #DateTimeUnitsCalculatorImpl
}
