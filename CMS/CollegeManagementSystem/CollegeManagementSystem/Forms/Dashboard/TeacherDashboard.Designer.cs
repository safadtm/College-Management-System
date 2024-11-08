namespace CollegeManagementSystem.Forms.Dashboard
{
    partial class TeacherDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            manageTeachersToolStripMenuItem = new ToolStripMenuItem();
            addStudentToolStripMenuItem = new ToolStripMenuItem();
            allStudentsToolStripMenuItem = new ToolStripMenuItem();
            manageDepartmentsToolStripMenuItem = new ToolStripMenuItem();
            addDepartmentToolStripMenuItem = new ToolStripMenuItem();
            allDepartmentsToolStripMenuItem = new ToolStripMenuItem();
            manageCoursesToolStripMenuItem = new ToolStripMenuItem();
            addCourseToolStripMenuItem = new ToolStripMenuItem();
            allCoursesToolStripMenuItem = new ToolStripMenuItem();
            profileToolStripMenuItem = new ToolStripMenuItem();
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            ediToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            label1 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, manageTeachersToolStripMenuItem, manageDepartmentsToolStripMenuItem, manageCoursesToolStripMenuItem, profileToolStripMenuItem, exitToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(552, 29);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(64, 25);
            homeToolStripMenuItem.Text = "Home";
            homeToolStripMenuItem.Click += homeToolStripMenuItem_Click;
            // 
            // manageTeachersToolStripMenuItem
            // 
            manageTeachersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addStudentToolStripMenuItem, allStudentsToolStripMenuItem });
            manageTeachersToolStripMenuItem.Name = "manageTeachersToolStripMenuItem";
            manageTeachersToolStripMenuItem.Size = new Size(82, 25);
            manageTeachersToolStripMenuItem.Text = "Students";
            // 
            // addStudentToolStripMenuItem
            // 
            addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            addStudentToolStripMenuItem.Size = new Size(165, 26);
            addStudentToolStripMenuItem.Text = "Add Student";
            addStudentToolStripMenuItem.Click += addTeacherToolStripMenuItem_Click;
            // 
            // allStudentsToolStripMenuItem
            // 
            allStudentsToolStripMenuItem.Name = "allStudentsToolStripMenuItem";
            allStudentsToolStripMenuItem.Size = new Size(165, 26);
            allStudentsToolStripMenuItem.Text = "All Students";
            allStudentsToolStripMenuItem.Click += allTeachersToolStripMenuItem_Click;
            // 
            // manageDepartmentsToolStripMenuItem
            // 
            manageDepartmentsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addDepartmentToolStripMenuItem, allDepartmentsToolStripMenuItem });
            manageDepartmentsToolStripMenuItem.Name = "manageDepartmentsToolStripMenuItem";
            manageDepartmentsToolStripMenuItem.Size = new Size(100, 25);
            manageDepartmentsToolStripMenuItem.Text = "Attendence";
            // 
            // addDepartmentToolStripMenuItem
            // 
            addDepartmentToolStripMenuItem.Name = "addDepartmentToolStripMenuItem";
            addDepartmentToolStripMenuItem.Size = new Size(190, 26);
            addDepartmentToolStripMenuItem.Text = "Add Attendence";
            addDepartmentToolStripMenuItem.Click += addDepartmentToolStripMenuItem_Click;
            // 
            // allDepartmentsToolStripMenuItem
            // 
            allDepartmentsToolStripMenuItem.Name = "allDepartmentsToolStripMenuItem";
            allDepartmentsToolStripMenuItem.Size = new Size(190, 26);
            allDepartmentsToolStripMenuItem.Text = "All Attendence";
            allDepartmentsToolStripMenuItem.Click += allDepartmentsToolStripMenuItem_Click;
            // 
            // manageCoursesToolStripMenuItem
            // 
            manageCoursesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addCourseToolStripMenuItem, allCoursesToolStripMenuItem });
            manageCoursesToolStripMenuItem.Name = "manageCoursesToolStripMenuItem";
            manageCoursesToolStripMenuItem.Size = new Size(59, 25);
            manageCoursesToolStripMenuItem.Text = "Exam";
            // 
            // addCourseToolStripMenuItem
            // 
            addCourseToolStripMenuItem.Name = "addCourseToolStripMenuItem";
            addCourseToolStripMenuItem.Size = new Size(158, 26);
            addCourseToolStripMenuItem.Text = "Add Scores";
            addCourseToolStripMenuItem.Click += addCourseToolStripMenuItem_Click;
            // 
            // allCoursesToolStripMenuItem
            // 
            allCoursesToolStripMenuItem.Name = "allCoursesToolStripMenuItem";
            allCoursesToolStripMenuItem.Size = new Size(158, 26);
            allCoursesToolStripMenuItem.Text = "All Scores";
            allCoursesToolStripMenuItem.Click += allCoursesToolStripMenuItem_Click;
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewProfileToolStripMenuItem, ediToolStripMenuItem });
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(67, 25);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // viewProfileToolStripMenuItem
            // 
            viewProfileToolStripMenuItem.Name = "viewProfileToolStripMenuItem";
            viewProfileToolStripMenuItem.Size = new Size(163, 26);
            viewProfileToolStripMenuItem.Text = "View Profile";
            viewProfileToolStripMenuItem.Click += viewProfileToolStripMenuItem_Click;
            // 
            // ediToolStripMenuItem
            // 
            ediToolStripMenuItem.Name = "ediToolStripMenuItem";
            ediToolStripMenuItem.Size = new Size(163, 26);
            ediToolStripMenuItem.Text = "Edit Profile";
            ediToolStripMenuItem.Click += ediToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(71, 25);
            exitToolStripMenuItem1.Text = "Logout";
            exitToolStripMenuItem1.Click += exitToolStripMenuItem1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(133, 36);
            label1.TabIndex = 2;
            label1.Text = "Welcome";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(203, 241, 245);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 168);
            panel1.Name = "panel1";
            panel1.Size = new Size(459, 297);
            panel1.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 223);
            label5.Name = "label5";
            label5.Size = new Size(176, 26);
            label5.TabIndex = 3;
            label5.Text = "Total Departments :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 160);
            label4.Name = "label4";
            label4.Size = new Size(135, 26);
            label4.TabIndex = 2;
            label4.Text = "Total Courses :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 102);
            label3.Name = "label3";
            label3.Size = new Size(141, 26);
            label3.TabIndex = 1;
            label3.Text = "Total Students :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 42);
            label2.Name = "label2";
            label2.Size = new Size(143, 26);
            label2.TabIndex = 0;
            label2.Text = "Total Teachers :";
            // 
            // TeacherDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(552, 534);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "TeacherDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher Dashboard";
            Load += TeacherDashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem manageTeachersToolStripMenuItem;
        private ToolStripMenuItem addStudentToolStripMenuItem;
        private ToolStripMenuItem allStudentsToolStripMenuItem;
        private ToolStripMenuItem manageDepartmentsToolStripMenuItem;
        private ToolStripMenuItem addDepartmentToolStripMenuItem;
        private ToolStripMenuItem allDepartmentsToolStripMenuItem;
        private ToolStripMenuItem manageCoursesToolStripMenuItem;
        private ToolStripMenuItem addCourseToolStripMenuItem;
        private ToolStripMenuItem allCoursesToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem viewProfileToolStripMenuItem;
        private ToolStripMenuItem ediToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private Label label1;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}