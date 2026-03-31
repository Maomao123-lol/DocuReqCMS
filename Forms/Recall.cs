using DocuFlow_Reg.Models;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class Recall : Form
    {
        public Recall()
        {
            InitializeComponent();
            this.Load += Recall_Load;
        }

        private void Recall_Load(object sender, EventArgs e)
        {
            LoadSkippedQueues();
        }

        private void LoadSkippedQueues()
        {
            // Using QueueList model
            DataTable dt = QueueList.GetSkippedQueues();
            dgvRecall.DataSource = dt;
            StyleDataGridView();
        }

        private void StyleDataGridView()
        {
            dgvRecall.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecall.RowHeadersVisible = false;
            dgvRecall.AllowUserToAddRows = false;
            dgvRecall.ReadOnly = true;
            dgvRecall.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            if (dgvRecall.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a queue number to recall.", "Warning");
                return;
            }

            try
            {
                string queueNo = dgvRecall.SelectedRows[0].Cells["Queue No"].Value.ToString();

                // Using QueueList model
                QueueList.RecallQueue(queueNo);

                MessageBox.Show("Queue " + queueNo + " has been recalled.", "Recalled");
                LoadSkippedQueues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error recalling queue:\n" + ex.Message, "Error");
            }
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}