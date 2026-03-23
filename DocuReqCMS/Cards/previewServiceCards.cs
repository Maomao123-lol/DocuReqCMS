using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace DocuReqCMS.Cards
{
    public partial class previewServiceCards : UserControl
    {
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;
        private int _serviceId;
        private bool _isActive = true;

        public Action OnStatusChanged { get; set; }

        public previewServiceCards()
        {
            InitializeComponent();
            btnDisable.Click += BtnDisable_Click;
            btnRemove.Click += BtnRemove_Click;
        }

        public int ServiceId { get => _serviceId; set => _serviceId = value; }
        public string ServiceName
        {
            get => lblService.Text;
            set
            {
                int maxChars = 13;
                lblService.Text = value.Length > maxChars ? value.Substring(0, maxChars) + "..." : value;
            }
        }
        public Image ServiceImage { get => picImage.Image; set => picImage.Image = value; }
        public bool IsActive
        {
            get => _isActive;
            set { _isActive = value; UpdateButton(); UpdateAppearance(); }
        }

        private void UpdateButton()
        {
            btnDisable.Text = _isActive ? "Disable" : "Enable";
            btnDisable.FillColor = _isActive ? Color.FromArgb(91, 208, 102) : Color.FromArgb(255, 153, 0);
        }

        private void UpdateAppearance()
        {
            this.BackColor = _isActive ? Color.White : Color.FromArgb(240, 240, 240);
            lblService.ForeColor = _isActive ? Color.Black : Color.Gray;
            picImage.Enabled = _isActive;
        }

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            string action = _isActive ? "disable" : "enable";
            if (MessageBox.Show($"Are you sure you want to {action} this service?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    using (var cmd = new MySqlCommand(
                        "UPDATE cms_db.kiosk_services SET is_active = @status WHERE id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@status", _isActive ? 0 : 1);
                        cmd.Parameters.AddWithValue("@id", _serviceId);
                        cmd.ExecuteNonQuery();
                    }
                }
                IsActive = !_isActive;
                MessageBox.Show($"Service {action}d successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove this service? It will be archived.",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var cmd = new MySqlCommand(@"
                            INSERT INTO cms_db.archived_services (original_id, name, image_path, archived_at)
                            SELECT id, name, image_path, NOW() FROM cms_db.kiosk_services WHERE id = @id",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", _serviceId);
                                cmd.ExecuteNonQuery();
                            }

                            using (var cmd = new MySqlCommand(@"
                            UPDATE cms_db.kiosk_services 
                            SET is_deleted = 1, deleted_at = NOW() WHERE id = @id",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", _serviceId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        }
                        catch { transaction.Rollback(); throw; }
                    }
                }

                MessageBox.Show("Service archived successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                OnStatusChanged?.Invoke();
                this.Parent?.Controls.Remove(this);
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
