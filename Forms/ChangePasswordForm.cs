using DocuReqCMS;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DocuFlow_Reg
{
    public partial class ChangePasswordForm : Form
    {
        private int userId;
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public ChangePasswordForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserInfo();
            lblPasswordStrength.Visible = false;
        }

        private void LoadUserInfo()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT username, fullname, email FROM users WHERE user_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtFullName.Text = reader["fullname"]?.ToString() ?? "";
                        txtEmail.Text = reader["email"]?.ToString() ?? "";
                        lblUsername.Text = $"User: {reader["username"]?.ToString()}";
                    }
                }
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtNewPassword.Text;

            UpdateRequirementLabel(lblReqLength, password.Length >= 8);
            UpdateRequirementLabel(lblReqUppercase, Regex.IsMatch(password, @"[A-Z]"));
            UpdateRequirementLabel(lblReqLowercase, Regex.IsMatch(password, @"[a-z]"));
            UpdateRequirementLabel(lblReqNumber, Regex.IsMatch(password, @"[0-9]"));
            UpdateRequirementLabel(lblReqSpecial, Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"));

            UpdatePasswordStrength(password);
        }

        private void UpdateRequirementLabel(Label label, bool isMet)
        {
            string cleanText = label.Text;
            if (cleanText.Length > 2)
                cleanText = cleanText.Substring(2);

            if (isMet)
            {
                label.Text = "✓ " + cleanText;
                label.ForeColor = Color.Green;
            }
            else
            {
                label.Text = "✗ " + cleanText;
                label.ForeColor = Color.Red;
            }
        }

        private void UpdatePasswordStrength(string password)
        {
            int strength = 0;

            if (password.Length >= 8) strength++;
            if (Regex.IsMatch(password, @"[A-Z]")) strength++;
            if (Regex.IsMatch(password, @"[a-z]")) strength++;
            if (Regex.IsMatch(password, @"[0-9]")) strength++;
            if (Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]")) strength++;

            if (!string.IsNullOrEmpty(password))
            {
                lblPasswordStrength.Visible = true;
                string strengthText;
                Color strengthColor;

                if (strength <= 2)
                {
                    strengthText = "Weak";
                    strengthColor = Color.Red;
                }
                else if (strength <= 4)
                {
                    strengthText = "Medium";
                    strengthColor = Color.Orange;
                }
                else
                {
                    strengthText = "Strong";
                    strengthColor = Color.Green;
                }

                lblPasswordStrength.Text = $"Password Strength: {strengthText}";
                lblPasswordStrength.ForeColor = strengthColor;
            }
            else
            {
                lblPasswordStrength.Visible = false;
                lblPasswordStrength.Text = "";
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            // --- Validation ---
            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter your full name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., user@example.com).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Please confirm your new password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            string passwordError = ValidatePasswordStrength(newPass);
            if (passwordError != null)
            {
                MessageBox.Show(passwordError, "Password Requirements",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            string hashed = HashPassword(newPass);

            // --- Step 1: Fetch username and role on its own dedicated connection ---
            string username = "";
            string role = "";

            try
            {
                using (MySqlConnection infoConn = new MySqlConnection(connStr))
                {
                    infoConn.Open();
                    MySqlCommand infoCmd = new MySqlCommand(
                        "SELECT username, role FROM users WHERE user_id = @id", infoConn);
                    infoCmd.Parameters.AddWithValue("@id", userId);

                    using (var reader = infoCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            username = reader.GetString("username");
                            role = reader.GetString("role");
                        }
                    }
                } // infoConn fully closed and disposed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load user info.\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Step 2: Perform the UPDATE on its own dedicated connection ---
            try
            {
                using (MySqlConnection updateConn = new MySqlConnection(connStr))
                {
                    updateConn.Open();

                    string updateQuery = @"UPDATE users 
                                           SET fullname = @fullname,
                                               email = @email,
                                               password_hash = @pass,
                                               is_default_password = 0,
                                               last_password_change = NOW(),
                                               password_changed = 1
                                           WHERE user_id = @id";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, updateConn);
                    updateCmd.Parameters.AddWithValue("@fullname", fullName);
                    updateCmd.Parameters.AddWithValue("@email", email);
                    updateCmd.Parameters.AddWithValue("@pass", hashed);
                    updateCmd.Parameters.AddWithValue("@id", userId);
                    updateCmd.ExecuteNonQuery();

                } // updateConn fully closed and disposed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating your profile.\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- Step 3: Log activity AFTER all connections are closed ---
            try
            {
                ActivityLogger.Log(
                    userId,
                    role,
                    $"{username} has successfully changed their password and updated profile information"
                );
            }
            catch
            {
                // Silently skip logging failure — don't block the user
            }

            // --- Step 4: Success ---
            MessageBox.Show("Profile updated and password changed successfully!",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Reg mainForm = new Reg(userId);
            mainForm.WindowState = FormWindowState.Maximized; 
            mainForm.Show();
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string ValidatePasswordStrength(string password)
        {
            if (password.Length < 8)
                return "Password must be at least 8 characters long.";

            if (!Regex.IsMatch(password, @"[A-Z]"))
                return "Password must contain at least one uppercase letter (A-Z).";

            if (!Regex.IsMatch(password, @"[a-z]"))
                return "Password must contain at least one lowercase letter (a-z).";

            if (!Regex.IsMatch(password, @"[0-9]"))
                return "Password must contain at least one number (0-9).";

            if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]"))
                return "Password must contain at least one special character (!@#$%^&* etc.).";

            string[] weakPasswords = { "Password123!", "Admin123!", "User123!", "Welcome123!" };
            if (Array.Exists(weakPasswords, p => p.Equals(password, StringComparison.OrdinalIgnoreCase)))
                return "This password is too common. Please choose a stronger password.";

            return null;
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

        private void lblInstruction_Click(object sender, EventArgs e)
        {

        }
    }
}