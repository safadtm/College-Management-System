using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class SemesterController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // fetch semester
        // Method to load all departments for dropdown
        public List<Semester> GetAllSemesters()
        {
            return databaseHelper.GetSemesters();
        }
    }
}
