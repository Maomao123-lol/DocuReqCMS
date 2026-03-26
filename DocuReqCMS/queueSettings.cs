using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class queueSettings : Form
    {
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public queueSettings()
        {
            InitializeComponent();
        }

        private void guna2Button45_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Select an Image";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2TextBox1.Text = ofd.FileName;
                    SaveImagePath();
                }
            }
        }

        private void SaveImagePath()
        {
            string imagePath = guna2TextBox1.Text.Trim();
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please enter or browse an image path.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "INSERT INTO slideshow_images (image_path) VALUES (@path)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@path", imagePath);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Image saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                guna2TextBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFontTicketWindow_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lblPreview.Font = fontDialog1.Font;
                lblPreview2.Font = fontDialog1.Font;
                lblPreview3.Font = fontDialog1.Font;
                SaveFontToDB("ticket_window_font", fontDialog1.Font);
            }
        }

        private void btnColorTicketWindow_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblPreview.ForeColor = colorDialog1.Color;
                lblPreview2.ForeColor = colorDialog1.Color;
                lblPreview3.ForeColor = colorDialog1.Color;
                SaveColorToDB("ticket_window_color", colorDialog1.Color);
            }
        }

        private void btnFontUpcomingTicket_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lblUpcomingPreview.Font = fontDialog1.Font;
                lblUpcomingPreview2.Font = fontDialog1.Font;
                lblUpcomingPreview3.Font = fontDialog1.Font;
                lblUpcomingPreview4.Font = fontDialog1.Font;
                lblUpcomingPreview5.Font = fontDialog1.Font;
                lblUpcomingPreview6.Font = fontDialog1.Font;
                SaveFontToDB("upcoming_ticket_font", fontDialog1.Font);
            }
        }

        private void btnColorUpcomingTicket_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lblUpcomingPreview.ForeColor = colorDialog1.Color;
                lblUpcomingPreview2.ForeColor = colorDialog1.Color;
                lblUpcomingPreview3.ForeColor = colorDialog1.Color;
                lblUpcomingPreview4.ForeColor = colorDialog1.Color;
                lblUpcomingPreview5.ForeColor = colorDialog1.Color;
                lblUpcomingPreview6.ForeColor = colorDialog1.Color;
                SaveColorToDB("upcoming_ticket_color", colorDialog1.Color);
            }
        }

        private void guna2Button44_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lblPreview.Font = fontDialog1.Font;
                lblPreview2.Font = fontDialog1.Font;
                lblPreview3.Font = fontDialog1.Font;
                lblUpcomingPreview.Font = fontDialog1.Font;
                lblUpcomingPreview2.Font = fontDialog1.Font;
                lblUpcomingPreview3.Font = fontDialog1.Font;
                lblUpcomingPreview4.Font = fontDialog1.Font;
                lblUpcomingPreview5.Font = fontDialog1.Font;
                lblUpcomingPreview6.Font = fontDialog1.Font;
                SaveFontToDB("header_font", fontDialog1.Font);
            }
        }

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                guna2Panel3.FillColor = colorDialog1.Color;
                SaveColorToDB("background_color", colorDialog1.Color);
            }
        }

        private void SaveFontToDB(string settingKey, Font font)
        {
            string fontValue = $"{font.Name},{font.Size},{(int)font.Style}";
            SaveSettingToDB(settingKey, fontValue);
        }

        private void SaveColorToDB(string settingKey, Color color)
        {
            string colorValue = $"{color.R},{color.G},{color.B}";
            SaveSettingToDB(settingKey, colorValue);
        }

        private void SaveSettingToDB(string key, string value)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO queue_settings (setting_key, setting_value) 
                                     VALUES (@key, @value)
                                     ON DUPLICATE KEY UPDATE setting_value = @value";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@key", key);
                        cmd.Parameters.AddWithValue("@value", value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Setting saved!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving setting: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}