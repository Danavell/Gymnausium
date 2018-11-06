using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace Data_Access_Layer
{
    public interface IUserDAO
    {
        Task<bool> Create(InternalInfoUser user);
        Task<bool> Update(InternalInfoUser user);
        Task<bool> Login_Validation(string email, string password);
    }
}
