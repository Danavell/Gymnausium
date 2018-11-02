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
    public class UserService : IUserService
    {
        public bool BlockUser(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public bool Create(InternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public bool Disable(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public ICollection<ExternalInfoUser> GetMatchedUsers()
        {
            throw new NotImplementedException();
        }

        public bool Update(InternalInfoUser user)
        {
            throw new NotImplementedException();
        }
    }
}