using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        Task<bool> Add_Message(Message message);

        [OperationContract]
        Task<bool> Create_Chat(Guid chat_guid, IEnumerable<Guid> participants, string group_name);

        [OperationContract]
        IEnumerable<Chat> Retrieve_Chats(Guid user_guid, int start_position, int chat_range, double latitude, double longitude);
    }
}
