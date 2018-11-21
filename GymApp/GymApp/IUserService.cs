 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace GymAppService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        Task<bool> Create(InternalInfoUser user);

        [OperationContract]
        Task<bool> Update(InternalInfoUser user);

        [OperationContract]
        Task<bool> Disable(ExternalInfoUser user);

        [OperationContract]
        Task<bool> BlockUser(ExternalInfoUser user);
        [OperationContract]
        Task<bool?> Login_Validation(string email, string password);

        [OperationContract]
        Task<ICollection<ExternalInfoUser>> GetMatchedUsers();
    }
}