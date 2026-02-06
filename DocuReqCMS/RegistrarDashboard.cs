using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class RegistrarDashboard : Form
    {
        private int userId;
        string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public RegistrarDashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
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

                string infoQuery = "SELECT username, role FROM users WHERE user_id=@id";
                MySqlCommand infoCmd = new MySqlCommand(infoQuery, conn);
                infoCmd.Parameters.AddWithValue("@id", userId);
                MySqlDataReader reader = infoCmd.ExecuteReader();

                string username = "";
                string role = "";
                if (reader.Read())
                {
                    username = reader.GetString("username");
                    role = reader.GetString("role");
                }
                reader.Close();

                string query = @"UPDATE users 
                         SET last_logout = NOW(), status = 'OFFLINE'
                         WHERE user_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();

                ActivityLogger.Log(
                    userId,                 
                    role,                
                    $"{username} has logged out and is now offline"
                );

    }
}
    }
}
