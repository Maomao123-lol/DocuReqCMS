using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KIOSK.Request
{
    public partial class feeStudentNumber : Form
    {
        private readonly Form1 _mainParent;
        private readonly requestForm _requestParent;
        private KIOSK.keyboardUI _keyboard;
        private readonly string _feeName;
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public feeStudentNumber(requestForm requestParent, Form1 mainParent, string feeName)
        {
            InitializeComponent();
            _requestParent = requestParent;
            _mainParent = mainParent;
            _feeName = feeName;

            label1.Text = feeName;

            LoadKeyboard();
            button2.Click += (s, e) => _mainParent.LoadChild(new requestForm(_mainParent));
            button1.Click += BtnEnter_Click;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();

            if (!IsValidStudentNumber(input))
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Invalid format. Use: 00000000-X";
                return;
            }

            label6.ForeColor = Color.Black;
            label6.Text = "Format: 00000000-X";

            try
            {
                string queueNo = GetNextQueueNo();
                SaveToDatabase(queueNo, input);
                ReceiptHelper.Print(queueNo, "PAY FEE");
                _mainParent.LoadChild(new thankPage(_mainParent));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNextQueueNo()
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM cms_db.queue_tickets 
                                 WHERE queue_no LIKE 'F%' 
                                 AND DATE(created_at) = CURDATE()";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return $"F{(count + 1):D3}";
                }
            }
        }

        private void SaveToDatabase(string queueNo, string studentNo)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string query = @"INSERT INTO cms_db.queue_tickets 
                         (queue_no, service_type, status, created_at, student_number, type) 
                         VALUES (@queueNo, @serviceType, 'pending', NOW(), @studentNo, @type)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@queueNo", queueNo);
                    cmd.Parameters.AddWithValue("@serviceType", "PAY FEE");
                    cmd.Parameters.AddWithValue("@studentNo", studentNo);
                    cmd.Parameters.AddWithValue("@type", _feeName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool IsValidStudentNumber(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{8}-[A-Za-z]$");
        }

        private void LoadKeyboard()
        {
            _keyboard = new KIOSK.keyboardUI();
            _keyboard.Dock = DockStyle.Fill;
            _keyboard.SetTarget(textBox1);
            panel4.Controls.Add(_keyboard);
        }
    }
}