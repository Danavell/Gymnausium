using Model_Layer;
using System;
using System.Collections.Generic;
using System.Text;
using GymAppService;

namespace Controllers
{
    class UserController
    {
        UserService service = new UserService();
        public async System.Threading.Tasks.Task CreateUserAsync(Guid user_guid, int gender, int weight, string email, string password, string fname, string lname, int age, string desc, bool disabled)
        {
            InternalInfoUser user = new InternalInfoUser(user_guid, gender, weight, email, password, fname, lname, age, desc, disabled);
            await service.Create(user);  
        
        }

        // To be implemented
        public void DeleteUser()
        {

        }
        public void UpdateUser()
        {

        }
        public void GetUser()
        {

        }
    }
}