using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model_Layer;
using System.Text;

namespace BestAppClient.ViewModels
{
    public class ListChatViewModel
    {
        public ObservableCollection<Chat> ChatCollection { get; set; } = new ObservableCollection<Chat>();

        public ListChatViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                Chat chat = new Chat();
                Message message = new Message();

                List<Message> messages = new List<Message>();

                message.Message_Author = new ExternalInfoUser(new Guid(), "Dave", 18, 0, 80, "fuck this", 1);
                message.Message_Text = "Whats up bro?";
                messages.Add(message);
                chat.Messages = messages;
                ChatCollection.Add(chat);
            }
        }
    }
}
