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
    public partial class TeacherDashboard : Form
    {
        // Property to store the username
        public string Username { get; set; }

        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeacherDashboard_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {

                label1.Text = $"Welcome, {Username}";
            }
            label2.Text = "Total Students : 10";
            label3.Text = "Upcoming Classes : 9";
            label4.Text = "Pending Grading : 6";
            label5.Text = "Attendance Status : 10";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherProfileForm teacherProfileForm = new TeacherProfileForm();   
            teacherProfileForm.Show();
        }
    }
}
