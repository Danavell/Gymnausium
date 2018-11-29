using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer
{
    public class Chat
    {
        public Guid Chat_Guid { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
