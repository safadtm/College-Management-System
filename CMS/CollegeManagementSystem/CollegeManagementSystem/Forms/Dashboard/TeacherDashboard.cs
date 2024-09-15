using CollegeManagementSystem.Forms.AttendanceManagement;
using CollegeManagementSystem.Forms.GradeManagement;
using CollegeManagementSystem.Forms.ProfileForms;
using CollegeManagementSystem.Forms.TimeTableManagement;
using CollegeManagementSystem.Forms.UserManagement.Student;
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

        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeacherDashboard_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username))
            {

                label1.Text = $"Welcome, {Username}";
            }
            label2.Text = "Total Students : 10";
            label3.Text = "Upcoming Classes : 9";
            label4.Text = "Pending Grading : 6";
            label5.Text = "Attendance Status : 10";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }

        private void viewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeacherProfileForm teacherProfileForm = new TeacherProfileForm();
            teacherProfileForm.Show();
        }

        private void ediToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            EditTeacherProfileForm editTeacherProfileForm = new EditTeacherProfileForm();
            editTeacherProfileForm.Show();
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add student
            this.Hide();
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.Show();
        }

        private void allTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all student assigned to this teacher
            AllStudentForm allStudentForm = new AllStudentForm();
            allStudentForm.Show();
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add attendence by teachers class
            this.Hide();
            AddAttendenceForm addAttendenceForm = new AddAttendenceForm();
            addAttendenceForm.Show();
        }

        private void allDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all attendence by teachers class
            AllAttendenceForm allAttendenceForm = new AllAttendenceForm();
            allAttendenceForm.Show();
        }

        private void editAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // edit attendence by teachers class
            this.Hide();
            EditAttendenceForm editAttendenceForm = new EditAttendenceForm();
            editAttendenceForm.Show();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add grade by teachers class
            this.Hide();
            AddGradesForm addGradesForm = new AddGradesForm();
            addGradesForm.Show();
        }

        private void allCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // all grade by teachers class
            AllGradesForm allGradesForm = new AllGradesForm();
            allGradesForm.Show();
        }

        private void editGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // edit grade by teachers class
            this.Hide();
            EditGradesForm editGradesForm= new EditGradesForm();
            editGradesForm.Show();
        }

        private void addTimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // add timetable to particular department
            this.Hide();
            AddTimeTableForm addTimeTableForm = new AddTimeTableForm();
            addTimeTableForm.Show();
        }

        private void viewTimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // view timetable to particular department
            ViewTimeTableForm viewTimeTableForm = new ViewTimeTableForm();
            viewTimeTableForm.Show();
        }

        private void editTimetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // edit timetable to particular department
            this.Hide();
            EditTimeTableForm editTimeTableForm = new EditTimeTableForm();
            editTimeTableForm.Show();
        }
    }
}
