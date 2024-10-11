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
            InitializeListView();
        }

        private void InitializeListView()
        {
            listView1 = new System.Windows.Forms.ListView
            {
                Size = new Size(350, 0), 
                View = View.Details,
                Font = new Font("Arial", 14, FontStyle.Bold), 
                FullRowSelect = true,
                GridLines = true,
                Location = new Point(180, 125) 
            };

            // Add columns
            listView1.Columns.Add("Subject", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Marks", 200, HorizontalAlignment.Center);
            Controls.Add(listView1); 
        }

        private void StudentScoreView_Load(object sender, EventArgs e)
        {
            Student  student= studentController.GetStudentByUsername(Username);
            fullName = student.FullName;
            label1.Text = "Hey " + fullName + ", your exam scores here";

            List<StudentMarksView> studentMarksViews = scoreController.GetMarksByStudent(StuID);

            if (studentMarksViews == null || studentMarksViews.Count == 0)
            {
                listView1.Visible = false;
                Label noDataLabel = new Label
                {
                    Text = "No scores found for this student.",
                    AutoSize = true,
                    Font = new Font("Arial", 12, FontStyle.Italic),
                    Location = new Point(10, 10)
                };
                this.Controls.Add(noDataLabel);
                return;
            }

            // Add items to the ListView
            foreach (var studentMark in studentMarksViews)
            {
                ListViewItem item = new ListViewItem(studentMark.SubjectName)
                {
                     
                  Font = new Font("Arial", 14, FontStyle.Bold) 
                
                };

                item.SubItems.Add(studentMark.MarksObtained?.ToString() ?? "N/A");


                if (studentMark.MarksObtained.HasValue && studentMark.MarksObtained.Value >= 50)
                {
                    item.SubItems[1].BackColor = AppColors.PresentColor; 
                }
                else
                {
                    item.SubItems[1].BackColor = AppColors.AbsentColor;
                }

                listView1.Items.Add(item);
            }

            // Adjust the height of the ListView based on the number of items
            int itemHeight = 100; // Approximate height of each row
            listView1.Height = Math.Min(itemHeight * studentMarksViews.Count + 20, 200); // 20 for padding and max height limit

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

    }
}

