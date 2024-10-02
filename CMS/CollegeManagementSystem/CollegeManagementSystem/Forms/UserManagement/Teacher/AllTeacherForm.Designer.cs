namespace CollegeManagementSystem.Forms.UserManagement.Teacher
{
    partial class AllTeacherForm
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
            dataGridViewTeachers = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeachers).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTeachers
            // 
            dataGridViewTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTeachers.Location = new Point(141, 111);
            dataGridViewTeachers.Name = "dataGridViewTeachers";
            dataGridViewTeachers.Size = new Size(637, 280);
            dataGridViewTeachers.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(248, 49);
            label1.Name = "label1";
            label1.Size = new Size(301, 30);
            label1.TabIndex = 1;
            label1.Text = "All teachers in your college";
            // 
            // AllTeacherForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(837, 476);
            Controls.Add(label1);
            Controls.Add(dataGridViewTeachers);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "AllTeacherForm";
            Text = "AllTeacherForm";
            Load += AllTeacherForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTeachers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTeachers;
        private Label label1;
    }
}