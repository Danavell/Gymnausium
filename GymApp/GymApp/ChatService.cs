using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace GymApp
{
    class ChatService : IChatService
    {
        readonly IChatService _cs;
        public ChatService(IChatService cs)
        {
            _cs = cs;
        }

        public Task<bool> Add_Message(Message message, Guid chat_guid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create_Chat(Guid chat_guid, IEnumerable<Guid> participants, string group_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> Retrieve_Chats(Guid user_guid, int start_position, int chat_range, double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
