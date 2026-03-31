using DocuFlow_Reg.Forms;
using DocuFlow_Reg.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class InquiriesUC : UserControl
    {
        Recall recall = new Recall();
        SharedMethods.Pagination pagination;

        private string searchText = "";

        public InquiriesUC()
        {
            InitializeComponent();
            this.Load += InquiriesUC_Load;
        }

        private void InquiriesUC_Load(object sender, EventArgs e)
        {
            pagination = new SharedMethods.Pagination(
                10,
                btnPreviousPage,
                btnNextPage,
                lblCurrentPage,
                lblLastPage
            );

            pagination.OnPageChanged += LoadInquiries;
            LoadInquiries();
        }

        private void LoadInquiries()
        {
            // Count using QueueTicket model
            int totalRecords = QueueTickets.GetInquiryCount(searchText);
            pagination.SetTotalRecords(totalRecords);

            // Data using QueueTicket model
            DataTable dt = QueueTickets.GetInquiries(searchText, pagination.PageSize, pagination.Offset);
            dgvInquiries.DataSource = dt;
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            dgvInquiries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInquiries.RowHeadersVisible = false;
            dgvInquiries.AllowUserToAddRows = false;
            dgvInquiries.ReadOnly = true;
            dgvInquiries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Green;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Black;
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            recall.ShowDialog();
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            searchText = txtSearch.Text.Trim();
            pagination.Reset();
            LoadInquiries();
        }

        private void dgvInquiries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string studentNumber = dgvInquiries.Rows[e.RowIndex].Cells["Student Number"].Value.ToString();
            string queueNo = dgvInquiries.Rows[e.RowIndex].Cells["Queue No"].Value.ToString();

            RequestDetails detailsForm = new RequestDetails(studentNumber, queueNo, () =>
            {
                LoadInquiries();
            });

            detailsForm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                // Using QueueList model
                DataTable dt = QueueList.GetNextQueue();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No more queue numbers to serve.", "Queue Empty");
                    return;
                }

                string queueNo = dt.Rows[0]["QueueNo"].ToString();
                lblServing.Text = queueNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting next queue:\n" + ex.Message, "Error");
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            try
            {
                string currentQueue = lblServing.Text.Trim();

                if (string.IsNullOrWhiteSpace(currentQueue) || currentQueue == "0" || currentQueue == "-")
                {
                    MessageBox.Show("No queue number is currently being served.", "Warning");
                    return;
                }

                // Using QueueList model
                QueueList.SkipQueue(currentQueue);
                MessageBox.Show("Queue " + currentQueue + " has been skipped.", "Skipped");

                // Auto call next
                btnNext_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error skipping queue:\n" + ex.Message, "Error");
            }
        }
    }
}