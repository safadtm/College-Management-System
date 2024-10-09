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

namespace CollegeManagementSystem.Forms.TimeTableManagement
{
    public partial class AddTimeTableForm : Form
    {
        public int DeptID { get; set; }
        public int TchID { get; set; }
        public AddTimeTableForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            CreateTimetableView();
        }

        private void CreateTimetableView()
        {
            // Create a main TableLayoutPanel to organize the form into sections
            TableLayoutPanel mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 3;  // One row for label, one for timetable, one for button
            mainLayout.ColumnCount = 1;  // Single column for a vertical layout
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Row for label
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80));  // Row for timetable (80% of the height)
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));  // Row for button

            // Add label for Department information
            Label labelDPT = new Label();
            labelDPT.Text = "Add TimeTable for " + DeptID;
            labelDPT.Dock = DockStyle.Top;
            labelDPT.TextAlign = ContentAlignment.MiddleCenter;
            labelDPT.Font = new Font(labelDPT.Font.FontFamily, 12, FontStyle.Bold);
            labelDPT.Padding = new Padding(10);
            mainLayout.Controls.Add(labelDPT, 0, 0);  // Add label to the first row

            // Create the timetable layout
            TableLayoutPanel timetableLayout = new TableLayoutPanel();
            timetableLayout.RowCount = 6; // 1 header + 5 time slots
            timetableLayout.ColumnCount = 6; // 1 time column + 5 days
            timetableLayout.Dock = DockStyle.Fill;
            timetableLayout.AutoSize = true;

            // Set all columns and rows to have equal size
            for (int i = 0; i < timetableLayout.ColumnCount; i++)
            {
                timetableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / timetableLayout.ColumnCount));
            }

            for (int i = 0; i < timetableLayout.RowCount; i++)
            {
                timetableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / timetableLayout.RowCount));
            }

            // Add the header row (Days of the week)
            string[] days = { "Time", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            for (int col = 0; col < days.Length; col++)
            {
                Label dayLabel = new Label();
                dayLabel.Text = days[col];
                dayLabel.Dock = DockStyle.Fill;
                dayLabel.TextAlign = ContentAlignment.MiddleCenter;
                dayLabel.Padding = new Padding(5); // Add padding for better spacing
                timetableLayout.Controls.Add(dayLabel, col, 0);
            }

            // Time slots
            string[] times = { "10:00", "11:00", "12:00", "02:00", "03:00" };

            // Add time labels and ComboBoxes for each day/time slot
            for (int row = 1; row <= times.Length; row++)
            {
                // Add time labels in the first column
                Label timeLabel = new Label();
                timeLabel.Text = times[row - 1];
                timeLabel.Dock = DockStyle.Fill;
                timeLabel.TextAlign = ContentAlignment.MiddleCenter;
                timeLabel.Padding = new Padding(5); // Add padding for spacing
                timetableLayout.Controls.Add(timeLabel, 0, row);

                // Add ComboBoxes in the remaining cells for subject selection
                for (int col = 1; col <= 5; col++)
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.Dock = DockStyle.Fill;
                    comboBox.Margin = new Padding(5); // Add margin for better spacing
                                                      // Populate ComboBox with subjects (example data, replace with your data source)
                    comboBox.Items.AddRange(new string[] { "Math", "Science", "History", "English", "Art" });
                    timetableLayout.Controls.Add(comboBox, col, row);
                }
            }

            // Add the timetable layout to the second row of the main layout
            mainLayout.Controls.Add(timetableLayout, 0, 1);

            // Add a button for submitting at the bottom
            Button submitButton = new Button();
            submitButton.Text = "Submit Timetable";
            submitButton.Dock = DockStyle.Fill;
            submitButton.Padding = new Padding(10);
            submitButton.Click += sbtBtn_Click;  // Attach your event handler
            mainLayout.Controls.Add(submitButton, 0, 2);

            // Add the main layout to the form
            this.Controls.Add(mainLayout);
        }


        private void AddTimeTableForm_Load(object sender, EventArgs e)
        {
            
        }

        private void sbtBtn_Click(object sender, EventArgs e)
        {
            // add the timetable to db
        }
    }
}
