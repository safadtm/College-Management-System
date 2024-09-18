﻿using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Forms.Dashboard;
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

namespace CollegeManagementSystem.Forms.UserManagement.Teacher
{
    public partial class AddTeacherForm : Form
    {
        
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        // load semesters
        private void PopulateSemesters()
        {
            // Clear previous controls
            tableLayoutPanelSemesters.Controls.Clear();

            // Fetch semesters from the database
            SemesterController semesterController = new SemesterController();
            List<Semester> semesters = semesterController.GetAllSemesters();

            // Set column count to 2 (for two semesters side by side)
            tableLayoutPanelSemesters.ColumnCount = 2;
            tableLayoutPanelSemesters.RowCount = (semesters.Count + 1) / 2; // Adjust row count based on the number of semesters
            tableLayoutPanelSemesters.AutoSize = true;

            int currentColumn = 0;
            int currentRow = 0;

            // Add CheckBoxes dynamically to the TableLayoutPanel
            foreach (var semester in semesters)
            {
                CheckBox semesterCheckBox = new CheckBox
                {
                    Text = semester.SemesterName,
                    AutoSize = true,
                    Tag = semester.SemesterID
                };

                // Add the CheckBox to the TableLayoutPanel
                semesterCheckBox.CheckedChanged += SemesterCheckBox_CheckedChanged;
                tableLayoutPanelSemesters.Controls.Add(semesterCheckBox, currentColumn, currentRow);

                // Move to the next column, and if we reach the second column, move to the next row
                currentColumn++;
                if (currentColumn >= 2)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
        }

        // load departments
        private void LoadDepartments()
        {
            try
            {
                DepartmentController departmentController = new DepartmentController();
                List<Department> departments = departmentController.GetAllDepartments();

                if (departments != null && departments.Any())
                {
                    cmbDepartment.DataSource = departments;
                    cmbDepartment.DisplayMember = "DepartmentName";
                    cmbDepartment.ValueMember = "DepartmentID";
                }
                else
                {
                    MessageBox.Show("No departments found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}");
            }
        }

        // load subjects according to the user selection
        // Event when the department is selected
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if any semester is selected before populating subjects
            PopulateSubjectsIfApplicable();
        }

        // Event when a semester checkbox is changed
        List<int> selectedSemesterIds = new List<int>();
        private void SemesterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checkbox that was clicked
            CheckBox semesterCheckBox = sender as CheckBox;

            if (semesterCheckBox != null)
            {
                // Retrieve the semester ID stored in the Tag property of the checkbox
                int semesterId = (int)semesterCheckBox.Tag;

                if (semesterCheckBox.Checked)
                {
                    // Add the semester ID if it's selected
                    if (!selectedSemesterIds.Contains(semesterId))
                    {
                        selectedSemesterIds.Add(semesterId);
                    }
                }
                else
                {
                    // Remove the semester ID if it's deselected
                    selectedSemesterIds.Remove(semesterId);
                }
            }
            PopulateSubjectsIfApplicable();
        }

        // Check if department is selected and any semester checkbox is checked
        private void PopulateSubjectsIfApplicable()
        {
           if (cmbDepartment.SelectedItem != null && selectedSemesterIds.Any())
            {
                // Department and at least one semester is selected, so populate subjects
                int departmentId = (int)cmbDepartment.SelectedValue;
                PopulateSubjects(departmentId, selectedSemesterIds);
               
            }
            else
            {
                tableLayoutPanelSubjects.Controls.Clear();
                Label noSelectionLabel = new Label
                {
                    Text = "Please select a department and at least one semester to view subjects.",
                    AutoSize = true
                };
                tableLayoutPanelSubjects.Controls.Add(noSelectionLabel);
            }
        }

       // Populate subjects based on selected department and semesters
        
        private void PopulateSubjects(int departmentId, List<int> semesterIds)
        {
            tableLayoutPanelSubjects.Controls.Clear();

            // Fetch subjects from the database based on department and selected semesters
            SubjectController subjectController = new SubjectController();
            List<Subject> subjects = subjectController.GetSubjectsByDepartmentAndSemesters(departmentId, semesterIds);

            if (subjects == null || subjects.Count == 0)
            {
                MessageBox.Show("No subjects found for the selected department and semesters.");
                return;
            }

            // Set column count and row count dynamically as needed
            tableLayoutPanelSubjects.ColumnCount = 2;  // 2 columns for layout
            tableLayoutPanelSubjects.RowCount = (subjects.Count + 1) / 2;
            tableLayoutPanelSubjects.AutoSize = true;

            int currentColumn = 0;
            int currentRow = 0;

            foreach (var subject in subjects)
            {
                CheckBox subjectCheckBox = new CheckBox
                {
                    Text = subject.SubjectName,
                    AutoSize = true,
                    Tag = subject // Store the Subject object for reference
                };

                // Add the CheckBox to the TableLayoutPanel
                tableLayoutPanelSubjects.Controls.Add(subjectCheckBox, currentColumn, currentRow);

                currentColumn++;
                if (currentColumn >= 2)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // generate username and password button
            var (username, password) = CredentialGenerator.GenerateCredentials("TCH");
            txtUsername.Text= username;
            txtPassword.Text= password;

            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New Teacher Added");
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTeacherForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            PopulateSemesters();
          
        }

        private void sem1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
