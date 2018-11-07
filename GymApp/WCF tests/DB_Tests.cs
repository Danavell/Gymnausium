using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model_Layer;
using Data_Access_Layer.Repositories;
using System.Threading.Tasks;

namespace Database_Tests
{
    [TestClass]
    public class Database_Tests
    {
        [TestMethod]
        public void Create_User_Test() { 
        
            bool x = Create_Outcome().Result;
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void Validation_Test()
        {
            bool x = Validation_Outcome("email", "password").Result;
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void Validation_Fail_Test()
        {
            bool x = Validation_Outcome("false", "false").Result;
            Assert.IsFalse(x);
        }
        
        public void Update_User_Test()
        {
            bool x = Update_Outcome().Result;
            Assert.IsTrue(x);
        }

        public async Task<bool> Create_Outcome()
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.NewGuid();

            return await userDAO.Create(new InternalInfoUser(g, 0, 100, "email", "password", "fname", "lname", 100, "desc", false));
        }

        public async Task<bool> Validation_Outcome(string email, string password)
        {
            UserDAO userDAO = new UserDAO();
            return await userDAO.Login_Validation(email, password);
        }

        public async Task<bool> Update_Outcome()
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.NewGuid();
            return await userDAO.Update(new InternalInfoUser(g, 0, 100, "email", "password", "fname", "lname", 100, "desc", false));
        }
    }
}
