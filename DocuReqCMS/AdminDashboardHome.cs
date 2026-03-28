using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DocuReqCMS
{
    public partial class AdminDashboardHome : Form
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        private Panel staffDetailsPanel;
        private bool isStaffDetailsVisible = false;

        private Panel docReqDetailsPanel;
        private bool isDocReqVisible = false;

        private Panel activeCard = null;
        private Timer animationTimer;
        private int targetHeight;
        private int startHeight;
        private int animationStep = 0;
        private const int ANIMATION_STEPS = 10;

        private string adminName = "Administrator";

        public AdminDashboardHome(string adminUsername = "Administrator")
        {
            InitializeComponent();
            this.adminName = adminUsername;
            SetupCardAppearance();
            SetupClickEvents();
            SetupAnimationTimer();
            UpdateWelcomeMessage();
            SetupChartControls();

            this.Shown += (s, e) =>
            {
                LoadDashboardData();
                LoadRequestChartData();
            };
        }

        // ─────────────────────────────────────────────
        // WELCOME / DATETIME
        // ─────────────────────────────────────────────

        private void UpdateWelcomeMessage()
        {
            string timeGreeting = GetTimeBasedGreeting();
            lblWelcome.Text = $"{timeGreeting}, {adminName}!";
        }

        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 5 && hour < 12) return "Good Morning";
            if (hour >= 12 && hour < 17) return "Good Afternoon";
            if (hour >= 17 && hour < 22) return "Good Evening";
            return "Good Night";
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy  •  hh:mm tt");

            Timer clockTimer = new Timer { Interval = 60000 };
            clockTimer.Tick += (s, e) =>
                lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy  •  hh:mm tt");
            clockTimer.Start();
        }

        // ─────────────────────────────────────────────
        // ANIMATION
        // ─────────────────────────────────────────────

        private void SetupAnimationTimer()
        {
            animationTimer = new Timer { Interval = 15 };
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationStep++;
            double progress = (double)animationStep / ANIMATION_STEPS;
            double eased = 1 - Math.Pow(1 - progress, 3);
            int newHeight = (int)(startHeight + (targetHeight - startHeight) * eased);

            if (activeCard != null)
                activeCard.Height = newHeight;

            // Staff panel visibility
            if (activeCard == cardStaff && staffDetailsPanel != null)
            {
                if (targetHeight > startHeight && progress > 0.2 && !staffDetailsPanel.Visible)
                    staffDetailsPanel.Visible = true;
                else if (targetHeight <= startHeight && progress > 0.05 && staffDetailsPanel.Visible)
                    staffDetailsPanel.Visible = false;
            }

            // Doc req panel visibility
            if (activeCard == docreq && docReqDetailsPanel != null)
            {
                if (targetHeight > startHeight && progress > 0.2 && !docReqDetailsPanel.Visible)
                    docReqDetailsPanel.Visible = true;
                else if (targetHeight <= startHeight && progress > 0.05 && docReqDetailsPanel.Visible)
                    docReqDetailsPanel.Visible = false;
            }

            if (animationStep >= ANIMATION_STEPS)
            {
                animationTimer.Stop();
                if (activeCard != null) activeCard.Height = targetHeight;

                // Staff final state
                if (activeCard == cardStaff && staffDetailsPanel != null)
                {
                    if (targetHeight <= startHeight)
                    {
                        staffDetailsPanel.Visible = false;
                        staffDetailsPanel.Height = 0;
                    }
                    else
                    {
                        staffDetailsPanel.Height = 100;
                        staffDetailsPanel.Visible = true;
                        LoadRegistrarStats();
                        UpdateStaffDetailsValues();
                    }
                    isStaffDetailsVisible = targetHeight > startHeight;
                }

                // Doc req final state
                if (activeCard == docreq && docReqDetailsPanel != null)
                {
                    if (targetHeight <= startHeight)
                    {
                        docReqDetailsPanel.Visible = false;
                        docReqDetailsPanel.Height = 0;
                    }
                    else
                    {
                        docReqDetailsPanel.Height = 220;
                        docReqDetailsPanel.Visible = true;
                        UpdateDocReqValues();
                    }
                    isDocReqVisible = targetHeight > startHeight;
                }

                animationStep = 0;
            }
        }

        // ─────────────────────────────────────────────
        // CARD APPEARANCE & CLICKS
        // ─────────────────────────────────────────────

        private void SetupCardAppearance()
        {
            this.cardStaff.Paint += (sender, e) =>
            {
                Panel card = sender as Panel;
                using (Pen pen = new Pen(Color.FromArgb(100, 200, 100), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };

            this.docreq.Paint += (sender, e) =>
            {
                Panel card = sender as Panel;
                using (Pen pen = new Pen(Color.FromArgb(100, 200, 100), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };
        }

        private void SetupClickEvents()
        {
            cardStaff.Click += CardStaff_Click;
            docreq.Click += DocReq_Click;

            foreach (Control ctrl in cardStaff.Controls)
                ctrl.Click += CardStaff_Click;

            foreach (Control ctrl in docreq.Controls)
                ctrl.Click += DocReq_Click;
        }

        // ─────────────────────────────────────────────
        // LOAD ALL DASHBOARD DATA
        // ─────────────────────────────────────────────

        private void LoadDashboardData()
        {
            try
            {
                LoadRegistrarStats();
                LoadTotalDocumentRequests();
                UpdateDateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // STAFF CARD
        // ─────────────────────────────────────────────

        private void LoadRegistrarStats()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        COUNT(*) AS total,
                        IFNULL(SUM(status = 'ONLINE'),  0) AS online,
                        IFNULL(SUM(status = 'OFFLINE'), 0) AS offline
                    FROM users
                    WHERE role = 'REGISTRAR'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        lblStaffCount.Text = r["total"].ToString();
                        lblOnlineCount.Text = r["online"].ToString();
                        lblOfflineCount.Text = r["offline"].ToString();
                    }
                }
            }
        }

        private void CardStaff_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            activeCard = cardStaff;
            startHeight = cardStaff.Height;

            if (!isStaffDetailsVisible)
            {
                if (staffDetailsPanel == null) CreateStaffDetailsPanel();
                else UpdateStaffDetailsValues();
                targetHeight = 240;
            }
            else
            {
                targetHeight = 150;
            }

            animationStep = 0;
            animationTimer.Start();
        }

        private void CreateStaffDetailsPanel()
        {
            staffDetailsPanel = new Panel
            {
                Size = new Size(cardStaff.Width - 20, 100),
                Location = new Point(10, 130),
                BackColor = Color.FromArgb(108, 225, 108),
                Visible = false,
            };

            staffDetailsPanel.Controls.AddRange(new Control[]
            {
                new Label { Text = "Staff Online:",  Font = new Font("Segoe UI", 11, FontStyle.Regular), ForeColor = Color.White, Location = new Point(15, 15), Size = new Size(120, 25), BackColor = Color.Transparent },
                new Label { Text = lblOnlineCount.Text,  Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.White, Location = new Point(150, 12), Size = new Size(60, 30), BackColor = Color.Transparent },
                new Label { Text = "Staff Offline:", Font = new Font("Segoe UI", 11, FontStyle.Regular), ForeColor = Color.White, Location = new Point(15, 55), Size = new Size(120, 25), BackColor = Color.Transparent },
                new Label { Text = lblOfflineCount.Text, Font = new Font("Segoe UI", 16, FontStyle.Bold), ForeColor = Color.White, Location = new Point(150, 52), Size = new Size(60, 30), BackColor = Color.Transparent },
            });

            cardStaff.Controls.Add(staffDetailsPanel);
            staffDetailsPanel.BringToFront();
        }

        private void UpdateStaffDetailsValues()
        {
            if (staffDetailsPanel == null) return;

            foreach (Control ctrl in staffDetailsPanel.Controls)
            {
                if (ctrl is Label lbl && lbl.Font.Bold)
                {
                    if (lbl.Location.Y == 12) lbl.Text = lblOnlineCount.Text;
                    else if (lbl.Location.Y == 52) lbl.Text = lblOfflineCount.Text;
                }
            }
        }

        // ─────────────────────────────────────────────
        // DOCUMENT REQUEST CARD  ← table: Request
        // ─────────────────────────────────────────────

        private void LoadTotalDocumentRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                // Count all rows — every request_number is a request regardless of status
                string query = "SELECT COUNT(*) FROM Request";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    label1.Text = count.ToString();
                }
            }
        }

        private void DocReq_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            activeCard = docreq;
            startHeight = docreq.Height;

            if (!isDocReqVisible)
            {
                if (docReqDetailsPanel == null) CreateDocReqPanel();
                else UpdateDocReqValues();
                targetHeight = 350;
            }
            else
            {
                targetHeight = 150;
            }

            animationStep = 0;
            animationTimer.Start();
        }

        private void CreateDocReqPanel()
        {
            docReqDetailsPanel = new Panel
            {
                Size = new Size(docreq.Width - 20, 220),
                Location = new Point(10, 130),
                BackColor = Color.FromArgb(108, 225, 108),
                Visible = false,
            };

            // All statuses from Request.status enum
            string[] statuses =
            {
                "Pending",
                "Waiting for Payment",
                "Processing",
                "Ready",
                "Released",
                "Reported"
            };

            int y = 8;
            foreach (string status in statuses)
            {
                docReqDetailsPanel.Controls.Add(new Label
                {
                    Text = status + ":",
                    Location = new Point(15, y),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true
                });

                docReqDetailsPanel.Controls.Add(new Label
                {
                    Name = "lbl_" + status.Replace(" ", "_"),
                    Text = "0",
                    Location = new Point(195, y),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    AutoSize = true
                });

                y += 32;
            }

            docreq.Controls.Add(docReqDetailsPanel);
            docReqDetailsPanel.BringToFront();
            UpdateDocReqValues();
        }

        private void UpdateDocReqValues()
        {
            if (docReqDetailsPanel == null) return;

            // Reset all to 0
            foreach (Control c in docReqDetailsPanel.Controls)
            {
                if (c is Label lbl && lbl.Name.StartsWith("lbl_"))
                    lbl.Text = "0";
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // Group by status using the correct table name: Request
                string query = @"
                    SELECT status, COUNT(*) AS total
                    FROM Request
                    GROUP BY status";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader["status"].ToString().Replace(" ", "_");
                        string key = "lbl_" + status;

                        Control[] found = docReqDetailsPanel.Controls.Find(key, true);
                        if (found.Length > 0)
                            found[0].Text = reader["total"].ToString();
                    }
                }
            }
        }

        // ─────────────────────────────────────────────
        // CHART — Request trends using Request table
        // ─────────────────────────────────────────────

        private void SetupChartControls()
        {
            cmbTimeRange.Items.Clear();
            cmbTimeRange.Items.AddRange(new object[]
            {
                "Last 7 Days",
                "Last 15 Days",
                "Last 30 Days",
                "Last 3 Months",
                "This Year"
            });
            cmbTimeRange.SelectedIndex = 2; // default: Last 30 Days

            cmbTimeRange.SelectedIndexChanged += (s, e) => LoadRequestChartData();
            btnRefreshChart.Click += (s, e) => LoadRequestChartData();
        }

        private int GetDaysFromComboBox()
        {
            if (cmbTimeRange.SelectedItem == null) return 30;

            switch (cmbTimeRange.SelectedItem.ToString())
            {
                case "Last 7 Days": return 7;
                case "Last 15 Days": return 15;
                case "Last 30 Days": return 30;
                case "Last 3 Months": return 90;
                case "This Year": return 365;
                default: return 30;
            }
        }

        private void LoadRequestChartData()
        {
            try
            {
                int days = GetDaysFromComboBox();
                DateTime startDate = DateTime.Today.AddDays(-days + 1);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Use correct table: Request, correct date column: created_at
                    string query = @"
                        SELECT 
                            DATE(created_at) AS req_date,
                            COUNT(*)         AS total
                        FROM Request
                        WHERE DATE(created_at) >= @startDate
                          AND DATE(created_at) <= CURDATE()
                        GROUP BY DATE(created_at)
                        ORDER BY req_date ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Clear chart
                            chartKioskUsage.Series.Clear();
                            chartKioskUsage.ChartAreas[0].AxisX.CustomLabels.Clear();

                            // Build series
                            Series series = new Series("Requests")
                            {
                                ChartType = SeriesChartType.Area,
                                Color = Color.FromArgb(91, 208, 102),
                                BorderColor = Color.FromArgb(50, 160, 60),
                                BorderWidth = 2,
                                IsValueShownAsLabel = false,
                                XValueType = ChartValueType.Date,
                                MarkerStyle = MarkerStyle.Circle,
                                MarkerSize = 6,
                                MarkerColor = Color.FromArgb(30, 130, 50),
                            };

                            // Build date lookup from query results
                            var lookup = new System.Collections.Generic.Dictionary<DateTime, int>();
                            foreach (DataRow row in dt.Rows)
                            {
                                DateTime d = Convert.ToDateTime(row["req_date"]);
                                int n = Convert.ToInt32(row["total"]);
                                lookup[d.Date] = n;
                            }

                            int totalRequests = 0;
                            int maxCount = 0;
                            DateTime peakDay = DateTime.Today;

                            // Back-fill every date so gaps show as 0
                            for (DateTime d = startDate.Date; d <= DateTime.Today; d = d.AddDays(1))
                            {
                                int count = lookup.ContainsKey(d.Date) ? lookup[d.Date] : 0;
                                series.Points.AddXY(d, count);

                                totalRequests += count;
                                if (count > maxCount)
                                {
                                    maxCount = count;
                                    peakDay = d;
                                }
                            }

                            chartKioskUsage.Series.Add(series);

                            // Style chart area
                            ChartArea area = chartKioskUsage.ChartAreas[0];
                            area.BackColor = Color.White;
                            area.AxisX.LineColor = Color.LightGray;
                            area.AxisY.LineColor = Color.LightGray;
                            area.AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
                            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
                            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8);
                            area.AxisX.LabelStyle.ForeColor = Color.Gray;
                            area.AxisY.LabelStyle.ForeColor = Color.Gray;
                            area.AxisY.Minimum = 0;
                            area.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                            // X-axis format based on range
                            area.AxisX.LabelStyle.Format =
                                days <= 90 ? "MMM dd" : "MMM yyyy";

                            area.AxisX.Interval = days <= 15 ? 1 : days <= 30 ? 3 : days <= 90 ? 7 : 30;
                            area.AxisX.IntervalType = days <= 90
                                ? DateTimeIntervalType.Days
                                : DateTimeIntervalType.Months;

                            // Update stat labels
                            lblTotalUsersValue.Text = totalRequests.ToString("N0");

                            int spanDays = (int)(DateTime.Today - startDate).TotalDays + 1;
                            double avg = spanDays > 0 ? (double)totalRequests / spanDays : 0;
                            lblAvgDailyValue.Text = avg.ToString("F1");

                            lblPeakDayValue.Text = totalRequests > 0
                                ? peakDay.ToString("MMM dd, yyyy") + $"  ({maxCount} requests)"
                                : "No data";

                            chartKioskUsage.Invalidate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart data:\n{ex.Message}",
                    "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        // FORM LOAD
        // ─────────────────────────────────────────────

        private void AdminDashboardHome_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
    }
}