using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class ArchiveUC : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();

        private string searchText = "";
        private Timer searchTimer = new Timer();

        int hoveredRowIndex = -1;
        Color hoverColor = Color.FromArgb(235, 245, 255);
        Color normalColor = Color.White;
        Color altColor = Color.FromArgb(245, 245, 245);

        public ArchiveUC()
        {
            InitializeComponent();
            this.Load += ArchiveUC_Load;
        }

        private void ArchiveUC_Load(object sender, EventArgs e)
        {
            searchTimer.Interval = 800;
            searchTimer.Tick += (s, ev) =>
            {
                searchTimer.Stop();
                searchText = txtSearch.Text.Trim();
                LoadArchive();
            };

            LoadArchive();
        }

        private void LoadArchive()
        {
            DataTable dt = db.ExecuteQuery(@"
        SELECT
            a.student_number    AS 'Student Number',
            a.name              AS 'Name',
            a.document_name     AS 'Document Type',
            a.final_status      AS 'Final Status',
            a.archived_at       AS 'Archived At'
        FROM Archive a
        WHERE (
            a.student_number LIKE @search
            OR a.name LIKE @search
            OR a.document_name LIKE @search
            OR a.final_status LIKE @search
        )
        ORDER BY a.archived_at DESC",
                new Dictionary<string, object>
                {
            { "@search", "%" + searchText + "%" }
                });

            dgvArchive.DataSource = dt;
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            dgvArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArchive.RowHeadersVisible = false;
            dgvArchive.AllowUserToAddRows = false;
            dgvArchive.ReadOnly = true;
            dgvArchive.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        private void ResetRowColor(int rowIndex)
        {
            if (rowIndex % 2 == 0)
                dgvArchive.Rows[rowIndex].DefaultCellStyle.BackColor = normalColor;
            else
                dgvArchive.Rows[rowIndex].DefaultCellStyle.BackColor = altColor;
        }

        private void dgvArchive_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (hoveredRowIndex != -1 && hoveredRowIndex != e.RowIndex)
                ResetRowColor(hoveredRowIndex);

            hoveredRowIndex = e.RowIndex;

            if (!dgvArchive.Rows[e.RowIndex].Selected)
                dgvArchive.Rows[e.RowIndex].DefaultCellStyle.BackColor = hoverColor;
        }

        private void dgvArchive_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (!dgvArchive.Rows[e.RowIndex].Selected)
                ResetRowColor(e.RowIndex);
        }
    }
}