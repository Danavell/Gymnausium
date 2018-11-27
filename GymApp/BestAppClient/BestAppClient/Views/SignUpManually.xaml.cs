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
    

    public partial class SignUpManually : ContentPage
	{
        private int gender;
        Entry genderEntry;

        private int weight;
        Entry weightEntry;

        private string email;
        Entry emailEntry;

        private string password;
        Entry passwordEntry;

        private string fname;
        Entry fnameEntry;

        private string lname;
        Entry lnameEntry;

        private int age;
        Entry ageEntry;

        private string desc;
        Entry descEntry;

        private bool disabled;
       

        public SignUpManually ()
		{
			InitializeComponent();
		}
	}
}