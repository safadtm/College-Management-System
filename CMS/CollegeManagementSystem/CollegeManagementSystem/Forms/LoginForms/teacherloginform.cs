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
    public partial class teacherloginform : Form
    {
        public teacherloginform()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            txtPassword.UseSystemPasswordChar = true;
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

            TeacherController teacherController = new TeacherController();
            bool isValid = teacherController.ValidateTeacherLogin(username, password);


            if (isValid)
            {
                this.Hide();
                TeacherDashboard teacherDashboard = new TeacherDashboard
                {
                    Username = username
                };
                teacherDashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
