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
    public partial class DocumentItemsUC : Form
    {
        private readonly string _connStr;
        public DocumentItemsUC(string connStr)
        {
            InitializeComponent();
            _connStr = connStr;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.SizeChanged += (s, e) =>
            {
                flowLayoutPanel1.Width = flowLayoutPanel1.Parent.ClientSize.Width;
                RefreshCardSizes();
            };
            btnAddDocument.Click += BtnAddDocument_Click;

            LoadDocumentItems();
        }


        private void LoadDocumentItems()
        {
            flowLayoutPanel1.Controls.Clear(); // ← was flowLayoutPanel1, WRONG

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT id, document_name, description, price, image_path, requirements, is_active 
                                     FROM cms_db.kiosk_documents 
                                     WHERE is_deleted = 0 OR is_deleted IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var card = CreateDocumentCard(reader);
                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading documents: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RefreshCardSizes();
        }

        private previewDocsCards CreateDocumentCard(MySqlDataReader reader)
        {
            int id = Convert.ToInt32(reader["id"]);
            string name = reader["document_name"].ToString();
            string price = reader["price"].ToString();
            string imagePath = reader["image_path"].ToString();
            string description = reader["description"].ToString();
            string requirements = reader["requirements"].ToString();
            bool isActive = Convert.ToInt32(reader["is_active"]) == 1;

            var card = new previewDocsCards
            {
                DocumentId = id,
                Size = new Size((flowLayoutPanel1.ClientSize.Width / 4) - 30, 330),
                Margin = new Padding(10),
                ItemName = name,
                IsActive = isActive
            };

            card.OnStatusChanged = () => LoadDocumentItems();

            // Wire card click to open DocsInfo
            card.OnCardClicked = () =>
            {
                var info = new DocsInfo(id, name, description, price, imagePath, requirements);
                info.StartPosition = FormStartPosition.CenterParent;
                info.Size = new Size(450, 650);
                info.ShowDialog(this);
            };

            if (File.Exists(imagePath))
            {
                try
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    card.ItemImage = Image.FromStream(new MemoryStream(imageBytes));
                }
                catch { }
            }

            return card;
        }

        private void RefreshCardSizes()
        {
            int cardWith = (flowLayoutPanel1.ClientSize.Width / 5) - 35;
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is previewDocsCards card)
                    card.Width = cardWith;
            }
        }

        private void BtnAddDocument_Click(object sender, EventArgs e)
        {
            using (var form = new createCard())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    LoadDocumentItems();
            }
        }
    }
}
