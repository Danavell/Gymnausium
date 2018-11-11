using Model_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinClient.ViewModels
{
    public class ChangeAccountDetailsViewModel
    {
        public string Title { get; set; }

        public IList<string> Genders { get { return Enum.GetNames(typeof(User.Genders)); } }
        public string SelectedGender { get; set; }
        private User.Genders SelectedGenderEnum
        {
            get
            {
                Enum.TryParse(SelectedGender, out User.Genders gender);
                return gender;
            }
        }

        public InternalInfoUser User { get; set; }
        public string OldEmail { get; set; }

        public ChangeAccountDetailsViewModel(InternalInfoUser user)
        {
            User = user;
            OldEmail = user.Email;
            Title = "Change detials";
        }
    }
}
