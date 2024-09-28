using CollegeManagementSystem.Controllers;
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

namespace CollegeManagementSystem.Forms.ProfileForms
{
    public partial class StudentProfileForm : Form
    {
        public string Username { get; set; }
        private StudentController studentController;
        public StudentProfileForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            studentController = new StudentController();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void RefreshProfileData()
        {
            // Fetch the student's data again
            LoadProfileData();
        }

        public void LoadProfileData()
        {
            // Get student data using the controller
            Student student = studentController.GetStudentByUsername(Username);

            if (student != null)
            {
                // Update the labels with the fetched data
                label1.Text = "Hi, " + student.FullName;
                label2.Text = "Username: " + Username;
                label3.Text = "Full Name: " + student.FullName;
                label4.Text = "Email: " + student.Email;
                label5.Text = "Phone: " + student.Phone;
                label6.Text = "Date of Birth: " + student.DOB;
                label7.Text = "Gender: " + student.Gender;
                label8.Text = "Address: " + student.Address;
                label9.Text = "Joined: " + student.Joined;

            }
            else
            {
                MessageBox.Show("Student details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StudentProfileForm_Load(object sender, EventArgs e)
        {
            RefreshProfileData();
        }
    }
}
