using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class AttendenceController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // add attendence
        public bool AddAttendance(int studentId, int teacherId, DateTime date, string status)
        {
            return databaseHelper.InsertAttendance(studentId, teacherId, date, status);
        }

        // teacher view attendence
        public List<Attendance> GetTodaysAttendanceForTeacher(int teacherId)
        {
            return databaseHelper.GetTodaysAttendanceForTeacher(teacherId);
        }

        // student view attendence
        public List<Attendance> GetStudentAttendanceHistory(int studentId)
        {
            return databaseHelper.GetStudentAttendanceHistory(studentId);
        }

    }
}
