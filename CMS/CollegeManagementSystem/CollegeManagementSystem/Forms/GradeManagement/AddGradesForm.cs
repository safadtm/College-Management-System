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

namespace CollegeManagementSystem.Forms.GradeManagement
{
    public partial class AddGradesForm : Form
    {

        public int TchID { get; set; }
        public int DptID { get; set; }

        public string username { get; set; }

        public int SbjID;
        public string subjectName;

        ScoreController scoreController = new ScoreController();
        StudentController studentController = new StudentController();
        SubjectController subjectController = new SubjectController();


        public AddGradesForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void AddGradesForm_Load(object sender, EventArgs e)
        {
            Subject subject = subjectController.GetSubjectByTeacherUsername(username);
            SbjID = subject.SubjectID;
            subjectName = subject.SubjectName;

            dptLabel.Text = "Enter the marks for the suject : " + subjectName;

            List<StudentDetails> students = studentController.GetDepartmentWiseStudentsWithDetails(DptID);
            if (students != null && students.Any())
            {
                dataGridView1.DataSource = students;
                dataGridView1.Columns["StudentID"].HeaderText = "SI.NO";
                dataGridView1.Columns["StudentUserID"].HeaderText = "Admission No";
                dataGridView1.Columns["StudentName"].HeaderText = "Name";
                dataGridView1.Columns["DepartmentName"].HeaderText = "Department";

                // Hide unnecessary columns
                dataGridView1.Columns["StudentID"].Visible = false;
                dataGridView1.Columns["DepartmentName"].Visible = false;

                // Add a column for marks input
                DataGridViewTextBoxColumn marksColumn = new DataGridViewTextBoxColumn();
                marksColumn.HeaderText = "Score";
                marksColumn.Name = "Scores";
                dataGridView1.Columns.Add(marksColumn);

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
                dataGridView1.Columns["StudentUserID"].Width = 100; // Example width for Admission No
                dataGridView1.Columns["StudentName"].Width = 200; // Example width for Name
                dataGridView1.Columns["Scores"].Width = 100; // Example width for Scores

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
                MessageBox.Show("No students found.");
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


        
        private void dptLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnSbmt_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                int examId = 4;
                int subjectId = SbjID;

                if (int.TryParse(row.Cells["Scores"].Value?.ToString(), out int marks))
                {
                    // Call the AddScore function to save the mark
                    bool result = scoreController.AddScore(marks, examId, studentId, subjectId);

                    if (!result)
                    {
                        MessageBox.Show($"Failed to save marks for Student ID {studentId}");
                    }
                }
            }

            MessageBox.Show("Marks saved successfully!");
            this.Hide();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
