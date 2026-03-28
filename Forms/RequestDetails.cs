using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    public partial class RequestDetails : Form
    {
        DatabaseHelper db = new DatabaseHelper();
        private string _studentNumber;
        private string _queueNo;
        private Action _onClose;

        public RequestDetails(string studentNumber, string queueNo, Action onClose = null)
        {
            InitializeComponent();
            _studentNumber = studentNumber;
            _queueNo = queueNo;
            _onClose = onClose;
            this.Load += RequestDetails_Load;
        }

        private void CloseAndRefresh()
        {
            _onClose?.Invoke();
            this.Close();
        }

        private void RequestDetails_Load(object sender, EventArgs e)
        {
            LoadStudentDetails();
            LoadDocumentType();
            LoadRequirements();
        }

        private void LoadStudentDetails()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT 
                    s.name,
                    s.student_number,
                    s.contact_number,
                    s.course,
                    s.year,
                    s.age,
                    s.gmail,
                    s.academic_status
                FROM Student s
                WHERE s.student_number = @studentNumber",
                new Dictionary<string, object>
                {
                    { "@studentNumber", _studentNumber }
                });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblName.Text = row["name"].ToString();
                lblStudentNum.Text = row["student_number"].ToString();
                lblContact.Text = row["contact_number"].ToString();
                lblCourseNYear.Text = row["course"].ToString() + " - " + row["year"].ToString();
                lblAge.Text = row["age"].ToString();
                lblEmail.Text = row["gmail"].ToString();
                lblStatus.Text = row["academic_status"].ToString();
            }
        }

        private void LoadDocumentType()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT qt.type, qt.queue_no
                FROM queue_tickets qt
                WHERE qt.queue_no = @queueNo",
                new Dictionary<string, object>
                {
                    { "@queueNo", _queueNo }
                });

            if (dt.Rows.Count > 0)
            {
                lblDocumentType.Text = dt.Rows[0]["type"].ToString();
                lblRequestCode.Text = dt.Rows[0]["queue_no"].ToString();
            }
        }

        private void LoadRequirements()
        {
            cblRequirements.Items.Clear();

            string documentType = lblDocumentType.Text.Trim();
            string studentNumber = lblStudentNum.Text.Trim();

            if (!DocumentRequirements.Requirements.ContainsKey(documentType))
            {
                cblRequirements.Items.Add("No requirements found for this document");
                return;
            }

            List<string> requirements = DocumentRequirements.Requirements[documentType];

            foreach (string requirement in requirements)
            {
                DataTable dt = db.ExecuteQuery(@"
                    SELECT sd.is_complete
                    FROM Student_Documents sd
                    INNER JOIN Document_Requirements dr
                        ON dr.requirement_id = sd.requirement_id
                    WHERE sd.student_number = @studentNumber
                    AND dr.requirement_name = @requirement",
                    new Dictionary<string, object>
                    {
                        { "@studentNumber", studentNumber },
                        { "@requirement",   requirement   }
                    });

                bool isComplete = dt.Rows.Count > 0
                                  && Convert.ToBoolean(dt.Rows[0]["is_complete"]);

                cblRequirements.Items.Add(requirement, isComplete);
            }
        }

        private void SaveRequirements()
        {
            string studentNumber = lblStudentNum.Text.Trim();

            for (int i = 0; i < cblRequirements.Items.Count; i++)
            {
                string requirementName = cblRequirements.Items[i].ToString();
                bool isChecked = cblRequirements.GetItemChecked(i);

                // Get requirement_id
                DataTable dt = db.ExecuteQuery(@"
                    SELECT requirement_id 
                    FROM Document_Requirements 
                    WHERE requirement_name = @requirement",
                    new Dictionary<string, object>
                    {
                        { "@requirement", requirementName }
                    });

                if (dt.Rows.Count == 0) continue;

                int requirementId = Convert.ToInt32(dt.Rows[0]["requirement_id"]);

                // Check if record already exists
                DataTable existing = db.ExecuteQuery(@"
                    SELECT record_id 
                    FROM Student_Documents 
                    WHERE student_number = @studentNumber 
                    AND requirement_id = @requirementId",
                    new Dictionary<string, object>
                    {
                        { "@studentNumber", studentNumber },
                        { "@requirementId", requirementId }
                    });

                if (existing.Rows.Count > 0)
                {
                    // Update existing
                    db.ExecuteNonQuery(@"
                        UPDATE Student_Documents 
                        SET is_complete = @isComplete
                        WHERE student_number = @studentNumber 
                        AND requirement_id = @requirementId",
                        new Dictionary<string, object>
                        {
                            { "@isComplete",    isChecked ? 1 : 0 },
                            { "@studentNumber", studentNumber },
                            { "@requirementId", requirementId }
                        });
                }
                else
                {
                    // Insert new
                    db.ExecuteNonQuery(@"
                        INSERT INTO Student_Documents 
                        (student_number, requirement_id, date_submitted, is_complete)
                        VALUES 
                        (@studentNumber, @requirementId, @dateSubmitted, @isComplete)",
                        new Dictionary<string, object>
                        {
                            { "@studentNumber", studentNumber },
                            { "@requirementId", requirementId },
                            { "@dateSubmitted", DateTime.Now.ToString("yyyy-MM-dd") },
                            { "@isComplete",    isChecked ? 1 : 0 }
                        });
                }
            }

            MessageBox.Show("Requirements saved successfully.", "Success");
        }

        private string GenerateRequestNumber()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT request_number 
                FROM Request 
                ORDER BY created_at DESC 
                LIMIT 1");

            if (dt.Rows.Count == 0) return "REQ-001";

            string last = dt.Rows[0]["request_number"].ToString();
            string[] parts = last.Split('-');

            if (parts.Length == 2 && int.TryParse(parts[1], out int number))
            {
                return "REQ-" + (number + 1).ToString("D3");
            }

            return "REQ-001";
        }

        private void DeleteFromQueue()
        {
            DataTable dt = db.ExecuteQuery(@"
                SELECT id FROM queue_tickets 
                WHERE queue_no = @queueNo",
                new Dictionary<string, object>
                {
                    { "@queueNo", _queueNo }
                });

            if (dt.Rows.Count == 0) return;

            int ticketId = Convert.ToInt32(dt.Rows[0]["id"]);

            db.ExecuteNonQuery(@"
                DELETE FROM Inquiry 
                WHERE ticket_id = @ticketId",
                new Dictionary<string, object>
                {
                    { "@ticketId", ticketId }
                });

            db.ExecuteNonQuery(@"
                DELETE FROM queue_tickets 
                WHERE id = @ticketId",
                new Dictionary<string, object>
                {
                    { "@ticketId", ticketId }
                });
        }

        private void btnMarkAsReady_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to approve this request?",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            try
            {
                string requestNumber = GenerateRequestNumber();

                DataTable docDt = db.ExecuteQuery(@"
                    SELECT id FROM kiosk_documents 
                    WHERE document_name = @documentName",
                    new Dictionary<string, object>
                    {
                        { "@documentName", lblDocumentType.Text.Trim() }
                    });

                if (docDt.Rows.Count == 0)
                {
                    MessageBox.Show("Document type not found.", "Error");
                    return;
                }

                int documentId = Convert.ToInt32(docDt.Rows[0]["id"]);

                db.ExecuteNonQuery(@"
                    INSERT INTO Request 
                    (request_number, student_number, document_id, inquiry_id, name, inquiry_type, status, or_number, pickup_deadline, created_at)
                    VALUES 
                    (@requestNumber, @studentNumber, @documentId, NULL, @name, @inquiryType, 'Pending', NULL, NULL, NOW())",
                    new Dictionary<string, object>
                    {
                        { "@requestNumber", requestNumber },
                        { "@studentNumber", _studentNumber },
                        { "@documentId",    documentId },
                        { "@name",          lblName.Text.Trim() },
                        { "@inquiryType",   lblDocumentType.Text.Trim() }
                    });

                DeleteFromQueue();

                MessageBox.Show(
                    "Request " + requestNumber + " created successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CloseAndRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating request:\n" + ex.Message, "Error");
            }
        }

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to dismiss this inquiry?",
                "Confirm Dismiss",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            try
            {
                DeleteFromQueue();
                MessageBox.Show("Inquiry dismissed successfully.", "Success");
                CloseAndRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dismissing inquiry:\n" + ex.Message, "Error");
            }
        }

        private void btnAccomplish_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to mark this as accomplished?",
                "Confirm Accomplish",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            try
            {
                DeleteFromQueue();
                MessageBox.Show("Inquiry marked as accomplished.", "Success");
                CloseAndRefresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accomplishing inquiry:\n" + ex.Message, "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveRequirements_Click_1(object sender, EventArgs e)
        {
            SaveRequirements();
            LoadRequirements();
        }
    }
}