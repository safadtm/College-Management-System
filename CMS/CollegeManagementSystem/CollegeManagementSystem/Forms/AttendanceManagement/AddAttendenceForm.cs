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
            date = DateTime.Now.ToString("dd/MM/yyyy");
            label1.Text = "Enter the attendence today :" + date;

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

                dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
                dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                dataGridView1.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);
                dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);


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

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Status"].Index && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.DrawMode = DrawMode.OwnerDrawFixed;  // Enable custom drawing for items
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

                // Handle the draw event for the combo box items
                comboBox.DrawItem -= ComboBox_DrawItem;  // Remove previous handler (if any)
                comboBox.DrawItem += ComboBox_DrawItem;  // Attach new handler
            }
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (e.Index < 0) return;

            string status = comboBox.Items[e.Index].ToString();
            Color backColor;
            Color textColor = AppColors.NeutralColor;

            if (status == AttendanceStatus.Present)
            {
                backColor = AppColors.PresentColor;
            }
            else if (status == AttendanceStatus.Absent)
            {
                backColor = AppColors.AbsentColor;
            }
            else
            {
                backColor = Color.White;
                textColor = Color.Black;
            }

            // Set background and text color
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
            e.Graphics.DrawString(status, e.Font, new SolidBrush(textColor), e.Bounds);
            e.DrawFocusRectangle();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty && dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Status")
            {
                // Get the new status value
                string status = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Apply the color manually to the cell immediately
                if (status == AttendanceStatus.Present)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = AppColors.PresentColor;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = AppColors.NeutralColor;
                }
                else if (status == AttendanceStatus.Absent)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = AppColors.AbsentColor;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = AppColors.NeutralColor;
                }

                dataGridView1.Invalidate(); // Force the grid to refresh and reapply styles
            }
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           DataGridViewHelper.FormatAttendanceCell(dataGridView1, e, "Status");
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

            MessageBox.Show("Attendence submitted successfully!");
        }
    }
}
