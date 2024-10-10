using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class ScoreController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();


        // Datagridview for add exam mark
        public bool AddScore(int gradeValue, int examId, int studentId, int subjectId)
        {
            return databaseHelper.InsertScore(gradeValue, examId, studentId, subjectId);
        }


        // Datagridview for show all the mark of the students in the department
        public List<StudentMarksView> GetMarksBySubject(int subjectId)
        {
            return databaseHelper.GetStudentMarksBySubjectID(subjectId);
        }

        // Particular student exam mark
        public List<StudentMarksView> GetMarksByStudent(int studentId)
        {
            return databaseHelper.GetStudentMarksByStudentID(studentId);
        }
    }
}
