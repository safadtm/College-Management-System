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
                using (SqlConnection conn = GetConnection())
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

        // edit principal profile
        public bool UpdatePrincipal(Principal principal)
        {
            string query = @"UPDATE Principal 
                     SET FullName = @FullName, 
                         Email = @Email, 
                         Phone = @Phone, 
                         DOB = @DOB, 
                         Gender = @Gender, 
                         Address = @Address, 
                         Joined = @Joined, 
                         Experience = @Experience
                     WHERE Username = @Username";

            try
            {
                using (SqlConnection conn = GetConnection())
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

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating principal: " + ex.Message);

            }



        }


        // principal add department
        // Method to insert a department
        public bool InsertDepartment(string departmentName)
        {
            string query = "INSERT INTO Department (DeptName) VALUES (@DepartmentName)";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", departmentName);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting department: " + ex.Message);
                return false;
            }
        }


        // fetch department
        // Load departments from the database
        public List<Department> GetDepartments()
        {
            string query = "SELECT DepartmentID, DeptName FROM Department";
            List<Department> departments = new List<Department>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                DepartmentName = reader["DeptName"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading departments: " + ex.Message);
            }

            return departments;
        }

        // fetch semester
        // Load semesters from the database
        public List<Semester> GetSemesters()
        {
            string query = "SELECT SemesterID,SemName,StartDate,EndDate FROM Semester";
            List<Semester> semesters = new List<Semester>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            semesters.Add(new Semester
                            {
                                SemesterID = Convert.ToInt32(reader["SemesterID"]),
                                SemesterName = reader["SemName"].ToString(),
                                StartDate = reader["StartDate"].ToString(),
                                EndDate = reader["EndDate"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading semesters: " + ex.Message);
            }

            return semesters;
        }


        // principal add subject
        // Method to insert a subject
        public bool InsertSubject(string subjectName, int departmentID, int semesterID, int? teacherID)
        {
            string query = "INSERT INTO Subject (SubName, DepartmentID, SemesterID, TeacherID) " +
                           "VALUES (@SubjectName, @DepartmentID, @SemesterID, @TeacherID)";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectName", subjectName);
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                        cmd.Parameters.AddWithValue("@SemesterID", semesterID);

                        // If teacherID is null, we handle it like this:
                        if (teacherID.HasValue)
                            cmd.Parameters.AddWithValue("@TeacherID", teacherID.Value);
                        else
                            cmd.Parameters.AddWithValue("@TeacherID", DBNull.Value);  // Set NULL for TeacherID

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting subject: " + ex.Message);
                return false;
            }
        }

        // update subject table for teacherID s
        public bool UpdateSubjectsForTeacher(int teacherID, List<int> subjectIDs)
        {
            // Construct the query for updating subjects
            string query = "UPDATE Subject SET TeacherID = @TeacherID WHERE SubjectID = @SubjectID";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // Iterate over the list of subject IDs and update the TeacherID for each
                    foreach (var subjectID in subjectIDs)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                            cmd.Parameters.AddWithValue("@SubjectID", subjectID);


                            cmd.ExecuteNonQuery();
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating subjects with TeacherID: " + ex.Message);
                return false;
            }
        }

        // fetch subject 

        public List<Subject> GetSubjects()
        {
            string query = @"
        SELECT s.SubjectID, s.SubName, d.DeptName, sem.SemName, t.FullName
        FROM Subject s
        LEFT JOIN Department d ON s.DepartmentID = d.DepartmentID
        LEFT JOIN Semester sem ON s.SemesterID = sem.SemesterID
        LEFT JOIN Teacher t ON s.TeacherID = t.TeacherID";

            List<Subject> subjects = new List<Subject>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubName"].ToString(),
                                DepartmentName = reader["DeptName"].ToString(),
                                SemesterName = reader["SemName"].ToString(),
                                TeacherName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : "Not assigned"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading subjects: " + ex.Message);
            }
            return subjects;
        }



        // fetch subjects according to department and semesters
        public List<Subject> GetSubjectsByDepartmentAndSemesters(int departmentId, List<int> semesterIds)
        {
            // Create the base query
            string query = @"
SELECT s.SubjectID, s.SubName, d.DeptName, sem.SemName, t.FullName
FROM Subject s
LEFT JOIN Department d ON s.DepartmentID = d.DepartmentID
LEFT JOIN Semester sem ON s.SemesterID = sem.SemesterID
LEFT JOIN Teacher t ON s.TeacherID = t.TeacherID
WHERE s.DepartmentID = @DepartmentID";

            // Check if semesterIds is not empty
            if (semesterIds != null && semesterIds.Count > 0)
            {
                query += " AND s.SemesterID IN (" + string.Join(",", semesterIds.Select((id, index) => "@SemesterID" + index)) + ")";
            }

            List<Subject> subjects = new List<Subject>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add DepartmentID parameter
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                    // Add parameters for each semester ID if semesterIds is not empty
                    if (semesterIds != null && semesterIds.Count > 0)
                    {
                        for (int i = 0; i < semesterIds.Count; i++)
                        {
                            cmd.Parameters.AddWithValue("@SemesterID" + i, semesterIds[i]);
                        }
                    }
                    else
                    {
                        // If no semester selected, throw a meaningful message or handle it
                        MessageBox.Show("Please select at least one semester.");
                        return null;
                    }

                    // Log the final query and parameters (for debugging purposes)
                    Console.WriteLine("Executing SQL Query: " + cmd.CommandText);
                    foreach (SqlParameter param in cmd.Parameters)
                    {
                        Console.WriteLine($"Parameter Name: {param.ParameterName}, Value: {param.Value}");
                    }

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubName"].ToString(),
                                DepartmentName = reader["DeptName"].ToString(),
                                SemesterName = reader["SemName"].ToString(),
                                TeacherName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : "Not assigned"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading subjects: " + ex.Message);
            }
            return subjects;
        }

        // principal add teacher
        // Insert a new teacher
        public int InsertTeacher(Teacher teacher)
        {
            string query = @"INSERT INTO Teacher (FullName, Email, Phone, DOB, Gender, Address, Joined, DepartmentID, Username, Password)
                    OUTPUT INSERTED.TeacherID
                     VALUES (@FullName, @Email, @Phone, @DOB, @Gender, @Address, @Joined, @DepartmentID, @Username, @Password)";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", teacher.FullName);
                        cmd.Parameters.AddWithValue("@Email", teacher.Email);
                        cmd.Parameters.AddWithValue("@Phone", teacher.Phone);
                        cmd.Parameters.AddWithValue("@DOB", teacher.DOB);
                        cmd.Parameters.AddWithValue("@Gender", teacher.Gender);
                        cmd.Parameters.AddWithValue("@Address", teacher.Address);
                        cmd.Parameters.AddWithValue("@Joined", teacher.Joined);
                        cmd.Parameters.AddWithValue("@DepartmentID", teacher.DepartmentID);
                        cmd.Parameters.AddWithValue("@Username", teacher.Username);
                        cmd.Parameters.AddWithValue("@Password", teacher.Password);


                        conn.Open();
                        int teacherID = (int)cmd.ExecuteScalar();

                        return teacherID;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error inserting teacher: " + ex.Message);
            }
        }

        // Validate teachers's login credentials
        // Validate principal's login credentials
        public bool ValidateTeacherCredentials(string username, string password)
        {
            string query = @"SELECT COUNT(*) FROM Teacher WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection conn = GetConnection()) 
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password); 

                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();

                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // fetch teacher
        // All Teachers With Details
        public List<TeacherDetails> GetTeachersWithDetails()
        {
            string query = @"
                SELECT DISTINCT
                t.TeacherID, 
                t.FullName AS TeacherName,
                d.DeptName AS DepartmentName,
                STRING_AGG(s.SubName, ', ') AS Subjects,
                STRING_AGG(sem.SemName, ', ') AS Semesters
                FROM Teacher t
                LEFT JOIN Department d ON t.DepartmentID = d.DepartmentID
                LEFT JOIN Subject s ON t.TeacherID = s.TeacherID
                LEFT JOIN Semester sem ON s.SemesterID = sem.SemesterID
                GROUP BY t.TeacherID, t.FullName, d.DeptName
                ORDER BY t.TeacherID;
                ";

            List<TeacherDetails> teacherDetailsList = new List<TeacherDetails>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teacherDetailsList.Add(new TeacherDetails
                            {
                                TeacherID = Convert.ToInt32(reader["TeacherID"]),
                                TeacherName = reader["TeacherName"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                Subjects = reader["Subjects"].ToString(),
                                Semesters = reader["Semesters"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading teachers: " + ex.Message);
            }

            return teacherDetailsList;
        }



        // Fetch the last used number from the database
        public int GetLastUsedNumber(string userType)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT LastUsedNumber FROM LastUsedNumbers WHERE UserType = @UserType";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 1000;  
                }
            }
        }

        // Update the last used number in the database
        public void UpdateLastUsedNumber(string userType, int lastUsedNumber)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE LastUsedNumbers SET LastUsedNumber = @LastUsedNumber WHERE UserType = @UserType";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LastUsedNumber", lastUsedNumber);
                    cmd.Parameters.AddWithValue("@UserType", userType);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

