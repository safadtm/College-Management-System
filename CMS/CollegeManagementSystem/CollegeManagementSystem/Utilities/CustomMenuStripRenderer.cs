using System.Drawing;
using System.Windows.Forms;

namespace CollegeManagementSystem.Utilities  
{
    public class CustomMenuStripColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return AppColors.AccentColor; }  // Color when item is selected
        }

        public override Color MenuItemBorder
        {
            get { return AppColors.HighlightColor; }  // Border color when hovered
        }

        public override Color ToolStripDropDownBackground
        {
            get { return AppColors.NeutralColor; }  // Dropdown menu background
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return AppColors.PrimaryColor; }  // Gradient start when item is clicked
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return AppColors.SecondaryColor; }  // Gradient end when item is clicked
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return AppColors.AccentColor; }  // Gradient for selected menu item start
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return AppColors.PrimaryColor; }  // Gradient for selected menu item end
        }
    }
}
