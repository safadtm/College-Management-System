using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.LoginForms
{
    public partial class principalregistrationform : Form
    {
        
        public principalregistrationform()
        {
            InitializeComponent();
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
            string experience = txtExperience.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check if any fields are empty
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(experience) ||
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

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // insert princpal into db 
            // All checks passed, proceed with registration
            PrincipalController principalController = new PrincipalController();
            bool isSuccess = principalController.RegisterPrincipal(fullName, email, phone, formattedDOBDate, gender, address, formattedJoinedDate, experience, username, password);

            if (isSuccess)
            {
                MessageBox.Show("Principal registered successfully!");
                this.Hide();
                principalloginform form2 = new principalloginform();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Error registering principal.");
            }

            
        }

        private void principalregistrationform_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
