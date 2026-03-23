using DocuReqCMS.KIOSKSETTINGS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocuReqCMS.User_Controls
{
    public partial class KIOSKSettingsUC : Form
    {
        private string _connStr;
        private Form _activeChildForm;
        private Guna.UI2.WinForms.Guna2Button _activeButton;

        public KIOSKSettingsUC()
        {
            InitializeComponent();
        }

        public void LoadDocuments(string connStr)
        {
            _connStr = connStr;

            btnDocument.Click += (s, e) => { OpenChild(new DocumentItemsUC(_connStr)); SetActiveButton(btnDocument); };
            btnService.Click += (s, e) => { OpenChild(new ServicesCardsUC(_connStr)); SetActiveButton(btnService); };
            btnDisplay.Click += (s, e) => { OpenChild(new KIOSKDisplayUC(_connStr)); SetActiveButton(btnDisplay); };

            OpenChild(new DocumentItemsUC(_connStr));
            SetActiveButton(btnDocument);
        }

        private void OpenChild(Form form)
        {
            if (_activeChildForm != null)
                _activeChildForm.Close();

            _activeChildForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void SetActiveButton(Guna.UI2.WinForms.Guna2Button button)
        {
            if (_activeButton != null)
            {
                _activeButton.FillColor = Color.Gainsboro;
                _activeButton.ForeColor = Color.Black;
            }
            _activeButton = button;
            _activeButton.FillColor = Color.FromArgb(91, 208, 102);
            _activeButton.ForeColor = Color.White;
        }
    }
}