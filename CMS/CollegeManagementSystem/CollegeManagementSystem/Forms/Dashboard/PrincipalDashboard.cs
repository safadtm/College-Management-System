using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.Dashboard
{
    public partial class PrincipalDashboard : Form
    {
        // Property to store the username
        public string Username { get; set; }
        public PrincipalDashboard()
        {
            InitializeComponent();
        }

        private void PrincipalDashboard_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Username))
            {

                label1.Text = $"Welcome, {Username}";
            }

            label2.Text = "Total Teachers : 10";
            label3.Text = "Total Students : 9";
            label4.Text = "Total Departments : 6";
            label5.Text = "Total Courses : 10";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreenForm sp = new SplashScreenForm();
            sp.Show();
        }
    }
}
