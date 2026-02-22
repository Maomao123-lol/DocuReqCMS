using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DocuReqCMS.Cards
{
    public partial class previewDocsCards : UserControl
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private int _documentId;
        private bool _isActive = true;

        public Action OnStatusChanged { get; set; }

        public previewDocsCards()
        {
            InitializeComponent();
            guna2Button1.Click += BtnDisable_Click;
            guna2Button2.Click += BtnRemove_Click;
        }

        #region Properties

        public int DocumentId
        {
            get => _documentId;
            set => _documentId = value;
        }

        public string ItemName
        {
            get => lblName.Text;
            set
            {
                int maxChars = 12;
                lblName.Text = value.Length > maxChars ? value.Substring(0, maxChars) + "..." : value;
            }
        }

        public string Price
        {
            get => lblPrice.Text;
            set => lblPrice.Text = value;
        }

        public Image ItemImage
        {
            get => picItem.Image;
            set => picItem.Image = value;
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                UpdateDisableButton();
                UpdateCardAppearance();
            }
        }

        #endregion

        #region UI Updates

        private void UpdateDisableButton()
        {
            if (_isActive)
            {
                guna2Button1.Text = "Disable";
                guna2Button1.FillColor = Color.FromArgb(91, 208, 102);
            }
            else
            {
                guna2Button1.Text = "Enable";
                guna2Button1.FillColor = Color.FromArgb(255, 153, 0);
            }
        }

        private void UpdateCardAppearance()
        {
            this.BackColor = _isActive ? Color.White : Color.FromArgb(240, 240, 240);
            lblName.ForeColor = _isActive ? Color.Black : Color.Gray;
            lblPrice.ForeColor = _isActive ? Color.Black : Color.Gray;
            picItem.Enabled = _isActive;
        }

        #endregion

        #region Button Events

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            string action = _isActive ? "disable" : "enable";

            var confirm = MessageBox.Show(
                $"Are you sure you want to {action} this document?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = "UPDATE cms_db.kiosk_documents SET is_active = @status WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", _isActive ? 0 : 1);
                        cmd.Parameters.AddWithValue("@id", _documentId);
                        cmd.ExecuteNonQuery();
                    }
                }

                IsActive = !_isActive;

                MessageBox.Show($"Document {action}d successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to remove this document?\nIt will be moved to the archive.",
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Archive the record
                            string archiveQuery = @"
                                INSERT INTO cms_db.archived_itemCard (original_id, document_name, price, image_path, archived_at)
                                SELECT id, document_name, price, image_path, NOW()
                                FROM cms_db.kiosk_documents
                                WHERE id = @id";

                            using (var cmd = new MySqlCommand(archiveQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", _documentId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Soft delete from source table
                            string softDeleteQuery = @"
                                UPDATE cms_db.kiosk_documents 
                                SET is_deleted = 1, deleted_at = NOW() 
                                WHERE id = @id";

                            using (var cmd = new MySqlCommand(softDeleteQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", _documentId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Document archived successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnStatusChanged?.Invoke();

                // Remove card from UI
                this.Parent?.Controls.Remove(this);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing document: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}