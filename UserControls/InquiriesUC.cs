using DocuFlow_Reg.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class InquiriesUC : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
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
            string countQuery = @"
    SELECT COUNT(*) 
    FROM queue_tickets qt
    LEFT JOIN Student s ON s.student_number = qt.student_number
    WHERE qt.status != 'done'
    AND (qt.student_number LIKE @search
    OR s.name              LIKE @search
    OR qt.queue_no         LIKE @search
    OR qt.student_classification LIKE @search
    OR qt.type             LIKE @search
    OR qt.status           LIKE @search)";

            int totalRecords = db.getDashboardCount(
                countQuery.Replace("@search", "'%" + searchText + "%'")
            );

            pagination.SetTotalRecords(totalRecords);

            DataTable dt = db.ExecuteQuery(@"
    SELECT 
        qt.queue_no             AS 'Queue No',
        qt.student_number       AS 'Student Number',
        s.name                  AS 'Student Name',
        qt.student_classification AS 'Inquiry Type',
        qt.type                 AS 'Document Requested',
        qt.status               AS 'Status'
    FROM queue_tickets qt
    LEFT JOIN Student s ON s.student_number = qt.student_number
    WHERE qt.status != 'done'
    AND (qt.student_number      LIKE @search
    OR s.name                   LIKE @search
    OR qt.queue_no              LIKE @search
    OR qt.student_classification LIKE @search
    OR qt.type                  LIKE @search
    OR qt.status                LIKE @search)
    ORDER BY qt.created_at ASC
    LIMIT @pageSize OFFSET @offset",
    new Dictionary<string, object>
    {
        { "@search", "%" + searchText + "%" },
        { "@pageSize", pagination.PageSize },
        { "@offset", pagination.Offset }
    });

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

            RequestDetails detailsForm = new RequestDetails(studentNumber, queueNo);
            LoadInquiries();
            detailsForm.Show();
        }
    }
}