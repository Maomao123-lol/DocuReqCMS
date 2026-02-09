using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocuReqCMS
{
    public partial class TestingForm : Form
    {
        private KioskDocumentManager docManager = new KioskDocumentManager();
        private KioskSettingsManager settingsManager = new KioskSettingsManager();
        public TestingForm()
        {
            InitializeComponent();
            LoadKioskDocuments();
            LoadAdImage();
        }

        private void LoadKioskDocuments()
        {
            try
            {
                flowPanelKiosk.Controls.Clear();

                var activeDocuments = docManager.GetActiveDocuments();

                foreach (var doc in activeDocuments)
                {
                    Panel docCard = CreateKioskDocumentCard(doc);
                    flowPanelKiosk.Controls.Add(docCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading kiosk documents: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateKioskDocumentCard(KioskDocument doc)
        {
            Panel card = new Panel();
            card.Size = new Size(200, 280);
            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Padding = new Padding(10);
            card.Margin = new Padding(10);
            card.Cursor = Cursors.Hand;
            card.Tag = doc;

            PictureBox picBox = new PictureBox();
            picBox.Size = new Size(180, 140);
            picBox.Location = new Point(10, 10);
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

            Label lblName = new Label();
            lblName.Text = doc.DocumentName;
            lblName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(33, 37, 41);
            lblName.Location = new Point(10, 155);
            lblName.Size = new Size(180, 50);
            lblName.TextAlign = ContentAlignment.TopCenter;
            card.Controls.Add(lblName);

            Label lblPrice = new Label();
            lblPrice.Text = $"₱{doc.Price:N2}";
            lblPrice.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(40, 167, 69);
            lblPrice.Location = new Point(10, 210);
            lblPrice.Size = new Size(180, 30);
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            card.Controls.Add(lblPrice);

            Button btnSelect = new Button();
            btnSelect.Text = "SELECT";
            btnSelect.BackColor = Color.FromArgb(0, 123, 255);
            btnSelect.ForeColor = Color.White;
            btnSelect.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSelect.Size = new Size(180, 35);
            btnSelect.Location = new Point(10, 240);
            btnSelect.Cursor = Cursors.Hand;
            btnSelect.Tag = doc;
            btnSelect.Click += BtnSelect_Click;
            card.Controls.Add(btnSelect);

            card.Click += (s, e) => BtnSelect_Click(s, e);
            picBox.Click += (s, e) => BtnSelect_Click(s, e);
            lblName.Click += (s, e) => BtnSelect_Click(s, e);
            lblPrice.Click += (s, e) => BtnSelect_Click(s, e);

            return card;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is KioskDocument doc)
            {
                DialogResult result = MessageBox.Show(
                    $"You selected:\n\n" +
                    $"Document: {doc.DocumentName}\n" +
                    $"Price: ₱{doc.Price:N2}\n\n" +
                    $"Do you want to proceed?",
                    "Document Selected",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ProcessDocumentSelection(doc);
                }
            }
        }

        private void ProcessDocumentSelection(KioskDocument doc)
        {
            // Implement the logic to process the selected document
            MessageBox.Show(
                $"Processing: {doc.DocumentName}\n" +
                $"Amount: ₱{doc.Price:N2}\n\n" +
                $"This is where you'd handle the transaction.",
                "Processing",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void ChangeFont(Font newFont)
        {
            // You can apply the font to any control
            this.Font = newFont; // Changes the form's default font

            // Or apply to specific controls:
            // label1.Font = newFont;
            // textBox1.Font = newFont;
        }

        public void RefreshDocuments()
        {
            LoadKioskDocuments();
        }

        private void LoadAdImage()
        {
            try
            {
                string adPath = settingsManager.GetAdImagePath();

                if (!string.IsNullOrEmpty(adPath) && System.IO.File.Exists(adPath))
                {
                    WelcomeAd.Image = Image.FromFile(adPath);
                }
            }
            catch (Exception ex)
            {
                // Silently fail if no image
            }
        }
        public void ChangeImage(Image newImage)
        {
            WelcomeAd.Image = newImage;
        }

        private void flowPanelKiosk_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
