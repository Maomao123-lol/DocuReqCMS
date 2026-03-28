namespace DocuFlow_Reg
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblPasswordStrength = new System.Windows.Forms.Label();
            this.lblPasswordRequirements = new System.Windows.Forms.Label();
            this.lblReqSpecial = new System.Windows.Forms.Label();
            this.lblReqNumber = new System.Windows.Forms.Label();
            this.lblReqLowercase = new System.Windows.Forms.Label();
            this.lblReqUppercase = new System.Windows.Forms.Label();
            this.lblReqLength = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.lblNew = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.lblInstruction);
            this.panelMain.Controls.Add(this.lblPasswordStrength);
            this.panelMain.Controls.Add(this.lblPasswordRequirements);
            this.panelMain.Controls.Add(this.lblReqSpecial);
            this.panelMain.Controls.Add(this.lblReqNumber);
            this.panelMain.Controls.Add(this.lblReqLowercase);
            this.panelMain.Controls.Add(this.lblReqUppercase);
            this.panelMain.Controls.Add(this.lblReqLength);
            this.panelMain.Controls.Add(this.lblUsername);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtFullName);
            this.panelMain.Controls.Add(this.lblFullName);
            this.panelMain.Controls.Add(this.btnChangePassword);
            this.panelMain.Controls.Add(this.txtConfirmPassword);
            this.panelMain.Controls.Add(this.txtNewPassword);
            this.panelMain.Controls.Add(this.lblConfirm);
            this.panelMain.Controls.Add(this.lblNew);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(550, 620);
            this.panelMain.TabIndex = 0;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInstruction.Location = new System.Drawing.Point(50, 20);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(721, 32);
            this.lblInstruction.TabIndex = 23;
            this.lblInstruction.Text = "Please update your profile information and create a new password";
            this.lblInstruction.Click += new System.EventHandler(this.lblInstruction_Click);
            // 
            // lblPasswordStrength
            // 
            this.lblPasswordStrength.AutoSize = true;
            this.lblPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordStrength.Location = new System.Drawing.Point(70, 445);
            this.lblPasswordStrength.Name = "lblPasswordStrength";
            this.lblPasswordStrength.Size = new System.Drawing.Size(0, 25);
            this.lblPasswordStrength.TabIndex = 22;
            this.lblPasswordStrength.Visible = false;
            // 
            // lblPasswordRequirements
            // 
            this.lblPasswordRequirements.AutoSize = true;
            this.lblPasswordRequirements.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordRequirements.Location = new System.Drawing.Point(50, 330);
            this.lblPasswordRequirements.Name = "lblPasswordRequirements";
            this.lblPasswordRequirements.Size = new System.Drawing.Size(220, 25);
            this.lblPasswordRequirements.TabIndex = 16;
            this.lblPasswordRequirements.Text = "Password Requirements:";
            // 
            // lblReqSpecial
            // 
            this.lblReqSpecial.AutoSize = true;
            this.lblReqSpecial.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblReqSpecial.ForeColor = System.Drawing.Color.Red;
            this.lblReqSpecial.Location = new System.Drawing.Point(70, 422);
            this.lblReqSpecial.Name = "lblReqSpecial";
            this.lblReqSpecial.Size = new System.Drawing.Size(372, 23);
            this.lblReqSpecial.TabIndex = 21;
            this.lblReqSpecial.Text = "✗ At least one special character (!@#$%^&* etc.)";
            // 
            // lblReqNumber
            // 
            this.lblReqNumber.AutoSize = true;
            this.lblReqNumber.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblReqNumber.ForeColor = System.Drawing.Color.Red;
            this.lblReqNumber.Location = new System.Drawing.Point(70, 404);
            this.lblReqNumber.Name = "lblReqNumber";
            this.lblReqNumber.Size = new System.Drawing.Size(225, 23);
            this.lblReqNumber.TabIndex = 20;
            this.lblReqNumber.Text = "✗ At least one number (0-9)";
            // 
            // lblReqLowercase
            // 
            this.lblReqLowercase.AutoSize = true;
            this.lblReqLowercase.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblReqLowercase.ForeColor = System.Drawing.Color.Red;
            this.lblReqLowercase.Location = new System.Drawing.Point(70, 386);
            this.lblReqLowercase.Name = "lblReqLowercase";
            this.lblReqLowercase.Size = new System.Drawing.Size(283, 23);
            this.lblReqLowercase.TabIndex = 19;
            this.lblReqLowercase.Text = "✗ At least one lowercase letter (a-z)";
            // 
            // lblReqUppercase
            // 
            this.lblReqUppercase.AutoSize = true;
            this.lblReqUppercase.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblReqUppercase.ForeColor = System.Drawing.Color.Red;
            this.lblReqUppercase.Location = new System.Drawing.Point(70, 368);
            this.lblReqUppercase.Name = "lblReqUppercase";
            this.lblReqUppercase.Size = new System.Drawing.Size(291, 23);
            this.lblReqUppercase.TabIndex = 18;
            this.lblReqUppercase.Text = "✗ At least one uppercase letter (A-Z)";
            // 
            // lblReqLength
            // 
            this.lblReqLength.AutoSize = true;
            this.lblReqLength.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblReqLength.ForeColor = System.Drawing.Color.Red;
            this.lblReqLength.Location = new System.Drawing.Point(70, 350);
            this.lblReqLength.Name = "lblReqLength";
            this.lblReqLength.Size = new System.Drawing.Size(222, 23);
            this.lblReqLength.TabIndex = 17;
            this.lblReqLength.Text = "✗ At least 8 characters long";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblUsername.ForeColor = System.Drawing.Color.Gray;
            this.lblUsername.Location = new System.Drawing.Point(50, 55);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 25);
            this.lblUsername.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(50, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(450, 30);
            this.txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 135);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(60, 25);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(50, 105);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(450, 30);
            this.txtFullName.TabIndex = 7;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(50, 85);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 25);
            this.lblFullName.TabIndex = 6;
            this.lblFullName.Text = "Full Name";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(50, 535);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(450, 45);
            this.btnChangePassword.TabIndex = 5;
            this.btnChangePassword.Text = "Update Profile and Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(50, 505);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(450, 30);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(50, 305);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(450, 30);
            this.txtNewPassword.TabIndex = 3;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.txtNewPassword_TextChanged);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(50, 485);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(171, 25);
            this.lblConfirm.TabIndex = 2;
            this.lblConfirm.Text = "Confirm Password";
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(50, 285);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(142, 25);
            this.lblNew.TabIndex = 1;
            this.lblNew.Text = "New Password";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 620);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Profile Information";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPasswordRequirements;
        private System.Windows.Forms.Label lblReqSpecial;
        private System.Windows.Forms.Label lblReqNumber;
        private System.Windows.Forms.Label lblReqLowercase;
        private System.Windows.Forms.Label lblReqUppercase;
        private System.Windows.Forms.Label lblReqLength;
        private System.Windows.Forms.Label lblPasswordStrength;
    }
}