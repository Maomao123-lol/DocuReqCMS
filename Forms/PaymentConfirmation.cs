using DocuFlow_Reg.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class PaymentConfirmation : Form
    {
        private string _requestNumber;
        private Action _onClose;

        public PaymentConfirmation(string requestNumber, Action onClose = null)
        {
            InitializeComponent();
            _requestNumber = requestNumber;
            _onClose = onClose;
            this.FormClosed += (s, e) => _onClose?.Invoke();
        }

        private bool ValidateConfirmationRequest()
        {
            string input = txtConfirmationRequest.Texts.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("OR number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d+$"))
            {
                MessageBox.Show("OR number must contain numbers only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            if (input.Length < 6)
            {
                MessageBox.Show("OR number must be at least 6 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            if (input.Length > 15)
            {
                MessageBox.Show("OR number must not exceed 15 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            return true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!ValidateConfirmationRequest()) return;

            try
            {
                // Using Request model class
                Request.UpdatePayment(_requestNumber, txtConfirmationRequest.Texts.Trim());

                MessageBox.Show("Payment confirmed! Status updated to Processing.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment:\n" + ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}