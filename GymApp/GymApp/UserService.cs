using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model_Layer;
using Data_Access_Layer;
using System.Threading.Tasks;

namespace GymAppService
{
    public class UserService : IUserService
    {
        IUserDAO _dao;   
        public UserService() { }
        public UserService(IUserDAO dao) { this._dao = dao; }
        
        public async Task<bool> Create(InternalInfoUser user)
        {
            return await Task.Run(() =>_dao.Create(user));
        }

        public async Task<bool> Disable(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ExternalInfoUser>> GetMatchedUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(InternalInfoUser user)
        {
            return await Task.Run(() => _dao.Update(user));
        }

        public Task<bool> BlockUser(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }
    }
}