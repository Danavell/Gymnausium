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
        bool Create(InternalInfoUser user);

        [OperationContract]
        bool Update(InternalInfoUser user);

        [OperationContract]
        bool Disable(ExternalInfoUser user);

        [OperationContract]
        bool BlockUser(ExternalInfoUser user);

        [OperationContract]
        ICollection<ExternalInfoUser> GetMatchedUsers();
    }
}
