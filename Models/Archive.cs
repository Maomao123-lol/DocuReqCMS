using System;
using System.Collections.Generic;
using System.Data;

namespace DocuFlow_Reg.Models
{
    internal class Archive
    {
        public int ArchiveId { get; set; }
        public string RequestNumber { get; set; }
        public string StudentNumber { get; set; }
        public string Name { get; set; }
        public string DocumentName { get; set; }
        public string FinalStatus { get; set; }
        public string OrNumber { get; set; }
        public DateTime ArchivedAt { get; set; }

        public static List<Archive> GetArchives(string searchText)
        {
            DatabaseHelper db = new DatabaseHelper();

            DataTable dt = db.ExecuteQuery(@"
                SELECT
                    a.archive_id,
                    a.request_number,
                    a.student_number,
                    a.name,
                    a.document_name,
                    a.final_status,
                    a.or_number,
                    a.archived_at
                FROM Archive a
                WHERE (
                    a.student_number LIKE @search
                    OR a.name LIKE @search
                    OR a.document_name LIKE @search
                    OR a.final_status LIKE @search
                )
                ORDER BY a.archived_at DESC",
                new Dictionary<string, object>
                {
                    { "@search", "%" + searchText + "%" }
                });

            List<Archive> archives = new List<Archive>();

            foreach (DataRow row in dt.Rows)
            {
                archives.Add(new Archive
                {
                    ArchiveId = Convert.ToInt32(row["archive_id"]),
                    RequestNumber = row["request_number"].ToString(),
                    StudentNumber = row["student_number"].ToString(),
                    Name = row["name"].ToString(),
                    DocumentName = row["document_name"].ToString(),
                    FinalStatus = row["final_status"].ToString(),
                    OrNumber = row["or_number"].ToString(),
                    ArchivedAt = Convert.ToDateTime(row["archived_at"])
                });
            }

            return archives;
        }
    }
}