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
    public partial class EditTeacherProfileForm : Form
    {
        public string Username { get; set; }

        public EditTeacherProfileForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher updatedTeacher = new Teacher
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

            TeacherController teacherController = new TeacherController();
            bool isUpdated = teacherController.UpdateTeacherProfile(updatedTeacher);

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

        private void EditTeacherProfileForm_Load(object sender, EventArgs e)
        {
            TeacherController teacherController = new TeacherController();
            Teacher teacher = teacherController.GetTeacherByUsername(Username);

            if (teacher != null)
            {
                // Populate the textboxes with fetched values
                txtFullName.Text = teacher.FullName;
                txtEmail.Text = teacher.Email;
                txtPhone.Text = teacher.Phone;
                dateTimePickerDOB.Value = Convert.ToDateTime(teacher.DOB);
                txtAddress.Text = teacher.Address;

                if (teacher.Gender == "Male")
                {
                    radioButtonMale.Checked = true;
                }
                else
                {
                    radioButtonFemale.Checked = true;
                }
                dateTimePickerJoined.Value = Convert.ToDateTime(teacher.Joined);
            }
            else
            {
                MessageBox.Show("Error fetching profile details.");
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
