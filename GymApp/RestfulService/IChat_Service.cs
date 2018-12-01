using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;

namespace RestfulService
{
    interface IChat_Service
    {
        [OperationContract]
        [WebGet(UriTemplate = "Add_Message/{Message_Datetime}/{Message_Text}/{Message_Author}/{chat_guid}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Add_Message(string Message_DateTime, string Message_Text, string Message_Author, string chat_guid);

        [OperationContract]
        [WebGet(UriTemplate = "Create_Chat/{}/{chat_guid}/{particpants}/{group_name}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Create_Chat(string chat_guid, string participants, string group_name);

        [OperationContract]
        [WebGet(UriTemplate = "Create_Chat/{}/{chat_guid}/{particpants}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Create_Chat(string chat_guid, string participants);

        [OperationContract]
        [WebGet(UriTemplate = "Retrieve_Chats/{user_guid}/{start_position}/{chat_range}/{latitude}/{longitude}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Chat Retrieve_Chats(string user_guid, string start_position, string chat_range, string latitude, string longitude);

    }
}
