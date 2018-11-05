using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model_Layer;
using Data_Access_Layer;
using Data_Access_Layer.Repositories;

namespace Database_Tests
{
    [TestClass]
    public class Database_Tests
    {
        [TestMethod]
        public void Create_User_Test()
        {
            InternalInfoUser iiu = new InternalInfoUser(new Guid(), 0, 100, "email", "password", "fname", "lname", 100, "desc", false);
            IUserDAO userDAO = new UserDAO();
            Console.WriteLine(userDAO.Create(iiu));
        }
    }
}
