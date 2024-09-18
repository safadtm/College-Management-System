using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.DepartmentMangement
{
    public partial class AddDeptForm : Form
    {
        public AddDeptForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string departmentName = txtDepartmentName.Text;

            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                DepartmentController departmentController = new DepartmentController();
                bool isSuccess = departmentController.AddDepartment(departmentName);

                if (isSuccess)
                {
                    MessageBox.Show("Department added successfully.");
                    this.DialogResult = DialogResult.OK; // Close the form with OK result
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error adding department.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a department name.");
            }


        }
    }
}
