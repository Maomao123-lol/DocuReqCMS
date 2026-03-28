using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DocuReqCMS
{
    public partial class AdminDashboardHome : Form
    {
        private readonly string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private Panel staffDetailsPanel;
        private bool isStaffDetailsVisible = false;
        private Timer animationTimer;
        private int targetHeight;
        private int startHeight;
        private int animationStep = 0;
        private const int ANIMATION_STEPS = 10;
        private string adminName = "Administrator";
        private Panel docReqDetailsPanel;
        private bool isDocReqVisible = false;
        private Panel activeCard = null;

        public AdminDashboardHome(string adminUsername = "Administrator")
        {
            InitializeComponent();
            this.adminName = adminUsername;
            SetupCardAppearance();
            SetupClickEvents();
            SetupAnimationTimer();
            UpdateWelcomeMessage();
            SetupChartControls();

            // Load data after form is fully loaded
            this.Shown += (s, e) =>
            {
                LoadDashboardData();
                LoadKioskUsageData();
            };
        }

        private void UpdateWelcomeMessage()
        {
            string timeGreeting = GetTimeBasedGreeting();
            lblWelcome.Text = $"{timeGreeting}, {adminName}!";
        }

        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 5 && hour < 12)
                return "Good Morning";
            else if (hour >= 12 && hour < 17)
                return "Good Afternoon";
            else if (hour >= 17 && hour < 22)
                return "Good Evening";
            else
                return "Good Night";
        }

        private void SetupAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 15;
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

            // Staff panel visibility control
            if (activeCard == cardStaff && staffDetailsPanel != null)
            {
                if (targetHeight > startHeight) // Expanding
                {
                    if (progress > 0.2 && !staffDetailsPanel.Visible)
                        staffDetailsPanel.Visible = true;
                }
                else // Collapsing
                {
                    if (progress > 0.05 && staffDetailsPanel.Visible)
                        staffDetailsPanel.Visible = false;
                }
            }

            // Document requests panel visibility control
            if (activeCard == docreq && docReqDetailsPanel != null)
            {
                if (targetHeight > startHeight) // Expanding
                {
                    if (progress > 0.2 && !docReqDetailsPanel.Visible)
                        docReqDetailsPanel.Visible = true;
                }
                else // Collapsing
                {
                    if (progress > 0.05 && docReqDetailsPanel.Visible)
                        docReqDetailsPanel.Visible = false;
                }
            }

            // Final state after animation completes
            if (animationStep >= ANIMATION_STEPS)
            {
                animationTimer.Stop();

                if (activeCard != null)
                    activeCard.Height = targetHeight;

                // Staff panel final state
                if (activeCard == cardStaff && staffDetailsPanel != null)
                {
                    if (targetHeight <= startHeight) // collapsed
                    {
                        staffDetailsPanel.Visible = false;
                        staffDetailsPanel.Height = 0;
                    }
                    else
                    {
                        staffDetailsPanel.Height = 100;
                        staffDetailsPanel.Visible = true;
                        // Refresh staff data when expanded
                        LoadRegistrarStats();
                        UpdateStaffDetailsValues();
                    }

                    isStaffDetailsVisible = targetHeight > startHeight;
                }

                // Document requests panel final state
                if (activeCard == docreq && docReqDetailsPanel != null)
                {
                    if (targetHeight <= startHeight) // collapsed
                    {
                        docReqDetailsPanel.Visible = false;
                        docReqDetailsPanel.Height = 0;
                    }
                    else
                    {
                        docReqDetailsPanel.Height = 180;
                        docReqDetailsPanel.Visible = true;
                        // Refresh document requests when expanded
                        LoadDocumentRequests();
                        UpdateDocReqValues();
                    }

                    isDocReqVisible = targetHeight > startHeight;
                }

                animationStep = 0;
            }
        }

        private void SetupCardAppearance()
        {
            // Add paint event for card border
            this.cardStaff.Paint += (sender, e) =>
            {
                Panel card = sender as Panel;
                using (Pen pen = new Pen(Color.FromArgb(100, 200, 100), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            this.docreq.Paint += (sender, e) =>
            {
                Panel card = sender as Panel;
                using (Pen pen = new Pen(Color.FromArgb(100, 200, 100), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };
        }

        private void LoadDashboardData()
        {
            try
            {
                LoadRegistrarStats();
                LoadDocumentRequests();
                LoadKioskStatus();
                UpdateDateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy • hh:mm tt");

            Timer timer = new Timer();
            timer.Interval = 60000;
            timer.Tick += (s, e) =>
            {
                lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy • hh:mm tt");
            };
            timer.Start();
        }

        private void LoadRegistrarStats()
        {
            int total = 0, online = 0, offline = 0;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        COUNT(*) AS total,
                        IFNULL(SUM(status='ONLINE'),0) AS online,
                        IFNULL(SUM(status='OFFLINE'),0) AS offline
                    FROM users
                    WHERE role = 'REGISTRAR'";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        total = Convert.ToInt32(r["total"]);
                        online = Convert.ToInt32(r["online"]);
                        offline = Convert.ToInt32(r["offline"]);
                    }
                }
            }

            lblStaffCount.Text = total.ToString();
            lblOnlineCount.Text = online.ToString();
            lblOfflineCount.Text = offline.ToString();
        }

        private void LoadDocumentRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM document_requests WHERE request_date >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    label1.Text = count.ToString();
                }
            }
        }

        private void LoadKioskStatus()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM kiosk_usage WHERE usage_date = CURDATE()";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int todayCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (todayCount > 0)
                        {
                            label3.Text = "ONLINE";
                            label3.ForeColor = Color.White;
                            kiosk.BackColor = Color.FromArgb(128, 255, 128);
                        }
                        else
                        {
                            string checkQuery = "SELECT COUNT(*) FROM kiosk_usage";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                            {
                                int totalCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                                if (totalCount > 0)
                                {
                                    label3.Text = "STANDBY";
                                    kiosk.BackColor = Color.FromArgb(255, 193, 7);
                                }
                                else
                                {
                                    label3.Text = "NO DATA";
                                    kiosk.BackColor = Color.Gray;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                label3.Text = "ERROR";
                kiosk.BackColor = Color.Orange;
            }
        }

        private void SetupChartControls()
        {
            cmbTimeRange.SelectedIndex = 2; // Default to 30 days
            cmbTimeRange.SelectedIndexChanged += (s, e) => LoadKioskUsageData();
            btnRefreshChart.Click += (s, e) => LoadKioskUsageData();
        }

        private void LoadKioskUsageData()
        {
            try
            {
                int days = GetDaysFromComboBox();
                DateTime startDate = DateTime.Now.AddDays(-days);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT usage_date, 
                               IFNULL(student_count, 0) as student_count,
                               IFNULL(staff_count, 0) as staff_count,
                               IFNULL(visitor_count, 0) as visitor_count,
                               IFNULL(total_count, 0) as total_count
                        FROM kiosk_usage 
                        WHERE usage_date >= @startDate 
                        ORDER BY usage_date";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate.Date);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Clear existing data
                            chartKioskUsage.Series["Users"].Points.Clear();

                            if (dt.Rows.Count == 0)
                            {
                                chartKioskUsage.Series["Users"].Points.AddXY("No Data", 0);
                                lblTotalUsersValue.Text = "0";
                                lblAvgDailyValue.Text = "0";
                                lblPeakDayValue.Text = "No data";
                                return;
                            }

                            int total = 0;
                            int maxCount = 0;
                            DateTime peakDay = DateTime.MinValue;

                            foreach (DataRow row in dt.Rows)
                            {
                                DateTime date = Convert.ToDateTime(row["usage_date"]);
                                int count = Convert.ToInt32(row["total_count"]);

                                chartKioskUsage.Series["Users"].Points.AddXY(date.ToString("MMM dd"), count);

                                total += count;
                                if (count > maxCount)
                                {
                                    maxCount = count;
                                    peakDay = date;
                                }
                            }

                            // Update statistics
                            lblTotalUsersValue.Text = total.ToString("N0");

                            if (dt.Rows.Count > 0)
                            {
                                double avg = (double)total / dt.Rows.Count;
                                lblAvgDailyValue.Text = avg.ToString("F0");
                                lblPeakDayValue.Text = peakDay.ToString("MMM dd, yyyy") + $" ({maxCount} users)";
                            }

                            chartKioskUsage.Invalidate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart data: {ex.Message}", "Chart Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetDaysFromComboBox()
        {
            if (cmbTimeRange.SelectedItem == null)
                return 30;

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

        private void SetupClickEvents()
        {
            cardStaff.Click += CardStaff_Click;
            docreq.Click += DocReq_Click;

            foreach (Control ctrl in cardStaff.Controls)
                ctrl.Click += CardStaff_Click;

            foreach (Control ctrl in docreq.Controls)
                ctrl.Click += DocReq_Click;
        }

        private void CardStaff_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();

            activeCard = cardStaff;
            startHeight = cardStaff.Height;

            if (!isStaffDetailsVisible)
            {
                if (staffDetailsPanel == null)
                    CreateStaffDetailsPanel();
                else
                    UpdateStaffDetailsValues();

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

            // Online staff row
            Label lblOnlineTitle = new Label
            {
                Text = "Staff Online:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(15, 15),
                Size = new Size(100, 25),
                BackColor = Color.Transparent
            };

            Label lblOnlineValue = new Label
            {
                Text = lblOnlineCount.Text,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(130, 12),
                Size = new Size(50, 30),
                BackColor = Color.Transparent
            };

            // Offline staff row
            Label lblOfflineTitle = new Label
            {
                Text = "Staff Offline:",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.White,
                Location = new Point(15, 55),
                Size = new Size(100, 25),
                BackColor = Color.Transparent
            };

            Label lblOfflineValue = new Label
            {
                Text = lblOfflineCount.Text,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(130, 52),
                Size = new Size(50, 30),
                BackColor = Color.Transparent
            };

            staffDetailsPanel.Controls.AddRange(new Control[] {
                lblOnlineTitle, lblOnlineValue,
                lblOfflineTitle, lblOfflineValue
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
                    if (lbl.Location.Y == 12)
                    {
                        lbl.Text = lblOnlineCount.Text;
                    }
                    else if (lbl.Location.Y == 52)
                    {
                        lbl.Text = lblOfflineCount.Text;
                    }
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
                if (docReqDetailsPanel == null)
                    CreateDocReqPanel();
                else
                    UpdateDocReqValues();

                targetHeight = 310;
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
                Size = new Size(docreq.Width - 20, 180),
                Location = new Point(10, 130),
                BackColor = Color.FromArgb(108, 225, 108),
                Visible = false,
            };

            string[] statuses = { "Pending", "Under Review", "Processing", "Approved", "Released" };
            int y = 10;

            foreach (string status in statuses)
            {
                Label title = new Label
                {
                    Text = status + ":",
                    Location = new Point(15, y),
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    AutoSize = true
                };

                Label value = new Label
                {
                    Name = "lbl" + status.Replace(" ", ""),
                    Text = "0",
                    Location = new Point(150, y),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    AutoSize = true
                };

                docReqDetailsPanel.Controls.Add(title);
                docReqDetailsPanel.Controls.Add(value);

                y += 32;
            }

            docreq.Controls.Add(docReqDetailsPanel);
            docReqDetailsPanel.BringToFront();
            UpdateDocReqValues();
        }

        private void UpdateDocReqValues()
        {
            if (docReqDetailsPanel == null) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT request_status, COUNT(*) total
                    FROM document_requests
                    GROUP BY request_status";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Reset all values first
                    foreach (Control c in docReqDetailsPanel.Controls)
                    {
                        if (c is Label lbl && lbl.Name.StartsWith("lbl"))
                            lbl.Text = "0";
                    }

                    // Fill actual data
                    while (reader.Read())
                    {
                        string status = reader["request_status"].ToString().Replace(" ", "");
                        string key = "lbl" + status;

                        Control[] found = docReqDetailsPanel.Controls.Find(key, true);

                        if (found.Length > 0)
                        {
                            found[0].Text = reader["total"].ToString();
                        }
                    }
                }
            }
        }

        private void AdminDashboardHome_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }
    }
}