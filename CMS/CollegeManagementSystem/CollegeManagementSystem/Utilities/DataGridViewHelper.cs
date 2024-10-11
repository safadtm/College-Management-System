using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Utilities
{
    public class DataGridViewHelper
    {
        public static void AdjustDataGridViewSizeToFitColumns(DataGridView dataGridView)
        {
            // Calculate total column width
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                totalColumnWidth += column.Width;
            }

            // Add padding to the width (optional)
            totalColumnWidth += dataGridView.Margin.Left + dataGridView.Margin.Right;

            // Set DataGridView width to fit all columns
            dataGridView.Width = totalColumnWidth;

            // Optionally, adjust DataGridView height to fit all rows
            int totalHeight = dataGridView.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalHeight += row.Height;
            }
            totalHeight += dataGridView.Margin.Top + dataGridView.Margin.Bottom;

            // Adjust the height of the DataGridView to fit all rows
            dataGridView.Height = totalHeight;

            // Disable scrollbars
            dataGridView.ScrollBars = ScrollBars.None;
        }

        // Reusable CellFormatting function for attendance status
        public static void FormatAttendanceCell(DataGridView dataGridView, DataGridViewCellFormattingEventArgs e, string statusColumnName)
        {
            // Check if we are in the specified "Status" column
            if (dataGridView.Columns[e.ColumnIndex].Name == statusColumnName)
            {
                // Get the value of the cell
                string statusValue = dataGridView.Rows[e.RowIndex].Cells[statusColumnName].Value?.ToString();

                // Apply the appropriate color
                if (statusValue == AttendanceStatus.Present)
                {
                    e.CellStyle.BackColor = AppColors.PresentColor;
                    e.CellStyle.ForeColor = AppColors.NeutralColor;
                }
                else if (statusValue == AttendanceStatus.Absent)
                {
                    e.CellStyle.BackColor = AppColors.AbsentColor;
                    e.CellStyle.ForeColor = AppColors.NeutralColor;
                }
            }

        }
    }
}
