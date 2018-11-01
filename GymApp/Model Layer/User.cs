using System;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Model_Layer
{
    [DataContract]
    [KnownType(typeof(InternalInfoUser))]
    [KnownType(typeof(ExternalInfoUser))]

    /*User is the base type inherited by both Internal and External User Info.
     * InternalInfoUser will be used to input a new user's info
     * ExternalInfoUser won't expose a User's email address, password or last name to other users
     * ExternalInfoUser will therefore be used when providing a list of mathcing Users.
     */

    public abstract class User
    {
        [DataMember] public Guid User_Guid { get; set; }
        [DataMember] public string First_Name { get; set; }
        [DataMember] public int Age { get; set; }
        [DataMember] public string Location_Data { get; set; }
        [DataMember] public string Description { get; set; }

        public User() { }
        public User(Guid user_guid, string fname, int age, string loc, string desc)
        {
            User_Guid = user_guid; First_Name = fname; Age = age; Location_Data = loc; Description = desc;
        }
    }

    [DataContract]
    public class InternalInfoUser : User
    {
        [DataMember] public string Email { get; set; }
        [DataMember] public string Password { get; set; }
        [DataMember] public string Last_Name { get; set; }

        public InternalInfoUser() { }
        public InternalInfoUser(Guid user_guid, string email, string password, string fname, string lname, int age, string loc, string desc) : base(user_guid, fname, age, loc, desc)
        {
            Email = email; Password = password; Last_Name = lname;
        }
    }

    [DataContract]
    public class ExternalInfoUser : User
    {
        [DataMember] public bool Account_Active { get; set; }
        [DataMember] public DateTime Last_Login { get; set; }
        public ExternalInfoUser() { }
        public ExternalInfoUser(bool acc, DateTime lastlog, Guid user_guid, string fname, int age, string loc, string desc) : base(user_guid, fname, age, loc, desc)
        {
            Account_Active = acc; Last_Login = lastlog;
        }
    }
}