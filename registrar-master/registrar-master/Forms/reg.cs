using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using DocuFlow_Reg.UserControls;

namespace DocuFlow_Reg
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            AutoScaleMode = AutoScaleMode.None;
        }

        private void LoadUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            panel5.Controls.Clear();
            panel5.Controls.Add(uc);
        }
        public void buttonClick(RadioButton btn)
        {
            btn.ForeColor = Color.FromArgb(0, 64, 64);
        }

        private void btnDashboard_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDashboard.Checked)
            {
                buttonClick(btnDashboard);
                btnDashboard.Image = Properties.Resources.dashboard__1_;
                btnDocReq.Image = Properties.Resources.google_docs;
                btnInquiry.Image = Properties.Resources.wall_clock;
                btnDocReq.ForeColor = Color.Black;
                btnArchive.Image = Properties.Resources.archive;
                btnArchive.ForeColor = Color.Black;
            }
            LoadUserControl(new DashboardUC());
        }

        private void btnDocReq_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDocReq.Checked)
            {
                buttonClick(btnDocReq);
                btnDocReq.Image = Properties.Resources.google_docs__1_;
                btnArchive.Image = Properties.Resources.archive;
                btnDashboard.Image = Properties.Resources.dashboard;
                btnInquiry.Image = Properties.Resources.wall_clock;
                btnDashboard.ForeColor = Color.Black;
                btnArchive.ForeColor = Color.Black;
            }
            LoadUserControl(new DocumentRequestsUC());
        }

        private void btnArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (btnArchive.Checked)
            {
                buttonClick(btnArchive);
                btnArchive.Image = Properties.Resources.archive__1_;
                btnDocReq.Image = Properties.Resources.google_docs;
                btnDashboard.Image = Properties.Resources.dashboard;
                btnInquiry.Image = Properties.Resources.wall_clock;
                btnDashboard.ForeColor = Color.Black;
                btnDocReq.ForeColor = Color.Black;
            }

            LoadUserControl(new ArchiveUC());
        }

        private void btnInquiry_CheckedChanged(object sender, EventArgs e)
        {
            if(btnInquiry.Checked)
            {
                buttonClick(btnInquiry);
                btnInquiry.Image = Properties.Resources.wall_clock__1_;
                btnDocReq.Image = Properties.Resources.google_docs;
                btnDashboard.Image = Properties.Resources.dashboard;
                btnArchive.Image = Properties.Resources.archive;
                btnDashboard.ForeColor = Color.Black;
                btnDocReq.ForeColor = Color.Black;
                btnArchive.ForeColor = Color.Black;
            }

            LoadUserControl(new InquiriesUC());
        }

        private void Reg_Load_1(object sender, EventArgs e)
        {
            LoadUserControl(new DashboardUC());
            btnDashboard.Checked = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
