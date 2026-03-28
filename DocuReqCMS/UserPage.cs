using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class UserPage : Form
    {
        private string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        private int adminUserId;
        private string adminUsername = "Admin";

        public UserPage(int adminId = 0, string adminName = "Admin")
        {
            InitializeComponent();

            adminUserId = adminId;
            adminUsername = adminName;

            StyleGrid();
            dataGridViewUsers.CellPainting += dataGridViewUsers_CellPainting;

            LoadUsers();
            dataGridViewUsers.ClearSelection();
        }

        // ─────────────────────────────────────────────
        // GRID STYLING
        // ─────────────────────────────────────────────

        private void StyleGrid()
        {
            dataGridViewUsers.EnableHeadersVisualStyles = false;
            dataGridViewUsers.BorderStyle = BorderStyle.None;
            dataGridViewUsers.BackgroundColor = Color.White;
            dataGridViewUsers.GridColor = Color.FromArgb(220, 245, 220);

            dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(91, 208, 102);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(91, 208, 102);
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dataGridViewUsers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewUsers.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dataGridViewUsers.DefaultCellStyle.BackColor = Color.White;
            dataGridViewUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 240, 200);
            dataGridViewUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 80, 20);
            dataGridViewUsers.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dataGridViewUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 255, 245);

            dataGridViewUsers.RowTemplate.Height = 44;
            dataGridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewUsers.RowHeadersVisible = false;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridViewUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridViewUsers.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                e.PaintBackground(e.CellBounds, true);

                bool isChecked = e.Value != null && Convert.ToBoolean(e.Value);

                Rectangle box = new Rectangle(
                    e.CellBounds.X + (e.CellBounds.Width - 18) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - 18) / 2,
                    18, 18
                );

                Color green = Color.FromArgb(91, 208, 102);
                Color border = Color.FromArgb(60, 160, 70);

                using (Pen borderPen = new Pen(border, 2))
                using (Brush fillBrush = new SolidBrush(green))
                {
                    if (isChecked)
                    {
                        e.Graphics.FillRectangle(fillBrush, box);
                        // Draw checkmark
                        using (Pen checkPen = new Pen(Color.White, 2.5f))
                        {
                            e.Graphics.DrawLine(checkPen,
                                box.X + 3, box.Y + 9,
                                box.X + 7, box.Y + 13);
                            e.Graphics.DrawLine(checkPen,
                                box.X + 7, box.Y + 13,
                                box.X + 15, box.Y + 4);
                        }
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), box);
                    }
                    e.Graphics.DrawRectangle(borderPen, box);
                }

                e.Handled = true;
            }
        }

        // ─────────────────────────────────────────────
        // DATA LOADING
        // ─────────────────────────────────────────────

        private void LoadUsers()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        user_id,
                        username,
                        fullname,
                        role,
                        is_default_password,
                        status,
                        last_login,
                        last_logout
                    FROM users
                    ORDER BY role, username";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewUsers.AutoGenerateColumns = false;
                dataGridViewUsers.DataSource = dt;

                colUserId.DataPropertyName = "user_id";
                colUsername.DataPropertyName = "username";
                colFullName.DataPropertyName = "fullname";
                colRole.DataPropertyName = "role";
                colDefaultPassword.DataPropertyName = "is_default_password";
                colStatus.DataPropertyName = "status";
                colLastLogin.DataPropertyName = "last_login";
                colLastLogout.DataPropertyName = "last_logout";

                // Update summary label
                UpdateSummary(dt);
            }
        }

        private void UpdateSummary(DataTable dt)
        {
            int total = dt.Rows.Count;
            int online = 0;
            int defPass = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["status"].ToString() == "ONLINE") online++;
                if (Convert.ToBoolean(row["is_default_password"])) defPass++;
            }

            lblSummary.Text =
                $"Total Users: {total}     |     Online: {online}     |     Using Default Password: {defPass}";
        }

        // ─────────────────────────────────────────────
        // HELPERS
        // ─────────────────────────────────────────────

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

        // ─────────────────────────────────────────────
        // ADD USER
        // ─────────────────────────────────────────────

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                ShowError("Please enter a username.");
                txtUsername.Focus();
                return;
            }

            string defaultPassword = "user123";
            string hashed = HashPassword(defaultPassword);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    INSERT INTO users
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

                    ShowSuccess(
                        $"Registrar account \"{username}\" created successfully.\n\nDefault password: user123");

                    txtUsername.Clear();
                    LoadUsers();
                }
                catch (MySqlException ex)
                {
                    ShowError("Error creating user:\n" + ex.Message);
                }
            }
        }

        // ─────────────────────────────────────────────
        // RESET PASSWORD
        // ─────────────────────────────────────────────

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            {
                ShowError("Please select a user from the table first.");
                return;
            }

            string role = dataGridViewUsers.SelectedRows[0]
                .Cells["colRole"].Value.ToString();

            if (role == "ADMIN")
            {
                ShowError("Admin account passwords cannot be reset from here.");
                return;
            }

            int userId = Convert.ToInt32(dataGridViewUsers.SelectedRows[0].Cells["colUserId"].Value);
            string username = dataGridViewUsers.SelectedRows[0].Cells["colUsername"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Reset password for \"{username}\" to default (user123)?",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            string hashed = HashPassword("user123");

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"
                    UPDATE users
                    SET password_hash       = @password,
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
                        $"Admin reset the password for registrar '{username}'"
                    );

                    ShowSuccess($"Password for \"{username}\" has been reset to: user123");
                    LoadUsers();
                }
                catch (MySqlException ex)
                {
                    ShowError("Error resetting password:\n" + ex.Message);
                }
            }
        }
        private void UserPage_Load(object sender, EventArgs e)
        {
            BuildGuideLabel(ref this.lblGuide1, "lblGuide1", 55,
                "➊  Creating a Registrar",
                "Enter a username and click\n\"Create Account\". The default\npassword will be:  user123");

            BuildGuideLabel(ref this.lblGuide2, "lblGuide2", 145,
                "➋  First Login",
                "The registrar must change their\npassword on first login before\naccessing the system.");

            BuildGuideLabel(ref this.lblGuide3, "lblGuide3", 235,
                "➌  Resetting a Password",
                "Select a row in the table then\nclick \"Reset Password\" to restore\nit back to: user123");

            BuildGuideLabel(ref this.lblGuide4, "lblGuide4", 310,
                "➍  Default Password Column",
                "A ✓ check means the user has\nnot yet changed their password.");
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}