using DocuReqCMS;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class frmLogin : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Texts.Trim();
            string password = txtPassword.Texts;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT user_id, password_hash, is_default_password
                                 FROM users
                                 WHERE username = @username AND is_active = 1 AND role = 'REGISTRAR'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int userId = reader.GetInt32("user_id");
                string dbPassword = reader.GetString("password_hash");
                bool isDefaultPassword = reader.GetBoolean("is_default_password");

                reader.Close();

                if (!VerifyPassword(password, dbPassword))
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update login status
                UpdateLoginStatus(userId, username);

                // If using default password, force change
                if (isDefaultPassword)
                {
                    MessageBox.Show(
                        "⚠️ SECURITY ALERT: Default Password Detected\n\n" +
                        "Your account is currently using the system-generated default password, which poses a security risk.\n\n" +
                        "For security reasons, you are required to:\n" +
                        "✓ Update your profile information (Full Name and Email)\n" +
                        "✓ Create a new strong password that meets the security requirements\n\n" +
                        "Please take a moment to complete your profile setup and create a new password.\n\n" +
                        "This is a one-time requirement to ensure the security of your account.",
                        "Security Required - Complete Your Profile",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    ChangePasswordForm cpf = new ChangePasswordForm(userId);
                    cpf.Show();
                    this.Hide();
                    return;
                }

                // Open main Registrar dashboard
                Reg main = new Reg(userId);
                main.FormClosed += (s, args) => this.Close();
                main.Show();
                this.Hide();
            }
        }

        private void UpdateLoginStatus(int userId, string username)
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

                ActivityLogger.Log(userId, "REGISTRAR", $"{username} has logged in and is now online");
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

        private void btnEyes_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = !txtPassword.PasswordChar;
        }
    }
}