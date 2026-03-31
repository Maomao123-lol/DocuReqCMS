using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class QueueTickets : BaseTransaction
    {
        public string Id { get; private set; }
        public string QueueNumber { get; private set; }
        public string StudentClassification { get; private set; }
        public string ServiceType { get; private set; }
        public string Type { get; private set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; private set; }
        public string studentNumber { get; private set; }

        public QueueTickets(string studentNumber, string name, int documentId, string inquiryType, string InquiryId, string Status)
            : base(studentNumber, name, documentId, inquiryType)
        {
            InquiryId = Convert.ToString(Math.Abs(new Guid().GetHashCode()) % 90000 + 10000);
            Status = "Pending";
        }

        public static DataTable GetInquiries(string searchText, int pageSize, int offset) // this method is use to display the queue tickets in dvgInquiries while considering the pagination
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.ExecuteQuery(@"
                SELECT 
                    qt.queue_no                 AS 'Queue No',
                    qt.student_number           AS 'Student Number',
                    s.name                      AS 'Student Name',
                    qt.student_classification   AS 'Inquiry Type',
                    qt.type                     AS 'Document Requested',
                    qt.status                   AS 'Status'
                FROM queue_tickets qt
                LEFT JOIN Student s ON s.student_number = qt.student_number
                WHERE qt.status != 'done'
                AND (qt.student_number          LIKE @search
                OR s.name                       LIKE @search
                OR qt.queue_no                  LIKE @search
                OR qt.student_classification    LIKE @search
                OR qt.type                      LIKE @search
                OR qt.status                    LIKE @search)
                ORDER BY qt.created_at ASC
                LIMIT @pageSize OFFSET @offset",
                new Dictionary<string, object>
                {
                    { "@search",   "%" + searchText + "%" },
                    { "@pageSize", pageSize },
                    { "@offset",   offset }
                });
        }

        public static int GetInquiryCount(string searchText)
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.getDashboardCount(@"
                SELECT COUNT(*) 
                FROM queue_tickets qt
                LEFT JOIN Student s ON s.student_number = qt.student_number
                WHERE qt.status != 'done'
                AND (qt.student_number          LIKE '" + "%" + searchText + "%" + @"'
                OR s.name                       LIKE '" + "%" + searchText + "%" + @"'
                OR qt.queue_no                  LIKE '" + "%" + searchText + "%" + @"'
                OR qt.student_classification    LIKE '" + "%" + searchText + "%" + @"'
                OR qt.type                      LIKE '" + "%" + searchText + "%" + @"'
                OR qt.status                    LIKE '" + "%" + searchText + "%" + @"')");
        }

        public static int GetTicketId(string queueNo)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable dt = db.ExecuteQuery(@"
                SELECT id FROM queue_tickets 
                WHERE queue_no = @queueNo",
                new Dictionary<string, object>
                {
                    { "@queueNo", queueNo }
                });

            if (dt.Rows.Count == 0) return -1;
            return Convert.ToInt32(dt.Rows[0]["id"]);
        }
        public static void DeleteTicket(int ticketId)
        {
            DatabaseHelper db = new DatabaseHelper();

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

        public void Approve()
        {
            Status = "Approved";
        }

        public void Reject()
        {
            Status = "Rejected";
        }
    }
}
