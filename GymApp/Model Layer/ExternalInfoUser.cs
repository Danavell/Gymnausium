using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model_Layer
{
    [DataContract]
    public class ExternalInfoUser : User
    {
        [DataMember] public double? Distance { get; set; }
        public ExternalInfoUser() { }
        public ExternalInfoUser(Guid user_guid, string fname, int age, string gender, int weight, string desc, double? distance, Filters filters) : base(user_guid, gender, weight, fname, age, desc)
        {
            Distance = distance;
        }
    }
}
