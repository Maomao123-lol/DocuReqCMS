using DocuReqCMS.User_Controls;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class Form1 : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentButton;
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private int currentUserId;
        private Form activeForm = null;

        public Form1(int userId)
        {
            InitializeComponent();
            currentUserId = userId;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openChildForm(new AdminDashboardHome());
        }

        private void ActivateButton(Guna.UI2.WinForms.Guna2Button button)
        {
            if (currentButton != null)
            {
                currentButton.FillColor = Color.Transparent;
                currentButton.ForeColor = Color.Black;
            }
            currentButton = button;
            currentButton.FillColor = Color.White;
            currentButton.ForeColor = Color.FromArgb(91, 208, 102);
        }

        private void bttnKQSettings_Click(object sender, EventArgs e)
        {
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            openChildForm(new UserPage());
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void SubBttnKIOSK_Click(object sender, EventArgs e)
        {
            KIOSKSettingsUC kioskForm = new KIOSKSettingsUC();
            kioskForm.LoadDocuments(connStr);
            openChildForm(kioskForm);
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void SubBttnQueue_Click(object sender, EventArgs e)
        {
            openChildForm(new queueSettings());
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void SubBttnRegistrar_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarSettings());
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void btnActivityLogs_Click(object sender, EventArgs e)
        {
            openChildForm(new activityLogs());
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            openChildForm(new Reports());
            ActivateButton((Guna.UI2.WinForms.Guna2Button)sender);
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                UpdateLogoutStatus();
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void UpdateLogoutStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string updateQuery = @"UPDATE users 
                               SET last_logout = NOW(), status = 'OFFLINE' 
                               WHERE user_id = @id";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@id", currentUserId);
                updateCmd.ExecuteNonQuery();

                string infoQuery = "SELECT username, role FROM users WHERE user_id=@id";
                MySqlCommand infoCmd = new MySqlCommand(infoQuery, conn);
                infoCmd.Parameters.AddWithValue("@id", currentUserId);
                MySqlDataReader reader = infoCmd.ExecuteReader();

                string username = "";
                string role = "";
                if (reader.Read())
                {
                    username = reader.GetString("username");
                    role = reader.GetString("role");
                }
                reader.Close();

                ActivityLogger.Log(
                    currentUserId,
                    role,
                    $"{username} has logged out and is now offline"
                );
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void guna2Panel14_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel3_Paint(object sender, PaintEventArgs e) { }
        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            openChildForm(new AdminDashboardHome());
        }
    }
}