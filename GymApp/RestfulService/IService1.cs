using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;

namespace RestfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //We can encrypt the url if needed

        [OperationContract]
        [WebGet(UriTemplate = "CreateUser/{user_guid}/{gender}/{weight}/{email}/{password}/{fname}/{lname}/{age}/{desc}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool CreateUser(string user_guid, string gender, string weight, string email, string password, string fname, string lname, string age, string desc);

        [OperationContract]
        [WebGet(UriTemplate = "UpdateUser/{user_guid}/{gender}/{weight}/{email}/{password}/{fname}/{lname}/{age}/{desc}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> UpdateUser(string user_guid, string gender, string weight, string email, string password, string fname, string lname, string age, string desc);

        [OperationContract]
        [WebGet(UriTemplate = "UpdateFilters/{user_guid}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> UpdateFilters(string user_guid);

        [OperationContract]
        [WebGet(UriTemplate = "DisableUser/{user_guid}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> DisableUser(string user_guid);

        [OperationContract]
        [WebGet(UriTemplate = "BlockUser/{user_guid}/{target_guid}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<bool> BlockUser(string user_guid, string target_guid);

        [OperationContract]
        [WebGet(UriTemplate = "LoginValidation/{email}/{password}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<Guid?> LoginValidation(string email, string password);

        [OperationContract]
        [WebGet(UriTemplate = "GetMatchedUsers", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        Task<ICollection<ExternalInfoUser>> GetMatchedUsers();
    }
}
