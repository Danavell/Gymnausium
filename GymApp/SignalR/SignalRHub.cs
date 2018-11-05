using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using ServiceProxy;
using Model_Layer;

namespace SignalR
{
    public class SignalRHub : Hub
    {
        IProxy _proxy;
        public SignalRHub(IProxy proxy)
        {
            this._proxy = proxy;
        }
        public void Hello()
        {
            Clients.All.hello();
        }

        public bool Create(Guid user_guid, string email, string password, string fname, string lname, int age, string desc)
        {
            Task<bool> outcome = _proxy.Create(new InternalInfoUser(user_guid, email, password, fname, lname, age, desc));
            return outcome.Result;
        }
    }
}