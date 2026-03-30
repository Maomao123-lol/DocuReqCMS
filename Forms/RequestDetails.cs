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
        private string _serviceType = "";

        public RequestDetails(string studentNumber, string queueNo, Action onClose = null)
        {
            InitializeComponent();
            _studentNumber = studentNumber;
            _queueNo = queueNo;
            _onClose = onClose;
            this.Load += RequestDetails_Load;
          
            // Fire refresh AFTER form is fully closed
            this.FormClosed += (s, e) => _onClose?.Invoke();
        }

        private void CloseAndRefresh()
        {
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
                SELECT qt.type, qt.queue_no, qt.service_type
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
                _serviceType = dt.Rows[0]["service_type"].ToString();
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
                return "REQ-" + (number + 1).ToString("D3");

            return "REQ-001";
        }

        private void DeleteFromQueue()
        {
            string queueNo = lblRequestCode.Text.Trim();

            DataTable dt = db.ExecuteQuery(@"
                SELECT id FROM queue_tickets 
                WHERE queue_no = @queueNo",
                new Dictionary<string, object>
                {
                    { "@queueNo", queueNo }
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

        private void btnProceed_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cblRequirements.Items.Count; i++)
            {
                if (!cblRequirements.GetItemChecked(i))
                {
                    MessageBox.Show(
                        "All requirements must be submitted before proceeding.\n\nMissing: " + cblRequirements.Items[i].ToString(),
                        "Incomplete Requirements",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult confirm = MessageBox.Show(
                "All requirements are complete. Proceed with this request?",
                "Confirm Approval",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            try
            {
                string requestNumber = GenerateRequestNumber();
                string documentType = lblDocumentType.Text.Trim();

                // Map service_type to correct ENUM value
                string mappedServiceType;
                switch (_serviceType.ToLower().Trim())
                {
                    case "request document":
                    case "document request":
                        mappedServiceType = "Document Request";
                        break;
                    case "evaluation":
                        mappedServiceType = "Evaluation";
                        break;
                    case "payment confirmation":
                    case "submit ticket":
                        mappedServiceType = "Payment Confirmation";
                        break;
                    default:
                        mappedServiceType = "Others";
                        break;
                }

                // Get document_id from Document_Requirements
                DataTable docDt = db.ExecuteQuery(@"
                    SELECT DISTINCT document_id 
                    FROM Document_Requirements 
                    WHERE requirement_name = @firstRequirement
                    LIMIT 1",
                    new Dictionary<string, object>
                    {
                        { "@firstRequirement", DocumentRequirements.Requirements[documentType][0] }
                    });

                if (docDt.Rows.Count == 0)
                {
                    MessageBox.Show("Document ID not found.", "Error");
                    return;
                }

                int documentId = Convert.ToInt32(docDt.Rows[0]["document_id"]);
                bool requiresPayment = DocumentRequirements.PaidDocuments.Contains(documentType);
                string status = requiresPayment ? "Waiting for Payment" : "Pending";

                db.ExecuteNonQuery(@"
                    INSERT INTO Request 
                    (request_number, student_number, document_id, name, service_type, document_name, status, or_number, pickup_deadline, created_at)
                    VALUES 
                    (@requestNumber, @studentNumber, @documentId, @name, @serviceType, @documentName, @status, NULL, NULL, NOW())",
                     new Dictionary<string, object>
                     {
                        { "@requestNumber", requestNumber },
                        { "@studentNumber", _studentNumber },
                        { "@documentId",    documentId },
                        { "@name",          lblName.Text.Trim() },
                        { "@serviceType",   mappedServiceType },
                        { "@documentName",  lblDocumentType.Text.Trim() },
                        { "@status",        status }
                     });

                DeleteFromQueue();

                MessageBox.Show(
                    "Request " + requestNumber + " created!\nStatus: " + status,
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