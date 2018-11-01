using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymAppService;
using Model_Layer;
using Data_Access_Layer;
using Moq;
namespace WCF_tests
{
    [TestClass]
    public class WCF_Test
    {
        [TestMethod]
        public void CreateTest()
        {
            MockDAO mock = new MockDAO();
            UserService us = new UserService(mock);
            Assert.IsTrue(us.Create(new InternalInfoUser(new Guid(), "a@hotmail.com", "wow", "a", "b", 100, "jhjjkhk", "ghjhg")));
        }

        [TestMethod]
        public void UpdateTest()
        {
            MockDAO mock = new MockDAO();
            UserService us = new UserService(mock);
            Assert.IsTrue(us.Create(new InternalInfoUser(new Guid(), "a@hotmail.com", "wow", "a", "b", 100, "jhjjkhk", "ghjhg")));
        }
    }

    public class MockDAO : IDAO
    {
        public bool Create(InternalInfoUser user)
        {
            if (user.Password.Equals("wow")) return true;
            else return false;
        }

        public bool Update(InternalInfoUser user)
        {
            if (user.Password.Equals("wow"))
            {
                return true;
            }
            else return false;
        }
    }
}
