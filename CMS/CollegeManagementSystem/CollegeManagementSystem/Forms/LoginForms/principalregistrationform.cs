using CollegeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.LoginForms
{
    public partial class principalregistrationform : Form
    {
        string gender;
        public principalregistrationform()
        {
            InitializeComponent();
        }

        private void TestDatabaseConnection()
        {
            using (SqlConnection connection = new DatabaseHelper().GetConnection())
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Database connection successful!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Connection failed: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            TestDatabaseConnection();
          //  this.Hide();
          //  principalloginform form2 = new principalloginform();
          //  form2.Show();
        }

        private void principalregistrationform_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
    }
}
