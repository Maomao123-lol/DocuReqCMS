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
    public partial class EmailReport : Form
    {
        public EmailReport()
        {
            InitializeComponent();

            // Optional: ensure label settings
            lblEmailSubject.AutoSize = false;
            lblEmailSubject.TextAlign = ContentAlignment.TopLeft;
            lblEmailSubject.MaximumSize = new Size(400, 0);
            lblEmailSubject.Size = new Size(400, 200); // add fixed size

        }

        private void EmailReport_Load(object sender, EventArgs e)
        {
            lblEmailSubject.Text = "asdfvasdfqwe";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
