using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace GymApp
{
    class Validator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            string dbUsername = null; // Get from db
            string dbPassword = null; // Get from db
            if (userName == /*dbUsername*/ "admin" && password == /*dbPassword*/ "passw0rd")
                return;

            throw new SecurityTokenException("Unknown Username or Password");
        }
    }
}
