using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Repositories;
using System.Threading.Tasks;
using Model_Layer;

namespace Database_Tests
{
    /// <summary>
    /// Summary description for ChatDB_Tests
    /// </summary>
    [TestClass]
    public class ChatDB_Tests
    {
        [TestMethod]
        public void Add_Chat()
        {
            bool x = Insert_Chat().Result;
            Assert.IsTrue(x);
        }
    
        [TestMethod]
        public void Add_Message()
        {
            bool x = Insert_Message().Result;
            Assert.IsTrue(x);
        }

        [TestMethod]
        public void Retrieve_Chats()
        {
            List<Chat> chats = (List<Chat>)Return_Chats().Result;
            Assert.IsTrue(chats[0].Message_Chat_Guid == new Guid("FC5F04A8-BEAC-40B0-9EFA-358995C272BC"));
        }

        public async Task<IEnumerable<Chat>> Return_Chats()
        {
            Guid guid = new Guid("398D626F-75BE-48DD-9F5C-08B73BAF405D");
            ChatDAO chat_dao = new ChatDAO();

            return await chat_dao.Retrieve_Chats(
                new Guid("398D626F-75BE-48DD-9F5C-08B73BAF405D"),
                20,
                0,
                20,
                0,
                9.954167,
                57.037278
               );
        }

        public async Task<bool> Insert_Chat()
        {
            Guid chat_guid = Guid.NewGuid();
            ChatDAO chat_dao = new ChatDAO();

            List<Guid> participants = new List<Guid>();

            Guid one = new Guid("398D626F-75BE-48DD-9F5C-08B73BAF405D");
            Guid two = new Guid("67C4E11D-97DC-49C1-85FB-84516519AA7E");
            Guid three = new Guid("9B0CFEBB-3EBD-4A49-86D3-87FB51E5C395");

            return await chat_dao.Create_Chat(chat_guid, participants, "");
        }

        public async Task<bool> Insert_Message()
        {
            ChatDAO chat_dao = new ChatDAO();

            Message message = new Message();
            message.Message_Author = new ExternalInfoUser() { User_Guid = new Guid("398D626F-75BE-48DD-9F5C-08B73BAF405D") };
            message.Message_Text = "Hell yeah!";
            message.Message_Datetime = DateTime.UtcNow;

            return await chat_dao.Add_Message(message, new Guid("FC5F04A8-BEAC-40B0-9EFA-358995C272BC"));
        }
    }
}
