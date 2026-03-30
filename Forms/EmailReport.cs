using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace DocuFlow_Reg.Forms
{
    public partial class EmailReport : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private string _requestNumber;

        public EmailReport(string requestNumber = null)
        {
            InitializeComponent();
            _requestNumber = requestNumber;

            lblEmailSubject.AutoSize = false;
            lblEmailSubject.TextAlign = ContentAlignment.TopLeft;
            lblEmailSubject.MaximumSize = new Size(400, 0);
            lblEmailSubject.Size = new Size(400, 200);

            this.Load += EmailReport_Load;
        }

        private void EmailReport_Load(object sender, EventArgs e)
        {
            if (_requestNumber == null) return;

            // Fetch student details from Request and Student tables
            DataTable dt = db.ExecuteQuery(@"
                SELECT 
                    s.name,
                    s.gmail,
                    r.request_number,
                    r.service_type
                FROM Request r
                INNER JOIN Student s ON s.student_number = r.student_number
                WHERE r.request_number = @requestNumber",
                new Dictionary<string, object>
                {
                    { "@requestNumber", _requestNumber }
                });

            if (dt.Rows.Count > 0)
            {
                string studentName = dt.Rows[0]["name"].ToString();
                string documentType = dt.Rows[0]["service_type"].ToString();

                lblEmailSubject.Text =
                    "Dear " + studentName + ",\r\n\r\n" +
                    "Your requested document (" + documentType + ") is now ready for pickup. " +
                    "Please proceed to the registrar's office during office hours and present a valid ID.\r\n\r\n" +
                    "Please be advised that failure to claim your document within 10 days may result " +
                    "in your request being archived and you will need to resubmit a new request.\r\n\r\n" +
                    "Thank you.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string toEmail = lblEmailAddress.Text.Trim();
            string fromEmail = lblSenderEmail.Text.Trim();
            string body = lblEmailSubject.Text;

            if (string.IsNullOrEmpty(toEmail))
            {
                MessageBox.Show("Recipient email address is missing.", "Cannot Send",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(fromEmail, "Registrar's Office");
                mail.To.Add(toEmail);
                mail.Subject = "Document Ready for Pickup";
                mail.Body = body;
                mail.IsBodyHtml = false;

                // Gmail SMTP — replace credentials with your actual sender account
                var smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("your-sender@gmail.com", "your-app-password");
                smtp.EnableSsl = true;

                btnSend.Enabled = false;
                btnSend.Text = "Sending…";

                smtp.Send(mail);

                MessageBox.Show("Email sent successfully to " + toEmail, "Sent",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Failed to send email:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "Send";
            }
        }
    }
}