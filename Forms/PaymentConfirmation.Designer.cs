namespace DocuFlow_Reg.Forms
{
    partial class PaymentConfirmation
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
            this.txtConfirmationRequest = new CustomControls.RJControls.RJTextBox();
            this.Save = new DocuFlow_Reg.RJControls.RJButton();
            this.btnCancel = new DocuFlow_Reg.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtConfirmationRequest
            // 
            this.txtConfirmationRequest.BackColor = System.Drawing.SystemColors.Window;
            this.txtConfirmationRequest.BorderColor = System.Drawing.Color.Black;
            this.txtConfirmationRequest.BorderFocusColor = System.Drawing.Color.Black;
            this.txtConfirmationRequest.BorderRadius = 0;
            this.txtConfirmationRequest.BorderSize = 1;
            this.txtConfirmationRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmationRequest.ForeColor = System.Drawing.Color.Black;
            this.txtConfirmationRequest.Location = new System.Drawing.Point(56, 45);
            this.txtConfirmationRequest.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmationRequest.Multiline = false;
            this.txtConfirmationRequest.Name = "txtConfirmationRequest";
            this.txtConfirmationRequest.Padding = new System.Windows.Forms.Padding(7);
            this.txtConfirmationRequest.PasswordChar = false;
            this.txtConfirmationRequest.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConfirmationRequest.PlaceholderText = "Enter Confirmation Number";
            this.txtConfirmationRequest.Size = new System.Drawing.Size(355, 36);
            this.txtConfirmationRequest.TabIndex = 0;
            this.txtConfirmationRequest.Texts = "";
            this.txtConfirmationRequest.UnderlinedStyle = false;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Save.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Save.BorderColor = System.Drawing.Color.Black;
            this.Save.BorderRadius = 0;
            this.Save.BorderSize = 1;
            this.Save.FlatAppearance.BorderSize = 0;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.Color.Black;
            this.Save.Location = new System.Drawing.Point(91, 126);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(129, 40);
            this.Save.TabIndex = 1;
            this.Save.Text = "Save";
            this.Save.TextColor = System.Drawing.Color.Black;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.BorderSize = 1;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(261, 126);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Payment Confimation";
            // 
            // PaymentConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 194);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.txtConfirmationRequest);
            this.Name = "PaymentConfirmation";
            this.Text = "PaymentConfirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJTextBox txtConfirmationRequest;
        private RJControls.RJButton Save;
        private RJControls.RJButton btnCancel;
        private System.Windows.Forms.Label label1;
    }
}