using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Model;
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
    public partial class AllDeptForm : Form
    {
        public AllDeptForm()
        {
            InitializeComponent();
        }

        private void AllDeptForm_Load(object sender, EventArgs e)
        {
            DepartmentController departmentController = new DepartmentController();
            departmentController.LoadDepartmentsIntoGridView(dataGridViewDepartments);
        }


        
    }
}
