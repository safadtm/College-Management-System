using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.AttendanceManagement;
using CollegeManagementSystem.Forms.GradeManagement;
using CollegeManagementSystem.Forms.ProfileForms;
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

        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {

                label1.Text = $"Welcome, {Username}";
            }
            label2.Text = "Grades Overview : 54%";
            label3.Text = "Total Attendence : 90%";
            label4.Text = "Upcoming Classes : 6";
            label5.Text = "Course Progress : 10%";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // daily attendence page
            attendenceType = "daily";
            AllAttendenceForm allAttendenceForm = new AllAttendenceForm();
            allAttendenceForm.Show();

        }

        private void weekwiseAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // week wise report
            attendenceType = "week";
            AllAttendenceForm allAttendenceForm = new AllAttendenceForm();
            allAttendenceForm.Show();
        }

        private void coursewiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // course wise report
            attendenceType = "course";
            AllAttendenceForm allAttendenceForm = new AllAttendenceForm();
            allAttendenceForm.Show();
        }

        private void internalExam1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // internal exam 1
            examType = "internal1";
            AllGradesForm allGradesForm = new AllGradesForm();
            allGradesForm.Show();
        }

        private void internalExam2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // internal exam 2
            examType = "internal2";
            AllGradesForm allGradesForm = new AllGradesForm();
            allGradesForm.Show();
        }

        private void modelExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // model exam
            examType = "model";
            AllGradesForm allGradesForm = new AllGradesForm();
            allGradesForm.Show();
        }

        private void mainExamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // main exam
            examType = "main";
            AllGradesForm allGradesForm = new AllGradesForm();
            allGradesForm.Show();
        }
    }
}
