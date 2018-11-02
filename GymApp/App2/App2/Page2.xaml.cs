using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinClient;

namespace XamarinClient
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
		public Page2 (string username, string password)
		{
			Content = CreatePage(username,password);  //idk why but xaml code creates the UI instead of C#
			InitializeComponent ();
		}

		private View CreatePage(string username, string password)
		{
			var outerStacklayout = new StackLayout()
			{
				Padding = 30,
				Children = {
					new Label() { Text = username + " " + password }

				}
							   
			};
			return outerStacklayout;

		}
	}
}