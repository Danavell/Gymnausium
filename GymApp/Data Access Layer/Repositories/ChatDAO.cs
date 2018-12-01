using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Shared;
using Model_Layer;

namespace Data_Access_Layer.Repositories
{
    public class ChatDAO : IChat
    {
        public async Task<bool> Add_Message(Message message, Guid chat_guid)
        {
            return await Task.FromResult(Insert_Message(message, chat_guid));
        }

        public async Task<bool> Create_Chat(Guid chat_guid, List<Guid> participants, string group_name)
        {
            return await Task.FromResult(Add_chat(chat_guid, participants, group_name));
        }

        public async Task<IEnumerable<Chat>> Retrieve_Chats(Guid user_guid, int message_range, int message_start_position, int chat_range, int chat_start_position, double latitude, double longitude)
        {
            return await Task.FromResult(Return_Chats(user_guid, message_range, message_start_position, chat_range, chat_start_position, latitude, longitude));
        }

        private bool Insert_Message(Message message, Guid chat_guid)
        {
            /*READUNCOMMITTED
             * No one including the original creator of the message can edit or delete it.
             * Therefore there can no be concurrency problem
            */
            var transaction = TransactionContext.New(IsolationLevel.ReadUncommitted);

            try
            {
                DBCommand command = new DBCommand("INSERT INTO [Message] (message_datetime, message_text, message_chat_guid, user_guid) VALUES (@DATE_TIME, @MESSAGE_TEXT, @MESSAGE_CHAT_GUID, @USER_GUID)", transaction);

                command.AddQueryParamters("@DATE_TIME", message.Message_Datetime);
                command.AddQueryParamters("@MESSAGE_TEXT", message.Message_Text);
                command.AddQueryParamters("@MESSAGE_CHAT_GUID", chat_guid); 
                command.AddQueryParamters("@USER_GUID", message.User_Guid);

                Update_Last_Modified_User_Chat(message, chat_guid, transaction);

                command.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private void Update_Last_Modified_User_Chat(Message message, Guid chat_guid, TransactionContext transaction)
        {
            DBCommand update_command = new DBCommand("UPDATE [User_Chat] SET last_modified = GETUTCDATE() WHERE chat_guid = @CHAT_GUID AND user_guid = @USER_GUID", transaction);

            update_command.AddQueryParamters("@CHAT_GUID", chat_guid);
            update_command.AddQueryParamters("@USER_GUID", message.User_Guid);

            update_command.ExecuteNonQuery();
        }

        private bool Add_chat(Guid chat_guid, List<Guid> participants, string group_name)
        {
            var transaction = TransactionContext.New(IsolationLevel.ReadUncommitted);

            try
            {
                DBCommand command = new DBCommand("INSERT INTO [Chat] (chat_guid, chat_group_name) VALUES (@GUID, @GROUP_NAME)", transaction);

                command.AddQueryParamters("@GUID", chat_guid);
                command.AddQueryParamters("@GROUP_NAME", group_name);
                command.ExecuteNonQuery();

                foreach (Guid user_guid in participants)
                {
                    DBCommand second = new DBCommand("INSERT INTO [User_Chat] (user_guid, chat_guid, last_modified) VALUES (@USER_GUID, @CHAT_GUID, GETUTCDATE())", transaction);

                    second.AddQueryParamters("@USER_GUID", user_guid);
                    second.AddQueryParamters("@CHAT_GUID", chat_guid);

                    second.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private IEnumerable<Chat> Return_Chats(Guid user_guid, int message_range, int message_start_position, int chat_range, int chat_start_position, double latitude, double longitude)
        {
            var result_set = new List<Chat>();

            var command = new DBCommand("SELECT TOP (@RANGE) * FROM ( SELECT ROW_NUMBER() OVER (ORDER BY last_modified) AS row_number, chat_guid, user_guid, last_modified FROM [User_Chat]) AS foo WHERE user_guid = @USER_GUID AND row_number >= (@START)");

            command.AddQueryParamters("@RANGE", chat_range);
            command.AddQueryParamters("@USER_GUID", user_guid);
            command.AddQueryParamters("@START", chat_start_position);

            command.ExecuteReaderWithRowAction((rdr) =>
            {
                result_set.Add(
                    new Chat()
                    {
                        Chat_Guid = (Guid)rdr["chat_guid"],
                        Messages = Chat_Return_Messages((Guid)rdr["chat_guid"], message_range, message_start_position, latitude, longitude),
                        Last_Modified = (DateTime)rdr["last_modified"]
                    }
                );
            });

            return result_set;
        }

        private IEnumerable<Message> Chat_Return_Messages(Guid chat_guid, int message_range, int message_start_position, double latitude, double longitude)
        {
            var command = new DBCommand("SELECT TOP 8 * FROM ( SELECT ROW_NUMBER() OVER (ORDER BY message_datetime) AS row_number, message_datetime, message_text, message_chat_guid, user_guid FROM [Message]) AS foo WHERE message_chat_guid = 'BD7E4018-4794-4C17-917B-E1BFC0185143' AND row_number >= (@START)");
    
            var result_set = new List<Message>();

            UserDAO userdao = new UserDAO();

            command.AddQueryParamters("@RANGE", message_range);
            command.AddQueryParamters("@CHAT_GUID", chat_guid);
            command.AddQueryParamters("@START", message_start_position);
            command.ExecuteReaderWithRowAction((rdr) =>
            {
                result_set.Add(
                    new Message()
                    {
                        Message_Datetime = (DateTime)rdr["message_datetime"],
                        Message_Text = rdr["message_text"] as string,
                        User_Guid = (Guid)rdr["user_guid"]
                    }
                );
            });
            return result_set;
        }
    }
}