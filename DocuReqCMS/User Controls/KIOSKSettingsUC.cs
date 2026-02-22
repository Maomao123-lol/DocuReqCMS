using DocuReqCMS.Cards;
using DocuReqCMS.KIOSKSETTINGS;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DocuReqCMS.User_Controls
{
    public partial class KIOSKSettingsUC : UserControl
    {
        private string _connStr;
        private UserControl _activeChild;
        private DocumentItemsUC _documentItemsUC;
        private ServicesCardsUC _servicesCardsUC;
        private KIOSKDisplayUC _kioskDisplayUC;
        private Guna.UI2.WinForms.Guna2Button _activeButton;

        public KIOSKSettingsUC()
        {
            InitializeComponent();
        }

        public void LoadDocuments(string connStr)
        {
            _connStr = connStr;
            _documentItemsUC = new DocumentItemsUC(_connStr);
            _servicesCardsUC = new ServicesCardsUC(_connStr);
            _kioskDisplayUC = new KIOSKDisplayUC(_connStr);

            btnDocument.Click += (s, e) => LoadChild(_documentItemsUC);
            btnService.Click += (s, e) => LoadChild(_servicesCardsUC);
            btnDisplay.Click += (s, e) => LoadChild(_kioskDisplayUC);

            LoadChild(_documentItemsUC);
            SetActiveButton(btnDocument);
        }

        private void LoadChild(UserControl child)
        {
            if (_activeChild != null)
                _activeChild.Visible = false; // hide instead of dispose

            _activeChild = child;
            _activeChild.Dock = DockStyle.Fill;

            if (!guna2Panel3.Controls.Contains(_activeChild))
                guna2Panel3.Controls.Add(_activeChild);

            _activeChild.Visible = true;
            _activeChild.BringToFront();
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