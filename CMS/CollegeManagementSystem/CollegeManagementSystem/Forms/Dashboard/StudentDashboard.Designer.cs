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
            manageDepartmentsToolStripMenuItem = new ToolStripMenuItem();
            profileToolStripMenuItem = new ToolStripMenuItem();
            viewProfileToolStripMenuItem = new ToolStripMenuItem();
            ediToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, manageTeachersToolStripMenuItem, manageDepartmentsToolStripMenuItem, profileToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1396, 36);
            menuStrip1.TabIndex = 1;
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
            manageTeachersToolStripMenuItem.Name = "manageTeachersToolStripMenuItem";
            manageTeachersToolStripMenuItem.Size = new Size(126, 32);
            manageTeachersToolStripMenuItem.Text = "Attendence";
            // 
            // manageDepartmentsToolStripMenuItem
            // 
            manageDepartmentsToolStripMenuItem.Name = "manageDepartmentsToolStripMenuItem";
            manageDepartmentsToolStripMenuItem.Size = new Size(87, 32);
            manageDepartmentsToolStripMenuItem.Text = "Grades";
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewProfileToolStripMenuItem, ediToolStripMenuItem });
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(82, 32);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // viewProfileToolStripMenuItem
            // 
            viewProfileToolStripMenuItem.Name = "viewProfileToolStripMenuItem";
            viewProfileToolStripMenuItem.Size = new Size(200, 32);
            viewProfileToolStripMenuItem.Text = "View Profile";
            // 
            // ediToolStripMenuItem
            // 
            ediToolStripMenuItem.Name = "ediToolStripMenuItem";
            ediToolStripMenuItem.Size = new Size(200, 32);
            ediToolStripMenuItem.Text = "Edit Profile";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(57, 32);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(1396, 712);
            Controls.Add(menuStrip1);
            Name = "StudentDashboard";
            Text = "Student Dashboard";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}