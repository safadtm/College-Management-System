using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.AttendanceManagement;
using CollegeManagementSystem.Forms.GradeManagement;
using CollegeManagementSystem.Forms.ProfileForms;
using CollegeManagementSystem.Forms.TimeTableManagement;
using CollegeManagementSystem.Forms.UserManagement.Student;
using CollegeManagementSystem.Forms.UserManagement.Teacher;
using CollegeManagementSystem.Model;
using CollegeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.Dashboard
{
    public partial class TeacherDashboard : Form
    {
        // Property to store the username
        public string Username { get; set; }
        
        private TeacherController teacherController;
        public int deptID;
        public int subID;
        public int tchID;

        public TeacherDashboard()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            CustomizeMenuStrip(menuStrip1);
            teacherController = new TeacherController();
        }

        private void CustomizeMenuStrip(MenuStrip menuStrip)
        {
            menuStrip.Renderer = new ToolStripProfessionalRenderer(new CustomMenuStripColorTable());
            menuStrip.BackColor = AppColors.PrimaryColor;  // MenuStrip background
            menuStrip.ForeColor = AppColors.NeutralColor;  // MenuStrip text color
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void TeacherDashboard_Load(object sender, EventArgs e)
        {
            Teacher teacher = teacherController.GetTeacherByUsername(Username);
            tchID=teacher.TeacherID;
            deptID = teacher.DepartmentID;

           
            if (!string.IsNullOrEmpty(teacher.FullName))
            {

                label1.Text = $"Welcome, {teacher.FullName}";
            }
            label2.Text = "Total Students : 10";
            label3.Text = "Upcoming Classes : 9";
            label4.Text = "Pending Grading : 6";
            label5.Text = "Attendance Status : 10";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TeacherProfileForm teacherProfileForm = new TeacherProfileForm())
            {
                teacherProfileForm.Username = this.Username;
                teacherProfileForm.ShowDialog();
            }
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (EditTeacherProfileForm editTeacherProfileForm = new EditTeacherProfileForm
            {
                Username = Username
            })
            {
                if (editTeacherProfileForm.ShowDialog() == DialogResult.OK)
                {
                    TeacherController teacherController = new TeacherController();
                    var updatedTeacher = teacherController.GetTeacherByUsername(Username);
                }
            }
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add student
            using (AddStudentForm addStudentForm = new AddStudentForm()
            {
                DeptID=deptID
            })
            {
                
                addStudentForm.ShowDialog();
            }
            
        }

        private void allTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all student assigned to this teacher
            using (AllStudentsByDepartment allStudentsByDepartment = new AllStudentsByDepartment()
            {
                DeptID = deptID
            })
            {
                allStudentsByDepartment.ShowDialog();
            }
            
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add attendence by teachers class
            using (AddAttendenceForm addAttendenceForm = new AddAttendenceForm()
            {
                TchID = tchID,
                DptID = deptID
            })
            {
                addAttendenceForm.ShowDialog();
            }
        }

        private void allDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all attendence by teachers class

            using (AllAttendenceForm allAttendenceForm = new AllAttendenceForm()
            {
                TchID = tchID
            })
            {
                allAttendenceForm.ShowDialog();
            }
        }

        private void editAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add mark by teachers class
            using (AddGradesForm addGradesForm = new()
            {
                TchID=tchID,
                DptID=deptID,
                username=Username
            })
            {
                addGradesForm.ShowDialog();
            }
        }

        private void allCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all mark by teachers class

            using (AllGradesForm allGradesForm = new AllGradesForm()
            {
                username = Username
            })
            {
                allGradesForm.ShowDialog();
            }
        }

        private void editGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // edit grade by teachers class
            using (EditGradesForm editGradesForm = new EditGradesForm())
            {
                editGradesForm.ShowDialog();
            }
        }

        private void addTimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add timetable to particular department
            using (AddTimeTableForm addTimeTableForm = new AddTimeTableForm()
            {
                DeptID = deptID,
                TchID=tchID
            })
            {
                addTimeTableForm.ShowDialog();
            }
        }

        private void viewTimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // view timetable to particular department
            using (ViewTimeTableForm viewTimeTableForm = new ViewTimeTableForm())
            {
                viewTimeTableForm.ShowDialog();
            }
        }

        private void editTimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
