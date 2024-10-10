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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CollegeManagementSystem.Forms.GradeManagement
{
    public partial class AllGradesForm : Form
    {
        public string username { get; set; }

        public int SbjID;
        public string subjectName;

        ScoreController scoreController = new ScoreController();
        StudentController studentController = new StudentController();
        SubjectController subjectController = new SubjectController();

        public AllGradesForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void AllGradesForm_Load(object sender, EventArgs e)
        {
            Subject subject = subjectController.GetSubjectByTeacherUsername(username);
            SbjID = subject.SubjectID;
            subjectName = subject.SubjectName;

            dptLabel.Text = "Students marks for the suject : " + subjectName;

            List<StudentMarksView> studentsMarks = scoreController.GetMarksBySubject(SbjID);
            if (studentsMarks != null && studentsMarks.Any())
            {
                dataGridView1.DataSource = studentsMarks;
                dataGridView1.Columns["StudentID"].HeaderText = "SI.NO";
                dataGridView1.Columns["StudentName"].HeaderText = "Name";
                dataGridView1.Columns["SubjectName"].HeaderText = "Name";
                dataGridView1.Columns["MarksObtained"].HeaderText = "Score";

                // Hide unnecessary columns
                dataGridView1.Columns["StudentID"].Visible = false;
                dataGridView1.Columns["SubjectName"].Visible = false;
                
                // Add a column for maximum score (read-only) with Fill behavior
                DataGridViewTextBoxColumn maxScoreColumn = new DataGridViewTextBoxColumn();
                maxScoreColumn.HeaderText = "Max Score";
                maxScoreColumn.Name = "MaxScore";
                maxScoreColumn.ReadOnly = true;
                maxScoreColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                maxScoreColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Fill remaining space
                dataGridView1.Columns.Add(maxScoreColumn);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["MaxScore"].Value = 100; // Set 100 as the value for Max Score
                }

                // Set specific widths for other columns (optional)
                dataGridView1.Columns["StudentName"].Width = 100; // Example width for Admission No
                dataGridView1.Columns["MarksObtained"].Width = 200; // Example width for Name
          
                // Adjust column sizes
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Disable auto resizing
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Ensure the last column fills any remaining space
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                AdjustDataGridViewHeight(dataGridView1);
                // Optionally refresh
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("No scores found.");
            }

            
        }

        public void AdjustDataGridViewHeight(DataGridView dataGridView)
        {
            // Calculate the total height needed for the DataGridView
            int rowHeight = dataGridView.Rows[0].Height; // Get the height of a single row
            int totalHeight = dataGridView.ColumnHeadersHeight; // Start with the header height

            // Add heights of all rows
            totalHeight += rowHeight * dataGridView.Rows.Count;

            // Add some extra space for margins (optional)
            totalHeight += dataGridView.Margin.Top + dataGridView.Margin.Bottom;

            // Set the DataGridView height
            dataGridView.Height = totalHeight;
        }
    }
}
