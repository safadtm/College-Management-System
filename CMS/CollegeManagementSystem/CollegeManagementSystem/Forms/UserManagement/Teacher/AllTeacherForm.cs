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

namespace CollegeManagementSystem.Forms.UserManagement.Teacher
{
    public partial class AllTeacherForm : Form
    {
        public AllTeacherForm()
        {
            InitializeComponent();
        }

        private void AllTeacherForm_Load(object sender, EventArgs e)
        {
           
            TeacherController teacherController = new TeacherController();
         teacherController.LoadTeachersIntoDataGridView(dataGridViewTeachers);

        }
    }
}
