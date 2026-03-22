using System;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class startPage : Form
    {
        private readonly Form1 _parent;

        public startPage(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
            btnStart.Click += BtnStart_Click;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            _parent.LoadChild(new preChoice(_parent));
        }
    }
}