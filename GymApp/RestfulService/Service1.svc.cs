using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Model_Layer;
using Data_Access_Layer;
using Data_Access_Layer.Repositories;

namespace RestfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        IUserDAO _dao;
        //public Service1(IUserDAO dao)
        //{
        //    this._dao = dao;
        //}

        public Service1()
        {
            _dao = new UserDAO();
        }
        public Task<bool> BlockUser(string user_guid, string target_guid)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateUser(string user_guid, string gender, string weight, string email, string password, string fname, string lname, string age, string desc)
        {
            return await _dao.Create(new InternalInfoUser(Guid.NewGuid(), gender, Convert.ToInt16(weight), email, password, fname, lname, Convert.ToInt16(age), desc));
        }

        public Task<bool> DisableUser(string user_guid)
        {
            return Task.Run(() => user_guid == "1");
        }

        public Task<ICollection<ExternalInfoUser>> GetMatchedUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Guid?> LoginValidation(string email, string password)
        {
            var guid = new Guid?();
            if (email == "email" && password == "password")
                return Task.Run(() => guid);
            else return Task.Run(() => new Guid?());
        }

        public Task<bool> UpdateFilters(string user_guid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(string user_guid, string gender, string weight, string email, string password, string fname, string lname, string age, string desc)
        {
            throw new NotImplementedException();
        }
    }
}
