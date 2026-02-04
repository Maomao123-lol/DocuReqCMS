using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class activityLogs : Form
    {
        string connStr = "server=localhost;database=cms_db;uid=root;pwd=takoyaki;";

        public activityLogs()
        {
            InitializeComponent();
            LoadActivityLogs();
        }

        // ===================== LOAD LOGS =====================
        private void LoadActivityLogs()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            CONCAT(
                                DATE_FORMAT(created_at, '%Y-%m-%d %H:%i'),
                                ': ',
                                activity
                            ) AS Activity
                        FROM activity_logs
                        ORDER BY created_at DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Activity Logs";
                    dataGridView1.Columns[0].AutoSizeMode =
                        DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load logs\n" + ex.Message);
                }
            }
        }

        // ===================== SEARCH =====================
        private void button1_Click(object sender, EventArgs e)
        {
            SearchLogs();
        }

        private void SearchLogs()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            CONCAT(
                                DATE_FORMAT(created_at, '%Y-%m-%d %H:%i'),
                                ': ',
                                activity
                            ) AS Activity
                        FROM activity_logs
                        WHERE
                            (@date = '' OR DATE(created_at) = @date)
                            AND activity LIKE CONCAT('%', @keyword, '%')
                        ORDER BY created_at DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@date", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@keyword",
                        $"{textBox2.Text}{textBox3.Text}{textBox4.Text}");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed\n" + ex.Message);
                }
            }
        }
    }
}
