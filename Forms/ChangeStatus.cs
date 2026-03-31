using DocuFlow_Reg.Models;
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

        private void btnReady_Click(object sender, EventArgs e)
        {
            // Update status to Ready then send email
            Request.UpdateStatus("Ready", _requestNumber);
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

            Request.UpdateStatus("Released", _requestNumber);
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            Request.UpdateStatus("Processing", _requestNumber);
        }
    }
}