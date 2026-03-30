using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class PaymentConfirmation : Form
    {
        DatabaseHelper db = new DatabaseHelper();
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
            string input = txtConfirmationRequest.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Confirmation request cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            if (input.Length < 5)
            {
                MessageBox.Show("Confirmation request must be at least 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmationRequest.Focus();
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z0-9\- ]+$"))
            {
                MessageBox.Show("Confirmation request contains invalid characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Save OR number and update status to Processing
                db.ExecuteNonQuery(@"
                    UPDATE Request 
                    SET or_number = @orNumber,
                        status = 'Processing'
                    WHERE request_number = @requestNumber",
                    new Dictionary<string, object>
                    {
                        { "@orNumber",       txtConfirmationRequest.Text.Trim() },
                        { "@requestNumber",  _requestNumber }
                    });

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