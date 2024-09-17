using CollegeManagementSystem.Forms.DepartmentMangement;
using CollegeManagementSystem.Forms.ProfileForms;
using CollegeManagementSystem.Forms.SubjectManagement;
using CollegeManagementSystem.Forms.UserManagement.Student;
using CollegeManagementSystem.Forms.UserManagement.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CollegeManagementSystem.Forms.Dashboard
{
    public partial class PrincipalDashboard : Form
    {
        // Property to store the username
        public string Username { get; set; }
        public PrincipalDashboard()
        {
            InitializeComponent();
        }

        private void PrincipalDashboard_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Username))
            {

                label1.Text = $"Welcome, {Username}";
            }

            label2.Text = "Total Teachers : 10";
            label3.Text = "Total Students : 9";
            label4.Text = "Total Departments : 6";
            label5.Text = "Total Courses : 10";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrincipalProfileForm principalProfileForm = new PrincipalProfileForm
            {
                Username = Username
            };
            principalProfileForm.Show();
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditPrincipalProfileForm editPrincipalProfileForm = new EditPrincipalProfileForm
            {
                Username = Username
            };
            editPrincipalProfileForm.Show();
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add teacher page
            this.Hide();
            AddTeacherForm addTeacherForm = new AddTeacherForm();
            addTeacherForm.Show();

        }

        private void allTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all teacher page
            AllTeacherForm allTeacherForm = new AllTeacherForm();
            allTeacherForm.Show();
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all students page without any conditions
            AllStudentForm allStudentForm = new AllStudentForm();
            allStudentForm.Show();
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add department
            this.Hide();
            AddDeptForm addDeptForm = new AddDeptForm();
            addDeptForm.Show();
        }

        private void allDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all departments
            AllDeptForm allDeptForm = new AllDeptForm();
            allDeptForm.Show();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add subject
            this.Hide();
            AddSubForm addSubForm   =new AddSubForm();
            addSubForm.Show();
        }

        private void allCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all subjects
            AllSubForm allSubForm = new AllSubForm();   
            allSubForm.Show();
        }
    }
}
