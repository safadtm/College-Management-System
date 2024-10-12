using CollegeManagementSystem.Forms.LoginForms;
using CollegeManagementSystem.Utilities;
namespace CollegeManagementSystem
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            this.BackColor = AppColors.NeutralColor;
            pictureBox1.BackColor = AppColors.HighlightColor;
            pictureBox4.BackColor = AppColors.SecondaryColor;
            pictureBox5.BackColor = AppColors.AccentColor;

        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            principalloginform form1 = new principalloginform();
            form1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            teacherloginform form2 = new teacherloginform();
            form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            studentloginform form3 = new studentloginform();
            form3.Show();
        }
    }
}
