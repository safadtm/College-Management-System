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

namespace CollegeManagementSystem.Forms.SubjectManagement
{
    public partial class AddSubForm : Form
    {
        public AddSubForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        // load departments
        private void LoadDepartments()
        {
            try
            {
                DepartmentController departmentController = new DepartmentController();
                List<Department> departments = departmentController.GetAllDepartments();

                if (departments != null && departments.Any())
                {
                    cmbDepartment.DataSource = departments;
                    cmbDepartment.DisplayMember = "DepartmentName";
                    cmbDepartment.ValueMember = "DepartmentID";
                }
                else
                {
                    MessageBox.Show("No departments found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            // add new subject
            string subjectName = txtSubjectName.Text;
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue); 
            
            if (!string.IsNullOrWhiteSpace(subjectName) && departmentID > 0 )
            {
                SubjectController subjectController = new SubjectController();
                bool isSuccess = subjectController.AddSubject(subjectName, departmentID);

                if (isSuccess)
                {
                    MessageBox.Show("Subject added successfully.");
                    this.DialogResult = DialogResult.OK; // Close the form with OK result
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding subject.");
                }
            }
            else
            {
                MessageBox.Show("Please fill all the required fields.");
            }

        }

        private void AddSubForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
           
        }
    }
}
