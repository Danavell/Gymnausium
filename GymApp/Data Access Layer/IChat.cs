using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace Data_Access_Layer
{
    interface IChat
    {
        //Add message to a pre-existing chat
        Task<bool>Add_Message(Message message, Guid chat_guid);

        //Create new chat
        Task<bool> Create_Chat(Guid chat_guid, List<Guid> participants, string group_name);

        //Return all chats associated to a user
        Task<IEnumerable<Chat>> Retrieve_Chats(Guid user_guid, int message_range, int message_start_position, int chat_range, int chat_start_position, double latitude, double longitude);
    }
}
