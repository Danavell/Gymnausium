using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Model_Layer;

namespace Data_Access_Layer.Repositories
{
    class MOCK_DAO_Connection
    {
        static void Main(string[] args)
        {
            InternalInfoUser iiu = new InternalInfoUser(new Guid(), 0, 100, "email", "password", "fname", "lname", 100, "desc", false);
            Console.WriteLine(new UserDAO().Create(iiu));
        }
    }
}
