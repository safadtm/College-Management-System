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

    }
}
