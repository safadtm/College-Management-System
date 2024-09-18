using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.Dashboard;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.UserManagement.Teacher
{
    public partial class AddTeacherForm : Form
    {
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        // load semesters
        private void PopulateSemesters()
        {

            SemesterController semesterController = new SemesterController();
            List<Semester> semesters = semesterController.GetAllSemesters();

            if (semesters.Count > 0)
            {
                if (semesters.Count > 0) sem1.Text = semesters[0].SemesterName;
                if (semesters.Count > 1) sem2.Text = semesters[1].SemesterName;
                if (semesters.Count > 2) sem3.Text = semesters[2].SemesterName;
                if (semesters.Count > 3) sem4.Text = semesters[3].SemesterName;
                if (semesters.Count > 4) sem5.Text = semesters[4].SemesterName;
                if (semesters.Count > 5) sem6.Text = semesters[5].SemesterName;

            }
            else
            {
                MessageBox.Show("No semesters found.");
            }
        }

        // load departments
        private void LoadDepartments()
        {
            try
            {
                DepartmentController departmentController = new DepartmentController();
                List<Department> departments = departmentController.GetAllDepartments();

                if (departments != null && departments.Any())
                {
                    cmbDepartment.DataSource = departments;
                    cmbDepartment.DisplayMember = "DepartmentName";
                    cmbDepartment.ValueMember = "DepartmentID";
                }
                else
                {
                    MessageBox.Show("No departments found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // generate username and password button
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Teacher Added");
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTeacherForm_Load(object sender, EventArgs e)
        {
            PopulateSemesters();
            LoadDepartments();
        }

        private void sem1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
