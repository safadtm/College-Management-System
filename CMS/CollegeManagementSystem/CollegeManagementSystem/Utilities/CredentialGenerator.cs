using CollegeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Utilities
{
    public class CredentialGenerator
    {   
        private static int _lastTeacherNumber = 1000;  // Separate counter for teachers
        private static int _lastStudentNumber = 1000;  // Separate counter for students
        private static string _shortName = "MPLY";    // College short name

        public static (string Username, string Password) GenerateCredentials(string userType)
        {
            DatabaseHelper databaseHelper = new DatabaseHelper();
            int lastUsedNumber = databaseHelper.GetLastUsedNumber(userType);


            lastUsedNumber++;  // Increment the last used number
            databaseHelper.UpdateLastUsedNumber(userType, lastUsedNumber);  

            string username = $"{_shortName.ToUpper()}{userType.ToUpper()}{lastUsedNumber}";
            string password = username;

            return (username, password);
        }
    }

}
