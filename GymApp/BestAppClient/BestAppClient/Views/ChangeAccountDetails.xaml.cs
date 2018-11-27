using BestAppClient.ViewModels;
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
	public partial class ChangeAccountDetails : ContentPage
	{
        ChangeAccountDetailsViewModel viewModel;
		public ChangeAccountDetails ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new ChangeAccountDetailsViewModel();
		}

        private void AccountSaveClicked(object sender, EventArgs e)
        {
            DisplayAlert("Saved", "Your information has been saved", "Or not...");
        }
        private void ProfileSaveClicked(object sender, EventArgs e)
        {
            DisplayAlert("Saved", "Your information has been saved", "Or not...");
        }
    }
}