using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Queue_monitoring
{
    public partial class Form1 : Form
    {
        private Timer slideshowTimer;
        private int currentImageIndex = 0;
        private List<string> imagePaths = new List<string>();
        string connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            panel7.Width = panel5.Width - tableLayoutPanel3.Width;
            panel7.Height = 701;
            panel7.Location = new System.Drawing.Point(0, 0);
            LoadSettingsFromDB();
            LoadImagePathsFromDB();
            InitializeSlideshow();
        }

        private void LoadSettingsFromDB()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT setting_key, setting_value FROM queue_settings";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string key = reader["setting_key"].ToString();
                            string value = reader["setting_value"].ToString();

                            switch (key)
                            {
                                case "ticket_window_font":
                                    var twFont = ParseFont(value);
                                    lblTicket1.Font = twFont; lblTicket2.Font = twFont; lblTicket3.Font = twFont;
                                    lblWindow1.Font = twFont; lblWindow2.Font = twFont; lblWindow3.Font = twFont;
                                    break;
                                case "ticket_window_color":
                                    var twColor = ParseColor(value);
                                    lblTicket1.ForeColor = twColor; lblTicket2.ForeColor = twColor; lblTicket3.ForeColor = twColor;
                                    lblWindow1.ForeColor = twColor; lblWindow2.ForeColor = twColor; lblWindow3.ForeColor = twColor;
                                    break;
                                case "upcoming_ticket_font":
                                    var utFont = ParseFont(value);
                                    upcomingTicket1.Font = utFont; upcomingTicket2.Font = utFont; upcomingTicket3.Font = utFont;
                                    break;
                                case "upcoming_ticket_color":
                                    var utColor = ParseColor(value);
                                    upcomingTicket1.ForeColor = utColor; upcomingTicket2.ForeColor = utColor; upcomingTicket3.ForeColor = utColor;
                                    break;
                                case "header_font":
                                    var hFont = ParseFont(value);
                                    label18.Font = hFont; label11.Font = hFont;
                                    break;
                                case "background_color":
                                    var bgColor = ParseColor(value);
                                    panel5.BackColor = bgColor;
                                    this.BackColor = bgColor;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Font ParseFont(string value)
        {
            var parts = value.Split(',');
            return new Font(parts[0], float.Parse(parts[1]), (FontStyle)int.Parse(parts[2]));
        }

        private Color ParseColor(string value)
        {
            var parts = value.Split(',');
            return Color.FromArgb(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }

        private void LoadImagePathsFromDB()
        {
            imagePaths.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT image_path FROM slideshow_images ORDER BY id ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            imagePaths.Add(reader["image_path"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading images: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeSlideshow()
        {
            if (imagePaths.Count == 0) return;
            pictureBox2.Image = Image.FromFile(imagePaths[0]);
            slideshowTimer = new Timer();
            slideshowTimer.Interval = 3000;
            slideshowTimer.Tick += SlideshowTimer_Tick;
            slideshowTimer.Start();
        }

        private void SlideshowTimer_Tick(object sender, EventArgs e)
        {
            if (imagePaths.Count == 0) return;
            currentImageIndex = (currentImageIndex + 1) % imagePaths.Count;
            try
            {
                pictureBox2.Image = Image.FromFile(imagePaths[currentImageIndex]);
            }
            catch
            {
                imagePaths.RemoveAt(currentImageIndex);
                if (currentImageIndex >= imagePaths.Count)
                    currentImageIndex = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }
    }
}