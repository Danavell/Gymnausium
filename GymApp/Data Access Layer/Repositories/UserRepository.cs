using Data_Access_Layer.shared;
using Data_Access_Layer.Shared;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    class UserRepository : IUserDAO
    { 
        private bool AddUser(InternalInfoUser user)
        {
            try
            {
                var command = new DBCommand("INSERT INTO [User] " +
                                            "(Guid, Email, Password, Fname, Lname, Age, location, descr) " +
                                            "VALUES (@Guid, @Email, @Password, @Fname, @Lname, @Age, @Descr)");

                command.AddQueryParamters("@Email", user.User_Guid);
                command.AddQueryParamters("@Email", user.Email);
                command.AddQueryParamters("@Password", user.Password);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@descr", user.Description);

                return command.ExecuteBoolQuery();
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool UpdateUser(InternalInfoUser user)
        {
            try
            {
                var command = new DBCommand("UPDATE [User] " +
                                            "SET Email = @Email, Password = @Password, Fname = @Fname, Lname = @Lname, Age = @Lname, descr = @descr) " +
                                            "WHERE Guid = @Guid)");

                command.AddQueryParamters("@Email", user.User_Guid);
                command.AddQueryParamters("@Email", user.Email);
                command.AddQueryParamters("@Password", user.Password);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@descr", user.Description);

                return command.ExecuteBoolQuery();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Create(InternalInfoUser user)
        {
            return await Task.Run(() => AddUser(user));
        }

        public async Task<bool> Update(InternalInfoUser user)
        {
            return await Task.Run(() => UpdateUser(user));
        }

    }
}
