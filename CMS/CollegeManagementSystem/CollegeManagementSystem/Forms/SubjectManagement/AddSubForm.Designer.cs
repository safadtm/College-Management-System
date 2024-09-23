namespace CollegeManagementSystem.Forms.SubjectManagement
{
    partial class AddSubForm
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
            button1 = new Button();
            label1 = new Label();
            txtSubjectName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmbDepartment = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(186, 255);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 7;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(72, 29);
            label1.Name = "label1";
            label1.Size = new Size(356, 30);
            label1.TabIndex = 4;
            label1.Text = "Add new subject to your college";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(250, 132);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(185, 29);
            txtSubjectName.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(72, 132);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 8;
            label3.Text = "Subject Name ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(72, 181);
            label4.Name = "label4";
            label4.Size = new Size(112, 25);
            label4.TabIndex = 10;
            label4.Text = "Department";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(249, 177);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(186, 29);
            cmbDepartment.TabIndex = 11;
            // 
            // AddSubForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(500, 370);
            Controls.Add(cmbDepartment);
            Controls.Add(label4);
            Controls.Add(txtSubjectName);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "AddSubForm";
            Text = "AddSubForm";
            Load += AddSubForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtSubjectName;
        private Label label3;
        private Label label4;
        private ComboBox cmbDepartment;
    }
}