﻿namespace CollegeManagementSystem
{
    partial class SplashScreenForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            label1 = new Label();
            panel2 = new Panel();
            button5 = new Button();
            pictureBox4 = new PictureBox();
            button6 = new Button();
            panel3 = new Panel();
            button7 = new Button();
            pictureBox5 = new PictureBox();
            button8 = new Button();
            panel1 = new Panel();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(34, 40, 49);
            label1.Location = new Point(364, 84);
            label1.Name = "label1";
            label1.Size = new Size(719, 45);
            label1.TabIndex = 0;
            label1.Text = "Welcome to College Management System";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(113, 201, 206);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(button6);
            panel2.Location = new Point(431, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(576, 106);
            panel2.TabIndex = 6;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.FromArgb(0, 173, 181);
            button5.Location = new Point(89, 0);
            button5.Name = "button5";
            button5.Size = new Size(487, 106);
            button5.TabIndex = 4;
            button5.Text = "Log in as teacher";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(203, 241, 245);
            pictureBox4.Dock = DockStyle.Left;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(89, 106);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.FromArgb(0, 173, 181);
            button6.Location = new Point(0, 0);
            button6.Name = "button6";
            button6.Size = new Size(576, 106);
            button6.TabIndex = 0;
            button6.Text = "Log in as principal";
            button6.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(113, 201, 206);
            panel3.Controls.Add(button7);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(button8);
            panel3.Location = new Point(431, 473);
            panel3.Name = "panel3";
            panel3.Size = new Size(576, 116);
            panel3.TabIndex = 7;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.FromArgb(0, 173, 181);
            button7.Location = new Point(89, 0);
            button7.Name = "button7";
            button7.Size = new Size(487, 116);
            button7.TabIndex = 4;
            button7.Text = "Log in as student";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.FromArgb(203, 241, 245);
            pictureBox5.Dock = DockStyle.Left;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(89, 116);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.FromArgb(0, 173, 181);
            button8.Location = new Point(0, 0);
            button8.Name = "button8";
            button8.Size = new Size(576, 116);
            button8.TabIndex = 0;
            button8.Text = "Log in as principal";
            button8.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(113, 201, 206);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(431, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(576, 106);
            panel1.TabIndex = 8;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(0, 173, 181);
            button1.Location = new Point(89, 0);
            button1.Name = "button1";
            button1.Size = new Size(487, 106);
            button1.TabIndex = 4;
            button1.Text = "Log in as principal";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(203, 241, 245);
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(89, 106);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Segoe UI Emoji", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(0, 173, 181);
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(576, 106);
            button2.TabIndex = 0;
            button2.Text = "Log in as principal";
            button2.UseVisualStyleBackColor = true;
            // 
            // SplashScreenForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(166, 227, 233);
            ClientSize = new Size(1396, 712);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label1);
            ForeColor = Color.Cornsilk;
            Name = "SplashScreenForm";
            Text = "Splash Screen";
            Load += SplashScreenForm_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel2;
        private Button button5;
        private PictureBox pictureBox4;
        private Button button6;
        private Panel panel3;
        private Button button7;
        private PictureBox pictureBox5;
        private Button button8;
        private Panel panel1;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
    }
}
