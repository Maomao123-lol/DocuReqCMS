using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KIOSK.Request
{
    public partial class requestForm : Form
    {
        private readonly Form1 _parent;
        private Form _activeChild;
        public readonly string ClassPrefix;
        public readonly string Classification;
        private string _connStr = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        public requestForm(Form1 parent, string classPrefix = "U", string classification = "Undergraduate")
        {
            InitializeComponent();
            _parent = parent;
            ClassPrefix = classPrefix;
            Classification = classification;
            btnDocument.Click += (s, e) => LoadDocumentCards();
            btnPayFee.Click += (s, e) => LoadFeeCards();
            button4.Click += (s, e) => _parent.LoadChild(new preChoice(_parent, ClassPrefix, Classification));
            this.Load += (s, e) => btnDocument.PerformClick();
        }

        private void LoadDocumentCards()
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT id, document_name, requirements 
                                     FROM cms_db.kiosk_documents 
                                     WHERE is_active = 1 
                                     AND (is_deleted = 0 OR is_deleted IS NULL)";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["document_name"].ToString();
                            string requirements = reader["requirements"].ToString();

                            var card = new documentCard
                            {
                                DocumentName = name,
                                Size = new Size(210, 210),
                                Margin = new Padding(10)
                            };

                            card.OnCardClicked = () =>
                            {
                                _parent.LoadChild(new feeStudentNumber(this, _parent, name, Classification));
                            };

                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading documents: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFeeCards()
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();
                    string query = @"SELECT id, name 
                             FROM cms_db.kiosk_services 
                             WHERE is_active = 1 
                             AND (is_deleted = 0 OR is_deleted IS NULL)";

                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string name = reader["name"].ToString();

                            var card = new feeCards
                            {
                                FeeName = name,
                                Size = new Size(210, 210),
                                Margin = new Padding(10)
                            };

                            card.OnCardClicked = () =>
                            {
                                _parent.LoadChild(new feeStudentNumber(this, _parent, name, Classification));
                            };

                            flowLayoutPanel1.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadChild(Form form)
        {
            if (_activeChild != null)
                _activeChild.Close();

            _activeChild = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            childForm.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}