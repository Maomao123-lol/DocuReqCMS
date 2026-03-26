namespace DocuFlow_Reg.UserControls
{
    partial class DocumentRequestsUC
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpRequest = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearchFil = new System.Windows.Forms.Panel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.txtSearch = new CustomControls.RJControls.RJTextBox();
            this.pnlSearch = new DocuFlow_Reg.RJControls.RJPanel();
            this.lblTypeOfUc = new System.Windows.Forms.Label();
            this.dgvReq = new System.Windows.Forms.DataGridView();
            this.pnlDocReqDgv = new DocuFlow_Reg.RJControls.RJPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpRequest.SuspendLayout();
            this.pnlSearchFil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReq)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 779);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlpRequest);
            this.panel1.Controls.Add(this.pnlDocReqDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 779);
            this.panel1.TabIndex = 0;
            // 
            // tlpRequest
            // 
            this.tlpRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpRequest.BackColor = System.Drawing.Color.White;
            this.tlpRequest.ColumnCount = 1;
            this.tlpRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRequest.Controls.Add(this.pnlSearchFil, 0, 0);
            this.tlpRequest.Controls.Add(this.dgvReq, 0, 1);
            this.tlpRequest.Location = new System.Drawing.Point(29, 20);
            this.tlpRequest.Name = "tlpRequest";
            this.tlpRequest.RowCount = 2;
            this.tlpRequest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tlpRequest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.47619F));
            this.tlpRequest.Size = new System.Drawing.Size(943, 730);
            this.tlpRequest.TabIndex = 13;
            // 
            // pnlSearchFil
            // 
            this.pnlSearchFil.Controls.Add(this.pbSearch);
            this.pnlSearchFil.Controls.Add(this.txtSearch);
            this.pnlSearchFil.Controls.Add(this.pnlSearch);
            this.pnlSearchFil.Controls.Add(this.lblTypeOfUc);
            this.pnlSearchFil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchFil.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchFil.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSearchFil.Name = "pnlSearchFil";
            this.pnlSearchFil.Size = new System.Drawing.Size(943, 69);
            this.pnlSearchFil.TabIndex = 0;
            // 
            // pbSearch
            // 
            this.pbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSearch.Image = global::DocuFlow_Reg.Properties.Resources.glass__1_;
            this.pbSearch.Location = new System.Drawing.Point(629, 16);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(34, 33);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 5;
            this.pbSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderFocusColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 0;
            this.txtSearch.BorderSize = 2;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearch.Location = new System.Drawing.Point(658, 13);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(7);
            this.txtSearch.PasswordChar = false;
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "Search by Name, ID, or Requests";
            this.txtSearch.Size = new System.Drawing.Size(249, 36);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.Texts = "";
            this.txtSearch.UnderlinedStyle = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnlSearch.Location = new System.Drawing.Point(626, 10);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(284, 46);
            this.pnlSearch.TabIndex = 1;
            this.pnlSearch.UseGradient = false;
            // 
            // lblTypeOfUc
            // 
            this.lblTypeOfUc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTypeOfUc.AutoSize = true;
            this.lblTypeOfUc.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeOfUc.Location = new System.Drawing.Point(36, 26);
            this.lblTypeOfUc.Name = "lblTypeOfUc";
            this.lblTypeOfUc.Size = new System.Drawing.Size(204, 30);
            this.lblTypeOfUc.TabIndex = 0;
            this.lblTypeOfUc.Text = "Document Requests";
            // 
            // dgvReq
            // 
            this.dgvReq.AllowUserToAddRows = false;
            this.dgvReq.AllowUserToResizeColumns = false;
            this.dgvReq.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvReq.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReq.BackgroundColor = System.Drawing.Color.White;
            this.dgvReq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReq.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReq.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReq.EnableHeadersVisualStyles = false;
            this.dgvReq.GridColor = System.Drawing.Color.LightGray;
            this.dgvReq.Location = new System.Drawing.Point(0, 69);
            this.dgvReq.Margin = new System.Windows.Forms.Padding(0);
            this.dgvReq.MultiSelect = false;
            this.dgvReq.Name = "dgvReq";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReq.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReq.RowHeadersVisible = false;
            this.dgvReq.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReq.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReq.RowTemplate.Height = 40;
            this.dgvReq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReq.Size = new System.Drawing.Size(943, 661);
            this.dgvReq.TabIndex = 1;
            // 
            // pnlDocReqDgv
            // 
            this.pnlDocReqDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDocReqDgv.BackColor = System.Drawing.Color.Transparent;
            this.pnlDocReqDgv.BackgroundColor = System.Drawing.Color.White;
            this.pnlDocReqDgv.BorderBottomColor = System.Drawing.Color.Empty;
            this.pnlDocReqDgv.BorderColor = System.Drawing.Color.Gray;
            this.pnlDocReqDgv.BorderLeftColor = System.Drawing.Color.Empty;
            this.pnlDocReqDgv.BorderRadius = 15;
            this.pnlDocReqDgv.BorderRightColor = System.Drawing.Color.Empty;
            this.pnlDocReqDgv.BorderSides = ((DocuFlow_Reg.RJControls.BorderSides)((((DocuFlow_Reg.RJControls.BorderSides.Left | DocuFlow_Reg.RJControls.BorderSides.Top) 
            | DocuFlow_Reg.RJControls.BorderSides.Right) 
            | DocuFlow_Reg.RJControls.BorderSides.Bottom)));
            this.pnlDocReqDgv.BorderSize = 0;
            this.pnlDocReqDgv.BorderTopColor = System.Drawing.Color.Empty;
            this.pnlDocReqDgv.ForeColor = System.Drawing.Color.Black;
            this.pnlDocReqDgv.GradientColor1 = System.Drawing.Color.Empty;
            this.pnlDocReqDgv.GradientColor2 = System.Drawing.Color.Empty;
            this.pnlDocReqDgv.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlDocReqDgv.Location = new System.Drawing.Point(29, 15);
            this.pnlDocReqDgv.Name = "pnlDocReqDgv";
            this.pnlDocReqDgv.Size = new System.Drawing.Size(943, 748);
            this.pnlDocReqDgv.TabIndex = 12;
            this.pnlDocReqDgv.UseGradient = false;
            // 
            // DocumentRequestsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DocumentRequestsUC";
            this.Size = new System.Drawing.Size(1001, 779);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tlpRequest.ResumeLayout(false);
            this.pnlSearchFil.ResumeLayout(false);
            this.pnlSearchFil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpRequest;
        private System.Windows.Forms.Panel pnlSearchFil;
        private System.Windows.Forms.PictureBox pbSearch;
        private CustomControls.RJControls.RJTextBox txtSearch;
        private RJControls.RJPanel pnlSearch;
        private System.Windows.Forms.Label lblTypeOfUc;
        private System.Windows.Forms.DataGridView dgvReq;
        private RJControls.RJPanel pnlDocReqDgv;
    }
}
