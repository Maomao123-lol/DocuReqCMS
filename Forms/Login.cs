using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DocuFlow_Reg.Forms
{
    public partial class frmLogin : Form
    {
        SharedMethods methods = new SharedMethods();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Texts;
            string password = txtPassword.Texts;

            if (username == "admin" && password == "1234")
            {
                Reg main = new Reg();

                main.FormClosed += (s, args) => this.Close();

                main.Show();
                this.Hide();
            }
            else
            {
                txtPassword.Texts = "";
                txtUsername.Texts = "";
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEyes_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == false)
            {
                txtPassword.PasswordChar = true;
            }
            else
            {
                txtPassword.PasswordChar = false;
            }
        }
    }
}
