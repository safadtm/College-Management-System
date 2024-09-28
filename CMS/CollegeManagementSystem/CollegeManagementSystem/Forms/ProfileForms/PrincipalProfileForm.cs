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
    public partial class PrincipalProfileForm : Form
    {
        // Property to store the username
        public string Username { get; set; }
        private PrincipalController principalController;


        public PrincipalProfileForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            principalController = new PrincipalController();
        }
        public void RefreshProfileData()
        {
            // Fetch the principal's data again
            LoadProfileData();
        }
        public void LoadProfileData() {
            // Get principal data using the controller
            Principal principal = principalController.GetPrincipalByUsername(Username);

            if (principal != null)
            {
                // Update the labels with the fetched data
                label1.Text = "Hi, " + principal.FullName;
                label2.Text = "Username: " + Username;
                label3.Text = "Full Name: " + principal.FullName;
                label4.Text = "Email: " + principal.Email;
                label5.Text = "Phone: " + principal.Phone;
                label6.Text = "Date of Birth: " + principal.DOB;
                label7.Text = "Gender: " + principal.Gender;
                label8.Text = "Address: " + principal.Address;
                label9.Text = "Joined: " + principal.Joined;
                label10.Text = "Experience: " + principal.Experience;
            }
            else
            {
                MessageBox.Show("Principal details not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PrincipalProfileForm_Load(object sender, EventArgs e)
        {
            RefreshProfileData();
         
        }
    }
}
