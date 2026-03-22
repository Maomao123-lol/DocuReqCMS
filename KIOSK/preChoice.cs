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
                GenerateAndPrintReceipt(queueNo, serviceType);
                _parent.LoadChild(new thankPage(_parent)); // ← add this
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

        private void GenerateAndPrintReceipt(string queueNo, string serviceType)
        {
            int width = 300;
            int height = 320;

            using (var bmp = new Bitmap(width, height))
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var fontTitle = new Font("MS PGothic", 10, FontStyle.Bold);
                var fontQueue = new Font("MS Gothic", 48, FontStyle.Regular);
                var fontNormal = new Font("MS PGothic", 10, FontStyle.Regular);
                var fontSmall = new Font("MS PGothic", 8, FontStyle.Regular);
                var center = new StringFormat { Alignment = StringAlignment.Center };
                var brush = Brushes.Black;

                int y = 10;

                g.DrawString("University of Caloocan City Registrar", fontSmall, brush,
                    new RectangleF(0, y, width, 20), center);
                y += 25;

                g.DrawLine(Pens.LightGray, 20, y, width - 20, y);
                y += 10;

                g.DrawString(serviceType.ToUpper(), fontTitle, brush,
                    new RectangleF(0, y, width, 25), center);
                y += 30;

                g.DrawString(queueNo, fontQueue, brush,
                    new RectangleF(0, y, width, 80), center);
                y += 85;

                g.DrawLine(Pens.LightGray, 20, y, width - 20, y);
                y += 10;

                g.DrawString("Please wait for your number", fontNormal, brush,
                    new RectangleF(0, y, width, 20), center);
                y += 20;
                g.DrawString("to be called. Thank you!", fontNormal, brush,
                    new RectangleF(0, y, width, 20), center);
                y += 30;

                g.DrawLine(Pens.LightGray, 20, y, width - 20, y);
                y += 10;

                g.DrawString(DateTime.Now.ToString("MM-dd-yyyy"), fontSmall, brush,
                    new RectangleF(0, y, width / 2, 20), center);
                g.DrawString(DateTime.Now.ToString("hh:mm tt"), fontSmall, brush,
                    new RectangleF(width / 2, y, width / 2, 20), center);

                // Save and open
                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Receipts");
                Directory.CreateDirectory(folder);
                string filePath = Path.Combine(folder, $"Receipt_{queueNo}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                bmp.Save(filePath, ImageFormat.Png);

                // Open the saved image
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }
    }
}