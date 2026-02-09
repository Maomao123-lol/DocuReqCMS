using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuReqCMS
{
    internal class KIOSKSettingsManager
    {
    }

    public class KioskSettingsManager
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DocuFlowDB"].ConnectionString;

        // Save ad image path to database
        public bool SaveAdImagePath(string imagePath)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if record exists
                    string checkQuery = "SELECT COUNT(*) FROM kiosk_welcomeimg WHERE id = 1";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    string query;
                    if (count > 0)
                    {
                        // Update existing record
                        query = "UPDATE kiosk_welcomeimg SET welcomeAd_name = @name, value = @path WHERE id = 1";
                    }
                    else
                    {
                        // Insert new record
                        query = "INSERT INTO kiosk_welcomeimg (id, welcomeAd_name, value) VALUES (1, @name, @path)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Extract just the filename from the full path
                        string fileName = System.IO.Path.GetFileName(imagePath);

                        cmd.Parameters.AddWithValue("@name", fileName);
                        cmd.Parameters.AddWithValue("@path", imagePath);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving ad image: " + ex.Message);
            }
        }

        // Get ad image path from database
        public string GetAdImagePath()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT value FROM kiosk_welcomeimg WHERE id = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                return ""; // Return empty if error (table might be empty)
            }
        }
    }
}
