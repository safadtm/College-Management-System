namespace CollegeManagementSystem.Forms.DepartmentMangement
{
    partial class AllDeptForm
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
            dataGridViewDepartments = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDepartments
            // 
            dataGridViewDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDepartments.Location = new Point(156, 83);
            dataGridViewDepartments.Name = "dataGridViewDepartments";
            dataGridViewDepartments.Size = new Size(450, 246);
            dataGridViewDepartments.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(219, 30);
            label1.Name = "label1";
            label1.Size = new Size(314, 30);
            label1.TabIndex = 1;
            label1.Text = "Departments in your college";
            // 
            // AllDeptForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(800, 464);
            Controls.Add(label1);
            Controls.Add(dataGridViewDepartments);
            Name = "AllDeptForm";
            Text = "AllDeptForm";
            Load += AllDeptForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewDepartments;
        private Label label1;
    }
}