using System;
using System.Collections.Generic;
using System.Text;

namespace BestAppClient.Model
{
    public class InternalInfoUser : User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Last_Name { get; set; }

        public InternalInfoUser() { }
        public InternalInfoUser(Guid user_guid, int gender, int weight, string email, string password, string fname, string lname, int age, string desc) : base(user_guid, gender, weight, fname, age, desc)
        {
            Email = email;
            Password = password;
            Last_Name = lname;
        }
    }
}
