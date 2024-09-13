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
    public partial class principalloginform : Form
    {
        public principalloginform()
        {
            InitializeComponent();
        }

        private void principalloginform_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            principalregistrationform form1 = new principalregistrationform();
            form1.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // forget password page
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;

            this.Hide();
            PrincipalDashboard principalDashboard = new PrincipalDashboard
            {
                Username = username 
            };

            principalDashboard.Show();
        }
    }
}
