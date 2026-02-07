using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class UserPage : Form
    {
<<<<<<< HEAD
        private string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
=======
        private string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
>>>>>>> a2f477006904e0adfc46ccb87d5f85ddf7d3be24

        // Admin info passed from dashboard
        private int adminUserId;
        private string adminUsername = "Admin";

        public UserPage(int adminId = 0, string adminName = "Admin")
        {
            InitializeComponent();
            adminUserId = adminId;
            adminUsername = adminName;
            LoadUsers();
        }

        // ===================== LOAD USERS =====================
        private void LoadUsers()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT 
                                    user_id,
                                    username,
                                    role,
                                    is_default_password,
                                    status,
                                    last_login,
                                    last_logout
                                 FROM users";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewUsers.AutoGenerateColumns = false;
                dataGridViewUsers.DataSource = dt;

                colUserId.DataPropertyName = "user_id";
                colUsername.DataPropertyName = "username";
                colRole.DataPropertyName = "role";
                colDefaultPassword.DataPropertyName = "is_default_password";
                colStatus.DataPropertyName = "status";
                colLastLogin.DataPropertyName = "last_login";
                colLastLogout.DataPropertyName = "last_logout";
            }
        }

        // ===================== HASH PASSWORD =====================
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // ===================== ADD USER =====================
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            string defaultPassword = "user123";
            string hashed = HashPassword(defaultPassword);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO users
                                 (username, password_hash, role, is_default_password, is_active, status)
                                 VALUES
                                 (@username, @password, 'REGISTRAR', 1, 1, 'OFFLINE')";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashed);

                try
                {
                    cmd.ExecuteNonQuery();

                    ActivityLogger.Log(
                        adminUserId != 0 ? (int?)adminUserId : null, 
                        "ADMIN",
                        $"Admin created a new registrar account: '{username}'"
                    );


                    MessageBox.Show(
                        "Registrar account created.\nDefault password: user123",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    txtUsername.Clear();
                    LoadUsers();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user.");
                return;
            }

            string role = dataGridViewUsers.SelectedRows[0]
                            .Cells["colRole"].Value.ToString();

            if (role == "ADMIN")
            {
                MessageBox.Show("Admin account cannot be reset.");
                return;
            }

            int userId = Convert.ToInt32(
                dataGridViewUsers.SelectedRows[0]
                .Cells["colUserId"].Value
            );

            string username = dataGridViewUsers.SelectedRows[0]
                                .Cells["colUsername"].Value.ToString();

            string defaultPassword = "user123";
            string hashed = HashPassword(defaultPassword);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE users
                                 SET password_hash = @password,
                                     is_default_password = 1
                                 WHERE user_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@password", hashed);
                cmd.Parameters.AddWithValue("@id", userId);

                try
                {
                    cmd.ExecuteNonQuery();

                    ActivityLogger.Log(
                         adminUserId != 0 ? (int?)adminUserId : null, 
                         "ADMIN",
                         $"Admin has reset the password for registrar '{username}'"
                     );


                    MessageBox.Show(
                        "Password has been reset to default (user123).",
                        "Reset Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadUsers();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
