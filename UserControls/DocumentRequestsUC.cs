using DocuFlow_Reg.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class DocumentRequestsUC : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
        private RequestDetails _detailsForm;

        private string searchText = "";
        private Timer searchTimer = new Timer();

        int hoveredRowIndex = -1;
        Color hoverColor = Color.FromArgb(235, 245, 255);
        Color normalColor = Color.White;
        Color altColor = Color.FromArgb(245, 245, 245);

        public DocumentRequestsUC()
        {
            InitializeComponent();
            this.Load += DocumentRequestsUC_Load;
        }

        private void DocumentRequestsUC_Load(object sender, EventArgs e)
        {
            searchTimer.Interval = 800;
            searchTimer.Tick += (s, ev) =>
            {
                searchTimer.Stop();
                searchText = txtSearch.Text.Trim();
                LoadRequests();
            };

            LoadRequests();
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void LoadRequests()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT
                    r.request_number    AS 'Request Number',
                    r.student_number    AS 'Student Number',
                    r.name              AS 'Name',
                    r.inquiry_type      AS 'Inquiry Type',
                    r.status            AS 'Status'
                FROM Request r
                WHERE r.status NOT IN ('Pending', 'Released')
                AND (
                    r.request_number LIKE @search
                    OR r.student_number LIKE @search
                    OR r.name LIKE @search
                    OR r.inquiry_type LIKE @search
                    OR r.status LIKE @search
                )
                ORDER BY r.created_at ASC",
                new Dictionary<string, object>
                {
                    { "@search", "%" + searchText + "%" }
                });

            dgvReq.DataSource = dt;
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            dgvReq.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReq.RowHeadersVisible = false;
            dgvReq.AllowUserToAddRows = false;
            dgvReq.ReadOnly = true;
            dgvReq.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Green;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Black;
        }

        private void dgvReq_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (hoveredRowIndex != -1 && hoveredRowIndex != e.RowIndex)
                ResetRowColor(hoveredRowIndex);

            hoveredRowIndex = e.RowIndex;

            if (!dgvReq.Rows[e.RowIndex].Selected)
                dgvReq.Rows[e.RowIndex].DefaultCellStyle.BackColor = hoverColor;
        }

        private void dgvReq_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (!dgvReq.Rows[e.RowIndex].Selected)
                ResetRowColor(e.RowIndex);
        }

        private void ResetRowColor(int rowIndex)
        {
            if (rowIndex % 2 == 0)
                dgvReq.Rows[rowIndex].DefaultCellStyle.BackColor = normalColor;
            else
                dgvReq.Rows[rowIndex].DefaultCellStyle.BackColor = altColor;
        }

        private void dgvReq_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvReq.IsCurrentCellDirty)
            {
                dgvReq.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dgvReq_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvReq.Rows[e.RowIndex];

            // Get status from selected row
            string status = row.Cells["Status"].Value.ToString();

            // Close existing form if open
            if (_detailsForm != null && !_detailsForm.IsDisposed)
            {
                _detailsForm.Close();
            }

            // Show different form based on status
            if (status == "Waiting for Payment")
            {
                PaymentConfirmation paymentForm = new PaymentConfirmation();
                paymentForm.ShowDialog();
            }
            else
            {
                ChangeStatus changeForm = new ChangeStatus();
                changeForm.ShowDialog();
            }
        }
    }
}