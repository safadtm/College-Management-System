using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
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

        // load all subjects
        public List<Subject> GetAllSubjects()
        {
            return databaseHelper.GetSubjects();
        }

        // fetch subjects to gridview
        public void LoadSubjectsIntoDataGridView(DataGridView dataGridView)
        {
            List<Subject> subjects = GetAllSubjects();

            if (subjects != null && subjects.Any())
            {
                dataGridView.DataSource = subjects;
                dataGridView.Columns["SubjectID"].HeaderText = "SI.NO";
                dataGridView.Columns["SubjectName"].HeaderText = "Subject";
                dataGridView.Columns["DepartmentName"].HeaderText = "Department";
                dataGridView.Columns["TeacherName"].HeaderText = "Teacher";
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
                MessageBox.Show("No subjects found.");
            }
        }


    }
}
