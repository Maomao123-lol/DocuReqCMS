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
    public partial class PaymentConfirmation : Form
    {
        public PaymentConfirmation()
        {
            InitializeComponent();
        }
        private bool ValidateConfirmationRequest()
        {
            string input = txtConfirmationRequest.Text.Trim();

            // 1. Check if empty
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Confirmation request cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            // 2. Check length (optional)
            if (input.Length < 5)
            {
                MessageBox.Show("Confirmation request must be at least 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            // 3. Optional: check allowed characters (letters, numbers, dashes)
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9\- ]+$"))
            {
                MessageBox.Show("Confirmation request contains invalid characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            // Passed all validations
            return true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!ValidateConfirmationRequest())
                return;

            // Proceed with processing request
            MessageBox.Show("Confirmation request is valid!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
