using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class ChangeStatus : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        EmailReport emailReport;
        private string _requestNumber;
        private Action _onClose;

        public ChangeStatus(string requestNumber, Action onClose = null)
        {
            InitializeComponent();
            _requestNumber = requestNumber;
            _onClose = onClose;
            emailReport = new EmailReport(_requestNumber);
            this.FormClosed += (s, e) => _onClose?.Invoke();
        }

        private void UpdateStatus(string status)
        {
            try
            {
                db.ExecuteNonQuery(@"
                    UPDATE Request 
                    SET status = @status
                    WHERE request_number = @requestNumber",
                    new Dictionary<string, object>
                    {
                        { "@status",        status },
                        { "@requestNumber", _requestNumber }
                    });

                MessageBox.Show("Status updated to " + status + ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status:\n" + ex.Message, "Error");
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            // Update status to Ready then send email
            UpdateStatus("Ready");
            emailReport.ShowDialog();
        }

        private void btnReleased_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to mark this as Released?",
                "Confirm Release",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            UpdateStatus("Released");
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            UpdateStatus("Processing");
        }
    }
}