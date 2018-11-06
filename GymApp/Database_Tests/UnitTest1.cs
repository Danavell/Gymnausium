using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model_Layer;
using Data_Access_Layer;
using Data_Access_Layer.Repositories;
using System.Threading.Tasks;

namespace Database_Tests
{
    [TestClass]
    public class Database_Tests
    {
        [TestMethod]
        public void Create_User_Test() { 
        
            bool x = Outcome();
            Assert.IsTrue(x);
        }

        public bool Outcome()
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.NewGuid();

            return userDAO.Create(new InternalInfoUser(g, 0, 100, "email", "password", "fname", "lname", 100, "desc", false));
        }
    }
}
