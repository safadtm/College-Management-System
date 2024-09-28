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
    public partial class EditPrincipalProfileForm : Form
    {
        public string Username { get; set; }

        public EditPrincipalProfileForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void EditPrincipalProfileForm_Load(object sender, EventArgs e)
        {
            PrincipalController principalController = new PrincipalController();
            Principal principal = principalController.GetPrincipalByUsername(Username);

            if (principal != null)
            {
                // Populate the textboxes with fetched values
                txtFullName.Text = principal.FullName;
                txtEmail.Text = principal.Email;
                txtPhone.Text = principal.Phone;
                dateTimePickerDOB.Value = Convert.ToDateTime(principal.DOB);
                txtAddress.Text = principal.Address;
                txtExperience.Text = principal.Experience;
                if (principal.Gender == "Male")
                {
                    radioButtonMale.Checked = true;
                }
                else
                {
                    radioButtonFemale.Checked = true;
                }
                dateTimePickerJoined.Value = Convert.ToDateTime(principal.Joined);
            }
            else
            {
                MessageBox.Show("Error fetching profile details.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Principal updatedPrincipal = new Principal
            {
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                DOB = dateTimePickerDOB.Value.ToString("yyyy-MM-dd"),
                Gender = radioButtonMale.Checked ? "Male" : "Female",
                Address = txtAddress.Text,
                Joined = dateTimePickerJoined.Value.ToString("yyyy-MM-dd"),
                Experience = txtExperience.Text,
                Username = Username
            };

            PrincipalController principalController = new PrincipalController();
            bool isUpdated = principalController.UpdatePrincipalProfile(updatedPrincipal);

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
    }
}
