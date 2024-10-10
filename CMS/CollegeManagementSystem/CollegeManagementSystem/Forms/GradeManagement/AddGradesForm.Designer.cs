namespace CollegeManagementSystem.Forms.GradeManagement
{
    partial class AddGradesForm
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
            dptLabel = new Label();
            SuspendLayout();
            // 
            // dptLabel
            // 
            dptLabel.AutoSize = true;
            dptLabel.Location = new Point(333, 24);
            dptLabel.Name = "dptLabel";
            dptLabel.Size = new Size(70, 21);
            dptLabel.TabIndex = 0;
            dptLabel.Text = "dptLabel";
            // 
            // AddGradesForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(800, 450);
            Controls.Add(dptLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "AddGradesForm";
            Text = "AddGradesForm";
            Load += AddGradesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label dptLabel;
    }
}