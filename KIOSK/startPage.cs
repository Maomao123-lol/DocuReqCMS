using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KIOSK
{
    public partial class startPage : Form
    {
        private readonly Form1 _parent;
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public startPage(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
            btnStart.Click += BtnStart_Click;
            this.Load += (s, e) => LoadWelcomeImage();
        }

        private void LoadWelcomeImage()
        {
            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "SELECT welcome_image FROM cms_db.kiosk_display WHERE id = 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string imagePath = result.ToString();
                            if (File.Exists(imagePath))
                            {
                                byte[] bytes = File.ReadAllBytes(imagePath);
                                pictureBox1.Image = Image.FromStream(new MemoryStream(bytes));
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _parent.LoadChild(new studentClassification(_parent));
        }
    }
}