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
     /*   private int gender;
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

        Button btnCancel;
        Button btnCreate;
        
            */
        public SignUpManually ()
		{
         /*   List<String> genders = new List<String>();
            genders.Add("Male");
            genders.Add("Female");
            genders.Add("Not defined");

            Picker genderPic = new Picker();
            genderPic.ItemsSource = genders;

            var stackayout = new StackLayout { Children = { genderPic, weightEntry, emailEntry, passwordEntry, fnameEntry, lnameEntry, ageEntry, descEntry } };

          
            

            weight = int.Parse(weightEntry.Text);*/
			InitializeComponent();
           
		}
	}
}