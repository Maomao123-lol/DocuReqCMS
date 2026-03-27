using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class frmLogin : Form
    {
        SharedMethods methods = new SharedMethods();
        Reg reg = new Reg();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            reg.Show();
        }
    }
}
