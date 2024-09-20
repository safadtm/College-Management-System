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

namespace CollegeManagementSystem.Forms.UserManagement.Student
{
    public partial class AddStudentForm : Form
    {
        public int DeptID { get; set; }
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // generate username and password button
            var (username, password) = CredentialGenerator.GenerateCredentials("STU");
            txtUsername.Text = username;
            txtPassword.Text = password;

            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get data from form inputs
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            DateTime dob = dateTimePickerDOB.Value;
            string formattedDOBDate = dob.ToString("yyyy-MM-dd");
            string gender = radioButtonMale.Checked ? "Male" : "Female";
            string address = txtAddress.Text;
            DateTime joined = dateTimePickerJoined.Value;
            string formattedJoinedDate = joined.ToString("yyyy-MM-dd");
            int deptID = DeptID;
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            // Check if any fields are empty
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address) ||
                deptID == 0 ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields before proceeding.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dob > DateTime.Today)
            {
                MessageBox.Show("Date of birth cannot be a future date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (joined > DateTime.Today)
            {
                MessageBox.Show("Joined date cannot be a future date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // insert student into db 
            // All checks passed, proceed with registration
            StudentController studentController = new StudentController();
            int studentID = studentController.RegisterStudent(fullName, email, phone, formattedDOBDate, gender, address, formattedJoinedDate, deptID, username, password);



            if (studentID > 0)
            {
              
                MessageBox.Show("Student registered successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error registering student.");
            }
        }
    }
}
