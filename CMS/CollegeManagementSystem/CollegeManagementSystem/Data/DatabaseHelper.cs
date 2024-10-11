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
                using SqlConnection conn = GetConnection();
                using SqlCommand cmd = new SqlCommand(query, conn);
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

        // Method to fetch department name by ID
        public string GetDepartmentNameById(int departmentId)
        {
            string departmentName = string.Empty;
            string query = "SELECT DeptName FROM Department WHERE DepartmentID = @DepartmentID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@DepartmentID", departmentId);
                conn.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    departmentName = result.ToString();
                }
            }

            return departmentName;
        }



        // principal add subject
        // Method to insert a subject
        public bool InsertSubject(string subjectName, int departmentID, int? teacherID)
        {
            string query = "INSERT INTO Subject (SubName, DepartmentID, TeacherID) " +
                           "VALUES (@SubjectName, @DepartmentID, @TeacherID)";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectName", subjectName);
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                       

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
        public bool UpdateSubjectForTeacher(int teacherID, int subjectID)
        {
            string query = "UPDATE Subject SET TeacherID = @TeacherID WHERE SubjectID = @SubjectID";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                        cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                       
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating subject with TeacherID: " + ex.Message);
                return false;
            }
        }

        // fetch subject 

        public List<Subject> GetSubjects()
        {
            string query = @"
        SELECT s.SubjectID, s.SubName, d.DeptName, t.FullName
        FROM Subject s
        LEFT JOIN Department d ON s.DepartmentID = d.DepartmentID
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

        // fetch subjects according to department
        public List<Subject> GetSubjectsByDepartment(int departmentId)
        {
            // Create the base query
            string query = @"
SELECT s.SubjectID, s.SubName, d.DeptName, t.FullName
FROM Subject s
LEFT JOIN Department d ON s.DepartmentID = d.DepartmentID
LEFT JOIN Teacher t ON s.TeacherID = t.TeacherID
WHERE s.DepartmentID = @DepartmentID";


            List<Subject> subjects = new List<Subject>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add DepartmentID parameter
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                   
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

        // fetch subject according to teacher
        public Subject GetSubjectByTeacherUsername(string username)
        {
            // Create the base query
            string query = @"
                SELECT TOP 1 s.SubjectID, s.SubName, d.DeptName, t.FullName
                FROM Subject s
                INNER JOIN Teacher t ON s.TeacherID = t.TeacherID
                INNER JOIN Department d ON s.DepartmentID = d.DepartmentID
                WHERE t.Username = @Username";

            Subject subject = null;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add Username parameter
                    cmd.Parameters.AddWithValue("@Username", username);

                    // Log the final query and parameters (for debugging purposes)
                    Console.WriteLine("Executing SQL Query: " + cmd.CommandText);
                    foreach (SqlParameter param in cmd.Parameters)
                    {
                        Console.WriteLine($"Parameter Name: {param.ParameterName}, Value: {param.Value}");
                    }

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            subject = new Subject
                            {
                                SubjectID = Convert.ToInt32(reader["SubjectID"]),
                                SubjectName = reader["SubName"].ToString(),
                                DepartmentName = reader["DeptName"] != DBNull.Value ? reader["DeptName"].ToString() : "Not assigned",
                                TeacherName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : "Not assigned"
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading subject: " + ex.Message);
            }
            return subject;
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
        SELECT 
            t.TeacherID, 
            t.FullName AS TeacherName,
            d.DeptName AS DepartmentName,
            s.SubName AS Subject
        FROM Teacher t
        LEFT JOIN Department d ON t.DepartmentID = d.DepartmentID
        LEFT JOIN Subject s ON t.TeacherID = s.TeacherID
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
                                Subject = reader["Subject"] != DBNull.Value ? reader["Subject"].ToString() : string.Empty,
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


        // Fetch teacher details by username
        public Teacher GetTeacherByUsername(string username)
        {
            string query = @"SELECT TeacherID, FullName, Email, Phone, DOB, Gender, Address, Joined,DepartmentID
                             FROM Teacher WHERE Username = @Username";

            try
            {
                using (SqlConnection conn = GetConnection()) 
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Teacher teacher = null;

                            if (reader.Read())
                            {
                                
                                teacher = new Teacher
                                {
                                    TeacherID= Convert.ToInt32(reader["TeacherID"]),
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    DOB = reader["DOB"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Joined = reader["Joined"].ToString(),
                                    DepartmentID= Convert.ToInt32(reader["DepartmentID"])
                                };
                            }
                            return teacher;
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // edit teacher profile
        public bool UpdateTeacher(Teacher teacher)
        {
            string query = @"UPDATE Teacher 
                     SET FullName = @FullName, 
                         Email = @Email, 
                         Phone = @Phone, 
                         DOB = @DOB, 
                         Gender = @Gender, 
                         Address = @Address, 
                         Joined = @Joined 
                     WHERE Username = @Username";

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
                        cmd.Parameters.AddWithValue("@Username", teacher.Username);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating teacher: " + ex.Message);

            }
        }

        // delete teacher
        public bool DeleteTeacher(int teacherID)
        {
            string query = @"DELETE FROM Teacher WHERE TeacherID = @TeacherID";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting teacher: " + ex.Message);
            }
        }


        /// STUDENT SECTION 
         // teacher add student
        // Insert a new student
        public bool InsertStudent(Student student)
        {
            string query = @"INSERT INTO Student (FullName, Email, Phone, DOB, Gender, Address, Joined, DepartmentID, Username, Password)
                    
                     VALUES (@FullName, @Email, @Phone, @DOB, @Gender, @Address, @Joined, @DepartmentID, @Username, @Password)";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", student.FullName);
                        cmd.Parameters.AddWithValue("@Email", student.Email);
                        cmd.Parameters.AddWithValue("@Phone", student.Phone);
                        cmd.Parameters.AddWithValue("@DOB", student.DOB);
                        cmd.Parameters.AddWithValue("@Gender", student.Gender);
                        cmd.Parameters.AddWithValue("@Address", student.Address);
                        cmd.Parameters.AddWithValue("@Joined", student.Joined);
                        cmd.Parameters.AddWithValue("@DepartmentID", student.DepartmentID);
                        cmd.Parameters.AddWithValue("@Username", student.Username);
                        cmd.Parameters.AddWithValue("@Password", student.Password);


                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error inserting student: " + ex.Message);
            }
        }

        // Validate students's login credentials
       
        public bool ValidateStudentCredentials(string username, string password)
        {
            string query = @"SELECT COUNT(*) FROM Student WHERE Username = @Username AND Password = @Password";

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

        // fetch student
        // All Students With Details
        public List<StudentDetails> GetStudentsWithDetails()
        {
            string query = @"
        SELECT 
            st.StudentID, 
            st.Username, 
            st.FullName AS StudentName, 
            d.DeptName AS DepartmentName
        FROM Student st
        LEFT JOIN Department d ON st.DepartmentID = d.DepartmentID
        ORDER BY st.StudentID;
        ";

            List<StudentDetails> studentDetails = new List<StudentDetails>();

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
                            studentDetails.Add(new StudentDetails
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                StudentUserID = reader["Username"].ToString(),
                                StudentName = reader["StudentName"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                               
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading students: " + ex.Message);
            }

            return studentDetails;
        }

        // fetch students of the particular department
        public List<StudentDetails> GetStudentsByDepartment(int departmentId)
        {
            string query = @"
        SELECT 
            st.StudentID, 
            st.Username, 
            st.FullName AS StudentName, 
            d.DeptName AS DepartmentName
        FROM Student st
        LEFT JOIN Department d ON st.DepartmentID = d.DepartmentID
        WHERE st.DepartmentID = @DepartmentID
        ORDER BY st.StudentID;
        ";

            List<StudentDetails> studentDetails = new List<StudentDetails>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId); // Pass the department ID
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentDetails.Add(new StudentDetails
                            {
                                StudentID = Convert.ToInt32(reader["StudentID"]),
                                StudentUserID = reader["Username"].ToString(),
                                StudentName = reader["StudentName"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading students: " + ex.Message);
            }

            return studentDetails;
        }


        // Fetch student details by username
        public Student GetStudentByUsername(string username)
        {
            string query = @"SELECT StudentID, FullName, Email, Phone, DOB, Gender, Address, Joined 
                             FROM Student WHERE Username = @Username";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Student student = null;

                            if (reader.Read())
                            {

                                student = new Student
                                {
                                    StudentID = Convert.ToInt32(reader["StudentID"]),
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    DOB = reader["DOB"].ToString(),
                                    Gender = reader["Gender"].ToString(),
                                    Address = reader["Address"].ToString(),
                                    Joined = reader["Joined"].ToString(),
                                };
                            }
                            return student;
                        }
                    }
                }
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // edit student profile
        public bool UpdateStudent(Student student)
        {
            string query = @"UPDATE Student 
                     SET FullName = @FullName, 
                         Email = @Email, 
                         Phone = @Phone, 
                         DOB = @DOB, 
                         Gender = @Gender, 
                         Address = @Address, 
                         Joined = @Joined 
                     WHERE Username = @Username";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", student.FullName);
                        cmd.Parameters.AddWithValue("@Email", student.Email);
                        cmd.Parameters.AddWithValue("@Phone", student.Phone);
                        cmd.Parameters.AddWithValue("@DOB", student.DOB);
                        cmd.Parameters.AddWithValue("@Gender", student.Gender);
                        cmd.Parameters.AddWithValue("@Address", student.Address);
                        cmd.Parameters.AddWithValue("@Joined", student.Joined);
                        cmd.Parameters.AddWithValue("@Username", student.Username);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating student: " + ex.Message);

            }
        }

        // delete student
        public bool DeleteStudent(int studentID)
        {
            string query = @"DELETE FROM Student WHERE StudentID = @StudentID";

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting student: " + ex.Message);
            }
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

        // TEACHER ATTENDENCE SECTION ------------
        // ADD ATTENDENCE
        public bool InsertAttendance(int studentId, int teacherId, string date, string status)
        {
            string query = @"INSERT INTO Attendance (StudentID, TeacherID, Date, Status)
                     VALUES (@StudentID, @TeacherID, @Date, @Status)";

            try
            {
                using (SqlConnection conn = GetConnection())  
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentId);
                        cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@Status", status);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting attendance: " + ex.Message);
            }
        }


        // ALL ATTENDENCE BY DEPARTMENT
        public List<Attendance> GetTodaysAttendanceForTeacher(int teacherId)
        {
            string query = @"
        SELECT S.StudentName, A.Date, A.Status
        FROM Attendance A
        INNER JOIN Student S ON A.StudentID = S.StudentID
        WHERE A.TeacherID = @TeacherID
        AND A.Date = @Today
        ORDER BY A.Date ASC";

            List<Attendance> attendanceList = new List<Attendance>();

            try
            {
                using (SqlConnection conn = GetConnection())  // Assuming GetConnection() is your function for DB connection
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                        cmd.Parameters.AddWithValue("@Today", DateTime.Today);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Attendance attendance = new Attendance
                                {
                                    StudentName = reader["StudentName"].ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Status = reader["Status"].ToString()
                                };
                                attendanceList.Add(attendance);
                            }
                        }
                    }
                }
                return attendanceList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching today's attendance: " + ex.Message);
            }
        }

        // ALL ATTENDENCE BY DATE
        public List<Attendance> GetAttendanceForTeacherByDate(int teacherId, string date)
        {
            string query = @"
        SELECT S.FullName, A.Date, A.Status
        FROM Attendance A
        INNER JOIN Student S ON A.StudentID = S.StudentID
        WHERE A.TeacherID = @TeacherID
        AND A.Date = @Date
        ORDER BY A.Date ASC";

            List<Attendance> attendanceList = new List<Attendance>();

            try
            {
                using (SqlConnection conn = GetConnection()) // Assuming GetConnection() is your function for DB connection
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TeacherID", teacherId);
                        cmd.Parameters.AddWithValue("@Date", date); // Pass the date string

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Attendance attendance = new Attendance
                                {
                                    StudentName = reader["FullName"].ToString(),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Status = reader["Status"].ToString()
                                };
                                attendanceList.Add(attendance);
                            }
                        }
                    }
                }
                return attendanceList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching attendance for the specified date: " + ex.Message);
            }
        }


        // STUDENT ATTENDENCE
        public List<Attendance> GetStudentAttendanceHistory(int studentId)
        {
            string query = @"
        SELECT A.Date, A.Status
        FROM Attendance A
        WHERE A.StudentID = @StudentID
        ORDER BY A.Date ASC";

            List<Attendance> attendanceList = new List<Attendance>();

            try
            {
                using (SqlConnection conn = GetConnection())  // Assuming GetConnection() is your function for DB connection
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentId);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Attendance attendance = new Attendance
                                {
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Status = reader["Status"].ToString()
                                };
                                attendanceList.Add(attendance);
                            }
                        }
                    }
                }
                return attendanceList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student attendance history: " + ex.Message);
            }
        }


        // EXAM MARK ---------------
        // ADD EXAM MARK
        public bool InsertScore(int gradeValue, int examId, int studentId, int subjectId)
        {
            string query = @"INSERT INTO Grades (GradeValue, ExamID, StudentID, SubjectID)
                     VALUES (@GradeValue, @ExamID, @StudentID, @SubjectID)";

            try
            {
                using (SqlConnection conn = GetConnection())  // Assuming GetConnection() is your function for DB connection
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@GradeValue", gradeValue);
                        cmd.Parameters.AddWithValue("@ExamID", examId);
                        cmd.Parameters.AddWithValue("@StudentID", studentId);
                        cmd.Parameters.AddWithValue("@SubjectID", subjectId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;  // Returns true if the insertion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting grade: " + ex.Message);
            }
        }


        // ALL EXAM MARK OF STUDENTS BY SUBJECT
        public List<StudentMarksView> GetStudentMarksBySubjectID(int subjectID)
        {
            string query = @"
        SELECT s.StudentID, s.FullName AS StudentName, g.GradeValue AS MarksObtained
        FROM Student s
        LEFT JOIN Grades g ON s.StudentID = g.StudentID AND g.SubjectID = @SubjectID
        WHERE s.StudentID IN (
            SELECT StudentID FROM Grades WHERE SubjectID = @SubjectID
        )";

            List<StudentMarksView> studentMarksList = new List<StudentMarksView>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SubjectID", subjectID);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentMarksView studentMark = new StudentMarksView
                                {
                                    StudentID = reader.GetInt32(0),
                                    StudentName = reader.GetString(1),
                                    MarksObtained = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)
                                };
                                studentMarksList.Add(studentMark);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student marks: " + ex.Message);
            }

            return studentMarksList;
        }


        // Particular student exam mark
        public List<StudentMarksView> GetStudentMarksByStudentID(int studentID)
        {
            string query = @"
        SELECT g.StudentID, sub.SubjectName, g.GradeValue AS MarksObtained
        FROM Grades g
        JOIN Subject sub ON g.SubjectID = sub.SubjectID
        WHERE g.StudentID = @StudentID";

            List<StudentMarksView> studentMarksList = new List<StudentMarksView>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StudentID", studentID);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentMarksView studentMark = new StudentMarksView
                                {
                                    StudentID = reader.GetInt32(0),
                                    SubjectName = reader.GetString(1), // Get the subject name
                                    MarksObtained = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                                };
                                studentMarksList.Add(studentMark);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching student marks: " + ex.Message);
            }

            return studentMarksList;
        }



    }
}

