namespace DocuFlow_Reg.Forms
{
    partial class ChangeStatus
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnReleased = new DocuFlow_Reg.RJControls.RJButton();
            this.btnReady = new DocuFlow_Reg.RJControls.RJButton();
            this.btnProcessing = new DocuFlow_Reg.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(60, 23);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(295, 25);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "You want to change the status to?";
            // 
            // btnReleased
            // 
            this.btnReleased.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReleased.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReleased.BorderColor = System.Drawing.Color.Black;
            this.btnReleased.BorderRadius = 10;
            this.btnReleased.BorderSize = 1;
            this.btnReleased.FlatAppearance.BorderSize = 0;
            this.btnReleased.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleased.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReleased.ForeColor = System.Drawing.Color.Black;
            this.btnReleased.Location = new System.Drawing.Point(384, 75);
            this.btnReleased.Name = "btnReleased";
            this.btnReleased.Size = new System.Drawing.Size(147, 36);
            this.btnReleased.TabIndex = 3;
            this.btnReleased.Text = "Released";
            this.btnReleased.TextColor = System.Drawing.Color.Black;
            this.btnReleased.UseVisualStyleBackColor = false;
            // 
            // btnReady
            // 
            this.btnReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnReady.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnReady.BorderColor = System.Drawing.Color.Black;
            this.btnReady.BorderRadius = 10;
            this.btnReady.BorderSize = 1;
            this.btnReady.FlatAppearance.BorderSize = 0;
            this.btnReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReady.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReady.ForeColor = System.Drawing.Color.Black;
            this.btnReady.Location = new System.Drawing.Point(190, 76);
            this.btnReady.Name = "btnReady";
            this.btnReady.Size = new System.Drawing.Size(147, 36);
            this.btnReady.TabIndex = 2;
            this.btnReady.Text = "Ready to Release";
            this.btnReady.TextColor = System.Drawing.Color.Black;
            this.btnReady.UseVisualStyleBackColor = false;
            this.btnReady.Click += new System.EventHandler(this.btnReady_Click);
            // 
            // btnProcessing
            // 
            this.btnProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnProcessing.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnProcessing.BorderColor = System.Drawing.Color.Black;
            this.btnProcessing.BorderRadius = 10;
            this.btnProcessing.BorderSize = 1;
            this.btnProcessing.FlatAppearance.BorderSize = 0;
            this.btnProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessing.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessing.ForeColor = System.Drawing.Color.Black;
            this.btnProcessing.Location = new System.Drawing.Point(12, 75);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(136, 36);
            this.btnProcessing.TabIndex = 1;
            this.btnProcessing.Text = "Processing";
            this.btnProcessing.TextColor = System.Drawing.Color.Black;
            this.btnProcessing.UseVisualStyleBackColor = false;
            // 
            // ChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 123);
            this.Controls.Add(this.btnReleased);
            this.Controls.Add(this.btnReady);
            this.Controls.Add(this.btnProcessing);
            this.Controls.Add(this.lblMessage);
            this.Name = "ChangeStatus";
            this.Text = "ChangeStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private RJControls.RJButton btnProcessing;
        private RJControls.RJButton btnReady;
        private RJControls.RJButton btnReleased;
    }
}