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

namespace CollegeManagementSystem.Forms.UserManagement.Teacher
{
    public partial class AddTeacherForm : Form
    {
        public AddTeacherForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // generate username and password button
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // only action performed after the username and password generated
            MessageBox.Show("New Teacher Added");
            this.Hide();
            PrincipalDashboard principalDashboard = new PrincipalDashboard();
            principalDashboard.Show();

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
