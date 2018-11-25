using Data_Access_Layer.Shared;
using Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class UserDAO : IUserDAO
    { 
        public (bool outcome, ICollection<ExternalInfoUser>) GetMatchedUsers(float latitude, float longitude, int search_distance)
        {
            var resultList = new HashSet<ExternalInfoUser>();

            var command = new DBCommand("EXEC Find_Nearby_Matches @lat = @la, @long = @lo, @search = @srch");

            command.AddQueryParamters("la", latitude);
            command.AddQueryParamters("@lo", longitude);
            command.AddQueryParamters("@Lname", search_distance);

            //command.ExecuteReaderWithRowAction((rdr) =>
            //{
            //    resultList.Add(
            //        new ExternalInfoUser(
            //            user_guid: int.Parse(rdr["ID"].ToString()),
            //            fname: rdr["Fname"] as string
            //    );
            //});
            bool outcome = false;
            return (outcome, resultList);
        }


        private bool? Check_Credentials(string email, string password)
        {
            var transaction = TransactionContext.New(IsolationLevel.Serializable);
            try
            {
                DBCommand command = new DBCommand("EXEC dbo.Count_Login_Authentication @Email = @email, @Password = @password, @Bool = @bool", transaction);
                command.AddQueryParamters("@email", email);
                command.AddQueryParamters("@password", password);
                command.AddQueryParamters("@bool", 0);
                int result = (int)command.ExecuteScalar();

                Change_Last_Login_Date(email, transaction);

                transaction.Commit();

                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        private void Change_Last_Login_Date(string email, TransactionContext transaction)
        {
            DBCommand command = new DBCommand("UPDATE [User_Account_Info] SET last_login = GETUTCDATE() WHERE [User_Account_Info].email = @email", transaction);
            command.AddQueryParamters("@email", email);
            command.ExecuteNonQuery();
        }

        private bool AddUser(InternalInfoUser user)
        {
            var transaction = TransactionContext.New(IsolationLevel.Serializable);

            try
            {
                DBCommand command = new DBCommand("INSERT INTO [user] (" +
                    "user_guid, first_name, last_name, gender, age, weigh, descrip) " +
                    "VALUES (@Guid, @Fname, @Lname, @Gender, @Age, @Weight, @Descr)", transaction);

                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Gender", user.Gender);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Descr", user.Description);

                command.ExecuteNonQuery();

                DBCommand second_command = new DBCommand("INSERT INTO [user_Account_Info] (" +
                    "email, password, last_login, account_active, user_guid) " +
                    "VALUES (@Email, @Password, @Last_Login, @Account_Active, @User_Guid)",
                    transaction);

                second_command.AddQueryParamters("@Email", user.Email);
                second_command.AddQueryParamters("@Password", user.Password);
                second_command.AddQueryParamters("@Last_Login", DateTime.UtcNow);
                second_command.AddQueryParamters("@Account_Active", 1);
                second_command.AddQueryParamters("@User_Guid", user.User_Guid);

                second_command.ExecuteNonQuery();

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
                    "SET user_guid = @Guid, first_name = @Fname, last_name = @Lname, gender = @Gender, age = @Age, weigh = @Weight, descrip = @Description" +
                    "WHERE Guid = @Guid)",
                    transaction);

                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Gender", user.Gender);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Descr", user.Description);

                command.ExecuteNonQuery();

                DBCommand second_command = new DBCommand("UPDATE [User] " +
                    "SET user_guid = email = @Email, password = @Password, last_login = @Last_Login, account_active = @Account_Active" +
                    "WHERE user_guid = @Guid)",
                    transaction);

                second_command.AddQueryParamters("@Email", user.Email);
                second_command.AddQueryParamters("@Password", user.Password);
                second_command.AddQueryParamters("@Last_Login", DateTime.UtcNow);
                second_command.AddQueryParamters("@Account_Active", 1);

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
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

        public async Task<bool?> Login_Validation(string email, string password)
        {
            return await Task.FromResult(Check_Credentials(email, password));
        }
    }
}
