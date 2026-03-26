using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DocuFlow_Reg
{
    internal class DatabaseHelper
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}