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

        public bool Create(Guid user_guid, int gender, int weight, string email, string password, string fname, string lname, int age, string desc, bool disabled)
        {
            Task<bool> outcome = _proxy.Create(new InternalInfoUser(user_guid, gender, weight, email, password, fname, lname, age, desc, disabled));
            return outcome.Result;
        }
    }
}