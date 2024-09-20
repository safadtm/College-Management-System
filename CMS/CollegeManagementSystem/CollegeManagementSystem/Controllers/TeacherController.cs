using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class TeacherController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // Teacher Inserting Controller 
        public int RegisterTeacher(string fullName, string email, string phone, string dob, string gender, string address, string joined, int deptID, string username, string password)
        {
            Teacher teacher = new Teacher
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


            return databaseHelper.InsertTeacher(teacher);
        }

        // principal login controller
        public bool ValidateTeacherLogin(string username, string password)
        {
            return databaseHelper.ValidateTeacherCredentials(username, password);
        }

        // Get All Teachers With Details
        public List<TeacherDetails> GetAllTeachersWithDetails()
        {
            return databaseHelper.GetTeachersWithDetails();
        }

        // All teachers into datagrid view
        public void LoadTeachersIntoDataGridView(DataGridView dataGridView)
        {
            List<TeacherDetails> teachers = GetAllTeachersWithDetails();

            if (teachers != null && teachers.Any())
            {
                dataGridView.DataSource = teachers;
                dataGridView.Columns["TeacherID"].HeaderText = "SI.NO";
                dataGridView.Columns["TeacherName"].HeaderText = "Name";
                dataGridView.Columns["DepartmentName"].HeaderText = "Department";
                dataGridView.Columns["Subjects"].HeaderText = "Subjects";
                dataGridView.Columns["Semesters"].HeaderText = "Semesters";
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
                MessageBox.Show("No teachers found.");
            }
        }

        // teacher profile fetching

        public Teacher GetTeacherByUsername(string username)
        {
            return databaseHelper.GetTeacherByUsername(username);
        }

        // edit teacher profile
        public bool UpdateTeacherProfile(Teacher teacher)
        {
            return databaseHelper.UpdateTeacher(teacher);
        }

    }
}
