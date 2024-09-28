using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class StudentController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // Student Inserting Controller 
        public bool RegisterStudent(string fullName, string email, string phone, string dob, string gender, string address, string joined, int deptID, string username, string password)
        {
            Student student = new Student
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                DOB = dob,
                Gender = gender,
                Address = address,
                Joined = joined,
                DepartmentID = deptID,
                Username = username,
                Password = password
            };


            return databaseHelper.InsertStudent(student);
        }

        // student login controller
        public bool ValidateStudentLogin(string username, string password)
        {
            return databaseHelper.ValidateStudentCredentials(username, password);
        }

        // Get All Students With Details
        public List<StudentDetails> GetAllStudentsWithDetails()
        {
            return databaseHelper.GetStudentsWithDetails();
        }
        
        public List<StudentDetails> GetDepartmentWiseStudentsWithDetails(int departmentId)
        {
            return databaseHelper.GetStudentsByDepartment(departmentId);
        }


        // All teachers into datagrid view
        public void LoadStudentsIntoDataGridView(DataGridView dataGridView)
        {
            List<StudentDetails> students = GetAllStudentsWithDetails();

            if (students != null && students.Any())
            {
                dataGridView.DataSource = students;
                dataGridView.Columns["StudentID"].HeaderText = "SI.NO";
                dataGridView.Columns["StudentUserID"].HeaderText = "Admission ID";
                dataGridView.Columns["StudentName"].HeaderText = "Name";
                dataGridView.Columns["DepartmentName"].HeaderText = "Department";
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                int totalColumnWidth = dataGridView.Columns.Cast<DataGridViewColumn>().Sum(col => col.Width);
                dataGridView.Width = totalColumnWidth + dataGridView.Padding.Left + dataGridView.Padding.Right;

                int totalHeight = dataGridView.ColumnHeadersHeight;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    totalHeight += row.Height;
                }
                dataGridView.Height = totalHeight + dataGridView.Rows.Count;
                dataGridView.ScrollBars = ScrollBars.None;
            }
            else
            {
                MessageBox.Show("No students found.");
            }
        }

        // department wise students into data grid view
        // All teachers into datagrid view
        public void LoadStudentsByDepartmentIntoDataGridView(DataGridView dataGridView,int departmentID)
        {
            List<StudentDetails> students = GetDepartmentWiseStudentsWithDetails(departmentID);

            if (students != null && students.Any())
            {
                dataGridView.DataSource = students;
                dataGridView.Columns["StudentID"].HeaderText = "SI.NO";
                dataGridView.Columns["StudentUserID"].HeaderText = "Admission ID";
                dataGridView.Columns["StudentName"].HeaderText = "Name";
                dataGridView.Columns["DepartmentName"].HeaderText = "Department";
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                int totalColumnWidth = dataGridView.Columns.Cast<DataGridViewColumn>().Sum(col => col.Width);
                dataGridView.Width = totalColumnWidth + dataGridView.Padding.Left + dataGridView.Padding.Right;

                int totalHeight = dataGridView.ColumnHeadersHeight;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    totalHeight += row.Height;
                }
                dataGridView.Height = totalHeight + dataGridView.Rows.Count;
                dataGridView.ScrollBars = ScrollBars.None;
            }
            else
            {
                MessageBox.Show("No students found.");
            }
        }

        // student profile fetching

        public Student GetStudentByUsername(string username)
        {
            return databaseHelper.GetStudentByUsername(username);
        }

        // edit student profile
        public bool UpdateStudentProfile(Student student)
        {
            return databaseHelper.UpdateStudent(student);
        }

        // delete teacher
        public bool DeleteStudent(int studentID)
        {
            return databaseHelper.DeleteStudent(studentID);
        }
    }
}
