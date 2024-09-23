﻿using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class SubjectController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // add subject
        public bool AddSubject(string subjectName, int departmentID, int? teacherID = null)
        {
            return databaseHelper.InsertSubject(subjectName, departmentID, teacherID);
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
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


                int totalColumnWidth = dataGridView.Columns.Cast<DataGridViewColumn>().Sum(col => col.Width);
                dataGridView.Width = totalColumnWidth + dataGridView.Padding.Left + dataGridView.Padding.Right;

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

        // load subject by department and semester
        public List<Subject> GetSubjectsByDepartment(int departmentId)
        {
            return databaseHelper.GetSubjectsByDepartment(departmentId);

        }

        // update subject table for teacherID s
        public bool UpdateSubjectsForTeacher(int teacherID, List<int> subjectIDs)
        {
            return databaseHelper.UpdateSubjectsForTeacher(teacherID, subjectIDs);
        }


    }
}
