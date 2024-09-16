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

namespace CollegeManagementSystem.Forms.SubjectManagement
{
    public partial class AddSubForm : Form
    {
        public AddSubForm()
        {
            InitializeComponent();
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

        // load semesters
        private void LoadSemesters()
        {
            try
            {
                SemesterController semesterController = new SemesterController();
                List<Semester> semesters = semesterController.GetAllSemesters();

                if (semesters != null && semesters.Any())
                {
                    cmbSemester.DataSource = semesters;
                    cmbSemester.DisplayMember = "SemesterName";
                    cmbSemester.ValueMember = "SemesterID";
                }
                else
                {
                    MessageBox.Show("No semesters found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading semesters: {ex.Message}");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            // add new subject
            string subjectName = txtSubjectName.Text;
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue); // Assuming departments are loaded in combobox
            int semesterID = Convert.ToInt32(cmbSemester.SelectedValue); // Assuming semesters are loaded in combobox

            if (!string.IsNullOrWhiteSpace(subjectName) && departmentID > 0 && semesterID > 0)
            {
                SubjectController subjectController = new SubjectController();
                bool isSuccess = subjectController.AddSubject(subjectName, departmentID, semesterID);

                if (isSuccess)
                {
                    MessageBox.Show("Subject added successfully.");
                    this.Hide();
                    PrincipalDashboard principalDashboard = new PrincipalDashboard();
                    principalDashboard.Show();
                }
                else
                {
                    MessageBox.Show("Error adding subject.");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the required fields.");
            }

        }

        private void AddSubForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadSemesters();
        }
    }
}
