using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class ChangePasswordForm : Form
    {
        private int userId;
        string connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public ChangePasswordForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (newPass == "" || confirmPass == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string hashed = HashPassword(newPass); 

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"UPDATE users 
                                 SET password_hash = @pass,
                                     is_default_password = 0
                                 WHERE user_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pass", hashed);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();

                string infoQuery = @"SELECT username, role FROM users WHERE user_id = @id";
                MySqlCommand infoCmd = new MySqlCommand(infoQuery, conn);
                infoCmd.Parameters.AddWithValue("@id", userId);
                using (var reader = infoCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string username = reader.GetString("username");
                        string role = reader.GetString("role");

                        ActivityLogger.Log(
                            userId,
                            role,
                            $"{username} has successfully changed the default password"
                        );
                    }
                }
            }

            MessageBox.Show("Password changed successfully. Please login again.");

            new LoginForm().Show();
            this.Close();
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
    }
}
