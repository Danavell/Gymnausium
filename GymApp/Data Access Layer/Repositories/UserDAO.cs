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
        public async Task<bool> Create(InternalInfoUser user)
        {
            return await Task.FromResult(AddUser(user));
        }

        public async Task<bool> Update(InternalInfoUser user)
        {
            return await Task.FromResult(UpdateUser(user));
        }

        public async Task<Guid?> Login_Validation(string email, string password)
        {
            return await Task.FromResult(Check_Credentials(email, password));
        }

        private bool AddUser(InternalInfoUser user)
        {
            var transaction = TransactionContext.New(IsolationLevel.Serializable);

            try
            {
                DBCommand command = new DBCommand("INSERT INTO [user] (user_guid, first_name, last_name, gender, age, weigh, descrip) VALUES (@Guid, @Fname, @Lname, @Gender, @Age, @Weight, @Descr)", transaction);
                
                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Gender", Determine_Gender_ID(user.Gender));
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Descr", user.Description);

                command.ExecuteNonQuery();

                DBCommand second_command = new DBCommand("INSERT INTO [user_Account_Info] (email, password, last_login, account_active, user_guid) VALUES (@Email, @Password, GETUTCDATE(), 1, @User_Guid)", transaction);

                second_command.AddQueryParamters("@Email", user.Email);
                second_command.AddQueryParamters("@Password", user.Password);
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
                DBCommand command = new DBCommand("UPDATE [User] SET user_guid = @Guid, first_name = @Fname, last_name = @Lname, gender = @Gender, age = @Age, weigh = @Weight, descrip = @Description WHERE Guid = @Guid)", transaction);

                command.AddQueryParamters("@Guid", user.User_Guid);
                command.AddQueryParamters("@Fname", user.First_Name);
                command.AddQueryParamters("@Lname", user.Last_Name);
                command.AddQueryParamters("@Gender", user.Gender);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Age", user.Age);
                command.AddQueryParamters("@Weight", user.Weight);
                command.AddQueryParamters("@Descr", user.Description);

                command.ExecuteNonQuery();

                DBCommand second_command = new DBCommand("UPDATE [User] SET user_guid = email = @Email, password = @Password, last_login = @Last_Login, account_active = @Account_Active WHERE user_guid = @Guid)", transaction);

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

        private Guid? Check_Credentials(string email, string password)
        {
            var transaction = TransactionContext.New(IsolationLevel.Serializable);
            try
            {
                //DBCommand command = new DBCommand("EXEC dbo.Count_Login_Authentication @Email = @email, @Password = @password, @Bool = @bool", transaction);
                //command.AddQueryParamters("@email", email);
                //command.AddQueryParamters("@password", password);
                //command.AddQueryParamters("@bool", 0);
                //int result = (int)command.ExecuteScalar();

                //Change_Last_Login_Date(email, transaction);

                //transaction.Commit();

                //return Convert.ToBoolean(result);
                return Guid.NewGuid();
            }
            catch (Exception)
            {
                transaction.Rollback();
                return null;
            }
        }

        public (bool outcome, ICollection<ExternalInfoUser>) GetMatchedUsers(double latitude, double longitude, int search_distance)
        {
            var resultList = new List<ExternalInfoUser>();

            var command = new DBCommand("EXEC Find_Nearby_Matches @lat = @la, @long = @lo, @search = @srch");

            command.AddQueryParamters("@la", latitude);
            command.AddQueryParamters("@lo", longitude);
            command.AddQueryParamters("@srch", search_distance);

            command.ExecuteReaderWithRowAction((rdr) =>
            {
                resultList.Add(
                    new ExternalInfoUser(
                        (Guid)rdr["user_guid"],
                        rdr["first_nname"] as string,
                        (int)rdr["age"],
                        Determine_Gender_Label((int)rdr["gender"]),
                        (int)rdr["weigh"],
                        rdr["descrip"] as string,
                        (int)rdr["distance"],
                        Get_Filters((Guid)rdr["user_guid"])
                    )
                );
            });
            bool outcome = false;
            return (outcome, resultList);
        }

        public ExternalInfoUser Get_Single_User(Guid user_guid, double latitude, double longitude)
        {
            DBCommand command = new DBCommand("EXEC Message_Return_User @LAT = @lat, @LONG = @long, @USER_GUID = @user_guid");
            command.AddQueryParamters("@user_guid", user_guid);
            command.AddQueryParamters("@lat", latitude);
            command.AddQueryParamters("@long", longitude);

            ExternalInfoUser user = new ExternalInfoUser();

            command.ExecuteReaderWithRowAction((rdr) =>
            {
                user.User_Guid = (Guid)rdr["user_guid"];
                user.First_Name = rdr["first_name"] as string;
                user.Age = (int)rdr["age"];
                user.Gender = rdr["gender_label"] as string;
                user.Weight = (int)rdr["weigh"];
                user.Description = rdr["descrip"] as string;
                user.Distance = rdr["distance"] as double?;
                //Get_Filters((Guid)rdr["user_guid"]);
            });
            return user;
        }

        public int Determine_Gender_ID(string gender)
        {
            DBCommand command = new DBCommand("select gender_ID from Gender WHERE gender_label = @GENDER");
            command.AddQueryParamters("@GENDER", gender);
            int result = (int)command.ExecuteScalar();
            return result;
        }

        public string Determine_Gender_Label(int gender)
        {
            DBCommand command = new DBCommand("select gender_label from Gender WHERE gender_ID = @GENDER");
            command.AddQueryParamters("@GENDER", gender);
            string result = (string)command.ExecuteScalar();
            return result;
        }

        public Filters Get_Filters(Guid user_guid)
        {
            Filters filters = new Filters();

            DBCommand command = new DBCommand("SELECT * FROM [User_Filters] WHERE user_guid = @USER_GUID");
            command.AddQueryParamters("@USER_GUID", user_guid);

            command.ExecuteReaderWithRowAction((rdr) =>
            {
                filters.Min_Age = (int)rdr["min_age"];
                filters.Max_age = (int)rdr["max_age"];
                filters.Min_Weight = (int)rdr["min_weight"];
                filters.Max_weight = (int)rdr["max_weight"];
                filters.Gender = rdr["gender"] as string;
            });

            return filters;
        }

        private void Change_Last_Login_Date(string email, TransactionContext transaction)
        {
            DBCommand command = new DBCommand("UPDATE [User_Account_Info] SET last_login = GETUTCDATE() WHERE [User_Account_Info].email = @email", transaction);
            command.AddQueryParamters("@email", email);
            command.ExecuteNonQuery();
        }
    }
}