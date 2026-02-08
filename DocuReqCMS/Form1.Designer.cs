namespace DocuReqCMS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnActivityLogs = new System.Windows.Forms.Button();
            this.SubPanelKQS = new System.Windows.Forms.Panel();
            this.SubBttnQueue = new System.Windows.Forms.Button();
            this.SubBttnKIOSK = new System.Windows.Forms.Button();
            this.btnKQ = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.SubBttnRegistrar = new System.Windows.Forms.Button();
            this.PanelMenu.SuspendLayout();
            this.SubPanelKQS.SuspendLayout();
            this.Admin.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.AutoScroll = true;
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(255)))), ((int)(((byte)(207)))));
            this.PanelMenu.Controls.Add(this.btnLogout);
            this.PanelMenu.Controls.Add(this.btnReports);
            this.PanelMenu.Controls.Add(this.btnActivityLogs);
            this.PanelMenu.Controls.Add(this.SubPanelKQS);
            this.PanelMenu.Controls.Add(this.btnKQ);
            this.PanelMenu.Controls.Add(this.btnUserManagement);
            this.PanelMenu.Controls.Add(this.btnDashboard);
            this.PanelMenu.Controls.Add(this.Admin);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(281, 794);
            this.PanelMenu.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 643);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(281, 74);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "         Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.btnReports.Image = global::DocuReqCMS.Properties.Resources.report;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 569);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(281, 74);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "         Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnActivityLogs
            // 
            this.btnActivityLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnActivityLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnActivityLogs.FlatAppearance.BorderSize = 0;
            this.btnActivityLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnActivityLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnActivityLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivityLogs.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnActivityLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.btnActivityLogs.Image = global::DocuReqCMS.Properties.Resources.file;
            this.btnActivityLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivityLogs.Location = new System.Drawing.Point(0, 495);
            this.btnActivityLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActivityLogs.Name = "btnActivityLogs";
            this.btnActivityLogs.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnActivityLogs.Size = new System.Drawing.Size(281, 74);
            this.btnActivityLogs.TabIndex = 7;
            this.btnActivityLogs.Text = "         Activity Logs";
            this.btnActivityLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivityLogs.UseVisualStyleBackColor = false;
            this.btnActivityLogs.Click += new System.EventHandler(this.btnActivityLogs_Click);
            // 
            // SubPanelKQS
            // 
            this.SubPanelKQS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SubPanelKQS.Controls.Add(this.SubBttnRegistrar);
            this.SubPanelKQS.Controls.Add(this.SubBttnQueue);
            this.SubPanelKQS.Controls.Add(this.SubBttnKIOSK);
            this.SubPanelKQS.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubPanelKQS.Location = new System.Drawing.Point(0, 327);
            this.SubPanelKQS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubPanelKQS.Name = "SubPanelKQS";
            this.SubPanelKQS.Size = new System.Drawing.Size(281, 168);
            this.SubPanelKQS.TabIndex = 5;
            // 
            // SubBttnQueue
            // 
            this.SubBttnQueue.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubBttnQueue.FlatAppearance.BorderSize = 0;
            this.SubBttnQueue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.SubBttnQueue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.SubBttnQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubBttnQueue.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.SubBttnQueue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.SubBttnQueue.Location = new System.Drawing.Point(0, 55);
            this.SubBttnQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubBttnQueue.Name = "SubBttnQueue";
            this.SubBttnQueue.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.SubBttnQueue.Size = new System.Drawing.Size(281, 55);
            this.SubBttnQueue.TabIndex = 1;
            this.SubBttnQueue.Text = "   Queue Monitor";
            this.SubBttnQueue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubBttnQueue.UseVisualStyleBackColor = true;
            this.SubBttnQueue.Click += new System.EventHandler(this.SubBttnQueue_Click);
            // 
            // SubBttnKIOSK
            // 
            this.SubBttnKIOSK.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubBttnKIOSK.FlatAppearance.BorderSize = 0;
            this.SubBttnKIOSK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.SubBttnKIOSK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.SubBttnKIOSK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubBttnKIOSK.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.SubBttnKIOSK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.SubBttnKIOSK.Location = new System.Drawing.Point(0, 0);
            this.SubBttnKIOSK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubBttnKIOSK.Name = "SubBttnKIOSK";
            this.SubBttnKIOSK.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.SubBttnKIOSK.Size = new System.Drawing.Size(281, 55);
            this.SubBttnKIOSK.TabIndex = 0;
            this.SubBttnKIOSK.Text = "   KIOSK";
            this.SubBttnKIOSK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubBttnKIOSK.UseVisualStyleBackColor = true;
            this.SubBttnKIOSK.Click += new System.EventHandler(this.SubBttnKIOSK_Click);
            // 
            // btnKQ
            // 
            this.btnKQ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKQ.FlatAppearance.BorderSize = 0;
            this.btnKQ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnKQ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnKQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKQ.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnKQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.btnKQ.Image = global::DocuReqCMS.Properties.Resources.settings;
            this.btnKQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKQ.Location = new System.Drawing.Point(0, 253);
            this.btnKQ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKQ.Name = "btnKQ";
            this.btnKQ.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnKQ.Size = new System.Drawing.Size(281, 74);
            this.btnKQ.TabIndex = 4;
            this.btnKQ.Text = "         KIOSK, Queue Monitor,\r\n         and Registrar Settings";
            this.btnKQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKQ.UseVisualStyleBackColor = false;
            this.btnKQ.Click += new System.EventHandler(this.btnKQ_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUserManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnUserManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnUserManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.btnUserManagement.Image = global::DocuReqCMS.Properties.Resources.management;
            this.btnUserManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.Location = new System.Drawing.Point(0, 179);
            this.btnUserManagement.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnUserManagement.Size = new System.Drawing.Size(281, 74);
            this.btnUserManagement.TabIndex = 3;
            this.btnUserManagement.Text = "         User Management";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.btnDashboard.Image = global::DocuReqCMS.Properties.Resources.dashboard__1_;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 105);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(281, 74);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "         Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // Admin
            // 
            this.Admin.Controls.Add(this.label2);
            this.Admin.Controls.Add(this.label1);
            this.Admin.Dock = System.Windows.Forms.DockStyle.Top;
            this.Admin.Location = new System.Drawing.Point(0, 0);
            this.Admin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(281, 105);
            this.Admin.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Super Admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reynaldo Abrigo";
            // 
            // panelChildForm
            // 
            this.panelChildForm.AutoScroll = true;
            this.panelChildForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(281, 0);
            this.panelChildForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1187, 794);
            this.panelChildForm.TabIndex = 2;
            // 
            // SubBttnRegistrar
            // 
            this.SubBttnRegistrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubBttnRegistrar.FlatAppearance.BorderSize = 0;
            this.SubBttnRegistrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.SubBttnRegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.SubBttnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubBttnRegistrar.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.SubBttnRegistrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(61)))), ((int)(((byte)(26)))));
            this.SubBttnRegistrar.Location = new System.Drawing.Point(0, 110);
            this.SubBttnRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SubBttnRegistrar.Name = "SubBttnRegistrar";
            this.SubBttnRegistrar.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.SubBttnRegistrar.Size = new System.Drawing.Size(281, 55);
            this.SubBttnRegistrar.TabIndex = 2;
            this.SubBttnRegistrar.Text = "   Registrar";
            this.SubBttnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubBttnRegistrar.UseVisualStyleBackColor = true;
            this.SubBttnRegistrar.Click += new System.EventHandler(this.SubBttnRegistrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1468, 794);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Registrar Content Management System";
            this.PanelMenu.ResumeLayout(false);
            this.SubPanelKQS.ResumeLayout(false);
            this.Admin.ResumeLayout(false);
            this.Admin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel Admin;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnActivityLogs;
        private System.Windows.Forms.Panel SubPanelKQS;
        private System.Windows.Forms.Button SubBttnQueue;
        private System.Windows.Forms.Button SubBttnKIOSK;
        private System.Windows.Forms.Button btnKQ;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubBttnRegistrar;
    }
}

