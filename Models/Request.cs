using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    internal class Request:BaseTransaction
    {
        public string RequestNumber { get; private set; }
        public string Status { get; private set; }
        public string ORNumber { get; private set; }
        public DateTime? PickupDeadline{get; private set;}        

        public Request(string studentNumber, string name, int documentId, string inquiryType, string requestNumber, string status, string orNumber, DateTime? pickupDeadline)
            : base(studentNumber, name, documentId, inquiryType)
        {
            RequestNumber = requestNumber;
            Status = status;
            ORNumber = orNumber;
            PickupDeadline = pickupDeadline;
        }

        public static int GetCountByStatus(string status) //get count by status of the request for dashboard
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.getDashboardCount(
                "SELECT COUNT(*) FROM Request WHERE status = '" + status + "'");
        }

        public static DataTable GetDocumentTypeDistribution() // get document type distribution for dashboard
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.ExecuteQuery(@"
                SELECT 
                    r.document_name     AS document_name,
                    COUNT(*)            AS request_count
                FROM Request r
                WHERE r.document_name IS NOT NULL
                AND r.document_name != ''
                GROUP BY r.document_name
                ORDER BY request_count DESC");
        }

        public static DataTable GetRequestTrend(string filter) //use for filling up the data in request trend chart in dashboard
        {
            DatabaseHelper db = new DatabaseHelper();
            string query = "";

            switch (filter)
            {
                case "Daily":
                    query = @"
                        SELECT CONCAT(HOUR(MIN(created_at)), ':00') as period, 
                               COUNT(*) as request_count
                        FROM Request
                        WHERE DATE(created_at) = CURDATE()
                        GROUP BY HOUR(created_at)
                        ORDER BY HOUR(created_at)";
                    break;

                case "Weekly":
                    query = @"
                        SELECT DAYNAME(MIN(created_at)) as period, 
                               COUNT(*) as request_count
                        FROM Request
                        WHERE WEEK(created_at) = WEEK(CURDATE())
                        AND YEAR(created_at) = YEAR(CURDATE())
                        GROUP BY DAYOFWEEK(created_at)
                        ORDER BY DAYOFWEEK(created_at)";
                    break;

                case "Monthly":
                    query = @"
                        SELECT DAY(created_at) as period, 
                               COUNT(*) as request_count
                        FROM Request
                        WHERE MONTH(created_at) = MONTH(CURDATE())
                        AND YEAR(created_at) = YEAR(CURDATE())
                        GROUP BY DAY(created_at)
                        ORDER BY DAY(created_at)";
                    break;

                case "Yearly":
                    query = @"
                        SELECT MONTHNAME(MIN(created_at)) as period, 
                               COUNT(*) as request_count
                        FROM Request
                        WHERE YEAR(created_at) = YEAR(CURDATE())
                        GROUP BY MONTH(created_at)
                        ORDER BY MONTH(created_at)";
                    break;

                default:
                    return new DataTable();
            }

            return db.ExecuteQuery(query);
        }

        public static DataTable GetActiveRequests(string searchText) // get active requests to be displayed in dgvRequest in DocuementRequestForm
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.ExecuteQuery(@"
                SELECT
                    r.request_number    AS 'Request Number',
                    r.student_number    AS 'Student Number',
                    r.name              AS 'Name',
                    r.document_name     AS 'Document Type',
                    r.status            AS 'Status'
                FROM Request r
                WHERE r.status NOT IN ('Pending', 'Released')
                AND (
                    r.request_number    LIKE @search
                    OR r.student_number LIKE @search
                    OR r.name           LIKE @search
                    OR r.document_name  LIKE @search
                    OR r.status         LIKE @search
                )
                ORDER BY r.created_at ASC",
                new Dictionary<string, object>
                {
                    { "@search", "%" + searchText + "%" }
                });
        }

        public static void UpdateStatus(string requestNumber, string status) // use to update status of the request mama
        {
            DatabaseHelper db = new DatabaseHelper();
            db.ExecuteNonQuery(@"
                UPDATE Request 
                SET status = @status
                WHERE request_number = @requestNumber",
                new Dictionary<string, object>
                {
                    { "@status",        status },
                    { "@requestNumber", requestNumber }
                });
        }

        public static void UpdatePayment(string requestNumber, string orNumber) // use to update payment status 
        {
            DatabaseHelper db = new DatabaseHelper();
            db.ExecuteNonQuery(@"
                UPDATE Request 
                SET or_number = @orNumber,
                    status = 'Processing'
                WHERE request_number = @requestNumber",
                new Dictionary<string, object>
                {
                    { "@orNumber",       orNumber },
                    { "@requestNumber",  requestNumber }
                });
        }

        public static string GenerateRequestNumber()
        {
            DatabaseHelper db = new DatabaseHelper();
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

    }
}

