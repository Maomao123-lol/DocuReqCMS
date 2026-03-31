using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuFlow_Reg.Models
{
    public class QueueList
    {
        public int IDQueueList { get; set; }
        public string QueueNo { get; set; }

        public QueueList(int idQueueList, string queueNumber)
        {
            IDQueueList = idQueueList;
            QueueNo = queueNumber;
        }

        public static DataTable GetNextQueue()
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.ExecuteQuery(@"
                SELECT idQueue_List, QueueNo
                FROM Queue_List
                WHERE Is_Skipped = 0
                ORDER BY QueueNo ASC
                LIMIT 1");
        }

        public static void SkipQueue(string queueNo)
        {
            DatabaseHelper db = new DatabaseHelper();
            db.ExecuteNonQuery(@"
                UPDATE Queue_List 
                SET Is_Skipped = 1
                WHERE QueueNo = @queueNo",
                new Dictionary<string, object>
                {
                    { "@queueNo", queueNo }
                });
        }

        public static void RecallQueue(string queueNo)
        {
            DatabaseHelper db = new DatabaseHelper();
            db.ExecuteNonQuery(@"
                UPDATE Queue_List 
                SET Is_Skipped = 0
                WHERE QueueNo = @queueNo",
                new Dictionary<string, object>
                {
                    { "@queueNo", queueNo }
                });
        }

        public static DataTable GetSkippedQueues()
        {
            DatabaseHelper db = new DatabaseHelper();
            return db.ExecuteQuery(@"
                SELECT 
                    ql.QueueNo      AS 'Queue No',
                    ql.Is_Skipped   AS 'Skipped'
                FROM Queue_List ql
                WHERE ql.Is_Skipped = 1
                ORDER BY ql.QueueNo ASC");
        }

    }
}
