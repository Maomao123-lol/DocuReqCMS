using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Media;

namespace DocuFlow_Reg.UserControls
{
    public partial class DashboardUC : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        public DashboardUC()
        {
            InitializeComponent();
            this.Load += DashboardUC_Load;
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {
            SetDocumentTypeChart();
            LoadRequestTrend("Weekly"); // default filter on load

            lblPendingRequest.Text = db.getDashboardCount("SELECT COUNT(*) FROM Request WHERE status = 'Pending'").ToString();
            lblPendingPayment.Text = db.getDashboardCount("SELECT COUNT(*) FROM Request WHERE status = 'Waiting for Payment'").ToString();
            lblReadyToRelease.Text = db.getDashboardCount("SELECT COUNT(*) FROM Request WHERE status = 'Ready'").ToString();
            lblReleased.Text = db.getDashboardCount("SELECT COUNT(*) FROM Request WHERE status = 'Released'").ToString();
        }

        private void SetDocumentTypeChart()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT d.document_name, COUNT(r.request_number) as request_count
                FROM Request r
                INNER JOIN Document_Data d ON r.document_id = d.document_id
                GROUP BY d.document_name
            ");

            var documentTypes = new List<string>();
            var requestCounts = new ChartValues<int>();

            foreach (DataRow row in dt.Rows)
            {
                documentTypes.Add(row["document_name"].ToString());
                requestCounts.Add(Convert.ToInt32(row["request_count"]));
            }

            chDocumentTypeDistribution.AxisX = new AxesCollection
            {
                new Axis
                {
                    Title = "Document Type",
                    Labels = documentTypes,
                    FontSize = 11,
                    LabelsRotation = 45,
                    Separator = new Separator { StrokeThickness = 0 }
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

            chDocumentTypeDistribution.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Requests",
                    Values = requestCounts,
                    DataLabels = true,
                    FontSize = 11,
                    Fill = new SolidColorBrush(Color.FromRgb(26, 122, 26)),
                    StrokeThickness = 0,
                    MaxColumnWidth = 40
                }
            };

            chDocumentTypeDistribution.LegendLocation = LegendLocation.None;
            chDocumentTypeDistribution.AxisX[0].Separator.Step = 1;
        }

        private void LoadRequestTrend(string filter)
        {
            string query = "";
            string xAxisTitle = "";

            switch (filter)
            {
                case "Daily":
                    query = @"
                    SELECT CONCAT(HOUR(MIN(created_at)), ':00') as period, 
                           COUNT(*) as request_count
                    FROM Request
                    WHERE DATE(created_at) = CURDATE()
                    GROUP BY HOUR(created_at)
                    ORDER BY HOUR(created_at)";
                    xAxisTitle = "Hour of Day";
                    break;

                case "Weekly":
                    query = @"
                SELECT DAYNAME(MIN(created_at)) as period, 
                       COUNT(*) as request_count
                FROM Request
                WHERE WEEK(created_at) = WEEK(CURDATE())
                AND YEAR(created_at) = YEAR(CURDATE())
                GROUP BY DAYOFWEEK(created_at)
                ORDER BY DAYOFWEEK(created_at)";
                    xAxisTitle = "Day of Week";
                    break;

                case "Monthly":
                    query = @"
                SELECT DAY(created_at) as period, 
                       COUNT(*) as request_count
                FROM Request
                WHERE MONTH(created_at) = MONTH(CURDATE())
                AND YEAR(created_at) = YEAR(CURDATE())
                GROUP BY DAY(created_at)
                ORDER BY DAY(created_at)";
                    xAxisTitle = "Day of Month";
                    break;

                case "Yearly":
                    query = @"
                SELECT MONTHNAME(MIN(created_at)) as period, 
                       COUNT(*) as request_count
                FROM Request
                WHERE YEAR(created_at) = YEAR(CURDATE())
                GROUP BY MONTH(created_at)
                ORDER BY MONTH(created_at)";
                    xAxisTitle = "Month";
                    break;

                default:
                    return;
            }

            DataTable dt = db.ExecuteQuery(query);

            var periodLabels = new List<string>();
            var requestCounts = new ChartValues<int>();

            foreach (DataRow row in dt.Rows)
            {
                periodLabels.Add(row["period"].ToString());
                requestCounts.Add(Convert.ToInt32(row["request_count"]));
            }

            if (periodLabels.Count == 0)
            {
                periodLabels = new List<string> { "No Data" };
                requestCounts = new ChartValues<int> { 0 };
            }

            chRequestTrend.Series.Clear();
            chRequestTrend.AxisX.Clear();
            chRequestTrend.AxisY.Clear();

            chRequestTrend.Series.Add(new LiveCharts.Wpf.LineSeries
            {
                Title = "Requests",
                Values = requestCounts,
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 10,
                StrokeThickness = 2,
                Fill = System.Windows.Media.Brushes.DarkSeaGreen,
                Opacity = 0.2
            });

            chRequestTrend.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = xAxisTitle,
                Labels = periodLabels,
                LabelsRotation = 15,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = false
                }
            });

            chRequestTrend.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Number of Requests",
                LabelFormatter = value => value.ToString("N0")
            });

            chRequestTrend.LegendLocation = LegendLocation.Top;
        }

        private void cbWidgetFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequestTrend(cbWidgetFilter.SelectedItem.ToString());
        }

        private void pnlPendingRequest_Click(object sender, EventArgs e)
        {

        }

        private void pnlPendingPayment_Click(object sender, EventArgs e)
        {

        }

        private void pnlReadyToRelease_Click(object sender, EventArgs e)
        {

        }

        private void pnlReleased_Click(object sender, EventArgs e)
        {

        }
    }
}