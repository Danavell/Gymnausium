using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BestAppClient.Model
{
    public class ExternalInfoUser : User
    {
        public float Distance { get; set; }
        public ExternalInfoUser(int user_guid) { }
        public ExternalInfoUser(Guid user_guid, string fname, int age, int gender, int weight, string desc, float distance) : base(user_guid, gender, weight, fname, age, desc)
        {
            Distance = distance;
        }
    }
}
