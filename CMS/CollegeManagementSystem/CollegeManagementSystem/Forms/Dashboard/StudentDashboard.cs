using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.AttendanceManagement;
using CollegeManagementSystem.Forms.GradeManagement;
using CollegeManagementSystem.Forms.ProfileForms;
using CollegeManagementSystem.Model;
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

namespace CollegeManagementSystem.Forms.Dashboard
{
    public partial class StudentDashboard : Form
    {
        // Property to store the username
        public string Username { get; set; }
        string attendenceType;
        string examType;
        public int stuID;
        private StudentController studentController;

        public StudentDashboard()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            CustomizeMenuStrip(menuStrip1);
            studentController = new StudentController();
        }

        private void CustomizeMenuStrip(MenuStrip menuStrip)
        {
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomMenuStripColorTable());
            menuStrip.BackColor = AppColors.PrimaryColor;  // MenuStrip background
            menuStrip.ForeColor = AppColors.NeutralColor;  // MenuStrip text color
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            Student student = studentController.GetStudentByUsername(Username);
            stuID = student.StudentID;

            if (!string.IsNullOrEmpty(Username))
            {

                label1.Text = $"Welcome, {student.FullName}";
            }
            label2.Text = "Grades Overview : 54%";
            label3.Text = "Total Attendence : 90%";
            label4.Text = "Upcoming Classes : 6";
            label5.Text = "Course Progress : 10%";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StudentProfileForm studentProfileForm = new StudentProfileForm())
            {
                studentProfileForm.Username = this.Username;
                studentProfileForm.ShowDialog();
            }
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditStudentProfileForm editStudentProfileForm = new EditStudentProfileForm
            {
                Username = Username
            })
            {
                if (editStudentProfileForm.ShowDialog() == DialogResult.OK)
                {
                    StudentController studentController = new StudentController();
                    var updatedStudent = studentController.GetStudentByUsername(Username);
                }
            }
        }

        private void viewAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // daily attendence page
            using (StudentAttendenceView studentAttendenceView = new StudentAttendenceView()
            {
                StuID = stuID
            })
            {
                studentAttendenceView.ShowDialog();
            }

        }

        private void mainExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StudentScoreView studentScoreView = new()
            {
                StuID = stuID,
                Username = Username
            })
            {
                studentScoreView.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
