using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocuReqCMS.KIOSKSETTINGS
{
    public partial class KIOSKDisplayUC : UserControl
    {
        public KIOSKDisplayUC(string connStr)
        {
            InitializeComponent();
            WireColorButtons();
            guna2Button43.Click += BtnCustomColor_Click;   // Custom Color
            guna2Button44.Click += BtnFont_Click;           // Font (left panel)
            guna2Button45.Click += BtnWelcomeImage_Click;   // Welcome Image browse
            guna2Button46.Click += BtnKioskLogo_Click;      // KIOSK Logo browse
            guna2Button47.Click += BtnKioskTitleFont_Click; // View Font (KIOSK Title)
            guna2TextBox3.TextChanged += (s, e) => guna2HtmlLabel8.Text = guna2TextBox3.Text; // KIOSK Title → label8
        }

        private void WireColorButtons()
        {
            // Wire all 42 color buttons with one loop
            for (int i = 1; i <= 42; i++)
            {
                var btn = (Guna.UI2.WinForms.Guna2Button)flowLayoutPanel1.Controls
                          .OfType<Guna.UI2.WinForms.Guna2Button>()
                          .FirstOrDefault(b => b.Name == $"guna2Button{i}");
                if (btn == null) continue;

                btn.Click += (s, e) =>
                {
                    var clickedBtn = (Guna.UI2.WinForms.Guna2Button)s;
                    ApplyAccentColor(clickedBtn.FillColor);
                };
            }
        }

        private void ApplyAccentColor(Color color)
        {
            guna2Button48.FillColor = color;
            guna2Button48.ForeColor = color; // active indicator matches
        }

        private void BtnCustomColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                ApplyAccentColor(colorDialog1.Color);
        }

        private void BtnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                guna2HtmlLabel7.Font = fontDialog1.Font;
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
                    guna2PictureBox1.Image = Image.FromStream(new MemoryStream(bytes));
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
                    guna2TextBox2.Text = ofd.FileName;
                    byte[] bytes = File.ReadAllBytes(ofd.FileName);
                    guna2PictureBox2.Image = Image.FromStream(new MemoryStream(bytes)); // ← your logo picturebox
                    guna2PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void BtnKioskTitleFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                guna2HtmlLabel8.Font = fontDialog1.Font; // ← reflects font on title label
        }
    }
}
