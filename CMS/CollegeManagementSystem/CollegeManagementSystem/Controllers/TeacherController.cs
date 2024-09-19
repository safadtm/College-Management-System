using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class TeacherController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // Teacher Inserting Controller 
        public int RegisterTeacher(string fullName, string email, string phone, string dob, string gender, string address, string joined, int deptID, string username, string password)
        {
            Teacher teacher = new Teacher
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                DOB = dob,
                Gender = gender,
                Address = address,
                Joined = joined,
                DepartmentID = deptID,
                Username = username,
                Password = password
            };


            return databaseHelper.InsertTeacher(teacher);
        }

        

    }
}
