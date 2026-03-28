namespace DocuReqCMS
{
    partial class AdminDashboardHome
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel cardStaff;
        private System.Windows.Forms.Label lblStaffCount;
        private System.Windows.Forms.Label lblStaffTitle;
        private System.Windows.Forms.Label lblOnlineCount;
        private System.Windows.Forms.Label lblOfflineCount;
        private System.Windows.Forms.Panel docreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel kiosk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        // Chart controls
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.ComboBox cmbTimeRange;
        private System.Windows.Forms.Button btnRefreshChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartKioskUsage;
        private System.Windows.Forms.Panel chartStatsPanel;
        private System.Windows.Forms.Label lblTotalUsers;
        private System.Windows.Forms.Label lblTotalUsersValue;
        private System.Windows.Forms.Label lblAvgDaily;
        private System.Windows.Forms.Label lblAvgDailyValue;
        private System.Windows.Forms.Label lblPeakDay;
        private System.Windows.Forms.Label lblPeakDayValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.cardStaff = new System.Windows.Forms.Panel();
            this.lblStaffCount = new System.Windows.Forms.Label();
            this.lblStaffTitle = new System.Windows.Forms.Label();
            this.kiosk = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.docreq = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.cmbTimeRange = new System.Windows.Forms.ComboBox();
            this.btnRefreshChart = new System.Windows.Forms.Button();
            this.chartKioskUsage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartStatsPanel = new System.Windows.Forms.Panel();
            this.lblTotalUsers = new System.Windows.Forms.Label();
            this.lblTotalUsersValue = new System.Windows.Forms.Label();
            this.lblAvgDaily = new System.Windows.Forms.Label();
            this.lblAvgDailyValue = new System.Windows.Forms.Label();
            this.lblPeakDay = new System.Windows.Forms.Label();
            this.lblPeakDayValue = new System.Windows.Forms.Label();
            this.lblOnlineCount = new System.Windows.Forms.Label();
            this.lblOfflineCount = new System.Windows.Forms.Label();
            this.mainContainer.SuspendLayout();
            this.cardStaff.SuspendLayout();
            this.kiosk.SuspendLayout();
            this.docreq.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKioskUsage)).BeginInit();
            this.chartStatsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.mainContainer.Controls.Add(this.cardStaff);
            this.mainContainer.Controls.Add(this.kiosk);
            this.mainContainer.Controls.Add(this.docreq);
            this.mainContainer.Controls.Add(this.headerPanel);
            this.mainContainer.Controls.Add(this.chartPanel);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Padding = new System.Windows.Forms.Padding(45, 46, 45, 46);
            this.mainContainer.Size = new System.Drawing.Size(1800, 1050);
            this.mainContainer.TabIndex = 0;
            // 
            // cardStaff
            // 
            this.cardStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.cardStaff.Controls.Add(this.lblStaffCount);
            this.cardStaff.Controls.Add(this.lblStaffTitle);
            this.cardStaff.Location = new System.Drawing.Point(59, 210);
            this.cardStaff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cardStaff.Name = "cardStaff";
            this.cardStaff.Size = new System.Drawing.Size(402, 226);
            this.cardStaff.TabIndex = 2;
            // 
            // lblStaffCount
            // 
            this.lblStaffCount.AutoSize = true;
            this.lblStaffCount.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold);
            this.lblStaffCount.ForeColor = System.Drawing.Color.White;
            this.lblStaffCount.Location = new System.Drawing.Point(155, 48);
            this.lblStaffCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaffCount.Name = "lblStaffCount";
            this.lblStaffCount.Size = new System.Drawing.Size(95, 112);
            this.lblStaffCount.TabIndex = 1;
            this.lblStaffCount.Text = "0";
            // 
            // lblStaffTitle
            // 
            this.lblStaffTitle.AutoSize = true;
            this.lblStaffTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStaffTitle.ForeColor = System.Drawing.Color.White;
            this.lblStaffTitle.Location = new System.Drawing.Point(7, 11);
            this.lblStaffTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaffTitle.Name = "lblStaffTitle";
            this.lblStaffTitle.Size = new System.Drawing.Size(129, 32);
            this.lblStaffTitle.TabIndex = 0;
            this.lblStaffTitle.Text = "Total Staff";
            // 
            // kiosk
            // 
            this.kiosk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.kiosk.Controls.Add(this.label3);
            this.kiosk.Controls.Add(this.label4);
            this.kiosk.Location = new System.Drawing.Point(961, 210);
            this.kiosk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kiosk.Name = "kiosk";
            this.kiosk.Size = new System.Drawing.Size(567, 226);
            this.kiosk.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(113, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 112);
            this.label3.TabIndex = 1;
            this.label3.Text = "OFFLINE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "KIOSK Status";
            // 
            // docreq
            // 
            this.docreq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.docreq.Controls.Add(this.label1);
            this.docreq.Controls.Add(this.label2);
            this.docreq.Location = new System.Drawing.Point(511, 210);
            this.docreq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.docreq.Name = "docreq";
            this.docreq.Size = new System.Drawing.Size(402, 226);
            this.docreq.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(155, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 112);
            this.label1.TabIndex = 1;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Document Requests";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerPanel.Controls.Add(this.lblDateTime);
            this.headerPanel.Controls.Add(this.lblWelcomeSub);
            this.headerPanel.Controls.Add(this.lblWelcome);
            this.headerPanel.Location = new System.Drawing.Point(45, 46);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1512, 130);
            this.headerPanel.TabIndex = 5;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDateTime.ForeColor = System.Drawing.Color.Gray;
            this.lblDateTime.Location = new System.Drawing.Point(1116, 18);
            this.lblDateTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(391, 32);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "Monday, January 1, 2024 • 9:00 AM";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.AutoSize = true;
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.Gray;
            this.lblWelcomeSub.Location = new System.Drawing.Point(2, 80);
            this.lblWelcomeSub.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(615, 38);
            this.lblWelcomeSub.TabIndex = 1;
            this.lblWelcomeSub.Text = "Here\'s what\'s happening with your system today";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(642, 74);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Good Morning, Admin!";
            // 
            // chartPanel
            // 
            this.chartPanel.BackColor = System.Drawing.Color.White;
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Controls.Add(this.lblChartTitle);
            this.chartPanel.Controls.Add(this.cmbTimeRange);
            this.chartPanel.Controls.Add(this.btnRefreshChart);
            this.chartPanel.Controls.Add(this.chartKioskUsage);
            this.chartPanel.Controls.Add(this.chartStatsPanel);
            this.chartPanel.Location = new System.Drawing.Point(45, 460);
            this.chartPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(1483, 500);
            this.chartPanel.TabIndex = 6;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblChartTitle.Location = new System.Drawing.Point(20, 15);
            this.lblChartTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(358, 45);
            this.lblChartTitle.TabIndex = 4;
            this.lblChartTitle.Text = "KIOSK Usage Analytics";
            // 
            // cmbTimeRange
            // 
            this.cmbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeRange.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTimeRange.FormattingEnabled = true;
            this.cmbTimeRange.Items.AddRange(new object[] {
            "Last 7 Days",
            "Last 15 Days",
            "Last 30 Days",
            "Last 3 Months",
            "This Year"});
            this.cmbTimeRange.Location = new System.Drawing.Point(1069, 16);
            this.cmbTimeRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTimeRange.Name = "cmbTimeRange";
            this.cmbTimeRange.Size = new System.Drawing.Size(240, 38);
            this.cmbTimeRange.TabIndex = 5;
            // 
            // btnRefreshChart
            // 
            this.btnRefreshChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRefreshChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshChart.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefreshChart.ForeColor = System.Drawing.Color.White;
            this.btnRefreshChart.Location = new System.Drawing.Point(1317, 15);
            this.btnRefreshChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshChart.Name = "btnRefreshChart";
            this.btnRefreshChart.Size = new System.Drawing.Size(120, 38);
            this.btnRefreshChart.TabIndex = 6;
            this.btnRefreshChart.Text = "Refresh";
            this.btnRefreshChart.UseVisualStyleBackColor = false;
            // 
            // chartKioskUsage
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.Title = "Number of Users";
            chartArea1.Name = "ChartArea1";
            this.chartKioskUsage.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartKioskUsage.Legends.Add(legend1);
            this.chartKioskUsage.Location = new System.Drawing.Point(30, 70);
            this.chartKioskUsage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartKioskUsage.Name = "chartKioskUsage";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Users";
            this.chartKioskUsage.Series.Add(series1);
            this.chartKioskUsage.Size = new System.Drawing.Size(984, 380);
            this.chartKioskUsage.TabIndex = 0;
            this.chartKioskUsage.Text = "chart1";
            // 
            // chartStatsPanel
            // 
            this.chartStatsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.chartStatsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartStatsPanel.Controls.Add(this.lblTotalUsers);
            this.chartStatsPanel.Controls.Add(this.lblTotalUsersValue);
            this.chartStatsPanel.Controls.Add(this.lblAvgDaily);
            this.chartStatsPanel.Controls.Add(this.lblAvgDailyValue);
            this.chartStatsPanel.Controls.Add(this.lblPeakDay);
            this.chartStatsPanel.Controls.Add(this.lblPeakDayValue);
            this.chartStatsPanel.Location = new System.Drawing.Point(1069, 70);
            this.chartStatsPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartStatsPanel.Name = "chartStatsPanel";
            this.chartStatsPanel.Size = new System.Drawing.Size(368, 380);
            this.chartStatsPanel.TabIndex = 7;
            // 
            // lblTotalUsers
            // 
            this.lblTotalUsers.AutoSize = true;
            this.lblTotalUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalUsers.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalUsers.Location = new System.Drawing.Point(30, 40);
            this.lblTotalUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalUsers.Name = "lblTotalUsers";
            this.lblTotalUsers.Size = new System.Drawing.Size(134, 32);
            this.lblTotalUsers.TabIndex = 0;
            this.lblTotalUsers.Text = "Total Users:";
            // 
            // lblTotalUsersValue
            // 
            this.lblTotalUsersValue.AutoSize = true;
            this.lblTotalUsersValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalUsersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblTotalUsersValue.Location = new System.Drawing.Point(180, 20);
            this.lblTotalUsersValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalUsersValue.Name = "lblTotalUsersValue";
            this.lblTotalUsersValue.Size = new System.Drawing.Size(56, 65);
            this.lblTotalUsersValue.TabIndex = 1;
            this.lblTotalUsersValue.Text = "0";
            // 
            // lblAvgDaily
            // 
            this.lblAvgDaily.AutoSize = true;
            this.lblAvgDaily.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAvgDaily.ForeColor = System.Drawing.Color.Gray;
            this.lblAvgDaily.Location = new System.Drawing.Point(30, 120);
            this.lblAvgDaily.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvgDaily.Name = "lblAvgDaily";
            this.lblAvgDaily.Size = new System.Drawing.Size(120, 32);
            this.lblAvgDaily.TabIndex = 2;
            this.lblAvgDaily.Text = "Avg Daily:";
            // 
            // lblAvgDailyValue
            // 
            this.lblAvgDailyValue.AutoSize = true;
            this.lblAvgDailyValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblAvgDailyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblAvgDailyValue.Location = new System.Drawing.Point(180, 100);
            this.lblAvgDailyValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAvgDailyValue.Name = "lblAvgDailyValue";
            this.lblAvgDailyValue.Size = new System.Drawing.Size(56, 65);
            this.lblAvgDailyValue.TabIndex = 3;
            this.lblAvgDailyValue.Text = "0";
            // 
            // lblPeakDay
            // 
            this.lblPeakDay.AutoSize = true;
            this.lblPeakDay.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPeakDay.ForeColor = System.Drawing.Color.Gray;
            this.lblPeakDay.Location = new System.Drawing.Point(30, 200);
            this.lblPeakDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeakDay.Name = "lblPeakDay";
            this.lblPeakDay.Size = new System.Drawing.Size(116, 32);
            this.lblPeakDay.TabIndex = 4;
            this.lblPeakDay.Text = "Peak Day:";
            // 
            // lblPeakDayValue
            // 
            this.lblPeakDayValue.AutoSize = true;
            this.lblPeakDayValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeakDayValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblPeakDayValue.Location = new System.Drawing.Point(30, 240);
            this.lblPeakDayValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPeakDayValue.Name = "lblPeakDayValue";
            this.lblPeakDayValue.Size = new System.Drawing.Size(151, 30);
            this.lblPeakDayValue.TabIndex = 5;
            this.lblPeakDayValue.Text = "Mar 15, 2024";
            // 
            // lblOnlineCount
            // 
            this.lblOnlineCount.AutoSize = true;
            this.lblOnlineCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOnlineCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.lblOnlineCount.Location = new System.Drawing.Point(0, 0);
            this.lblOnlineCount.Name = "lblOnlineCount";
            this.lblOnlineCount.Size = new System.Drawing.Size(28, 32);
            this.lblOnlineCount.TabIndex = 3;
            this.lblOnlineCount.Text = "0";
            this.lblOnlineCount.Visible = false;
            // 
            // lblOfflineCount
            // 
            this.lblOfflineCount.AutoSize = true;
            this.lblOfflineCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOfflineCount.ForeColor = System.Drawing.Color.Red;
            this.lblOfflineCount.Location = new System.Drawing.Point(0, 0);
            this.lblOfflineCount.Name = "lblOfflineCount";
            this.lblOfflineCount.Size = new System.Drawing.Size(28, 32);
            this.lblOfflineCount.TabIndex = 4;
            this.lblOfflineCount.Text = "0";
            this.lblOfflineCount.Visible = false;
            // 
            // AdminDashboardHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1800, 1050);
            this.Controls.Add(this.mainContainer);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminDashboardHome";
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboardHome_Load);
            this.mainContainer.ResumeLayout(false);
            this.cardStaff.ResumeLayout(false);
            this.cardStaff.PerformLayout();
            this.kiosk.ResumeLayout(false);
            this.kiosk.PerformLayout();
            this.docreq.ResumeLayout(false);
            this.docreq.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.chartPanel.ResumeLayout(false);
            this.chartPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartKioskUsage)).EndInit();
            this.chartStatsPanel.ResumeLayout(false);
            this.chartStatsPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}