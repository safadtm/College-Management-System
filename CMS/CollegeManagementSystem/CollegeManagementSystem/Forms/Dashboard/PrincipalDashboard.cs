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

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
