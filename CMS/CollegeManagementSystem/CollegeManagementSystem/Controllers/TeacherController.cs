using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using CollegeManagementSystem.Utilities;
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

                // Add Delete button column
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                deleteButton.Name = "Delete";
                deleteButton.HeaderText = "Delete";
                deleteButton.Text = "Delete";
                deleteButton.UseColumnTextForButtonValue = true;

                // Set the button style
                deleteButton.FlatStyle = FlatStyle.Flat; // Set the flat style
                deleteButton.DefaultCellStyle.BackColor = AppColors.AbsentColor; // Set background color
                deleteButton.DefaultCellStyle.ForeColor = AppColors.NeutralColor; // Set text color
                deleteButton.DefaultCellStyle.SelectionBackColor = AppColors.AbsentColor; // Set selected background color
                deleteButton.DefaultCellStyle.SelectionForeColor = AppColors.NeutralColor; // Set selected text color
                

                dataGridView.Columns.Add(deleteButton);

                // Center-align the header of the "Delete" column
                dataGridView.Columns["Delete"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


                // Adjust column sizes
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Ensure the last column fills any remaining space
                dataGridView.Columns[dataGridView.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Dynamically adjust the DataGridView size to fit content
               DataGridViewHelper.AdjustDataGridViewSizeToFitColumns(dataGridView);
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

        // delete teacher
        public bool DeleteTeacher(int teacherID)
        {
            return databaseHelper.DeleteTeacher(teacherID);
        }


    }
}
