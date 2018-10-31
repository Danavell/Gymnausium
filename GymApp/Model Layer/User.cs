using System;
using System.Runtime.Serialization;

namespace Model_Layer
{
    [DataContract]
    public class User
    {
        [DataMember] public Guid User_Guid { get; set; }
        [DataMember] public bool Account_Active { get; set; }
        [DataMember] public string Email { get; set; }
        [DataMember] public string First_Name { get; set; }
        [DataMember] public string Last_Name { get; set; }
        [DataMember] public string Location_Data{ get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public DateTime Last_Login { get; set; }

        public User() { }
        public User(Guid user_guid, bool activity, string email, string fname, string lname, string loc, string desc, DateTime lastlog)
        {
            User_Guid = user_guid; Account_Active = activity; Email = email;
            First_Name = fname; Last_Name = lname; Location_Data = loc;
            Description = desc; Last_Login = lastlog;
        }
    }
}
