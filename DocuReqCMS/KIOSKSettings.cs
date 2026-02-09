using Cyotek.Windows.Forms;
using DocuReqCMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UCCRegistrarCMS
{
    public partial class KIOSKSettings : Form
    {
        private KioskDocumentManager docManager = new KioskDocumentManager();
        private KioskSettingsManager settingsManager = new KioskSettingsManager();

        private ColorEditorManager colorManager;
        public KIOSKSettings()
        {
            InitializeComponent();
        }
        private void KioskSettings_Load(object sender, EventArgs e)
        {
            LoadDocuments();
            LoadCurrentAdImage();
        }

        private void LoadDocuments()
        {
            try
            {
                flowPanelDocuments.Controls.Clear();
                var documents = docManager.GetAllDocuments();
                foreach (var doc in documents)
                {
                    Panel docCard = CreateDocumentCard(doc);
                    flowPanelDocuments.Controls.Add(docCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading documents: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateDocumentCard(KioskDocument doc)
        {
            Panel card = new Panel();
            card.Size = new Size(220, 300);
            card.BorderStyle = BorderStyle.None;
            card.BackColor = Color.White;
            card.Padding = new Padding(15);
            card.Margin = new Padding(15);

            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };

            if (!doc.IsActive)
            {
                card.BackColor = Color.FromArgb(245, 245, 245);
            }

            PictureBox picBox = new PictureBox();
            picBox.Size = new Size(190, 160);
            picBox.Location = new Point(15, 15);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.BackColor = Color.WhiteSmoke;

            if (!string.IsNullOrEmpty(doc.ImagePath) && System.IO.File.Exists(doc.ImagePath))
            {
                try
                {
                    picBox.Image = Image.FromFile(doc.ImagePath);
                }
                catch
                {
                    picBox.BackColor = Color.LightGray;
                }
            }
            card.Controls.Add(picBox);

            Label lblPrice = new Label();
            lblPrice.Text = $"₱{doc.Price:N2}";
            lblPrice.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(40, 167, 69);
            lblPrice.Location = new Point(15, 180);
            lblPrice.AutoSize = true;
            card.Controls.Add(lblPrice);

            Label lblName = new Label();
            lblName.Text = doc.DocumentName;
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(33, 37, 41);
            lblName.Location = new Point(15, 205);
            lblName.Size = new Size(190, 40);
            card.Controls.Add(lblName);

            Button btnToggle = new Button();
            btnToggle.Text = doc.IsActive ? "DISABLE" : "ENABLE";
            btnToggle.BackColor = doc.IsActive ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);
            btnToggle.ForeColor = Color.White;
            btnToggle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            btnToggle.Size = new Size(90, 32);
            btnToggle.Location = new Point(15, 255);
            btnToggle.FlatStyle = FlatStyle.Flat;
            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.Tag = doc.Id;
            btnToggle.Click += BtnToggle_Click;
            card.Controls.Add(btnToggle);

            Button btnDelete = new Button();
            btnDelete.Text = "DELETE";
            btnDelete.BackColor = Color.FromArgb(108, 117, 125);
            btnDelete.ForeColor = Color.White;
            btnDelete.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            btnDelete.Size = new Size(90, 32);
            btnDelete.Location = new Point(115, 255);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Tag = doc.Id;
            btnDelete.Click += BtnDelete_Click;
            card.Controls.Add(btnDelete);

            return card;
        }

        private void BtnToggle_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int docId = (int)btn.Tag;

                if (docManager.ToggleDocumentStatus(docId))
                {
                    MessageBox.Show("Document status updated!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDocuments();

                    _testingForm?.RefreshDocuments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to DELETE this document?\n\nThis action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Button btn = (Button)sender;
                    int docId = (int)btn.Tag;

                    if (docManager.DeleteDocument(docId))
                    {
                        MessageBox.Show("Document deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDocuments();

                        _testingForm?.RefreshDocuments();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            AddDocumentForm addForm = new AddDocumentForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadDocuments();

                _testingForm?.RefreshDocuments();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private TestingForm _testingForm;
        public void SetTestingForm(TestingForm testingForm)
        {
            _testingForm = testingForm;
        }

        private void btnBrowseAd_Click(object sender, EventArgs e)
        {
            var testingForm = Program.TestingForm;

            if (testingForm == null || testingForm.IsDisposed)
            {
                MessageBox.Show("Testing Form is not available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                ofd.Title = "Select Advertisement Image";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image newImage = Image.FromFile(ofd.FileName);

                        // Save to database
                        if (settingsManager.SaveAdImagePath(ofd.FileName))
                        {
                            // Update TestingForm
                            testingForm.ChangeImage(newImage);

                            // Update WelcomePreview
                            WelcomePreview.Image = newImage;
                            WelcomePreview.SizeMode = PictureBoxSizeMode.Zoom;

                            MessageBox.Show("Advertisement image updated successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadCurrentAdImage()
        {
            try
            {
                string adPath = settingsManager.GetAdImagePath();

                if (!string.IsNullOrEmpty(adPath) && System.IO.File.Exists(adPath))
                {
                    WelcomePreview.Image = Image.FromFile(adPath);
                    WelcomePreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    WelcomePreview.Image = null;
                    WelcomePreview.BackColor = Color.LightGray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading preview image: " + ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //private void btnChangeFont_Click(object sender, EventArgs e)
        //{
        //    using (FontDialog fontDialog = new FontDialog())
        //    {
        //        fontDialog.ShowColor = true;
        //        fontDialog.Font = _testingForm.Font;

        //        if (fontDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            _testingForm.ChangeFont(fontDialog.Font);
        //        }
        //    }
        //}
    }
}
