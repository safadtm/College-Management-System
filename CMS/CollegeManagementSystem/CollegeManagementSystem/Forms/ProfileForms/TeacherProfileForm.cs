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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CollegeManagementSystem.Forms.ProfileForms
{
    public partial class TeacherProfileForm : Form
    {
        // Property to store the username
        public string Username { get; set; }
        private TeacherController teacherController;

        public TeacherProfileForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            teacherController = new TeacherController();
        }

        public void RefreshProfileData()
        {
            // Fetch the teachers's data again
            LoadProfileData();
        }

        public void LoadProfileData()
        {
            // Get teacher data using the controller
            Teacher teacher = teacherController.GetTeacherByUsername(Username);

            if (teacher != null)
            {
                // Update the labels with the fetched data
                label1.Text = "Hi, " + teacher.FullName;
                label2.Text = "Username: " + Username;
                label3.Text = "Full Name: " + teacher.FullName;
                label4.Text = "Email: " + teacher.Email;
                label5.Text = "Phone: " + teacher.Phone;
                label6.Text = "Date of Birth: " + teacher.DOB;
                label7.Text = "Gender: " + teacher.Gender;
                label8.Text = "Address: " + teacher.Address;
                label9.Text = "Joined: " + teacher.Joined;

            }
            else
            {
                MessageBox.Show("Teacher details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeacherProfileForm_Load(object sender, EventArgs e)
        {
            RefreshProfileData();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close this window?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
