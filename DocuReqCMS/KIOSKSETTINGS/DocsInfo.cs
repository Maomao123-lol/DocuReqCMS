using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DocuReqCMS.KIOSKSETTINGS
{
    public partial class DocsInfo : Form
    {
        public DocsInfo(int id, string name, string description, string price, string imagePath, string requirements)
        {
            InitializeComponent();

            // Set header title
            guna2HtmlLabel1.Text = name.ToUpper();

            // Fill labels
            label1.Text = name;
            label2.Text = "PHP " + price;
            label3.Text = imagePath;
            label4.Text = string.IsNullOrWhiteSpace(description) ? "No description." : description;

            // Load image
            if (File.Exists(imagePath))
            {
                try
                {
                    byte[] bytes = File.ReadAllBytes(imagePath);
                    picPreview.Image = Image.FromStream(new MemoryStream(bytes));
                    picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                catch { }
            }

            // Load requirements — check matching checkboxes, disable all
            LoadRequirements(requirements);
        }

        private void LoadRequirements(string requirements)
        {
            var reqList = string.IsNullOrWhiteSpace(requirements)
                ? new string[0]
                : requirements.Split(',').Select(r => r.Trim()).ToArray();

            foreach (CheckBox cb in panel1.Controls.OfType<CheckBox>())
            {
                bool isChecked = reqList.Any(r => r.Equals(cb.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                cb.Checked = isChecked;
                cb.Enabled = true;

                cb.Click += (s, e) => ((CheckBox)s).Checked = ((CheckBox)s).Checked; // no-op
                cb.CheckedChanged += (s, e) =>
                {
                    var box = (CheckBox)s;
                    box.Checked = reqList.Any(r => r.Equals(box.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                };

                cb.ForeColor = isChecked ? Color.Black : Color.Gray;
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e) { }
    }
}