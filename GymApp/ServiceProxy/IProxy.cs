using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace ServiceProxy
{
    public interface IProxy
    {
        Task<bool> Create(InternalInfoUser user);

        Task<bool> Update(InternalInfoUser user);

        Task<bool> Disable(ExternalInfoUser user);

        Task<bool> BlockUser(ExternalInfoUser user);

        Task<ICollection<ExternalInfoUser>> GetMatchedUsers();
    }
}
