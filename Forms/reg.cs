using DocuFlow_Reg.Forms;
using DocuFlow_Reg.UserControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg
{
    public partial class Reg : Form
    {
        SharedMethods methods = new SharedMethods();

        public Reg()
        {
            InitializeComponent();
        }


        // NAVIGATION HELPER

        private void Navigate(UserControl uc, RadioButton activeBtn)
        {
            // Reset all buttons
            btnDashboard.ForeColor = Color.Black;
            btnDocReq.ForeColor = Color.Black;
            btnArchive.ForeColor = Color.Black;
            btnInquiry.ForeColor = Color.Black;

            // Reset all images to inactive
            btnDashboard.Image = Properties.Resources.dashboard;
            btnDocReq.Image = Properties.Resources.google_docs;
            btnArchive.Image = Properties.Resources.archive;
            btnInquiry.Image = Properties.Resources.wall_clock;

            // Set active button
            activeBtn.ForeColor = Color.FromArgb(0, 64, 64);

            // Set active image
            if (activeBtn == btnDashboard) btnDashboard.Image = Properties.Resources.dashboard__1_;
            if (activeBtn == btnDocReq) btnDocReq.Image = Properties.Resources.google_docs__1_;
            if (activeBtn == btnArchive) btnArchive.Image = Properties.Resources.archive__1_;
            if (activeBtn == btnInquiry) btnInquiry.Image = Properties.Resources.wall_clock__1_;

            // Load user control
            methods.LoadUserControl(uc, panel5);
        }


        // NAVIGATION EVENTS

        private void btnDashboard_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDashboard.Checked) Navigate(new DashboardUC(), btnDashboard);
        }

        private void btnDocReq_CheckedChanged(object sender, EventArgs e)
        {
            if (btnDocReq.Checked) Navigate(new DocumentRequestsUC(), btnDocReq);
        }

        private void btnArchive_CheckedChanged(object sender, EventArgs e)
        {
            if (btnArchive.Checked) Navigate(new ArchiveUC(), btnArchive);
        }

        private void btnInquiry_CheckedChanged(object sender, EventArgs e)
        {
            if (btnInquiry.Checked) Navigate(new InquiriesUC(), btnInquiry);
        }


        // FORM LOAD

        private void Reg_Load_1(object sender, EventArgs e)
        {
            Navigate(new DashboardUC(), btnDashboard);
            btnDashboard.Checked = true;
            this.WindowState = FormWindowState.Maximized;
        }

        // LOGOUT

        private void rjButton1_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            this.Hide();
        }
    }
}