namespace DocuReqCMS
{
    partial class UserPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblAddSection = new System.Windows.Forms.Label();
            this.lblUsernameLabel = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panelDivider = new System.Windows.Forms.Panel();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.panelGuide = new System.Windows.Forms.Panel();
            this.lblGuideTitle = new System.Windows.Forms.Label();
            this.lblGuide1 = new System.Windows.Forms.Label();
            this.lblGuide2 = new System.Windows.Forms.Label();
            this.lblGuide3 = new System.Windows.Forms.Label();
            this.lblGuide4 = new System.Windows.Forms.Label();
            this.lblGuide5 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelSummaryBar = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastLogout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDefaultPassword = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelGuide.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelSummaryBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(238)))));
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.panelBody);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(1400, 800);
            this.panelMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.panelHeader.Controls.Add(this.lblPageTitle);
            this.panelHeader.Controls.Add(this.lblPageSubtitle);
            this.panelHeader.Location = new System.Drawing.Point(20, 20);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.panelHeader.Size = new System.Drawing.Size(1360, 72);
            this.panelHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(20, 10);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(357, 45);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "👥  User Management";
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(22, 42);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(400, 25);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Manage registrar accounts and access credentials";
            // 
            // panelBody
            // 
            this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBody.Controls.Add(this.panelLeft);
            this.panelBody.Controls.Add(this.panelRight);
            this.panelBody.Location = new System.Drawing.Point(20, 100);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1360, 680);
            this.panelBody.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.lblAddSection);
            this.panelLeft.Controls.Add(this.lblUsernameLabel);
            this.panelLeft.Controls.Add(this.txtUsername);
            this.panelLeft.Controls.Add(this.btnAddUser);
            this.panelLeft.Controls.Add(this.panelDivider);
            this.panelLeft.Controls.Add(this.btnResetPassword);
            this.panelLeft.Controls.Add(this.panelGuide);
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(20);
            this.panelLeft.Size = new System.Drawing.Size(320, 680);
            this.panelLeft.TabIndex = 0;
            // 
            // lblAddSection
            // 
            this.lblAddSection.AutoSize = true;
            this.lblAddSection.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAddSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.lblAddSection.Location = new System.Drawing.Point(20, 20);
            this.lblAddSection.Name = "lblAddSection";
            this.lblAddSection.Size = new System.Drawing.Size(252, 30);
            this.lblAddSection.TabIndex = 0;
            this.lblAddSection.Text = "➕  Add New Registrar";
            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.AutoSize = true;
            this.lblUsernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblUsernameLabel.Location = new System.Drawing.Point(21, 48);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.Size = new System.Drawing.Size(111, 25);
            this.lblUsernameLabel.TabIndex = 1;
            this.lblUsernameLabel.Text = "USERNAME";
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(20, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(275, 37);
            this.txtUsername.TabIndex = 1;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(20, 125);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(275, 42);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "Create Account";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // panelDivider
            // 
            this.panelDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(220)))));
            this.panelDivider.Location = new System.Drawing.Point(20, 182);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(275, 1);
            this.panelDivider.TabIndex = 3;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(20, 195);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(275, 42);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = "🔐  Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // panelGuide
            // 
            this.panelGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGuide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.panelGuide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGuide.Controls.Add(this.lblGuideTitle);
            this.panelGuide.Controls.Add(this.lblGuide5);
            this.panelGuide.Controls.Add(this.lblGuide1);
            this.panelGuide.Controls.Add(this.lblGuide2);
            this.panelGuide.Controls.Add(this.lblGuide3);
            this.panelGuide.Controls.Add(this.lblGuide4);
            this.panelGuide.Location = new System.Drawing.Point(20, 255);
            this.panelGuide.Name = "panelGuide";
            this.panelGuide.Padding = new System.Windows.Forms.Padding(15);
            this.panelGuide.Size = new System.Drawing.Size(275, 370);
            this.panelGuide.TabIndex = 4;
            // 
            // lblGuideTitle
            // 
            this.lblGuideTitle.AutoSize = true;
            this.lblGuideTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGuideTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(130)))), ((int)(((byte)(50)))));
            this.lblGuideTitle.Location = new System.Drawing.Point(15, 15);
            this.lblGuideTitle.Name = "lblGuideTitle";
            this.lblGuideTitle.Size = new System.Drawing.Size(161, 28);
            this.lblGuideTitle.TabIndex = 0;
            this.lblGuideTitle.Text = "📋  How to Use";
            // 
            // lblGuide1
            // 
            this.lblGuide1.Location = new System.Drawing.Point(0, 0);
            this.lblGuide1.Name = "lblGuide1";
            this.lblGuide1.Size = new System.Drawing.Size(100, 23);
            this.lblGuide1.TabIndex = 1;
            // 
            // lblGuide2
            // 
            this.lblGuide2.Location = new System.Drawing.Point(0, 0);
            this.lblGuide2.Name = "lblGuide2";
            this.lblGuide2.Size = new System.Drawing.Size(100, 23);
            this.lblGuide2.TabIndex = 2;
            // 
            // lblGuide3
            // 
            this.lblGuide3.Location = new System.Drawing.Point(0, 0);
            this.lblGuide3.Name = "lblGuide3";
            this.lblGuide3.Size = new System.Drawing.Size(100, 23);
            this.lblGuide3.TabIndex = 3;
            // 
            // lblGuide4
            // 
            this.lblGuide4.Location = new System.Drawing.Point(0, 0);
            this.lblGuide4.Name = "lblGuide4";
            this.lblGuide4.Size = new System.Drawing.Size(100, 23);
            this.lblGuide4.TabIndex = 4;
            // 
            // lblGuide5
            // 
            this.lblGuide5.Location = new System.Drawing.Point(0, 0);
            this.lblGuide5.Name = "lblGuide5";
            this.lblGuide5.Size = new System.Drawing.Size(100, 23);
            this.lblGuide5.TabIndex = 5;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.panelSummaryBar);
            this.panelRight.Controls.Add(this.dataGridViewUsers);
            this.panelRight.Location = new System.Drawing.Point(330, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1030, 680);
            this.panelRight.TabIndex = 1;
            // 
            // panelSummaryBar
            // 
            this.panelSummaryBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSummaryBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.panelSummaryBar.Controls.Add(this.lblSummary);
            this.panelSummaryBar.Location = new System.Drawing.Point(0, 0);
            this.panelSummaryBar.Name = "panelSummaryBar";
            this.panelSummaryBar.Size = new System.Drawing.Size(1030, 38);
            this.panelSummaryBar.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(120)))), ((int)(((byte)(60)))));
            this.lblSummary.Location = new System.Drawing.Point(14, 10);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(88, 25);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Loading...";
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(208)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUsers.ColumnHeadersHeight = 50;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colUserId,
            this.colUsername,
            this.colFullName,
            this.colRole,
            this.colStatus,
            this.colLastLogin,
            this.colLastLogout,
            this.colDefaultPassword});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUsers.EnableHeadersVisualStyles = false;
            this.dataGridViewUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(245)))), ((int)(((byte)(220)))));
            this.dataGridViewUsers.Location = new System.Drawing.Point(0, 38);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.RowHeadersVisible = false;
            this.dataGridViewUsers.RowHeadersWidth = 62;
            this.dataGridViewUsers.RowTemplate.Height = 44;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(1030, 642);
            this.dataGridViewUsers.TabIndex = 1;
            // 
            // colUserId
            // 
            this.colUserId.FillWeight = 4F;
            this.colUserId.HeaderText = "ID";
            this.colUserId.MinimumWidth = 50;
            this.colUserId.Name = "colUserId";
            this.colUserId.ReadOnly = true;
            // 
            // colUsername
            // 
            this.colUsername.FillWeight = 14F;
            this.colUsername.HeaderText = "Username";
            this.colUsername.MinimumWidth = 130;
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.FillWeight = 20F;
            this.colFullName.HeaderText = "Full Name";
            this.colFullName.MinimumWidth = 160;
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.FillWeight = 10F;
            this.colRole.HeaderText = "Role";
            this.colRole.MinimumWidth = 100;
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 9F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 90;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colLastLogin
            // 
            this.colLastLogin.FillWeight = 16F;
            this.colLastLogin.HeaderText = "Last Login";
            this.colLastLogin.MinimumWidth = 140;
            this.colLastLogin.Name = "colLastLogin";
            this.colLastLogin.ReadOnly = true;
            // 
            // colLastLogout
            // 
            this.colLastLogout.FillWeight = 16F;
            this.colLastLogout.HeaderText = "Last Logout";
            this.colLastLogout.MinimumWidth = 140;
            this.colLastLogout.Name = "colLastLogout";
            this.colLastLogout.ReadOnly = true;
            // 
            // colDefaultPassword
            // 
            this.colDefaultPassword.FillWeight = 11F;
            this.colDefaultPassword.HeaderText = "Default Pwd?";
            this.colDefaultPassword.MinimumWidth = 100;
            this.colDefaultPassword.Name = "colDefaultPassword";
            this.colDefaultPassword.ReadOnly = true;
            this.colDefaultPassword.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDefaultPassword.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "UserPage";
            this.Text = "User Management";
            this.panelMain.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelGuide.ResumeLayout(false);
            this.panelGuide.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelSummaryBar.ResumeLayout(false);
            this.panelSummaryBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);

        }

        // Helper to build guide step labels cleanly
        private void BuildGuideLabel(ref System.Windows.Forms.Label titleLbl, string name, int y,
            string title, string body)
        {
            // title label
            titleLbl = new System.Windows.Forms.Label
            {
                Name = name,
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(40, 130, 50),
                Location = new System.Drawing.Point(15, y),
                Text = title
            };

            // body label (placed right after)
            var bodyLbl = new System.Windows.Forms.Label
            {
                AutoSize = false,
                Font = new System.Drawing.Font("Segoe UI", 8.5F),
                ForeColor = System.Drawing.Color.FromArgb(80, 80, 80),
                Location = new System.Drawing.Point(15, y + 18),
                Size = new System.Drawing.Size(240, 52),
                Text = body
            };

            this.panelGuide.Controls.Add(titleLbl);
            this.panelGuide.Controls.Add(bodyLbl);
        }

        #endregion

        // ── Controls ─────────────────────────────────────
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblAddSection;
        private System.Windows.Forms.Label lblUsernameLabel;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Panel panelDivider;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Panel panelGuide;
        private System.Windows.Forms.Label lblGuideTitle;
        private System.Windows.Forms.Label lblGuide1;
        private System.Windows.Forms.Label lblGuide2;
        private System.Windows.Forms.Label lblGuide3;
        private System.Windows.Forms.Label lblGuide4;
        private System.Windows.Forms.Label lblGuide5;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelSummaryBar;
        public System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastLogout;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDefaultPassword;
    }
}