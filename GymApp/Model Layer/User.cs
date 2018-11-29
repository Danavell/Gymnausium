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
        public enum Genders { Male, Female, Unspecified }

        [DataMember] public Guid User_Guid { get; set; }
        [DataMember] public string First_Name { get; set; }
        [DataMember] public int Age { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public int Weight { get; set; }
        [DataMember] public string Gender { get; set; }
        public User() { }
        public User(Guid user_guid, string gender, int weight, string fname, int age, string desc)
        {
            User_Guid = user_guid;
            First_Name = fname;
            Age = age;
            Description = desc;
            Gender = gender;
            Weight = weight;
        }
    }
}