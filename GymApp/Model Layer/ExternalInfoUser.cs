using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model_Layer
{
    [DataContract]
    public class ExternalInfoUser : User
    {
        [DataMember] public double Distance { get; set; }
        [DataMember] public Filters User_Filters;
        public ExternalInfoUser() { }
        public ExternalInfoUser(int user_guid) { }
        public ExternalInfoUser(Guid user_guid, string fname, int age, string gender, int weight, string desc, double distance, Filters filters) : base(user_guid, gender, weight, fname, age, desc)
        {
            Distance = distance;
            User_Filters = filters;
        }
    }
}
