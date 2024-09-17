using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class DepartmentController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // add department
        public bool AddDepartment(string departmentName)
        {
            return databaseHelper.InsertDepartment(departmentName);
        }

        // fetch departments
        // Method to load all departments for dropdown
        public List<Department> GetAllDepartments()
        {
            return databaseHelper.GetDepartments();
        }

        // department listing for data grid view
        public void LoadDepartmentsIntoGridView(DataGridView dataGridView)
        {
            List<Department> departments = GetAllDepartments(); 

            if (departments != null && departments.Any())
            {
                dataGridView.DataSource = departments;
                dataGridView.Columns["DepartmentID"].HeaderText = "SI.NO";
                dataGridView.Columns["DepartmentName"].HeaderText = "Department Name";
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                
                int totalHeight = dataGridView.ColumnHeadersHeight;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    totalHeight += row.Height;
                }
                dataGridView.Height = totalHeight + dataGridView.Rows.Count;
                dataGridView.ScrollBars = ScrollBars.None;
            }
            else
            {
                MessageBox.Show("No departments found.");
            }
        }


    }
}
