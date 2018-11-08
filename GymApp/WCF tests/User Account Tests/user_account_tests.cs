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
            bool? x = Validation_Outcome("email", "password").Result;
            if(x != null)
                Assert.IsTrue((bool)x);
        }

        [TestMethod]
        public void Validation_Fail_Test()
        {
            bool? x = Validation_Outcome("false", "false").Result;
            if (x != null)
                Assert.IsFalse((bool)x);
        }

        [TestMethod]
        public void Update_User_Test()
        {
            bool x = Update_Outcome("67C4E11D-97DC-49C1-85FB-84516519AA7E").Result;
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void Update_User_Test_Fail()
        {
            bool x = Update_Outcome("67C4E11D-97DC-49C1-85FB-84716519AB7E").Result;
            Assert.IsFalse(x);
        }

        public async Task<bool> Create_Outcome()
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.NewGuid();

            return await userDAO.Create(new InternalInfoUser(g, 0, 100, "email", "password", "fname", "lname", 100, "desc"));
        }

        public async Task<bool?> Validation_Outcome(string email, string password)
        {
            UserDAO userDAO = new UserDAO();
            return await userDAO.Login_Validation(email, password);
        }

        public async Task<bool> Update_Outcome(string guid)
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.Parse(guid);
            return await userDAO.Update(new InternalInfoUser(g, 0, 100, "email", "password", "fname", "lname", 1000, "desc"));
        }
    }
}