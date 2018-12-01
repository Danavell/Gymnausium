using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model_Layer;

namespace RestfulService
{
    public class Chat_Service : IChat_Service
    {
        public bool Add_Message(string Message_DateTime, string Message_Text, string Message_Author, string chat_guid)
        {
            throw new NotImplementedException();
        }

        public bool Create_Chat(string chat_guid, string participants, string group_name)
        {
            List<Guid> participants_guids = new List<Guid>();
            foreach (var element in participants.Split('#'){
                participants_guids.Add(new Guid(element));
            }
            return true;
        }

        public Chat Retrieve_Chats(string user_guid, string start_position, string chat_range, string latitude, string longitude)
        {
            throw new NotImplementedException();
        }
    }
}