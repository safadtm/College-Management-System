using CollegeManagementSystem.Controllers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CollegeManagementSystem.Forms.GradeManagement
{
    public partial class StudentScoreView : Form
    {
        public int StuID { get; set; }
        public string Username { get; set; }
        string fullName;
        StudentController studentController = new();
        ScoreController scoreController = new();
        private System.Windows.Forms.ListView listView1;

        public StudentScoreView()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
          
        }

        
        private void StudentScoreView_Load(object sender, EventArgs e)
        {
            Student  student= studentController.GetStudentByUsername(Username);
            fullName = student.FullName;
            label1.Text = "Hey " + fullName + ", your exam scores here";

            List<StudentMarksView> studentMarksViews = scoreController.GetMarksByStudent(StuID);

            // Create TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                ColumnCount = 2,
                AutoSize = true, 
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Padding = new Padding(10), 
                Location = new Point(170, 110)
            };

            // Set column widths using AutoSize
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F)); // Equal width for Subject column
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F)); // Equal width for Marks column

            // Add header row
            tableLayoutPanel.Controls.Add(new Label
            {
                Text = "Subject",
                Font = new Font("Arial", 14, FontStyle.Bold), // Adjust font size as needed
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = AppColors.HighlightColor,
                MinimumSize = new Size(0, 35)
            }, 0, 0); // Column 0, Row 0

            tableLayoutPanel.Controls.Add(new Label
            {
                Text = "Marks",
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = AppColors.HighlightColor,
                MinimumSize = new Size(0, 35)
            }, 1, 0); // Column 1, Row 0

            // Add rows for each student mark
            int rowIndex = 1; // Start at row 1 (after header)
            foreach (var studentMark in studentMarksViews)
            {
                // Subject
                var subjectLabel = new Label
                {
                    Text = studentMark.SubjectName,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor=AppColors.SecondaryColor,
                    MinimumSize = new Size(0, 50) // Minimum height for the label
                };
                tableLayoutPanel.Controls.Add(subjectLabel, 0, rowIndex);

                // Marks with background color
                Label marksLabel = new()
                {
                    Text = studentMark.MarksObtained?.ToString() ?? "N/A",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    BackColor = studentMark.MarksObtained >= 50 ? AppColors.PresentColor : AppColors.AbsentColor,
                    MinimumSize = new Size(0, 50) // Minimum height for the label
                };
                tableLayoutPanel.Controls.Add(marksLabel, 1, rowIndex);

                rowIndex++;
            }

            // Add the TableLayoutPanel to the form
            this.Controls.Add(tableLayoutPanel);


        }

    }
}

