using Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinClient.ViewModels;

namespace XamarinClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeAccountDetailsPage : ContentPage
    {
        private ChangeAccountDetailsViewModel viewModel;
        public ChangeAccountDetailsPage(ChangeAccountDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        public ChangeAccountDetailsPage()
        {
            InitializeComponent();
            var user = new InternalInfoUser()
            {
                User_Guid = new Guid(),
                Age = 25,
                Gender = 0,
                Description = "some desc",
                Email = "emaiasd@lala.com",
                First_Name = "David",
                Last_Name ="Gordon",
                Weight = 55,
                Password = "Passw0rd"
            };

            viewModel = new ChangeAccountDetailsViewModel(user);
            BindingContext = viewModel;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            string newEmail = Email.Text;
            throw new NotImplementedException();
            bool success;
            string message = success ? "Your details was changed and saved successfully!" : "There was an error saving your details. Please try again later.";
            DisplayAlert("Success", message, "OK");
        }
    }
}