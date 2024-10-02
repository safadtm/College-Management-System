using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using CollegeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Controllers
{
    public class StudentController
    {
        private int deptID;
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
            deptID = departmentId;
            return databaseHelper.GetStudentsByDepartment(departmentId);
        }


        // All students into datagrid view
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
                MessageBox.Show("No students found.");
            }
        }

        // department wise students into data grid view
        
        public async Task LoadStudentsByDepartmentIntoDataGridView(DataGridView dataGridView,int departmentID)
        {
            List<StudentDetails> students = GetDepartmentWiseStudentsWithDetails(departmentID);

            if (students != null && students.Any())
            {
                dataGridView.DataSource = students;
                dataGridView.Columns["StudentID"].HeaderText = "SI.NO";
                dataGridView.Columns["StudentUserID"].HeaderText = "Admission ID";
                dataGridView.Columns["StudentName"].HeaderText = "Name";
                dataGridView.Columns["DepartmentName"].HeaderText = "Department";

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

                // Attach the CellClick event
                dataGridView.CellClick += new DataGridViewCellEventHandler(DataGridView_CellClick);


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
                MessageBox.Show("No students found.");
            }
        }

        private async void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            // Check if the clicked cell is in the Delete button column
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Delete"].Index)
            {
                // Get the StudentID from the corresponding row
                int studentID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["StudentID"].Value);
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Call your Delete function
                    bool success = DeleteStudent(studentID);

                    if (success)
                    {
                        MessageBox.Show("Student deleted successfully.");
                        dataGridView.DataSource = null;

                        // Reload the students for the current department
                        await LoadStudentsByDepartmentIntoDataGridView(dataGridView, deptID);
                    }
                    else
                    {
                        MessageBox.Show("Error deleting student.");
                    }
                }
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

        // delete student
        public bool DeleteStudent(int studentID)
        {
            return databaseHelper.DeleteStudent(studentID);
        }




    }
}
