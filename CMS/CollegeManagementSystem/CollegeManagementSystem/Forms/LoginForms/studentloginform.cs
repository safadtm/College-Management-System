using CollegeManagementSystem.Forms.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.LoginForms
{
    public partial class studentloginform : Form
    {
        public studentloginform()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false; // Shows password
            }
            else
            {
                textBox2.UseSystemPasswordChar = true; // Hides password
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // forget password page
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;

            this.Hide();
            StudentDashboard studentDashboard = new StudentDashboard
            {
                Username = username
            };

            studentDashboard.Show();
        }
    }
}
