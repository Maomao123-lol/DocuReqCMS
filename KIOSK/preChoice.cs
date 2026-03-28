using KIOSK.Request;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class preChoice : Form
    {
        private readonly Form1 _parent;
        public readonly string ClassPrefix;
        public readonly string Classification;
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public preChoice(Form1 parent, string classPrefix, string classification)
        {
            InitializeComponent();
            _parent = parent;
            ClassPrefix = classPrefix;
            Classification = classification;
            btnRequest.Click += (s, e) => _parent.LoadChild(new requestForm(_parent, ClassPrefix, Classification));
            btnEvaluation.Click += (s, e) => GenerateQueue("E", "EVALUATION");
            btnSubmitReceipt.Click += (s, e) => GenerateQueue("S", "SUBMIT RECEIPT");
            btnInquiry.Click += (s, e) => GenerateQueue("I", "INQUIRY");
        }

        private void GenerateQueue(string servicePrefix, string serviceType)
        {
            try
            {
                string queueNo = GetNextQueueNo(ClassPrefix, servicePrefix);
                SaveToDatabase(queueNo, serviceType, Classification);
                ReceiptHelper.Print(queueNo, serviceType, Classification);
                _parent.LoadChild(new thankPage(_parent));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNextQueueNo(string classPrefix, string servicePrefix)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string pattern = $"{classPrefix}-{servicePrefix}%";
                string query = @"SELECT COUNT(*) FROM cms_db.queue_tickets 
                                 WHERE queue_no LIKE @prefix 
                                 AND DATE(created_at) = CURDATE()";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", pattern);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return $"{classPrefix}-{servicePrefix}{(count + 1):D3}";
                }
            }
        }

        private void SaveToDatabase(string queueNo, string serviceType, string classification)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string query = @"INSERT INTO cms_db.queue_tickets 
                                 (queue_no, service_type, status, created_at, student_classification) 
                                 VALUES (@queueNo, @serviceType, 'pending', NOW(), @classification)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@queueNo", queueNo);
                    cmd.Parameters.AddWithValue("@serviceType", serviceType);
                    cmd.Parameters.AddWithValue("@classification", classification);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}