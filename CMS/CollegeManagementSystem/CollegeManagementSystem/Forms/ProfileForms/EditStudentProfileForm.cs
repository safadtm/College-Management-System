using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.Dashboard;
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
    public partial class EditStudentProfileForm : Form
    {
        public string Username { get; set; }
        StudentController studentController;
        public EditStudentProfileForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student updatedStudent = new Student
            {
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                DOB = dateTimePickerDOB.Value.ToString("yyyy-MM-dd"),
                Gender = radioButtonMale.Checked ? "Male" : "Female",
                Address = txtAddress.Text,
                Joined = dateTimePickerJoined.Value.ToString("yyyy-MM-dd"),
                Username = Username
            };

            studentController = new StudentController();
            bool isUpdated = studentController.UpdateStudentProfile(updatedStudent);

            if (isUpdated)
            {
                MessageBox.Show("Profile updated successfully.");
                this.Hide();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error updating profile.");
            }
        }

        private void EditStudentProfileForm_Load(object sender, EventArgs e)
        {
            studentController = new StudentController();
            Student student = studentController.GetStudentByUsername(Username);

            if (student != null)
            {
                // Populate the textboxes with fetched values
                txtFullName.Text = student.FullName;
                txtEmail.Text = student.Email;
                txtPhone.Text = student.Phone;
                dateTimePickerDOB.Value = Convert.ToDateTime(student.DOB);
                txtAddress.Text = student.Address;

                if (student.Gender == "Male")
                {
                    radioButtonMale.Checked = true;
                }
                else
                {
                    radioButtonFemale.Checked = true;
                }
                dateTimePickerJoined.Value = Convert.ToDateTime(student.Joined);
            }
            else
            {
                MessageBox.Show("Error fetching profile details.");
            }
        }
    }
}
