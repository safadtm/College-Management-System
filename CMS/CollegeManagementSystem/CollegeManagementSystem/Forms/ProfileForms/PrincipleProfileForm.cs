using CollegeManagementSystem.Forms.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.ProfileForms
{
    public partial class PrincipleProfileForm : Form
    {
        public PrincipleProfileForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PrincipleProfileForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Hi, Full Name";
            label2.Text = "Username : princi";
            label3.Text = "Full Name : hello joker";
            label4.Text = "Email : princi@gmail.com";
            label5.Text = "Phone : 9687451232";
            label6.Text = "Date of birth : 10-45-1994";
            label7.Text = "Gender : Male";
            label8.Text = "Addres : xyz, road ernakulam";
            label9.Text = "Joined : 15-10-2024";
            label10.Text = "Experince : UC College Aluva";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalDashboard principalDashboard = new PrincipalDashboard();
            principalDashboard.Show();
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add teacher page
        }

        private void allTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all teachers page
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add department page
        }

        private void allDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all department page
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add course page
        }

        private void allCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all course page
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // profile page
            this.Hide();
            PrincipleProfileForm   principleProfileForm = new PrincipleProfileForm();   
            principleProfileForm.Show();

        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // edit profile page
        }
    }
}
