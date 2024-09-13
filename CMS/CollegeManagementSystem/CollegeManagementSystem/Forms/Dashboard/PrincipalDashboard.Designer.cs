namespace CollegeManagementSystem.Forms.Dashboard
{
    partial class PrincipalDashboard
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
            manageDepartmentsToolStripMenuItem = new ToolStripMenuItem();
            manageCoursesToolStripMenuItem = new ToolStripMenuItem();
            profileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            addTeacherToolStripMenuItem = new ToolStripMenuItem();
            allTeachersToolStripMenuItem = new ToolStripMenuItem();
            addDepartmentToolStripMenuItem = new ToolStripMenuItem();
            allDepartmentsToolStripMenuItem = new ToolStripMenuItem();
            addCourseToolStripMenuItem = new ToolStripMenuItem();
            allCoursesToolStripMenuItem = new ToolStripMenuItem();
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            ediToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, manageTeachersToolStripMenuItem, manageDepartmentsToolStripMenuItem, manageCoursesToolStripMenuItem, profileToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1396, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(79, 32);
            homeToolStripMenuItem.Text = "Home";
            // 
            // manageTeachersToolStripMenuItem
            // 
            manageTeachersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addTeacherToolStripMenuItem, allTeachersToolStripMenuItem });
            manageTeachersToolStripMenuItem.Name = "manageTeachersToolStripMenuItem";
            manageTeachersToolStripMenuItem.Size = new Size(175, 32);
            manageTeachersToolStripMenuItem.Text = "Manage Teachers";
            // 
            // manageDepartmentsToolStripMenuItem
            // 
            manageDepartmentsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addDepartmentToolStripMenuItem, allDepartmentsToolStripMenuItem });
            manageDepartmentsToolStripMenuItem.Name = "manageDepartmentsToolStripMenuItem";
            manageDepartmentsToolStripMenuItem.Size = new Size(215, 32);
            manageDepartmentsToolStripMenuItem.Text = "Manage Departments";
            // 
            // manageCoursesToolStripMenuItem
            // 
            manageCoursesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addCourseToolStripMenuItem, allCoursesToolStripMenuItem });
            manageCoursesToolStripMenuItem.Name = "manageCoursesToolStripMenuItem";
            manageCoursesToolStripMenuItem.Size = new Size(170, 32);
            manageCoursesToolStripMenuItem.Text = "Manage Courses";
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewProfileToolStripMenuItem, ediToolStripMenuItem });
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(82, 32);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(57, 32);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // addTeacherToolStripMenuItem
            // 
            addTeacherToolStripMenuItem.Name = "addTeacherToolStripMenuItem";
            addTeacherToolStripMenuItem.Size = new Size(224, 32);
            addTeacherToolStripMenuItem.Text = "Add Teacher";
            // 
            // allTeachersToolStripMenuItem
            // 
            allTeachersToolStripMenuItem.Name = "allTeachersToolStripMenuItem";
            allTeachersToolStripMenuItem.Size = new Size(224, 32);
            allTeachersToolStripMenuItem.Text = "All Teachers";
            // 
            // addDepartmentToolStripMenuItem
            // 
            addDepartmentToolStripMenuItem.Name = "addDepartmentToolStripMenuItem";
            addDepartmentToolStripMenuItem.Size = new Size(245, 32);
            addDepartmentToolStripMenuItem.Text = "Add Department";
            // 
            // allDepartmentsToolStripMenuItem
            // 
            allDepartmentsToolStripMenuItem.Name = "allDepartmentsToolStripMenuItem";
            allDepartmentsToolStripMenuItem.Size = new Size(245, 32);
            allDepartmentsToolStripMenuItem.Text = "All Departments";
            // 
            // addCourseToolStripMenuItem
            // 
            addCourseToolStripMenuItem.Name = "addCourseToolStripMenuItem";
            addCourseToolStripMenuItem.Size = new Size(224, 32);
            addCourseToolStripMenuItem.Text = "Add Course";
            // 
            // allCoursesToolStripMenuItem
            // 
            allCoursesToolStripMenuItem.Name = "allCoursesToolStripMenuItem";
            allCoursesToolStripMenuItem.Size = new Size(224, 32);
            allCoursesToolStripMenuItem.Text = "All Courses";
            // 
            // viewProfileToolStripMenuItem
            // 
            viewProfileToolStripMenuItem.Name = "viewProfileToolStripMenuItem";
            viewProfileToolStripMenuItem.Size = new Size(224, 32);
            viewProfileToolStripMenuItem.Text = "View Profile";
            // 
            // ediToolStripMenuItem
            // 
            ediToolStripMenuItem.Name = "ediToolStripMenuItem";
            ediToolStripMenuItem.Size = new Size(224, 32);
            ediToolStripMenuItem.Text = "Edit Profile";
            // 
            // PrincipalDashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(1396, 712);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "PrincipalDashboard";
            Text = "Principal Dashboard";
            Load += PrincipalDashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem manageTeachersToolStripMenuItem;
        private ToolStripMenuItem addTeacherToolStripMenuItem;
        private ToolStripMenuItem allTeachersToolStripMenuItem;
        private ToolStripMenuItem manageDepartmentsToolStripMenuItem;
        private ToolStripMenuItem addDepartmentToolStripMenuItem;
        private ToolStripMenuItem allDepartmentsToolStripMenuItem;
        private ToolStripMenuItem manageCoursesToolStripMenuItem;
        private ToolStripMenuItem addCourseToolStripMenuItem;
        private ToolStripMenuItem allCoursesToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem viewProfileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem ediToolStripMenuItem;
    }
}