using System;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Model_Layer
{
    [DataContract]
    [KnownType(typeof(InternalInfoUser))]
    [KnownType(typeof(ExternalInfoUser))]

    /*User is the base type inherited by both Internal and External User Info.
     * InternalInfoUser will be used to input a new user's info or to update it
     * ExternalInfoUser won't expose a User's email address, password or last name to other users
     * ExternalInfoUser will therefore be used when providing a list of mathcing Users.
     */

    public abstract class User
    {
        [DataMember] public Guid User_Guid { get; set; }
        [DataMember] public string First_Name { get; set; }
        [DataMember] public int Age { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public bool Disabled { get; set; }
        [DataMember] public int Weight { get; set; }
        [DataMember] public int Gender { get; set; }
        public User() { }
        public User(Guid user_guid, int gender, int weight, string fname, int age, string desc, bool disabled)
        {
            User_Guid = user_guid;
            First_Name = fname;
            Age = age;
            Description = desc;
            Disabled = disabled;
            Gender = gender;
            Weight = weight;
        }
    }

    [DataContract]
    public class InternalInfoUser : User
    {
        [DataMember] public string Email { get; set; }
        [DataMember] public string Password { get; set; }
        [DataMember] public string Last_Name { get; set; }

        public InternalInfoUser() { }
        public InternalInfoUser(Guid user_guid, int gender, int weight, string email, string password, string fname, string lname, int age, string desc, bool disabled) : base(user_guid, gender, weight, fname, age, desc, disabled)
        {
            Email = email;
            Password = password;
            Last_Name = lname;
        }
    }

    [DataContract]
    public class ExternalInfoUser : User
    {
        [DataMember] public bool Account_Active { get; set; }
        [DataMember] public DateTime Last_Login { get; set; }
        public ExternalInfoUser() { }
        public ExternalInfoUser(bool acc, DateTime lastlog, int gender, int weight, Guid user_guid, string fname, int age, string desc, bool disabled) : base(user_guid, gender, weight, fname, age, desc, disabled)
        {
            Account_Active = acc; Last_Login = lastlog;
        }
    }
}