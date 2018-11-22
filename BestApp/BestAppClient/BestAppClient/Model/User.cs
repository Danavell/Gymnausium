using System;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace BestAppClient.Model
{
    /*User is the base type inherited by both Internal and External User Info.
     * InternalInfoUser will be used to input a new user's info or to update it
     * ExternalInfoUser won't expose a User's email address, password or last name to other users
     * ExternalInfoUser will therefore be used when providing a list of mathcing Users.
     */

    public abstract class User
    {
        public enum Genders { Male, Female, Unspecified }

        public Guid User_Guid { get; set; }
        public string First_Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int Gender { get; set; }
        public User() { }
        public User(Guid user_guid, int gender, int weight, string fname, int age, string desc)
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