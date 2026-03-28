namespace DocuFlow_Reg.Forms
{
    partial class RequestDetails
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
            this.tlpReqDetails = new System.Windows.Forms.TableLayoutPanel();
            this.pnlReqID = new System.Windows.Forms.Panel();
            this.lblRequestCode = new System.Windows.Forms.Label();
            this.lblReqID = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStudentNum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCourseNYear = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlTypeOfDoc = new DocuFlow_Reg.RJControls.RJPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlStudentInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new DocuFlow_Reg.RJControls.RJButton();
            this.btnMarkAsReady = new DocuFlow_Reg.RJControls.RJButton();
            this.btnPrint = new DocuFlow_Reg.RJControls.RJButton();
            this.cblRequirements = new System.Windows.Forms.CheckedListBox();
            this.tlpReqDetails.SuspendLayout();
            this.pnlReqID.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlStudentInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpReqDetails
            // 
            this.tlpReqDetails.AutoScroll = true;
            this.tlpReqDetails.ColumnCount = 1;
            this.tlpReqDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpReqDetails.Controls.Add(this.pnlReqID, 0, 0);
            this.tlpReqDetails.Controls.Add(this.pnlBody, 0, 1);
            this.tlpReqDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpReqDetails.Location = new System.Drawing.Point(0, 0);
            this.tlpReqDetails.Margin = new System.Windows.Forms.Padding(2);
            this.tlpReqDetails.Name = "tlpReqDetails";
            this.tlpReqDetails.RowCount = 2;
            this.tlpReqDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.26034F));
            this.tlpReqDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.73966F));
            this.tlpReqDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpReqDetails.Size = new System.Drawing.Size(697, 653);
            this.tlpReqDetails.TabIndex = 0;
            // 
            // pnlReqID
            // 
            this.pnlReqID.BackColor = System.Drawing.Color.White;
            this.pnlReqID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReqID.Controls.Add(this.lblRequestCode);
            this.pnlReqID.Controls.Add(this.lblReqID);
            this.pnlReqID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReqID.Location = new System.Drawing.Point(0, 0);
            this.pnlReqID.Margin = new System.Windows.Forms.Padding(0);
            this.pnlReqID.Name = "pnlReqID";
            this.pnlReqID.Size = new System.Drawing.Size(697, 67);
            this.pnlReqID.TabIndex = 0;
            // 
            // lblRequestCode
            // 
            this.lblRequestCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRequestCode.AutoSize = true;
            this.lblRequestCode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestCode.Location = new System.Drawing.Point(530, 18);
            this.lblRequestCode.Name = "lblRequestCode";
            this.lblRequestCode.Size = new System.Drawing.Size(113, 32);
            this.lblRequestCode.TabIndex = 3;
            this.lblRequestCode.Text = "REQ-001";
            // 
            // lblReqID
            // 
            this.lblReqID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReqID.AutoSize = true;
            this.lblReqID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReqID.Location = new System.Drawing.Point(11, 18);
            this.lblReqID.Name = "lblReqID";
            this.lblReqID.Size = new System.Drawing.Size(190, 32);
            this.lblReqID.TabIndex = 2;
            this.lblReqID.Text = "Request Details";
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.pnlStudentInfo);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 67);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(697, 586);
            this.pnlBody.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(20, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student Name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(20, 107);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(158, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Vergel Moyamoy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(238, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Student Number";
            // 
            // lblStudentNum
            // 
            this.lblStudentNum.AutoSize = true;
            this.lblStudentNum.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentNum.ForeColor = System.Drawing.Color.Black;
            this.lblStudentNum.Location = new System.Drawing.Point(254, 107);
            this.lblStudentNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStudentNum.Name = "lblStudentNum";
            this.lblStudentNum.Size = new System.Drawing.Size(96, 25);
            this.lblStudentNum.TabIndex = 4;
            this.lblStudentNum.Text = "20231567";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(21, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Course and Year";
            // 
            // lblCourseNYear
            // 
            this.lblCourseNYear.AutoSize = true;
            this.lblCourseNYear.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseNYear.ForeColor = System.Drawing.Color.Black;
            this.lblCourseNYear.Location = new System.Drawing.Point(22, 184);
            this.lblCourseNYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCourseNYear.Name = "lblCourseNYear";
            this.lblCourseNYear.Size = new System.Drawing.Size(106, 25);
            this.lblCourseNYear.TabIndex = 6;
            this.lblCourseNYear.Text = "BSCS - 2nd";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(455, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "Contact Number";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.Black;
            this.lblContact.Location = new System.Drawing.Point(455, 106);
            this.lblContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(131, 25);
            this.lblContact.TabIndex = 8;
            this.lblContact.Text = "09282729760";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(455, 162);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 21);
            this.label11.TabIndex = 9;
            this.label11.Text = "Email";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(419, 185);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(216, 25);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "vmoyamoy@gmail.com";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(20, 326);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 30);
            this.label12.TabIndex = 11;
            this.label12.Text = "Document Type";
            // 
            // pnlTypeOfDoc
            // 
            this.pnlTypeOfDoc.BackColor = System.Drawing.Color.Transparent;
            this.pnlTypeOfDoc.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTypeOfDoc.BorderBottomColor = System.Drawing.Color.Empty;
            this.pnlTypeOfDoc.BorderColor = System.Drawing.Color.Gray;
            this.pnlTypeOfDoc.BorderLeftColor = System.Drawing.Color.Empty;
            this.pnlTypeOfDoc.BorderRadius = 18;
            this.pnlTypeOfDoc.BorderRightColor = System.Drawing.Color.Empty;
            this.pnlTypeOfDoc.BorderSides = ((DocuFlow_Reg.RJControls.BorderSides)((((DocuFlow_Reg.RJControls.BorderSides.Left | DocuFlow_Reg.RJControls.BorderSides.Top) 
            | DocuFlow_Reg.RJControls.BorderSides.Right) 
            | DocuFlow_Reg.RJControls.BorderSides.Bottom)));
            this.pnlTypeOfDoc.BorderSize = 0;
            this.pnlTypeOfDoc.BorderTopColor = System.Drawing.Color.Empty;
            this.pnlTypeOfDoc.ForeColor = System.Drawing.Color.Black;
            this.pnlTypeOfDoc.GradientColor1 = System.Drawing.Color.Empty;
            this.pnlTypeOfDoc.GradientColor2 = System.Drawing.Color.Empty;
            this.pnlTypeOfDoc.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pnlTypeOfDoc.Location = new System.Drawing.Point(23, 358);
            this.pnlTypeOfDoc.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTypeOfDoc.Name = "pnlTypeOfDoc";
            this.pnlTypeOfDoc.Size = new System.Drawing.Size(583, 77);
            this.pnlTypeOfDoc.TabIndex = 12;
            this.pnlTypeOfDoc.UseGradient = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(47, 382);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(190, 25);
            this.label13.TabIndex = 13;
            this.label13.Text = "Transcript of Records";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Green;
            this.label14.Location = new System.Drawing.Point(506, 382);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 32);
            this.label14.TabIndex = 14;
            this.label14.Text = "₱150";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(273, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Age";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(274, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(23, 234);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "Academic Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(30, 255);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Irregular";
            // 
            // pnlStudentInfo
            // 
            this.pnlStudentInfo.BackColor = System.Drawing.Color.White;
            this.pnlStudentInfo.Controls.Add(this.cblRequirements);
            this.pnlStudentInfo.Controls.Add(this.panel1);
            this.pnlStudentInfo.Controls.Add(this.label6);
            this.pnlStudentInfo.Controls.Add(this.label8);
            this.pnlStudentInfo.Controls.Add(this.label3);
            this.pnlStudentInfo.Controls.Add(this.label4);
            this.pnlStudentInfo.Controls.Add(this.label14);
            this.pnlStudentInfo.Controls.Add(this.label13);
            this.pnlStudentInfo.Controls.Add(this.pnlTypeOfDoc);
            this.pnlStudentInfo.Controls.Add(this.label12);
            this.pnlStudentInfo.Controls.Add(this.lblEmail);
            this.pnlStudentInfo.Controls.Add(this.label11);
            this.pnlStudentInfo.Controls.Add(this.lblContact);
            this.pnlStudentInfo.Controls.Add(this.label9);
            this.pnlStudentInfo.Controls.Add(this.lblCourseNYear);
            this.pnlStudentInfo.Controls.Add(this.label7);
            this.pnlStudentInfo.Controls.Add(this.lblStudentNum);
            this.pnlStudentInfo.Controls.Add(this.label5);
            this.pnlStudentInfo.Controls.Add(this.lblName);
            this.pnlStudentInfo.Controls.Add(this.label2);
            this.pnlStudentInfo.Controls.Add(this.label1);
            this.pnlStudentInfo.Location = new System.Drawing.Point(17, 2);
            this.pnlStudentInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlStudentInfo.Name = "pnlStudentInfo";
            this.pnlStudentInfo.Size = new System.Drawing.Size(655, 683);
            this.pnlStudentInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnMarkAsReady);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 104);
            this.panel1.TabIndex = 23;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.BorderColor = System.Drawing.Color.Gray;
            this.btnClose.BorderRadius = 18;
            this.btnClose.BorderSize = 1;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(50, 23);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 58);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.TextColor = System.Drawing.Color.Black;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMarkAsReady
            // 
            this.btnMarkAsReady.BackColor = System.Drawing.Color.Green;
            this.btnMarkAsReady.BackgroundColor = System.Drawing.Color.Green;
            this.btnMarkAsReady.BorderColor = System.Drawing.Color.Gray;
            this.btnMarkAsReady.BorderRadius = 18;
            this.btnMarkAsReady.BorderSize = 1;
            this.btnMarkAsReady.FlatAppearance.BorderSize = 0;
            this.btnMarkAsReady.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkAsReady.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkAsReady.ForeColor = System.Drawing.Color.White;
            this.btnMarkAsReady.Location = new System.Drawing.Point(492, 23);
            this.btnMarkAsReady.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkAsReady.Name = "btnMarkAsReady";
            this.btnMarkAsReady.Size = new System.Drawing.Size(112, 58);
            this.btnMarkAsReady.TabIndex = 21;
            this.btnMarkAsReady.Text = "Proceed";
            this.btnMarkAsReady.TextColor = System.Drawing.Color.White;
            this.btnMarkAsReady.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrint.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPrint.BorderColor = System.Drawing.Color.Gray;
            this.btnPrint.BorderRadius = 18;
            this.btnPrint.BorderSize = 1;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(277, 23);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(112, 58);
            this.btnPrint.TabIndex = 19;
            this.btnPrint.Text = "Accomplish";
            this.btnPrint.TextColor = System.Drawing.Color.Black;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // cblRequirements
            // 
            this.cblRequirements.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cblRequirements.FormattingEnabled = true;
            this.cblRequirements.Location = new System.Drawing.Point(52, 454);
            this.cblRequirements.Name = "cblRequirements";
            this.cblRequirements.Size = new System.Drawing.Size(534, 88);
            this.cblRequirements.TabIndex = 24;
            // 
            // RequestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 653);
            this.ControlBox = false;
            this.Controls.Add(this.tlpReqDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "RequestDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RequestDetails";
            this.tlpReqDetails.ResumeLayout(false);
            this.pnlReqID.ResumeLayout(false);
            this.pnlReqID.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlStudentInfo.ResumeLayout(false);
            this.pnlStudentInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpReqDetails;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlReqID;
        private System.Windows.Forms.Label lblReqID;
        private System.Windows.Forms.Label lblRequestCode;
        private System.Windows.Forms.Panel pnlStudentInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private RJControls.RJPanel pnlTypeOfDoc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCourseNYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStudentNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private RJControls.RJButton btnClose;
        private RJControls.RJButton btnMarkAsReady;
        private RJControls.RJButton btnPrint;
        private System.Windows.Forms.CheckedListBox cblRequirements;
    }
}