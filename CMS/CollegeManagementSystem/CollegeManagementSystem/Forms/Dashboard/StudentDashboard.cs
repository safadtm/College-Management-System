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
            StudentProfileForm studentProfileForm = new StudentProfileForm();
            studentProfileForm.Show();
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            EditStudentProfileForm editStudentProfileForm = new EditStudentProfileForm();
            editStudentProfileForm.Show();
        }
    }
}
