using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;
using UCCRegistrarCMS;

namespace DocuReqCMS
{
    public partial class Form1 : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private int currentUserId;
        private Form activeForm = null;

        public Form1(int userId)
        {
            InitializeComponent();
            customizeDesign();
            currentUserId = userId;
        }

        private void customizeDesign()
        {
            SubPanelKQS.Visible = false;
        }

        private void hideSubMenu()
        {
            if (SubPanelKQS.Visible)
                SubPanelKQS.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void bttnKQSettings_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnKQ_Click(object sender, EventArgs e)
        {
            showSubMenu(SubPanelKQS);
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            openChildForm(new UserPage());
            hideSubMenu();
        }

        private void SubBttnKIOSK_Click(object sender, EventArgs e)
        {
            openChildForm(new KIOSKSettings());
            hideSubMenu();
        }

        private void SubBttnQueue_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnServiceConfiguration_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnActivityLogs_Click(object sender, EventArgs e)
        {
            openChildForm(new activityLogs());
            hideSubMenu();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            openChildForm(new Reports());
            hideSubMenu();
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

                // 1️⃣ Update user status
                string updateQuery = @"UPDATE users 
                               SET last_logout = NOW(), status = 'OFFLINE' 
                               WHERE user_id = @id";

                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@id", currentUserId);
                updateCmd.ExecuteNonQuery();

                // 2️⃣ Get user info for logging
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

                // 3️⃣ Log activity using ActivityLogger
                ActivityLogger.Log(
                    currentUserId,                    // int? userId
                    role,                             // role string
                    $"{username} has logged out and is now offline"
                );
            }
        }
    }
}
