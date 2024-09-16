using CollegeManagementSystem.Model;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CollegeManagementSystem.Data
{
    public class DatabaseHelper
    {
        // Centralized connection string (kept private)
        private string connectionString = ConfigurationManager.ConnectionStrings["CollegeManagementSystemDB"].ConnectionString;

        // Method to get a new SQL connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Insert a new principal
        public bool InsertPrincipal(Principal principal)
        {
            string query = @"INSERT INTO Principal (FullName, Email, Phone, DOB, Gender, Address, Joined, Experience, Username, Password)
                             VALUES (@FullName, @Email, @Phone, @DOB, @Gender, @Address, @Joined, @Experience, @Username, @Password)";

            try
            {
                using (SqlConnection conn = GetConnection()) // Reuse GetConnection method
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", principal.FullName);
                        cmd.Parameters.AddWithValue("@Email", principal.Email);
                        cmd.Parameters.AddWithValue("@Phone", principal.Phone);
                        cmd.Parameters.AddWithValue("@DOB", principal.DOB);
                        cmd.Parameters.AddWithValue("@Gender", principal.Gender);
                        cmd.Parameters.AddWithValue("@Address", principal.Address);
                        cmd.Parameters.AddWithValue("@Joined", principal.Joined);
                        cmd.Parameters.AddWithValue("@Experience", principal.Experience);
                        cmd.Parameters.AddWithValue("@Username", principal.Username);
                        cmd.Parameters.AddWithValue("@Password", principal.Password);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0; // Return true if a row was inserted
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (optional: log it)
                throw new Exception("Error inserting principal: " + ex.Message);
            }
        }

        // Validate principal's login credentials
        public bool ValidatePrincipalCredentials(string username, string password)
        {
            string query = @"SELECT COUNT(*) FROM Principal WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection conn = GetConnection()) // Reuse GetConnection method
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password); // Note: Always hash passwords in production

                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();

                        return count > 0; // Return true if a matching record was found
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (optional: log it)
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Fetch principal details by username
        public Principal GetPrincipalByUsername(string username)
        {
            string query = @"SELECT FullName, Email, Phone, DOB, Gender, Address, Joined, Experience 
                             FROM Principal WHERE Username = @Username";

            try
            {
                using (SqlConnection conn = GetConnection()) // Reuse GetConnection method
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Principal principal = null;

                            if (reader.Read())
                            {
                                // Map data from reader to Principal object
                                principal = new Principal
                                {
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    DOB = reader["DOB"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Joined = reader["Joined"].ToString(),
                                    Experience = reader["Experience"].ToString()
                                };
                            }
                            return principal;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (optional: log it)
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
