using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DocuReqCMS
{
    public class KioskDocumentManager
    {
        private string connectionString = "Server=localhost;Database=kioskdocuments;Uid=root;Pwd=takoyaki;";

        public bool AddDocument(KioskDocument doc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO kiosk_documents  -- CHANGED FROM 'documents'
                             (document_name, description, price, image_path, is_active, display_order)
                             VALUES (@name, @desc, @price, @image, @active, @order)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", doc.DocumentName);
                        cmd.Parameters.AddWithValue("@desc", doc.Description ?? "");
                        cmd.Parameters.AddWithValue("@price", doc.Price);
                        cmd.Parameters.AddWithValue("@image", doc.ImagePath ?? "");
                        cmd.Parameters.AddWithValue("@active", doc.IsActive);
                        cmd.Parameters.AddWithValue("@order", doc.DisplayOrder);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding document: " + ex.Message);
            }
        }

        public List<KioskDocument> GetAllDocuments()
        {
            List<KioskDocument> documents = new List<KioskDocument>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM kiosk_documents ORDER BY display_order, document_name";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            documents.Add(new KioskDocument
                            {
                                Id = reader.GetInt32("id"),
                                DocumentName = reader.GetString("document_name"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString("description"),
                                Price = reader.GetDecimal("price"),
                                ImagePath = reader.IsDBNull(reader.GetOrdinal("image_path")) ? "" : reader.GetString("image_path"),
                                IsActive = reader.GetBoolean("is_active"),
                                DisplayOrder = reader.GetInt32("display_order"),
                                CreatedDate = reader.GetDateTime("created_date")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving documents: " + ex.Message);
            }
            return documents;
        }

        public List<KioskDocument> GetActiveDocuments()
        {
            List<KioskDocument> documents = new List<KioskDocument>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT * FROM kiosk_documents 
                                     WHERE is_active = 1 
                                     ORDER BY display_order, document_name";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            documents.Add(new KioskDocument
                            {
                                Id = reader.GetInt32("id"),
                                DocumentName = reader.GetString("document_name"),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? "" : reader.GetString("description"),
                                Price = reader.GetDecimal("price"),
                                ImagePath = reader.IsDBNull(reader.GetOrdinal("image_path")) ? "" : reader.GetString("image_path"),
                                IsActive = reader.GetBoolean("is_active"),
                                DisplayOrder = reader.GetInt32("display_order")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving active documents: " + ex.Message);
            }
            return documents;
        }
        public bool UpdateDocument(KioskDocument doc)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE kiosk_documents 
                                    SET document_name = @name, 
                                        description = @desc, 
                                        price = @price, 
                                        image_path = @image, 
                                        is_active = @active, 
                                        display_order = @order 
                                    WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", doc.Id);
                        cmd.Parameters.AddWithValue("@name", doc.DocumentName);
                        cmd.Parameters.AddWithValue("@desc", doc.Description ?? "");
                        cmd.Parameters.AddWithValue("@price", doc.Price);
                        cmd.Parameters.AddWithValue("@image", doc.ImagePath ?? "");
                        cmd.Parameters.AddWithValue("@active", doc.IsActive);
                        cmd.Parameters.AddWithValue("@order", doc.DisplayOrder);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating document: " + ex.Message);
            }
        }
        public bool DeleteDocument(int documentId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM kiosk_documents WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", documentId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting document: " + ex.Message);
            }
        }

        public bool ToggleDocumentStatus(int documentId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE kiosk_documents SET is_active = NOT is_active WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", documentId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error toggling document status: " + ex.Message);
            }
        }
    }
}
