using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;
using ServiceProxy.UserServiceReference;

namespace ServiceProxy
{
    public class Proxy : IProxy
    {
        public Task<bool> BlockUser(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(InternalInfoUser user)
        {
            return await Task.Run(() => new UserServiceClient().Create(user));
        }

        public Task<bool> Disable(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ExternalInfoUser>> GetMatchedUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(InternalInfoUser user)
        {
            return await Task.Run(() => new UserServiceClient().Update(user));
        }
    }
}