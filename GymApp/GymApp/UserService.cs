using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model_Layer;
using Data_Access_Layer;

namespace GymAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserService : IUserService
    {

        public bool BlockUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Disable(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetMatchedUsers()
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
