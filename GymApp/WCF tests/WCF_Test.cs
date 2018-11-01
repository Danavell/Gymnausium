using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymAppService;
using Model_Layer;
using Data_Access_Layer;

namespace WCF_tests
{
    [TestClass]
    public class WCF_Test
    {
        [TestMethod]
        public void CreateTest()
        {
            UserService us = new UserService();
            Assert.IsTrue(us.Create(new InternalInfoUser(new Guid(), "a@hotmail.com", "wow", "a", "b", 100, "jhjjkhk", "ghjhg")));
        }

        [TestMethod]
        public void UpdateTest()
        {
            UserService us = new UserService();
            Assert.IsTrue(us.Create(new InternalInfoUser(new Guid(), "a@hotmail.com", "wow", "a", "b", 100, "jhjjkhk", "ghjhg")));
        }

    }
}
