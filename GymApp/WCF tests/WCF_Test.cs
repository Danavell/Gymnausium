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
        }

        [TestMethod]
        public void UpdateTest()
        {
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
