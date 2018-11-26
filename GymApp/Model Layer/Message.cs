using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer
{
    public class Message
    {
        public DateTime Message_Datetime { get; set; }
        public string Message_Text { get; set; }
        public Guid Message_Chat_Guid { get; set; }
        public ExternalInfoUser Message_Author { get; set; }
    }
}
