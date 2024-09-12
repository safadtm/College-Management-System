using CollegeManagementSystem.Utilities;
namespace CollegeManagementSystem
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            // Set background color for the form
            this.BackColor = AppColors.BackgroundColor;

            // Set colors for Label (label1)
           // label1.ForeColor = AppColors.TextColor; // Text color
          //  label1.BackColor = AppColors.SecondaryColor; // Background color (optional)

            // Set colors for Button (button1)
         //   button1.BackColor = AppColors.PrimaryColor; // Background color
        //    button1.ForeColor = AppColors.TextColor; // Text color

        }
    }
}
