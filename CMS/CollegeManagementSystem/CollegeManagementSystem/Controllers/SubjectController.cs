using CollegeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class SubjectController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // add subject
        public bool AddSubject(string subjectName, int departmentID, int semesterID, int? teacherID = null)
        {
            return databaseHelper.InsertSubject(subjectName, departmentID, semesterID, teacherID);
        }

        // fetch subjects

    }
}
