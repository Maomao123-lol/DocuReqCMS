using System;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class studentClassification : Form
    {
        private readonly Form1 _parent;

        public studentClassification(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
            btnUndergrad.Click += (s, e) => _parent.LoadChild(new preChoice(_parent, "U", "Undergraduate"));
            btnGrad.Click += (s, e) => _parent.LoadChild(new preChoice(_parent, "G", "Graduate"));
            btnAlum.Click += (s, e) => _parent.LoadChild(new preChoice(_parent, "L", "Alum"));
        }
    }
}