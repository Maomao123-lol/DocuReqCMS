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
    public partial class InquiriesUC : UserControl
    {
        DatabaseHelper db = new DatabaseHelper();
        public InquiriesUC()
        {
            InitializeComponent();
            dgvInquiries.Rows.Clear();
            LoadData();
        }

        public void LoadData() 
        {
            string query = "SELECT RequestNumber, StudentNumber, student_name, document_type, InquiryType FROM document_requests";
            dgvInquiries.DataSource = db.ExecuteQuery(query);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Green;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            pnlSearch.BorderColor = Color.Black;
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;

            string query = "SELECT RequestNumber, StudentNumber, student_name, document_type, InquiryType " +
                           "FROM document_requests " +
                           "WHERE RequestNumber LIKE @search OR " +
                           "StudentNumber LIKE @search OR " +
                           "student_name LIKE @search OR " +
                           "document_type LIKE @search OR " +
                           "InquiryType LIKE @search";

            string searchParam = "%" + searchText + "%";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@search", searchParam);

            dgvInquiries.DataSource = db.ExecuteQuery(query, parameters);
        }
    }
}
