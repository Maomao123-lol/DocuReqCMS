
using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace YourApp.DataAccess
{
    public class DatabaseConnection  // Moved class declaration to top
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;  // Changed to "MyDb"

        // Method to get a new connection
        public static MySqlConnection GetConnection()  // Changed to MySqlConnection
        {
            return new MySqlConnection(connectionString);
        }

        // Test connection method
        public static bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())  // Changed to MySqlConnection
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
                return false;
            }
        }
    }
}