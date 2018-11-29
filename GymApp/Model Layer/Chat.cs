using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model_Layer
{
    public class Chat
    {
        public Guid Message_Chat_Guid { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string ChatName{ get; set; }
        public string LastMessage { get; set; }
        public void UpdateLastMessageDetails() //have to do it like this instead of returning methods for data binding
        {
            // in future should get the other participants name by checking users guid
            ChatName = Messages.Last().Message_Author.First_Name;
            LastMessage = Messages.Last().Message_Text;
        }
    }
}
