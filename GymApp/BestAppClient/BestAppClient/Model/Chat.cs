using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BestAppClient.Model
{
    public class Chat
    {
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string Last_Author()
        {
            return Messages.Last().Message_Author.First_Name;
        }

        public string Last_Message()
        {
            return Messages.Last().Message_Text;
        }
    }
}
