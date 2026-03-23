using KIOSK.Request;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class preChoice : Form
    {
        private readonly Form1 _parent;
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public preChoice(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;

            btnRequest.Click += (s, e) => _parent.LoadChild(new requestForm(_parent));
            btnEvaluation.Click += (s, e) => GenerateQueue("E", "EVALUATION");
            btnSubmitReceipt.Click += (s, e) => GenerateQueue("S", "SUBMIT RECEIPT");
            btnInquiry.Click += (s, e) => GenerateQueue("I", "INQUIRY");
        }

        private void GenerateQueue(string prefix, string serviceType)
        {
            try
            {
                string queueNo = GetNextQueueNo(prefix);
                SaveToDatabase(queueNo, serviceType);
                ReceiptHelper.Print(queueNo, serviceType);
                _parent.LoadChild(new thankPage(_parent));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetNextQueueNo(string prefix)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string query = @"SELECT COUNT(*) FROM cms_db.queue_tickets 
                                 WHERE queue_no LIKE @prefix 
                                 AND DATE(created_at) = CURDATE()";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prefix", prefix + "%");
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return $"{prefix}{(count + 1):D3}";
                }
            }
        }

        private void SaveToDatabase(string queueNo, string serviceType)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string query = @"INSERT INTO cms_db.queue_tickets 
                                 (queue_no, service_type, status, created_at) 
                                 VALUES (@queueNo, @serviceType, 'pending', NOW())";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@queueNo", queueNo);
                    cmd.Parameters.AddWithValue("@serviceType", serviceType);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}