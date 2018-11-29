using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BestAppClient.ViewModels;
using BestAppClient.Model;

namespace BestAppClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatCollection : ContentPage
	{
        ListUsersViewModel viewModel;
		public ChatCollection ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new ListUsersViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }        
    }
}