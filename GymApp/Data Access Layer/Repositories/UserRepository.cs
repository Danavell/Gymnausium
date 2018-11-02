using Data_Access_Layer.shared;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    class UserRepository
    { 
        public void CreateNewUser(InternalInfoUser user)
        {
            var command = new DBCommand("INSERT INTO [User] (Guid, Email, Password, Fname, Lname, Age, location, descr) VALUES (@Guid, @Email, @Password, @Fname, @Lname, @Age, @Location, @Descr)");

            command.AddQueryParamters("@Email", user.User_Guid);
            command.AddQueryParamters("@Email", user.Email);
            command.AddQueryParamters("@Password", user.Password);
            command.AddQueryParamters("@Fname", user.First_Name);
            command.AddQueryParamters("@Lname", user.Last_Name);
            command.AddQueryParamters("@Age", user.Age);
            command.AddQueryParamters("@Location", user.Location_Data);
            command.AddQueryParamters("@descr", user.Description);
                
            command.ExecuteNoneQuery();
        }

        public void UpdateUser(InternalInfoUser user)
        {
            var command = new DBCommand("UPDATE [User] SET Email = @Email, Password = @Password, Fname = @Fname, Lname = @Lname, Age = @Lname, location = @Location, descr = @descr) WHERE Guid = @Guid)");

            command.AddQueryParamters("@Email", user.User_Guid);
            command.AddQueryParamters("@Email", user.Email);
            command.AddQueryParamters("@Password", user.Password);
            command.AddQueryParamters("@Fname", user.First_Name);
            command.AddQueryParamters("@Lname", user.Last_Name);
            command.AddQueryParamters("@Age", user.Age);
            command.AddQueryParamters("@Location", user.Location_Data);
            command.AddQueryParamters("@descr", user.Description);

            command.ExecuteNoneQuery();
        }
    }
}
