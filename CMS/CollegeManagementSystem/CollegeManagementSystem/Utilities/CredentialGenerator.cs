using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Utilities
{
    public class CredentialGenerator
    {
        private static int _lastUsedNumber = 1000;
        private static string _shortName = "MPLY";

        public static (string Username, string Password) GenerateCredentials(string userType)
        {
            _lastUsedNumber++; 

            string username = $"{_shortName.ToUpper()}{userType.ToUpper()}{_lastUsedNumber}";
            string password = username; 

          
            return (username, password);
        }
    }
}
