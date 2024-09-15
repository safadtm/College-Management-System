using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Data
{
    public class DatabaseHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CollegeManagementSystemDB"].ConnectionString;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // principal insertion
        public bool InsertPrincipal(Principal principal)
        {
            string query = "INSERT INTO Principal (FullName, Email, Phone, DOB, Gender, Address, Joined, Experience, Username, Password) " +
                           "VALUES (@FullName, @Email, @Phone, @DOB, @Gender, @Address, @Joined, @Experience, @Username, @Password)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
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

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error inserting principal: " + ex.Message);
            }
        }

        // principal login
        // Method to validate user credentials
        public bool ValidatePrincipalCredentials(string username, string password)
        {
            bool isValid = false;

            string query = "SELECT COUNT(*) FROM Principal WHERE Username = @Username AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password); // Note: In a real application, you should hash passwords

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    isValid = count > 0;
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    Console.WriteLine(ex.Message);
                }
            }

            return isValid;
        }
    }
}
