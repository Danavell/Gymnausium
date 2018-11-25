﻿using Model_Layer;
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
            Guid guid = Guid.NewGuid();
            InternalInfoUser user = new InternalInfoUser(guid, gender, weight, email, password, fname, lname, age, desc);
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