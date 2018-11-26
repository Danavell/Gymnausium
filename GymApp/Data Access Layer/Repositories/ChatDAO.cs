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
    class ChatDAO : IChat
    {
        private bool Insert_Message(Message message)
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
                command.AddQueryParamters("@MessageChatGuid", message.Message_Chat_Guid);
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

        private bool Add_chat(Guid chat_guid, IEnumerable<Guid> participants, string group_name)
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

                foreach(Guid user_guid in participants.ToList())
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

        public IEnumerable<Chat> Return_Chats(Guid user_guid, int start_position, int chat_range)
        {
            var result_set = new List<Chat>();

            var command = new DBCommand("SELECT TOP 20 * FROM [Chat] INNER JOIN [User_Chat] ON [Chat].chat_guid = [User_Chat].chat_guid WHERE ROWNUM >= @START_POSITION AND user_guid = @USER_GUID");

            command.AddQueryParamters("@START_POSITION", start_position);
            command.AddQueryParamters("@USER_GUID", user_guid);
            
            command.ExecuteReaderWithRowAction((rdr) =>
            {
                result_set.Add(
                    new Chat()
                    {
                        Chat_Guid = (Guid)rdr["user_guid"]
                    }
                );
            });


            return result_set;
        }

        public async Task<bool> Add_Message(Message message)
        {
            return await Task.FromResult(Insert_Message(message));
        }

        public async Task<bool> Create_Chat(Guid chat_guid, IEnumerable<Guid> participants, string group_name)
        {
            return await Task.FromResult(Add_chat(chat_guid, participants, group_name));
        }

        public IEnumerable<Chat> Retrieve_Chats(Guid user_guid, int message_range, int chat_range)
        {
            throw new NotImplementedException();
        }
    }
}
