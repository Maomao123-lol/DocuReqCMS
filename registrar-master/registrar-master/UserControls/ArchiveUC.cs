using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocuFlow_Reg.UserControls
{
    public partial class ArchiveUC : UserControl
    {
        int hoveredRowIndex = -1;
        Color hoverColor = Color.FromArgb(235, 245, 255); // soft blue
        Color normalColor = Color.White;
        Color altColor = Color.FromArgb(245, 245, 245);
        public ArchiveUC()
        {
            InitializeComponent();
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

            // Reset previously hovered row
            if (hoveredRowIndex != -1 && hoveredRowIndex != e.RowIndex)
                ResetRowColor(hoveredRowIndex);

            hoveredRowIndex = e.RowIndex;

            // Apply hover color ONLY if not selected
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
