﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 


namespace WCF_Gym_App
{
    public class UserService : IUserService
    {
        IUserDAO _dao;
        public UserService() { }
        public UserService(IUserDAO dao)
        {
            this._dao = dao;
        }

        public async Task<bool> Create(InternalInfoUser user)
        {
            return await _dao.Create(user);
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
            return await _dao.Update(user);
        }

        public Task<bool> BlockUser(ExternalInfoUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid?> Login_Validation(string email, string password)
        {
            return await _dao.Login_Validation(email, password);
        }
    }
    public class MockDAO : IUserDAO
    {
        public Task<bool> Create(InternalInfoUser user)
        {
            return Task.Run(() => user.Password == "password");
        }

        public Task<Guid?> Login_Validation(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(InternalInfoUser user)
        {
            return Task.Run(() => user.Password == "password");
        }
    }

}
