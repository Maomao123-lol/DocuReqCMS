namespace KIOSK.Request
{
    partial class requestForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.childForm = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnPayFee = new System.Windows.Forms.Button();
            this.btnDocument = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.childForm.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.childForm);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1902, 878);
            this.panel1.TabIndex = 0;
            // 
            // childForm
            // 
            this.childForm.Controls.Add(this.flowLayoutPanel1);
            this.childForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.childForm.Location = new System.Drawing.Point(311, 0);
            this.childForm.Name = "childForm";
            this.childForm.Size = new System.Drawing.Size(1591, 878);
            this.childForm.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(55, 20, 0, 20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1591, 878);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btnPayFee);
            this.panel2.Controls.Add(this.btnDocument);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 878);
            this.panel2.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(41, 790);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(223, 70);
            this.button4.TabIndex = 3;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnPayFee
            // 
            this.btnPayFee.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayFee.Location = new System.Drawing.Point(41, 429);
            this.btnPayFee.Name = "btnPayFee";
            this.btnPayFee.Size = new System.Drawing.Size(223, 223);
            this.btnPayFee.TabIndex = 2;
            this.btnPayFee.Text = "Pay Fee";
            this.btnPayFee.UseVisualStyleBackColor = true;
            // 
            // btnDocument
            // 
            this.btnDocument.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocument.Location = new System.Drawing.Point(41, 126);
            this.btnDocument.Name = "btnDocument";
            this.btnDocument.Size = new System.Drawing.Size(223, 223);
            this.btnDocument.TabIndex = 0;
            this.btnDocument.Text = "Document";
            this.btnDocument.UseVisualStyleBackColor = true;
            // 
            // requestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 878);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "requestForm";
            this.Text = "requestForm";
            this.panel1.ResumeLayout(false);
            this.childForm.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel childForm;
        private System.Windows.Forms.Button btnDocument;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnPayFee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}