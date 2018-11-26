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
       Task<bool>Add_Message(Message message);

        //Create new chat
        Task<bool> Create_Chat(Guid chat_guid, IEnumerable<Guid> participants, string group_name);

        //Return all chats associated to a user
        IEnumerable<Chat> Retrieve_Chats(Guid user_guid, int start_position, int chat_range);
    }
}
