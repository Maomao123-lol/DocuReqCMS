using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Windows.Forms;
using System.Windows.Media;

namespace DocuFlow_Reg.UserControls
{
    public partial class DashboardUC : UserControl
    {
        public DashboardUC()
        {
            InitializeComponent();
            this.Load += DashboardUC_Load;
        }

       private void DashboardUC_Load(object sender, EventArgs e)
        {
            SetDocumentTypeChart();
            SetupRequestTrendChart();
        }

        private void SetDocumentTypeChart()
        {
            // ── Sample data (replace with DB query) ──
            var documentTypes = new[]
            {
                "Transcript",
                "Diploma",
                "Cert of Enrollment",
                "Good Moral",
                "Form 137",
                "Hon. Dismissal",
                "TOR",
                "Medical"
            };

            var requestCounts = new ChartValues<int> { 89, 54, 67, 41, 33, 22, 50, 120 };

            // ── Configure Axes FIRST ──
            chDocumentTypeDistribution.AxisX = new AxesCollection
            {
                new Axis
                {
                    Title = "Document Type",
                    Labels = documentTypes,
                    FontSize = 11,
                    LabelsRotation = 45,
                    Separator = new Separator { StrokeThickness = 0 } // removes vertical grid lines
                }
            };

            chDocumentTypeDistribution.AxisY = new AxesCollection
            {
                new Axis
                {
                    Title = "No. of Requests",
                    MinValue = 0,
                    FontSize = 11,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        Stroke = new SolidColorBrush(Color.FromArgb(40, 0, 0, 0))
                    }
                }
            };

            // ── Configure Series LAST ──
            chDocumentTypeDistribution.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Requests",
                    Values = requestCounts,
                    DataLabels = true,
                    FontSize = 11,
                    Fill = new SolidColorBrush(Color.FromRgb(26, 122, 26)), // green bars
                    StrokeThickness = 0,
                    MaxColumnWidth = 40
                }
            };

            // Optional: remove legend for a cleaner look
            chDocumentTypeDistribution.LegendLocation = LegendLocation.None;
            chDocumentTypeDistribution.AxisX[0].Separator.Step = 1;
        }

        private void SetupRequestTrendChart()
        {
            // Sample data: number of requests per day of the week
            int[] requestsPerDay = { 18, 9, 15, 22, 5 }; // Sun to Sat

            // Clear existing series and axes
            chRequestTrend.Series.Clear();
            chRequestTrend.AxisX.Clear();
            chRequestTrend.AxisY.Clear();

            // 1. Add LineSeries
            var lineSeries = new LiveCharts.Wpf.LineSeries
            {
                Title = "Requests",
                Values = new ChartValues<int>(requestsPerDay),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 10,
                StrokeThickness = 2,
                Fill = System.Windows.Media.Brushes.DarkSeaGreen, // no fill under the line
                Opacity = 0.2
            };
            chRequestTrend.Series.Add(lineSeries);

            // 2. Setup X-axis labels (days of the week)
            chRequestTrend.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Day of Week",
                Labels = new[] {"Mon", "Tue", "Wed", "Thu", "Fri" },
                LabelsRotation = 15, // tilts labels slightly for readability
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1, // show every label
                    IsEnabled = false // hides vertical grid lines
                }
            });

            // 3. Setup Y-axis
            chRequestTrend.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Number of Requests",
                LabelFormatter = value => value.ToString("N0") // integer formatting
            });

            // Optional: disable chart legend if not needed
            chRequestTrend.LegendLocation = LegendLocation.Top;
        }
    }
}