using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model_Layer;
using Data_Access_Layer.Repositories;
using System.Threading.Tasks;

namespace Database_Tests
{
    [TestClass]
    public class UserDB_Tests
    {
        [TestMethod]
        public void Create_User_Test() { 
        
            bool x = Create_Outcome().Result;
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void Validation_Test()
        {
            Guid test_guid = new Guid();
            Guid x = (Guid)Validation_Outcome("email", "password").Result;
            Assert.IsFalse(x.ToString() == test_guid.ToString());
        }

        [TestMethod]
        public void Validation_Fail_Test()
        {
            Guid test_guid = new Guid();
            Guid x = (Guid)Validation_Outcome("false", "false").Result;
            Assert.IsFalse(x.ToString() == test_guid.ToString());
        }
        
        public void Update_User_Test()
        {
            bool x = Update_Outcome().Result;
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void Determine_Gender_ID()
        {
            UserDAO us = new UserDAO();
            Assert.IsTrue(us.Determine_Gender_ID("Female") == 1);
        }

        [TestMethod]
        public void Determine_Gender_Label()
        {
            UserDAO us = new UserDAO();
            Assert.IsTrue(us.Determine_Gender_Label(0) == "Male");
        }
        public async Task<bool> Create_Outcome()
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.NewGuid();

            return await userDAO.Create(new InternalInfoUser(g, "Male", 100, "email@email", "password", "fname", "lname", 100, "desc"));
        }

        [TestMethod]
        public void Get_Single_ExternalInfoUser()
        {
            UserDAO us = new UserDAO();
            Guid guid = new Guid("67C4E11D-97DC-49C1-85FB-84516519AA7E");
            Assert.IsTrue(us.Get_Single_User(guid).First_Name.Equals("fname"));
        }

        public async Task<Guid?> Validation_Outcome(string email, string password)
        {
            UserDAO userDAO = new UserDAO();
            return await userDAO.Login_Validation(email, password);
        }

        public async Task<bool> Update_Outcome()
        {
            UserDAO userDAO = new UserDAO();
            Guid g = Guid.NewGuid();
            return await userDAO.Update(new InternalInfoUser(g, "Male", 100, "email", "password", "fname", "lname", 100, "desc"));
        }
    }
}
