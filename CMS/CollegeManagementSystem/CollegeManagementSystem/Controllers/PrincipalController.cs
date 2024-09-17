using CollegeManagementSystem.Data;
using CollegeManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Controllers
{
    public class PrincipalController
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        // Principal Register Controller 
        public bool RegisterPrincipal(string fullName, string email, string phone, string dob, string gender, string address, string joined, string experience, string username, string password)
        {
            Principal principal = new Principal
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                DOB = dob,
                Gender = gender,
                Address = address,
                Joined = joined,
                Experience = experience,
                Username = username,
                Password = password
            };

           
            return databaseHelper.InsertPrincipal(principal);
        }

        // principal login controller
        public bool ValidatePrincipalLogin(string username, string password)
        {
            return databaseHelper.ValidatePrincipalCredentials(username, password);
        }

        // principal profile fetching

        public Principal GetPrincipalByUsername(string username)
        {
            return databaseHelper.GetPrincipalByUsername(username);
        }

        // edit principal profile
        public bool UpdatePrincipalProfile(Principal principal)
        {
           return databaseHelper.UpdatePrincipal(principal);
        }


    }
}
