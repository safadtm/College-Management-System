using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Utilities
{
    public static class AppColors
    {
        // Primary colors
        public static Color PrimaryColor = ColorTranslator.FromHtml("#002D62"); // Navy Blue
        public static Color SecondaryColor = ColorTranslator.FromHtml("#00A8E8"); // Sky Blue

        // Neutral colors
        public static Color BackgroundColor = ColorTranslator.FromHtml("#F8F9FA"); // Light Gray
        public static Color TextColor = Color.White; // White

        // Success, warning, error colors
        public static Color SuccessColor = ColorTranslator.FromHtml("#28A745"); // Green
        public static Color WarningColor = ColorTranslator.FromHtml("#FFC107"); // Yellow
        public static Color ErrorColor = ColorTranslator.FromHtml("#DC3545"); // Red

        // Accent colors
        public static Color AccentColor = ColorTranslator.FromHtml("#20C997"); // Teal
    }
}
