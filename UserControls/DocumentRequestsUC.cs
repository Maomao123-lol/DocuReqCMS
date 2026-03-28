using DocuFlow_Reg.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DocuFlow_Reg.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class DocumentRequestsUC : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
        private Timer searchTimer = new Timer();
        private string searchText = "";
        private int currentPage = 1;
        private RequestDetails _detailsForm;

        public DocumentRequestsUC()
        {
            InitializeComponent();
            this.Load += DocumentRequestsUC_Load;
        }

        private void DocumentRequestsUC_Load(object sender, EventArgs e)
        {
            SharedMethods.SetupAutoSearch(
            txtSearch,
            searchTimer,
            800,
            onSearch: (text) =>
            {
                searchText = text;
                currentPage = 1;
                LoadRequests();
            }
        );
            LoadRequests();
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
                ORDER BY r.created_at ASC");

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

        int hoveredRowIndex = -1;
        Color hoverColor = Color.FromArgb(235, 245, 255);
        Color normalColor = Color.White;
        Color altColor = Color.FromArgb(245, 245, 245);

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

        private void dgvReq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_detailsForm != null && !_detailsForm.IsDisposed)
            {
                _detailsForm.Close();
            }

            _detailsForm = new RequestDetails();
            _detailsForm.Show();
        }

        private void dgvReq_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvReq.IsCurrentCellDirty)
            {
                dgvReq.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}