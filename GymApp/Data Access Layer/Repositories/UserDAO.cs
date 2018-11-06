using Data_Access_Layer.Shared;
using Model_Layer;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class UserDAO : IUserDAO
    { 
        private bool Check_Credentials(string email, string password)
        {
            DBCommand command = new DBCommand("EXEC dbo.Login_Authentication @Email = @email, @Password = @password");

            command.AddQueryParamters("@email", email);
            command.AddQueryParamters("@password", password);

            int result = command.ExecuteNoneQuery();
            return Convert.ToBoolean(result);
        }

        private bool AddUser(InternalInfoUser user)
        {
            var transaction = TransactionContext.New(IsolationLevel.Serializable);

            try
            {
                DBCommand command = new DBCommand("INSERT INTO [user] (" +
                    "user_guid, first_name, last_name, gender, weigh, descrip) " +
                    "VALUES (@Guid, @Fname, @Lname, @Gender, @Weight,@Descr)", transaction);

                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Gender", user.Gender);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Descr", user.Description);

                command.ExecuteNoneQuery();
                int active = user.Disabled ? 1 : 0;

                DBCommand second_command = new DBCommand("INSERT INTO [user_Account_Info] (" +
                    "email, password, last_login, account_active, user_guid) " +
                    "VALUES (@Email, @Password, @Last_Login, @Account_Active, @User_Guid)",
                    transaction);

                second_command.AddQueryParamters("@Email", user.Email);
                second_command.AddQueryParamters("@Password", user.Password);
                second_command.AddQueryParamters("@Last_Login", DateTime.UtcNow);
                second_command.AddQueryParamters("@Account_Active", active);
                second_command.AddQueryParamters("@User_Guid", user.User_Guid);

                second_command.ExecuteNoneQuery();

                transaction.Commit();
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
            var transaction = TransactionContext.New(IsolationLevel.Serializable);

            try
            {
                DBCommand command = new DBCommand("UPDATE [User] " +
                    "SET user_guid = @Guid, first_name = @Fname, last_name = @Lname, gender = @Gender, weigh = @Weight, descrip = @Description" +
                    "WHERE Guid = @Guid)",
                    transaction);

                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Gender", user.Gender);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Description", user.Description);

                command.ExecuteNoneQuery();
                int active = user.Disabled ? 1 : 0;

                DBCommand second_command = new DBCommand("UPDATE [User] " +
                    "SET user_guid = email = @Email, password = @Password, last_login = @Last_Login, account_active = @Account_Active" +
                    "WHERE user_guid = @Guid)",
                    transaction);

                second_command.AddQueryParamters("@Email", user.Email);
                second_command.AddQueryParamters("@Password", user.Password);
                second_command.AddQueryParamters("@Last_Login", DateTime.UtcNow);
                second_command.AddQueryParamters("@Account_Active", active);

                transaction.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Create(InternalInfoUser user)
        {
            return await Task.FromResult(AddUser(user));
        }

        public async Task<bool> Update(InternalInfoUser user)
        {
            return await Task.FromResult(UpdateUser(user));
        }

        public async Task<bool> Login_Validation(string email, string password)
        {
            return await Task.FromResult(Check_Credentials(email, password));
        }
    }
}
