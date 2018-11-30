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
                DBCommand command = new DBCommand("INSERT INTO [Message] (" +
                      "message_datetime, message_text, message_chat_guid, user_guid) " +
                      "VALUES (@DateTime, @MessageText, @MessageChatGuid, @UserGuid)", transaction);

                command.AddQueryParamters("@DateTime", message.Message_Datetime);
                command.AddQueryParamters("@MessageText", message.Message_Text);
                command.AddQueryParamters("@MessageChatGuid", chat_guid); 
                command.AddQueryParamters("@UserGuid", message.Message_Author.User_Guid);

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

        private bool Add_chat(Guid chat_guid, List<Guid> participants, string group_name)
        {
            var transaction = TransactionContext.New(IsolationLevel.ReadUncommitted);

            try
            {
                DBCommand command = new DBCommand("INSERT INTO [Chat] (" +
                    "chat_guid, chat_group_name) " +
                    "VALUES (@Guid, @Group_Name)", transaction);

                command.AddQueryParamters("@Guid", chat_guid);
                command.AddQueryParamters("@Group_Name", group_name);
                command.ExecuteNonQuery();

                foreach (Guid user_guid in participants)
                {
                    DBCommand second = new DBCommand("INSERT INTO [User_Chat] (" +
                        "user_guid, chat_guid) " +
                        "VALUES (@User_Guid, @Chat_Guid)", transaction);

                    second.AddQueryParamters("@User_Guid", user_guid);
                    second.AddQueryParamters("@Chat_Guid", chat_guid);
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

            var command = new DBCommand("SELECT TOP @CHAT_RANGE * FROM [Chat] INNER JOIN [User_Chat] ON [Chat].chat_guid = [User_Chat].chat_guid WHERE ROWNUM >= @START_POSITION AND user_guid = @USER_GUID");

            command.AddQueryParamters("@CHAT_RANGE", chat_range);
            command.AddQueryParamters("@START_POSITION", chat_start_position);
            command.AddQueryParamters("@USER_GUID", user_guid);
            
            command.ExecuteReaderWithRowAction((rdr) =>
            {
                result_set.Add(
                    new Chat()
                    {
                        Message_Chat_Guid = (Guid)rdr["chat_guid"],
                        Messages = Chat_Return_Messages((Guid)rdr["chat_guid"], message_range, message_start_position)
                    }
                );
            });

            return result_set;
        }

        private IEnumerable<Message> Chat_Return_Messages(Guid chat_guid, int message_range, int message_start_position)
        {
            var command = new DBCommand("SELECT TOP @MESSAGE_RANGE * FROM [Message] WHERE ROWNUM >= @START_POSITION AND chat_guid = @CHAT_GUID");

            var result_set = new List<Message>();

            UserDAO userdao = new UserDAO();

            command.AddQueryParamters("@MESSAGE_RANGE", message_range);
            command.AddQueryParamters("@START_POSITION", message_start_position);
            command.AddQueryParamters("@CHAT_GUID", chat_guid);
            command.ExecuteReaderWithRowAction((rdr) =>
            {
                result_set.Add(
                    new Message()
                    {
                        Message_Datetime = (DateTime)rdr["message_datetime"],
                        Message_Text = rdr["message_text"] as string,
                        Message_Author = userdao.Get_Single_User((Guid)rdr["user_guid"])
                    }
                );
            });
            return result_set;
        }
    }
}