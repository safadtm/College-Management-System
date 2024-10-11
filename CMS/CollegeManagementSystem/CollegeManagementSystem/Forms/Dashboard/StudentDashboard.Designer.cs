namespace CollegeManagementSystem.Forms.Dashboard
{
    partial class StudentDashboard
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
            viewAttendenceToolStripMenuItem = new ToolStripMenuItem();
            coursewiseReportToolStripMenuItem = new ToolStripMenuItem();
            manageDepartmentsToolStripMenuItem = new ToolStripMenuItem();
            mainExamToolStripMenuItem = new ToolStripMenuItem();
            profileToolStripMenuItem = new ToolStripMenuItem();
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            ediToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, manageTeachersToolStripMenuItem, manageDepartmentsToolStripMenuItem, profileToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(601, 29);
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
            manageTeachersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewAttendenceToolStripMenuItem, coursewiseReportToolStripMenuItem });
            manageTeachersToolStripMenuItem.Name = "manageTeachersToolStripMenuItem";
            manageTeachersToolStripMenuItem.Size = new Size(100, 25);
            manageTeachersToolStripMenuItem.Text = "Attendence";
            // 
            // viewAttendenceToolStripMenuItem
            // 
            viewAttendenceToolStripMenuItem.Name = "viewAttendenceToolStripMenuItem";
            viewAttendenceToolStripMenuItem.Size = new Size(218, 26);
            viewAttendenceToolStripMenuItem.Text = "Daily Attendence";
            viewAttendenceToolStripMenuItem.Click += viewAttendenceToolStripMenuItem_Click;
            // 
            // coursewiseReportToolStripMenuItem
            // 
            coursewiseReportToolStripMenuItem.Name = "coursewiseReportToolStripMenuItem";
            coursewiseReportToolStripMenuItem.Size = new Size(218, 26);
            coursewiseReportToolStripMenuItem.Text = "Course Wise Report";
            coursewiseReportToolStripMenuItem.Click += coursewiseReportToolStripMenuItem_Click;
            // 
            // manageDepartmentsToolStripMenuItem
            // 
            manageDepartmentsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mainExamToolStripMenuItem });
            manageDepartmentsToolStripMenuItem.Name = "manageDepartmentsToolStripMenuItem";
            manageDepartmentsToolStripMenuItem.Size = new Size(59, 25);
            manageDepartmentsToolStripMenuItem.Text = "Exam";
            // 
            // mainExamToolStripMenuItem
            // 
            mainExamToolStripMenuItem.Name = "mainExamToolStripMenuItem";
            mainExamToolStripMenuItem.Size = new Size(164, 26);
            mainExamToolStripMenuItem.Text = "View Scores";
            mainExamToolStripMenuItem.Click += mainExamToolStripMenuItem_Click;
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
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(71, 25);
            exitToolStripMenuItem.Text = "Logout";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
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
            panel1.Location = new Point(12, 169);
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
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(601, 534);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "StudentDashboard";
            Text = "Student Dashboard";
            Load += StudentDashboard_Load;
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
        private ToolStripMenuItem manageDepartmentsToolStripMenuItem;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem viewProfileToolStripMenuItem;
        private ToolStripMenuItem ediToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label label1;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ToolStripMenuItem viewAttendenceToolStripMenuItem;
        private ToolStripMenuItem coursewiseReportToolStripMenuItem;
        private ToolStripMenuItem mainExamToolStripMenuItem;
    }
}