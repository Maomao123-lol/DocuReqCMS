using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DocuReqCMS.Cards
{
    public partial class createCard : Form
    {
        private readonly string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private string _selectedImagePath = string.Empty;

        public Action OnSaved { get; set; }
        public Action OnCancelled { get; set; }


        public createCard()
        {
            InitializeComponent();
            bttnAdd.Click += BttnAdd_Click;
            bttnCancel.Click += BttnCancel_Click;
            bttnBrowse.Click += BttnBrowse_Click;
            this.Load += (s, e) => txtDocumentName.Focus();
        }

        private void BttnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                ofd.Title = "Select Document Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;

                    // Show path in the textbox
                    txtSelectedImagePath.Text = _selectedImagePath;

                    // Show preview in picPreview
                    byte[] imageBytes = File.ReadAllBytes(_selectedImagePath);
                    picPreview.Image = Image.FromStream(new MemoryStream(imageBytes));
                    picPreview.SizeMode = PictureBoxSizeMode.Zoom;

                    // Clear red border if previously flagged
                    txtSelectedImagePath.BorderColor = Color.LightGray;
                }
            }
        }

        private void BttnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out decimal price)) return;

            string requirements = GetSelectedRequirements();

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO cms_db.kiosk_documents 
                    (document_name, description, price, image_path, requirements, is_active, is_deleted) 
                VALUES 
                    (@name, @description, @price, @imagePath, @requirements, 1, 0)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtDocumentName.Text.Trim());
                        cmd.Parameters.AddWithValue("@description", guna2TextBox1.Text.Trim()); // ← add this
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@imagePath", _selectedImagePath);
                        cmd.Parameters.AddWithValue("@requirements", requirements);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Document added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving document: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedRequirements()
        {
            var checked_items = new System.Collections.Generic.List<string>();

            foreach (CheckBox cb in panel1.Controls.OfType<CheckBox>())
            {
                if (cb.Checked)
                    checked_items.Add(cb.Text.Trim());
            }

            return string.Join(",", checked_items);
        }

        private bool ValidateInputs(out decimal price)
        {
            price = 0;
            bool isValid = true;

            // Reset all borders first
            txtDocumentName.BorderColor = Color.LightGray;
            txtPrice.BorderColor = Color.LightGray;
            txtSelectedImagePath.BorderColor = Color.LightGray;

            if (string.IsNullOrWhiteSpace(txtDocumentName.Text))
            {
                txtDocumentName.BorderColor = Color.Red;
                isValid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0)
            {
                txtPrice.BorderColor = Color.Red;
                isValid = false;
            }

            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                txtSelectedImagePath.BorderColor = Color.Red;
                isValid = false;
            }

            if (!isValid)
                MessageBox.Show("Please fill in all required fields correctly.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return isValid;
        }

        private void BttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void bttnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}