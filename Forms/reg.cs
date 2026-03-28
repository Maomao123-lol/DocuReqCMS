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
using System.Configuration;
using MySql.Data.MySqlClient;
using DocuFlow_Reg.UserControls;
using DocuFlow_Reg.Forms;

namespace DocuFlow_Reg
{
    public partial class Reg : Form
    {
        SharedMethods methods = new SharedMethods();
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        private int _userId;

        // ✅ Default constructor (keep for compatibility)
        public Reg()
        {
            InitializeComponent();
        }

        // ✅ New constructor that accepts userId
        public Reg(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void LoadUserFullName()
        {
            if (_userId <= 0) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "SELECT fullname FROM users WHERE user_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", _userId);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        label1.Text = result.ToString();
                    }
                }
            }
            catch
            {
                label1.Text = "Unknown User";
            }
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
            methods.LoadUserControl(new DashboardUC(), panel5);
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
            methods.LoadUserControl(new DashboardUC(), panel5);
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
            methods.LoadUserControl(new DashboardUC(), panel5);
        }

        private void btnInquiry_CheckedChanged(object sender, EventArgs e)
        {
            if (btnInquiry.Checked)
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
            methods.LoadUserControl(new DashboardUC(), panel5);
        }

        private void Reg_Load_1(object sender, EventArgs e)
        {
            methods.LoadUserControl(new DashboardUC(), panel5);
            btnDashboard.Checked = true;
            this.WindowState = FormWindowState.Maximized;
            LoadUserFullName(); // ✅ Load and display fullname on startup
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rjCircularPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}