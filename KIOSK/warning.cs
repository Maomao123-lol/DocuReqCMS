using System;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class warning : Form
    {
        private readonly Form1 _parent;
        private readonly Func<Form> _createPreviousPage;

        public warning(Form1 parent, Func<Form> createPreviousPage)
        {
            InitializeComponent();
            _parent = parent;
            _createPreviousPage = createPreviousPage;

            btnNo.Click += (s, e) => _parent.LoadChild(new startPage(_parent));
            btnYes.Click += (s, e) => _parent.LoadChild(_createPreviousPage());
        }
    }
}