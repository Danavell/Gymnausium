using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymAppService;
using Model_Layer;
using Data_Access_Layer;
using Moq;
using System.Threading.Tasks;

namespace WCF_tests
{
    [TestClass]
    public class WCF_Test
    {
        [TestMethod]
        public async Task CreateTest()
        {
            MockDAO mock = new MockDAO();
            UserService userservice = new UserService(mock);
            InternalInfoUser iiu = new InternalInfoUser(new Guid(), "email@email.com", "password", "fname", "lname", 100, "loc", "desc");
            await userservice.Create(iiu);
            Assert.IsTrue(iiu.First_Name.Equals("fname"));
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            MockDAO mock = new MockDAO();
            UserService userservice = new UserService(mock);
            InternalInfoUser iiu = new InternalInfoUser(new Guid(), "email@email.com", "password", "fname", "lname", 100, "loc", "desc");
            await userservice.Update(iiu);
            Assert.IsTrue(iiu.First_Name.Equals("fname"));
        }
    }

    public class MockDAO :IUserDAO
    {
        public Task<bool> Create(InternalInfoUser user)
        {
            return Task.Run(()=> user.Password == "password");
        }

        public Task<bool> Update(InternalInfoUser user)
        {
            return Task.Run(()=> user.Password == "password");
        }
    }
}
