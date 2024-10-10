using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Model
{
    public class StudentMarksView
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }

        public string SubjectName { get; set; }
        public int? MarksObtained { get; set; }

    }
}
