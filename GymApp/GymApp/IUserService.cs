using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model_Layer;

namespace GymAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool Create(User user);

        [OperationContract]
        bool Update(User user);

        [OperationContract]
        bool Disable(User user);

        [OperationContract]
        bool BlockUser(User user);

        [OperationContract]
        IList<User> GetMatchedUsers();
    }
}
