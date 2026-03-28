using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    internal class SharedMethods
    {
        // ============================
        // LOAD USER CONTROL
        // ============================
        public void LoadUserControl(UserControl uc, Panel panel)
        {
            uc.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(uc);
        }

        // ============================
        // PAGINATION
        // ============================
        public class Pagination
        {
            private int currentPage = 1;
            private int pageSize;
            private int totalRecords;

            private Button btnPrevious;
            private Button btnNext;
            private Label lblCurrentPage;
            private Label lblLastPage;

            public int CurrentPage => currentPage;
            public int PageSize => pageSize;
            public int Offset => (currentPage - 1) * pageSize;

            public event Action OnPageChanged;

            public Pagination(int pageSize, Button btnPrevious, Button btnNext, Label lblCurrentPage, Label lblLastPage)
            {
                this.pageSize = pageSize;
                this.btnPrevious = btnPrevious;
                this.btnNext = btnNext;
                this.lblCurrentPage = lblCurrentPage;
                this.lblLastPage = lblLastPage;

                this.btnPrevious.Click += BtnPrevious_Click;
                this.btnNext.Click += BtnNext_Click;
            }

            public void SetTotalRecords(int totalRecords)
            {
                this.totalRecords = totalRecords;
                UpdateControls();
            }

            public void Reset()
            {
                currentPage = 1;
                UpdateControls();
            }

            private void BtnPrevious_Click(object sender, EventArgs e)
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    UpdateControls();
                    OnPageChanged?.Invoke();
                }
            }

            private void BtnNext_Click(object sender, EventArgs e)
            {
                int totalPages = GetTotalPages();
                if (currentPage < totalPages)
                {
                    currentPage++;
                    UpdateControls();
                    OnPageChanged?.Invoke();
                }
            }

            private void UpdateControls()
            {
                int totalPages = GetTotalPages();

                lblCurrentPage.Text = currentPage.ToString();
                lblLastPage.Text = totalPages.ToString();

                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }

            private int GetTotalPages()
            {
                int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                return totalPages == 0 ? 1 : totalPages;
            }
        }
    }
}