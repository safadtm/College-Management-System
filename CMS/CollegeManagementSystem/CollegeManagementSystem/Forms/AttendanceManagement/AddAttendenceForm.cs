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

namespace CollegeManagementSystem.Forms.AttendanceManagement
{
    public partial class AddAttendenceForm : Form
    {
        public int TchID { get; set; }
        public int DptID { get; set; }

        string date;

        AttendenceController attendenceController = new();
        StudentController studentController = new();

        public AddAttendenceForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddAttendenceForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(TchID.ToString());
            date = DateTime.Now.ToString("dd/MM/yyyy");
            label1.Text = "Enter the attendence today :" + DateTime.Now.ToString("dd/MM/yyyy");

            List<StudentDetails> students = studentController.GetDepartmentWiseStudentsWithDetails(DptID);
            if (students != null && students.Count != 0)
            {
                dataGridView1.DataSource = students;
                dataGridView1.Columns["StudentID"].HeaderText = "SI.NO";
                dataGridView1.Columns["StudentUserID"].HeaderText = "Admission No";
                dataGridView1.Columns["StudentName"].HeaderText = "Name";
                dataGridView1.Columns["DepartmentName"].HeaderText = "Department";

                
                dataGridView1.Columns["StudentID"].Visible = false;
                dataGridView1.Columns["DepartmentName"].Visible = false;

                DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Status",
                    Name = "Status",
                    Width = 100 
                }; ;
                statusColumn.Items.AddRange(AttendanceStatus.Present, AttendanceStatus.Absent);

                dataGridView1.Columns.Add(statusColumn);

                dataGridView1.Columns["StudentUserID"].Width = 100; 
                dataGridView1.Columns["StudentName"].Width = 200; 
                
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; 
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                AdjustDataGridViewHeight(dataGridView1);
                
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

        private void btnSbmt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int studentId = Convert.ToInt32(row.Cells["StudentID"].Value);

                string status = row.Cells["Status"].Value?.ToString();

                bool result = attendenceController.AddAttendance(studentId, TchID, date, status);

                if (!result)
                {
                    MessageBox.Show($"Failed to save attendance for Student ID {studentId}");
                }
            }

            MessageBox.Show("Marks saved successfully!");
        }
    }
}
