using CollegeManagementSystem.Controllers;
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
    public partial class AllStudentsByDepartment : Form
    {
        public int DeptID { get; set; }
        public AllStudentsByDepartment()
        {
            InitializeComponent();
        }

        private void AllStudentsByDepartment_Load(object sender, EventArgs e)
        {
            StudentController studentController = new StudentController();
            studentController.LoadStudentsByDepartmentIntoDataGridView(dataGridViewStudents, DeptID);

        }
    }
}
