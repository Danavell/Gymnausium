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
    public partial class ListUsersPage : ContentPage
    {
        public ListUsersPage()
        {
            InitializeComponent();
            BindingContext = new ListUsersViewModel();
        }
    }
}