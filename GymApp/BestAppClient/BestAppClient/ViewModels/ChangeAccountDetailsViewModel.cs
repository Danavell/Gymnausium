using Model_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestAppClient.ViewModels
{
    public class ChangeAccountDetailsViewModel : BaseViewModel
    {
        public int GenderIndex { get; set; }

        public InternalInfoUser User { get; set; }

        public ChangeAccountDetailsViewModel()
        {
            Title = "Change details";
            //Get user from db
            User = new InternalInfoUser()
            {
                Age = 23,
                Email = "123@ucn.dk",
                First_Name = "Sama",
                Last_Name = "Lama",
                Gender = 1,
                Weight = 77,
                Description = "askjdjkafh kashdfkhafk laksjflkasjf  salkfj lajsdflkj ",
                Password = "123",
            };
            GenderIndex = User.Gender;
        }
    }
}
