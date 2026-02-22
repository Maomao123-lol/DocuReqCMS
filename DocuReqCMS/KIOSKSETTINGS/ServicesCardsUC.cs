using DocuReqCMS.Cards;
using MySql.Data.MySqlClient;
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
    public partial class ServicesCardsUC : UserControl
    {
        private readonly string _connStr;

        public ServicesCardsUC(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.SizeChanged += (s, e) =>
            {
                flowLayoutPanel1.Height = this.ClientSize.Height - guna2Panel2.Height;
                RefreshCardSizes();
            };
            btnServiceCard.Click += BtnServiceCard_Click;
            LoadServiceItems();
        }

        private void LoadServiceItems()
        {
            flowLayoutPanel1.Controls.Clear();
            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT id, name, image_path, is_active 
                                 FROM cms_db.kiosk_services 
                                 WHERE is_deleted = 0 OR is_deleted IS NULL";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            flowLayoutPanel1.Controls.Add(CreateServiceCard(reader));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefreshCardSizes();
        }

        private previewServiceCards CreateServiceCard(MySqlDataReader reader)
        {
            var card = new previewServiceCards
            {
                ServiceId = Convert.ToInt32(reader["id"]),
                Size = new Size((flowLayoutPanel1.ClientSize.Width / 4) - 30, 270),
                Margin = new Padding(10),
                ServiceName = reader["name"].ToString(),
                IsActive = Convert.ToInt32(reader["is_active"]) == 1
            };

            string imagePath = reader["image_path"].ToString();
            if (File.Exists(imagePath))
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    card.ServiceImage = Image.FromStream(new MemoryStream(imageBytes));
                }
                catch { }
            }

            return card;
        }

        private void RefreshCardSizes()
        {
            int cardWidth = (flowLayoutPanel1.ClientSize.Width / 4) - 30;
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is previewServiceCards card)
                    card.Width = cardWidth;
            }
        }

        private void BtnServiceCard_Click(object sender, EventArgs e)
        {
            using (var form = new createServiceCard())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadServiceItems();
            }
        }
    }
}
