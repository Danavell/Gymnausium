using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class User
    {
        public string User_Guid { get; set; }
        public bool active_account { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string location_data { get; set; }
        public string description { get; set; }
        public DateTime last_login { get; set; }

    }
}
