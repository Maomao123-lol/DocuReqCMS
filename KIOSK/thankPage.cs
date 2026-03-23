using System;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class thankPage : Form
    {
        private readonly Form1 _parent;

        public thankPage(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
            btnDone.Click += (s, e) => _parent.LoadChild(new startPage(_parent));
        }
    }
}