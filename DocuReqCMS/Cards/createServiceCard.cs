using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DocuReqCMS.Cards
{
    public partial class createServiceCard : Form
    {
        private readonly string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private string _selectedImagePath = string.Empty;

        public createServiceCard()
        {
            InitializeComponent();
            bttnAdd.Click += BttnAdd_Click;
            bttnCancel.Click += BttnCancel_Click;
            bttnBrowse.Click += BttnBrowse_Click;
        }

        private void BttnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                ofd.Title = "Select Service Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    txtSelectedImagePath.Text = _selectedImagePath;
                    byte[] imageBytes = File.ReadAllBytes(_selectedImagePath);
                    picPreview.Image = Image.FromStream(new MemoryStream(imageBytes));
                    picPreview.SizeMode = PictureBoxSizeMode.Zoom;
                    txtSelectedImagePath.BorderColor = Color.LightGray;
                }
            }
        }

        private void BttnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO cms_db.kiosk_services 
                            (name, image_path, is_active, is_deleted) 
                        VALUES 
                            (@name, @imagePath, 1, 0)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@imagePath", _selectedImagePath);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Service added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving service: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            txtName.BorderColor = Color.LightGray;
            txtSelectedImagePath.BorderColor = Color.LightGray;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.BorderColor = Color.Red;
                isValid = false;
            }

            if (string.IsNullOrEmpty(_selectedImagePath))
            {
                txtSelectedImagePath.BorderColor = Color.Red;
                isValid = false;
            }

            if (!isValid)
                MessageBox.Show("Please fill in all required fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return isValid;
        }

        private void BttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}