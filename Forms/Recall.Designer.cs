using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    partial class Recall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvRecall = new System.Windows.Forms.DataGridView();
            this.btnCall = new DocuFlow_Reg.RJControls.RJButton();
            this.btnDrop = new DocuFlow_Reg.RJControls.RJButton();
            this.lblSkippedQueue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecall)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecall
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvRecall.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecall.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecall.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecall.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecall.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecall.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRecall.EnableHeadersVisualStyles = false;
            this.dgvRecall.Location = new System.Drawing.Point(56, 68);
            this.dgvRecall.MultiSelect = false;
            this.dgvRecall.Name = "dgvRecall";
            this.dgvRecall.ReadOnly = true;
            this.dgvRecall.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecall.RowHeadersVisible = false;
            this.dgvRecall.RowTemplate.Height = 35;
            this.dgvRecall.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecall.Size = new System.Drawing.Size(560, 474);
            this.dgvRecall.TabIndex = 0;
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCall.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCall.BorderColor = System.Drawing.Color.Black;
            this.btnCall.BorderRadius = 14;
            this.btnCall.BorderSize = 1;
            this.btnCall.FlatAppearance.BorderSize = 0;
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCall.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCall.ForeColor = System.Drawing.Color.Black;
            this.btnCall.Location = new System.Drawing.Point(114, 568);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(138, 44);
            this.btnCall.TabIndex = 1;
            this.btnCall.Text = "Call";
            this.btnCall.TextColor = System.Drawing.Color.Black;
            this.btnCall.UseVisualStyleBackColor = false;
            // 
            // btnDrop
            // 
            this.btnDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDrop.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDrop.BorderColor = System.Drawing.Color.Black;
            this.btnDrop.BorderRadius = 14;
            this.btnDrop.BorderSize = 1;
            this.btnDrop.FlatAppearance.BorderSize = 0;
            this.btnDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrop.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrop.ForeColor = System.Drawing.Color.Black;
            this.btnDrop.Location = new System.Drawing.Point(431, 568);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(138, 44);
            this.btnDrop.TabIndex = 2;
            this.btnDrop.Text = "Drop";
            this.btnDrop.TextColor = System.Drawing.Color.Black;
            this.btnDrop.UseVisualStyleBackColor = false;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // lblSkippedQueue
            // 
            this.lblSkippedQueue.AutoSize = true;
            this.lblSkippedQueue.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkippedQueue.Location = new System.Drawing.Point(35, 21);
            this.lblSkippedQueue.Name = "lblSkippedQueue";
            this.lblSkippedQueue.Size = new System.Drawing.Size(158, 30);
            this.lblSkippedQueue.TabIndex = 3;
            this.lblSkippedQueue.Text = "Skipped Queue";
            // 
            // Recall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 653);
            this.Controls.Add(this.lblSkippedQueue);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.dgvRecall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Recall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recall";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRecall;
        private RJControls.RJButton btnCall;
        private RJControls.RJButton btnDrop;
        private Label lblSkippedQueue;
    }
}