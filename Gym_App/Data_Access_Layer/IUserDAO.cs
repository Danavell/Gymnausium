using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public interface IUserDAO
    {
        Task<bool> Create(InternalInfoUser user);
        Task<bool> Update(InternalInfoUser user);
        Task<Guid?> Login_Validation(string email, string password);
    }
}
