using MySql.Data.MySqlClient;
using System;

namespace DocuReqCMS
{
    public static class ActivityLogger
    {
        private static string connStr =
            "server=localhost;database=cms_db;uid=root;pwd=takoyaki;";

        public static void Log(
            int? userId,
            string role,
            string message
        )
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = @"INSERT INTO activity_logs
                                 (user_id, role, activity)
                                 VALUES
                                 (@user_id, @role, @activity)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@activity", message);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
