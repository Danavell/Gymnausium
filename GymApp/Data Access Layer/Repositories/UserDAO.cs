using Data_Access_Layer.Shared;
using Model_Layer;
using System;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class UserDAO : IUserDAO
    { 
        private bool AddUser(InternalInfoUser user)
        {
            try
            {
                DBCommand command = new DBCommand("INSERT INTO [user] (ID, gender, weght, email, psswrd, first_name, last_name, age, descrption, dsbld) VALUES (@Guid, @Gender, @Weight, @Email, @Password, @Fname, @Lname, @Age, @Descr, @Disabled)");

                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Gender", user.Gender);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Email", user.Email);
                command.AddQueryParamters("@Password", user.Password);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Descr", user.Description);
                command.AddQueryParamters("@Disabled", 1);

                command.ExecuteNoneQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private bool UpdateUser(InternalInfoUser user)
        {
            DBCommand command = null;
            try
            {
                command = new DBCommand("UPDATE [User] " +
                                            "SET Email = @Email, Password = @Password, Fname = @Fname, Lname = @Lname, Age = @Lname, descr = @descr) " +
                                            "WHERE Guid = @Guid)");

                command.AddQueryParamters("@E", user.User_Guid);
                command.AddQueryParamters("@Email", user.Email);
                command.AddQueryParamters("@Password", user.Password);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@descr", user.Description);

                command.ExecuteNoneQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(InternalInfoUser user)
        {
            return AddUser(user);
        }

        public async Task<bool> Update(InternalInfoUser user)
        {
            return await Task.FromResult(UpdateUser(user));
        }

        Task<bool> IUserDAO.Create(InternalInfoUser user)
        {
            throw new NotImplementedException();
        }
    }
}
