using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymAppService;
using Unity;
using Data_Access_Layer;
using Unity.Wcf;
using Data_Access_Layer.Repositories;
using GymApp;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IUserDAO, UserDAO>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IChatService, IChatService>();

            using (UnityServiceHost serviceHost = new UnityServiceHost(container, typeof(UserService)))
            {
                serviceHost.Open();
                Console.ReadKey();
            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
