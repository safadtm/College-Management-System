using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.Dashboard;
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

namespace CollegeManagementSystem.Forms.LoginForms
{
    public partial class studentloginform : Form
    {
        public studentloginform()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false; // Shows password
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; // Hides password
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // forget password page
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            StudentController studentController = new StudentController();
            bool isValid = studentController.ValidateStudentLogin(username, password);


            if (isValid)
            {
                this.Hide();
                StudentDashboard studentDashboard = new StudentDashboard
                {
                    Username = username
                };
                studentDashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
