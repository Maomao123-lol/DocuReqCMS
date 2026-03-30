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
    public partial class ChangeStatus : Form
    {
        EmailReport emailReport = new EmailReport();
        public ChangeStatus()
        {
            InitializeComponent();
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            emailReport.ShowDialog();
            this.Close();
        }

        private void btnReleased_Click(object sender, EventArgs e)
        {

        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {

        }
    }
}
