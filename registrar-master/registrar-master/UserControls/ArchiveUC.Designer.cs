namespace DocuFlow_Reg.UserControls
{
    partial class ArchiveUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlArchive = new System.Windows.Forms.Panel();
            this.tlpArchive = new System.Windows.Forms.TableLayoutPanel();
            this.dgvArchive = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new CustomControls.RJControls.RJTextBox();
            this.pnlSearch = new DocuFlow_Reg.RJControls.RJPanel();
            this.lblTypeOfUc = new System.Windows.Forms.Label();
            this.pnlBody = new DocuFlow_Reg.RJControls.RJPanel();
            this.pnlArchive.SuspendLayout();
            this.tlpArchive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchive)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlArchive
            // 
            this.pnlArchive.Controls.Add(this.tlpArchive);
            this.pnlArchive.Controls.Add(this.pnlBody);
            this.pnlArchive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArchive.Location = new System.Drawing.Point(0, 0);
            this.pnlArchive.Name = "pnlArchive";
            this.pnlArchive.Size = new System.Drawing.Size(1001, 779);
            this.pnlArchive.TabIndex = 0;
            // 
            // tlpArchive
            // 
            this.tlpArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpArchive.BackColor = System.Drawing.Color.White;
            this.tlpArchive.ColumnCount = 1;
            this.tlpArchive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpArchive.Controls.Add(this.dgvArchive, 0, 1);
            this.tlpArchive.Controls.Add(this.pnlTop, 0, 0);
            this.tlpArchive.Location = new System.Drawing.Point(28, 52);
            this.tlpArchive.Name = "tlpArchive";
            this.tlpArchive.RowCount = 2;
            this.tlpArchive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.4213F));
            this.tlpArchive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.5787F));
            this.tlpArchive.Size = new System.Drawing.Size(940, 629);
            this.tlpArchive.TabIndex = 1;
            // 
            // dgvArchive
            // 
            this.dgvArchive.AllowUserToAddRows = false;
            this.dgvArchive.AllowUserToResizeColumns = false;
            this.dgvArchive.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvArchive.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArchive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArchive.BackgroundColor = System.Drawing.Color.White;
            this.dgvArchive.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArchive.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvArchive.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchive.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvArchive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchive.EnableHeadersVisualStyles = false;
            this.dgvArchive.GridColor = System.Drawing.Color.LightGray;
            this.dgvArchive.Location = new System.Drawing.Point(0, 96);
            this.dgvArchive.Margin = new System.Windows.Forms.Padding(0);
            this.dgvArchive.MultiSelect = false;
            this.dgvArchive.Name = "dgvArchive";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvArchive.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvArchive.RowHeadersVisible = false;
            this.dgvArchive.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvArchive.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvArchive.RowTemplate.Height = 40;
            this.dgvArchive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchive.Size = new System.Drawing.Size(940, 533);
            this.dgvArchive.TabIndex = 2;
            this.dgvArchive.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchive_CellMouseEnter);
            this.dgvArchive.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArchive_CellMouseLeave);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pbSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.pnlSearch);
            this.pnlTop.Controls.Add(this.lblTypeOfUc);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(940, 96);
            this.pnlTop.TabIndex = 0;
            // 
            // pbSearch
            // 
            this.pbSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbSearch.Image = global::DocuFlow_Reg.Properties.Resources.glass__1_;
            this.pbSearch.Location = new System.Drawing.Point(630, 30);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(34, 30);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 8;
            this.pbSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderFocusColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 0;
            this.txtSearch.BorderSize = 2;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(659, 26);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(7);
            this.txtSearch.PasswordChar = false;
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "Search by Name, ID, or Requests";
            this.txtSearch.Size = new System.Drawing.Size(249, 36);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.Texts = "";
            this.txtSearch.UnderlinedStyle = false;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.BackgroundColor = System.Drawing.Color.White;
            this.pnlSearch.BorderBottomColor = System.Drawing.Color.Empty;
            this.pnlSearch.BorderColor = System.Drawing.Color.Black;
            this.pnlSearch.BorderLeftColor = System.Drawing.Color.Empty;
            this.pnlSearch.BorderRadius = 0;
            this.pnlSearch.BorderRightColor = System.Drawing.Color.Empty;
            this.pnlSearch.BorderSides = ((DocuFlow_Reg.RJControls.BorderSides)((((DocuFlow_Reg.RJControls.BorderSides.Left | DocuFlow_Reg.RJControls.BorderSides.Top) 
            | DocuFlow_Reg.RJControls.BorderSides.Right) 
            | DocuFlow_Reg.RJControls.BorderSides.Bottom)));
            this.pnlSearch.BorderSize = 2;
            this.pnlSearch.BorderTopColor = System.Drawing.Color.Empty;
            this.pnlSearch.ForeColor = System.Drawing.Color.Black;
            this.pnlSearch.GradientColor1 = System.Drawing.Color.Empty;
            this.pnlSearch.GradientColor2 = System.Drawing.Color.Empty;
            this.pnlSearch.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlSearch.Location = new System.Drawing.Point(627, 23);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(284, 45);
            this.pnlSearch.TabIndex = 6;
            this.pnlSearch.UseGradient = false;
            // 
            // lblTypeOfUc
            // 
            this.lblTypeOfUc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTypeOfUc.AutoSize = true;
            this.lblTypeOfUc.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeOfUc.Location = new System.Drawing.Point(40, 32);
            this.lblTypeOfUc.Name = "lblTypeOfUc";
            this.lblTypeOfUc.Size = new System.Drawing.Size(84, 30);
            this.lblTypeOfUc.TabIndex = 1;
            this.lblTypeOfUc.Text = "Archive";
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.BackgroundColor = System.Drawing.Color.White;
            this.pnlBody.BorderBottomColor = System.Drawing.Color.Empty;
            this.pnlBody.BorderColor = System.Drawing.Color.Gray;
            this.pnlBody.BorderLeftColor = System.Drawing.Color.Empty;
            this.pnlBody.BorderRadius = 15;
            this.pnlBody.BorderRightColor = System.Drawing.Color.Empty;
            this.pnlBody.BorderSides = ((DocuFlow_Reg.RJControls.BorderSides)((((DocuFlow_Reg.RJControls.BorderSides.Left | DocuFlow_Reg.RJControls.BorderSides.Top) 
            | DocuFlow_Reg.RJControls.BorderSides.Right) 
            | DocuFlow_Reg.RJControls.BorderSides.Bottom)));
            this.pnlBody.BorderSize = 0;
            this.pnlBody.BorderTopColor = System.Drawing.Color.Empty;
            this.pnlBody.ForeColor = System.Drawing.Color.Black;
            this.pnlBody.GradientColor1 = System.Drawing.Color.Empty;
            this.pnlBody.GradientColor2 = System.Drawing.Color.Empty;
            this.pnlBody.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlBody.Location = new System.Drawing.Point(28, 24);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(940, 697);
            this.pnlBody.TabIndex = 0;
            this.pnlBody.UseGradient = false;
            // 
            // ArchiveUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.pnlArchive);
            this.Name = "ArchiveUC";
            this.Size = new System.Drawing.Size(1001, 779);
            this.pnlArchive.ResumeLayout(false);
            this.tlpArchive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArchive)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlArchive;
        private RJControls.RJPanel pnlBody;
        private System.Windows.Forms.TableLayoutPanel tlpArchive;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTypeOfUc;
        private System.Windows.Forms.PictureBox pbSearch;
        private CustomControls.RJControls.RJTextBox txtSearch;
        private RJControls.RJPanel pnlSearch;
        private System.Windows.Forms.DataGridView dgvArchive;
    }
}
