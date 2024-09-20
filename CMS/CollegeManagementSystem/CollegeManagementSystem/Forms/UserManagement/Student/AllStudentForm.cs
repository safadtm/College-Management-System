﻿using CollegeManagementSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.UserManagement.Student
{
    public partial class AllStudentForm : Form
    {
        public AllStudentForm()
        {
            InitializeComponent();
        }

        private void AllStudentForm_Load(object sender, EventArgs e)
        {
            StudentController studentController = new StudentController();
            studentController.LoadStudentsIntoDataGridView(dataGridViewStudents);

        }
    }
}
