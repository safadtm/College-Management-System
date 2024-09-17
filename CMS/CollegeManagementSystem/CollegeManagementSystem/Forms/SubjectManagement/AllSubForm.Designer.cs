namespace CollegeManagementSystem.Forms.SubjectManagement
{
    partial class AllSubForm
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
            label1 = new Label();
            dataGridViewSubjects = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjects).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(253, 30);
            label1.Name = "label1";
            label1.Size = new Size(266, 30);
            label1.TabIndex = 3;
            label1.Text = "Subjects in your college";
            // 
            // dataGridViewSubjects
            // 
            dataGridViewSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubjects.Location = new Point(168, 81);
            dataGridViewSubjects.Name = "dataGridViewSubjects";
            dataGridViewSubjects.Size = new Size(450, 246);
            dataGridViewSubjects.TabIndex = 2;
            // 
            // AllSubForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dataGridViewSubjects);
            Name = "AllSubForm";
            Text = "AllSubForm";
            Load += AllSubForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewSubjects;
    }
}