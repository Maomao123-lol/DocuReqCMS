using System;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class Form1 : Form
    {
        private Form _activeChild;

        public Form1()
        {
            InitializeComponent();
            LoadChild(new startPage(this));
        }

        public void LoadChild(Form form)
        {
            if (_activeChild != null)
                _activeChild.Close();

            _activeChild = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel3.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }
    }
}