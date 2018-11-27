using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BestAppClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InternalProfile : ContentPage
	{
		public InternalProfile ()
		{
			InitializeComponent ();
		}

        private void LogoutImage_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "You have logged out", "OK");
        }

        private async void ChangeProfileDetailsImage_TappedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeAccountDetails());
            //DisplayAlert("Alert", "You want to change profile details", "OK");
        }
        private void ChangeProfilePictureImage_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "You want to change profile picture", "OK");
        }
    }
}