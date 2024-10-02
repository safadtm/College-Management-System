namespace CollegeManagementSystem.Forms.DepartmentMangement
{
    partial class AddDeptForm
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
            label2 = new Label();
            txtDepartmentName = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 21);
            label1.Name = "label1";
            label1.Size = new Size(405, 30);
            label1.TabIndex = 0;
            label1.Text = "Add new department to your college";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(58, 123);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 1;
            label2.Text = "Department Name ";
            // 
            // txtDepartmentName
            // 
            txtDepartmentName.Location = new Point(236, 123);
            txtDepartmentName.Name = "txtDepartmentName";
            txtDepartmentName.Size = new Size(185, 29);
            txtDepartmentName.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(185, 192);
            button1.Name = "button1";
            button1.Size = new Size(124, 40);
            button1.TabIndex = 3;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddDeptForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(513, 281);
            Controls.Add(button1);
            Controls.Add(txtDepartmentName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AddDeptForm";
            Text = "Add Deptartment Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDepartmentName;
        private Button button1;
    }
}