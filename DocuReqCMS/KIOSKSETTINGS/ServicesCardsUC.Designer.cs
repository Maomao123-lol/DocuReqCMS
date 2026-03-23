namespace DocuReqCMS.KIOSKSETTINGS
{
    partial class ServicesCardsUC
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnServiceCard = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1590, 763);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnServiceCard
            // 
            this.btnServiceCard.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnServiceCard.BorderRadius = 20;
            this.btnServiceCard.BorderThickness = 1;
            this.btnServiceCard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnServiceCard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnServiceCard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnServiceCard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnServiceCard.FillColor = System.Drawing.Color.White;
            this.btnServiceCard.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnServiceCard.ForeColor = System.Drawing.Color.Black;
            this.btnServiceCard.Location = new System.Drawing.Point(18, 12);
            this.btnServiceCard.Name = "btnServiceCard";
            this.btnServiceCard.Size = new System.Drawing.Size(180, 45);
            this.btnServiceCard.TabIndex = 0;
            this.btnServiceCard.Text = "Add Service Card";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnServiceCard);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 763);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1590, 70);
            this.guna2Panel2.TabIndex = 3;
            // 
            // ServicesCardsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 833);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServicesCardsUC";
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button btnServiceCard;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}
