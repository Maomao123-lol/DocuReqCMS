using DocuFlow_Reg.Forms;
using DocuFlow_Reg.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class DocumentRequestsUC : UserControl
    {
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

        private void LoadRequests()
        {
            // Now using Request model class
            DataTable dt = Request.GetActiveRequests(searchText);
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

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
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
                dgvReq.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvReq_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string status = dgvReq.Rows[e.RowIndex].Cells["Status"].Value.ToString();
            string requestNumber = dgvReq.Rows[e.RowIndex].Cells["Request Number"].Value.ToString();

            if (status == "Waiting for Payment")
            {
                PaymentConfirmation paymentForm = new PaymentConfirmation(requestNumber, () =>
                {
                    LoadRequests();
                });
                paymentForm.ShowDialog();
            }
            else
            {
                ChangeStatus changeForm = new ChangeStatus(requestNumber, () =>
                {
                    LoadRequests();
                });
                changeForm.ShowDialog();
            }
        }
    }
}