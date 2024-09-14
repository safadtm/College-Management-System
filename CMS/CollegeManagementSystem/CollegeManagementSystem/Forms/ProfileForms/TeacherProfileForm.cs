using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.ProfileForms
{
    public partial class TeacherProfileForm : Form
    {
        public TeacherProfileForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TeacherProfileForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Hi, Full Name";
            label2.Text = "Username : princi";
            label3.Text = "Full Name : hello joker";
            label4.Text = "Email : princi@gmail.com";
            label5.Text = "Phone : 9687451232";
            label6.Text = "Date of birth : 10-45-1994";
            label7.Text = "Gender : Male";
            label8.Text = "Addres : xyz, road ernakulam";
            label9.Text = "Joined : 15-10-2024";
            label10.Text = "Experince : UC College Aluva";
        }
    }
}
