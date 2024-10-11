namespace CollegeManagementSystem.Forms.AttendanceManagement
{
    partial class AllAttendenceForm
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
            dataGridView1 = new DataGridView();
            dptLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(63, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(441, 208);
            dataGridView1.TabIndex = 5;
            // 
            // dptLabel
            // 
            dptLabel.AutoSize = true;
            dptLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dptLabel.Location = new Point(112, 29);
            dptLabel.Name = "dptLabel";
            dptLabel.Size = new Size(97, 30);
            dptLabel.TabIndex = 4;
            dptLabel.Text = "dptLabel";
            // 
            // AllAttendenceForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(601, 450);
            Controls.Add(dataGridView1);
            Controls.Add(dptLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AllAttendenceForm";
            Text = "ViewAttendence";
            Load += AllAttendenceForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label dptLabel;
    }
}