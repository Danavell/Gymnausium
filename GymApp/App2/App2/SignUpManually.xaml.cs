using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinClient
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    
	public partial class SignUpManually : ContentPage
	{
      //  (ID, gender, weght, email, psswrd, first_name, last_name, age, descrption, dsbld)
        Entry password = new Entry  { IsPassword = true, Placeholder = "Password" };
        Entry username = new Entry {Placeholder = "Username" };
        Entry username = new Entry { Placeholder = "Username" };
        Entry username = new Entry { Placeholder = "Username" };
        Entry username = new Entry { Placeholder = "Username" };
        Entry username = new Entry { Placeholder = "Username" };
        Entry username = new Entry { Placeholder = "Username" };

        public SignUpManually ()
		{
			InitializeComponent ();

            StackLayout panel = new StackLayout;

            
		}
	}
}