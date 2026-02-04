namespace DocuReqCMS
{
    partial class TestingForm
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
            this.WelcomeAd = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanelKiosk = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeAd)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeAd
            // 
            this.WelcomeAd.Location = new System.Drawing.Point(69, 44);
            this.WelcomeAd.Name = "WelcomeAd";
            this.WelcomeAd.Size = new System.Drawing.Size(633, 615);
            this.WelcomeAd.TabIndex = 0;
            this.WelcomeAd.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 690);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // flowPanelKiosk
            // 
            this.flowPanelKiosk.AutoScroll = true;
            this.flowPanelKiosk.Location = new System.Drawing.Point(745, 44);
            this.flowPanelKiosk.Name = "flowPanelKiosk";
            this.flowPanelKiosk.Size = new System.Drawing.Size(986, 553);
            this.flowPanelKiosk.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 675);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1768, 735);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowPanelKiosk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WelcomeAd);
            this.Name = "TestingForm";
            this.Text = "TestingForm";
            ((System.ComponentModel.ISupportInitialize)(this.WelcomeAd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WelcomeAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelKiosk;
        private System.Windows.Forms.Label label2;
    }
}