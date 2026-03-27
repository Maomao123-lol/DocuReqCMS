using DocuFlow_Reg.Forms;
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
    public partial class DocumentRequestsUC : UserControl
    {

        private RequestDetails _detailsForm;
        public DocumentRequestsUC()
        {
            InitializeComponent();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Green;
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

        private void dgvReq_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

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

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Black;
        }

        private void dgvReq_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvReq.IsCurrentCellDirty)
            {
                dgvReq.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

       /* private void dgvReq_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvReq.Columns[e.ColumnIndex].Name == reqStat.Name)
            {
                string status = dgvReq.Rows[e.RowIndex].Cells[reqStat.Name].Value?.ToString();

                if(status == "Not Approved" || status == "Released")
                {
                    DialogResult result = MessageBox.Show(
                       $"This request will be marked as '{status}' and moved to the archive. Continue?",
                       "Confirm Update",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        dgvReq.Rows[e.RowIndex].Cells[reqStat.Name].Value = status;
                        MessageBox.Show(status);
                        return;
                    }
                }

            }
        }*/

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
