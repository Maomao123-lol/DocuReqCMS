using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class activityLogs : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        string searchPlaceholder = "🔍 Search activity logs...";

        Timer searchTimer;
        bool isLoading = false;

        public activityLogs()
        {
            InitializeComponent();
            SetupSearchBox();
            StyleGrid();
            LoadActivityLogs("");
        }

        public static void Log(string role, string activity)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO activity_logs (role, activity) VALUES (@role, @activity)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@activity", activity);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Logging error: " + ex.Message);
                }
            }
        }


        private void SetupSearchBox()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = Color.Gray;

            searchTimer = new Timer();
            searchTimer.Interval = 800;

            searchTimer.Tick += (s, e) =>
            {
                searchTimer.Stop();
                LoadActivityLogs(txtSearch.Text.Trim());
            };

            txtSearch.Enter += (s, e) =>
            {
                if (txtSearch.Text == searchPlaceholder)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = searchPlaceholder;
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            txtSearch.TextChanged += (s, e) =>
            {
                if (txtSearch.Text == searchPlaceholder) return;

                if (txtSearch.Text.Length < 2)
                {
                    LoadActivityLogs("");
                    return;
                }

                searchTimer.Stop();
                searchTimer.Start();
            };
        }

        private void LoadActivityLogs(string searchText)
        {
            if (isLoading) return;

            isLoading = true;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            DATE_FORMAT(created_at, '%Y-%m-%d %H:%i') AS DateTime,
                            role AS Role,
                            activity AS Activity
                        FROM activity_logs
                        WHERE 
                            (@search = '' 
                            OR activity LIKE CONCAT('%', @search, '%')
                            OR role LIKE CONCAT('%', @search, '%')
                            OR DATE_FORMAT(created_at, '%Y-%m-%d %H:%i') LIKE CONCAT('%', @search, '%'))
                        ORDER BY created_at DESC
                        LIMIT 200";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", searchText);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

                    if (dt.Columns.Count > 0)
                    {
                        dataGridView1.Columns["DateTime"].HeaderText = "Date & Time";
                        dataGridView1.Columns["Role"].HeaderText = "User Role";
                        dataGridView1.Columns["Activity"].HeaderText = "Activity";
                        dataGridView1.Columns["Activity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading logs:\n" + ex.Message);
                }
                finally
                {
                    isLoading = false;
                }
            }
        }


        private void StyleGrid()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(91, 208, 102);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 153, 76);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            dataGridView1.RowTemplate.Height = 32;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print feature coming soon.", "Info");
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Archive feature coming soon.", "Info");
        }
    }
}