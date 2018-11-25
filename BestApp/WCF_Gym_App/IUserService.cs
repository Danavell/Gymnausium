using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WCF_Gym_App
{
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
        Task<Guid?> Login_Validation(string email, string password);

        [OperationContract]
        Task<ICollection<ExternalInfoUser>> GetMatchedUsers();
    }
}
