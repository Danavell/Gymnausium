using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access_Layer; 
using GymAppService;
using Ninject;
using Ninject.Modules;

namespace SignalR
{
    public class Dependencies : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserDAO>().To<MockDAO>();
}
    }
}