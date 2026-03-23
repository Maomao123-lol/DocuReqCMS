using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DocuReqCMS.KIOSKSETTINGS
{
    public partial class KIOSKDisplayUC :Form
    {
        private readonly string _connStr;
        public KIOSKDisplayUC(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
            WireColorButtons();
            guna2Button43.Click += BtnCustomColor_Click;
            guna2Button44.Click += BtnFont_Click;
            guna2Button45.Click += BtnWelcomeImage_Click;
            guna2Button46.Click += BtnKioskLogo_Click;
            guna2Button47.Click += BtnKioskTitleFont_Click;
            guna2TextBox2.TextChanged += (s, e) =>
                lblKIOSKTitlePreview.Text = guna2TextBox2.Text;
        }

        private void WireColorButtons()
        {
            for (int i = 1; i <= 42; i++)
            {
                var btn = flowLayoutPanel1.Controls
                          .OfType<Button>()
                          .FirstOrDefault(b => b.Name == $"guna2Button{i}");
                if (btn == null) continue;
                btn.Click += (s, e) => ApplyAccentColor(((Button)s).BackColor);
            }
        }

        private void ApplyAccentColor(Color color)
        {
            btnPreview.BackColor = color;
            guna2Panel3.BackColor = color;
        }

        private void BtnCustomColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                ApplyAccentColor(colorDialog1.Color);
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                lblPreview.Font = fontDialog1.Font;
        }

        private void BtnWelcomeImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2TextBox1.Text = ofd.FileName;
                    byte[] bytes = File.ReadAllBytes(ofd.FileName);
                    picWelcomePreview.Image = Image.FromStream(new MemoryStream(bytes));
                    picWelcomePreview.SizeMode = PictureBoxSizeMode.Zoom;
                    SaveWelcomeImage(ofd.FileName); // ← add this
                }
            }
        }

        private void BtnKioskLogo_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2TextBox3.Text = ofd.FileName;
                    byte[] bytes = File.ReadAllBytes(ofd.FileName);
                    picLogoPreview.Image = Image.FromStream(new MemoryStream(bytes));
                    picLogoPreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void BtnKioskTitleFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                lblKIOSKTitlePreview.Font = fontDialog1.Font;
        }


        private void SaveWelcomeImage(string imagePath)
        {
            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"UPDATE cms_db.kiosk_display 
                             SET welcome_image = @path, updated_at = NOW() 
                             WHERE id = 1";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@path", imagePath);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving image: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picLogoPreview_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button44_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}