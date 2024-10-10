using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.DepartmentMangement;
using CollegeManagementSystem.Forms.ProfileForms;
using CollegeManagementSystem.Forms.SubjectManagement;
using CollegeManagementSystem.Forms.UserManagement.Student;
using CollegeManagementSystem.Forms.UserManagement.Teacher;
using CollegeManagementSystem.Utilities;
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
            this.BackColor = AppColors.NeutralColor;
            CustomizeMenuStrip(menuStrip1);
        }

        private void CustomizeMenuStrip(MenuStrip menuStrip)
        {
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomMenuStripColorTable());
            menuStrip.BackColor = AppColors.PrimaryColor;  // MenuStrip background
            menuStrip.ForeColor = AppColors.NeutralColor;  // MenuStrip text color
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
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (PrincipalProfileForm principalProfileForm = new PrincipalProfileForm())
            {
                principalProfileForm.Username = this.Username;
                principalProfileForm.ShowDialog();
            }
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditPrincipalProfileForm editPrincipalProfileForm = new EditPrincipalProfileForm
            {
                Username = Username 
            })
            {
                if (editPrincipalProfileForm.ShowDialog() == DialogResult.OK)
                {
                    PrincipalController principalController = new PrincipalController();
                    var updatedPrincipal = principalController.GetPrincipalByUsername(Username);
                }
            }

        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Add teacher page
            using (AddTeacherForm addTeacherForm = new AddTeacherForm())
            {
                addTeacherForm.ShowDialog();
            }

        }

        private void allTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all teacher page
            using (AllTeacherForm allTeacherForm = new AllTeacherForm())
            {
                allTeacherForm.ShowDialog();
            }
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all students page without any conditions
            using (AllStudentForm allStudentForm = new AllStudentForm())
            {
                allStudentForm.ShowDialog();
            }
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add department
            using (AddDeptForm addDeptForm = new AddDeptForm())
            {
                addDeptForm.ShowDialog();
            }
        }

        private void allDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all departments
            using (AllDeptForm allDeptForm = new AllDeptForm())
            {
                allDeptForm.ShowDialog();
            }
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add subject
            using (AddSubForm addSubForm = new AddSubForm())
            {
                addSubForm.ShowDialog();
            }
        }

        private void allCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all subjects
            using (AllSubForm allSubForm = new AllSubForm())
            {
                allSubForm.ShowDialog();
            }
        }
    }
}
