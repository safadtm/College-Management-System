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
    public partial class AllAttendenceForm : Form
    {
        public int TchID { get; set; }


        string date;

        AttendenceController attendenceController = new();
        StudentController studentController = new();


        public AllAttendenceForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
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

        private void AllAttendenceForm_Load(object sender, EventArgs e)
        {
            date = DateTime.Now.ToString("dd/MM/yyyy");
            dptLabel.Text = "Todays Attendence : " + date;

            List<Attendance> attendances = attendenceController.GetTodaysAttendanceByDate(TchID,date);
            if (attendances != null && attendances.Count != 0)
            {
                dataGridView1.DataSource = attendances;
                dataGridView1.Columns["StudentName"].HeaderText = "Name";
                dataGridView1.Columns["Date"].HeaderText = "Date";
                dataGridView1.Columns["Status"].HeaderText = "Status";

                dataGridView1.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView1.Columns["Date"].Visible = false;
               
                dataGridView1.Columns["StudentName"].Width = 200;
                dataGridView1.Columns["Status"].Width = 100;

                dataGridView1.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                AdjustDataGridViewHeight(dataGridView1);

                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("No attendences found.");
            }

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewHelper.FormatAttendanceCell(dataGridView1, e, "Status");
        }
    }
}
