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
    public class WCF_Tests
    {
        [TestMethod]
        public async Task CreateTest()
        {
            MockDAO mock = new MockDAO();
            UserService userservice = new UserService(mock);
            InternalInfoUser iiu = new InternalInfoUser(new Guid(), 0, 100, "email@email.com", "password", "fname", "lname", 100, "desc");
            bool x = await userservice.Create(iiu);
            Assert.IsTrue(x);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            MockDAO mock = new MockDAO();
            UserService userservice = new UserService(mock);
            InternalInfoUser iiu = new InternalInfoUser(new Guid(), 0, 100, "email@email.com", "password", "fname", "lname", 100, "desc");
            bool x = await userservice.Update(iiu);
            Assert.IsTrue(x);
        }
    }
}
