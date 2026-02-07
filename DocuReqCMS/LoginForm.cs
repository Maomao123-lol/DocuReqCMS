using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class LoginForm : Form
    {
        bool isPasswordVisible = false;
<<<<<<< HEAD
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
=======
        string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
>>>>>>> a2f477006904e0adfc46ccb87d5f85ddf7d3be24

        public LoginForm()
        {
            InitializeComponent();
            SetupPasswordEye();
        }

        private void SetupPasswordEye()
        {
            txtPassword.UseSystemPasswordChar = true;

            picShowHide.Image = Properties.Resources.eye;
            picShowHide.Cursor = Cursors.Hand;
            picShowHide.Parent = txtPassword;
            picShowHide.Location = new Point(txtPassword.Width - 30, -7);
            picShowHide.BackColor = Color.Transparent;
            picShowHide.BringToFront();

            picShowHide.Click += picShowHide_Click;
        }

        private void picShowHide_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;

            picShowHide.Image = isPasswordVisible
                ? Properties.Resources.eye_slash
                : Properties.Resources.eye;
        }

        // ===================== LOGIN =====================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT user_id, password_hash, role, is_default_password
                                 FROM users
                                 WHERE username = @username AND is_active = 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                int userId = reader.GetInt32("user_id");
                string dbPassword = reader.GetString("password_hash");
                string role = reader.GetString("role");
                bool isDefaultPassword = reader.GetBoolean("is_default_password");

                reader.Close();

                if (!VerifyPassword(password, dbPassword))
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                UpdateLoginStatus(userId, username, role);

                if (role == "REGISTRAR" && isDefaultPassword)
                {
                    MessageBox.Show(
                        "Login successful.\n\nYou are using the default password.\nPlease change it now.",
                        "Security Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    ChangePasswordForm cpf = new ChangePasswordForm(userId);
                    cpf.Show();
                    this.Hide();
                    return;
                }

                //MessageBox.Show(
                //    $"Login successful.\n\nWelcome, {role}!",
                //    "Login Successful",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Information
                //);

                // 🚀 OPEN DASHBOARD
                if (role == "ADMIN")
                {
                    Form1 adminDashboard = new Form1(userId);
                    adminDashboard.Show();
                }
                else
                {
                    RegistrarDashboard registrar = new RegistrarDashboard(userId);
                    registrar.Show();
                }

                this.Hide();
            }
        }

        private void UpdateLoginStatus(int userId, string username, string role)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE users 
                         SET last_login = NOW(), status = 'ONLINE' 
                         WHERE user_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();

                // Corrected ActivityLogger call
                ActivityLogger.Log(
                    userId,
                    role,
                    $"{username} has logged in and is now online"
                );
            }
        }
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

        private bool VerifyPassword(string input, string storedHash)
        {
            return HashPassword(input) == storedHash;
        }
    }
}
