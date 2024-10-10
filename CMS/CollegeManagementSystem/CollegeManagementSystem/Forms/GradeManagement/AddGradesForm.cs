using CollegeManagementSystem.Controllers;
using CollegeManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeManagementSystem.Forms.GradeManagement
{
    public partial class AddGradesForm : Form
    {
        
        public int TchID { get; set; }
        public AddGradesForm()
        {
            ScoreController scoreController = new ScoreController();
            StudentController studentController = new StudentController();
            SubjectController subjectController = new SubjectController();
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
        }

        private void AddGradesForm_Load(object sender, EventArgs e)
        {
            dptLabel.Text=TchID.ToString();
        }

        // list out the students from the depmartment
    }
}
